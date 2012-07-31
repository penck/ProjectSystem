<%@ Page Title="" Language="VB" MasterPageFile="~/ManageSys/Apply/ApplyUser.master" AutoEventWireup="false" CodeFile="Xmsb.aspx.vb" Inherits="ApplyUser_Xmsb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="upXmsbPage" runat="server">
    <ContentTemplate >
    <div style =" float :right ; width :760px;height :530px;" > 
        <div style="font-size: small">
            <table bgcolor="#D2E2F0" border="0" cellpadding="6" cellspacing="1" width="100%">
                <tbody><tr>
                    <td bgcolor="F2F9FE" width="85%">
                        <span id="titl">申报项目列表(添加新项目后须刷新本页面)</span>
                    </td>
                    <td width="15%">
                        <asp:LinkButton ID="lbtnAddNewProject" runat="server" Width ="196px" Height ="36px" style=" border-width:0px; background :url(../../images/applyuser/tjxxm.jpg);"></asp:LinkButton>
                    </td>
                </tr>
            </tbody></table>
            <div>
                <asp:GridView ID="gvProject" runat="server" 
                    BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" 
                    EmptyDataText="没有任何数据可以显示" GridLines="None" Width="100%" 
                    AllowPaging="True" AutoGenerateColumns="False" 
                    DataKeyNames="PrId" ForeColor="#333333" Font-Size="15px">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundField DataField="PrId" HeaderText="ID" />
                        <asp:TemplateField HeaderText="编号">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text="<%# Container.DataItemIndex + 1%>" ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PrName" HeaderText="项目名称" />
                        <asp:BoundField DataField="PrStatus" HeaderText="状态" />
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate >
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName ="updateProject" CommandArgument="<%# CType(Container, GridViewRow).RowIndex %>" >修改</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName ="deleteProject" CommandArgument="<%# CType(Container, GridViewRow).RowIndex %>"  OnClientClick ="return confirm('确定要删除吗？')">删除</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" Font-Size="15px" 
                        Font-Underline="False" />
                </asp:GridView> 
            </div>
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

