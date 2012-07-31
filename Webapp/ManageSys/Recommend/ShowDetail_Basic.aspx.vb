Imports System.Web.Services
Imports ProjectData
Imports SysOpProvider

Partial Class ManageSys_Recommend_ShowDetail_Basic
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
            Dim oType As New Type
            oType = oType.GetToObj("TyId=" & oProjectBasicInfo.PrBaClass)
            If Not oType Is Nothing Then
                lblPrBaClass.Text = oType.TyName
            End If
            lblPrBaYear.Text = oProjectBasicInfo.PrBaYear
            lblPrBaName.Text = oProjectBasicInfo.PrBaName
            lblPrBaApplyTime.Text = oProjectBasicInfo.PrBaApplyTime
            oType = oType.GetToObj("TyId=" & oProjectBasicInfo.PrBaArea)
            If Not oType Is Nothing Then
                lblPrBaArea.Text = oType.TyName
            End If
            Dim oRecommendUnit As New RecommendUnit
            oRecommendUnit = oRecommendUnit.GetToObj("ReUnId=" & oProjectBasicInfo.ReUnId)
            If Not oRecommendUnit Is Nothing Then
                lblReUnId.Text = oRecommendUnit.ReUnName
                oType = oType.GetToObj("TyId=" & oRecommendUnit.ReUnTypeId)
                If Not oType Is Nothing Then
                    lblReUnClass.Text = oType.TyName
                End If
            End If
            lblPrBaHostUnit.Text = oProjectBasicInfo.PrBaHostUnit
            oType = oType.GetToObj("TyId=" & oProjectBasicInfo.PrBaHostUnitClass)
            If Not oType Is Nothing Then
                lblPrBaHostUnitClass.Text = oType.TyName
            End If
            lblPrBaCooperationUnit.Text = oProjectBasicInfo.PrBaCooperationUnit
            oType = oType.GetToObj("TyId=" & oProjectBasicInfo.PrBaCooperationUnitClass)
            If Not oType Is Nothing Then
                lblPrBaCooperationUnitClass.Text = oType.TyName
            End If
            oType = oType.GetToObj("TyId=" & oProjectBasicInfo.PrBaIsCxyhz)
            If Not oType Is Nothing Then
                lblPrBaIsCxyhz.Text = oType.TyName
            End If
            oType = oType.GetToObj("TyId=" & oProjectBasicInfo.PrBaHzxs)
            If Not oType Is Nothing Then
                lblPrBaHzxs.Text = oType.TyName
            End If
            lblPrBaHostName.Text = oProjectBasicInfo.PrBaHostName
            oType = oType.GetToObj("TyId=" & oProjectBasicInfo.PrBaHostSex)
            If Not oType Is Nothing Then
                lblPrBaHostSex.Text = oType.TyName
            End If
            oType = oType.GetToObj("TyId=" & oProjectBasicInfo.PrBaHostEducation)
            If Not oType Is Nothing Then
                lblPrBaHostEducation.Text = oType.TyName
            End If
            oType = oType.GetToObj("TyId=" & oProjectBasicInfo.PrBaHostPosition)
            If Not oType Is Nothing Then
                lblPrBaHostPosition.Text = oType.TyName
            End If
            lblPrBaHostBirth.Text = oProjectBasicInfo.PrBaHostBirth.Date
            lblPrBaHostWorkPhone.Text = oProjectBasicInfo.PrBaHostWorkPhone
            lblPrBaHostMobilePhone.Text = oProjectBasicInfo.PrBaHostMobilePhone
            lblPrBaHostEmail.Text = oProjectBasicInfo.PrBaHostEmail
            lblPrBaAllPeopleNumber.Text = oProjectBasicInfo.PrBaAllPeopleNumber
            lblPrBaGjzcNumber.Text = oProjectBasicInfo.PrBaGjzcNumber
            lblPrBaZjzcNumber.Text = oProjectBasicInfo.PrBaZjzcNumber
            lblPrBaCjzcNumber.Text = oProjectBasicInfo.PrBaCjzcNumber
            lblPrBaOtherNumber.Text = oProjectBasicInfo.PrBaOtherNumber
            lblPrBaYfztr.Text = oProjectBasicInfo.PrBaYfztr
            lblPrBaSczbk.Text = oProjectBasicInfo.PrBaSczbk
            lblPrBaQxczbk.Text = oProjectBasicInfo.PrBaQxczbk
            lblPrBaDwzc.Text = oProjectBasicInfo.PrBaDwzc
            lblPrBaKfxcp.Text = oProjectBasicInfo.PrBaKfxcp
            lblPrBaQdzlx.Text = oProjectBasicInfo.PrBaQdzlx
            lblPrBaJsbz.Text = oProjectBasicInfo.PrBaJsbz
            lblPrBaDzwxpz.Text = oProjectBasicInfo.PrBaDzwxpz
            lblPrBaYfOther.Text = oProjectBasicInfo.PrBaYfOther
            lblPrBaXzqy.Text = oProjectBasicInfo.PrBaXzqy
            lblPrBaXcscnl.Text = oProjectBasicInfo.PrBaXcscnl
            lblPrBaLdcytz.Text = oProjectBasicInfo.PrBaLdcytz
            lblPrBaXzxssr.Text = oProjectBasicInfo.PrBaXzxssr
            lblPrBaXzls.Text = oProjectBasicInfo.PrBaXzls
            lblPrBaCh.Text = oProjectBasicInfo.PrBaCh
        End If
    End Sub

End Class
