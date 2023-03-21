using MB.Application.Contracts.Article;
using MB.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleAgg;
public interface IArticleRepository
{
    List<ArticleViewModel> GetList();
    void Add(Article entity);
    Article Get(long id);
    void SaveChanges();
    bool IsExists(string title);
}
