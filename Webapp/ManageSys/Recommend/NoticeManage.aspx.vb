Imports System.Web.Services
Imports ProjectData
Imports SysOpProvider

Partial Class ManageSys_Check_NoticeManage
    Inherits System.Web.UI.Page

    Public gUser As New User

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            gUser = gUser.GetUserBySession("UsName")
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
        Dim oNoticeInfo As New NoticeInfo
        gvNoticeInfo.Columns(0).Visible = True
        gvNoticeInfo.DataSource = oNoticeInfo.GetToDV("NoAddUser='" & gUser.UsName & "'")
        gvNoticeInfo.DataBind()
        gvNoticeInfo.Columns(0).Visible = False
    End Sub

    Protected Sub gvNoticeInfo_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvNoticeInfo.RowCommand
        Try
            Dim nNoId As Integer = gvNoticeInfo.DataKeys(e.CommandArgument).Value.ToString
            If e.CommandName = "NoticeUpdate" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(upPage, Me.GetType, "click", "javascript:location.href='NoticeAdd.aspx?id=" & nNoId & "';", True)
            ElseIf e.CommandName = "NoticeDelete" Then
                Dim oNoticeInfo As New NoticeInfo
                oNoticeInfo.Delete("NoId=" & nNoId)
                LogsOper.ShowInfotoWeb("删除成功！", upPage)
                BindData()
            ElseIf e.CommandName = "NoticeTitle" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(upPage, Me.GetType, "click", "javascript:location.href='NoticeShow.aspx?id=" & nNoId & "';", True)
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class
