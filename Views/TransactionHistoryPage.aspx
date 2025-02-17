<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/NavigationBar.Master" AutoEventWireup="true" CodeBehind="TransactionHistoryPage.aspx.cs" Inherits="LOrd_Card_Shop.Views.TransactionHistoryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container">
        <h1>Transaction History</h1>
        <div>
            <asp:GridView ID="TransactionHeaderGridView" runat="server" AutoGenerateColumns="false" OnRowCommand="TransactionHistoryGridView_RowCommand">
                <Columns>
                    <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                    <asp:BoundField DataField="CustomerID" HeaderText="Customer ID" SortExpression="TransactionID" Visible="false" />
                    <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:ButtonField ButtonType="Button" CommandName="SeeDetails" HeaderText="See Details" ShowHeader="True" Text="See Details" />
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <asp:Label ID="MessageLabel" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
