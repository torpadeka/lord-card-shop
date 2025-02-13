<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="LOrd_Card_Shop.Views.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Register Page</h1>
    <form id="form" runat="server">
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
                <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
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
            <div>
                <asp:Label ID="GenderLabel" runat="server" Text="Gender"></asp:Label>
            </div>
            <div>
                <asp:RadioButtonList ID="GenderRadioButtonList" runat="server">
                    <asp:ListItem Value="Male">Male</asp:ListItem>
                    <asp:ListItem Value="Female">Female</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <br />
        <div>
            <div>
                <asp:Label ID="ConfirmationPasswordLabel" runat="server" Text="Confirm Password"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="ConfirmationPasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
            </div>
        </div>
        <br />
        <div>
            <div>
                <asp:Label ID="DOBLabel" runat="server" Text="Date of Birth"></asp:Label>
            </div>
            <div>
                <asp:Calendar ID="DOBCalendar" runat="server"></asp:Calendar>
            </div>
        </div>
        <br />
        <div>
            <div>
                <asp:Label ID="RoleLabel" runat="server" Text="Role"></asp:Label>
            </div>
            <div>
                <asp:DropDownList ID="RoleDropDownList" runat="server">
                    <asp:ListItem Value="Customer" Selected="True">Customer</asp:ListItem>
                    <asp:ListItem Value="Admin">Admin</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <br />
        <div>
            <asp:Button ID="RegisterButton" runat="server" Text="Register" OnClick="RegisterButton_Click" />
        </div>
        <br />
        <div>
            <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
        </div>
        <br />
        <div>
            <asp:LinkButton ID="LoginLinkButton" runat="server" OnClick="LoginLinkButton_Click">Already Have an Account? Login Here</asp:LinkButton>
        </div>
</form>
</body>
</html>
