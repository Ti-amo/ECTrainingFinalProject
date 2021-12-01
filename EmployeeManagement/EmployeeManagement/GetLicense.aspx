<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetLicense.aspx.cs" Inherits="EmployeeManagement.GetLicense" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2 class="main-title">資格取得</h2>
        <br />

        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell Width="35%">
                        <asp:Label AssociatedControlID="TextBoxEmpCode" runat="server" Text="従業員コード"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxEmpCode" runat="server" Width="293px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                        <asp:Label AssociatedControlID="DropDownListLicense" runat="server" Text="資格"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListLicense" runat="server"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                        <asp:Label AssociatedControlID="TextBoxDate" runat="server" Text="取得日"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxDate" runat="server" TextMode="Date"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                </asp:TableCell>
                <asp:TableCell Height="100px">
                    <asp:Button CssClass="btn btn-danger ml-48" ID="ButtonCancel" runat="server" Text="キャンセル" Width="120px" OnClick="ButtonCancel_Click" />
                    <asp:Button CssClass="btn btn-primary ml-4" ID="ButtonGet" runat="server" Text="取得" Width="120px" OnClick="ButtonGet_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
</asp:Content>
