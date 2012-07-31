<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Xgmm.aspx.vb" Inherits="ManageSys_Check_Xgmm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center; vertical-align:middle">
         <br />
         <br />
         <br />
         <table bgcolor="#D2E2F0" border="0" cellpadding="6" cellspacing="1" width="50%" align="center" style="vertical-align:middle">
            <tbody>   
                <tr>
                    <td height="4" colspan="2">
                    </td>
                </tr>
                <tr>
                    <td bgcolor="F2F9FE">
                        <div align="center">
                            <font color="006DBD">原 密 码：</font></div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:TextBox ID="txtPassWordOri" TextMode="Password"  runat="server" Height ="20px" Width="148px" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="F2F9FE">
                        <div align="center">
                            <font color="006DBD">新 密 码：</font></div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:TextBox ID="txtPassWordNew" runat="server" Height ="20px" Width="148px" 
                            TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="F2F9FE">
                        <div align="center">
                            <font color="006DBD">确 认 密 码：</font></div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:TextBox ID="txtPassWordConfirm" runat="server" Width="148px" TextMode="Password" /> 
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#D2E2F0" height="4" colspan = "2">
                    </td> 
                </tr>  
            </tbody>
        </table>
        <div  style="text-align:center; vertical-align:middle"> 
            <asp:Label ID="lblMessage" runat="server" Text="" /> <br />
            <asp:Button ID="btnSubmit" runat="server" Text="保存" />
        </div>
    </div>
    </form>
</body>
</html>
