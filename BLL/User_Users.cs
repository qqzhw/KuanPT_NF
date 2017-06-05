using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    /// <summary>
    /// Business entity used to BLL User_Users
    /// </summary>
    public class User_Users:IUser_Users
    {
        private readonly IRepository<User_UsersInfo> _userRepository;
        public User_Users(IRepository<User_UsersInfo> userRepository)
        {
            _userRepository = userRepository;
        }

        public User_UsersInfo GetUserByUserId(int userId)
        {
           return _userRepository.GetById(userId);
        }
        //public DataTable GetAll()
        //{
        //    return dal.GetAll();
        //}
    }
}
