﻿using LOrd_Card_Shop.Controllers;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrd_Card_Shop.Views
{
	public partial class CartPage : System.Web.UI.Page
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

            if (response.Success)
            {
                List<CartCardDataObject> cartCards = response.Payload;

                if (cartCards.Count == 0)
                {
                    CartsGridView.Visible = false;
                    MessageLabel.ForeColor = System.Drawing.Color.OrangeRed;
                    MessageLabel.Text = "Your cart is empty :')";

                    return;
                }

                CartsGridView.DataSource = cartCards;
                CartsGridView.DataBind();
            }
            else
            {
                MessageLabel.ForeColor = System.Drawing.Color.Red;
                MessageLabel.Text = "Something just went sooooooo wrong!";
            }

            return;
        }

        protected void CartsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("SeeDetails"))
            {
                GridViewRow row = CartsGridView.Rows[Convert.ToInt32(e.CommandArgument)];
                String cardId = row.Cells[0].Text;

                Response.Redirect("~/Views/CardDetailPage.aspx?cardId=" + cardId + "&fromPage=Cart");
            }
        }

        protected void CheckoutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/CheckOutPage.aspx");
        }

        protected void ClearCartButton_Click(object sender, EventArgs e)
        {
            Response<List<Cart>> response = CartController.ClearUserCart(currentUser.UserID);

            RefreshGridView();

            if (response.Success)
            {
                MessageLabel.ForeColor = System.Drawing.Color.Green;
                MessageLabel.Text = "Your cart was cleared!";
            }
            else
            {
                MessageLabel.ForeColor = System.Drawing.Color.Red;
                MessageLabel.Text = "Something has went ludicrously wrong!";
            }
        }
    }
}