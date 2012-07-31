Imports System.Web.Services
Imports ProjectData
Imports SysOpProvider

Partial Class ManageSys_ApplyUser_Basic
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
                If Session("PrOperate") = "AddNewProject" Then
                    Session("Basic") = False
                    '初始化加载页面所需的内容
                    initContent()

                ElseIf Session("PrOperate") = "EditProject" Then
                    Session("Basic") = True
                    '初始化加载页面所需的内容
                    initContent()
                    '显示详细信息
                    showContent()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

#Region "初始化页面加载内容"

    ''' <summary>
    ''' 初始化页面内容
    ''' </summary>
    ''' <remarks></remarks>
    Sub initContent()
        '初始化项目类型
        Dim oType As New Type
        dpPrBaClass.Items.Clear()
        dpPrBaClass.DataSource = oType.GetToLOLIT("TyClass='项目类型'")
        dpPrBaClass.DataTextField = "Text"
        dpPrBaClass.DataValueField = "Value"
        dpPrBaClass.DataBind()
        '初始化所属批次
        txtPrBaYear.Text = Now.Year.ToString
        '初始化所在区县
        dpPrBaArea.Items.Clear()
        dpPrBaArea.DataSource = oType.GetToLOLIT("TyClass='区县名称'")
        dpPrBaArea.DataTextField = "Text"
        dpPrBaArea.DataValueField = "Value"
        dpPrBaArea.DataBind()
        dpPrBaArea.Items.Add(New ListItem("请选择...", "-1"))
        dpPrBaArea.SelectedIndex = dpPrBaArea.Items.Count - 1
        '初始化推荐单位
        dpReUnClass.Items.Clear()
        dpReUnClass.DataSource = oType.GetToLOLIT("TyClass='推荐单位类别'")
        dpReUnClass.DataTextField = "Text"
        dpReUnClass.DataValueField = "Value"
        dpReUnClass.DataBind()
        dpReUnClass.Items.Add(New ListItem("请选择...", "-1"))
        dpReUnClass.SelectedIndex = dpReUnClass.Items.Count - 1
        dpReUnClass_SelectedIndexChanged(Nothing, Nothing)
        '初始化单位性质
        dpPrBaHostUnitClass.Items.Clear()
        dpPrBaHostUnitClass.DataSource = oType.GetToLOLIT("TyClass='单位性质'")
        dpPrBaHostUnitClass.DataTextField = "Text"
        dpPrBaHostUnitClass.DataValueField = "Value"
        dpPrBaHostUnitClass.DataBind()
        dpPrBaCooperationUnitClass.Items.Clear()
        dpPrBaCooperationUnitClass.DataSource = oType.GetToLOLIT("TyClass='单位性质'")
        dpPrBaCooperationUnitClass.DataTextField = "Text"
        dpPrBaCooperationUnitClass.DataValueField = "Value"
        dpPrBaCooperationUnitClass.DataBind()
        '初始化产学研合作
        dpPrBaIsCxyhz.Items.Clear()
        dpPrBaIsCxyhz.DataSource = oType.GetToLOLIT("TyClass='是否'")
        dpPrBaIsCxyhz.DataTextField = "Text"
        dpPrBaIsCxyhz.DataValueField = "Value"
        dpPrBaIsCxyhz.DataBind()
        dpPrBaHzxs.Items.Clear()
        dpPrBaHzxs.DataSource = oType.GetToLOLIT("TyClass='产学研合作形式'")
        dpPrBaHzxs.DataTextField = "Text"
        dpPrBaHzxs.DataValueField = "Value"
        dpPrBaHzxs.DataBind()
        '初始化性别
        dpPrBaHostSex.Items.Clear()
        dpPrBaHostSex.DataSource = oType.GetToLOLIT("TyClass='性别'")
        dpPrBaHostSex.DataTextField = "Text"
        dpPrBaHostSex.DataValueField = "Value"
        dpPrBaHostSex.DataBind()
        '初始化学历
        dpPrBaHostEducation.Items.Clear()
        dpPrBaHostEducation.DataSource = oType.GetToLOLIT("TyClass='学历'")
        dpPrBaHostEducation.DataTextField = "Text"
        dpPrBaHostEducation.DataValueField = "Value"
        dpPrBaHostEducation.DataBind()
        '初始化职称
        dpPrBaHostPosition.Items.Clear()
        dpPrBaHostPosition.DataSource = oType.GetToLOLIT("TyClass='职称'")
        dpPrBaHostPosition.DataTextField = "Text"
        dpPrBaHostPosition.DataValueField = "Value"
        dpPrBaHostPosition.DataBind()
    End Sub

    Protected Sub dpReUnClass_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dpReUnClass.SelectedIndexChanged
        Try
            Dim oRecommendUnit As New RecommendUnit
            dpReUnName.Items.Clear()
            dpReUnName.DataSource = oRecommendUnit.GetToLOLIT("ReUnTypeId=" & dpReUnClass.SelectedValue)
            dpReUnName.DataTextField = "Text"
            dpReUnName.DataValueField = "Value"
            dpReUnName.DataBind()
            dpReUnName.Items.Add(New ListItem("请选择...", "-1"))
            dpReUnName.SelectedIndex = dpReUnName.Items.Count - 1
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' 显示详细信息
    ''' </summary>
    ''' <remarks></remarks>
    Sub showContent()
        If gPrId <> 0 Then
            Dim oProjectBasicInfo As New ProjectBasicInfo
            oProjectBasicInfo = oProjectBasicInfo.GetToObj("PrId=" & gPrId)
            If Not oProjectBasicInfo Is Nothing Then
                dpPrBaClass.SelectedValue = oProjectBasicInfo.PrBaClass
                txtPrBaYear.Text = oProjectBasicInfo.PrBaYear
                txtPrBaName.Text = oProjectBasicInfo.PrBaName
                txtPrBaApplyTime.Text = oProjectBasicInfo.PrBaApplyTime
                dpPrBaArea.SelectedValue = oProjectBasicInfo.PrBaArea
                Dim oRecommendUnit As New RecommendUnit
                oRecommendUnit = oRecommendUnit.GetToObj("ReUnId='" & oProjectBasicInfo.ReUnId & "'")
                If Not oRecommendUnit Is Nothing Then
                    dpReUnClass.SelectedValue = oRecommendUnit.ReUnTypeId
                    dpReUnClass_SelectedIndexChanged(Nothing, Nothing)
                    dpReUnName.SelectedValue = oProjectBasicInfo.ReUnId
                End If
                txtPrBaHostUnit.Text = oProjectBasicInfo.PrBaHostUnit
                dpPrBaHostUnitClass.SelectedValue = oProjectBasicInfo.PrBaHostUnitClass
                txtPrBaCooperationUnit.Text = oProjectBasicInfo.PrBaCooperationUnit
                dpPrBaCooperationUnitClass.SelectedValue = oProjectBasicInfo.PrBaCooperationUnitClass

                dpPrBaIsCxyhz.SelectedValue = oProjectBasicInfo.PrBaIsCxyhz
                dpPrBaHzxs.SelectedValue = oProjectBasicInfo.PrBaHzxs

                txtPrBaHostName.Text = oProjectBasicInfo.PrBaHostName
                dpPrBaHostSex.SelectedValue = oProjectBasicInfo.PrBaHostSex
                dpPrBaHostEducation.SelectedValue = oProjectBasicInfo.PrBaHostEducation
                txtPrBaHostBirth.Text = oProjectBasicInfo.PrBaHostBirth
                dpPrBaHostPosition.SelectedValue = oProjectBasicInfo.PrBaHostPosition
                txtPrBaHostWorkPhone.Text = oProjectBasicInfo.PrBaHostWorkPhone
                txtPrBaHostMobilePhone.Text = oProjectBasicInfo.PrBaHostMobilePhone
                txtPrBaHostEmail.Text = oProjectBasicInfo.PrBaHostEmail
                txtPrBaAllPeopleNumber.Text = oProjectBasicInfo.PrBaAllPeopleNumber
                txtPrBaGjzcNumber.Text = oProjectBasicInfo.PrBaGjzcNumber
                txtPrBaZjzcNumber.Text = oProjectBasicInfo.PrBaZjzcNumber
                txtPrBaCjzcNumber.Text = oProjectBasicInfo.PrBaCjzcNumber
                txtPrBaOtherNumber.Text = oProjectBasicInfo.PrBaOtherNumber
                txtPrBaYfztr.Text = oProjectBasicInfo.PrBaYfztr
                txtPrBaSczbk.Text = oProjectBasicInfo.PrBaSczbk
                txtPrBaQxczbk.Text = oProjectBasicInfo.PrBaQxczbk
                txtPrBaDwzc.Text = oProjectBasicInfo.PrBaDwzc
                txtPrBaKfxcp.Text = oProjectBasicInfo.PrBaKfxcp
                txtPrBaKfxgy.Text = oProjectBasicInfo.PrBaKfxgy
                txtPrBaKfxzb.Text = oProjectBasicInfo.PrBaKfxzb
                txtPrBaRjzscq.Text = oProjectBasicInfo.PrBaRjzscq
                txtPrBaQdzlx.Text = oProjectBasicInfo.PrBaQdzlx
                txtPrBaQzfmzlx.Text = oProjectBasicInfo.PrBaQzfmzlx
                txtPrBaJsbz.Text = oProjectBasicInfo.PrBaJsbz
                txtPrBaDzwxpz.Text = oProjectBasicInfo.PrBaDzwxpz
                txtPrBaYfOther.Text = oProjectBasicInfo.PrBaYfOther
                txtPrBaXzqy.Text = oProjectBasicInfo.PrBaXzqy
                txtPrBaXcscnl.Text = oProjectBasicInfo.PrBaXcscnl
                txtPrBaLdcytz.Text = oProjectBasicInfo.PrBaLdcytz
                txtPrBaXzxssr.Text = oProjectBasicInfo.PrBaXzxssr
                txtPrBaXzls.Text = oProjectBasicInfo.PrBaXzls
                txtPrBaCh.Text = oProjectBasicInfo.PrBaCh
                txtPrBaYjtt.Text = oProjectBasicInfo.PrBaYjtt
                txtPrBaYjrc.Text = oProjectBasicInfo.PrBaYjrc
            End If
        End If
    End Sub

