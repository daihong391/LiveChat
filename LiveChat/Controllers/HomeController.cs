using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LiveChat.Models;

namespace LiveChat.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CreateMsg()
        {
            string fName = Request.Params["fName"];
            string lName = Request.Params["lName"];

            Message message = new Message();
            LC_Msg msg = new LC_Msg();

            using (LiveChatEntities db = new LiveChatEntities())
            {
                if (fName != "" && lName != "")
                {
                    message.FName = fName;
                    message.LName = lName;
                    msg = message.Save();
                }
                else
                {
                    msg = null;
                }
            }

            return Json(new { msg = msg }, JsonRequestBehavior.DenyGet);
        }

        public JsonResult AppMsg()
        {
            string msgID = Request.Params["msgID"];
            string fName = Request.Params["fName"];
            string msgContent = "<li>" + fName + ": " + Request.Params["msgContent"] + "</li>";

            LC_Msg msg = new LC_Msg();
            Message message = new Message();
            message.MsgID = msgID;
            message.MsgContent = msgContent;

            using (LiveChatEntities db = new LiveChatEntities())
            {
                msg = message.UserSave();
            }

            return Json(new { msg = msg }, JsonRequestBehavior.DenyGet);
        }

        public JsonResult MsgUp(string msgID)
        {
            List<LC_Msg> msgList = new List<LC_Msg>();
            LC_Msg msg = new LC_Msg();
            string msgContent = "";

            using (LiveChatEntities db = new LiveChatEntities())
            {
                msgList = db.sp_LC_SearchMsg(msgID).ToList();

                if (msgList.Any())
                {
                    msg = msgList.First();
                    msgContent = msg.MsgContent;
                }
                else
                {
                    msgContent = "";
                }
            }


            return Json(new { msgContent = msgContent }, JsonRequestBehavior.DenyGet);
        }

    }
}
