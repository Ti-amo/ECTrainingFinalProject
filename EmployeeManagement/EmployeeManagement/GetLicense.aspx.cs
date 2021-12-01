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
                Dictionary<string, string> dLicense = new Dictionary<string, string>();

                ListDAO listDao = new ListDAO();
                List<LicenseItem> licenseList = listDao.GetLicenseList();

                foreach (LicenseItem licenseItem in licenseList) {
                    dLicense.Add(licenseItem.LicenseCode, licenseItem.LicenseName);
                }

                DropDownListLicense.DataTextField = "Value";
                DropDownListLicense.DataValueField = "Key";
                DropDownListLicense.DataSource = dLicense;
                DropDownListLicense.DataBind();
            }
        }

        protected void ButtonGet_Click(object sender, EventArgs e) {
            if (TextBoxEmpCode.Text != "" && TextBoxDate.Text != "") {
                EmployeeDAO employeeDao = new EmployeeDAO();
                if (employeeDao.Find(TextBoxEmpCode.Text) != null) {
                    LicenseEntity licenseEntity = new LicenseEntity {
                        EmpCode = TextBoxEmpCode.Text,
                        LicenseCode = DropDownListLicense.SelectedValue,
                        GetLicenseDate = TextBoxDate.Text
                    };

                    LicenseDAO licenseDao = new LicenseDAO();
                    licenseDao.Insert(licenseEntity);

                    Session["finish"] = "資格取得";
                    Session["page"] = "GetLicense";

                    Response.Redirect(@"Finish.aspx");
                } else {
                    Session["error"] = "資格取得";
                    Session["msg"] = "従業員コードが存在しません。";
                    Session["page"] = "GetLicense";

                    Response.Redirect(@"Error.aspx");
                }
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e) {
            Response.Redirect(@"Menu.aspx");
        }
    }
}