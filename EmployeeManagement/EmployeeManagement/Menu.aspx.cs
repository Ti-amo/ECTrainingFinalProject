using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagement {
    public partial class Menu : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void ButtonEmployeeList_Click(object sender, EventArgs e) {
            Response.Redirect(@"EmployeeList.aspx");
        }

        protected void ButtonRegisterEmployee_Click(object sender, EventArgs e) {
            Response.Redirect(@"EmployeeRegister.aspx");
        }

        protected void ButtonRegisterUser_Click(object sender, EventArgs e) {
            Response.Redirect(@"UserRegister.aspx");
        }

        protected void ButtonGetLicense_Click(object sender, EventArgs e) {
            Response.Redirect(@"GetLicense.aspx");
        }
    }
}