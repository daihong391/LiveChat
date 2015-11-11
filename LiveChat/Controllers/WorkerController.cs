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
        LiveChatEntities db = new LiveChatEntities();

        //
        // GET: /Worker/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                List<LC_User> lcUserList = db.sp_LC_UserValid_CallCentre(user.UserName, user.Password).ToList();

                if (lcUserList.Any())
                {
                    LC_User lcUser = lcUserList.First();

                    string userID = lcUser.UserID;

                    return RedirectToAction("Console", new { userID = userID });
                }
                else
                {
                    ModelState.AddModelError("", "UserName and Password are not matched.");
                }
            }

            return View(user);
        }

        public ActionResult Console(string userID)
        {
            LC_User lcUser = db.sp_LC_FindUser(userID).ToList().First();

            User user = new User
            {
                UserID = lcUser.UserID,
                UserName = lcUser.UserName,
                Password = lcUser.Password,
                UserLevel = lcUser.UserLevel,
                Dept = lcUser.Dept,
                Status = lcUser.Status
            };

            List<LC_Msg> msgList = db.sp_LC_SearchActiveMsg().ToList();

            ViewBag.msgList = msgList;

            return View(user);
        }

    }
}
