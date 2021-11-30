<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EmployeeManagement.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ログイン画面</title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- #include file="Header.inc" -->

        <asp:Image ID="Image1" runat="server" /><br />
        <br />
        <div>
            <asp:Label runat="server" Text="ログイン"></asp:Label><br />

            <asp:Label AssociatedControlID="TextBoxUserID" runat="server" Text="ユーザＩＤ"></asp:Label>
            <asp:TextBox ID="TextBoxUserID" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator runat="server" ForeColor="Red" Text="ユーザＩＤを入力してください。" ControlToValidate="TextBoxUserID"></asp:RequiredFieldValidator><br />

            <asp:Label AssociatedControlID="TextBoxPassword" runat="server" Text="パスワード"></asp:Label>
            <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:RequiredFieldValidator runat="server" ForeColor="Red" Text="パスワードを入力してください。" ControlToValidate="TextBoxPassword"></asp:RequiredFieldValidator><br />

            <asp:Label ID="LabelMsg" runat="server" Visible="false"></asp:Label>
        </div>
        <asp:Button ID="ButtonLogin" runat="server" Text="ログイン" OnClick="ButtonLogin_Click" />
    </form>
</body>
</html>
