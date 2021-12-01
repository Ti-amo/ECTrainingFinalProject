<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EmployeeManagement.Login" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label runat="server" Text="ログイン"></asp:Label><br />

        <asp:Label AssociatedControlID="TextBoxUserID" runat="server" Text="ユーザＩＤ"></asp:Label>
        <asp:TextBox ID="TextBoxUserID" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator runat="server" ForeColor="Red" Text="ユーザＩＤを入力してください。" ControlToValidate="TextBoxUserID"></asp:RequiredFieldValidator><br />

        <asp:Label AssociatedControlID="TextBoxPassword" runat="server" Text="パスワード"></asp:Label>
        <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox><br />
        <asp:RequiredFieldValidator runat="server" ForeColor="Red" Text="パスワードを入力してください。" ControlToValidate="TextBoxPassword"></asp:RequiredFieldValidator><br />

        <asp:Label ID="LabelMsg" runat="server" Visible="false"></asp:Label>
    </div>
    <asp:Button ID="ButtonLogin" runat="server" Text="ログイン" OnClick="ButtonLogin_Click" />
</asp:Content>
