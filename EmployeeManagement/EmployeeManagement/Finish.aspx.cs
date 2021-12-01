using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagement {
    public partial class Finish : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelFinish.Text = Session["finish"].ToString() + "に完了しました。";
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"" + Session["page"].ToString() + ".aspx");
        }
    }
}