<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Logout.aspx.vb" Inherits="ManageSys_Recommend_Logout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>退出系统</title>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type">
    <meta name="GENERATOR" content="MSHTML 9.00.8112.16446">
</head>
<body leftMargin="0" topMargin="0" bgColor="#ffffff">
    <table border="0" cellSpacing="0" cellPadding="0" width="100%" height="100%">
          <tr>
            <form name="loading">
            <td align="center">
              <p><font color="gray"></font>&nbsp;</p>
              <p>        &nbsp;</p>
              <P>        &nbsp;</p>
              <p>        &nbsp;</p>
              <p>        &nbsp;</p>
              <p>        &nbsp;</p>
              <p><font color="gray">正在退出系统......</font></p>
              <p><input style="padding: 0px; color: gray; font-family: Arial; font-weight: bolder; background-color: white;" name="chart" size="46" type="text"/><br/>
              <input style="text-align: center; color: gray; font-family: Arial;" name="percent" size="46" type="text"/>
            <script type ="text/javascript">
                var bar = 0;
                var line = "||";
                var amount = "||";
            count();
            function count() {
                bar = bar + 2;
                amount = amount + line;
                document.loading.chart.value = amount;
                document.loading.percent.value = bar + "%";
                if (bar < 99)
                { setTimeout("count()", 40); }
                else
                { window.top.location = "../../index.aspx"; }
            }
        </script>
      </p></td>
      </form>
      </tr></table>
</body>
</html>
