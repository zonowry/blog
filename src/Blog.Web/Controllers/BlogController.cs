﻿using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Blog.Application.Articles;
using Blog.Application.Commands;
using Blog.Domain.Articles;
using Blog.Domain.Shared.Articles;
using Blog.Domain.Shared.Collections;
using Blog.Domain.Shared.Utils;
using Blog.Web.Controllers.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers {
    public class BlogController : Controller {
        private readonly ArticleService articleService;
        private readonly IArticleQueries articleQueries;

        public BlogController(ArticleService articleService, IArticleQueries articleQueries) {
            this.articleService = articleService;
            this.articleQueries = articleQueries;
        }


        private IActionResult EnhancedView(string viewName, object? model = null) {
            if (HttpContext.Request.Method.ToUpper() == "GET") {
                return View(viewName, model);
            }

            return PartialView(viewName, model);
        }


        [Route("")]
        [Route("index")]
        public IActionResult Index(int pageIndex = 1, int pageSize = 10) {
            var articles = articleQueries.FindArticles(PagingLimit.FromPageIndexAndSize(pageIndex, pageSize));
            HttpContext.Response.Headers.Add("title", DataTools.MakeWebTitle("首页", true));
            return EnhancedView("Index", articles.Items);
        }


        [Route("article/{code}/{articleId:int}")]
        public async Task<IActionResult> Article(int articleId, string code) {
            var command = new ViewArticleCommand(articleId, "TODO");
            var article = await articleService.ViewArticle(command);
            var bucket = new Dictionary<int, List<ArticleComment>>();
            // 构建评论结构，方便渲染
            var postComments = new List<ArticleComment>();
            article.Comments.ForEach(it => {
                    if (it.RootId != null) {
                        bucket[it.RootId.Value] ??= new List<ArticleComment>();

                        bucket[it.RootId.Value].Add(it);
                    } else {
                        postComments.Add(it);
                    }
                }
            );

            ViewBag.Title = DataTools.MakeWebTitle(article.Title);
            ViewBag.Email = Request.Cookies["email"] ?? string.Empty;
            ViewBag.Website = Request.Cookies["website"] ?? string.Empty;
            ViewBag.Name = Request.Cookies["name"] ?? string.Empty;
            return EnhancedView("Article", new ArticleViewModel(article, postComments, bucket));
        }

        [Route("links")]
        public IActionResult Friends(int page = 1, int row = 10) {
            ViewBag.Title = DataTools.MakeWebTitle("友情链接");
            HttpContext.Response.Headers.Add("title", DataTools.MakeWebTitle("友情链接", true));
            return EnhancedView("Friends");
        }


        [Route("article/{code}/{imageName}")]
        public IActionResult ArticleImage(string code, string imageName) {
            var imagePath = Path.Combine("article", code, imageName);
            return EnhancedView(imagePath, "image/jpeg");
        }


        [Route("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return EnhancedView("_Error404");
        }
    }
}