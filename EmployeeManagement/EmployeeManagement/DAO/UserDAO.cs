using EmployeeManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.DAO
{
    public class UserDAO
    {
        public UserDAO() { }
        public UserEntity Find(string userId, string password)
        {
            UserEntity userEntity = new UserEntity();
            return userEntity;
        }
        public int Insert(string userId, string password)
        {
            int result = 0; 
            return result;  
        }
    }
}