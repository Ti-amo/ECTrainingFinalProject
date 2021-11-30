﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagement {
    public partial class Error : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            LabelError.Text = Session["error"].ToString() + "失敗しました。";
            LabelMsg.Text = Session["msg"].ToString();
        }

        protected void ButtonBack_Click(object sender, EventArgs e) {
            Response.Redirect(@"" + Session["page"].ToString() + ".aspx");
        }
    }
}