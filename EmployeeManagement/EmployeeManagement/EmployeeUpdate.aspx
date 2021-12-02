<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeUpdate.aspx.cs" Inherits="EmployeeManagement.EmployeeUpdate" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="main-title">従業員情報変更</h2>
    <br />
    <table width="100%">
        <tr>
            <td width="35%">
                <asp:Label ID="lbName" runat="server" Text="氏名"></asp:Label>
            </td>
            <td width="40%">
                <asp:TextBox ID="TextBoxName" runat="server" Width="293px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="35%">
                <asp:Label ID="lbNameKana" runat="server" Text="氏名（フリガナ）"></asp:Label>
            </td>
            <td width="40%">
                <asp:TextBox ID="TextBoxNameKana" runat="server" Width="293px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="35%">
                <asp:Label ID="lbGender" runat="server" Text="性別"></asp:Label>
            </td>
            <td width="40%">
                <asp:DropDownList ID="DropDownListGender" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td width="35%">
                <asp:Label ID="lbSection" runat="server" Text="所属部署"></asp:Label>
            </td>
            <td width="40%">
                <asp:DropDownList ID="DropDownListSection" runat="server">
                    <asp:ListItem>管理部</asp:ListItem>
                    <asp:ListItem>総務部</asp:ListItem>
                    <asp:ListItem>開発部</asp:ListItem>
                    <asp:ListItem>営業部</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td width="35%"></td>
            <td width="40%" style="height: 100px">
                <asp:Button CssClass="btn btn-danger" ID="ButtonCancel" runat="server" Text="キャンセル" Width="120px" OnClick="ButtonCancel_Click" />
                <asp:Button CssClass="btn btn-primary" ID="ButtonRegister" runat="server" Text="登録" Width="120px" OnClick="ButtonRegister_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
