<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="EmployeeManagement.Logout" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label runat="server" Text="ログアウトしました。 またね。"></asp:Label>
    </div>
    <asp:Button CssClass="btn btn-primary ml-60" ID="ButtonLogin" runat="server" Text="ログイン" OnClick="ButtonLogin_Click" />
</asp:Content>
