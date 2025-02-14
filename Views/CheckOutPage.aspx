<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/NavigationBar.Master" AutoEventWireup="true" CodeBehind="CheckOutPage.aspx.cs" Inherits="LOrd_Card_Shop.Views.CheckOutPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="..\Styles\CheckOutPageStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container">
        <h1>Checkout</h1>
        <div>
            <asp:GridView ID="CheckoutGridView" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="CardID" HeaderText="Card ID" SortExpression="CardID" />
                    <asp:BoundField DataField="CardName" HeaderText="Card Name" SortExpression="CardName" />
                    <asp:BoundField DataField="CardPrice" HeaderText="Card Price" SortExpression="CardPrice" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <asp:Button CssClass="button" ID="ProceedWithCheckoutButton" runat="server" Text="Proceed With Checkout" OnClick="ProceedWithCheckoutButton_Click" />
        </div>
        <div>
            <asp:Label ID="MessageLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button CssClass="button" ID="ViewTransactionHistoryButton" runat="server" Text="View Transaction History" OnClick="ViewTransactionHistoryButton_Click" />
        </div>
    </div>
</asp:Content>
