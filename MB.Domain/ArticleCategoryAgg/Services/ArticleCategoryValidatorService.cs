using MB.Domain.ArticleCategoryAgg.Exceptions;

namespace MB.Domain.ArticleCategoryAgg.Services;

public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
{
    private readonly IArticleCategoryRepository _articleCategoryRepository;

    public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
    {
        _articleCategoryRepository = articleCategoryRepository;
    }

    public void ThrowExceptionIfExists(string title)
    {
        if (!_articleCategoryRepository.IsExists(x => x.Title == title))
            return;

        throw new DuplicatedRecordException("This record already exists in DataBase!");
    }
}