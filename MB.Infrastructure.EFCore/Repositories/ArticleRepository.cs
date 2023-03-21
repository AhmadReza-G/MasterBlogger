using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Infrastructure.EFCore.Repositories;
public class ArticleRepository : IArticleRepository
{
    private readonly MasterBloggerContext _context;

    public ArticleRepository(MasterBloggerContext context)
    {
        _context = context;
    }

    public void Add(Article entity)
    {
        _context.Articles.Add(entity);
        SaveChanges();
    }

    public Article Get(long id)
    {
        return _context.Articles.FirstOrDefault(x => x.Id == id);
    }

    public List<ArticleViewModel> GetList()
    {
        return _context.Articles.Include(x => x.ArticleCategory)
            .Select(x => new ArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                IsDeleted = x.IsDeleted,
                CreationDate = x.CreationDate.ToString(),
                ArticleCategory = x.ArticleCategory.Title
            }).OrderByDescending(x => x.Id)
            .ToList();
    }

    public bool IsExists(string title)
    {
        return _context.Articles.Any(x => x.Title == title);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
