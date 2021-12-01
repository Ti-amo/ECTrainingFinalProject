using EmployeeManagement.DAO;
using EmployeeManagement.Entity;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace EmployeeManagement
{
    public partial class EmployeeList : System.Web.UI.Page
    {
        private List<EmployeeEntity> employees = new List<EmployeeEntity>();
        private EmployeeDAO employeeDAO = new EmployeeDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            employees = employeeDAO.FindAll();
            foreach (EmployeeEntity employee in employees)
            {
                TableRow tr = new TableRow();
                // コードのセル
                TableCell tc = new TableCell
                {
                    Text = employee.EmpCode
                };
                tr.Cells.Add(tc);
                // 氏名のセル
                tc = new TableCell
                {
                    Text = employee.Name
                };
                tr.Cells.Add(tc);
                // 氏名（フリガナ）のセル
                tc = new TableCell
                {
                    Text = employee.NameKana
                };
                tr.Cells.Add(tc);
                // 性別のセル
                tc = new TableCell
                {
                    Text = employee.Gender
                };
                tr.Cells.Add(tc);
                // 生年月日のセル
                tc = new TableCell
                {
                    Text = employee.BirthDate
                };
                tr.Cells.Add(tc);
                // 保有資格のセル
                tc = new TableCell
                {
                    Text = string.Join(",", employee.License.ToArray())
                };
                tr.Cells.Add(tc);
                // 所属部署のセル
                tc = new TableCell
                {
                    Text = employee.Section
                };
                tr.Cells.Add(tc);
                // 入社日のセル
                tc = new TableCell
                {
                    Text = employee.EmpDate
                };
                tr.Cells.Add(tc);
                // チェックボックスのセル
                tc = new TableCell();
                CheckBox checkBox = new CheckBox();
                tc.Controls.Add(checkBox);
                tr.Cells.Add(tc);
                // 行を追加する
                TableEmployeeList.Rows.Add(tr);
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            string empCode = "";
            int check = 0;
            for (int i = 1; i < TableEmployeeList.Rows.Count; i++)
            {
                CheckBox checkBox = TableEmployeeList.Rows[i].Cells[8].Controls[0] as CheckBox;
                if (checkBox.Checked)
                {
                    empCode = TableEmployeeList.Rows[i].Cells[0].Text;
                    check += 1;
                }
            }
            if (check != 1)
            {
                // Redirect to error page
            }
            else
            {
                Response.Redirect("EmployeeUpdate.aspx?EmpCode=" + empCode);
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < TableEmployeeList.Rows.Count; i++)
            {
                CheckBox checkBox = TableEmployeeList.Rows[i].Cells[8].Controls[0] as CheckBox;
                if (checkBox.Checked)
                {
                    string empCode = TableEmployeeList.Rows[i].Cells[0].Text;
                    EmployeeEntity employee = employees.Find(emp => emp.EmpCode.Equals(empCode));
                    employeeDAO.Delete(employee);
                }
            }
            // Redirect to done page
            
        }
    }
}