using System.Collections.Generic;
//using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Pages
{
    public class IndexModel : PageModel
    {
        //public List<ArticleQueryView> Articles { get; set; }

        //private readonly IArticleQuery _articleQuery;

        //public Edit(IArticleQuery articleQuery)
        //{
        //    _articleQuery = articleQuery;
        //}

        public void OnGet()
        {
            //Articles = _articleQuery.GetArticles();
        }
    }
}