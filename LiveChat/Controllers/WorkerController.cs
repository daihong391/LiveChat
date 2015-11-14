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

        public JsonResult AppMsg()
        {
            string msgID = Request.Params["msgID"];
            string fName = Request.Params["fName"];
            string msgContent = "<li>" + fName + ": " + Request.Params["msgContent"] + "</li>";

            LC_Msg lcMsg = db.sp_LC_SearchMsg(msgID).First();
            if ((Request.Params["msgContent"].Trim()).Equals("Dialog has been finished."))
            {
                lcMsg.Status = "F";
            }
            lcMsg.UserID = Request.Params["userID"];
            lcMsg.MsgContent += msgContent;
            db.SaveChanges();

            Message msg = new Message();
            msg.MsgID = lcMsg.MsgID;
            msg.MsgContent = lcMsg.MsgContent;
            msg.UserID = lcMsg.UserID;
            msg.PostTime = lcMsg.PostTime.ToString();
            msg.FName = lcMsg.FName;
            msg.LName = lcMsg.LName;
            msg.Status = lcMsg.Status;

            return Json(new { msg = msg }, JsonRequestBehavior.DenyGet);
        }

        public JsonResult MsgUp(string msgID)
        {
            LC_Msg lcMsg = db.sp_LC_SearchMsg(msgID).First();
            string msgContent = "";

            msgContent = lcMsg.MsgContent;

            return Json(new { msgContent = msgContent }, JsonRequestBehavior.DenyGet);
        }

        public JsonResult MsgListShow()
        {
            List<LC_Msg> msgList = db.sp_LC_SearchActiveMsg().ToList();

            List<String> msgArray = new List<string>();

            foreach (var msg in msgList)
            {
                msgArray.Add(msg.MsgID);
            }

            return Json(new { msgArray = msgArray });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
