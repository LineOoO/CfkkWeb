using CfkkWeb.Builders;
using CfkkWeb.Command;
using CfkkWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CfkkWeb.Controllers
{
    public class MemberController : Controller
    {
        private readonly ILogger<MemberController> _logger;

        public MemberController(ILogger<MemberController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            var model = new MemberListBuilder().Build();
            return View(model);
        }

        [Authorize(Policy = "AdminOnly")]
        public IActionResult NewMember()
        {
            var model = new MemberBuilder().Build();
            return View(model);
        }

        [HttpPost]
        public IActionResult NewMember(MemberModel model)
        {
            if (!ModelState.IsValid)
            {
                var newModel = new MemberBuilder().Build();
                return View(newModel);
            }

            new NewMemberCommand().Execute(model);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var model = new MemberBuilder().Build(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(MemberModel model)
        {
            if (!ModelState.IsValid)
            {
                var newModel = new MemberBuilder().Build();
                return View(newModel);
            }
            new EditMemberCommand().Execute(model);

            return RedirectToAction("Index");
        }

        [Authorize(Policy = "AdminOnly")]
        public IActionResult Delete(int id)
        {
            new DeleteMemberCommand().Execute(id);

            return RedirectToAction("Index");
        }
    }
}
