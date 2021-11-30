using EmployeeManagement.DAO;
using EmployeeManagement.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagement {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            
        }

        protected void ButtonLogin_Click(object sender, EventArgs e) {
            if (TextBoxUserID.Text != "" && TextBoxPassword.Text != "") {
                try {
                    UserDAO userDao = new UserDAO();

                    UserEntity userEntity = userDao.Find(TextBoxUserID.Text);
                    if (userEntity == null) {
                        Session["error"] = "ログイン";
                        Session["msg"] = "ユーザIDが存在しません。";
                        Session["page"] = "Login";

                        Response.Redirect(@"Error.aspx");
                    } else if (!userEntity.Password.Equals(TextBoxPassword.Text)) {
                        Session["error"] = "ログイン";
                        Session["msg"] = "パスワードが正しくありません。";
                        Session["page"] = "Login";

                        Response.Redirect(@"Error.aspx");
                    } else {
                        Session["user"] = userEntity;
                        Session["login"] = true;

                        Response.Redirect(@"Menu.aspx");
                    }
                } catch (SqlException) {
                    Session["error"] = "ログイン";
                    Session["msg"] = "データベースに接続できません。";
                    Session["page"] = "Login";

                    Response.Redirect(@"Error.aspx");
                }
            }
        }
    }
}