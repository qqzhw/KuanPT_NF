using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// Business entity used to model User_UsersInfo
    /// </summary>
    [Table("Users")]
    public class User_UsersInfo
    {
        [Key]
        public int UserId { get; set; }
        public int RoleID { get; set; }
        public int DeptId { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string RealName { get; set; }
        public string PhoneNo { get; set; }
        public string Icon { get; set; }
        public string ComId { get; set; }
        public string Email { get; set; }
        public string AliAccount { get; set; }
        public decimal MyMoney { get; set; }
        public int UserStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastDate { get; set; }
        public string LastIP { get; set; }
        public string ComName { get; set; }
        public string WorkArea { get; set; }
        public string Modules { get; set; }

        public int HandleNum { get; set; }

        public int ClassId { get; set; }
        public int UserType { get; set; }

        public int BmId { get; set; }

    }
}