#End Region

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Try
            '验证信息
            Dim nCheckInfo As String = ""
            nCheckInfo &= CheckClass.StrIsEmptyCheck(txtPrBaName.Text.Trim, "项目名称")
            nCheckInfo &= CheckClass.StrIsEmptyCheck(txtPrBaApplyTime.Text.Trim, "申报日期")
            nCheckInfo &= CheckClass.StrIsEmptyCheck(txtPrBaHostUnit.Text.Trim, "承担单位")
            nCheckInfo &= CheckClass.StrIsEmptyCheck(txtPrBaHostName.Text.Trim, "项目主持人姓名")
            nCheckInfo &= CheckClass.StrIsEmptyCheck(txtPrBaHostBirth.Text.Trim, "出生日期")
            If txtPrBaHostWorkPhone.Text.Trim <> "" Then
                nCheckInfo &= CheckClass.PhoneCheck(txtPrBaHostWorkPhone.Text.Trim, True)
            End If
            If txtPrBaHostMobilePhone.Text.Trim <> "" Then
                nCheckInfo &= CheckClass.TelPhoneCheck(txtPrBaHostMobilePhone.Text.Trim, True)
            End If
            If txtPrBaHostEmail.Text.Trim <> "" Then
                nCheckInfo &= CheckClass.EmailCheck(txtPrBaHostEmail.Text.Trim, True)
            End If
            If txtPrBaAllPeopleNumber.Text.Trim <> "" Then
                nCheckInfo &= CheckClass.StrIsDigitalCheck(txtPrBaAllPeopleNumber.Text.Trim, True, "项目总人数")
            End If
            If txtPrBaGjzcNumber.Text.Trim <> "" Then
                nCheckInfo &= CheckClass.StrIsDigitalCheck(txtPrBaGjzcNumber.Text.Trim, True, "高级职称人数")
            End If
            If txtPrBaZjzcNumber.Text.Trim <> "" Then
                nCheckInfo &= CheckClass.StrIsDigitalCheck(txtPrBaZjzcNumber.Text.Trim, True, "中级职称人数")
            End If
            If txtPrBaCjzcNumber.Text.Trim <> "" Then
                nCheckInfo &= CheckClass.StrIsDigitalCheck(txtPrBaCjzcNumber.Text.Trim, True, "初级级职称人数")
            End If
            If txtPrBaOtherNumber.Text.Trim <> "" Then
                nCheckInfo &= CheckClass.StrIsDigitalCheck(txtPrBaOtherNumber.Text.Trim, True, "其他人数")
            End If
            If txtPrBaYfztr.Text.Trim <> "" Then
                nCheckInfo &= CheckClass.StrIsShishuCheck(txtPrBaYfztr.Text.Trim, True, "研发总投入总计")
            End If
            If txtPrBaSczbk.Text.Trim <> "" Then
                nCheckInfo &= CheckClass.StrIsShishuCheck(txtPrBaSczbk.Text.Trim, True, "申请市财政拨款")
            End If
            If txtPrBaQxczbk.Text.Trim <> "" Then
                nCheckInfo &= CheckClass.StrIsShishuCheck(txtPrBaQxczbk.Text.Trim, True, "区县财政拨款")
            End If
            If txtPrBaDwzc.Text.Trim <> "" Then
                nCheckInfo &= CheckClass.StrIsShishuCheck(txtPrBaDwzc.Text.Trim, True, "单位自筹")
            End If
            If txtPrBaQdzlx.Text.Trim <> "" Then
                nCheckInfo &= CheckClass.StrIsDigitalCheck(txtPrBaQdzlx.Text.Trim, True, "取得专利")
            End If
            If txtPrBaQzfmzlx.Text.Trim <> "" Then
                nCheckInfo &= CheckClass.StrIsDigitalCheck(txtPrBaQzfmzlx.Text.Trim, True, "其中发明专利")
            End If
            If txtPrBaXzqy.Text.Trim <> "" Then
                nCheckInfo &= CheckClass.StrIsDigitalCheck(txtPrBaXzqy.Text.Trim, True, "新增企业")
            End If
            If txtPrBaLdcytz.Text.Trim <> "" Then
                nCheckInfo &= CheckClass.StrIsShishuCheck(txtPrBaLdcytz.Text.Trim, True, "拉动产业投资")
            End If
            If txtPrBaXzxssr.Text.Trim <> "" Then
                nCheckInfo &= CheckClass.StrIsShishuCheck(txtPrBaXzxssr.Text.Trim, True, "新增销售收入")
            End If
            If txtPrBaXzls.Text.Trim <> "" Then
                nCheckInfo &= CheckClass.StrIsShishuCheck(txtPrBaXzls.Text.Trim, True, " 新增利税")
            End If
            If txtPrBaCh.Text.Trim <> "" Then
                nCheckInfo &= CheckClass.StrIsShishuCheck(txtPrBaCh.Text.Trim, True, " 创汇")
            End If
            If txtPrBaYjtt.Text.Trim <> "" Then
                nCheckInfo &= CheckClass.StrIsDigitalCheck(txtPrBaYjtt.Text.Trim, True, "引进团体")
            End If
            If txtPrBaYjrc.Text.Trim <> "" Then
                nCheckInfo &= CheckClass.StrIsDigitalCheck(txtPrBaYjrc.Text.Trim, True, "引进人才")
            End If
            If nCheckInfo.Trim <> "" Then
                LogsOper.ShowInfotoWeb(nCheckInfo.Trim, upBasicPage)
                Exit Sub
            End If
            If dpPrBaArea.SelectedValue = "-1" Then
                LogsOper.ShowInfotoWeb("请选择所在区，县！", upBasicPage)
                Exit Sub
            End If
            If dpReUnName.SelectedValue = "-1" Then
                LogsOper.ShowInfotoWeb("请选择推荐单位！", upBasicPage)
                Exit Sub
            End If

            If Session("PrOperate") = "AddNewProject" Then
                '添加信息
                addNewProject()
                Session("Basic") = True
                Session("PrOperate") = "EditProject"
            ElseIf Session("PrOperate") = "EditProject" Then
                '更新信息
                updateProject()
                Session("Basic") = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' 添加新项目信息
    ''' </summary>
    ''' <remarks></remarks>
    Sub addNewProject()
        Dim oProjectInfo As New ProjectInfo
        oProjectInfo.PrName = txtPrBaName.Text.Trim
        oProjectInfo.PrStatus = "未提交"
        oProjectInfo.PrAddTime = Now.ToShortDateString
        oProjectInfo.UsId = gUsId
        Dim nReturnPrId As Integer = 0
        nReturnPrId = oProjectInfo.Add(oProjectInfo)
        If nReturnPrId <> 0 Then
            Session("PrId") = nReturnPrId
            Dim oProjectBasicInfo As New ProjectBasicInfo
            oProjectBasicInfo.PrId = nReturnPrId
            oProjectBasicInfo.PrBaClass = dpPrBaClass.SelectedValue
            oProjectBasicInfo.PrBaYear = txtPrBaYear.Text.Trim
            oProjectBasicInfo.PrBaName = txtPrBaName.Text.Trim
            oProjectBasicInfo.PrBaApplyTime = txtPrBaApplyTime.Text.Trim
            oProjectBasicInfo.PrBaArea = dpPrBaArea.SelectedValue
            oProjectBasicInfo.ReUnId = dpReUnName.SelectedValue

            oProjectBasicInfo.PrBaHostUnit = txtPrBaHostUnit.Text.Trim
            oProjectBasicInfo.PrBaHostUnitClass = dpPrBaHostUnitClass.SelectedValue

            oProjectBasicInfo.PrBaCooperationUnit = txtPrBaCooperationUnit.Text.Trim
            oProjectBasicInfo.PrBaCooperationUnitClass = dpPrBaCooperationUnitClass.SelectedValue

            oProjectBasicInfo.PrBaIsCxyhz = dpPrBaIsCxyhz.SelectedValue
            oProjectBasicInfo.PrBaHzxs = dpPrBaHzxs.SelectedValue

            oProjectBasicInfo.PrBaHostName = txtPrBaHostName.Text.Trim
            oProjectBasicInfo.PrBaHostSex = dpPrBaHostSex.SelectedValue
            oProjectBasicInfo.PrBaHostEducation = dpPrBaHostEducation.SelectedValue
            oProjectBasicInfo.PrBaHostBirth = txtPrBaHostBirth.Text.Trim
            oProjectBasicInfo.PrBaHostPosition = dpPrBaHostPosition.SelectedValue
            oProjectBasicInfo.PrBaHostWorkPhone = txtPrBaHostWorkPhone.Text.Trim
            oProjectBasicInfo.PrBaHostMobilePhone = txtPrBaHostMobilePhone.Text.Trim
            oProjectBasicInfo.PrBaHostEmail = txtPrBaHostEmail.Text.Trim
            If txtPrBaAllPeopleNumber.Text.Trim <> "" Then
                oProjectBasicInfo.PrBaAllPeopleNumber = txtPrBaAllPeopleNumber.Text.Trim
            Else
                oProjectBasicInfo.PrBaAllPeopleNumber = 0
            End If
            If txtPrBaGjzcNumber.Text.Trim <> "" Then
                oProjectBasicInfo.PrBaGjzcNumber = txtPrBaGjzcNumber.Text.Trim
            Else
                oProjectBasicInfo.PrBaGjzcNumber = 0
            End If
            If txtPrBaZjzcNumber.Text.Trim <> "" Then
                oProjectBasicInfo.PrBaZjzcNumber = txtPrBaZjzcNumber.Text.Trim
            Else
                oProjectBasicInfo.PrBaZjzcNumber = 0
            End If
            If txtPrBaCjzcNumber.Text.Trim <> "" Then
                oProjectBasicInfo.PrBaCjzcNumber = txtPrBaCjzcNumber.Text.Trim
            Else
                oProjectBasicInfo.PrBaCjzcNumber = 0
            End If
            If txtPrBaOtherNumber.Text.Trim <> "" Then
                oProjectBasicInfo.PrBaOtherNumber = txtPrBaOtherNumber.Text.Trim
            Else
                oProjectBasicInfo.PrBaOtherNumber = 0
            End If
           
            If txtPrBaYfztr.Text.Trim <> "" Then
                oProjectBasicInfo.PrBaYfztr = txtPrBaYfztr.Text.Trim
            Else
                oProjectBasicInfo.PrBaYfztr = 0
            End If
            If txtPrBaSczbk.Text.Trim <> "" Then
                oProjectBasicInfo.PrBaSczbk = txtPrBaSczbk.Text.Trim
            Else
                oProjectBasicInfo.PrBaSczbk = 0
            End If
            If txtPrBaQxczbk.Text.Trim <> "" Then
                oProjectBasicInfo.PrBaQxczbk = txtPrBaQxczbk.Text.Trim
            Else
                oProjectBasicInfo.PrBaQxczbk = 0
            End If
            If txtPrBaDwzc.Text.Trim <> "" Then
                oProjectBasicInfo.PrBaDwzc = txtPrBaDwzc.Text.Trim
            Else
                oProjectBasicInfo.PrBaDwzc = 0
            End If
            oProjectBasicInfo.PrBaKfxcp = txtPrBaKfxcp.Text.Trim
            oProjectBasicInfo.PrBaKfxgy = txtPrBaKfxgy.Text.Trim
            oProjectBasicInfo.PrBaKfxzb = txtPrBaKfxzb.Text.Trim
            oProjectBasicInfo.PrBaRjzscq = txtPrBaRjzscq.Text.Trim
            If txtPrBaQdzlx.Text.Trim <> "" Then
                oProjectBasicInfo.PrBaQdzlx = txtPrBaQdzlx.Text.Trim
            Else
                oProjectBasicInfo.PrBaQdzlx = 0
            End If
            If txtPrBaQzfmzlx.Text.Trim <> "" Then
                oProjectBasicInfo.PrBaQzfmzlx = txtPrBaQzfmzlx.Text.Trim
            Else
                oProjectBasicInfo.PrBaQzfmzlx = 0
            End If
            oProjectBasicInfo.PrBaJsbz = txtPrBaJsbz.Text.Trim
            oProjectBasicInfo.PrBaDzwxpz = txtPrBaDzwxpz.Text.Trim
            oProjectBasicInfo.PrBaYfOther = txtPrBaYfOther.Text.Trim
            If txtPrBaXzqy.Text.Trim <> "" Then
                oProjectBasicInfo.PrBaXzqy = txtPrBaXzqy.Text.Trim
            Else
                oProjectBasicInfo.PrBaXzqy = 0
            End If
            oProjectBasicInfo.PrBaXcscnl = txtPrBaXcscnl.Text.Trim
            If txtPrBaLdcytz.Text.Trim <> "" Then
                oProjectBasicInfo.PrBaLdcytz = txtPrBaLdcytz.Text.Trim
            Else
                oProjectBasicInfo.PrBaLdcytz = 0
            End If
            If txtPrBaXzxssr.Text.Trim <> "" Then
                oProjectBasicInfo.PrBaXzxssr = txtPrBaXzxssr.Text.Trim
            Else
                oProjectBasicInfo.PrBaXzxssr = 0
            End If
            If txtPrBaXzls.Text.Trim <> "" Then
                oProjectBasicInfo.PrBaXzls = txtPrBaXzls.Text.Trim
            Else
                oProjectBasicInfo.PrBaXzls = 0
            End If
            If txtPrBaCh.Text.Trim <> "" Then
                oProjectBasicInfo.PrBaCh = txtPrBaCh.Text.Trim
            Else
                oProjectBasicInfo.PrBaCh = 0
            End If
            If txtPrBaYjtt.Text.Trim <> "" Then
                oProjectBasicInfo.PrBaYjtt = txtPrBaYjtt.Text.Trim
            Else
                oProjectBasicInfo.PrBaYjtt = 0
            End If
            If txtPrBaYjrc.Text.Trim <> "" Then
                oProjectBasicInfo.PrBaYjrc = txtPrBaYjrc.Text.Trim
            Else
                oProjectBasicInfo.PrBaYjrc = 0
            End If
            Dim nReturnPrBaId As Integer = 0
            nReturnPrBaId = oProjectBasicInfo.Add(oProjectBasicInfo)
            If nReturnPrBaId <> 0 Then
                LogsOper.ShowInfotoWeb("添加成功！", upBasicPage)
            End If
        End If
    End Sub

    ''' <summary>
    ''' 更新项目信息
    ''' </summary>
    ''' <remarks></remarks>
    Sub updateProject()
        Dim oProjectInfo As New ProjectInfo
        Session("PrId") = gPrId
        oProjectInfo = oProjectInfo.GetToObj("PrId=" & gPrId)
        If Not oProjectInfo Is Nothing Then
            oProjectInfo.PrName = txtPrBaName.Text.Trim
            Dim nReturnPr As Integer = 0
            nReturnPr = oProjectInfo.Update(oProjectInfo)
            If nReturnPr <> 0 Then
                Dim oProjectBasicInfo As New ProjectBasicInfo
                oProjectBasicInfo = oProjectBasicInfo.GetToObj("PrId=" & gPrId)
                If Not oProjectBasicInfo Is Nothing Then
                    oProjectBasicInfo.PrId = gPrId
                    oProjectBasicInfo.PrBaClass = dpPrBaClass.SelectedValue
                    oProjectBasicInfo.PrBaYear = txtPrBaYear.Text.Trim
                    oProjectBasicInfo.PrBaName = txtPrBaName.Text.Trim
                    oProjectBasicInfo.PrBaApplyTime = txtPrBaApplyTime.Text.Trim
                    oProjectBasicInfo.PrBaArea = dpPrBaArea.SelectedValue
                    oProjectBasicInfo.ReUnId = dpReUnName.SelectedValue

                    oProjectBasicInfo.PrBaHostUnit = txtPrBaHostUnit.Text.Trim
                    oProjectBasicInfo.PrBaHostUnitClass = dpPrBaHostUnitClass.SelectedValue

                    oProjectBasicInfo.PrBaCooperationUnit = txtPrBaCooperationUnit.Text.Trim
                    oProjectBasicInfo.PrBaCooperationUnitClass = dpPrBaCooperationUnitClass.SelectedValue

                    oProjectBasicInfo.PrBaIsCxyhz = dpPrBaIsCxyhz.SelectedValue
                    oProjectBasicInfo.PrBaHzxs = dpPrBaHzxs.SelectedValue

                    oProjectBasicInfo.PrBaHostName = txtPrBaHostName.Text.Trim
                    oProjectBasicInfo.PrBaHostSex = dpPrBaHostSex.SelectedValue
                    oProjectBasicInfo.PrBaHostEducation = dpPrBaHostEducation.SelectedValue
                    oProjectBasicInfo.PrBaHostBirth = txtPrBaHostBirth.Text.Trim
                    oProjectBasicInfo.PrBaHostPosition = dpPrBaHostPosition.SelectedValue
                    oProjectBasicInfo.PrBaHostWorkPhone = txtPrBaHostWorkPhone.Text.Trim
                    oProjectBasicInfo.PrBaHostMobilePhone = txtPrBaHostMobilePhone.Text.Trim
                    oProjectBasicInfo.PrBaHostEmail = txtPrBaHostEmail.Text.Trim
                    If txtPrBaAllPeopleNumber.Text.Trim <> "" Then
                        oProjectBasicInfo.PrBaAllPeopleNumber = txtPrBaAllPeopleNumber.Text.Trim
                    Else
                        oProjectBasicInfo.PrBaAllPeopleNumber = 0
                    End If
                    If txtPrBaGjzcNumber.Text.Trim <> "" Then
                        oProjectBasicInfo.PrBaGjzcNumber = txtPrBaGjzcNumber.Text.Trim
                    Else
                        oProjectBasicInfo.PrBaGjzcNumber = 0
                    End If
                    If txtPrBaZjzcNumber.Text.Trim <> "" Then
                        oProjectBasicInfo.PrBaZjzcNumber = txtPrBaZjzcNumber.Text.Trim
                    Else
                        oProjectBasicInfo.PrBaZjzcNumber = 0
                    End If
                    If txtPrBaCjzcNumber.Text.Trim <> "" Then
                        oProjectBasicInfo.PrBaCjzcNumber = txtPrBaCjzcNumber.Text.Trim
                    Else
                        oProjectBasicInfo.PrBaCjzcNumber = 0
                    End If
                    If txtPrBaOtherNumber.Text.Trim <> "" Then
                        oProjectBasicInfo.PrBaOtherNumber = txtPrBaOtherNumber.Text.Trim
                    Else
                        oProjectBasicInfo.PrBaOtherNumber = 0
                    End If
                   
                    If txtPrBaYfztr.Text.Trim <> "" Then
                        oProjectBasicInfo.PrBaYfztr = txtPrBaYfztr.Text.Trim
                    Else
                        oProjectBasicInfo.PrBaYfztr = 0
                    End If
                    If txtPrBaSczbk.Text.Trim <> "" Then
                        oProjectBasicInfo.PrBaSczbk = txtPrBaSczbk.Text.Trim
                    Else
                        oProjectBasicInfo.PrBaSczbk = 0
                    End If
                    If txtPrBaQxczbk.Text.Trim <> "" Then
                        oProjectBasicInfo.PrBaQxczbk = txtPrBaQxczbk.Text.Trim
                    Else
                        oProjectBasicInfo.PrBaQxczbk = 0
                    End If
                    If txtPrBaDwzc.Text.Trim <> "" Then
                        oProjectBasicInfo.PrBaDwzc = txtPrBaDwzc.Text.Trim
                    Else
                        oProjectBasicInfo.PrBaDwzc = 0
                    End If
                    oProjectBasicInfo.PrBaKfxcp = txtPrBaKfxcp.Text.Trim
                    oProjectBasicInfo.PrBaKfxgy = txtPrBaKfxgy.Text.Trim
                    oProjectBasicInfo.PrBaKfxzb = txtPrBaKfxzb.Text.Trim
                    oProjectBasicInfo.PrBaRjzscq = txtPrBaRjzscq.Text.Trim
                    If txtPrBaQdzlx.Text.Trim <> "" Then
                        oProjectBasicInfo.PrBaQdzlx = txtPrBaQdzlx.Text.Trim
                    Else
                        oProjectBasicInfo.PrBaQdzlx = 0
                    End If
                    If txtPrBaQzfmzlx.Text.Trim <> "" Then
                        oProjectBasicInfo.PrBaQzfmzlx = txtPrBaQzfmzlx.Text.Trim
                    Else
                        oProjectBasicInfo.PrBaQzfmzlx = 0
                    End If
                    oProjectBasicInfo.PrBaJsbz = txtPrBaJsbz.Text.Trim
                    oProjectBasicInfo.PrBaDzwxpz = txtPrBaDzwxpz.Text.Trim
                    oProjectBasicInfo.PrBaYfOther = txtPrBaYfOther.Text.Trim
                    If txtPrBaXzqy.Text.Trim <> "" Then
                        oProjectBasicInfo.PrBaXzqy = txtPrBaXzqy.Text.Trim
                    Else
                        oProjectBasicInfo.PrBaXzqy = 0
                    End If
                    oProjectBasicInfo.PrBaXcscnl = txtPrBaXcscnl.Text.Trim
                    If txtPrBaLdcytz.Text.Trim <> "" Then
                        oProjectBasicInfo.PrBaLdcytz = txtPrBaLdcytz.Text.Trim
                    Else
                        oProjectBasicInfo.PrBaLdcytz = 0
                    End If
                    If txtPrBaXzxssr.Text.Trim <> "" Then
                        oProjectBasicInfo.PrBaXzxssr = txtPrBaXzxssr.Text.Trim
                    Else
                        oProjectBasicInfo.PrBaXzxssr = 0
                    End If
                    If txtPrBaXzls.Text.Trim <> "" Then
                        oProjectBasicInfo.PrBaXzls = txtPrBaXzls.Text.Trim
                    Else
                        oProjectBasicInfo.PrBaXzls = 0
                    End If
                    If txtPrBaCh.Text.Trim <> "" Then
                        oProjectBasicInfo.PrBaCh = txtPrBaCh.Text.Trim
                    Else
                        oProjectBasicInfo.PrBaCh = 0
                    End If
                    If txtPrBaYjtt.Text.Trim <> "" Then
                        oProjectBasicInfo.PrBaYjtt = txtPrBaYjtt.Text.Trim
                    Else
                        oProjectBasicInfo.PrBaYjtt = 0
                    End If
                    If txtPrBaYjrc.Text.Trim <> "" Then
                        oProjectBasicInfo.PrBaYjrc = txtPrBaYjrc.Text.Trim
                    Else
                        oProjectBasicInfo.PrBaYjrc = 0
                    End If
                    Dim nReturnPrBa As Integer = 0
                    nReturnPrBa = oProjectBasicInfo.Update(oProjectBasicInfo)
                    If nReturnPrBa <> 0 Then
                        LogsOper.ShowInfotoWeb("修改成功！", upBasicPage)
                    End If
                End If
            End If
        End If

    End Sub

End Class
