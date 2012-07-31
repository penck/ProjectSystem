<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NoticeManage.aspx.vb" Inherits="ManageSys_Check_NoticeManage" %>

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
        <div>
        <div style="line-height: 24px;">
            <table id="zb" width="100%" border="0" cellspacing="1" cellpadding="6" bgcolor="#D2E2F0">
	            <tr>
		        <td bgcolor="F2F9FE" align="left" style="font-size: small; font-style: normal;" >
                </td>
                <td align="right" style="font-size: small; font-style: normal; width :120px;">
                        <a href="NoticeAdd.aspx?id=0" target="mainFrame">添加通知公告</a>&nbsp;
                </td>
	            </tr>
            </table>
        </div>
    <div>
        <asp:GridView ID="gvNoticeInfo" runat="server" Width="100%" 
            CellPadding="4" ForeColor="#333333" Font-Size="15px"
            GridLines="None" AutoGenerateColumns="False" DataKeyNames="NoId" 
            EmptyDataText="没有任何数据可以显示">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="NoId" HeaderText="ID" />
                <asp:TemplateField HeaderText="编号">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text="<%# Container.DataItemIndex + 1%>" ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="标题">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName ="NoticeTitle"
                         CommandArgument="<%# CType(Container, GridViewRow).RowIndex %>" ><%# Eval("NoTitle") %></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="NoAnnounce" HeaderText="发布人" />
                <asp:BoundField DataField="NoYear" HeaderText="年份" />
                <asp:TemplateField HeaderText="修改">
                    <ItemTemplate >
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName ="NoticeUpdate"
                         CommandArgument="<%# CType(Container, GridViewRow).RowIndex %>" >修改</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除">
                    <ItemTemplate >
                        <asp:LinkButton ID="LinkButton3" runat="server" CommandName ="NoticeDelete"
                         CommandArgument="<%# CType(Container, GridViewRow).RowIndex %>" OnClientClick ="return confirm('确定要删除吗？')">删除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
