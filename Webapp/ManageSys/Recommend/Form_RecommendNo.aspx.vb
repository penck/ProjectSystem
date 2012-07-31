Imports System.Web.Services
Imports ProjectData
Imports SysOpProvider

Partial Class ManageSys_Recommend_Form_RecommendNo
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
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnOK_Click(sender As Object, e As System.EventArgs) Handles btnOK.Click
        Try
            If txtPrReThYy.Text.Trim = "" Then
                LogsOper.ShowInfotoWeb("退回原因不能为空！", upPage)
                Exit Sub
            End If
            Dim oProjectRecommend As New ProjectRecommend
            oProjectRecommend = oProjectRecommend.GetToObj("PrId=" & gPrId)
            If Not oProjectRecommend Is Nothing Then
                Dim nProjectRecommend As New ProjectRecommend
                nProjectRecommend.PrId = gPrId
                nProjectRecommend.PrReNo = oProjectRecommend.PrReNo
                nProjectRecommend.PrReIsTj = False
                nProjectRecommend.PrReTjYy = " "
                nProjectRecommend.PrReIsTh = True
                nProjectRecommend.PrReThYy = txtPrReThYy.Text.Trim
                nProjectRecommend.PrReUserName = gUser.UsName
                nProjectRecommend.Update(nProjectRecommend)
            Else
                Dim nProjectRecommend As New ProjectRecommend
                nProjectRecommend.PrId = gPrId
                nProjectRecommend.PrReNo = " "
                nProjectRecommend.PrReIsTj = False
                nProjectRecommend.PrReTjYy = " "
                nProjectRecommend.PrReIsTh = True
                nProjectRecommend.PrReThYy = txtPrReThYy.Text.Trim
                nProjectRecommend.PrReUserName = gUser.UsName
                nProjectRecommend.Add(nProjectRecommend)
            End If
            Dim oProjectInfo As New ProjectInfo
            oProjectInfo = oProjectInfo.GetToObj("PrId=" & gPrId)
            If Not oProjectInfo Is Nothing Then
                oProjectInfo.PrStatus = "预推荐通过"
                oProjectInfo.Update(oProjectInfo)
            End If
            System.Web.UI.ScriptManager.RegisterStartupScript(upPage, Me.GetType, "click", "javascript:window.returnValue=true;window.close();", True)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(upPage, Me.GetType, "click", "javascript:window.returnValue=false;window.close();", True)
    End Sub

End Class
