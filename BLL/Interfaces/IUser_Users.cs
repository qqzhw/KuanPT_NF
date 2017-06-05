using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Interfaces
{
    public interface IUser_Users
    {
        User_UsersInfo GetUserByUserId(int userId);
    }
}
