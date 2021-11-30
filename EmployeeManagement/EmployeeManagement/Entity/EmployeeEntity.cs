using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Entity {
    public class EmployeeEntity {
        /// <summary>
        /// 従業員コード
        /// </summary>
        public string EmpCode { get; set; }

        /// <summary>
        /// 氏名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 氏名（フリガナ）
        /// </summary>
        public string NameKana { get; set; }

        /// <summary>
        /// 性別名
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// 生年月日
        /// </summary>
        public string BirthDate { get; set; }

        /// <summary>
        /// 資格
        /// </summary>
        public List<string> License { get; set; }

        /// <summary>
        /// 所属名
        /// </summary>
        public string Section { get; set; }

        /// <summary>
        /// 入社日
        /// </summary>
        public string EmpDate { get; set; }
    }
}