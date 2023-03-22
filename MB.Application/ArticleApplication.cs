using _01_Framework.Infrastructure;
using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application;
public class ArticleApplication : IArticleApplication
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IArticleRepository _articleRepository;

    public ArticleApplication(IArticleRepository articleRepository, IUnitOfWork unitOfWork)
    {
        _articleRepository = articleRepository;
        _unitOfWork = unitOfWork;
    }

    public void Activate(long id)
    {
        _unitOfWork.BeginTran();
        var article = _articleRepository.GetBy(id);
        article.Activate();
        //_articleRepository.SaveChanges();
        _unitOfWork.CommitTran();
    }

    public void Create(CreateArticle command)
    {
        _unitOfWork.BeginTran();
        var article = new Article(command.Title, command.Image, command.ShortDescription, command.Content, command.ArticleCategoryId);
        _articleRepository.Create(article);
        _unitOfWork.CommitTran();
    }

    public void Edit(EditArticle command)
    {
        _unitOfWork.BeginTran();
        var article = _articleRepository.GetBy(command.Id);
        article.Edit(command.Title, command.Image, command.ShortDescription, command.Content, command.ArticleCategoryId);
        //_articleRepository.SaveChanges();
        _unitOfWork.CommitTran();
    }

    public EditArticle Get(long id)
    {
        var article = _articleRepository.GetBy(id);
        return new EditArticle
        {
            Title = article.Title,
            Image = article.Image,
            ShortDescription = article.ShortDescription,
            Content = article.Content,
            Id = article.Id,
            ArticleCategoryId = article.ArticleCategoryId
        };
    }

    public List<ArticleViewModel> GetList()
    {
        return _articleRepository.GetList();
    }

    public void Remove(long id)
    {
        _unitOfWork.BeginTran();
        var article = _articleRepository.GetBy(id);
        article.Remove();
        //_articleRepository.SaveChanges();
        _unitOfWork.CommitTran();
    }
}
