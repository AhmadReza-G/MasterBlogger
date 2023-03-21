using MB.Domain.ArticleAgg;
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

    public List<Article> GetAll()
    {
        return _context.Articles.OrderByDescending(x => x.Id).ToList();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
