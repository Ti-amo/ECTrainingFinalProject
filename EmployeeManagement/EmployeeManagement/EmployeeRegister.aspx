﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeRegister.aspx.cs" Inherits="EmployeeManagement.EmployeeRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
            <!--#include file="Header.inc"-->

        <table width ="45%">  
            <caption><b><span style="font-size:40px">従業員登録</span></b></caption>
    
    <tr>  
         <td width="30%">  
           <asp:Label ID="lbEmployeeCode" runat="server" Text="従業員コード"></asp:Label>
         </td>  
         <td width="40%">  
           <asp:TextBox ID="TextBoxEmployeeCode" runat="server"  Width="293px"></asp:TextBox>
         </td>  
     </tr>  
     <tr>  
         <td width="30%">  
           <asp:Label ID="lbName" runat="server" Text="氏名"></asp:Label>
         </td>  
         <td width="40%">  
           <asp:TextBox ID="TextBoxName" runat="server"  Width="293px"></asp:TextBox>
         </td>  
     </tr>  
     <tr>  
         <td width="30%">  
           <asp:Label ID="lbNameKana" runat="server" Text="氏名（フリガナ）"></asp:Label>
         </td>  
         <td width="40%">  
           <asp:TextBox ID="TextBoxNameKana" runat="server"  Width="293px"></asp:TextBox>
         </td>  
     </tr>  
     <tr>  
         <td width="30%">  
           <asp:Label ID="lbGender" runat="server" Text="性別"></asp:Label>
         </td>  
         <td width="40%">  
             <asp:DropDownList ID="DropDownListGender" runat="server">
                 <asp:ListItem>不明</asp:ListItem>
                <asp:ListItem>男性</asp:ListItem>
                <asp:ListItem>女性</asp:ListItem>
                <asp:ListItem>その他</asp:ListItem>
             </asp:DropDownList>
         </td>  
     </tr>  
     <tr>  
         <td width="30%">  
           <asp:Label ID="lbDateOfBirth" runat="server" Text="生年月日"></asp:Label>
         </td>  
         <td width="40%">  
<asp:TextBox ID="TextBoxDateOfBirth" runat="server" placeholder="mm/dd/yyyy" Textmode="Date" ReadOnly = "false"></asp:TextBox>

         </td>  
     </tr>       
     <tr>  
         <td width="30%">  
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
         <td width="30%">  
           <asp:Label ID="lbDate" runat="server" Text="入社日"></asp:Label>
         </td>  
         <td width="40%">  
<asp:TextBox ID="TextBoxEmpDate" runat="server" placeholder="mm/dd/yyyy" Textmode="Date" ReadOnly = "false"></asp:TextBox>
         </td>  
     </tr>  
             <tr>  
         <td width="30%">  
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



