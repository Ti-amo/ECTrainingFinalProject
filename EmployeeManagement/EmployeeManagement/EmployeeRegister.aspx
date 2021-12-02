<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeRegister.aspx.cs" Inherits="EmployeeManagement.EmployeeRegister" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="main-title">従業員登録</h2>
    <br />
    <table width="100%">
        <tr>
            <td width="35%">
                <asp:Label ID="lbEmployeeCode" runat="server" Text="従業員コード"></asp:Label>
            </td>
            <td width="40%">
                <asp:TextBox ID="TextBoxEmployeeCode" runat="server" Width="293px"></asp:TextBox>
            </td>
        </tr>
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
                <asp:TextBox ID="TextBoxDateOfBirth" runat="server" placeholder="mm/dd/yyyy" TextMode="Date" ReadOnly="false"></asp:TextBox>

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
                <asp:Label ID="lbDate" runat="server" Text="入社日"></asp:Label>
            </td>
            <td width="40%">
                <asp:TextBox ID="TextBoxEmpDate" runat="server" placeholder="mm/dd/yyyy" TextMode="Date" ReadOnly="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="35%"></td>
            <td width="40%" style="height: 100px">
                <asp:Button CssClass="btn btn-danger ml-48" ID="ButtonCancel" runat="server" Text="キャンセル" Width="120px" OnClick="ButtonCancel_Click" />
                <asp:Button CssClass="btn btn-primary" ID="ButtonRegister" runat="server" Text="登録" Width="120px" OnClick="ButtonRegister_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
