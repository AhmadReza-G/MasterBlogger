using MB.Application;
using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using MB.Infrastructure.EFCore;
using MB.Infrastructure.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MB.Infrastructure.Core;
public class Bootstrapper
{
    public static void Config(IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();
        serviceCollection.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
        serviceCollection.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
        serviceCollection.AddTransient<IArticleApplication, ArticleApplication>();
        serviceCollection.AddTransient<IArticleRepository, ArticleRepository>();
        serviceCollection.AddDbContext<MasterBloggerContext>(options => options.UseSqlServer(connectionString));
    }
}
