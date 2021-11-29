<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Finish.aspx.cs" Inherits="EmployeeManagement.Finish" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>完了画面</title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- #include file="Header.inc" -->

        <asp:Image ID="Image1" runat="server" /><br />
        <br />
        <div>
            <asp:Label ID="LabelMsg" runat="server"></asp:Label>
        </div>
        <asp:Button ID="ButtonBack" runat="server" Text="戻る" OnClick="ButtonBack_Click" />
    </form>
</body>
</html>
