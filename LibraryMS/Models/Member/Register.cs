using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryMS.Models.Membership
{
    public class Register
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string Fullname
        {
            get
            {
                return string.Concat(FirstName + " " + LastName);



            }
        }
    }
}