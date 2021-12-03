using EmployeeManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagement {
    public partial class Site : System.Web.UI.MasterPage {
        public bool login = false;

        protected void Page_Load(object sender, EventArgs e) {
            string pageUrl = HttpContext.Current.Request.Url.AbsoluteUri;
            if (Session["login"] == null && !pageUrl.Contains("Login") && !pageUrl.Contains("Logout") && !pageUrl.Contains("Error")) {
                Response.Redirect(@"Login.aspx");
            } else if (Session["login"] != null) {
                UserEntity user = (UserEntity)Session["user"];
                login = true;
                int hour = int.Parse(DateTime.Now.ToString("HH", System.Globalization.DateTimeFormatInfo.InvariantInfo));
                string msg;
                if (hour > 0 && hour <= 10) {
                    msg = "おはようございます、";
                } else if (hour > 10 && hour <= 17) {
                    msg = "こんにちは、";
                } else msg = "こんばんは、";
                LabelHello.Text = msg + user.UserId + "さん";
            }
        }

        protected void ButtonLogout_Click(object sender, EventArgs e) {
            Session.Remove("login");
            Session.Remove("user");
            Response.Redirect(@"Logout.aspx");
        }
    }
}