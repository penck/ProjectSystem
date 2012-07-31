Imports System.Web.Services
Imports ProjectData
Imports SysOpProvider

Partial Class ApplyUser_Xmsb
    Inherits System.Web.UI.Page

    Public gUsId As Integer
    Public gUser As New User

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            gUser = gUser.GetUserBySession("UsName")
            If Not gUser Is Nothing Then
                gUsId = gUser.UsId
            End If
            If Not IsPostBack Then
                '绑定数据到gvProject中去
                BindData()
            End If
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' 绑定数据到gvProject中去
    ''' </summary>
    ''' <remarks></remarks>
    Sub BindData()
        Dim oProjectInfo As New ProjectInfo
        Dim nCondition As String = "UsId=" & gUsId
        gvProject.Columns(0).Visible = True
        gvProject.DataSource = oProjectInfo.GetToDV(nCondition)
        gvProject.DataBind()
        gvProject.Columns(0).Visible = False
    End Sub

    Protected Sub lbtnAddNewProject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnAddNewProject.Click
        Session("PrOperate") = "AddNewProject"
        Session("PrId") = 0
        System.Web.UI.ScriptManager.RegisterStartupScript(upXmsbPage, Me.GetType, "click", "javascript:window.open('Xmsb/Basic.aspx');", True)
    End Sub

    Protected Sub gvProject_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvProject.PageIndexChanging
        gvProject.PageIndex = e.NewPageIndex
        BindData()
    End Sub

    Protected Sub gvProject_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvProject.RowCommand
        Try
            Dim nPrId As Integer = gvProject.DataKeys(e.CommandArgument).Value.ToString
            Dim nPrStatus As String = gvProject.Rows(e.CommandArgument).Cells(3).Text.Trim
            If e.CommandName = "updateProject" Then
                If nPrStatus <> "未提交" Then
                    If nPrStatus <> "提交预审" Then
                        If nPrStatus <> "预推荐通过" Then
                            If nPrStatus <> "预审通过" Then
                                LogsOper.ShowInfotoWeb("此项目已推荐，无法修改！", upXmsbPage)
                                Exit Sub
                            End If
                        End If
                    End If
                End If
                Session("PrOperate") = "EditProject"
                Session("PrId") = nPrId
                System.Web.UI.ScriptManager.RegisterStartupScript(upXmsbPage, Me.GetType, "click", "javascript:window.open('Xmsb/Basic.aspx');", True)
            ElseIf e.CommandName = "deleteProject" Then
                If nPrStatus <> "未提交" Then
                    LogsOper.ShowInfotoWeb("此项目已提交，无法删除！", upXmsbPage)
                    Exit Sub
                End If
                Dim oProjectInfo As New ProjectInfo
                oProjectInfo.Delete("PrId=" & nPrId)
                LogsOper.ShowInfotoWeb("删除成功！", upXmsbPage)
                BindData()
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class
