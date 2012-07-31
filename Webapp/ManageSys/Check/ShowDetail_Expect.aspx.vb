Imports System.Web.Services
Imports ProjectData
Imports SysOpProvider

Partial Class ManageSys_Check_ShowDetail_Expect
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
        Dim oProjectBasicInfo As New ProjectBasicInfo
        oProjectBasicInfo = oProjectBasicInfo.GetToObj("PrId=" & gPrId)
        If Not oProjectBasicInfo Is Nothing Then
            lblPrName.Text = oProjectBasicInfo.PrBaName
            lblPrBaHostName.Text = oProjectBasicInfo.PrBaHostName
            Dim oRecommendUnit As New RecommendUnit
            oRecommendUnit = oRecommendUnit.GetToObj("ReUnId=" & oProjectBasicInfo.ReUnId)
            If Not oRecommendUnit Is Nothing Then
                lblReUnName.Text = oRecommendUnit.ReUnName
            End If
        End If
        Dim oProjectExpectInfo As New ProjectExpectInfo
        oProjectExpectInfo = oProjectExpectInfo.GetToObj("PrId=" & gPrId)
        If Not oProjectExpectInfo Is Nothing Then
            lblPrExWcsj.Text = oProjectExpectInfo.PrExWcsj
            txtPrExZyyjnr.Text = oProjectExpectInfo.PrExZyyjnr
            txtPrExYqmb.Text = oProjectExpectInfo.PrExYqmb
            lblPrExDwzhqc.Text = oProjectExpectInfo.PrExDwzhqc
            lblPrExKhhqc.Text = oProjectExpectInfo.PrExKhhqc
            lblPrExKhhzh.Text = oProjectExpectInfo.PrExKhhzh
        End If
    End Sub
End Class
