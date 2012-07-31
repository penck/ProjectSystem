<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NoticeShow.aspx.vb" Inherits="ManageSys_Check_NoticeShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>黄山市科技计划项目管理系统</title>
</head>
<body >
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel  ID="upPage"  runat="server" >
    <ContentTemplate>
    <div style =" text-align :center ; font-size :25px;">
        <asp:Label ID="lblNoTitle" runat="server" Text=""></asp:Label></div>
    <div style =" text-align :center ; font-size :12px;">发布者:
        <asp:Label ID="lblNoAnnounce" runat="server" Text=""></asp:Label>&nbsp;&nbsp;发布时间:
        <asp:Label ID="lblNoAddTime" runat="server" Text=""></asp:Label></div>
    <div style ="font-size :18px;">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblNoContent" runat="server" Text=""></asp:Label></div>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
