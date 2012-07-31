<%@ Page Title="" Language="VB" MasterPageFile="~/ManageSys/Apply/Xmsb/XmsbPage.master" AutoEventWireup="false" CodeFile="ApplyBook.aspx.vb" Inherits="ManageSys_ApplyUser_ApplyBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">                   
    <br/>
    <asp:UpdatePanel ID="upApplyBookPage" runat="server">
    <ContentTemplate >
    
    <table style="width: 100%;">
    <tr >
        <td bgcolor="#bed1eb" colspan ="2">请点击浏览按钮选择要上传的文件，点击上传按钮进行上传！</td>
    </tr>
	<tr>
		<td bgcolor="#bed1eb">
                项目申报书：
        </td>
		<td bgcolor="#bed1eb">
            <asp:FileUpload ID="fupApplyBook" runat="server" />只能上传word2003版文档，且大小不要超过4M！<asp:Button ID="btnOk" runat="server" Text="上传" />
        </td>
	</tr>
    </table>

    <table style="width: 100%;">
        <tr>
            <td colspan="2" style="width: 14%;" bgcolor="#bed1eb">
                项目名称：
            </td>
            <td colspan="6">
                <asp:Label ID="lblPrName" runat="server" Text="lblPrName"></asp:Label>
            </td>
        </tr>
        <tr align="left">
            <td colspan="8" valign="top">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <span style="color: Red">已上传附件列表如下：</span>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="8">
                <div style="width: 100%">
                    <asp:GridView ID="gvApplyBook" runat="server" Width="100%" 
                        AutoGenerateColumns="False" CellPadding="4" DataKeyNames="PrFiId" 
                        ForeColor="#333333" GridLines="None" EmptyDataText="没有任何数据可以显示" 
                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                        <Columns>
                            <asp:BoundField DataField="PrFiId" HeaderText="编号" />
                            <asp:BoundField DataField="PrFiName" HeaderText="项目附件名称" />
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName ="deleteFile" CommandArgument="<%# CType(Container, GridViewRow).RowIndex %>"  OnClientClick ="return confirm('确定要删除吗？')">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
    
    </ContentTemplate>
    <Triggers >
    <asp:PostBackTrigger ControlID ="btnOk" />
    </Triggers>
    </asp:UpdatePanel>
    
</asp:Content>

