<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/NavigationBar.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="LOrd_Card_Shop.Views.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="..\Styles\HomePageStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <h1>
            <asp:Label ID="WelcomeLabel" runat="server" Text=""></asp:Label>
        </h1>
    </div>
</asp:Content>
