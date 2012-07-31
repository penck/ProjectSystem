<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ShowDetail_Expect.aspx.vb" Inherits="ManageSys_Recommend_ShowDetail_Expect" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>黄山市科技计划项目管理系统</title>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type"/>
    <meta name="GENERATOR" content="MSHTML 9.00.8112.16446"/>
    <meta name="Author" content =""/>
    <meta name="Keywords" content =""/>
    <meta name="Description" content =""/>
    <link rel="stylesheet" type="text/css" href="../../css/style.css"/>
    <link rel="stylesheet" type="text/css" href="../../css/tryStyles.css"/>
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
    <table border="0" cellspacing="1" cellpadding="5" width="92%" bgcolor="#cfe6f6" align="center">
        <tr>
        <td bgcolor="#e2f1fc">项目名称</td>
        <td style="background-color: white;" colSpan="2">
            <asp:Label ID="lblPrName" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
        <td bgcolor="#e2f1fc">主持人</td>
        <td style="background-color: white;" colSpan="2">
            <asp:Label ID="lblPrBaHostName" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
        <td bgcolor="#e2f1fc">归口管理部门</td>
        <td style="background-color: white;" colSpan="2">
            <asp:Label ID="lblReUnName" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr id="ctl00_ContentPlaceHolder1_wcdate">
        <td bgcolor="#e2f1fc">完成时间</td>
        <td style="background-color: white;" colSpan="2">
            <asp:Label ID="lblPrExWcsj" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
        <td bgcolor="#e2f1fc" colSpan="3">主要研究内容<font color="red">（请不要超过200汉字）</font></td></tr>
        <tr>
        <td style="background-color: white;" colSpan="3">
        <asp:TextBox ID="txtPrExZyyjnr" runat="server" ReadOnly="True" TextMode="MultiLine" style="width: 98%; height: 150px;"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td bgColor="#e2f1fc" colSpan="3">预期目标<font color="red">（请不要超过100汉字）</font></td>
        </tr>
        <tr>
        <td style="background-color: white;" colSpan="3">
        <asp:TextBox ID="txtPrExYqmb" runat="server" ReadOnly="True" TextMode="MultiLine" style="width: 98%; height: 120px;"></asp:TextBox>
        </td></tr>
        <tr>
        <td style="width: 20%;" bgColor="#e2f1fc" rowSpan="3">项目经费账号信息 
                        </td>
        <td style="width: 20%; background-color: white;">              
            单位帐户全称：            </td>
        <td style="background-color: white;">
        <asp:Label ID="lblPrExDwzhqc" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
        <td style="width: 20%; background-color: white;">              
            开户行全称：            </td>
        <td style="background-color: white;">
        <asp:Label ID="lblPrExKhhqc" runat="server" Text=""></asp:Label>
        </td></tr>
        <tr>
        <td style="width: 20%; background-color: white;">              
            开户行帐号：            </td>
        <td style="background-color: white;">
        <asp:Label ID="lblPrExKhhzh" runat="server" Text=""></asp:Label>
        </td></tr>
        </table>
    </form>
</body>
</html>
