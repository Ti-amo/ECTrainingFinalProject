using EmployeeManagement.DAO;
using EmployeeManagement.Entity;
using EmployeeManagement.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagement {
    public partial class EmployeeRegister : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
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

                Dictionary<string, string> dSection = new Dictionary<string, string>();
                List<SectionItem> sectionList = listDao.GetSectionList();

                foreach (SectionItem sectionItem in sectionList) {
                    dSection.Add(sectionItem.SectionCode, sectionItem.SectionName);
                }

                DropDownListSection.DataTextField = "Value";
                DropDownListSection.DataValueField = "Key";
                DropDownListSection.DataSource = dSection;
                DropDownListSection.DataBind();
            }
        }

        /// <summary>
        /// バリデート判定
        /// </summary>
        /// <returns></returns>
        private bool IsValidData() {
            if (string.IsNullOrWhiteSpace(TextBoxEmployeeCode.Text) || string.IsNullOrWhiteSpace(TextBoxName.Text) || string.IsNullOrWhiteSpace(TextBoxNameKana.Text) || string.IsNullOrWhiteSpace(TextBoxEmpDate.Text) || string.IsNullOrWhiteSpace(TextBoxDateOfBirth.Text)) {
                return false;
            }
            return true;
        }

        protected void ButtonCancel_Click(object sender, EventArgs e) {
            Response.Redirect("Menu.aspx");
        }

        /// <summary>
        /// 新規登録
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonRegister_Click(object sender, EventArgs e) {
            if (IsValidData()) {
                if (IsValidSpecialChar()) {
                    EmployeeDAO dao = new EmployeeDAO();

                    if (dao.Find(TextBoxEmployeeCode.Text) != null) {
                        Session["error"] = "従業員登録";
                        Session["msg"] = "従業員コードが存在しました。";
                        Session["page"] = "EmployeeRegister";
                        Response.Redirect(@"Error.aspx");
                    } else {
                        if (TextBoxEmployeeCode.Text.Length > 4 || TextBoxName.Text.Length > 32 || TextBoxNameKana.Text.Length > 32) {
                            Session["error"] = "従業員登録";
                            Session["msg"] = "許可されている文字数を超えて入力しまいました。";
                            Session["page"] = "EmployeeRegister";
                            Response.Redirect(@"Error.aspx");
                        } else {
                            EmployeeEntity newEmployee = new EmployeeEntity();
                            newEmployee.EmpCode = TextBoxEmployeeCode.Text;
                            newEmployee.Name = TextBoxName.Text;
                            newEmployee.NameKana = TextBoxNameKana.Text;
                            newEmployee.Gender = DropDownListGender.SelectedValue;
                            newEmployee.BirthDate = TextBoxDateOfBirth.Text;
                            newEmployee.Section = DropDownListSection.SelectedValue;
                            newEmployee.EmpDate = TextBoxEmpDate.Text;
                            dao.Insert(newEmployee);
                            Session["finish"] = "従業員登録";
                            Session["page"] = "EmployeeRegister";
                            Response.Redirect(@"Finish.aspx");
                        }
                    }
                } else {
                    Session["error"] = "従業員登録";
                    Session["msg"] = "入力した文字は特殊文字です。";
                    Session["page"] = "EmployeeRegister";
                    Response.Redirect(@"Error.aspx");
                }
            } else {
                Session["error"] = "従業員登録";
                Session["msg"] = "従業員情報が登録できません。";
                Session["page"] = "EmployeeRegister";
                Response.Redirect(@"Error.aspx");
            }
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