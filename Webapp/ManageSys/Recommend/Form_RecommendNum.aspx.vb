Imports System.Web.Services
Imports ProjectData
Imports SysOpProvider

Partial Class ManageSys_Recommend_Form_RecommendNum
    Inherits System.Web.UI.Page

    Public gUser As New User
    Public gPrId As Integer = 0
    Public gLOObj As New List(Of ProjectRecommend)

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            gUser = gUser.GetUserBySession("UsName")
            Dim nPrId As String = ""
            nPrId = Request.QueryString("id")
            If nPrId <> "" Then
                gPrId = CInt(nPrId)
            End If
            Dim oProjectRecommend As New ProjectRecommend
            gLOObj = oProjectRecommend.GetToLOObj("PrReUserName='" & gUser.UsName & "'")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnOK_Click(sender As Object, e As System.EventArgs) Handles btnOK.Click
        Try
            Dim oProjectRecommend As New ProjectRecommend
            oProjectRecommend = oProjectRecommend.GetToObj("PrId=" & gPrId)
            If Not oProjectRecommend Is Nothing Then
                oProjectRecommend.PrReNo = dpRecommendNum.SelectedValue.ToString.Trim
                oProjectRecommend.Update(oProjectRecommend)
                '重新调整次序
                ChangeNum(oProjectRecommend, dpRecommendNum.SelectedValue)
            Else
                Dim nProjectRecommend As New ProjectRecommend
                nProjectRecommend.PrId = gPrId
                nProjectRecommend.PrReNo = dpRecommendNum.SelectedValue.ToString.Trim
                nProjectRecommend.PrReIsTj = False
                nProjectRecommend.PrReTjYy = " "
                nProjectRecommend.PrReIsTh = False
                nProjectRecommend.PrReThYy = " "
                nProjectRecommend.PrReUserName = gUser.UsName
                nProjectRecommend.Add(nProjectRecommend)
                '重新调整次序
                Dim cProjectRecommend As New ProjectRecommend
                cProjectRecommend.GetToObj("PrId='" & gPrId & "'")
                If Not cProjectRecommend Is Nothing Then
                    ChangeNum(cProjectRecommend, dpRecommendNum.SelectedValue)
                End If

            End If
            System.Web.UI.ScriptManager.RegisterStartupScript(upPage, Me.GetType, "click", "javascript:window.returnValue=true;window.close();", True)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(upPage, Me.GetType, "click", "javascript:window.returnValue=false;window.close();", True)
    End Sub
    ''' <summary>
    ''' 重新调整次序
    ''' </summary>
    ''' <param name="cProjectRecommend"></param>
    ''' <param name="cNum"></param>
    ''' <remarks></remarks>
    Sub ChangeNum(ByVal cProjectRecommend As ProjectRecommend, ByVal cNum As Integer)
        For nIndex As Integer = 0 To gLOObj.Count - 1
            If gLOObj(nIndex).PrReId <> cProjectRecommend.PrReId And gLOObj(nIndex).PrReNo = cNum Then
                Dim oProjectRecommend As New ProjectRecommend
                oProjectRecommend = gLOObj(nIndex)
                oProjectRecommend.PrReNo = CInt(oProjectRecommend.PrReNo) + 1
                oProjectRecommend.Update(oProjectRecommend)
                ChangeNum(oProjectRecommend, oProjectRecommend.PrReNo)
            End If
        Next
    End Sub

End Class
