<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="EmployeeManagement.UserRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <!--#include file="Header.inc"-->

        <table width ="45%">  
                <caption><b><span style="font-size:40px">利用者登録</span></b></caption>
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
       
    </form>
</body>
</html>