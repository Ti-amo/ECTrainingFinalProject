<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeUpdate.aspx.cs" Inherits="EmployeeManagement.EmployeeUpdate" MasterPageFile="~/Site.Master" ValidateRequest="false" %>

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
                <asp:Label ID="lbDateOfBirth" runat="server" Text="生年月日"></asp:Label>
            </td>
            <td width="40%">
                <asp:TextBox ID="TextBoxDateOfBirth" runat="server" TextMode="Date">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="35%">
                <asp:Label ID="lbSection" runat="server" Text="所属部署"></asp:Label>
            </td>
            <td width="40%">
                <asp:DropDownList ID="DropDownListSection" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td width="35%">
                <asp:Label ID="lbEmpDate" runat="server" Text="入社日"></asp:Label>
            </td>
            <td width="40%">
                <asp:TextBox ID="TextBoxEmpDate" runat="server" TextMode="Date">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="35%"></td>
            <td width="40%" style="height: 100px">
                <asp:Button CssClass="btn btn-danger" ID="ButtonCancel" runat="server" Text="キャンセル" Width="120px" OnClick="ButtonCancel_Click" />
                <asp:Button CssClass="btn btn-primary" ID="ButtonUpdate" runat="server" Text="変更" Width="120px" OnClick="ButtonUpdate_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
