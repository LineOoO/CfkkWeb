using CfkkWeb.Builders;
using CfkkWeb.Command;
using CfkkWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CfkkWeb.Controllers
{
    public class NewsArticleController : Controller
    {
        private readonly ILogger<NewsArticleController> _logger;

        public NewsArticleController(ILogger<NewsArticleController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            var model = new NewsArticleListBuilder().Build();
            return View(model);
        }

        [Authorize]
        public IActionResult NewNewsArticle()
        {
            var model = new NewsArticleBuilder().Build();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> NewNewsArticle(IFormFile Picture, NewsArticleModel model)
        {
            if (!ModelState.IsValid)
            {
                var newModel = new NewsArticleBuilder().Build();
                return View(newModel);
            }

            if (Picture != null && Picture.Length > 0)
            {
                var fileName = Path.GetFileName(Picture.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/news_images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Picture.CopyToAsync(stream);
                }

                model.PicturePath = $"/uploads/news_images/{fileName}";
            }

            new NewNewsArticleCommand().Execute(model);
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            var model = new NewsArticleBuilder().Build(id);
            return View(model);
        }

        public IActionResult PublishUnpublish(int id, bool publish)
        {
            new PublishUnpublishNewsArticleCommand().Execute(id, publish);
            return RedirectToAction("Index");
        }



    }
}
