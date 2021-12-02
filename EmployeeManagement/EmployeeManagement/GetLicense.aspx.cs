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
    public partial class GetLicense : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                // DropDownListEmp
                Dictionary<string, string> dEmp = new Dictionary<string, string>();

                EmployeeDAO employeeDao = new EmployeeDAO();
                List<EmployeeEntity> employeeList = employeeDao.FindAll();

                foreach (EmployeeEntity employeeEntity in employeeList) {
                    string emp = employeeEntity.EmpCode + " - " + employeeEntity.Name + " (" + employeeEntity.NameKana + ")";
                    dEmp.Add(employeeEntity.EmpCode, emp);
                }

                DropDownListEmp.DataValueField = "Key";
                DropDownListEmp.DataTextField = "Value";
                DropDownListEmp.DataSource = dEmp;
                DropDownListEmp.DataBind();

                // DropDownListLicense
                Dictionary<string, string> dLicense = new Dictionary<string, string>();

                ListDAO listDao = new ListDAO();
                List<LicenseItem> licenseList = listDao.GetLicenseList();

                foreach (LicenseItem licenseItem in licenseList) {
                    dLicense.Add(licenseItem.LicenseCode, licenseItem.LicenseName);
                }

                DropDownListLicense.DataValueField = "Key";
                DropDownListLicense.DataTextField = "Value";
                DropDownListLicense.DataSource = dLicense;
                DropDownListLicense.DataBind();
            }
        }

        protected void ButtonGet_Click(object sender, EventArgs e) {
            if (!string.IsNullOrWhiteSpace(TextBoxDate.Text)) {
                EmployeeDAO employeeDao = new EmployeeDAO();
                if (employeeDao.Find(DropDownListEmp.SelectedValue) == null) {
                    Session["error"] = "資格取得";
                    Session["msg"] = "従業員コードが存在しません。";
                    Session["page"] = "GetLicense";

                    Response.Redirect(@"Error.aspx");
                } else {
                    LicenseDAO licenseDao = new LicenseDAO();

                    if (licenseDao.Find(DropDownListEmp.SelectedValue, DropDownListLicense.SelectedValue) == null) {
                        LicenseEntity licenseEntity = new LicenseEntity {
                            EmpCode = DropDownListEmp.SelectedValue,
                            LicenseCode = DropDownListLicense.SelectedValue,
                            GetLicenseDate = TextBoxDate.Text
                        };

                        licenseDao.Insert(licenseEntity);

                        Session["finish"] = "資格取得";
                        Session["page"] = "GetLicense";

                        Response.Redirect(@"Finish.aspx");
                    } else {
                        Session["error"] = "資格取得";
                        Session["msg"] = "資格取得が存在します。";
                        Session["page"] = "GetLicense";

                        Response.Redirect(@"Error.aspx");
                    }
                }
            } else {
                Session["error"] = "資格取得";
                Session["msg"] = "取得日を入力しませんでした。";
                Session["page"] = "GetLicense";

                Response.Redirect(@"Error.aspx");
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e) {
            Response.Redirect(@"Menu.aspx");
        }
    }
}