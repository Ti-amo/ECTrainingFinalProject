<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="EmployeeManagement.UserRegister" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>利用者登録</h1>
        <table width="45%" >  
               <%-- <caption><b>利用者登録</b></caption>--%>
    <tr>  
         <td width="20%">  
           <asp:Label ID="lbUserId" runat="server" Text="ユーザID"></asp:Label>
         </td>  
         <td width="40%">  
           <asp:TextBox ID="TextBoxUserId" runat="server"  Width="293px"></asp:TextBox>
         </td>  
     </tr>  
     <tr>  
         <td width="20%">  
           <asp:Label ID="lbPassword" runat="server" Text="パスワード"></asp:Label>
         </td>  
         <td width="40%">  
           <asp:TextBox ID="TextBoxPassword" runat="server"  Width="293px"></asp:TextBox>
         </td>  
     </tr>
             <tr>  
         <td width="20%">  
         </td>  
         <td width="40%">  
           <asp:Button ID="ButtonCancel" runat="server" Text="キャンセル"  Width="120px" OnClick="ButtonCancel_Click"/>
                <asp:Button ID="ButtonRegister" runat="server" Text="登録" Width="120px" OnClick ="ButtonRegister_Click" />

         </td>  
     </tr>  
     
 </table>  
 </asp:Content>