<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Finish.aspx.cs" Inherits="EmployeeManagement.Finish" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="main-title">
        <asp:Label ID="LabelFinish" runat="server"></asp:Label>
    </h2>
    <div style="display:flex; justify-content: space-between">
        <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" Text="戻る" OnClick="ButtonBack_Click" />
        <asp:Button CssClass="btn btn-warning" ID="Button2" runat="server" Text="メニュー画面" OnClick="ButtonMenu_Click" />
    </div>
</asp:Content>
