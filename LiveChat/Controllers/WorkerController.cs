using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LiveChat.Models;

namespace LiveChat.Controllers
{
    public class WorkerController : Controller
    {
        //
        // GET: /Worker/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            LC_User LCUser = new LC_User();

            LCUser = user.UserValid();

            if (LCUser != null)
            {
                if (LCUser.UserLevel.Trim() != "AD" && LCUser.UserLevel.Trim() != "GU")
                {
                    ModelState.AddModelError("UserLevel", "UserLevel is not allowed to accesss!");
                }
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction("Home", "Worker", new { userID = LCUser.UserID });
            }
            else
            {
                return View(user);
            }
        }

    }
}
