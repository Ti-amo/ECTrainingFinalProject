using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Entity
{
    public class LicenseEntity
    {
        string empCode;
        string licenseName;
        string getLicenseDate;
        public string EmpCode { get => empCode; set => empCode = value; }
        public string LicenseName { get => licenseName; set => licenseName = value; }
        public string GetLicenseDate { get => getLicenseDate; set => getLicenseDate = value; }
        public LicenseEntity() { }
        public LicenseEntity(string empCode, string licenseName, string getLicenseDate)
        {
            this.EmpCode = empCode;
            this.LicenseName = licenseName;
            this.GetLicenseDate = getLicenseDate;   
        }
    }
}