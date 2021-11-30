<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="EmployeeManagement.Logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ログアウト画面</title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- #include file="Header.inc" -->

        <asp:Image ID="Image1" runat="server" /><br />
        <br />
        <div>
            <asp:Label runat="server" Text="ログアウトしました。 またね。"></asp:Label>
        </div>
        <asp:Button CssClass="btn btn-primary" ID="ButtonLogin" runat="server" Text="ログイン" OnClick="ButtonLogin_Click" />
    </form>
</body>
</html>
