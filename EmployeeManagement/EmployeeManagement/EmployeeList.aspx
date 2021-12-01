<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="EmployeeManagement.EmployeeList" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <!--#include file="/Include/HamburgerMenu.inc"-->
        <div>
            <asp:Label runat="server" ID="LabelTitle" Text="全ての従業員" />
            <asp:Button CssClass="btn btn-warning" runat="server" ID="ButtonUpdate" Text="変更" OnClick="ButtonUpdate_Click" />
            <asp:Button CssClass="btn btn-danger" runat="server" ID="ButtonDelete" Text="削除" OnClick="ButtonDelete_Click" />
        </div>
        <asp:Table runat="server" ID="TableEmployeeList" GridLines="Both">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>コード</asp:TableHeaderCell>
                <asp:TableHeaderCell>氏名</asp:TableHeaderCell>
                <asp:TableHeaderCell>氏名（フリガナ）</asp:TableHeaderCell>
                <asp:TableHeaderCell>性別</asp:TableHeaderCell>
                <asp:TableHeaderCell>生年月日</asp:TableHeaderCell>
                <asp:TableHeaderCell>保有資格</asp:TableHeaderCell>
                <asp:TableHeaderCell>所属部署</asp:TableHeaderCell>
                <asp:TableHeaderCell>入社日</asp:TableHeaderCell>
                <asp:TableHeaderCell></asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>
</asp:Content>
