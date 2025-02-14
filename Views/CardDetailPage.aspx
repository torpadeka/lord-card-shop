<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/NavigationBar.Master" AutoEventWireup="true" CodeBehind="CardDetailPage.aspx.cs" Inherits="LOrd_Card_Shop.Views.CardDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="..\Styles\CardDetailsPageStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container">
        <h1>Card Detail | ID: <%= cardId %></h1>
        <div class="card-details-content">
             <div class="card-detail-title">Card ID</div>
            <asp:Label ID="CardIDLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <div class="card-detail-title">Card Name</div>
            <asp:Label ID="CardNameLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <div class="card-detail-title">Card Price</div>
            <asp:Label ID="CardPriceLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <div class="card-detail-title">Card Description</div>
            <asp:Label ID="CardDescriptionLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <div class="card-detail-title">Card Type</div>
            <asp:Label ID="CardTypeLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
             <div class="card-detail-title">Is Foil</div>
             <asp:Label ID="CardIsFoilLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button CssClass="button" ID="BackButton" runat="server" Text="Back" OnClick="BackButton_Click" />
        </div>
        <div>
            <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
