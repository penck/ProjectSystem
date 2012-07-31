Imports SysOpProvider
Imports ProjectData

Partial Class ManageSys_ApplyUser_XmsbPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("PrOperate") = "AddNewProject" Then
            lblPrStatus.Text = "未提交"
        End If
    End Sub

    Protected Sub lbtnBasic_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnBasic.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(upPage, Me.GetType, "click", "javascript:window.location='Basic.aspx';", True)
    End Sub

    Protected Sub lbtnExpect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnExpect.Click
        If Session("Basic") = True Then
            System.Web.UI.ScriptManager.RegisterStartupScript(upPage, Me.GetType, "click", "javascript:window.location='Expect.aspx';", True)
        ElseIf Session("Basic") = False Then
            LogsOper.ShowInfotoWeb("请先填写项目申报基本信息表并保存！", upPage)
            Exit Sub
        End If
    End Sub

    Protected Sub lbtnApplyBook_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnApplyBook.Click
        If Session("Basic") = True Then
            System.Web.UI.ScriptManager.RegisterStartupScript(upPage, Me.GetType, "click", "javascript:window.location='ApplyBook.aspx';", True)
        ElseIf Session("Basic") = False Then
            LogsOper.ShowInfotoWeb("请先填写项目申报基本信息表并保存！", upPage)
            Exit Sub
        End If
    End Sub

    Protected Sub lbtnPlanBook_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnPlanBook.Click
        If Session("Basic") = True Then
            System.Web.UI.ScriptManager.RegisterStartupScript(upPage, Me.GetType, "click", "javascript:window.location='PlanBook.aspx';", True)
        ElseIf Session("Basic") = False Then
            LogsOper.ShowInfotoWeb("请先填写项目申报基本信息表并保存！", upPage)
            Exit Sub
        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Session("Basic") = False Then
            LogsOper.ShowInfotoWeb("请先填写项目申报基本信息表并保存！", upPage)
            Exit Sub
        End If
            If Session("PrId") <> 0 And Not Session("PrId") Is Nothing Then
                Dim oProjectInfo As New ProjectInfo
                oProjectInfo = oProjectInfo.GetToObj("PrId=" & Session("PrId"))
                If Not oProjectInfo Is Nothing Then
                    oProjectInfo.PrStatus = "提交预审"
                    oProjectInfo.Update(oProjectInfo)
                    LogsOper.ShowInfotoWeb("提交成功！", upPage)
                End If
            End If
    End Sub

End Class

