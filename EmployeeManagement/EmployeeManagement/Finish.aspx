<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Finish.aspx.cs" Inherits="EmployeeManagement.Finish" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>完了画面</title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- #include file="Header.inc" -->

        <h2>
            <asp:Label ID="LabelFinish" runat="server"></asp:Label>
        </h2>
        <asp:Button ID="ButtonBack" runat="server" Text="戻る" OnClick="ButtonBack_Click" />
    </form>
</body>
</html>