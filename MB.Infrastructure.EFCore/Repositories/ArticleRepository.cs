using _01_Framework.Infrastructure;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Infrastructure.EFCore.Repositories;
public class ArticleRepository : BaseRepository<long, Article>, IArticleRepository
{
    private readonly MasterBloggerContext _context;

    public ArticleRepository(MasterBloggerContext context) : base(context)
    {
        _context = context;
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
}
