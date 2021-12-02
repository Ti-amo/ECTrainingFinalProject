using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagement {
    public partial class Error : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["error"] == null) {
                Response.Redirect(@"Menu.aspx");
            } else {
                LabelError.Text = Session["error"].ToString() + "に失敗しました。";
                LabelMsg.Text = Session["msg"].ToString();
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e) {
            Session.Remove("error");
            Session.Remove("msg");

            string page = @"" + Session["page"].ToString() + ".aspx";
            Session.Remove("page");
            Response.Redirect(page);
        }
    }
}