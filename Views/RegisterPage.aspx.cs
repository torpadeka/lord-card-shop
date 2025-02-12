using LOrd_Card_Shop.Controllers;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrd_Card_Shop.Views
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null || Request.Cookies["user_cookie"] != null)
            {
                // redirect to home page
                Response.Redirect("~/Views/HomePage.aspx");
                return;
            }
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            String userName = UsernameTextBox.Text;
            String userEmail = EmailTextBox.Text;
            String userPassword = PasswordTextBox.Text;
            String userGender = GenderRadioButtonList.SelectedValue;
            String confirmationPassword = ConfirmationPasswordTextBox.Text;
            DateTime userDob = DOBCalendar.SelectedDate;
            String userRole = RoleDropDownList.SelectedValue;

            Response<User> response = UserController.RegisterUser(userName, userEmail, userPassword, userGender, confirmationPassword, userDob, userRole);

            if (!response.Success)
            {
                ErrorLabel.ForeColor = System.Drawing.Color.Red;
                ErrorLabel.Text = response.Message;
                return;
            }
            else
            {
                ErrorLabel.ForeColor = System.Drawing.Color.Green;
                ErrorLabel.Text = response.Message;
            }

            // Put user in session (log the user in after registering)
            Session["user"] = response.Payload;
            Response.Redirect("~/Views/HomePage.aspx");
        }

        protected void LoginLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/LoginPage.aspx");
        }
    }
}