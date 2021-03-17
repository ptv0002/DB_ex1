using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DB_ex1.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Please insert username")]
        public string Username { set; get; }
        [Required(ErrorMessage = "Please insert password")]
        public string Password { set; get; }
        public bool RememberMe { set; get; }

    }
}