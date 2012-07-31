<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Form_RecommendNo.aspx.vb" Inherits="ManageSys_Recommend_Form_RecommendNo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel  ID="upPage"  runat="server" >
    <ContentTemplate>
    <div style =" color :Red ; width :400px; height :260px;">
    <div style =" height :10px;"></div>
        请填写退回原因：<br />
        <asp:TextBox ID="txtPrReThYy" runat="server" TextMode="MultiLine" Width="392px" 
            Height ="181px"></asp:TextBox><br />
        <div style =" height :10px;"></div>
        <div style =" text-align :center ; ">
        <asp:Button ID="btnOK" runat="server" Text="确定" Height="32px" Width="78px" />&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="取消" Height="32px" Width="78px" />
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
