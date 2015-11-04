using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LiveChat.Models
{
    public class User
    {

        public string UserID { get; set; }

        [Required(ErrorMessage="UserName is required!")]
        public string UserName { get; set; }

        [Required(ErrorMessage="Password is required!")]
        public string Password { get; set; }

        public string UserLevel { get; set; }

        public string Dept { get; set; }

        public string Status { get; set; }

        public LC_User UserValid(){

            List<LC_User> userList = new List<LC_User>();
            LC_User user = new LC_User();

            using (LiveChatEntities db = new LiveChatEntities())
            {
                userList = db.sp_LC_UserValid_CallCentre(UserName, Password).ToList();

                if (userList.Any())
                {
                    user = userList.First();
                }
                else
                {
                    user = null;
                }
            }

            return user;
        }
    }
}