<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="EmployeeManagement.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>エラー画面</title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- #include file="Header.inc" -->

        <h2>
            <asp:Label ID="LabelError" runat="server"></asp:Label>
        </h2>
        <p>
            <asp:Label ID="LabelMsg" runat="server"></asp:Label>
        </p>
        <asp:Button ID="ButtonBack" runat="server" Text="戻る" OnClick="ButtonBack_Click"></asp:Button>
    </form>
</body>
</html>
