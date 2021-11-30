<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="EmployeeManagement.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>メニュー画面</title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- #include file="Header.inc" -->

        <asp:Image ID="Image1" runat="server" /><br />
        <br />
        <div>
            <asp:Button ID="ButtonEmployeeList" runat="server" Text="従業員一覧" OnClick="ButtonEmployeeList_Click" /><br />
            <br />

            <asp:Button ID="ButtonRegisterEmployee" runat="server" Text="従業員登録" OnClick="ButtonRegisterEmployee_Click" /><br />
            <br />

            <asp:Button ID="ButtonRegisterUser" runat="server" Text="利用者登録" OnClick="ButtonRegisterUser_Click" /><br />
            <br />

            <asp:Button ID="ButtonGetLicense" runat="server" Text="資格取得" OnClick="ButtonGetLicense_Click" />
        </div>
    </form>
</body>
</html>
