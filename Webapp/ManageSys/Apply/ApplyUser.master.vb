Imports SysOpProvider

Partial Class ApplyUser_ApplyUser
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("UsName") Is Nothing AndAlso Session("UsName") <> "" Then
            lblUsName.Text = Session("UsName")
        End If
    End Sub

    Protected Sub lbtnXmsb_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnXmsb.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(upPage, Me.GetType, "click", "javascript:window.location='Xmsb.aspx';", True)
    End Sub

    Protected Sub lbtnXmlx_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnXmlx.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(upPage, Me.GetType, "click", "javascript:window.location='Xmlx.aspx';", True)
    End Sub

    Protected Sub lbtnZqjc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnZqjc.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(upPage, Me.GetType, "click", "javascript:window.location='Zqjc.aspx';", True)
    End Sub

    Protected Sub lbtnJtbg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnJtbg.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(upPage, Me.GetType, "click", "javascript:window.location='Jtbg.aspx';", True)
    End Sub

    Protected Sub lbtnXmzj_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnXmzj.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(upPage, Me.GetType, "click", "javascript:window.location='Xmzj.aspx';", True)
    End Sub

    Protected Sub lbtnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnExit.Click
        Session.Remove("UsName")
        Cache.Remove("UsName")
        LogsOper.ShowInfotoWeb("成功退出登录！", upPage)
        System.Web.UI.ScriptManager.RegisterStartupScript(upPage, Me.GetType, "click", "javascript:window.location='../../index.aspx';", True)
    End Sub
End Class

