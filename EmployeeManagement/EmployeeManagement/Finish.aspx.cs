using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagement {
    public partial class Finish : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["finish"] == null) {
                Response.Redirect(@"Menu.aspx");
            } else {
                LabelFinish.Text = Session["finish"].ToString() + "に完了しました。";
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e) {
            Session.Remove("finish");

            string page = @"" + Session["page"].ToString() + ".aspx";
            Session.Remove("page");
            Response.Redirect(page);
        }

        protected void ButtonMenu_Click(object sender, EventArgs e) {
            Session.Remove("finish");
            Session.Remove("page");

            Response.Redirect(@"Menu.aspx");
        }

    }
}