using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class CreateModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public CreateModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(string title)
        {
            
        }
        public RedirectToPageResult OnPost(CreateArticleCategory command)
        {
            _articleCategoryApplication.Create(command);
            return RedirectToPage("./List");
        }
    }
}
