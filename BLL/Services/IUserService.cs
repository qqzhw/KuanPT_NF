using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public interface IUserService
    {
        User_UsersInfo GetUserByUserId(int userId);
    }
}
