<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="LOrd_Card_Shop.Views.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Login Page</h1>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label ID="UsernameLabel" runat="server" Text="Username"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <div>
            <div>
                <asp:Label ID="PasswordLabel" runat="server" Text="Password"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
            </div>
        </div>
        <br />
        <div>
            <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
        </div>
        <br />
        <div>
            <asp:CheckBox ID="RememberMeCheckBox" runat="server" />
            <span>Remember Me?</span>
        </div>
        <br />
        <div>
            <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
        </div>
        <br />
        <div>
            <asp:LinkButton ID="RegisterLinkButton" runat="server" OnClick="RegisterLinkButton_Click">No Account? Register Here</asp:LinkButton>
        </div>
    </form>
</body>
</html>
