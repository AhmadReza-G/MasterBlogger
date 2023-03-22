using _01_Framework.Infrastructure;
using MB.Application.Contracts.ArticleCategory;
using MB.Application.Contracts.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCategoryAgg;
public interface IArticleCategoryRepository : IRepository<long, ArticleCategory>
{
}

