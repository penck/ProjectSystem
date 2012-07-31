<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Sbxmgl.aspx.vb" Inherits="ManageSys_Check_Sbxmgl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>��ɽ�пƼ���Ŀ�ƻ�����ϵͳ</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link rel="stylesheet" href="../../css/main.css" type="text/css" />
    <link media="all" href="../../css/TryStyles.css" type="text/css" rel="stylesheet" />
    <style type ="text/css">
        /* ajax__tab_yuitabview-theme theme (img/yui/sprite.png) */
        .ajax__tab_yuitabview-theme .ajax__tab_header 
        {
            font-family:arial,helvetica,clean,sans-serif;
            font-size:small;
            border-bottom:solid 5px #2647a0;
        }
        .ajax__tab_yuitabview-theme .ajax__tab_header .ajax__tab_outer 
        {
            background:url(img/yui/sprite.png) #d8d8d8 repeat-x;
            margin:0px 0.16em 0px 0px;
            padding:1px 0px 1px 0px;
            vertical-align:bottom;
            border:solid 1px #a3a3a3;
            border-bottom-width:0px;
        }
        .ajax__tab_yuitabview-theme .ajax__tab_header .ajax__tab_tab
        {    
            color:#000;
            padding:0.35em 0.75em;    
            margin-right:0.01em;
        }
        .ajax__tab_yuitabview-theme .ajax__tab_hover .ajax__tab_outer 
        {
            background: url(img/yui/sprite.png) #bfdaff repeat-x left -1300px;
        }
        .ajax__tab_yuitabview-theme .ajax__tab_active .ajax__tab_tab 
        {
            color:#fff;
        }
        .ajax__tab_yuitabview-theme .ajax__tab_active .ajax__tab_outer
        {
            background:url(img/yui/sprite.png) #2647a0 repeat-x left -1400px;
        }
        .ajax__tab_yuitabview-theme .ajax__tab_body 
        {
            font-family:verdana,tahoma,helvetica;
            font-size:10pt;
            padding:0.25em 0.5em;
            background-color:#edf5ff;    
            border:solid 1px #808080;
            border-top-width:0px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <ajaxToolkit:TabContainer runat="server" CssClass="ajax__tab_yuitabview-theme">
    
    <ajaxToolkit:TabPanel ID ="tab1" runat="server" HeaderText="�ύ��Ŀ">
    <ContentTemplate>
    <asp:UpdatePanel  ID="upSubmitPage"  runat="server" >
    <ContentTemplate>
    <div style="display: block">
        <div style="line-height: 24px;">
            <table id="zb" width="100%" border="0" cellspacing="1" cellpadding="6" bgcolor="#D2E2F0">
	            <tr>
		        <td style="width:260px">��Ŀ��λ��
                    <asp:TextBox ID="txtPrBaHostUnit" runat="server" Width ="150px"></asp:TextBox>
                </td>
		        <td style="width:260px">�Ƽ���λ��
                    <asp:DropDownList ID="ddlRecUnit" runat="server" Width="150px"> </asp:DropDownList>
                </td>
                <td> 
                    <asp:Button ID="btnSearch" runat="server" Text="��ѯ" Width ="60px" />
                </td>
	            </tr>
            </table>
        </div>
        <div>
        <asp:GridView ID="gvProjectSubmit" runat="server" Width="100%" 
            CellPadding="4" ForeColor="#333333" Font-Size="15px"
            GridLines="None" AutoGenerateColumns="False" DataKeyNames="PrId"
            EmptyDataText="û���κ����ݿ�����ʾ">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="PrId" HeaderText="ID" />
                <asp:TemplateField HeaderText="���">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text="<%# Container.DataItemIndex + 1%>" ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="��Ŀ����">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName ="SubmitPrName"
                         CommandArgument="<%# CType(Container, GridViewRow).RowIndex %>" ><%# Eval("PrName") %></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PrBaHostUnit" HeaderText="��ɵ�λ" />
                <asp:BoundField DataField="PrBaYear" HeaderText="���" />
                <asp:BoundField DataField="PrStatus" HeaderText="��Ŀ״̬" />
                <asp:BoundField DataField="PrBaSczbk" HeaderText="�в�������" />
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
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    </ContentTemplate>
    </ajaxToolkit:TabPanel>

    <ajaxToolkit:TabPanel ID ="tab2" runat="server" HeaderText="Ԥ�Ƽ���Ŀ">
    <ContentTemplate>
    <asp:UpdatePanel  ID="upPreparePage"  runat="server" >
    <ContentTemplate>
    <div style="display: block">
        <div style="line-height: 24px;">
            <table id="Table2" width="100%" border="0" cellspacing="1" cellpadding="6" bgcolor="#D2E2F0">
	            <tr>
		        <td  style="width:260px">��Ŀ��λ��
                    <asp:TextBox ID="txtPrBaHostUnit3" runat="server" Width ="150px"></asp:TextBox> 
                </td> 
		        <td style="width:260px">�Ƽ���λ��
                    <asp:DropDownList ID="ddlRecUnit3" runat="server" Width="150px"> </asp:DropDownList>
                </td>
                <td> 
                    <asp:Button ID="btnSearch3" runat="server" Text="��ѯ" Width ="60px" />
                </td>
	            </tr>
            </table>
        </div>
        <div>
        <asp:GridView ID="gvProjectPrepare" runat="server" Width="100%" 
            CellPadding="4" ForeColor="#333333" Font-Size="15px"
            GridLines="None" AutoGenerateColumns="False" DataKeyNames="PrId"
            EmptyDataText="û���κ����ݿ�����ʾ">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="PrId" HeaderText="ID" />
                <asp:TemplateField HeaderText="���">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text="<%# Container.DataItemIndex + 1%>" ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="��Ŀ����">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton7" runat="server" CommandName ="PreparePrName"
                         CommandArgument="<%# CType(Container, GridViewRow).RowIndex %>" ><%# Eval("PrName") %></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PrBaHostUnit" HeaderText="��ɵ�λ" />
                <asp:BoundField DataField="PrBaYear" HeaderText="���" />
                <asp:BoundField DataField="PrStatus" HeaderText="��Ŀ״̬" />
                <asp:BoundField DataField="PrBaSczbk" HeaderText="�в�������" />
                <asp:TemplateField HeaderText="Ԥ�����">
                    <ItemTemplate >
                        <asp:LinkButton ID="LinkButton8" runat="server" CommandName ="CheckYes"
                         CommandArgument="<%# CType(Container, GridViewRow).RowIndex %>" >ͨ��</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:LinkButton ID="LinkButton9" runat="server" CommandName ="CheckNo"
                         CommandArgument="<%# CType(Container, GridViewRow).RowIndex %>" >�˻�</asp:LinkButton>
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
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    </ContentTemplate>
    </ajaxToolkit:TabPanel>

    <ajaxToolkit:TabPanel ID ="tab3" runat="server" HeaderText="���Ƽ���Ŀ">
    <ContentTemplate>
    <asp:UpdatePanel  ID="upRecommendPage"  runat="server" >
    <ContentTemplate>
    <div style="display: block">
        <div style="line-height: 24px;">
                <table id="Table1" width="100%" border="0" cellspacing="1" cellpadding="6" bgcolor="#D2E2F0">
	                <tr>
		            <td  style="width:260px">��Ŀ��λ��
                        <asp:TextBox ID="txtPrBaHostUnit2" runat="server" Width ="150px"></asp:TextBox>
                    </td> 
		            <td style="width:260px">�Ƽ���λ��
                        <asp:DropDownList ID="ddlRecUnit2" runat="server" Width="150px"> </asp:DropDownList>
                    </td>
                    <td> 
                        <asp:Button ID="btnSearch2" runat="server" Text="��ѯ" Width ="60px" />
                    </td>
	                </tr>
                </table>
        </div>
        <asp:GridView ID="gvProjectRecommend" runat="server" Width="100%" 
            CellPadding="4" ForeColor="#333333" Font-Size="15px"
            GridLines="None" AutoGenerateColumns="False" DataKeyNames="PrId" 
            EmptyDataText="û���κ����ݿ�����ʾ">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="PrId" HeaderText="ID"/>
                <asp:TemplateField HeaderText="���">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text="<%# Container.DataItemIndex + 1%>" ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="��Ŀ����">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton4" runat="server" CommandName ="RecommendPrName"
                         CommandArgument="<%# CType(Container, GridViewRow).RowIndex %>" ><%# Eval("PrName") %></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PrBaHostUnit" HeaderText="��ɵ�λ" />
                <asp:BoundField DataField="PrBaYear" HeaderText="���" />
                <asp:BoundField DataField="PrStatus" HeaderText="��Ŀ״̬" />
                <asp:BoundField DataField="PrBaSczbk" HeaderText="�в�������" />
                <asp:BoundField DataField="PrReNo" HeaderText="�Ƽ�����" />
                <asp:TemplateField HeaderText="����">
                    <ItemTemplate >
                        <asp:LinkButton ID="LinkButton5" runat="server" CommandName ="Lixiang"
                         CommandArgument="<%# CType(Container, GridViewRow).RowIndex %>" >����</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="�˻�">
                    <ItemTemplate >
                        <asp:LinkButton ID="LinkButton6" runat="server" CommandName ="Tuihui"
                         CommandArgument="<%# CType(Container, GridViewRow).RowIndex %>" >�˻�</asp:LinkButton>
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
    </ContentTemplate>
    </ajaxToolkit:TabPanel>

    </ajaxToolkit:TabContainer> 
    
    </form>
</body>
</html>
