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
    public partial class TransactionHistoryPage : System.Web.UI.Page
    {
        private User currentUser = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Middleware for authentication

            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                // Redirect to login page
                Response.Redirect("~/Views/LoginPage.aspx");
                return;
            }

            // This will run if the user has a cookie, in which we will extend user's session
            if (Session["user"] == null)
            {
                String cookie = Request.Cookies["user_cookie"].Value;

                Response<User> response = UserController.LoginUserByCookie(cookie);

                // If the response for some reason returns failure, then expire the cookie
                if (!response.Success)
                {
                    Response.Cookies["user_cookie"].Expires = DateTime.Now.AddDays(-1);
                    Response.Redirect("~/View/LoginPage.aspx");
                    return;
                }

                Session["user"] = response.Payload;
                currentUser = response.Payload;
            }

            if (currentUser == null)
            {
                currentUser = Session["user"] as User;
            }

            RefreshGridView();
        }

        private void RefreshGridView()
        {
            Response<List<TransactionHeader>> response = null;

            if (currentUser.UserRole.Equals("Customer"))
            {
                response = TransactionController.GetTransactionHeadersByUserId(currentUser.UserID);
            }
            else if (currentUser.UserRole.Equals("Admin"))
            {
                response = TransactionController.GetAllTransactionHeaders();
                TransactionHeaderGridView.Columns[1].Visible = true;
            }


            if (response.Success)
            {
                List<TransactionHeader> transactionHeaders = response.Payload;

                if (transactionHeaders.Count == 0)
                {
                    TransactionHeaderGridView.Visible = false;
                    MessageLabel.ForeColor = System.Drawing.Color.OrangeRed;

                    if (currentUser.UserRole.Equals("Customer"))
                    {
                        MessageLabel.Text = "You haven't done any transactions!";
                    }
                    else if (currentUser.UserRole.Equals("Admin"))
                    {
                        MessageLabel.Text = "No customers have done any transactions! Perhaps get better at marketing?";
                    }

                    return;
                }

                TransactionHeaderGridView.DataSource = transactionHeaders;
                TransactionHeaderGridView.DataBind();
            }
            else
            {
                MessageLabel.ForeColor = System.Drawing.Color.Red;
                MessageLabel.Text = "Something just went obliviously wrong!";
            }

            return;
        }

        protected void TransactionHistoryGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("SeeDetails"))
            {
                GridViewRow row = TransactionHeaderGridView.Rows[Convert.ToInt32(e.CommandArgument)];
                String transactionId = row.Cells[0].Text;

                Response.Redirect("~/Views/TransactionDetailPage.aspx?transactionId=" + transactionId);
            }
        }
    }
}