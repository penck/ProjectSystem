<%@ Page Title="" Language="VB" MasterPageFile="~/ManageSys/Apply/Xmsb/XmsbPage.master" AutoEventWireup="false" CodeFile="Expect.aspx.vb" Inherits="ManageSys_ApplyUser_Expect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br/>
    <asp:UpdatePanel ID="upExpectPage" runat="server">
    <ContentTemplate >
    <table bgcolor="CFE6F6" border="0" cellpadding="5" cellspacing="1" width="92%" align="center">
        <tr>
            <td bgcolor="E2F1FC">项目名称：</td>
            <td style="background-color: White;" colspan="2">
                <asp:Label ID="lblPrBaName" runat="server" Text="lblPrBaName"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="E2F1FC">主持人：</td>
            <td style="background-color: White;" colspan="2">
                <asp:Label ID="lblPrBaHostName" runat="server" Text="lblPrBaHostName"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="E2F1FC">归口管理部门：</td>
            <td style="background-color: White;" colspan="2">
                <asp:Label ID="lblReUnName" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="E2F1FC">完成时间</td>
            <td style="background-color: White;" colspan="2">
                <asp:TextBox ID="txtPrExWcsj" runat="server" Width ="160px" onfocus=" WdatePicker()"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3" bgcolor="E2F1FC">
                主要研究内容<font color="red">（请不要超过200汉字）</font>
            </td>
        </tr>
        <tr>
            <td style="background-color: White;" colspan="3">
                <asp:TextBox ID="txtPrExZyyjnr" runat="server" TextMode="MultiLine" style="height: 150px; width: 98%;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3" bgcolor="E2F1FC">
                预期目标<font color="red">（请不要超过100汉字）</font>
            </td>
        </tr>
        <tr>
            <td style="background-color: White;" colspan="3">
                <asp:TextBox ID="txtPrExYqmb" runat="server" TextMode="MultiLine" style="height: 100px; width: 98%;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td rowspan="3" style="width: 20%;" bgcolor="E2F1FC">
                项目经费账号信息
            </td>
            <td style="width: 20%; background-color: White;">
                单位帐户全称：
            </td>
            <td style="background-color: White;">
                <asp:TextBox ID="txtPrExDwzhqc" runat="server" style="width: 90%;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 20%; background-color: White;">
                开户行全称：
            </td>
            <td style="background-color: White;">
                <asp:TextBox ID="txtPrExKhhqc" runat="server" style="width: 90%;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 20%; background-color: White;">
                开户行帐号：
            </td>
            <td style="background-color: White;">
                <asp:TextBox ID="txtPrExKhhzh" runat="server" style="width: 90%;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="background-color: White;" align="center">
                <asp:Button ID="btnOk" runat="server" Text="" Width ="158px" Height ="42px"  style="border-width: 0px; background :url(../../../images/applyuser/button_save.gif)"/>
                <asp:Button ID ="btnCancel" runat="server" Text="" Width ="158px" Height ="42px" OnClientClick ="if(confirm('确认关闭窗口吗？')){window.close();}" style="border-width: 0px; background :url(../../../images/applyuser/button_close.gif)"/>
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

