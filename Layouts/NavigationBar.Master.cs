using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrd_Card_Shop.Layouts
{
	public partial class NavigationBar : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			// Master Page's load event runs after the plcaeholder pages
			// Therefore we can simply validate if a session exists, then decide which navbar to show

			if (Session["user"] != null)
			{
				User user = Session["user"] as User;

				if (user.UserRole.Equals("Admin"))
				{
					AdminNavbarPanel.Visible = true;
				}

                if (user.UserRole.Equals("Customer"))
                {
                    CustomerNavbarPanel.Visible = true;
                }
            }
			else
			{
				// Code should never reach here, but it's a safeguard
				Response.Redirect("~/Views/LoginPage.aspx");
			}
		}

        // Link Buttons' events
        protected void HomeLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HomePage.aspx");
        }

        protected void ManageCardLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageCardPage.aspx");
        }

        protected void ViewTransactionLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ViewTransactionPage.aspx");
        }

        protected void TransactionReportLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TransactionReportPage.aspx");
        }

        protected void LogoutLinkButton_Click(object sender, EventArgs e)
        {
            String[] cookies = Request.Cookies.AllKeys;

            foreach(String cookie in cookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }

            Session.Remove("user");

            Response.Redirect("~/Views/LoginPage.aspx");
        }

        protected void OrderQueueLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/OrderQueuePage.aspx");
        }

        protected void OrderCardLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/OrderCardPage.aspx");
        }

        protected void ProfileLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ProfilePage.aspx");
        }

        protected void HistoryLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TransactionHistoryPage.aspx");
        }

        protected void CartLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/CartPage.aspx");
        }
    }
}