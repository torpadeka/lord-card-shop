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
	public partial class CheckOutPage : System.Web.UI.Page
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

            if (!currentUser.UserRole.Equals("Customer"))
            {
                Response.Redirect("~/View/HomePage.aspx");
            }

            RefreshGridView();
        }

        private void RefreshGridView()
        {
            Response<List<CartCardDataObject>> response = CartController.GetCartsAndCardsByUserId(currentUser.UserID);

            List<CartCardDataObject> cartCards = response.Payload;

            if (cartCards.Count == 0)
            {
                Response.Redirect("~/Views/CartPage.aspx");
            }

            CheckoutGridView.DataSource = cartCards;
            CheckoutGridView.DataBind();

            return;
        }

        protected void ProceedWithCheckoutButton_Click(object sender, EventArgs e)
        {
            Response<List<CartCardDataObject>> userCartCardsResponse = CartController.GetCartsAndCardsByUserId(currentUser.UserID);

            if (userCartCardsResponse.Success)
            {
                List<CartCardDataObject> cartCards = userCartCardsResponse.Payload;

                Response<TransactionHeader> thResponse = TransactionController.CreateTransactionHeader(currentUser.UserID);
                TransactionHeader th = thResponse.Payload;

                foreach (CartCardDataObject cc in cartCards)
                {
                    TransactionController.CreateTransactionDetail(th.TransactionID, cc.CardID, cc.Quantity);
                }

                CartController.ClearUserCart(currentUser.UserID);

                CheckoutGridView.Visible = false;
                ProceedWithCheckoutButton.Visible = false;

                MessageLabel.ForeColor = System.Drawing.Color.Green;
                MessageLabel.Text = "Checkout done! Transaction has been created!";

                ViewTransactionHistoryButton.Visible = true;
            }
            else
            {
                MessageLabel.ForeColor = System.Drawing.Color.Red;
                MessageLabel.Text = "Something has went unbelievably wrong!";
            }
        }

        protected void ViewTransactionHistoryButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TransactionHistoryPage.aspx");
        }
    }
}