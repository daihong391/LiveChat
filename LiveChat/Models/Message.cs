using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using LiveChat.Models;

namespace LiveChat.Models
{
    public class Message
    {
        public string MsgID { get; set; }

        public string MsgContent { get; set; }

        public string UserID { get; set; }

        public string PostTime { get; set; }

        [Required(ErrorMessage = "First Name is Required!")]
        [StringLength(30)]
        public string FName { get; set; }

        [Required(ErrorMessage = "Last Name is Required!")]
        [StringLength(30)]
        public string LName { get; set; }

        public string Status { get; set; }

        public LC_Msg Save()
        {
            LC_Msg msg = new LC_Msg();

            using (LiveChatEntities db = new LiveChatEntities())
            {
                if (MsgID != "" && MsgID != null)
                {
                    msg = db.sp_LC_SearchMsg(MsgID).ToList().First();
                    msg.MsgContent = MsgContent;
                    msg.UserID = UserID;
                    msg.PostTime = DateTime.Now;
                    msg.FName = FName;
                    msg.LName = LName;
                    msg.Status = Status;
                }
                else
                {
                    msg.MsgID = db.sp_LC_GenID().ToList().First();
                    msg.MsgContent = MsgContent;
                    msg.UserID = UserID;
                    msg.PostTime = DateTime.Now;
                    msg.FName = FName;
                    msg.LName = LName;
                    msg.Status = "A";
                    db.LC_Msg.Add(msg);
                }
                db.SaveChanges();

                return msg;
            }
        }

        public LC_Msg UserSave()
        {
            LC_Msg msg = new LC_Msg();

            using (LiveChatEntities db = new LiveChatEntities())
            {
                msg = db.sp_LC_SearchMsg(MsgID).ToList().First();
                msg.MsgContent += MsgContent;
                if (MsgContent.Equals("<li>"+msg.FName+": Agent has left.</li>"))
                {
                    msg.Status = "F";
                }

                db.SaveChanges();

                return msg;
            }
        }
    }
}