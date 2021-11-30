using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Entity {
    public class LicenseEntity {
        /// <summary>
        /// 従業員コード
        /// </summary>
        public string EmpCode { get; set; }

        /// <summary>
        /// 資格コード
        /// </summary>
        public string LicenseCode { get; set; }

        /// <summary>
        /// 取得日
        /// </summary>
        public string GetLicenseDate { get; set; }
    }
}