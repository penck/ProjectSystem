<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ShowDetail_Basic.aspx.vb" Inherits="ManageSys_Recommend_ShowDetail_Basic" %>

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
    <div id="Div1" style =" height :1000px;">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="text-align: center" align="center" class="t1">
        <tr>
            <td colspan="5" bgcolor="#F2F9FE" align="center" class="style1">
                申报基本信息表
            </td>
        </tr>
        <tr>
            <td bgcolor="#F2F9FE">
                项目类型
            </td>
            <td bgcolor="#FFFFFF" colspan="2" class="orange" align="center">
                <asp:Label ID="lblPrBaClass" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
            <td bgcolor="#F2F9FE" colspan="1">
                批次
            </td>
            <td bgcolor="#FFFFFF" class="orange" align="center">
                <asp:Label ID="lblPrBaYear" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="#F2F9FE">
                项目名称
            </td>
            <td bgcolor="#FFFFFF" colspan="4" class="orange" align="center">
                <asp:Label ID="lblPrBaName" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="#F2F9FE">
                申报日期
            </td>
            <td bgcolor="#FFFFFF" class="orange" align="center">
                <asp:Label ID="lblPrBaApplyTime" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
            <td bgcolor="#F2F9FE" colspan="1">
                项目所在地区（区，县)
            </td>
            <td bgcolor="#FFFFFF" class="orange" align="center">
                <asp:Label ID="lblPrBaArea" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="#F2F9FE">
                推荐单位
            </td>
            <td bgcolor="#FFFFFF" class="orange" colspan="2" align="center">
                <asp:Label ID="lblReUnId" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
            <td bgcolor="#F2F9FE">
                推荐单位性质
            </td>
            <td bgcolor="#FFFFFF" class="orange">
                <asp:Label ID="lblReUnClass" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="#F2F9FE">
                承担单位
            </td>
            <td bgcolor="#FFFFFF" class="orange" colspan="2" align="center">
                <asp:Label ID="lblPrBaHostUnit" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
            <td>
                承担单位性质
            </td>
            <td bgcolor="#FFFFFF" class="orange">
                <asp:Label ID="lblPrBaHostUnitClass" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="#F2F9FE">
                合作单位
            </td>
            <td bgcolor="#FFFFFF" class="orange" colspan="2" align="center">
                <asp:Label ID="lblPrBaCooperationUnit" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
            <td bgcolor="#F2F9FE">
                合作单位性质
            </td>
            <td bgcolor="#FFFFFF" class="orange">
                <asp:Label ID="lblPrBaCooperationUnitClass" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="#F2F9FE">
                产学研合作
            </td>
            <td bgcolor="#FFFFFF" class="orange" colspan="2" align="center">
                <asp:Label ID="lblPrBaIsCxyhz" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
            <td bgcolor="#F2F9FE">
                合作形式
            </td>
            <td bgcolor="#FFFFFF" class="orange">
                <asp:Label ID="lblPrBaHzxs" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td rowspan="4" bgcolor="#F2F9FE">
                项目负责人
            </td>
            <td bgcolor="#F2F9FE">
                姓名
            </td>
            <td align="center">
                <asp:Label ID="lblPrBaHostName" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
            <td bgcolor="#F2F9FE">
                性别
            </td>
            <td bgcolor="#FFFFFF" class="orange" align="center">
                <asp:Label ID="lblPrBaHostSex" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="#F2F9FE">
                学历
            </td>
            <td bgcolor="#FFFFFF" class="orange" align="center">
                <asp:Label ID="lblPrBaHostEducation" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
            <td bgcolor="#F2F9FE">
                职称
            </td>
            <td bgcolor="#FFFFFF" class="orange" align="center">
                <asp:Label ID="lblPrBaHostPosition" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="#F2F9FE">
                出生年月
            </td>
            <td bgcolor="#FFFFFF" class="orange" align="center">
                <asp:Label ID="lblPrBaHostBirth" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
            <td bgcolor="#F2F9FE">
                联系电话
            </td>
            <td bgcolor="#FFFFFF" class="orange" align="center">
                <asp:Label ID="lblPrBaHostWorkPhone" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                手机
            </td>
            <td bgcolor="#FFFFFF" class="orange" align="center">
                <asp:Label ID="lblPrBaHostMobilePhone" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
            <td>
                Email
            </td>
            <td bgcolor="#FFFFFF" class="orange" align="center">
                <asp:Label ID="lblPrBaHostEmail" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td rowspan="3" bgcolor="#F2F9FE">
                项目组人数
            </td>
            <td bgcolor="#F2F9FE">
                总人数
            </td>
            <td bgcolor="#FFFFFF" class="orange" colspan="3" align="center">
                <asp:Label ID="lblPrBaAllPeopleNumber" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="#F2F9FE">
                高级职称人数
            </td>
            <td bgcolor="#FFFFFF" class="orange" align="center">
                <asp:Label ID="lblPrBaGjzcNumber" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
            <td bgcolor="#F2F9FE">
                中级职称人数
            </td>
            <td align="center" bgcolor="#FFFFFF" class="orange">
                <asp:Label ID="lblPrBaZjzcNumber" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="#F2F9FE">
                初级职称人数
            </td>
            <td bgcolor="#FFFFFF" class="orange" align="center">
                <asp:Label ID="lblPrBaCjzcNumber" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
            <td bgcolor="#F2F9FE">
                其他
            </td>
            <td align="center" bgcolor="#FFFFFF" class="orange">
                <asp:Label ID="lblPrBaOtherNumber" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td rowspan="4" bgcolor="#F2F9FE">
                研发总投入（万元）
            </td>
            <td bgcolor="#F2F9FE">
                合计
            </td>
            <td bgcolor="#FFFFFF" class="orange" colspan="3">
                <asp:Label ID="lblPrBaYfztr" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td rowspan="3" bgcolor="#F2F9FE">
                其中
            </td>
            <td bgcolor="#FFFFFF" class="orange" bgcolor="#F2F9FE">
                申请市财政拨款
            </td>
            <td align="center" colspan="2">
                <asp:Label ID="lblPrBaSczbk" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="#F2F9FE">
                区县财政拨款
            </td>
            <td bgcolor="#FFFFFF" class="orange" align="center" colspan="2">
                <asp:Label ID="lblPrBaQxczbk" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="#F2F9FE">
                单位自筹
            </td>
            <td bgcolor="#FFFFFF" class="orange" align="center" colspan="2">
                <asp:Label ID="lblPrBaDwzc" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td rowspan="11" bgcolor="#F2F9FE">
                预期效应
            </td>
            <td rowspan="5" bgcolor="#F2F9FE">
                研发成果形式
            </td>
            <td bgcolor="#F2F9FE">
                开发新产品
            </td>
            <td bgcolor="#FFFFFF" class="orange" colspan="2" align="center">
                <asp:Label ID="lblPrBaKfxcp" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="#F2F9FE">
                取得专利
            </td>
            <td bgcolor="#FFFFFF" class="orange" colspan="2" align="center">
                <asp:Label ID="lblPrBaQdzlx" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="#F2F9FE">
                技术标准
            </td>
            <td bgcolor="#FFFFFF" class="orange" colspan="2" align="center">
                <asp:Label ID="lblPrBaJsbz" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="#F2F9FE">
                动植物新品种
            </td>
            <td bgcolor="#FFFFFF" class="orange" colspan="2" align="center">
                <asp:Label ID="lblPrBaDzwxpz" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="#F2F9FE">
                其他
            </td>
            <td bgcolor="#FFFFFF" class="orange" colspan="2" align="center">
                <asp:Label ID="lblPrBaYfOther" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td rowspan="6" bgcolor="#F2F9FE">
                产业成果
            </td>
            <td bgcolor="#F2F9FE">
                新增企业（家）
            </td>
            <td bgcolor="#FFFFFF" class="orange" colspan="2" align="center">
                <asp:Label ID="lblPrBaXzqy" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="#F2F9FE">
                形成生产能力
            </td>
            <td bgcolor="#FFFFFF" class="orange" colspan="2" align="center">
                <asp:Label ID="lblPrBaXcscnl" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="#F2F9FE">
                拉动产业投资（万元）
            </td>
            <td bgcolor="#FFFFFF" class="orange" colspan="2" align="center">
                <asp:Label ID="lblPrBaLdcytz" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="#F2F9FE">
                新增销售收入（万元）
            </td>
            <td bgcolor="#FFFFFF" class="orange" colspan="2" align="center">
                <asp:Label ID="lblPrBaXzxssr" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="#F2F9FE">
                新增利税（万元）
            </td>
            <td bgcolor="#FFFFFF" class="orange" colspan="2" align="center">
                <asp:Label ID="lblPrBaXzls" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="#F2F9FE">
                创汇（万美元）
            </td>
            <td bgcolor="#FFFFFF" class="orange" colspan="2" align="center">
                <asp:Label ID="lblPrBaCh" runat="server" Text="" style="display:inline-block;width:80%;"></asp:Label>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
