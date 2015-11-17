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

            User user = new User();
            user.UserID = lcUser.UserID;
            user.UserName = lcUser.UserName;
            user.Password = lcUser.Password;
            user.UserLevel = lcUser.UserLevel;
            user.Dept = lcUser.Dept;
            user.Status = lcUser.Status;

            return View(user);
        }

        public ActionResult Account(string userID)
        {
            ViewBag.userID = userID;

            return View();
        }

        public JsonResult AccountDetails()
        {
            List<LC_User> lcUserList = new List<LC_User>();

            lcUserList = (from lcUser in db.LC_User
                          select lcUser).ToList();

            return Json(new { lcUserList = lcUserList }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AccountEdit()
        {
            string userID = Request.Params["userID"];
            string accountID = Request.Params["accountID"];

            ViewBag.userID = userID;

            List<LC_User> lcUserList = db.sp_LC_FindUser(accountID).ToList();
            User user = new User();

            if (lcUserList.Any())
            {
                LC_User lcUser = lcUserList.First();
                user.UserID = lcUser.UserID;
                user.UserName = lcUser.UserName;
                user.Password = lcUser.Password;
                user.UserLevel = lcUser.UserLevel;
                user.Dept = lcUser.Dept;
                user.Status = lcUser.Status;
            }

            //List<SelectListItem> items = new List<SelectListItem>();
            //items.Add(new SelectListItem { Text = "Administer", Value = "AD" });
            //items.Add(new SelectListItem { Text = "Worker", Value = "GU" });
            //items.Add(new SelectListItem { Text = "Visitor", Value = "V " });
            //var levelList = new SelectList(items, "Value", "Text", user.UserLevel);
            //ViewBag.levelLlist = levelList;

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccountEdit(User user, string loginID)
        {
            if (user.UserLevel == null)
            {
                ModelState.AddModelError("", "UserLevel is required!");
            }

            if (user.Status == null)
            {
                ModelState.AddModelError("", "Status is required!");
            }

            if (ModelState.IsValid)
            {
                List<LC_User> lcUserList = db.sp_LC_FindUser(user.UserID).ToList();
                LC_User lcUser = new LC_User();

                if (lcUserList.Any())
                {
                    lcUser = lcUserList.First();
                    lcUser.UserName = user.UserName;
                    lcUser.Password = user.Password;
                    lcUser.UserLevel = user.UserLevel;
                    lcUser.Dept = user.Dept;
                    lcUser.Status = user.Status;
                }
                else
                {
                    lcUser.UserID = db.sp_LC_GenUserID().ToList().First();
                    lcUser.UserName = user.UserName;
                    lcUser.Password = user.Password;
                    lcUser.UserLevel = user.UserLevel;
                    lcUser.Dept = user.Dept;
                    lcUser.Status = user.Status;
                    db.LC_User.Add(lcUser);
                }
                db.SaveChanges();

                return RedirectToAction("Console", "Admin", new { userID = loginID });
            }

            return View(user);
        }

        public void AccountDelete(string accountID)
        {
            LC_User lcUser = db.sp_LC_FindUser(accountID).First();
            db.LC_User.Remove(lcUser);
            db.SaveChanges();
        }

        public ActionResult Message()
        {
            return View();
        }

        public JsonResult MessageDetails()
        {
            List<LC_Msg> lcMsgList = new List<LC_Msg>();

            lcMsgList = (from lcMsg in db.LC_Msg
                         select lcMsg).ToList();

            List<Message> msgList = new List<Message>();
            Message msg;
            foreach (var lcMsg in lcMsgList)
            {
                msg = new Message();
                msg.MsgID = lcMsg.MsgID;
                msg.MsgContent = lcMsg.MsgContent;
                msg.UserID = lcMsg.UserID;
                var postTime = lcMsg.PostTime ?? DateTime.Now;
                msg.PostTime = postTime.ToString("yyyy/MM/dd");
                msg.FName = lcMsg.FName;
                msg.LName = lcMsg.LName;
                msg.Status = lcMsg.Status;
                msgList.Add(msg);
            }

            return Json(new { msgList = msgList }, JsonRequestBehavior.AllowGet);
        }

    }
}
