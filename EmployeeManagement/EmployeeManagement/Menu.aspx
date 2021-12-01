<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="EmployeeManagement.Menu" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Button CssClass="btn btn-primary" ID="ButtonEmployeeList" runat="server" Text="従業員一覧" OnClick="ButtonEmployeeList_Click" Width="160px" /><br />
        <br />

        <asp:Button CssClass="btn btn-primary" ID="ButtonRegisterEmployee" runat="server" Text="従業員登録" OnClick="ButtonRegisterEmployee_Click" Width="160px" /><br />
        <br />

        <asp:Button CssClass="btn btn-primary" ID="ButtonRegisterUser" runat="server" Text="利用者登録" OnClick="ButtonRegisterUser_Click" Width="160px" /><br />
        <br />

        <asp:Button CssClass="btn btn-primary" ID="ButtonGetLicense" runat="server" Text="資格取得" OnClick="ButtonGetLicense_Click" Width="160px" />
    </div>
</asp:Content>
