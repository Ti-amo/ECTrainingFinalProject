using EmployeeManagement.DAO;
using EmployeeManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagement {
    public partial class UserRegister : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        private bool IsValidData() {
            if (string.IsNullOrWhiteSpace(TextBoxUserId.Text) || string.IsNullOrWhiteSpace(TextBoxPassword.Text)) {
                return false;
            }
            return true;
        }

        protected void ButtonCancel_Click(object sender, EventArgs e) {
            Response.Redirect("Menu.aspx");
        }

        /// <summary>
        /// 新規登録
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonRegister_Click(object sender, EventArgs e) {
            if (IsValidData()) {
                Regex regexItem = new Regex("^[a-zA-Z0-9_]*$");
                if (regexItem.IsMatch(TextBoxUserId.Text) && regexItem.IsMatch(TextBoxPassword.Text)) {
                    UserDAO userDAO = new UserDAO();
                    if (userDAO.Find(TextBoxUserId.Text) != null) {
                        Session["error"] = "ユーザ登録";
                        Session["msg"] = "ユーザIDが存在しました。";
                        Session["page"] = "UserRegister";
                        Response.Redirect(@"Error.aspx");
                    } else {
                        if (TextBoxUserId.Text.Length > 24 || TextBoxPassword.Text.Length > 32) {
                            Session["error"] = "ユーザ登録";
                            Session["msg"] = "許可されている文字数を超えて入力しまいました。";
                            Session["page"] = "UserRegister";
                            Response.Redirect(@"Error.aspx");
                        } else {
                            UserEntity newUser = new UserEntity {
                                UserId = TextBoxUserId.Text,
                                Password = TextBoxPassword.Text
                            };
                            userDAO.Insert(newUser);
                            Session["finish"] = "ユーザ登録";
                            Session["page"] = "UserRegister";
                            Response.Redirect(@"Finish.aspx");
                        }
                    }
                } else {
                    Session["error"] = "ユーザ登録";
                    Session["msg"] = "入力した文字は特殊文字です。";
                    Session["page"] = "UserRegister";
                    Response.Redirect(@"Error.aspx");
                }
            } else {
                Session["error"] = "ユーザ登録";
                Session["msg"] = "ユーザ情報が登録できません。";
                Session["page"] = "UserRegister";
                Response.Redirect(@"Error.aspx");
            }
        }
    }
}