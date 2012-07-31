<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Frame.aspx.vb" Inherits="ManageSys_Recommend_Frame" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>黄山市科技项目计划管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link rel="stylesheet" href="../../css/main.css" type="text/css" />
    <link media="all" href="../../css/TryStyles.css" type="text/css" rel="stylesheet" />

    <script language="JavaScript" type="text/JavaScript">
            function toggle(targetid) {
                if (document.getElementById) {
                    target = document.getElementById(targetid);
                    if (target.style.display == "block") {
                        target.style.display = "none";
                    } else {
                        target.style.display = "block";
                    }
                }
            }
            function toggle_graph(mainid, targetid) {
                if (document.getElementById) {
                    target = document.getElementById(targetid);
                    main = document.getElementById(mainid);
                    if (target.style.display == "block") {
                        target.style.display = "none";
                        main.style.display = "block";
                    } else {
                        target.style.display = "block";
                        main.style.display = "none";
                    }
                }
            }
            function datetime() {
                var enabled = 0; today = new Date();
                var day; var date;
                if (today.getDay() == 0) day = "星期日"
                if (today.getDay() == 1) day = "星期一"
                if (today.getDay() == 2) day = "星期二"
                if (today.getDay() == 3) day = "星期三"
                if (today.getDay() == 4) day = "星期四"
                if (today.getDay() == 5) day = "星期五"
                if (today.getDay() == 6) day = "星期六"
                date = (today.getYear()) + "年" + (today.getMonth() + 1) + "月" + today.getDate() + "日 " + day + "";
                document.write(date);
            }
    </script>

    <script language="javascript" type="text/javascript">
        //TreeView onclick 触发事件 
        function client_OnTreeNodeChecked(event) {

            //得到当前所 Click 的对象 
            var objNode;

            if (!public_IsObjectNull(event.srcElement)) {
                //IE 
                objNode = event.srcElement;
            }
            else {
                //FF 
                objNode = event.target;
            }

            //判断是否 Click 的 CheckBox 
            if (!public_IsCheckBox(objNode))
                return;

            var objCheckBox = objNode;
            //根据CheckBox状态进行相应处理 
            if (objCheckBox.checked == true) {
                //递归选中父节点的 CheckBox 
                setParentChecked(objCheckBox);

                //递归选中所有的子节点 
                setChildChecked(objCheckBox);
            }
            else {
                //递归取消选中所有的子节点 
                setChildUnChecked(objCheckBox);

                //递归取消选中父节点(如果当前节点的所有其他同级节点也都未被选中). 
                setParentUnChecked(objCheckBox);
            }
        }

        //判断对象是否为空 
        function public_IsObjectNull(element) {
            if (element == null || element == "undefined")
                return true;
            else
                return false;
        }

        //判断对象是否为 CheckBox 
        function public_IsCheckBox(element) {
            if (public_IsObjectNull(element))
                return false;

            if (element.tagName != "INPUT" || element.type != "checkbox")
                return false;
            else
                return true;
        }
        //得到包含所有子节点的 Node(Div 对象) 
        function public_CheckBox2Node(element) {
            var objID = element.getAttribute("ID");
            objID = objID.substring(0, objID.indexOf("CheckBox"));
            return document.getElementById(objID + "Nodes");
        }
        //得到父节点的 CheckBox 
        function public_Node2CheckBox(element) {
            var objID = element.getAttribute("ID");
            objID = objID.substring(0, objID.indexOf("Nodes"));
            return document.getElementById(objID + "CheckBox");
        }
        //得到本节点所在的 Node(Div 对象) 
        function public_GetParentNode(element) {
            var parent = element.parentNode;
            var upperTagName = "DIV";
            //如果这个元素还不是想要的 tag 就继续上溯 
            while (parent && (parent.tagName.toUpperCase() != upperTagName)) {
                parent = parent.parentNode ? parent.parentNode : parent.parentElement;
            }
            return parent;
        }


        //设置节点的父节点 Checked 
        function setParentChecked(currCheckBox) {
            var objParentNode = public_GetParentNode(currCheckBox);
            if (public_IsObjectNull(objParentNode))
                return;

            var objParentCheckBox = public_Node2CheckBox(objParentNode);

            if (!public_IsCheckBox(objParentCheckBox))
                return;

            objParentCheckBox.checked = true;
            setParentChecked(objParentCheckBox);
        }

        //当父节点的所有子节点都未被选中时,设置父节点 UnChecked 
        function setParentUnChecked(currCheckBox) {
            var objParentNode = public_GetParentNode(currCheckBox);
            if (public_IsObjectNull(objParentNode))
                return;
            //判断 currCheckBox 的同级节点是否都为 UnChecked. 
            if (!IsMyChildCheckBoxsUnChecked(objParentNode))
                return;

            var objParentCheckBox = public_Node2CheckBox(objParentNode);

            if (!public_IsCheckBox(objParentCheckBox))
                return;

            objParentCheckBox.checked = false;
            setParentUnChecked(objParentCheckBox);
        }

        //设置节点的子节点 UnChecked 
        function setChildUnChecked(currObj) {
            var currNode;
            if (public_IsCheckBox(currObj)) {
                currNode = public_CheckBox2Node(currObj);
                if (public_IsObjectNull(currNode))
                    return;
            }
            else
                currNode = currObj;

            var currNodeChilds = currNode.childNodes;
            var count = currNodeChilds.length;
            for (var i = 0; i < count; i++) {
                var childCheckBox = currNodeChilds[i];
                if (public_IsCheckBox(childCheckBox)) {
                    childCheckBox.checked = false;
                }
                setChildUnChecked(childCheckBox);
            }
        }

        //设置节点的子节点 Checked 
        function setChildChecked(currObj) {
            var currNode;
            if (public_IsCheckBox(currObj)) {
                currNode = public_CheckBox2Node(currObj);
                if (public_IsObjectNull(currNode))
                    return;
            }
            else
                currNode = currObj;

            var currNodeChilds = currNode.childNodes;
            var count = currNodeChilds.length;
            for (var i = 0; i < count; i++) {
                var childCheckBox = currNodeChilds[i];
                if (public_IsCheckBox(childCheckBox)) {
                    childCheckBox.checked = true;
                }
                setChildChecked(childCheckBox);
            }
        }

        //判断该节点的子节点是否都为 UnChecked 
        function IsMyChildCheckBoxsUnChecked(currObj) {
            var retVal = true;

            var currNode;
            if (public_IsCheckBox(currObj) && currObj.checked == true) {
                return false;
            }
            else
                currNode = currObj;

            var currNodeChilds = currNode.childNodes;
            var count = currNodeChilds.length;
            for (var i = 0; i < count; i++) {
                if (retVal == false)
                    break;
                var childCheckBox = currNodeChilds[i];
                if (public_IsCheckBox(childCheckBox) && childCheckBox.checked == true) {
                    retVal = false;
                    return retVal;
                }
                else
                    retVal = IsMyChildCheckBoxsUnChecked(childCheckBox);
            }
            return retVal;
        }
        function datetime() {
            var enabled = 0; today = new Date();
            var day; var date;
            if (today.getDay() == 0) day = "星期日"
            if (today.getDay() == 1) day = "星期一"
            if (today.getDay() == 2) day = "星期二"
            if (today.getDay() == 3) day = "星期三"
            if (today.getDay() == 4) day = "星期四"
            if (today.getDay() == 5) day = "星期五"
            if (today.getDay() == 6) day = "星期六"
            date = (today.getYear()) + "年" + (today.getMonth() + 1) + "月" + today.getDate() + "日 " + day + "";
            document.write(date);
        }


        function dyniframesize(down) {

            var pTar = null;

            if (document.getElementById) {

                pTar = document.getElementById(down);

            }

            else {

                eval('pTar = ' + down + ';');

            }

            if (pTar && !window.opera) {

                //begin resizing iframe 

                pTar.style.display = "block"

                if (pTar.contentDocument && pTar.contentDocument.body.offsetHeight) {

                    //ns6 syntax 

                    pTar.height = pTar.contentDocument.body.offsetHeight + 20;

                    pTar.width = pTar.contentDocument.body.scrollWidth + 20;

                }

                else if (pTar.Document && pTar.Document.body.scrollHeight) {

                    //ie5+ syntax 

                    pTar.height = pTar.Document.body.scrollHeight;

                    pTar.width = pTar.Document.body.scrollWidth;

                }

            }

        } 
    </script>

    <script language="Javascript" type="text/javascript" src="../../js/FusionCharts.js"></script>
