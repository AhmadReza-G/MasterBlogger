﻿using _01_Framework.Infrastructure;
using MB.Application;
using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using MB.Application.Contracts.Comment;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EFCore;
using MB.Infrastructure.EFCore.Repositories;
using MB.Infrastructure.Query;
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
        serviceCollection.AddTransient<IArticleValidatorService, ArticleValidatorService>();

        serviceCollection.AddTransient<ICommentApplication, CommentApplication>();
        serviceCollection.AddTransient<ICommentRepository, CommentRepository>();

        serviceCollection.AddTransient<IArticleQuery, ArticleQuery>();

        serviceCollection.AddTransient<IUnitOfWork, UnitOfWorkEF>();

        serviceCollection.AddDbContext<MasterBloggerContext>(options => options.UseSqlServer(connectionString));
    }
}
