using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCategoryAgg;
public class ArticleCategory
{
    public long Id { get; private set; }
    public string Title { get; private set; }
    public bool IsDeleted { get; private set; } = false;
    public DateTime CreationDate { get; private set; } = DateTime.Now;
    public ICollection<Article> Articles { get; private set; } = new List<Article>();
    public ArticleCategory(string title, IArticleCategoryValidatorService validatorService)
    {
        GuardAgainstEmptyTitle("create", title);
        validatorService.ThrowExceptionIfExists(title);
        Title = title;
    }
    public void GuardAgainstEmptyTitle(string operationName, string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException("title", $"Cannot {operationName} ArticleCategory with null title!");
    }
    public void Rename(string title)
    {
        GuardAgainstEmptyTitle("rename", title);
        Title = title;
    }
    public void Remove()
    {
        IsDeleted = true;
    }
    public void Activate()
    {
        IsDeleted = false;
    }
}
