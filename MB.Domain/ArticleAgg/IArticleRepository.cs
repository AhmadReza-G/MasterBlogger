using MB.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleAgg;
public interface IArticleRepository
{
    List<Article> GetAll();
    void Add(Article entity);
    Article Get(long id);
    void SaveChanges();
    
}
