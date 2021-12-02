<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="EmployeeManagement.Logout" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">
        <h2>ログアウトしました。 またね。</h2>
        <br />
        <asp:Button CssClass="btn btn-primary" ID="ButtonLogin" runat="server" Text="ログイン" OnClick="ButtonLogin_Click" />
    </div>
</asp:Content>
