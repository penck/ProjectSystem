<%@ Page Language="VB" AutoEventWireup="false" CodeFile="register.aspx.vb" Inherits="register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>黄山市科技计划管理项目系统-用户注册</title>
    <style type="text/css">
        .register
        {
        	border-width: 0px;
        	background :url(images/button_register01.gif) no-repeat;
        }
        .cancel
        {
        	border-width: 0px;
        	background :url(images/button_register02.gif) no-repeat;
        }
    </style>
    <link rel="stylesheet" href="css/main.css" type="text/css"/>
    <script language="JavaScript" type="text/JavaScript">
        function datetime() {
            var enabled = 0; today = new Date();
            var day; var date;
            if (today.getDay() == 0) day = "星期日"
            if (today.getDay() == 1) day = "星期一"
            if (today.getDay() == 2) day = "星期二"
            if (today.getDay() == 3) day = "星期三"
            if (today.getDay() == 4) day = "星期四"
            if (today.getDay() == 5) day = "星期五"
            if (today.getDay() == 6) day = "星期六"
            date = (today.getYear()) + "年" + (today.getMonth() + 1) + "月" + today.getDate() + "日 " + day + "";
            document.write(date);
        }
    </script>
</head>
<body style =" margin:0px;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <!--头部开始 -->
    <table border="0" cellpadding="0" cellspacing="0" width="1004" align="center">
        <tbody><tr>
            <td style =" background :url(images/top01.jpg); width :1004px; height :139px;">
            </td>
        </tr>
        <tr>
            <td style ="background :url(images/top_dh02.gif) repeat-x;">
                <table class="dh" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tbody><tr>
                        <td style ="background :url(images/top_dh01.gif) no-repeat ; height :35px;width :251px; vertical-align :bottom ; ">
                            <table border="0" cellpadding="0" cellspacing="0" width="95%" align="center">
                                <tbody><tr>
                                    <td height="30">
                                        <font color="#FFFFFF">今天是 </font><font color="#ffffff">
                                            <script language="JavaScript" type="text/javascript" class="white">
                                                datetime();
                                            </script>
                                        </font>
                                    </td>
                                </tr>
                               </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody></table>
            </td>
        </tr>
        <tr>
            <td height="2">
            </td>
        </tr>
       </tbody>
    </table>
    <!--头部结束 -->
    <asp:UpdatePanel  ID="upPage"  runat="server" >
    <ContentTemplate>
    <!--注册界面开始 -->
    <table border="0" cellpadding="0" cellspacing="0" width="1004" align="center">
        <tbody><tr>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tbody><tr>
                        <td height="1">
                        </td>
                    </tr>
                    <tr>
                        <td style =" background :url(images/top_dh04.gif); height :30px;">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tbody><tr>
                                    <td width="40">
                                        <div align="center">
                                            <img alt ="" src="images/list02.gif" height="22" width="11" /></div>
                                    </td>
                                    <td>
                                        <font color="#666666">系统首页 &gt; 用户注册</font>
                                    </td>
                                </tr>
                            </tbody></table>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="D2E2F0" height="1">
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                            
                        </td>
                    </tr>
                </tbody></table>
                
                <table border="0" cellpadding="0" cellspacing="0" width="864" align="center">
                    <tbody>
                    <tr>
                        <td>
                            <img alt="" src="images/register_01.gif" height="29" width="864"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tbody><tr>
                                    <td width="281">
                                        <img alt ="" src="images/register_02.gif" height="410" width="281"/>
                                    </td>
                                    <td style =" background :url(images/register_03.gif);" valign="top">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tbody><tr>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                        </tbody></table>
                                        <table bgcolor="#D2E2F0" border="0" cellpadding="6" cellspacing="1" width="90%" align="center">
                                            <tbody>
                                            <tr>
                                                <td bgcolor="F2F9FE">
                                                    <div align="center">
                                                        <font color="006DBD">用 户 名：</font></div>
                                                </td>
                                                <td bgcolor="#FFFFFF">
                                                    <asp:TextBox ID="txtUsName" runat="server" TabIndex ="1" style="height: 20px; width: 200px;"></asp:TextBox>
                                                    &nbsp;<font color="#FF6600">*</font>(请用不多于50个字母或数字）
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="F2F9FE">
                                                    <div align="center">
                                                        <font color="006DBD">密 码：</font></div>
                                                </td>
                                                <td bgcolor="#FFFFFF">
                                                    <asp:TextBox ID="txtUsPassWord"  runat="server" TabIndex ="2" style="height: 20px; width: 200px;" TextMode="Password"></asp:TextBox>
                                                    &nbsp;<font color="#FF6600">*</font>(请用不多于50个字母或数字）
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="F2F9FE">
                                                    <div align="center">
                                                        <font color="006DBD">密码确认：</font></div>
                                                </td>
                                                <td bgcolor="#FFFFFF">
                                                    <asp:TextBox ID="txtUsPassWord_Check" runat="server" TabIndex ="3" style="height: 20px; width: 200px;" TextMode="Password"></asp:TextBox>
                                                    &nbsp;<font color="#FF6600">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="F2F9FE">
                                                    <div align="center">
                                                        <font color="006DBD">单位名称：</font></div>
                                                </td>
                                                <td bgcolor="#FFFFFF">
                                                    <asp:TextBox ID="txtUsCompany" TabIndex ="4" runat="server" style="height: 20px; width: 200px;"></asp:TextBox>
                                                    &nbsp;<font color="#FF6600">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="F2F9FE">
                                                    <div align="center">
                                                        <font color="006DBD">联系人姓名：</font></div>
                                                </td>
                                                <td bgcolor="#FFFFFF">
                                                    <asp:TextBox ID="txtUsContactName" runat="server" TabIndex ="5" style="height: 20px; width: 200px;"></asp:TextBox>
                                                    &nbsp;<font color="#FF6600">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="F2F9FE">
                                                    <div align="center">
                                                        <font color="006DBD">工作号码：</font></div>
                                                </td>
                                                <td bgcolor="#FFFFFF">
                                                    <asp:TextBox ID="txtUsTelephone" runat="server" TabIndex ="6" style="height: 20px; width: 200px;"></asp:TextBox>
                                                    &nbsp;<font color="#FF6600">*</font>(如：1234-1234567）
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="F2F9FE">
                                                    <div align="center">
                                                        <font color="006DBD">手机号码：</font></div>
                                                </td>
                                                <td bgcolor="#FFFFFF">
                                                    <asp:TextBox ID="txtUsMobilephone" runat="server" TabIndex ="7" style="height: 20px; width: 200px;"></asp:TextBox>
                                                    &nbsp;<font color="#FF6600">*</font>(如：12345678901）
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="F2F9FE">
                                                    <div align="center">
                                                        <font color="006DBD">验 证 码：</font></div>
                                                </td>
                                                <td bgcolor="#FFFFFF">
                                                    <asp:TextBox ID="txtCode" runat="server" TabIndex ="8" style="height: 20px; width: 200px;" ></asp:TextBox>
                                                    &nbsp;&nbsp;<asp:Image ID="ValidateImage" runat="server" Height="20px" Width="55px" ImageAlign="AbsBottom" />&nbsp;<font color="#FF6600">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="#D2E2F0" height="4">
                                                </td>
                                                <td bgcolor="#D2E2F0" height="4">
                                                </td>
                                            </tr>
                                            <tr bgcolor="#FFFFFF">
                                                <td colspan="2" height="70">
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tbody><tr>
                                                            <td width="95">&nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnOk" runat="server" Width ="119px" Height ="30px" 
                                                                    CssClass="register" TabIndex ="9" />&nbsp;
                                                                <asp:Button ID="btnCancel" runat="server" Width ="119px" Height ="30px" 
                                                                    CssClass="cancel" TabIndex ="10" />&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                        <td colspan ="2" style =" color :Red ; text-align :center ; ">
                                                            当前页面注册成功用户均为申报用户,只能以申报用户身份在首页面登录
                                                            </td>
                                                        </tr>
                                                    </tbody></table>
                                                </td>
                                            </tr>
                                        </tbody></table>
                                    </td>
                                </tr>
                            </tbody></table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <img alt ="" src="images/register_04.gif" height="15" width="864"/>
                        </td>
                    </tr>
                    </tbody>
                 </table>
                 
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tbody><tr>
                        <td>&nbsp;
                            
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                            
                        </td>
                    </tr>
                </tbody></table>
            </td>
        </tr>
    </tbody></table>
    <!--注册界面结束 -->
    </ContentTemplate>
    </asp:UpdatePanel> 
    <!--底部开始 -->
    <table border="0" cellpadding="0" cellspacing="0" width="1004" align="center">
        <tbody><tr>
            <td bgcolor="0063A2">
                <img alt ="" src="images/bottom_01.gif" height="7" width="226"/>
            </td>
        </tr>
        <tr>
            <td bgcolor="0274BD" height="70" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="80%" align="center">
                    <tbody><tr>
                        <td height="8">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="center">
                                 <font color="#FFFFFF">版权所有 © 2012 黄山市科技局 All Rights Reserved. 主办：黄山市科技局<br>
                                    技术支持：黄山市黄山学院信息工程学院</font></div>
                        </td>
                    </tr>
                </tbody></table>
            </td>
        </tr>
    </tbody></table>
    <!--底部结束 -->
    
    </form>
</body>
</html>
