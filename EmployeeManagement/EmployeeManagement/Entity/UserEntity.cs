using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Entity
{
    public class UserEntity
    {
        string userId;
        string password;
        public string UserId{ get => userId; set => userId = value; }
        public string Password { get => password; set => password = value; }
        public UserEntity() { }
        public UserEntity( string userId, string password)
        {
            this.UserId = userId;
            this.Password = password;
        }
    }
}