<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ShowDetail.aspx.vb" Inherits="ManageSys_Check_ShowDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>黄山市科技计划项目管理系统</title>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type"/>
    <meta name="GENERATOR" content="MSHTML 9.00.8112.16446"/>
    <meta name="Author" content =""/>
    <meta name="Keywords" content =""/>
    <meta name="Description" content =""/>
    <link rel="stylesheet" type="text/css" href="../../css/style.css"/>
    <link rel="stylesheet" type="text/css" href="../../css/TryStyles.css"/>
    <link rel="stylesheet" type="text/css" href="../../css/main.css"/>
    <style type="text/css">
    A:link{text-decoration:none} 
    A:visited{text-decoration:none} 
    A:hover {color: #339999;}
    </style>
    <style type="text/css">
    table{
	table-layout:fixed;
	empty-cells:show; 
	border-collapse: collapse;
	margin:0 auto;
	text-align:"left";
	font-size:12px;
    }
    table.t1{
	    border:1px solid #cad9ea;

    }

    table.t1 td{
	    border:1px solid  #cad9ea;
	
    }
    td{
	    height:30px;
    }      
    .style1
    {  
       font-size: medium;
       font-weight: bold;
    }       
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="1004" border="0" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td style =" background :url(../../images/top01.jpg); width :1004px; height :139px;">
            </td>
        </tr>
        <tr>
            <td style ="background :url(../../images/top_dh02.gif) repeat-x;">
            </td>
        </tr>
        <tr>
            <td height="1">
            </td>
        </tr>
    </table>

    <table width="1004" height="100%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td width="15%" valign="top" background="../../images/recommend/left_bg.jpg" >
          <table width="100%" border="0" cellpadding="0" cellspacing="0" background="../../images/recommend/left_bg.jpg">
            <tr>
              <td id="Td1" width="13%" height="22">&nbsp;</td>
              <td id="Td2" width="87%" height="22" align="left"><a href="ShowDetail_Basic.aspx?id=<%=Me.gPrId%>" target ="sysMain">一 项目基本情况</a></td>
            </tr>
             <tr>
              <td id="Td3" width="13%" height="22">&nbsp;</td>
              <td id="Td4" width="87%" height="22" align="left"><a href="ShowDetail_Expect.aspx?id=<%=Me.gPrId %>" target ="sysMain"" >二 预期内容和帐号信息</a></td>
            </tr>
            <tr>
              <td height="22">&nbsp;</td>
              <td height="22" align="left">三 主要附件材料</td>
            </tr> 
            <tr>
              <td id="Td5" height="22">&nbsp;</td>
              <td id="Td6" height="22" align="left"><a href="ShowDetail_ApplyBook.aspx?id=<%=Me.gPrId%>" target ="sysMain">项目申报书</a></td>
            </tr>
            <tr>
              <td id="Td7" height="22">&nbsp;</td>
              <td id="Td8" height="22" align="left"><a href="ShowDetail_PlanBook.aspx?id=<%=Me.gPrId%>" target ="sysMain">项目计划任务书</a></td>
            </tr>
          </table></td>
        <td width="100%" valign="top">
        <table  width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr><td>
        <div>
            <iframe frameborder="0" id="sysMain" name="sysMain" scrolling="yes" src="ShowDetail_Basic.aspx?id=<%=Me.gPrId%>" style="height:100%;visibility:inherit; width:100%;z-index:1; height :1000px;"></iframe> 
        </div>
         </td></tr>
        </table>
        </td>
      </tr>
    </table>
    <table border="0" cellSpacing="0" cellPadding="0" width="1004" align="center">
    <tr>
        <td bgColor="#0063a2"><img alt="" src="../../images/bottom_01.gif" width="226" height="7" /></td>
    </tr>
    <tr>
        <td bgColor="#0274bd" height="70" vAlign="top">
            <table border="0" cellSpacing="0" cellPadding="0" width="80%" align="center">
                <tr>
                <td height="8"></td></tr>
                <tr>
                <td>
                <div align="center"><font color="#ffffff">版权所有 © 2012 黄山市科技局 All Rights Reserved. 主办：黄山市科技局<br>
                                            技术支持：黄山市黄山学院信息工程学院</font></div></td></tr>
                </table>
     </td></tr></table>
    </form>
</body>
</html>

