﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<LicenseEntity> License { get => license; set => license = value;}
        public string Section { get => section; set => section = value; }
        public string EmpDate { get => empDate; set => empDate = value; }   
        public EmployeeEntity() { }
        public EmployeeEntity(string empCode, string name, string nameKana, string gender, List<LicenseEntity> license, string section, string empDate)
        {
            this.EmpCode = empCode;
            this.Name = name;
            this.NameKana = nameKana;
            this.Gender = gender;
            this.License = license;
            this.Section = section;
            this.EmpDate = empDate;
        }
    }
}