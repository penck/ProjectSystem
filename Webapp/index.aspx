

<%@ Page Language="VB" AutoEventWireup="false" CodeFile="index.aspx.vb" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>黄山市科技计划管理项目系统-用户登录</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
    <link rel="stylesheet" href="css/main.css" type="text/css"/>
    <script language="javascript" type="text/javascript">
        function datetime() {
            var enabled = 0; today = new Date();
            var day; var date;
            if (today.getDay() == 0) day = "星期日";
            if (today.getDay() == 1) day = "星期一";
            if (today.getDay() == 2) day = "星期二";
            if (today.getDay() == 3) day = "星期三";
            if (today.getDay() == 4) day = "星期四";
            if (today.getDay() == 5) day = "星期五";
            if (today.getDay() == 6) day = "星期六";
            date = (today.getYear()) + "年" + (today.getMonth() + 1) + "月" + today.getDate() + "日 " + day + "";
            document.write(date);
        }
    </script>
    <style type="text/css">
        .style1
        {
            width: 107px;
        }
        .login
        {
        	border-width: 0px;
        	background :url(images/button_login02.gif) no-repeat;
        }
        .register
        {
        	border-width: 0px;
        	background :url(images/button_login01.gif) no-repeat;
        }
    </style>
</head>
<body style ="margin :0px; background-color :#FFFFFF">
<form runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <!--头部开始-->
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
    <!--头部结束-->
    <asp:UpdatePanel  ID="upPage"  runat="server" >
    <ContentTemplate>
    <!--用户登录界面开始-->
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
                                        <font color="#666666">系统首页 &gt; 用户登录</font>
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
                                        <img alt ="" src="images/login_01.gif" height="410" width="281"/>
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
                                                        <font color="006DBD">用 户 类 型：</font></div>
                                                </td>
                                                <td bgcolor="#FFFFFF">
                                                    <asp:DropDownList ID="dpUsType" runat="server" style=" height :20px; width :154px;">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="F2F9FE">
                                                    <div align="center">
                                                        <font color="006DBD">用 户 名：</font></div>
                                                </td>
                                                <td bgcolor="#FFFFFF">
                                                    <asp:TextBox ID="txtUsName" runat="server" Height ="20px" Width="148px" ></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="F2F9FE">
                                                    <div align="center">
                                                        <font color="006DBD">密 码：</font></div>
                                                </td>
                                                <td bgcolor="#FFFFFF">
                                                    <asp:TextBox ID="txtUsPassword" runat="server" Height ="20px" Width="148px" 
                                                        TextMode="Password"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="F2F9FE">
                                                    <div align="center">
                                                        <font color="006DBD">验 证 码：</font></div>
                                                </td>
                                                <td bgcolor="#FFFFFF">
                                                    <asp:TextBox ID="txtCode" runat="server" Width="87px"></asp:TextBox>&nbsp;&nbsp;
                                                    <asp:Image ID="ValidateImage" runat="server" Height="20px" Width="55px" ImageAlign="AbsBottom" />
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
                                                        <tbody><tr align ="center">
                                                            <td>
                                                                <asp:LinkButton ID="lbtnLogin" runat="server" CssClass="login" Width ="89px" Height ="28px"></asp:LinkButton>
                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                                <asp:LinkButton ID="lbtnRegister" runat="server" CssClass="register" Width ="89px" Height ="28px"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align ="center"  height="7">
                                                                <font color="red">注意事项：<br/>
                                                                    无账号的用户请点击“注册”按钮，注册用户后登录本系统</font>
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
    <!--用户登录界面结束-->
    </ContentTemplate>
    </asp:UpdatePanel> 
    <!--流程图片开始-->
    <table border="0" cellpadding="0" cellspacing="0" width="1004" align="center">
        <tbody><tr>
            <td>
                <img alt ="" src="images/index_main06.jpg" border="0" height="164" width="1004"/>
            </td>
        </tr>
    </tbody></table>
    <!--流程图片结束-->
    
    <!--底部开始-->
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
    <!--底部结束-->
    
</form></body>
</html>
