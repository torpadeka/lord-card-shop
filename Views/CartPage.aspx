<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/NavigationBar.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="LOrd_Card_Shop.Views.CartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="..\Styles\CartPageStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container">
        <h1>Cart</h1>
        <div>
            <asp:GridView ID="CartsGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="CartsGridView_RowCommand">
                <Columns>
                    <asp:BoundField DataField="CardID" HeaderText="Card ID" SortExpression="CardID" />
                    <asp:BoundField DataField="CardName" HeaderText="Card Name" SortExpression="CardName" />
                    <asp:BoundField DataField="CardPrice" HeaderText="Card Price" SortExpression="CardPrice" />
                    <asp:ButtonField ButtonType="Button" CommandName="SeeDetails" HeaderText="Card Details" ShowHeader="True" Text="See Details" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <asp:Button CssClass="button" ID="CheckoutButton" runat="server" Text="Checkout" OnClick="CheckoutButton_Click" />
        </div>
    </div>
</asp:Content>
