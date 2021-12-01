using EmployeeManagement.DAO;
using EmployeeManagement.Entity;
using EmployeeManagement.Item;
using System;
using System.Collections.Generic;

namespace EmployeeManagement
{
    public partial class EmployeeUpdate : System.Web.UI.Page
    {
        private EmployeeEntity employee = new EmployeeEntity();
        private EmployeeDAO employeeDAO = new EmployeeDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            string empCode = Request.QueryString["EmpCode"];
            employee = employeeDAO.Find(empCode);
            if (!IsPostBack)
            {
                FillData();
            }
        }
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
        }
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeList.aspx");
        }
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
            }
            else
            {
                // Redirect to error page
                Session["error"] = "従業員情報の変更";
                Session["msg"] = "フィールドに内容を入力してください。";
                Session["page"] = "EmployeeUpdate";
                Response.Redirect("Error.aspx");
            }
        }

        private bool IsValidData()
        {
            if(string.IsNullOrWhiteSpace(TextBoxName.Text) || string.IsNullOrWhiteSpace(TextBoxNameKana.Text))
            {
                return false;
            }
            return true;
        }
    }
}