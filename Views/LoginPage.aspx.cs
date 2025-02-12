using LOrd_Card_Shop.Controllers;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrd_Card_Shop.Views
{
    public partial class LoginPage : System.Web.UI.Page
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

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            ErrorLabel.ForeColor = System.Drawing.Color.Red;

            String userName = UsernameTextBox.Text;
            String userPassword = PasswordTextBox.Text;
            Boolean rememberMe = RememberMeCheckBox.Checked;

            Response<User> response = UserController.LoginUser(userName, userPassword);

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

            if (rememberMe)
            {
                // Encrypt the UserID that will become the cookie value
                String cookieValue = Convert.ToBase64String(MachineKey.Protect(Encoding.UTF8.GetBytes(response.Payload.UserID.ToString())));

                HttpCookie cookie = new HttpCookie("user_cookie")
                {
                    Value = cookieValue,
                    Expires = DateTime.Now.AddHours(2)
                };
                Response.Cookies.Add(cookie);
            }

            // Put user in session
            Session["user"] = response.Payload;
            Response.Redirect("~/Views/HomePage.aspx");
        }

        protected void RegisterLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/RegisterPage.aspx");
        }
    }
}