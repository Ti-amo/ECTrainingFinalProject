using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EmployeeManagement.Entity
{
    public class EmployeeEntity
    {
        string empCode;
        string name;
        string nameKana;
        string gender;
        List<LicenseEntity> license = new List<LicenseEntity>();
        string section;
        string empDate;
        public string EmpCode { get => empCode; set => empCode = value; }
        public string Name { get => name; set => name = value; }
        public string NameKana { get => nameKana; set => nameKana = value; }    
        public string Gender { get => gender; set => gender = value; }
        public string DateOfBirth { get; set; }
        public List<LicenseEntity> License { get => license; set => license = value;}
        public string Section { get => section; set => section = value; }
        public string EmpDate { get => empDate; set => empDate = value; }   
        public EmployeeEntity() { }
        public EmployeeEntity(string empCode, string name, string nameKana, string gender, string dateOfBirth, List<LicenseEntity> license, string section, string empDate)
        {
            this.EmpCode = empCode;
            this.Name = name;
            this.NameKana = nameKana;
            this.Gender = gender;
            this.DateOfBirth = dateOfBirth;
            this.License = license;
            this.Section = section;
            this.EmpDate = empDate;
        }

        public string GetLicenseName()
        {
            StringBuilder builder = new StringBuilder();
            foreach (LicenseEntity license in License)
            {
                builder.Append(license.LicenseName);
                builder.Append(", ");
            }
            return builder.Remove(builder.Length - 2, 2).ToString();
        }
    }
}