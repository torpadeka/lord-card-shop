<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/NavigationBar.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="LOrd_Card_Shop.Views.TransactionDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container">
        <h1>
            <asp:Label ID="TransactionDetailHeaderLabel" runat="server" Text="Transaction Detail | ID: "></asp:Label>
        </h1>
        <div class="transaction-content">
            <asp:Label ID="CustomerIDLabel" runat="server" Text="Customer ID: " Visible="false"></asp:Label>
        </div>
        <div class="transaction-content">
            <div class="transaction-title">Transaction ID</div>
            <asp:Label ID="TransactionIDLabel" runat="server" Text=""></asp:Label>
        </div>
        <div class="transaction-content">
            <div class="transaction-title">Transaction Date</div>
            <asp:Label ID="TransactionDateLabel" runat="server" Text=""></asp:Label>
        </div>
        <div class="transaction-content">
            <div class="transaction-title">Transaction Status</div>
            <asp:Label ID="TransactionStatusLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <h2>Cards List</h2>
        </div>
        <div>
            <asp:GridView ID="TransactionDetailsGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="TransactionDetailsGridView_RowCommand">
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
            <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
