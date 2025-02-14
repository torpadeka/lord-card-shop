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
	public partial class OrderCardPage : System.Web.UI.Page
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
            Response<List<Card>> response = CardController.GetAllCards();

            List<Card> cards = response.Payload;

            CardsGridView.DataSource = cards;
            CardsGridView.DataBind();
        }

        protected void CardsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName.Equals("SeeDetails"))
            {
                GridViewRow row = CardsGridView.Rows[Convert.ToInt32(e.CommandArgument)];
                String cardId = row.Cells[0].Text;

                Response.Redirect("~/Views/CardDetailPage.aspx?cardId=" + cardId);
            }

            if(e.CommandName.Equals("AddToCart"))
            {
                GridViewRow row = CardsGridView.Rows[Convert.ToInt32(e.CommandArgument)];
                String cardId = row.Cells[0].Text;

                Response<Cart> response = CartController.AddCardToCart(Convert.ToInt32(cardId), currentUser.UserID);

                if (response.Success)
                {
                    MessageLabel.ForeColor = System.Drawing.Color.Green;
                    MessageLabel.Text = "Card added to cart successfully!";
                }
                else
                {
                    MessageLabel.ForeColor = System.Drawing.Color.Red;
                    MessageLabel.Text = "Card was not added to cart. Something went terribly wrong!";
                }
            }
        }
    }
}