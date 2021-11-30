using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Entity {
    public class UserEntity {
        /// <summary>
        /// ユーザID
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// パスワード
        /// </summary>
        public string Password { get; set; }
    }
}