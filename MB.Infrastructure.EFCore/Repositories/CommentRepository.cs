using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Infrastructure.EFCore.Repositories;
public class CommentRepository : ICommentRepository
{
    private readonly MasterBloggerContext _context;

    public CommentRepository(MasterBloggerContext context)
    {
        _context = context;
    }

    public void Create(Comment entity)
    {
        _context.Comments.Add(entity);
        SaveChanges();
    }

    public List<CommentViewModel> GetList()
    {
        return _context.Comments.Include(x => x.Article)
            .Select(x => new CommentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Message = x.Message,
                CreationDate = x.CreationDate.ToString(),
                Status = x.Status,
                Article = x.Article.Title
            }).ToList();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
