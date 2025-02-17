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
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        private User currentUser = null;
        public int transactionId = 0;
        public TransactionHeader transactionHeader = null;
        public List<TransactionDetail> transactionDetail = null;

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

            if (Request.QueryString["transactionId"].Equals(""))
            {
                Response.Redirect("~/View/HomePage.aspx");
            }

            transactionId = Convert.ToInt32(Request.QueryString["transactionId"]);

            Response<TransactionHeader> transactionHeaderResponse = TransactionController.GetTransactionHeaderById(transactionId);
            Response<List<TransactionDetail>> transactionDetailResponse = TransactionController.GetTransactionDetailsById(transactionId);

            TransactionDetailHeaderLabel.Text = "Transaction Detail | ID: " + transactionId.ToString();

            if (transactionDetailResponse.Success)
            {
                transactionHeader = transactionHeaderResponse.Payload;
                transactionDetail = transactionDetailResponse.Payload;

                TransactionIDLabel.Text = transactionHeader.TransactionID.ToString();
                TransactionDateLabel.Text = transactionHeader.TransactionDate.ToString();
                TransactionStatusLabel.Text = transactionHeader.Status.ToString();

                if (currentUser.UserRole.Equals("Admin"))
                {
                    CustomerIDLabel.Text = "Customer ID: " + transactionHeader.CustomerID.ToString();
                    CustomerIDLabel.Visible = true;
                }
            }
            else
            {
                ErrorLabel.ForeColor = System.Drawing.Color.Red;
                ErrorLabel.Text = "Something went unmistakably wrong!";
            }

            if (currentUser.UserRole.Equals("Admin"))
            {
                TransactionDetailsGridView.Columns[3].Visible = false;
            }

            RefreshGridView();
        }

        private void RefreshGridView()
        {
            Response<List<TransactionCardDataObject>> response = TransactionController.GetTransactionsAndCards(transactionId);

            if (response.Success)
            {
                List<TransactionCardDataObject> transactionCards = response.Payload;

                TransactionDetailsGridView.DataSource = transactionCards;
                TransactionDetailsGridView.DataBind();
            }
            else
            {
                ErrorLabel.ForeColor = System.Drawing.Color.Red;
                ErrorLabel.Text = "Something went unmistakably wrong!";
            }

            return;
        }

        protected void TransactionDetailsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("SeeDetails"))
            {
                GridViewRow row = TransactionDetailsGridView.Rows[Convert.ToInt32(e.CommandArgument)];
                String cardId = row.Cells[0].Text;

                Response.Redirect("~/Views/CardDetailPage.aspx?cardId=" + cardId + "&fromPage=TransactionDetail&transactionId=" + transactionId.ToString());
            }
        }
    }
}