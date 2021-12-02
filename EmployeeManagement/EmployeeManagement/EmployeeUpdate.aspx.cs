using EmployeeManagement.DAO;
using EmployeeManagement.Entity;
using EmployeeManagement.Item;
using System;
using System.Collections.Generic;

namespace EmployeeManagement
{
    public partial class EmployeeUpdate : System.Web.UI.Page
    {
        /// <summary>
        /// 変更する従業員情報
        /// </summary>
        private EmployeeEntity employee = new EmployeeEntity();
        /// <summary>
        /// インスタンス
        /// </summary>
        private EmployeeDAO employeeDAO = new EmployeeDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["EmpCode"] != null)
            {
                string empCode = (string)Session["EmpCode"];
                employee = employeeDAO.Find(empCode);
                if (!IsPostBack)
                {
                    FillData();
                }
            }
        }
        /// <summary>
        /// ページをロードする時、データを表示する
        /// </summary>
        private void FillData()
        {
            TextBoxName.Text = employee.Name;
            TextBoxNameKana.Text = employee.NameKana;

            Dictionary<int, string> dGender = new Dictionary<int, string>();
            ListDAO listDao = new ListDAO();
            List<GenderItem> genderList = listDao.GetGenderList();

            foreach (GenderItem genderItem in genderList)
            {
                dGender.Add(genderItem.GenderCode, genderItem.GenderName);
            }

            DropDownListGender.DataTextField = "Value";
            DropDownListGender.DataValueField = "Key";
            DropDownListGender.DataSource = dGender;
            DropDownListGender.DataBind();
            DropDownListGender.SelectedValue = DropDownListGender.Items.FindByText(employee.Gender).Value;

            Dictionary<string, string> dSection = new Dictionary<string, string>();
            List<SectionItem> sectionList = listDao.GetSectionList();

            foreach (SectionItem sectionItem in sectionList)
            {
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
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeList.aspx");
        }
        /// <summary>
        /// 登録ボタンを押下する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                employee.Name = TextBoxName.Text;
                employee.NameKana = TextBoxNameKana.Text;
                employee.Gender = DropDownListGender.SelectedValue;
                employee.Section = DropDownListSection.SelectedValue;
                employeeDAO.Update(employee);
                // Redirect to done page
                Session["finish"] = "従業員情報の変更";
                Session["page"] = "EmployeeList";
                Response.Redirect("Finish.aspx");
                Session.Remove("EmpCode");
            }
            else
            {
                // Redirect to error page
                Session["error"] = "従業員情報の変更";
                Session["msg"] = "フィールドに内容（32文字以下）を入力してください。";
                Session["page"] = "EmployeeUpdate";
                Response.Redirect("Error.aspx");
            }
        }
        /// <summary>
        /// 入力したデータをチェックする
        /// </summary>
        /// <returns></returns>
        private bool IsValidData()
        {
            if(string.IsNullOrWhiteSpace(TextBoxName.Text) || string.IsNullOrWhiteSpace(TextBoxNameKana.Text)
                || TextBoxName.Text.Length > 32 || TextBoxNameKana.Text.Length > 32)
            {
                return false;
            }
            return true;
        }
    }
}