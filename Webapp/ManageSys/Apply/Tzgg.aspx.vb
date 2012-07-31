Imports System.Web.Services
Imports ProjectData
Imports SysOpProvider

Partial Class ManageSys_Apply_Tzgg
    Inherits System.Web.UI.Page

    Public gUser As New User

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            gUser = gUser.GetUserBySession("UsName")
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
        Dim oProjectInfo As New ProjectInfo
        oProjectInfo = oProjectInfo.GetToObj("UsId='" & gUser.UsId & "'")
        If Not oProjectInfo Is Nothing Then
            Dim oProjectBasicInfo As New ProjectBasicInfo
            oProjectBasicInfo = oProjectBasicInfo.GetToObj("PrId='" & oProjectInfo.PrId & "'")
            If Not oProjectBasicInfo Is Nothing Then
                Dim oRecommendUnit As New RecommendUnit
                oRecommendUnit = oRecommendUnit.GetToObj("ReUnId='" & oProjectBasicInfo.ReUnId & "'")
                If Not oRecommendUnit Is Nothing Then
                    Dim oUser As New User
                    oUser = oUser.GetToObj("UsCompany='" & oRecommendUnit.ReUnName & "'")
                    If Not oUser Is Nothing Then
                        Dim oNoticeInfo As New NoticeInfo
                        Dim oLOOBj As New List(Of NoticeInfo)
                        oLOOBj = oNoticeInfo.GetToLOObj("NoAddUser='" & oUser.UsName & "'")
                        If Not oLOOBj Is Nothing Then
                            lblNoTitle.Text = "<br>"
                            For nIndex As Integer = 0 To oLOOBj.Count - 1
                                lblNoTitle.Text &= "<a href='NoticeShow.aspx?id=" & oLOOBj(nIndex).NoId & "'>" & (nIndex + 1) & "." & oLOOBj(nIndex).NoTitle & "</a>"
                                lblNoTitle.Text &= "<br>"
                            Next
                        Else
                            lblNoTitle.Text = "暂无通知公告"
                        End If
                    Else
                        lblNoTitle.Text = "暂无通知公告"
                    End If
                Else
                    lblNoTitle.Text = "暂无通知公告"
                End If
            Else
                lblNoTitle.Text = "暂无通知公告"
            End If
        Else
            lblNoTitle.Text = "暂无通知公告"
        End If
    End Sub
End Class
