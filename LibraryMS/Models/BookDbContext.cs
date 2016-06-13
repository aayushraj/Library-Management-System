using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LibraryMS.Models
{
    public class BookDbContext:DbContext

    {
        public BookDbContext(): base("DefaultConnection")
        {

        }
        public virtual DbSet<BookInfo> Book {get;set;}

        public System.Data.Entity.DbSet<LibraryMS.Models.Membership.Login> Logins { get; set; }

        public System.Data.Entity.DbSet<LibraryMS.Models.Membership.Register> Registers { get; set; }

    }
}