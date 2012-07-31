Imports System.Web.Services
Imports ProjectData
Imports SysOpProvider

Partial Class ManageSys_ApplyUser_Expect
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
                '显示详细信息
                showContent()
            End If
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' 初始化加载页面所需的内容
    ''' </summary>
    ''' <remarks></remarks>
    Sub initContent()
        Dim oProjectBasicInfo As New ProjectBasicInfo
        If gPrId <> 0 Then
            oProjectBasicInfo = oProjectBasicInfo.GetToObj("PrId=" & gPrId)
            If Not oProjectBasicInfo Is Nothing Then
                lblPrBaName.Text = oProjectBasicInfo.PrBaName
                lblPrBaHostName.Text = oProjectBasicInfo.PrBaHostName
                Dim oRecommendUnit As New RecommendUnit
                oRecommendUnit = oRecommendUnit.GetToObj("ReUnId=" & oProjectBasicInfo.ReUnId)
                If Not oRecommendUnit Is Nothing Then
                    lblReUnName.Text = oRecommendUnit.ReUnName
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' 显示详细信息
    ''' </summary>
    ''' <remarks></remarks>
    Sub showContent()
        If gPrId <> 0 Then
            Dim oProjectExpectInfo As New ProjectExpectInfo
            oProjectExpectInfo = oProjectExpectInfo.GetToObj("PrId=" & gPrId)
            If Not oProjectExpectInfo Is Nothing Then
                txtPrExWcsj.Text = oProjectExpectInfo.PrExWcsj
                txtPrExZyyjnr.Text = oProjectExpectInfo.PrExZyyjnr
                txtPrExYqmb.Text = oProjectExpectInfo.PrExYqmb
                txtPrExDwzhqc.Text = oProjectExpectInfo.PrExDwzhqc
                txtPrExKhhqc.Text = oProjectExpectInfo.PrExKhhqc
                txtPrExKhhzh.Text = oProjectExpectInfo.PrExKhhzh
            End If
        End If
    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Try
            '验证信息
            Dim nCheckInfo As String = ""
            nCheckInfo &= CheckClass.StrIsEmptyCheck(txtPrExWcsj.Text.Trim, "完成时间")
            nCheckInfo &= CheckClass.StrIsEmptyCheck(txtPrExZyyjnr.Text.Trim, "主要研究内容")
            nCheckInfo &= CheckClass.StrIsEmptyCheck(txtPrExYqmb.Text.Trim, "预期目标")
            nCheckInfo &= CheckClass.StrIsEmptyCheck(txtPrExDwzhqc.Text.Trim, "单位帐户全称")
            nCheckInfo &= CheckClass.StrIsEmptyCheck(txtPrExKhhqc.Text.Trim, "开户行全称")
            nCheckInfo &= CheckClass.StrIsDigitalCheck(txtPrExKhhzh.Text.Trim, True, "开户行帐号")
            If nCheckInfo.Trim <> "" Then
                LogsOper.ShowInfotoWeb(nCheckInfo.Trim, upExpectPage)
                Exit Sub
            End If
            '添加信息
            addNewProject()
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    '''添加信息 
    ''' </summary>
    ''' <remarks></remarks>
    Sub addNewProject()
        If gPrId <> 0 Then
            Dim oProjectExpectInfo As New ProjectExpectInfo
            oProjectExpectInfo = oProjectExpectInfo.GetToObj("PrId=" & gPrId)
            If Not oProjectExpectInfo Is Nothing Then
                oProjectExpectInfo.PrId = gPrId
                oProjectExpectInfo.PrExWcsj = txtPrExWcsj.Text.Trim
                oProjectExpectInfo.PrExZyyjnr = txtPrExZyyjnr.Text.Trim
                oProjectExpectInfo.PrExYqmb = txtPrExYqmb.Text.Trim
                oProjectExpectInfo.PrExDwzhqc = txtPrExDwzhqc.Text.Trim
                oProjectExpectInfo.PrExKhhqc = txtPrExKhhqc.Text.Trim
                oProjectExpectInfo.PrExKhhzh = txtPrExKhhzh.Text.Trim
                Dim nRePrExId As Integer = 0
                nRePrExId = oProjectExpectInfo.Update(oProjectExpectInfo)
                If nRePrExId <> 0 Then
                    LogsOper.ShowInfotoWeb("修改成功！", upExpectPage)
                End If
            Else
                '添加新纪录
                Dim oProjectExpectInfo1 As New ProjectExpectInfo
                oProjectExpectInfo1.PrId = gPrId
                oProjectExpectInfo1.PrExWcsj = txtPrExWcsj.Text.Trim
                oProjectExpectInfo1.PrExZyyjnr = txtPrExZyyjnr.Text.Trim
                oProjectExpectInfo1.PrExYqmb = txtPrExYqmb.Text.Trim
                oProjectExpectInfo1.PrExDwzhqc = txtPrExDwzhqc.Text.Trim
                oProjectExpectInfo1.PrExKhhqc = txtPrExKhhqc.Text.Trim
                oProjectExpectInfo1.PrExKhhzh = txtPrExKhhzh.Text.Trim
                Dim nRePrExId1 As Integer = 0
                nRePrExId1 = oProjectExpectInfo1.Add(oProjectExpectInfo1)
                If nRePrExId1 <> 0 Then
                    LogsOper.ShowInfotoWeb("添加成功！", upExpectPage)
                End If
            End If
        End If

    End Sub

End Class
