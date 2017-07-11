using IMCustSys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMCustSys.BLL.Services
{
    public interface IUserService
    {
        User GetUserByUserId(int userId);
    }
}
