Imports System.Web.Services
Imports ProjectData
Imports SysOpProvider

Partial Class ManageSys_Recommend_ShowDetail_ApplyBook
    Inherits System.Web.UI.Page

    Public gUser As New User
    Public gPrId As Integer = 0

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            gUser = gUser.GetUserBySession("UsName")
            Dim nPrId As String = ""
            nPrId = Request.QueryString("id")
            If nPrId <> "" Then
                gPrId = CInt(nPrId)
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
        Dim oProjectFile As New ProjectFile
        Dim oLOOBj As New List(Of ProjectFile)
        oLOOBj = oProjectFile.GetToLOObj("PrId='" & gPrId & "' and PrFiClass='项目申请书'")
        If Not oLOOBj Is Nothing Then
            lblPrFiName.Text = "<br>"
            For nIndex As Integer = 0 To oLOOBj.Count - 1
                lblPrFiName.Text &= "<a href='" & "../../uploadfiles/" & oLOOBj(nIndex).PrFiAddress & "'>" & oLOOBj(nIndex).PrFiName & "</a>"
                lblPrFiName.Text &= "<br>"
            Next
        Else
            lblPrFiName.Text = "暂无附件"
        End If
    End Sub
End Class
