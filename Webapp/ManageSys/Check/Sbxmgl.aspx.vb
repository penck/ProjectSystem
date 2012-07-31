Imports System.Web.Services
Imports ProjectData
Imports SysOpProvider

Partial Class ManageSys_Check_Sbxmgl
    Inherits System.Web.UI.Page

    Public gUser As New User
    Public gReUnId As Integer

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            gUser = gUser.GetUserBySession("UsName")
            If Not IsPostBack Then
                '绑定数据到gvProject中去
                BindDataToSubmit()
                BindDataToRecommend()
                BindDataToPrepare()

                Dim oRecommendUnit As New RecommendUnit
                Dim datasource As List(Of ListItem) = oRecommendUnit.GetToLOLIT()
                ddlRecUnit.DataSource = datasource
                ddlRecUnit.DataTextField = "Text"
                ddlRecUnit.DataValueField = "Value"
                ddlRecUnit.DataBind()
                ddlRecUnit.Items.Insert(0, New ListItem("", ""))
                ddlRecUnit.Items(0).Selected = True

                ddlRecUnit2.DataSource = datasource
                ddlRecUnit2.DataTextField = "Text"
                ddlRecUnit2.DataValueField = "Value"
                ddlRecUnit2.DataBind()
                ddlRecUnit2.Items.Insert(0, New ListItem("", ""))
                ddlRecUnit2.Items(0).Selected = True

                ddlRecUnit3.DataSource = datasource
                ddlRecUnit3.DataTextField = "Text"
                ddlRecUnit3.DataValueField = "Value"
                ddlRecUnit3.DataBind()
                ddlRecUnit3.Items.Insert(0, New ListItem("", ""))
                ddlRecUnit3.Items(0).Selected = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' 绑定数据到gvProjectSubmit中去
    ''' </summary>
    ''' <remarks></remarks>
    Sub BindDataToSubmit(Optional ByVal cCondition As String = "")
        Dim oProjectRecommend As New ProjectRecommend
        Dim nCondition As String = ""
        If cCondition <> "" Then
            nCondition = cCondition & " and PrStatus='提交预审' and PrBaYear='" & Now.Year.ToString & "'"
        Else
            nCondition = "PrStatus='提交预审' and PrBaYear='" & Now.Year.ToString & "'"
        End If
        gvProjectSubmit.Columns(0).Visible = True
        gvProjectSubmit.DataSource = oProjectRecommend.GetToDV(nCondition)
        gvProjectSubmit.DataBind()
        gvProjectSubmit.Columns(0).Visible = False
    End Sub

    ''' <summary>
    ''' 绑定数据到gvProjectRecommend中去
    ''' </summary>
    ''' <remarks></remarks>
    Sub BindDataToRecommend(Optional ByVal cCondition As String = "")
        Dim oProjectRecommend As New ProjectRecommend
        Dim nCondition As String = ""
        If cCondition <> "" Then
            nCondition = cCondition & " and PrStatus='已推荐' and PrBaYear='" & Now.Year.ToString & "' order by PrReNo asc"
        Else
            nCondition = "PrStatus='已推荐' and PrBaYear='" & Now.Year.ToString & "'"
        End If
        gvProjectRecommend.Columns(0).Visible = True
        gvProjectRecommend.DataSource = oProjectRecommend.GetToDV(nCondition)
        gvProjectRecommend.DataBind()
        gvProjectRecommend.Columns(0).Visible = False
    End Sub

    ''' <summary>
    ''' 绑定数据到gvProject中去
    ''' </summary>
    ''' <remarks></remarks>
    Sub BindDataToPrepare(Optional ByVal cCondition As String = "")
        Dim oProjectRecommend As New ProjectRecommend
        Dim nCondition As String = ""
        If cCondition <> "" Then
            nCondition = cCondition & " and (PrStatus='预推荐通过' or PrStatus='预审通过') and PrBaYear='" & Now.Year.ToString & "'"
        Else
            nCondition = "PrStatus='预推荐通过' and PrBaYear='" & Now.Year.ToString & "'"
        End If
        gvProjectPrepare.Columns(0).Visible = True
        gvProjectPrepare.DataSource = oProjectRecommend.GetToDV(nCondition)
        gvProjectPrepare.DataBind()
        gvProjectPrepare.Columns(0).Visible = False
    End Sub

    Protected Sub gvProjectSubmit_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvProjectSubmit.RowCommand
        Try
            Dim nPrId As Integer = gvProjectSubmit.DataKeys(e.CommandArgument).Value.ToString
            System.Web.UI.ScriptManager.RegisterStartupScript(upSubmitPage, Me.GetType, "click", "javascript:window.top.open('ShowDetail.aspx?id=" & nPrId & "');", True)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub gvProjectRecommend_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvProjectRecommend.RowCommand
        Try
            Dim nPrId As Integer = gvProjectRecommend.DataKeys(e.CommandArgument).Value.ToString
            Dim nPrStatus As String = gvProjectRecommend.Rows(e.CommandArgument).Cells(5).Text.Trim
            If e.CommandName = "RecommendPrName" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(upRecommendPage, Me.GetType, "click", "javascript:window.top.open('ShowDetail.aspx?id=" & nPrId & "');", True)
            ElseIf e.CommandName = "Lixiang" Then
                LogsOper.ShowInfotoWeb("暂时还没有开放立项功能！", upPreparePage)
                Exit Sub
            ElseIf e.CommandName = "Tuihui" Then
                If nPrStatus = "已推荐" Then
                    Dim oProjectInfo As New ProjectInfo
                    oProjectInfo = oProjectInfo.GetToObj("PrId=" & nPrId)
                    If Not oProjectInfo Is Nothing Then
                        oProjectInfo.PrStatus = "预审通过"
                        oProjectInfo.Update(oProjectInfo)
                        LogsOper.ShowInfotoWeb("操作成功！", upPreparePage)
                        BindDataToRecommend()
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub btnSearch_Click(sender As Object, e As System.EventArgs) Handles btnSearch.Click
        Dim nCondition As String = ""
        If txtPrBaHostUnit.Text.Trim = "" Then
            nCondition = ""
        Else
            nCondition = "PrBaHostUnit like '%" & txtPrBaHostUnit.Text.Trim & "%' "
        End If

        If ddlRecUnit.SelectedValue <> "" Then
            If nCondition.Length > 0 Then
                nCondition += " and "
            End If
            nCondition += " ReUnId = " & ddlRecUnit.SelectedValue
        End If
        BindDataToSubmit(nCondition)
    End Sub

    Protected Sub btnSearch2_Click(sender As Object, e As System.EventArgs) Handles btnSearch2.Click
        Dim nCondition As String = ""
        If txtPrBaHostUnit2.Text.Trim = "" Then
            nCondition = ""
        Else
            nCondition = "PrBaHostUnit like '%" & txtPrBaHostUnit2.Text.Trim & "%'"
        End If

        If ddlRecUnit2.SelectedValue <> "" Then
            If nCondition.Length > 0 Then
                nCondition += " and "
            End If
            nCondition += " ReUnId = " & ddlRecUnit2.SelectedValue
        End If
        BindDataToRecommend(nCondition)
    End Sub


    Protected Sub gvProjectPrepare_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvProjectPrepare.RowCommand
        Try
            Dim nPrId As Integer = gvProjectPrepare.DataKeys(e.CommandArgument).Value.ToString
            Dim nPrStatus As String = gvProjectPrepare.Rows(e.CommandArgument).Cells(5).Text.Trim
            If e.CommandName = "CheckYes" Then
                Dim oProjectInfo As New ProjectInfo
                oProjectInfo = oProjectInfo.GetToObj("PrId=" & nPrId)
                If Not oProjectInfo Is Nothing Then
                    oProjectInfo.PrStatus = "预审通过"
                    oProjectInfo.Update(oProjectInfo)
                    LogsOper.ShowInfotoWeb("预审通过！", upPreparePage)
                    BindDataToPrepare()
                End If
            ElseIf e.CommandName = "CheckNo" Then
                If nPrStatus = "预推荐通过" Then
                    Dim oProjectInfo As New ProjectInfo
                    oProjectInfo = oProjectInfo.GetToObj("PrId=" & nPrId)
                    If Not oProjectInfo Is Nothing Then
                        oProjectInfo.PrStatus = "提交预审"
                        oProjectInfo.Update(oProjectInfo)
                        LogsOper.ShowInfotoWeb("操作成功！", upPreparePage)
                        BindDataToPrepare()
                    End If
                ElseIf nPrStatus = "预审通过" Then
                    Dim oProjectInfo As New ProjectInfo
                    oProjectInfo = oProjectInfo.GetToObj("PrId=" & nPrId)
                    If Not oProjectInfo Is Nothing Then
                        oProjectInfo.PrStatus = "预推荐通过"
                        oProjectInfo.Update(oProjectInfo)
                        LogsOper.ShowInfotoWeb("操作成功！", upPreparePage)
                        BindDataToPrepare()
                    End If
                End If
            ElseIf e.CommandName = "PreparePrName" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(upPreparePage, Me.GetType, "click", "javascript:window.top.open('ShowDetail.aspx?id=" & nPrId & "');", True)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub btnSearch3_Click(sender As Object, e As System.EventArgs) Handles btnSearch3.Click
        Dim nCondition As String = ""
        If txtPrBaHostUnit3.Text.Trim = "" Then
            nCondition = ""
        Else
            nCondition = "PrBaHostUnit like '%" & txtPrBaHostUnit3.Text.Trim & "%'"
        End If
         
        If ddlRecUnit3.SelectedValue <> "" Then
            If nCondition.Length > 0 Then
                nCondition += " and "
            End If
            nCondition += " ReUnId = " & ddlRecUnit3.SelectedValue
        End If
        BindDataToPrepare(nCondition)
    End Sub


End Class
