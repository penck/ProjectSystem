Imports System.Web.Services
Imports ProjectData
Imports SysOpProvider

Partial Class register
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '验证码生成
            ValidateImage.ImageUrl = "ValidateImage.aspx"
            txtUsName.Focus()
        End If
    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Try
            Dim nCheckInfo As String = ""
            nCheckInfo &= CheckClass.StrIsEmptyCheck(txtUsName.Text.Trim, "用户名")
            nCheckInfo &= CheckClass.StrIsEmptyCheck(txtUsPassWord.Text.Trim, "密码")
            nCheckInfo &= CheckClass.StrIsEmptyCheck(txtUsPassWord_Check.Text.Trim, "确认密码")
            nCheckInfo &= CheckClass.StrIsEmptyCheck(txtUsCompany.Text.Trim, "单位名称")
            nCheckInfo &= CheckClass.StrIsEmptyCheck(txtUsContactName.Text.Trim, "联系人姓名")
            nCheckInfo &= CheckClass.PhoneCheck(txtUsTelephone.Text.Trim, True)
            nCheckInfo &= CheckClass.TelPhoneCheck(txtUsMobilephone.Text.Trim, True)
            nCheckInfo &= CheckClass.StrIsEmptyCheck(txtCode.Text.Trim, "验证码")
            If nCheckInfo.Trim <> "" Then
                LogsOper.ShowInfotoWeb(nCheckInfo.Trim, upPage)
                Exit Sub
            End If
            If txtUsPassWord.Text.Trim <> txtUsPassWord_Check.Text.Trim Then
                LogsOper.ShowInfotoWeb("确认密码不对！", upPage)
                Exit Sub
            End If
            If Request.Cookies("ChkCode") Is Nothing Then
                Exit Sub
            End If
            If Request.Cookies("ChkCode").Value = txtCode.Text.Trim.ToString Then
                Dim oUser As New User
                If oUser.IsExistUser("UsName= '" & txtUsName.Text.Trim & "'") Then
                    LogsOper.ShowInfotoWeb("该用户名已存在！", upPage)
                    txtUsName.Text = ""
                    ScriptManager1.SetFocus(txtUsName)
                    Exit Sub
                End If
                oUser.UsName = txtUsName.Text.Trim
                oUser.UsPassword = txtUsPassWord.Text.Trim
                oUser.UsCompany = txtUsCompany.Text.Trim
                oUser.UsContactName = txtUsContactName.Text.Trim
                oUser.UsTelephone = txtUsTelephone.Text.Trim
                oUser.UsMobilephone = txtUsMobilephone.Text.Trim
                oUser.TypeName = "申报用户"
                oUser.UsAddTime = Now
                oUser.Add(oUser)
                LogsOper.ShowInfotoWeb("注册成功！", upPage)
                System.Web.UI.ScriptManager.RegisterStartupScript(upPage, Me.GetType, "click", "javascript:window.location='index.aspx';", True)
            Else
                LogsOper.ShowInfotoWeb("您输入的验证码不正确！", upPage)
                txtCode.Text = ""
                ScriptManager1.SetFocus(txtCode)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        txtUsName.Text = ""
        txtUsPassWord.Text = ""
        txtUsPassWord_Check.Text = ""
        txtUsCompany.Text = ""
        txtUsContactName.Text = ""
        txtUsTelephone.Text = ""
        txtUsMobilephone.Text = ""
        txtCode.Text = ""
    End Sub

End Class
