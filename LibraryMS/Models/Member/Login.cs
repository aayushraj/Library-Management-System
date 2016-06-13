using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryMS.Models.Membership
{
    public class Login
    {
        public int LoginId { get; set; }
        public string UserName { get; set; }
        
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }
}