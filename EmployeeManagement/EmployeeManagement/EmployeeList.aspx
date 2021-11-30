<%@ Import Namespace="EmployeeManagement.Entity" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="EmployeeManagement.EmployeeList" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <asp:Label runat="server" ID="LabelTitle" Text="全ての従業員" />
            <asp:Button runat="server" ID="ButtonUpdate" Text="変更" OnClick="ButtonUpdate_Click" />
            <asp:Button runat="server" ID="ButtonDelete" Text="削除" OnClick="ButtonDelete_Click" />
        </div>
        <asp:Repeater runat="server" ID="RepeaterEmployeeList">
            <HeaderTemplate>
                <table border="1" cellpadding="5" cellspacing="0">
                    <thead>
                        <tr>
                            <td>コード</td>
                            <td>氏名</td>
                            <td>氏名（フリガナ）</td>
                            <td>性別</td>
                            <td>生年月日</td>
                            <td>保有資格</td>
                            <td>所属部署</td>
                            <td>入社日</td>
                            <td></td>
                        </tr>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tbody>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text='<%# Eval("EmpCode") %>' /></td>
                        <td>
                            <asp:Label runat="server" Text='<%# Eval("Name") %>' /></td>
                        <td>
                            <asp:Label runat="server" Text='<%# Eval("NameKana") %>' /></td>
                        <td>
                            <asp:Label runat="server" Text='<%# Eval("Gender") %>' /></td>
                        <td>
                            <asp:Label runat="server" Text='<%# ((EmployeeEntity)Container.DataItem).GetLicenseName() %>' /></td>
                        <td>
                            <asp:Label runat="server" Text='<%# Eval("Section") %>' /></td>
                        <td>
                            <asp:Label runat="server" Text='<%# Eval("EmpDate") %>' /></td>
                        <td>
                            <asp:CheckBox runat="server" ID="CheckboxEmployee" /></td>
                    </tr>
                </tbody>
            </ItemTemplate>
            <FooterTemplate>
                </table>    
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
