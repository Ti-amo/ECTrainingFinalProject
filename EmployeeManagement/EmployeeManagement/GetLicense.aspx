<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetLicense.aspx.cs" Inherits="EmployeeManagement.GetLicense" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>資格取得画面</title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- #include file="Header.inc" -->

        <asp:Image ID="Image1" runat="server" /><br />
        <br />
        <div>
            <asp:Label runat="server" Text="資格取得"></asp:Label><br />

            <asp:Label AssociatedControlID="TextBoxEmpCode" runat="server" Text="従業員コード"></asp:Label>
            <asp:TextBox ID="TextBoxEmpCode" runat="server"></asp:TextBox><br />
            
            <asp:Label AssociatedControlID="DropDownListLicense" runat="server" Text="資格"></asp:Label>
            <asp:DropDownList ID="DropDownListLicense" runat="server"></asp:DropDownList><br />

            <asp:Label AssociatedControlID="TextBoxDate" runat="server" Text="取得日"></asp:Label>
            <asp:TextBox ID="TextBoxDate" runat="server" TextMode="Date"></asp:TextBox><br />
        </div>
        <asp:Button ID="ButtonGet" runat="server" Text="取得" OnClick="ButtonGet_Click" /><br />
        <asp:Button ID="ButtonCancel" runat="server" Text="キャンセル" OnClick="ButtonCancel_Click" />
    </form>
</body>
</html>
