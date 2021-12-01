<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Finish.aspx.cs" Inherits="EmployeeManagement.Finish" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        <asp:Label ID="LabelFinish" runat="server"></asp:Label>
    </h2>
    <asp:Button ID="ButtonBack" runat="server" Text="戻る" OnClick="ButtonBack_Click" />
</asp:Content>
