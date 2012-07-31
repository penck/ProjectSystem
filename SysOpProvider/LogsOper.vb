Imports System.Web.HttpContext
Imports DBOpProvider
Imports System.Data.SqlClient
Imports System.Net.Mime.MediaTypeNames
Imports System.Data
Imports System.Web.UI

Public Class LogsOper

    ''' <summary>
    ''' 显示提示信息(在web应用程序中）,cUrl为空时不转入其它页面，如果不为空则转入cUrl
    ''' </summary>
    ''' <param name="cMsg">提示的信息</param>
    ''' <remarks>显示提示信息(在web应用程序中）cUrl为空时不转入其它页面，如果不为空则转入cUrl</remarks>
    Public Overloads Shared Sub ShowInfotoWeb(ByVal cMsg As String)
        Current.Response.Write("<script>alert('" & cMsg & "');</script>")
    End Sub

    ''' <summary>
    ''' 显示提示信息(在web应用程序中）,cUrl为空时不转入其它页面，如果不为空则转入cUrl
    ''' </summary>
    ''' <param name="cMsg">提示的信息</param>
    ''' <param name="cUrl">待转入页面的地址</param>
    ''' <remarks>显示提示信息(在web应用程序中）cUrl为空时不转入其它页面，如果不为空则转入cUrl</remarks>
    Public Overloads Shared Sub ShowInfotoWeb(ByVal cMsg As String, ByVal cUrl As String)
        Current.Response.Write("<script>alert('" & cMsg & "');</script>")
        Current.Response.Write("<script>javascript:window.location='" & cUrl & "'</script>")
    End Sub


    ''' <summary>
    ''' 显示提示信息(在web应用程序中）,cUrl为空时不转入其它页面，如果不为空则转入cUrl
    ''' </summary>
    ''' <param name="cMsg">提示的信息</param>
    ''' <remarks>显示提示信息(在web应用程序中）cUrl为空时不转入其它页面，如果不为空则转入cUrl</remarks>
    Public Overloads Shared Sub ShowInfotoWeb(ByVal cMsg As String, ByVal cUpdatePanelId As Object)
        Dim nForm As New System.Web.UI.Page
        System.Web.UI.ScriptManager.RegisterStartupScript(cUpdatePanelId, nForm.GetType, "click", "alert('" & cMsg & "');", True)
    End Sub


    ''' <summary>
    ''' 显示提示信息(在windows应用程序中）
    ''' </summary>
    ''' <param name="cMsg">提示的信息</param>
    ''' <remarks>显示提示信息(在windows应用程序中）</remarks>
    Public Overloads Shared Sub ShowInfotoWindows(ByVal cMsg As String)
        MsgBox(cMsg, MsgBoxStyle.Information, "系统提示")
    End Sub

    Public Overloads Shared Function ShowInfotoWindows(ByVal cMsg As String, ByVal cMsgBoxStyle As MsgBoxStyle) As MsgBoxResult
        Return MsgBox(cMsg, cMsgBoxStyle, "系统提示")
    End Function

End Class
