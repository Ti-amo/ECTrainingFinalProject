using EmployeeManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagement
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public bool login = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != null)
            {
                UserEntity user = (UserEntity)Session["user"];
                login = true;
                int date = int.Parse(DateTime.Now.ToString("HH", System.Globalization.DateTimeFormatInfo.InvariantInfo));
                string msg;
                if (date > 0 && date <= 10)
                {
                    msg = "おはようございます、";
                } else if (date > 10 && date <= 17)
                {
                    msg = "こんにちは、";
                } else msg = "こんばんは、";
                LabelHello.Text = msg + user.UserId;
            }
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("login");
            Session.Remove("user");
            Response.Redirect(@"Logout.aspx");
        }
    }
}