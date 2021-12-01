<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="EmployeeManagement.Error" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="main-title">
        <asp:Label ID="LabelError" runat="server"></asp:Label>
    </h2>
    <p>
        <asp:Label ID="LabelMsg" runat="server"></asp:Label>
    </p>
    <asp:Button CssClass="btn btn-primary" ID="ButtonBack" runat="server" Text="戻る" OnClick="ButtonBack_Click"></asp:Button>
</asp:Content>
