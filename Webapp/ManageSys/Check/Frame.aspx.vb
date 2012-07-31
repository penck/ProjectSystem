Imports System.Web.Services
Imports ProjectData
Imports SysOpProvider
Partial Class ManageSys_Check_Frame
    Inherits System.Web.UI.Page

    Public gUser As New User

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            gUser = gUser.GetUserBySession("UsName")
            If Not gUser Is Nothing Then
                lblUserName.Text = gUser.UsCompany & "管理员"
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class
