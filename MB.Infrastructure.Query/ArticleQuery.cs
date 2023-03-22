using MB.Domain.CommentAgg;
using MB.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MB.Infrastructure.Query;

public class ArticleQuery : IArticleQuery
{
    private readonly MasterBloggerContext _context;

    public ArticleQuery(MasterBloggerContext context)
    {
        _context = context;
    }
    public List<ArticleQueryView> GetArticles()
    {
        return _context.Articles.Include(x => x.ArticleCategory)
            .Include(x => x.Comments)
            .Where(x => x.IsDeleted == false)
            .Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                CreationDate = x.CreationDate.ToString(),
                ArticleCategory = x.ArticleCategory.Title,
                Image = x.Image,
                CommentsCount = x.Comments.Count(x => x.Status == Statuses.Confirmed)
            }).ToList();
    }
    public ArticleQueryView? GetArticle(long id)
    {
        return _context.Articles.Include(x => x.ArticleCategory)
            .Include(x => x.Comments)
            .Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                CreationDate = x.CreationDate.ToString(),
                ArticleCategory = x.ArticleCategory.Title,
                Image = x.Image,
                Content = x.Content,
                CommentsCount = x.Comments.Count(x => x.Status == Statuses.Confirmed),
                Comments = MapComments(x.Comments.Where(x => x.Status == Statuses.Confirmed))
            }).FirstOrDefault(a => a.Id == id);

    }

    private static List<CommentQueryView> MapComments(IEnumerable<Comment> comments)
    {
        return (comments.Select(comment => new CommentQueryView
        {
            Name = comment.Name,
            CreationDate = comment.CreationDate.ToString(),
            Message = comment.Message
        })).ToList();
    }
}
