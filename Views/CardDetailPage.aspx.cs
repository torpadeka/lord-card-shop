﻿using LOrd_Card_Shop.Controllers;
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
	public partial class CardDetailPage : System.Web.UI.Page
	{
        private User currentUser = null;
        public int cardId = 0;
        public Card card = null;

        public String prevPage = "";

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

            cardId = Convert.ToInt32(Request.QueryString["cardId"]);
            prevPage = Request.QueryString["fromPage"];

            if (cardId.Equals(""))
            {
                Response.Redirect("~/View/HomePage.aspx");
            }

            Response<Card> cardResponse = CardController.GetCardById(cardId);

            if (cardResponse.Success)
            {
                card = cardResponse.Payload;

                CardIDLabel.Text = card.CardID.ToString();
                CardNameLabel.Text = card.CardName;
                CardPriceLabel.Text = card.CardPrice.ToString();
                CardDescriptionLabel.Text = card.CardDesc;
                CardTypeLabel.Text = card.CardType;
                CardIsFoilLabel.Text = BitConverter.ToBoolean(card.isFoil, 0) ? "Yes" : "No";
            }
            else
            {
                ErrorLabel.ForeColor = System.Drawing.Color.Red;
                ErrorLabel.Text = "Something went horrendously wrong!";
            }

            if (prevPage.Equals("") || prevPage.Equals("OrderCard"))
            {
                BackButton.Text = "Back to Order Card";
            }
            else if (prevPage.Equals("Cart"))
            {
                BackButton.Text = "Back to Cart";
            }
            else if (prevPage.Equals("TransactionDetail"))
            {
                BackButton.Text = "Back to Transaction Detail";
            }
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            if (prevPage.Equals("") || prevPage.Equals("OrderCard"))
            {
                Response.Redirect("~/Views/OrderCardPage.aspx");
            }
            else if (prevPage.Equals("Cart"))
            {
                Response.Redirect("~/Views/CartPage.aspx");
            }
            else if (prevPage.Equals("TransactionDetail"))
            {
                String transactionId = Request.QueryString["transactionId"];
                Response.Redirect("~/Views/TransactionDetailPage.aspx?transactionId=" + transactionId);
            }
        }
    }
}