using MB.Domain.ArticleCategoryAgg.Exceptions;
using MB.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleAgg.Services;
public class ArticleValidatorService : IArticleValidatorService
{
    private readonly IArticleRepository _articleRepository;

    public ArticleValidatorService(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public void ThrowExceptionIfExists(string title)
    {
        if (!_articleRepository.IsExists(x => x.Title == title))
            return;

        throw new DuplicatedRecordException("This record already exists in DataBase!");
    }
}
