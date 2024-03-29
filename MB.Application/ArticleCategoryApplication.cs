﻿using _01_Framework.Infrastructure;
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
    private readonly IUnitOfWork _unitOfWork;
    private readonly IArticleCategoryRepository _articleCategoryRepository;
    private readonly IArticleCategoryValidatorService _articleCategoryValidatorService;

    public ArticleCategoryApplication(IArticleCategoryRepository repository, IArticleCategoryValidatorService articleCategoryValidatorService, IUnitOfWork unitOfWork)
    {
        _articleCategoryRepository = repository;
        _articleCategoryValidatorService = articleCategoryValidatorService;
        _unitOfWork = unitOfWork;
    }

    public void Create(CreateArticleCategory command)
    {
        _unitOfWork.BeginTran();
        var articleCategory = new ArticleCategory(command.Title, _articleCategoryValidatorService);
        _articleCategoryRepository.Create(articleCategory);
        _unitOfWork.CommitTran();
    }

    public void Rename(RenameArticleCategory command)
    {
        _unitOfWork.BeginTran();
        var articleCategory = _articleCategoryRepository.GetBy(command.Id);
        articleCategory.Rename(command.Title);
        //_articleCategoryRepository.SaveChanges();
        _unitOfWork.CommitTran();
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
        _unitOfWork.BeginTran();
        var articleCategory = _articleCategoryRepository.GetBy(id);
        articleCategory.Remove();
        //_articleCategoryRepository.SaveChanges();
        _unitOfWork.CommitTran();
    }

    public void Activate(long id)
    {
        _unitOfWork.BeginTran();
        var articleCategory = _articleCategoryRepository.GetBy(id);
        articleCategory.Activate();
        //_articleCategoryRepository.SaveChanges();
        _unitOfWork.CommitTran();
    }
}
