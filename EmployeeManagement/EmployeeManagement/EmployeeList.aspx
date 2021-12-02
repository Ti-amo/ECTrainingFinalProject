<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="EmployeeManagement.EmployeeList" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <!--#include file="/Include/HamburgerMenu.inc"-->
        </div>
        <h2 class="main-title">全ての従業員</h2>
        
        <div class="employee-list-button">
            <asp:Button CssClass="btn btn-warning" runat="server" ID="ButtonUpdate" Text="変更" OnClick="ButtonUpdate_Click" Width="80" />
            <asp:Button CssClass="btn btn-danger ml-4" runat="server" ID="ButtonDelete" Text="削除" OnClick="ButtonDelete_Click" Width="80" />
        </div>
        <asp:Table runat="server" ID="TableEmployeeList" GridLines="Both" Width="100%" CellPadding="8" >
            <asp:TableHeaderRow>
                <asp:TableHeaderCell BorderStyle="Solid" BorderColor="Black" BorderWidth="1">コード</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderColor="Black" BorderWidth="1">氏名</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderColor="Black" BorderWidth="1">氏名（フリガナ）</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderColor="Black" BorderWidth="1">性別</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderColor="Black" BorderWidth="1">生年月日</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderColor="Black" BorderWidth="1">保有資格</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderColor="Black" BorderWidth="1">所属部署</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderColor="Black" BorderWidth="1">入社日</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderColor="Black" BorderWidth="1"></asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>
</asp:Content>
