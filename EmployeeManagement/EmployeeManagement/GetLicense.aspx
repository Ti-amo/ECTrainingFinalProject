<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetLicense.aspx.cs" Inherits="EmployeeManagement.GetLicense" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>資格取得</h2>
        <br />

        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                        <asp:Label AssociatedControlID="TextBoxEmpCode" runat="server" Text="従業員コード"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxEmpCode" runat="server"></asp:TextBox>
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
                    <asp:Button ID="ButtonGet" runat="server" Text="取得" OnClick="ButtonGet_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="ButtonCancel" runat="server" Text="キャンセル" OnClick="ButtonCancel_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
</asp:Content>
