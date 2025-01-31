using CfkkWeb.Builders;
using CfkkWeb.Command;
using CfkkWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CfkkWeb.Controllers
{
    public class ClubController : Controller
    {
        private readonly ILogger<ClubController> _logger;

        public ClubController(ILogger<ClubController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            var model = new ClubListBuilder().Build();
            return View(model);
        }

        [Authorize(Policy = "AdminOnly")]
        public IActionResult NewClub()
        {
            var model = new ClubBuilder().Build();
            return View(model);
        }

        [HttpPost]
        public IActionResult NewClub(ClubModel model)
        {
            if (!ModelState.IsValid)
            {
                var newModel = new ClubBuilder().Build();
                return View(newModel);
            }
            new NewClubCommand().Execute(model);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var model = new ClubBuilder().Build(id);
            return View(model);
        }

        [Authorize(Policy = "AdminOnly")]
        public IActionResult Delete(int id)
        {
            new DeleteClubCommand().Execute(id);

            return RedirectToAction("Index");
        }
    }
}
