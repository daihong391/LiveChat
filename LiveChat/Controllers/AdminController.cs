using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LiveChat.Models;
using System.ComponentModel.DataAnnotations;

namespace LiveChat.Controllers
{
    public class AdminController : Controller
    {
        LiveChatEntities db = new LiveChatEntities();

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            User user = new User();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                List<LC_User> lcUserList = db.sp_LC_UserValidate(user.UserName, user.Password).ToList();

                if (lcUserList.Any())
                {
                    LC_User lcUser = lcUserList.First();
                    string userID = lcUser.UserID;
                    return RedirectToAction("Console", "Admin", new { userID = userID });
                }
                else
                {
                    ModelState.AddModelError("", "UserName and Password are not matched.");
                    return View(user);
                }
            }
            else
            {
                return View(user);
            }
        }

        public ActionResult Console(string userID)
        {
            LC_User lcUser = db.sp_LC_FindUser(userID).ToList().First();



            return View();
        }

    }
}
