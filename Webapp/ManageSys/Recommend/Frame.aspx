<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Frame.aspx.vb" Inherits="ManageSys_Recommend_Frame" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>��ɽ�пƼ���Ŀ�ƻ�����ϵͳ</title>
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
                if (today.getDay() == 0) day = "������"
                if (today.getDay() == 1) day = "����һ"
                if (today.getDay() == 2) day = "���ڶ�"
                if (today.getDay() == 3) day = "������"
                if (today.getDay() == 4) day = "������"
                if (today.getDay() == 5) day = "������"
                if (today.getDay() == 6) day = "������"
                date = (today.getYear()) + "��" + (today.getMonth() + 1) + "��" + today.getDate() + "�� " + day + "";
                document.write(date);
            }
    </script>

    <script language="javascript" type="text/javascript">
        //TreeView onclick �����¼� 
        function client_OnTreeNodeChecked(event) {

            //�õ���ǰ�� Click �Ķ��� 
            var objNode;

            if (!public_IsObjectNull(event.srcElement)) {
                //IE 
                objNode = event.srcElement;
            }
            else {
                //FF 
                objNode = event.target;
            }

            //�ж��Ƿ� Click �� CheckBox 
            if (!public_IsCheckBox(objNode))
                return;

            var objCheckBox = objNode;
            //����CheckBox״̬������Ӧ���� 
            if (objCheckBox.checked == true) {
                //�ݹ�ѡ�и��ڵ�� CheckBox 
                setParentChecked(objCheckBox);

                //�ݹ�ѡ�����е��ӽڵ� 
                setChildChecked(objCheckBox);
            }
            else {
                //�ݹ�ȡ��ѡ�����е��ӽڵ� 
                setChildUnChecked(objCheckBox);

                //�ݹ�ȡ��ѡ�и��ڵ�(�����ǰ�ڵ����������ͬ���ڵ�Ҳ��δ��ѡ��). 
                setParentUnChecked(objCheckBox);
            }
        }

        //�ж϶����Ƿ�Ϊ�� 
        function public_IsObjectNull(element) {
            if (element == null || element == "undefined")
                return true;
            else
                return false;
        }

        //�ж϶����Ƿ�Ϊ CheckBox 
        function public_IsCheckBox(element) {
            if (public_IsObjectNull(element))
                return false;

            if (element.tagName != "INPUT" || element.type != "checkbox")
                return false;
            else
                return true;
        }
        //�õ����������ӽڵ�� Node(Div ����) 
        function public_CheckBox2Node(element) {
            var objID = element.getAttribute("ID");
            objID = objID.substring(0, objID.indexOf("CheckBox"));
            return document.getElementById(objID + "Nodes");
        }
        //�õ����ڵ�� CheckBox 
        function public_Node2CheckBox(element) {
            var objID = element.getAttribute("ID");
            objID = objID.substring(0, objID.indexOf("Nodes"));
            return document.getElementById(objID + "CheckBox");
        }
        //�õ����ڵ����ڵ� Node(Div ����) 
        function public_GetParentNode(element) {
            var parent = element.parentNode;
            var upperTagName = "DIV";
            //������Ԫ�ػ�������Ҫ�� tag �ͼ������� 
            while (parent && (parent.tagName.toUpperCase() != upperTagName)) {
                parent = parent.parentNode ? parent.parentNode : parent.parentElement;
            }
            return parent;
        }


        //���ýڵ�ĸ��ڵ� Checked 
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

        //�����ڵ�������ӽڵ㶼δ��ѡ��ʱ,���ø��ڵ� UnChecked 
        function setParentUnChecked(currCheckBox) {
            var objParentNode = public_GetParentNode(currCheckBox);
            if (public_IsObjectNull(objParentNode))
                return;
            //�ж� currCheckBox ��ͬ���ڵ��Ƿ�Ϊ UnChecked. 
            if (!IsMyChildCheckBoxsUnChecked(objParentNode))
                return;

            var objParentCheckBox = public_Node2CheckBox(objParentNode);

            if (!public_IsCheckBox(objParentCheckBox))
                return;

            objParentCheckBox.checked = false;
            setParentUnChecked(objParentCheckBox);
        }

        //���ýڵ���ӽڵ� UnChecked 
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

        //���ýڵ���ӽڵ� Checked 
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

        //�жϸýڵ���ӽڵ��Ƿ�Ϊ UnChecked 
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
            if (today.getDay() == 0) day = "������"
            if (today.getDay() == 1) day = "����һ"
            if (today.getDay() == 2) day = "���ڶ�"
            if (today.getDay() == 3) day = "������"
            if (today.getDay() == 4) day = "������"
            if (today.getDay() == 5) day = "������"
            if (today.getDay() == 6) day = "������"
            date = (today.getYear()) + "��" + (today.getMonth() + 1) + "��" + today.getDate() + "�� " + day + "";
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
                            <span style="font-size: medium; font-weight: bold; color: Red;">��ӭ��</span>
                            <br />
                            <span style="font-size: small; font-weight: bold;">
                                <asp:Label ID="lblUserName" runat="server" Text="lblUserName"></asp:Label>
                            </span>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <a href="Tzgg.aspx" target="mainFrame">֪ͨ����</a><b>||</b>
                            <a href="Xgmm.aspx" target="mainFrame">�޸�����</a>
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
                                        <a href="Sbxmgl.aspx" target="mainFrame">�걨��Ŀ����</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td background="../../images/recommend/manage_left_bg2.gif" height="27" class="main_14" <%--onclick="toggle('tb3')"--%>>
                                        <img alt="" src="../../images/recommend/2.gif" height="22" align="absmiddle"/>
                                        <a href="Lxxmgl.aspx" target="mainFrame">������Ŀ����</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td background="../../images/recommend/manage_left_bg2.gif" height="27" class="main_14" onclick="toggle('Table1')">
                                        <img alt="" src="../../images/recommend/1.gif" height="22" align="absmiddle"/>
                                        ���ڹ���
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellspacing="3" cellpadding="0" align="center" class="blue14"
                                            id="Table1" style="display: none">
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;&nbsp;<img alt="" src="../../images/recommend/1.gif" height="20" align="absmiddle"/>
                                                    <a href="#" onclick="toggle_graph('Table55','Table44')">ִ�����</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="80%" border="0" cellspacing="3" cellpadding="0" align="center" class="blue14"
                                                        id="Table44" style="display: none">
                                                        <tr>
                                                            <td>
                                                                <img src="../../images/recommend/list01.gif" height="20" align="absmiddle"/>
                                                                <a href="zqjc.aspx" target="mainFrame">�Ƽ��ƻ���Ŀ</a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <img src="../../images/recommend/list01.gif" height="20" align="absmiddle"/>
                                                                <a href="zxqk_ndzd.aspx" target="mainFrame">����ص������Ŀ</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;&nbsp;<img src="../../images/recommend/1.gif" height="20" align="absmiddle">
                                                    <a href="#" onclick="toggle_graph('Table44','Table55')">��Ч����</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="80%" border="0" cellspacing="3" cellpadding="0" align="center" class="blue14"
                                                        id="Table55" style="display: none">
                                                        <tr>
                                                            <td>
                                                                &nbsp;&nbsp;&nbsp;<img src="../../images/recommend/list01.gif" height="20" align="absmiddle">
                                                                <a href="jxkh_gczx.aspx" target="mainFrame">���̼����о�����</a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                &nbsp;&nbsp;&nbsp;<img src="../../images/recommend/list01.gif" height="20" align="absmiddle">
                                                                <a href="jxkh_jszy.aspx" target="mainFrame">����ת�ƻ���</a>
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
                                        �������
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="80%" border="0" cellspacing="3" cellpadding="0" align="center" class="blue14"
                                            id="Table4" style="display: none">
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;&nbsp;<img src="../../images/recommend/list01.gif" height="20" align="absmiddle">
                                                    <a href="jxkh_gczx.aspx" target="mainFrame">���̼����о�����</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    &nbsp;&nbsp;&nbsp;<img src="../../images/recommend/list01.gif" height="20" align="absmiddle">
                                                    <a href="ys_ndzd.aspx?type=17" target="mainFrame">����ص����</a>
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
                                        <a target="mainFrame" href="Founding.aspx">����λͳ��</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../../images/recommend/list01.gif" height="22" align="absmiddle">
                                        <a target="mainFrame" href="Founding.aspx">����ͳ��</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../../images/recommend/list01.gif" height="22" align="absmiddle">
                                        <a target="mainFrame" href="Founding.aspx">��Ŀ����</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../../images/recommend/list01.gif" height="22" align="absmiddle">
                                        <a target="mainFrame" href="Founding.aspx">��ҵ����</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../../images/recommend/list01.gif" height="22" align="absmiddle">
                                        <a target="mainFrame" href="Founding.aspx">�ص���Ŀ</a>
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
                                        <a target="mainFrame" href="Founding.aspx">����λͳ��</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../../images/recommend/list01.gif" height="22" align="absmiddle">
                                        <a target="mainFrame" href="Founding.aspx">����ͳ��</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../../images/recommend/list01.gif" height="22" align="absmiddle">
                                        <a target="mainFrame" href="Founding.aspx">�ƻ�����</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../../images/recommend/list01.gif" height="22" align="absmiddle">
                                        <a target="mainFrame" href="Founding.aspx">��ҵ����</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../../images/recommend/list01.gif" height="22" align="absmiddle">
                                        <a target="mainFrame" href="Founding.aspx">�ص���Ŀ</a>
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


