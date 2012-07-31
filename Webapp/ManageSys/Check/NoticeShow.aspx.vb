Imports System.Web.Services
Imports ProjectData
Imports SysOpProvider

Partial Class ManageSys_Check_NoticeShow
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
        Dim oNoticeInfo As New NoticeInfo
        oNoticeInfo = oNoticeInfo.GetToObj("NoId=" & gNoId)
        If Not oNoticeInfo Is Nothing Then
            lblNoTitle.Text = oNoticeInfo.NoTitle
            lblNoAnnounce.Text = oNoticeInfo.NoAnnounce
            lblNoAddTime.Text = oNoticeInfo.NoAddTime.Date
            lblNoContent.Text = oNoticeInfo.NoContent
        End If
    End Sub

End Class
