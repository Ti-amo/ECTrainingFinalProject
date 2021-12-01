<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="EmployeeManagement.Menu" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Button ID="ButtonEmployeeList" runat="server" Text="従業員一覧" OnClick="ButtonEmployeeList_Click" /><br />
        <br />

        <asp:Button ID="ButtonRegisterEmployee" runat="server" Text="従業員登録" OnClick="ButtonRegisterEmployee_Click" /><br />
        <br />

        <asp:Button ID="ButtonRegisterUser" runat="server" Text="利用者登録" OnClick="ButtonRegisterUser_Click" /><br />
        <br />

        <asp:Button ID="ButtonGetLicense" runat="server" Text="資格取得" OnClick="ButtonGetLicense_Click" />
    </div>
</asp:Content>
