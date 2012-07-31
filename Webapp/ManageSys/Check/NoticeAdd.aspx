<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NoticeAdd.aspx.vb" Inherits="ManageSys_Check_NoticeAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>黄山市科技计划项目管理系统</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel  ID="upPage"  runat="server" >
    <ContentTemplate>
    <div style ="width :100%;">
    <div style =" height :10px;"></div>
        <div style ="color :Red ;">添加通知公告：</div><br /><br />
        标题：<asp:TextBox ID="txtNoTitle" runat="server" Width ="300px"></asp:TextBox><br /><br />
        <div>内容：</div>
        <asp:TextBox ID="txtNoContent" runat="server" style="height: 200px; width: 98%;" TextMode="MultiLine"></asp:TextBox>
        <div style =" height :10px;"></div>
        <div style =" text-align :center ; ">
        <asp:Button ID="btnOK" runat="server" Text="确定" Height="32px" Width="78px" />
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
