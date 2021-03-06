using EmployeeManagement.DAO;
using EmployeeManagement.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI.WebControls;

namespace EmployeeManagement
{
    public partial class EmployeeList : System.Web.UI.Page
    {
        /// <summary>
        /// 従業員一覧
        /// </summary>
        private List<EmployeeEntity> employees = new List<EmployeeEntity>();
        /// <summary>
        /// インスタンス
        /// </summary>
        private EmployeeDAO employeeDAO = new EmployeeDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            FillData();
        }
        /// <summary>
        /// ページをロードする時、データを表示する
        /// </summary>
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
                tc.BorderColor = Color.Black;
                tc.BorderStyle = BorderStyle.Solid;
                tc.BorderWidth = 1;
                tr.Cells.Add(tc);
                // 氏名のセル
                tc = new TableCell
                {
                    Text = employee.Name
                };
                tc.BorderColor = Color.Black;
                tc.BorderStyle = BorderStyle.Solid;
                tc.BorderWidth = 1;
                tr.Cells.Add(tc);
                // 氏名（フリガナ）のセル
                tc = new TableCell
                {
                    Text = employee.NameKana
                };
                tc.BorderColor = Color.Black;
                tc.BorderStyle = BorderStyle.Solid;
                tc.BorderWidth = 1;
                tr.Cells.Add(tc);
                // 性別のセル
                tc = new TableCell
                {
                    Text = employee.Gender
                };
                tc.BorderColor = Color.Black;
                tc.BorderStyle = BorderStyle.Solid;
                tc.BorderWidth = 1;
                tr.Cells.Add(tc);
                // 生年月日のセル
                tc = new TableCell
                {
                    Text = employee.BirthDate
                };
                tc.BorderColor = Color.Black;
                tc.BorderStyle = BorderStyle.Solid;
                tc.BorderWidth = 1;
                tr.Cells.Add(tc);
                // 保有資格のセル
                tc = new TableCell
                {
                    Text = string.Join("<br/>", employee.License.ToArray())
                };
                tc.BorderColor = Color.Black;
                tc.BorderStyle = BorderStyle.Solid;
                tc.BorderWidth = 1;
                tr.Cells.Add(tc);
                // 所属部署のセル
                tc = new TableCell
                {
                    Text = employee.Section
                };
                tc.BorderColor = Color.Black;
                tc.BorderStyle = BorderStyle.Solid;
                tc.BorderWidth = 1;
                tr.Cells.Add(tc);
                // 入社日のセル
                tc = new TableCell
                {
                    Text = employee.EmpDate
                };
                tc.BorderColor = Color.Black;
                tc.BorderStyle = BorderStyle.Solid;
                tc.BorderWidth = 1;
                tr.Cells.Add(tc);
                // チェックボックスのセル
                tc = new TableCell();
                CheckBox checkBox = new CheckBox();
                checkBox.Checked = false;
                tc.Controls.Add(checkBox);
                tc.BorderColor = Color.Black;
                tc.BorderStyle = BorderStyle.Solid;
                tc.BorderWidth = 1;
                tr.Cells.Add(tc);
                // 行を追加する
                TableEmployeeList.Rows.Add(tr);
            }
        }
        /// <summary>
        /// 変更ボタンを押下する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                RedirectToErrorPage("従業員情報の変更", "従業員を一人選択してください。", "EmployeeList");
            }
            else
            {
                // Redirect to EmployeeUpdate page
                Session["EmpCode"] = empCode;
                Response.Redirect("EmployeeUpdate.aspx");
            }
        }
        /// <summary>
        /// 削除ボタンを押下する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            bool isChecked = false;
            for (int i = 1; i < TableEmployeeList.Rows.Count; i++)
            {
                CheckBox checkBox = TableEmployeeList.Rows[i].Cells[8].Controls[0] as CheckBox;
                if (checkBox.Checked)
                {
                    isChecked = true;
                    string empCode = TableEmployeeList.Rows[i].Cells[0].Text;
                    EmployeeEntity employee = employees.Find(emp => emp.EmpCode.Equals(empCode));
                    employeeDAO.Delete(employee);
                }
            }
            if (isChecked)
            {
                // Redirect to done page
                Session["finish"] = "従業員削除";
                Session["page"] = "EmployeeList";
                Response.Redirect("Finish.aspx");
            }
            else
            {
                RedirectToErrorPage("従業員削除", "従業員を一人選択してください。", "EmployeeList");
            }
        }
        /// <summary>
        /// Redirect to error page
        /// </summary>
        /// <param name="err"></param>
        /// <param name="msg"></param>
        /// <param name="page"></param>
        private void RedirectToErrorPage(string err, string msg, string page)
        {
            Session["error"] = err;
            Session["msg"] = msg;
            Session["page"] = page;
            Response.Redirect("Error.aspx");
        }
    }
}