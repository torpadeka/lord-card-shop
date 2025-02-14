<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/NavigationBar.Master" AutoEventWireup="true" CodeBehind="OrderCardPage.aspx.cs" Inherits="LOrd_Card_Shop.Views.OrderCardPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="..\Styles\OrderCardPageStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container">
        <h1>Order Card</h1>
        <asp:GridView ID="CardsGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="CardsGridView_RowCommand">
            <Columns>
                <asp:BoundField DataField="CardID" HeaderText="Card ID" SortExpression="CardID" />
                <asp:BoundField DataField="CardName" HeaderText="Card Name" SortExpression="CardName" />
                <asp:BoundField DataField="CardPrice" HeaderText="Card Price" SortExpression="CardPrice" />
                <asp:ButtonField ButtonType="Button" CommandName="SeeDetails" HeaderText="Card Details" ShowHeader="True" Text="See Details" />
                <asp:ButtonField ButtonType="Button" CommandName="AddToCart" HeaderText="Action" ShowHeader="True" Text="Add to Cart" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="MessageLabel" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
