using EmployeeManagement.DAO;
using EmployeeManagement.Entity;
using EmployeeManagement.Item;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace EmployeeManagement {
    public partial class EmployeeUpdate : System.Web.UI.Page {
        /// <summary>
        /// 変更する従業員情報
        /// </summary>
        private EmployeeEntity employee = new EmployeeEntity();
        /// <summary>
        /// インスタンス
        /// </summary>
        private EmployeeDAO employeeDAO = new EmployeeDAO();
        /// <summary>
        /// エラー一覧
        /// </summary>
        private enum Err {
            None,
            ErrName,
            ErrDateOfBirth,
            ErrEmpDate
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["EmpCode"] != null) {
                string empCode = (string)Session["EmpCode"];
                employee = employeeDAO.Find(empCode);
                if (!IsPostBack) {
                    FillData();
                }
            } else {
                RedirectToErrorPage("従業員情報の変更", "従業員を一人選択してください。", "EmployeeList");
            }
        }

        /// <summary>
        /// ページをロードする時、データを表示する
        /// </summary>
        private void FillData() {
            TextBoxName.Text = employee.Name;
            TextBoxNameKana.Text = employee.NameKana;
            TextBoxDateOfBirth.Text = Convert.ToDateTime(employee.BirthDate).ToString("yyyy-MM-dd");
            TextBoxEmpDate.Text = Convert.ToDateTime(employee.EmpDate).ToString("yyyy-MM-dd");

            Dictionary<int, string> dGender = new Dictionary<int, string>();
            ListDAO listDao = new ListDAO();
            List<GenderItem> genderList = listDao.GetGenderList();

            foreach (GenderItem genderItem in genderList) {
                dGender.Add(genderItem.GenderCode, genderItem.GenderName);
            }

            DropDownListGender.DataTextField = "Value";
            DropDownListGender.DataValueField = "Key";
            DropDownListGender.DataSource = dGender;
            DropDownListGender.DataBind();
            DropDownListGender.SelectedValue = DropDownListGender.Items.FindByText(employee.Gender).Value;

            Dictionary<string, string> dSection = new Dictionary<string, string>();
            List<SectionItem> sectionList = listDao.GetSectionList();

            foreach (SectionItem sectionItem in sectionList) {
                dSection.Add(sectionItem.SectionCode, sectionItem.SectionName);
            }

            DropDownListSection.DataTextField = "Value";
            DropDownListSection.DataValueField = "Key";
            DropDownListSection.DataSource = dSection;
            DropDownListSection.DataBind();
            DropDownListSection.SelectedValue = DropDownListSection.Items.FindByText(employee.Section).Value;
        }

        /// <summary>
        /// キャンセルボタンを押下する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonCancel_Click(object sender, EventArgs e) {
            Session.Remove("EmpCode");
            Response.Redirect("EmployeeList.aspx");
        }

        /// <summary>
        /// 登録ボタンを押下する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonUpdate_Click(object sender, EventArgs e) {
            if (ValidateData() != Err.None) {
                switch (ValidateData()) {
                    case Err.ErrName:
                        RedirectToErrorPage("従業員情報の変更", "氏名（32文字以下）を入力してください。", "EmployeeUpdate");
                        break;
                    case Err.ErrDateOfBirth:
                        RedirectToErrorPage("従業員情報の変更", "生年月日を入力しませんでした。", "EmployeeUpdate");
                        break;
                    case Err.ErrEmpDate:
                        RedirectToErrorPage("従業員情報の変更", "入社日を入力しませんでした。", "EmployeeUpdate");
                        break;
                }
            } else if (!IsValidSpecialChar()) {
                RedirectToErrorPage("従業員情報の変更", "入力した文字は特殊文字です。", "EmployeeUpdate");
            } else {
                employee.Name = TextBoxName.Text;
                employee.NameKana = TextBoxNameKana.Text;
                employee.Gender = DropDownListGender.SelectedValue;
                employee.BirthDate = TextBoxDateOfBirth.Text;
                employee.Section = DropDownListSection.SelectedValue;
                employee.EmpDate = TextBoxEmpDate.Text;
                employeeDAO.Update(employee);

                Session.Remove("EmpCode");
                // Redirect to done page
                Session["finish"] = "従業員情報の変更";
                Session["page"] = "EmployeeList";
                Response.Redirect("Finish.aspx");
            }
        }

        /// <summary>
        /// Redirect to error page
        /// </summary>
        /// <param name="err"></param>
        /// <param name="msg"></param>
        /// <param name="page"></param>
        private void RedirectToErrorPage(string err, string msg, string page) {
            Session["error"] = err;
            Session["msg"] = msg;
            Session["page"] = page;
            Response.Redirect(@"Error.aspx");
        }

        /// <summary>
        /// 入力したデータをチェックする
        /// </summary>
        /// <returns></returns>
        private Err ValidateData() {
            if (string.IsNullOrWhiteSpace(TextBoxName.Text) || string.IsNullOrWhiteSpace(TextBoxNameKana.Text)
                || TextBoxName.Text.Length > 32 || TextBoxNameKana.Text.Length > 32) {
                return Err.ErrName;
            }
            if (string.IsNullOrWhiteSpace(TextBoxDateOfBirth.Text)) {
                return Err.ErrDateOfBirth;
            }
            if (string.IsNullOrWhiteSpace(TextBoxEmpDate.Text)) {
                return Err.ErrEmpDate;
            }
            return Err.None;
        }

        private bool IsValidSpecialChar() {
            string special = @"\|!#$%&/()=?»«@£§€{}*.-;'<>_,""";
            foreach (char item in special) {
                if (TextBoxName.Text.Contains(item) || TextBoxNameKana.Text.Contains(item)) {
                    return false;
                }
            }
            return true;
        }
    }
}