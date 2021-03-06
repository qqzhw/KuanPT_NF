﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using IMCustSys.Model;
using IMCustSys.DAL;
using IMCustSys.BLL.Services;

namespace IMCustSys.BLL
{
    /// <summary>
    /// Business entity used to BLL User_Users
    /// </summary>
    public class UserService:IUserService
    {
        private readonly IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserByUserId(int userId)
        {
           return _userRepository.GetById(userId);
        }
        //public DataTable GetAll()
        //{
        //    return dal.GetAll();
        //}
    }
}
