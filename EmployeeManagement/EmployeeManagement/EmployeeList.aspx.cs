using EmployeeManagement.Entity;
using System;
using System.Collections.Generic;

namespace EmployeeManagement
{
    public partial class EmployeeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<LicenseEntity> licenses = new List<LicenseEntity>();
            licenses.Add(new LicenseEntity("", "FE", ""));
            licenses.Add(new LicenseEntity("", "MCITP", ""));
            List<EmployeeEntity> employees = new List<EmployeeEntity>();
            employees.Add(new EmployeeEntity("20166061", "山田太郎", "やまだたろう", "男", "2000/02/20", licenses, "人事部", "2000/02/20"));
            employees.Add(new EmployeeEntity("20166061", "山田太郎", "やまだたろう", "男", "2000/02/20", licenses, "人事部", "2000/02/20"));
            RepeaterEmployeeList.DataSource = employees;
            RepeaterEmployeeList.DataBind();
            
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {

        }
    }
}