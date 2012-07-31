Imports System.Web.Services
Imports ProjectData
Imports SysOpProvider

Partial Class ManageSys_Check_NoticeAdd
    Inherits System.Web.UI.Page

    Public gUser As New User
    Public gNoId As Integer = 0

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            gUser = gUser.GetUserBySession("UsName")
            Dim nNoId As String = ""
            nNoId = Request.QueryString("id")
            If nNoId <> "" Then
                gNoId = CInt(nNoId)
            End If
            '显示详细信息
            ShowDetail()
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' 显示详细信息
    ''' </summary>
    ''' <remarks></remarks>
    Sub ShowDetail()
        If gNoId <> 0 Then
            Dim oNoticeInfo As New NoticeInfo
            oNoticeInfo = oNoticeInfo.GetToObj("NoId='" & gNoId & "'")
            If Not oNoticeInfo Is Nothing Then
                txtNoTitle.Text = oNoticeInfo.NoTitle
                txtNoContent.Text = oNoticeInfo.NoContent
            End If
        End If
    End Sub

    Protected Sub btnOK_Click(sender As Object, e As System.EventArgs) Handles btnOK.Click
        Try
            If txtNoTitle.Text.Trim = "" Then
                LogsOper.ShowInfotoWeb("标题不能为空！", upPage)
                Exit Sub
            End If
            If txtNoContent.Text.Trim = "" Then
                LogsOper.ShowInfotoWeb("内容不能为空！", upPage)
                Exit Sub
            End If
            If gNoId = 0 Then
                Dim oNoticeInfo As New NoticeInfo
                oNoticeInfo.NoTitle = txtNoTitle.Text.Trim
                oNoticeInfo.NoContent = txtNoContent.Text.Trim
                oNoticeInfo.NoAnnounce = gUser.UsCompany
                oNoticeInfo.NoAccept = "推荐用户"
                oNoticeInfo.NoYear = Now.Year.ToString
                oNoticeInfo.NoAddUser = gUser.UsName
                oNoticeInfo.NoAddTime = Now
                oNoticeInfo.Add(oNoticeInfo)
                LogsOper.ShowInfotoWeb("添加成功！", upPage)
            Else
                Dim oNoticeInfo As New NoticeInfo
                oNoticeInfo.NoId = gNoId
                oNoticeInfo.NoTitle = txtNoTitle.Text.Trim
                oNoticeInfo.NoContent = txtNoContent.Text.Trim
                oNoticeInfo.NoAnnounce = gUser.UsCompany
                oNoticeInfo.NoAccept = "推荐用户"
                oNoticeInfo.NoYear = Now.Year.ToString
                oNoticeInfo.NoAddUser = gUser.UsName
                oNoticeInfo.NoAddTime = Now
                oNoticeInfo.Update(oNoticeInfo)
                LogsOper.ShowInfotoWeb("修改成功！", upPage)
            End If
            System.Web.UI.ScriptManager.RegisterStartupScript(upPage, Me.GetType, "click", "javascript:location.href='NoticeManage.aspx';", True)
        Catch ex As Exception

        End Try
    End Sub
End Class
