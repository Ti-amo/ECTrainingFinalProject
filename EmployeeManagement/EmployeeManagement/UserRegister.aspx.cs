using EmployeeManagement.DAO;
using EmployeeManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagement
{
    public partial class UserRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private bool IsValidData()
        {
            if (string.IsNullOrWhiteSpace(TextBoxUserId.Text) || string.IsNullOrWhiteSpace(TextBoxPassword.Text))
            { 
                return false;
            }
            return true;
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
        /// <summary>
        /// 新規登録
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                UserEntity newUser = new UserEntity();
                newUser.UserId = TextBoxUserId.Text;
                newUser.Password = TextBoxPassword.Text;
                UserDAO userDAO = new UserDAO();
                userDAO.Insert(newUser);
                Response.Redirect("Finish.aspx");
            }
        }
    }
}