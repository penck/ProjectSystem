<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Tzgg.aspx.vb" Inherits="ManageSys_Recommend_Tzgg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="line-height: 24px;">
            <table id="zb" width="100%" border="0" cellspacing="1" cellpadding="6" bgcolor="#D2E2F0">
	            <tr>
		        <td bgcolor="F2F9FE" align="left" style="font-size: small; font-style: normal;" >
                </td>
                <td align="right" style="font-size: small; font-style: normal; width :120px;">
                        <a href="NoticeAdd.aspx?id=0" target="mainFrame">添加通知公告</a>&nbsp;
                </td>
		        <td align="right" style="font-size: small; font-style: normal; width :120px;"">
                        <a href="NoticeManage.aspx" target="mainFrame">管理通知公告</a>&nbsp;
                </td>
	            </tr>
            </table>
        </div> 

        <div >
        <div style =" color:Red; height :20px; font-size :15px; background-color:#F2F9FE; text-align :center ;">通知公告如下：</div>
        <div><asp:Label ID="lblNoTitle" runat="server" Text=""></asp:Label></div>
        </div>
        </div>
    </form>
</body>
</html>
