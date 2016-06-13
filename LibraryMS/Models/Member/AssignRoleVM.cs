using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMS.Models.Membership
{
    public class AssignRoleVM
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }

        public List<AssignRoleVM> RoleLists { get; set; }
        public List<AssignRoleVM> UserLists { get; set; }

    }

    public class AllRolesUsers
    {
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public List<AllRolesUsers> AllRolesUsersDetails { get; set; }
    }
}