using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using LiveChat.Models;

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

    }
}