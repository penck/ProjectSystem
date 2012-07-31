Imports System.Web.Services
Imports ProjectData
Imports SysOpProvider

Partial Class index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim oType As New Type
            dpUsType.Items.Clear()
            dpUsType.DataSource = oType.GetToLOLIT("TyClass='用户类型'")
            dpUsType.DataTextField = "Text"
            dpUsType.DataValueField = "Value"
            dpUsType.DataBind()
            '验证码生成
            ValidateImage.ImageUrl = "ValidateImage.aspx"
            '默认enter按钮
            SetEnterControl(lbtnLogin)
        End If
    End Sub

    Protected Sub lbtnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnLogin.Click
        Dim nUsType As String = dpUsType.SelectedItem.Text.ToString
        Dim nUsName As String = txtUsName.Text.Trim
        Dim nUsPassword As String = txtUsPassword.Text.Trim
        Dim nCode As String = txtCode.Text.Trim
        If nUsName = "" Then
            LogsOper.ShowInfotoWeb("请输入用户名！", upPage)
            ScriptManager1.SetFocus(txtUsName)
            Exit Sub
        End If
        If nUsPassword = "" Then
            LogsOper.ShowInfotoWeb("请输入密码！", upPage)
            ScriptManager1.SetFocus(txtUsPassword)
            Exit Sub
        End If
        If nCode = "" Then
            LogsOper.ShowInfotoWeb("请输入验证码！", upPage)
            ScriptManager1.SetFocus(txtCode)
            Exit Sub
        End If

        Try
            If Request.Cookies("ChkCode") Is Nothing Then
                Exit Sub
            End If
            If Request.Cookies("ChkCode").Value = txtCode.Text.Trim.ToString Then
                Login(nUsType, nUsName, nUsPassword)
            Else
                LogsOper.ShowInfotoWeb("您输入的验证码不正确！", upPage)
                txtCode.Text = ""
                ScriptManager1.SetFocus(txtCode)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Protected Sub lbtnRegister_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnRegister.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(upPage, Me.GetType, "click", "javascript:window.location='register.aspx';", True)
    End Sub

    Sub Login(ByVal cUsType As String, ByVal cUsName As String, ByVal cUsPassword As String)
        Try
            Dim nFlag As Integer = 0
            Dim oUser As New User
            nFlag = oUser.GetLoginStatus(cUsType, cUsName, cUsPassword)
            If nFlag = 1 Then
                Session("UsName") = cUsName
                If dpUsType.SelectedItem.Text = "申报用户" Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(upPage, Me.GetType, "click", "javascript:window.location='ManageSys/Apply/Tzgg.aspx';", True)
                ElseIf dpUsType.SelectedItem.Text = "推荐用户" Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(upPage, Me.GetType, "click", "javascript:window.location='ManageSys/Recommend/Main.aspx';", True)
                ElseIf dpUsType.SelectedItem.Text = "审核用户" Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(upPage, Me.GetType, "click", "javascript:window.location='ManageSys/Check/Main.aspx';", True)
                End If
            ElseIf nFlag = 3 Then
                txtUsName.Text = ""
                txtUsPassword.Text = ""
                ScriptManager1.SetFocus(txtUsName)
                LogsOper.ShowInfotoWeb("该用户名不存在！", upPage)
            ElseIf nFlag = 2 Then
                txtUsPassword.Text = ""
                ScriptManager1.SetFocus(txtUsPassword)
                LogsOper.ShowInfotoWeb("您输入的密码错误！", upPage)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub SetEnterControl(ByVal nCtrl As Control)
        Dim nPage As Page
        nPage = nCtrl.Page
        Dim nScript As String
        nScript = "<script language=""javascript""> "
        nScript &= "function document.onkeydown()"
        nScript &= "{"
        nScript &= "var e = event.srcElement;"
        nScript &= "var k = event.keyCode;"
        nScript &= "if (k == 13 && e.type != ""textarea"") "
        nScript &= "{"
        nScript &= "document.all." + nCtrl.ClientID + ".click();"
        nScript &= "event.cancelBubble = true;"
        nScript &= "event.returnValue = false;"
        nScript &= "}"
        nScript &= "}"
        nScript &= "</script>"
        If Not nPage.ClientScript.IsClientScriptBlockRegistered("SetEnterControl") Then
            nPage.ClientScript.RegisterClientScriptBlock(Me.GetType, "SetEnterControl", nScript)
        End If
    End Sub

End Class
