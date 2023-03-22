using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application;
public class ArticleCategoryApplication : IArticleCategoryApplication
{
    private readonly IArticleCategoryRepository _articleCategoryRepository;
    private readonly IArticleCategoryValidatorService _articleCategoryValidatorService;

    public ArticleCategoryApplication(IArticleCategoryRepository repository, IArticleCategoryValidatorService articleCategoryValidatorService)
    {
        _articleCategoryRepository = repository;
        _articleCategoryValidatorService = articleCategoryValidatorService;
    }

    public void Create(CreateArticleCategory command)
    {
        var articleCategory = new ArticleCategory(command.Title, _articleCategoryValidatorService);
        _articleCategoryRepository.Create(articleCategory);
    }

    public void Rename(RenameArticleCategory command)
    {
        var articleCategory = _articleCategoryRepository.GetBy(command.Id);
        articleCategory.Rename(command.Title);
        //_articleCategoryRepository.SaveChanges();
    }

    public List<ArticleCategoryViewModel> GetList()
    {
        return _articleCategoryRepository.GetAll().Select(x => new ArticleCategoryViewModel
        {
            Id = x.Id,
            Title = x.Title,
            IsDeleted = x.IsDeleted,
            CreationDate = x.CreationDate.ToString()
        }).OrderByDescending(x => x.Id)
        .ToList();
    }

    public RenameArticleCategory Get(long id)
    {
        var articleCategory = _articleCategoryRepository.GetBy(id);
        return new RenameArticleCategory
        {
            Id = articleCategory.Id,
            Title = articleCategory.Title
        };
    }

    public void Remove(long id)
    {
        var articleCategory = _articleCategoryRepository.GetBy(id);
        articleCategory.Remove();
        //_articleCategoryRepository.SaveChanges();
    }

    public void Activate(long id)
    {
        var articleCategory = _articleCategoryRepository.GetBy(id);
        articleCategory.Activate();
        //_articleCategoryRepository.SaveChanges();
    }
}
