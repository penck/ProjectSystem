Imports System.Web.Services
Imports ProjectData
Imports SysOpProvider
Partial Class ManageSys_Recommend_Xgmm
    Inherits System.Web.UI.Page

    Public gUser As New User

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            gUser = gUser.GetUserBySession("UsName")
            If Not IsPostBack Then
                lblMessage.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try
            If txtPassWordOri.Text <> gUser.UsPassword Then
                lblMessage.Text = "原密码错误！"
                lblMessage.ForeColor = Drawing.Color.Red
                lblMessage.Font.Italic = True
                lblMessage.Visible = True
                Return
            ElseIf txtPassWordConfirm.Text <> txtPassWordNew.Text Then
                lblMessage.Text = "两次输入新密码不一致！"
                lblMessage.ForeColor = Drawing.Color.Red
                lblMessage.Font.Italic = True
                lblMessage.Visible = True
                Return
            End If

            gUser = gUser.GetUserBySession("UsName")
            gUser.UsPassword = txtPassWordNew.Text
            Dim d As DateTime = DateTime.Parse(gUser.UsAddTime)
            gUser.UsAddTime = String.Format("{0:yyyy-MM-dd HH:mm:ss.FFFF}", d)

            gUser.Update(gUser)
            lblMessage.Text = "密码已修改!"
            lblMessage.ForeColor = Drawing.Color.Green
        Catch ex As Exception

        End Try
    End Sub
End Class
