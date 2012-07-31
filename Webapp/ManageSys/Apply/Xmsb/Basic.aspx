<%@ Page Title="" Language="VB" MasterPageFile="~/ManageSys/Apply/Xmsb/XmsbPage.master" AutoEventWireup="false" CodeFile="Basic.aspx.vb" Inherits="ManageSys_ApplyUser_Basic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="upBasicPage" runat="server" UpdateMode ="Conditional" >
<ContentTemplate >
<table bgcolor="CFE6F6" border="0" cellpadding="5" cellspacing="1" width="98%" align="center">
    <tr>
       <td colspan="8" style="font-size: 14px;" align="center">
            <span style="color: red">项目申报基本信息表(申报初期不用上传项目申请书和项目计划书,等预审通过了方可)</span>
       </td>
   </tr>
    <tr>
       <td colspan="2" bgcolor="E2F1FC">项目类型</td>
       <td colspan="2" style="background-color: White;">
           <asp:DropDownList ID="dpPrBaClass" runat="server" Width="160px">
           </asp:DropDownList>
       </td>
       <td colspan="1" bgcolor="E2F1FC">所属批次</td>
       <td colspan="3" style="background-color: White;">
           <asp:TextBox ID="txtPrBaYear" runat="server" Width="160px"></asp:TextBox>
       </td>
    </tr>
    <tr>
        <td colspan="2" bgcolor="E2F1FC">项目名称</td>
        <td colspan="6" style="background-color: White;">
            <asp:TextBox ID="txtPrBaName" runat="server" Width ="80%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" bgcolor="E2F1FC">申报日期</td>
        <td colspan="2" style="background-color: White;">
            <asp:TextBox ID="txtPrBaApplyTime" runat="server" Width="160px" onfocus=" WdatePicker()"></asp:TextBox>
        </td>
        <td colspan="1" bgcolor="E2F1FC">所在区，县</td>
        <td colspan="3" style="background-color: White;">
            <asp:DropDownList ID="dpPrBaArea" runat="server" Width="160px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td colspan="2" bgcolor="E2F1FC">推荐单位</td>
        <td colspan="7" style="background-color: White;">
            <asp:DropDownList ID="dpReUnClass" AutoPostBack ="true"  runat="server" Width ="160px">
            </asp:DropDownList>
            <asp:DropDownList ID="dpReUnName" runat="server" Width ="160px" >
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td colspan="2" bgcolor="E2F1FC">承担单位</td>
        <td colspan="2" style="background-color: White;">
            <asp:TextBox ID="txtPrBaHostUnit" runat="server" Width ="160px"></asp:TextBox>
        </td>
        <td colspan="1" bgcolor="E2F1FC">单位性质</td>
        <td colspan="3" style="background-color: White;">
            <asp:DropDownList ID="dpPrBaHostUnitClass" runat="server" Width ="160px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td colspan="2" bgcolor="E2F1FC">合作单位</td>
        <td colspan="2" style="background-color: White;">
            <asp:TextBox ID="txtPrBaCooperationUnit" runat="server"  Width ="160px"></asp:TextBox> 
        </td>
        <td bgcolor="E2F1FC"> 单位性质</td>
        <td colspan="3" style="background-color: White;">
            <asp:DropDownList ID="dpPrBaCooperationUnitClass" runat="server" Width ="160px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td colspan="2" bgcolor="E2F1FC">产学研合作</td>
        <td colspan="2" style="background-color: White;">
            <asp:DropDownList ID="dpPrBaIsCxyhz" runat="server" Width ="160px">
            </asp:DropDownList>
        </td>
        <td bgcolor="E2F1FC">合作形式</td>
        <td colspan="3" style="background-color: White;">
            <asp:DropDownList ID="dpPrBaHzxs" runat="server" Width ="160px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td rowspan="4" style="vertical-align: middle;" bgcolor="E2F1FC">
            <div style="vertical-align: middle" align="center">
                项<br/>目<br/>主<br/>持<br/>人</div>
        </td>
        <td style="background-color: White;">姓名</td>
        <td colspan="2" style="background-color: White;">
            <asp:TextBox ID="txtPrBaHostName" runat="server" Width ="160px"></asp:TextBox>
        </td>
        <td bgcolor="E2F1FC">性别</td>
        <td colspan="3" style="background-color: White;">
            <asp:DropDownList ID="dpPrBaHostSex" runat="server" Width ="120px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="background-color: White;">学历</td>
        <td colspan="2" style="background-color: White;">
            <asp:DropDownList ID="dpPrBaHostEducation" runat="server" Width ="120px">
            </asp:DropDownList>
        </td>
        <td bgcolor="E2F1FC">出生年月</td>
        <td colspan="3" style="background-color: White;">
            <asp:TextBox ID="txtPrBaHostBirth" runat="server"  Width ="160px" onfocus=" WdatePicker()"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="background-color: White;">职称</td>
        <td colspan="2" style="background-color: White;">
            <asp:DropDownList ID="dpPrBaHostPosition" runat="server" Width ="120px">
            </asp:DropDownList>
        </td>
        <td bgcolor="E2F1FC">联系电话</td>
        <td colspan="3" style="background-color: White;">
            <asp:TextBox ID="txtPrBaHostWorkPhone" runat="server" Width ="160px"></asp:TextBox><br/>
            <font color="red">（如：0551-1234567）</font>
        </td>
   </tr>
    <tr>
        <td style="background-color: White;">手机</td>
        <td colspan="2" style="background-color: White;">
            <asp:TextBox ID="txtPrBaHostMobilePhone" runat="server" Width ="160px"></asp:TextBox>
        </td>
        <td bgcolor="E2F1FC">Email</td>
        <td colspan="3" style="background-color: White;">
            <asp:TextBox ID="txtPrBaHostEmail" runat="server" Width ="160px"></asp:TextBox><br/>
            <font color="red">（如：123@163.com）</font>
        </td>
    </tr>
    <tr>
        <td rowspan="3" bgcolor="E2F1FC">
            <div style="vertical-align: middle" align="center">
                项<br/>目<br/>组<br/>人<br/>数
            </div>
        </td>
        <td style="background-color: White;">总人数</td>
        <td colspan="6" style="background-color: White;">
            <asp:TextBox ID="txtPrBaAllPeopleNumber" runat="server" Width ="120px" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="background-color: White;">高级职称</td>
        <td colspan="2" style="background-color: White;">
            <asp:TextBox ID="txtPrBaGjzcNumber" runat="server" Width ="120px" ></asp:TextBox>
        </td>
        <td bgcolor="E2F1FC">中级职称</td>
        <td colspan="3" style="background-color: White;">
            <asp:TextBox ID="txtPrBaZjzcNumber" runat="server" Width ="120px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="background-color: White;">初级职称</td>
        <td colspan="2" style="background-color: White;">
            <asp:TextBox ID="txtPrBaCjzcNumber" runat="server" Width ="120px"></asp:TextBox>
        </td>
        <td bgcolor="E2F1FC"> 其他</td>
        <td colspan="3" style="background-color: White;">
            <asp:TextBox ID="txtPrBaOtherNumber" runat="server" Width ="120px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td rowspan="4" bgcolor="E2F1FC">
            研发总投入<br/>
            （万元）
        </td>
        <td style="background-color: White;">合计</td>
        <td colspan="6" style="background-color: White;">
            <asp:TextBox ID="txtPrBaYfztr" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="background-color: White;" rowspan="3">其中</td>
        <td style="background-color: White;" colspan="2">申请市财政拨款</td>
        <td style="background-color: White;" colspan="4">
            <asp:TextBox ID="txtPrBaSczbk" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="background-color: White;" colspan="2">
            区县财政拨款
        </td>
        <td style="background-color: White;" colspan="4">
            <asp:TextBox ID="txtPrBaQxczbk" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="background-color: White;" colspan="2">
            单位自筹
        </td>
        <td style="background-color: White;" colspan="4">
            <asp:TextBox ID="txtPrBaDwzc" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td rowspan="9" style="vertical-align: middle;" bgcolor="E2F1FC">
            <div style="vertical-align: middle" align="center">
                预<br/>
                期<br/>
                效<br/>
                应</div>
        </td>
        <td rowspan="5" style="background-color: White;">
            研发成果形式
        </td>
        <td bgcolor="E2F1FC">
            开发新产品
        </td>
        <td colspan="2" style="background-color: White;">
            <asp:TextBox ID="txtPrBaKfxcp" runat="server"></asp:TextBox>
        </td>
        <td bgcolor="E2F1FC">
            开发新工艺
        </td>
        <td colspan="2" style="background-color: White;">
            <asp:TextBox ID="txtPrBaKfxgy" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td bgcolor="E2F1FC">
            开发新装备
        </td>
        <td colspan="2" style="background-color: White;">
            <asp:TextBox ID="txtPrBaKfxzb" runat="server"></asp:TextBox>
        </td>
        <td bgcolor="E2F1FC">
            软件知识产权
        </td>
        <td colspan="2" style="background-color: White;">
            <asp:TextBox ID="txtPrBaRjzscq" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td bgcolor="E2F1FC">
            取得专利(项)
        </td>
        <td colspan="2" style="background-color: White;">
            <asp:TextBox ID="txtPrBaQdzlx" runat="server"></asp:TextBox>
        </td>
        <td colspan="1" bgcolor="E2F1FC">
            其中发明专利(项)：
        </td>
        <td colspan="2" style="background-color: White;">
            <asp:TextBox ID="txtPrBaQzfmzlx" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td bgcolor="E2F1FC">
            技术标准
        </td>
        <td colspan="2" style="background-color: White;">
            <asp:TextBox ID="txtPrBaJsbz" runat="server"></asp:TextBox>
        </td>
        <td bgcolor="E2F1FC">
            动植物新品种
        </td>
        <td colspan="2" style="background-color: White;">
            <asp:TextBox ID="txtPrBaDzwxpz" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td bgcolor="E2F1FC">
            其他
        </td>
        <td colspan="5" style="background-color: White;">
            <asp:TextBox ID="txtPrBaYfOther" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td rowspan="4" style="background-color: White;">
            产业成果
        </td>
        <td bgcolor="E2F1FC">
            新增企业（家）
        </td>
        <td colspan="2" style="background-color: White;">
            <asp:TextBox ID="txtPrBaXzqy" runat="server"></asp:TextBox>
        </td>
        <td bgcolor="E2F1FC">
            形成生产能力
        </td>
        <td style="background-color: White;" colspan="2">
            <asp:TextBox ID="txtPrBaXcscnl" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td bgcolor="E2F1FC">
            拉动产业投资（万元）
        </td>
        <td colspan="2" style="background-color: White;">
            <asp:TextBox ID="txtPrBaLdcytz" runat="server"></asp:TextBox>
        </td>
        <td bgcolor="E2F1FC">
            新增销售收入（万元）
        </td>
        <td colspan="2" style="background-color: White;">
            <asp:TextBox ID="txtPrBaXzxssr" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td bgcolor="E2F1FC">
            新增利税（万元）
        </td>
        <td colspan="2" style="background-color: White;">
            <asp:TextBox ID="txtPrBaXzls" runat="server"></asp:TextBox>
        </td>
        <td bgcolor="E2F1FC">
            创汇（万美元）
        </td>
        <td colspan="2" style="background-color: White;">
            <asp:TextBox ID="txtPrBaCh" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td bgcolor="E2F1FC">
            引进团体（个）
        </td>
        <td colspan="2" style="background-color: White;">
            <asp:TextBox ID="txtPrBaYjtt" runat="server"></asp:TextBox>
        </td>
        <td bgcolor="E2F1FC">
            引进人才（人）
        </td>
        <td colspan="2" style="background-color: White;">
            <asp:TextBox ID="txtPrBaYjrc" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="8" style="background-color: White;" align="center">
            <asp:Button ID="btnOk" runat="server" Text="" Width ="158px" Height ="42px"  style="border-width: 0px; background :url(../../../images/applyuser/button_save.gif)"/>
            <asp:Button ID ="btnCancel" runat="server" Text="" Width ="158px" Height ="42px" OnClientClick ="if(confirm('确认关闭窗口吗？')){window.close();}" style="border-width: 0px; background :url(../../../images/applyuser/button_close.gif)"/>
        </td>
    </tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

