using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contracts.ArticleCategory;
public interface IArticleCategoryApplication
{
    List<ArticleCategoryViewModel> GetList();
    void Create(CreateArticleCategory command);
    void Rename(RenameArticleCategory command);
    RenameArticleCategory Get(long id);
    void Remove(long id);
    void Activate(long id);
}
