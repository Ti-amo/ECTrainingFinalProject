<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="EmployeeManagement.UserRegister" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="main-title">利用者登録</h2>
    <br />
    <table width="100%">
        <tr>
            <td width="20%">
                <asp:Label ID="lbUserId" runat="server" Text="ユーザID"></asp:Label>
            </td>
            <td width="40%">
                <asp:TextBox ID="TextBoxUserId" runat="server" Width="293px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="30%">
                <asp:Label ID="lbPassword" runat="server" Text="パスワード"></asp:Label>
            </td>
            <td width="40%">
                <asp:TextBox ID="TextBoxPassword" TextMode="Password" runat="server" Width="293px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="20%"></td>
            <td width="40%" style="height: 100px">
                <asp:Button CssClass="btn btn-danger ml-48" ID="ButtonCancel" runat="server" Text="キャンセル" Width="120px" OnClick="ButtonCancel_Click" />
                <asp:Button CssClass="btn btn-primary" ID="ButtonRegister" runat="server" Text="登録" Width="120px" OnClick="ButtonRegister_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
