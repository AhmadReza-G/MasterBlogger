using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contracts.ArticleCategory;
public class ArticleCategoryViewModel
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public bool IsDeleted { get; set; }
    public required string CreationDate { get; set; }
}
