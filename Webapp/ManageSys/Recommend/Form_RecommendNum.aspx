<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Form_RecommendNum.aspx.vb" Inherits="ManageSys_Recommend_Form_RecommendNum" %>

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
    <div style =" height :100px;"></div>
    <div style =" text-align :center ; ">
        请选择次序：
        <asp:DropDownList ID="dpRecommendNum" Width="150px" runat="server" 
            Height="26px">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
        </asp:DropDownList>
        <br />
        <div style =" height :10px;"></div>
        <asp:Button ID="btnOK" runat="server" Text="确定" Height="32px" Width="78px" />&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="取消" Height="32px" Width="78px" />
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