</head>

<body bgcolor="#FFFFFF" text="#000000" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
<form runat ="server" >
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel  ID="upPage"  runat="server" >
    <ContentTemplate>
    <table width="20%" border="0" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td valign="top" width="220" background="../../images/recommend/left_bg.gif">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="center">
                            <br />
                            <span style="font-size: medium; font-weight: bold; color: Red;">欢迎您</span>
                            <br />
                            <span style="font-size: small; font-weight: bold;">
                                <asp:Label ID="lblUserName" runat="server" Text="lblUserName"></asp:Label>
                            </span>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <a href="Tzgg.aspx" target="mainFrame">通知公告</a><b>||</b>
                            <a href="Xgmm.aspx" target="mainFrame">修改密码</a>
                        </td>
                    </tr>
                </table>
                <table width="196" border="0" cellspacing="0" cellpadding="0" align="center">
                    <tr>
                        <td height="40" valign="top">
                                <img alt="" src="../../images/recommend/manage_b02.gif" width="196" height="36" border="0" onclick="toggle('Table6')"/>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center" class="links_14" id="Table6" style="display: none">
                                <tr>
                                    <td>
                                        <img alt="" src="../../images/recommend/manage_left02.gif" width="196" height="1"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td background="../../images/recommend/manage_left_bg2.gif" height="27" class="main_14" <%--onclick="toggle('tb2')"--%>>
                                        <img alt="" src="../../images/recommend/2.gif" height="22" align="absmiddle"/>
                                        <a href="Sbxmgl.aspx" target="mainFrame">申报项目管理</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td background="../../images/recommend/manage_left_bg2.gif" height="27" class="main_14" <%--onclick="toggle('tb3')"--%>>
                                        <img alt="" src="../../images/recommend/2.gif" height="22" align="absmiddle"/>
                                        <a href="Lxxmgl.aspx" target="mainFrame">立项项目管理</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td background="../../images/recommend/manage_left_bg2.gif" height="27" class="main_14" onclick="toggle('Table1')">
                                        <img alt="" src="../../images/recommend/1.gif" height="22" align="absmiddle"/>
                                        中期管理
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellspacing="3" cellpadding="0" align="center" class="blue14"
                                            id="Table1" style="display: none">
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;&nbsp;<img alt="" src="../../images/recommend/1.gif" height="20" align="absmiddle"/>
                                                    <a href="#" onclick="toggle_graph('Table55','Table44')">执行情况</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="80%" border="0" cellspacing="3" cellpadding="0" align="center" class="blue14"
                                                        id="Table44" style="display: none">
                                                        <tr>
                                                            <td>
                                                                <img src="../../images/recommend/list01.gif" height="20" align="absmiddle"/>
                                                                <a href="zqjc.aspx" target="mainFrame">科技计划项目</a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <img src="../../images/recommend/list01.gif" height="20" align="absmiddle"/>
                                                                <a href="zxqk_ndzd.aspx" target="mainFrame">年度重点科研项目</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;&nbsp;<img src="../../images/recommend/1.gif" height="20" align="absmiddle">
                                                    <a href="#" onclick="toggle_graph('Table44','Table55')">绩效考核</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="80%" border="0" cellspacing="3" cellpadding="0" align="center" class="blue14"
                                                        id="Table55" style="display: none">
                                                        <tr>
                                                            <td>
                                                                &nbsp;&nbsp;&nbsp;<img src="../../images/recommend/list01.gif" height="20" align="absmiddle">
                                                                <a href="jxkh_gczx.aspx" target="mainFrame">工程技术研究中心</a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                &nbsp;&nbsp;&nbsp;<img src="../../images/recommend/list01.gif" height="20" align="absmiddle">
                                                                <a href="jxkh_jszy.aspx" target="mainFrame">技术转移机构</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td background="../../../images/recommend/recommend/manage_left_bg2.gif" height="27" class="main_14" onclick="toggle('Table4')">
                                        <img src="../../images/recommend/1.gif" height="22" align="absmiddle">
                                        结题管理
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="80%" border="0" cellspacing="3" cellpadding="0" align="center" class="blue14"
                                            id="Table4" style="display: none">
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;&nbsp;<img src="../../images/recommend/list01.gif" height="20" align="absmiddle">
                                                    <a href="jxkh_gczx.aspx" target="mainFrame">工程技术研究中心</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    &nbsp;&nbsp;&nbsp;<img src="../../images/recommend/list01.gif" height="20" align="absmiddle">
                                                    <a href="ys_ndzd.aspx?type=17" target="mainFrame">年度重点科研</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td background="../../images/recommend/manage_left_bg2.gif" height="27" class="main_14">
                            <img src="../../images/recommend/sd_b118.gif" width="196" height="36" border="0" onclick="toggle('Table2')">
                            <table width="80%" border="0" cellspacing="3" cellpadding="0" align="center" class="links_14" id="Table2" style="display: none">
                                <tr>
                                    <td>
                                        <img src="../../images/recommend/list01.gif" height="22" align="absmiddle">
                                        <a target="mainFrame" href="Founding.aspx">本单位统计</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../../images/recommend/list01.gif" height="22" align="absmiddle">
                                        <a target="mainFrame" href="Founding.aspx">领域统计</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../../images/recommend/list01.gif" height="22" align="absmiddle">
                                        <a target="mainFrame" href="Founding.aspx">项目类型</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../../images/recommend/list01.gif" height="22" align="absmiddle">
                                        <a target="mainFrame" href="Founding.aspx">产业类型</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../../images/recommend/list01.gif" height="22" align="absmiddle">
                                        <a target="mainFrame" href="Founding.aspx">重点项目</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td background="../../images/recommend/manage_left_bg2.gif" height="27" class="main_14">
                            <img src="../../images/recommend/sd_b117.gif" width="196" height="36" border="0" onclick="toggle('Table3')">
                            <table width="80%" border="0" cellspacing="3" cellpadding="0" align="center" class="links_14"
                                id="Table3" style="display: none">
                                <tr>
                                    <td>
                                        <img src="../../images/recommend/list01.gif" height="22" align="absmiddle">
                                        <a target="mainFrame" href="Founding.aspx">本单位统计</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../../images/recommend/list01.gif" height="22" align="absmiddle">
                                        <a target="mainFrame" href="Founding.aspx">领域统计</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../../images/recommend/list01.gif" height="22" align="absmiddle">
                                        <a target="mainFrame" href="Founding.aspx">计划类型</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../../images/recommend/list01.gif" height="22" align="absmiddle">
                                        <a target="mainFrame" href="Founding.aspx">产业类型</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../../images/recommend/list01.gif" height="22" align="absmiddle">
                                        <a target="mainFrame" href="Founding.aspx">重点项目</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="40" valign="top">
                            <a target="mainFrame" href="Logout.aspx">
                                <img alt ="" src="../../images/recommend/left_button_exit02.gif" width="196" height="36" border="0"></a>
                        </td>
                    </tr>
                </table>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</form>
</body>
</html>


