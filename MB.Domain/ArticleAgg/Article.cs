using MB.Domain.ArticleCategoryAgg;
using MB.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleAgg;
public class Article
{
    public long Id { get; private set; }
    public string Title { get; private set; }
    public string Image { get; private set; }
    public string ShortDescription { get; private set; }
    public string? Content { get; private set; }
    public bool IsDeleted { get; private set; } = false;
    public DateTime CreationDate { get; private set; } = DateTime.Now;
    public long ArticleCategoryId { get; private set; }
    public ArticleCategory ArticleCategory { get; private set; }
    public ICollection<Comment> Comments { get; private set; } = new List<Comment>();
    protected Article()
    {

    }
    public Article(string title, string image, string shortDescription, string? content, long articleCategoryId)
    {
        Validate(title, articleCategoryId);
        Title = title;
        Image = image;
        ShortDescription = shortDescription;
        Content = content;
        ArticleCategoryId = articleCategoryId;
    }
    public void Edit(string title, string image, string shortDescription, string? content, long articleCategoryId)
    {
        Validate(title, articleCategoryId);
        Title = title;
        Image = image;
        ShortDescription = shortDescription;
        Content = content;
    }

    private static void Validate(string title, long articleCategoryId)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException();
        if (articleCategoryId == 0)
            throw new ArgumentOutOfRangeException();
    }

    public void Remove()
    {
        IsDeleted = true;
    }
    public void Activate()
    {
        IsDeleted = false;
    }
}