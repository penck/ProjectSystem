Imports System.Web.Services
Imports ProjectData
Imports SysOpProvider

Partial Class ManageSys_ApplyUser_ApplyBook
    Inherits System.Web.UI.Page

    Public gUsId As Integer = 0
    Public gUser As New User
    Public gPrId As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            gUser = gUser.GetUserBySession("UsName")
            If Not gUser Is Nothing Then
                gUsId = gUser.UsId
            End If
            gPrId = Session("PrId")
            If Not IsPostBack Then
                '初始化加载页面所需的内容
                initContent()
                '绑定数据到gvApplyBook中去
                BindData()
            End If
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' 初始化加载页面所需的内容
    ''' </summary>
    ''' <remarks></remarks>
    Sub initContent()
        Dim oProjectInfo As New ProjectInfo
        oProjectInfo = oProjectInfo.GetToObj("PrId=" & gPrId)
        If Not oProjectInfo Is Nothing Then
            lblPrName.Text = oProjectInfo.PrName
        End If
    End Sub

    ''' <summary>
    ''' 绑定数据到gvApplyBook中去
    ''' </summary>
    ''' <remarks></remarks>
    Sub BindData()
        Dim oProjectFile As New ProjectFile
        Dim nCondition As String = "PrId=" & gPrId & "and PrFiClass='项目申请书'"
        gvApplyBook.DataSource = oProjectFile.GetToDV(nCondition)
        gvApplyBook.DataBind()
    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim nSavePath As String = ""
        If fupApplyBook.HasFile Then
            Dim nPrFiName As String = Server.HtmlEncode(fupApplyBook.FileName)
            Dim nExtension As String = System.IO.Path.GetExtension(nPrFiName)
            If nExtension = ".doc" Or nExtension = ".docx" Then
                Dim nPrFiAddr As String = DateTime.Now.ToString("yyyyMMddhhmmssfff") + nExtension
                nSavePath = Server.MapPath("~/uploadfiles/" & nPrFiAddr)
                fupApplyBook.SaveAs(nSavePath)
                Dim oProjectFile As New ProjectFile
                oProjectFile.PrId = gPrId
                oProjectFile.PrFiName = nPrFiName
                oProjectFile.PrFiAddress = nPrFiAddr
                oProjectFile.PrFiClass = "项目申请书"
                Dim nRePrFiId As Integer = 0
                nRePrFiId = oProjectFile.Add(oProjectFile)
                If nRePrFiId <> 0 Then
                    LogsOper.ShowInfotoWeb("文件上传成功！", upApplyBookPage)
                    '绑定数据到gvApplyBook中去
                    BindData()
                End If
            Else
                LogsOper.ShowInfotoWeb("只能上传.doc格式或.docx格式的文件！", upApplyBookPage)
                Exit Sub
            End If
        Else
            LogsOper.ShowInfotoWeb("请选择要上传的文件！", upApplyBookPage)
            Exit Sub
        End If
    End Sub


    Protected Sub gvApplyBook_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvApplyBook.RowCommand
        Try
            Dim nPrFiId As Integer = gvApplyBook.DataKeys(e.CommandArgument).Value.ToString
            If e.CommandName = "deleteFile" Then
                Dim oProjectFile As New ProjectFile
                oProjectFile = oProjectFile.GetToObj("PrFiId=" & nPrFiId)
                If Not oProjectFile Is Nothing Then
                    Dim nFileName As String = ""
                    nFileName = Server.MapPath("~/uploadfiles/" & oProjectFile.PrFiAddress)
                    If My.Computer.FileSystem.FileExists(nFileName) Then
                        My.Computer.FileSystem.DeleteFile(nFileName)
                    End If
                End If
                Dim oProjectFile1 As New ProjectFile
                Dim nReDelete As Integer = 0
                nReDelete = oProjectFile1.Delete("PrFiId=" & nPrFiId)
                If nReDelete <> 0 Then
                    LogsOper.ShowInfotoWeb("删除成功！", upApplyBookPage)
                    '绑定数据到gvApplyBook中去
                    BindData()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
