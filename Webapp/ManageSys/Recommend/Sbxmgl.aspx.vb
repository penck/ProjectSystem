Imports System.Web.Services
Imports ProjectData
Imports SysOpProvider

Partial Class ManageSys_Recommend_Sbxmgl
    Inherits System.Web.UI.Page

    Public gUser As New User
    Public gReUnId As Integer

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            gUser = gUser.GetUserBySession("UsName")
            If Not gUser Is Nothing Then
                Dim gUsCompany As String
                gUsCompany = gUser.UsCompany
                Dim oRecommendUnit As New RecommendUnit
                oRecommendUnit = oRecommendUnit.GetToObj("ReUnName='" & gUsCompany & "'")
                If Not oRecommendUnit Is Nothing Then
                    gReUnId = oRecommendUnit.ReUnId
                End If
            End If
            If Not IsPostBack Then
                '绑定数据到gvProject中去
                BindDataToSubmit()
                BindDataToRecommend()
            End If
        Catch ex As Exception

        End Try
    End Sub
    ''' <summary>
    ''' 绑定数据到gvProject中去
    ''' </summary>
    ''' <remarks></remarks>
    Sub BindDataToSubmit()
        Dim oProjectRecommend As New ProjectRecommend
        Dim nCondition As String = ""
        nCondition = "(PrStatus='提交预审' or PrStatus='预推荐通过') and ReUnId='" & gReUnId & "' and PrBaYear='" & Now.Year.ToString & "'"
        gvProjectSubmit.Columns(0).Visible = True
        gvProjectSubmit.DataSource = oProjectRecommend.GetToDV(nCondition)
        gvProjectSubmit.DataBind()
        gvProjectSubmit.Columns(0).Visible = False
    End Sub

    ''' <summary>
    ''' 绑定数据到gvProject中去
    ''' </summary>
    ''' <remarks></remarks>
    Sub BindDataToRecommend()
        Dim oProjectRecommend As New ProjectRecommend
        Dim nCondition As String = ""
        nCondition = "(PrStatus='预审通过' or PrStatus='已推荐') and ReUnId='" & gReUnId & "' and PrBaYear='" & Now.Year.ToString & "' order by PrReNo asc"
        gvProjectRecommend.Columns(0).Visible = True
        gvProjectRecommend.DataSource = oProjectRecommend.GetToDV(nCondition)
        gvProjectRecommend.DataBind()
        gvProjectRecommend.Columns(0).Visible = False
    End Sub

    Protected Sub gvProjectSubmit_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvProjectSubmit.RowCommand
        Try
            Dim nPrId As Integer = gvProjectSubmit.DataKeys(e.CommandArgument).Value.ToString
            Dim nPrStatus As String = gvProjectSubmit.Rows(e.CommandArgument).Cells(5).Text.Trim
            If e.CommandName = "RecommendPrName" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(upSubmitPage, Me.GetType, "click", "javascript:window.top.open('ShowDetail.aspx?id=" & nPrId & "');", True)
            ElseIf e.CommandName = "RecommendPrepare" Then
                If nPrStatus = "预推荐通过" Then
                    LogsOper.ShowInfotoWeb("该项目预推荐已经通过！", upSubmitPage)
                    Exit Sub
                End If
                Dim oProjectInfo As New ProjectInfo
                oProjectInfo = oProjectInfo.GetToObj("PrId=" & nPrId)
                If Not oProjectInfo Is Nothing Then
                    oProjectInfo.PrStatus = "预推荐通过"
                    oProjectInfo.Update(oProjectInfo)
                    LogsOper.ShowInfotoWeb("预推荐通过！", upSubmitPage)
                    BindDataToSubmit()
                End If
            ElseIf e.CommandName = "RecommendCancel" Then
                If nPrStatus = "预推荐通过" Then
                    Dim oProjectInfo As New ProjectInfo
                    oProjectInfo = oProjectInfo.GetToObj("PrId=" & nPrId)
                    If Not oProjectInfo Is Nothing Then
                        oProjectInfo.PrStatus = "提交预审"
                        oProjectInfo.Update(oProjectInfo)
                        LogsOper.ShowInfotoWeb("退回成功！", upSubmitPage)
                        BindDataToSubmit()
                    End If
                ElseIf nPrStatus = "提交预审" Then
                    Dim oProjectInfo As New ProjectInfo
                    oProjectInfo = oProjectInfo.GetToObj("PrId=" & nPrId)
                    If Not oProjectInfo Is Nothing Then
                        oProjectInfo.PrStatus = "未提交"
                        oProjectInfo.Update(oProjectInfo)
                        LogsOper.ShowInfotoWeb("退回成功！", upSubmitPage)
                        BindDataToSubmit()
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub gvProjectRecommend_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvProjectRecommend.RowCommand
        Try
            Dim nPrId As Integer = gvProjectRecommend.DataKeys(e.CommandArgument).Value.ToString
            Dim nPrStatus As String = gvProjectRecommend.Rows(e.CommandArgument).Cells(5).Text.Trim
            If e.CommandName = "RecommendPrName" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(upRecommendPage, Me.GetType, "click", "javascript:window.top.open('ShowDetail.aspx?id=" & nPrId & "');", True)
            ElseIf e.CommandName = "RecommendNum" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(upRecommendPage, Me.GetType, "click", "javascript:if(showModalDialog('Form_RecommendNum.aspx?id=" & nPrId & "','newwindow','dialogHeight:260px;dialogWidth:400px; dialogTop:screen.height/8;dialogLeft:screen.width/8; edge:sunken ; center: Yes; help: No; resizable: No; status: No; scroll:yes;')){window.location.href =window.location.href;window.location.reload();}", True)
                'BindData()
            ElseIf e.CommandName = "RecommendYes" Then
                If nPrStatus <> "预审通过" Then
                    LogsOper.ShowInfotoWeb("此项目不可推荐！", upRecommendPage)
                    Exit Sub
                End If
                System.Web.UI.ScriptManager.RegisterStartupScript(upRecommendPage, Me.GetType, "click", "javascript:if(showModalDialog('Form_RecommendYes.aspx?id=" & nPrId & "','newwindow','dialogHeight:260px;dialogWidth:400px; dialogTop:screen.height/8;dialogLeft:screen.width/8; edge:sunken ; center: Yes; help: No; resizable: No; status: No; scroll:yes;')){window.location.href =window.location.href;window.location.reload();}", True)
                'BindData()
            ElseIf e.CommandName = "RecommendNo" Then
                If nPrStatus <> "预审通过" Then
                    LogsOper.ShowInfotoWeb("此项目不可退回！", upRecommendPage)
                    Exit Sub
                End If
                System.Web.UI.ScriptManager.RegisterStartupScript(upRecommendPage, Me.GetType, "click", "javascript:if(showModalDialog('Form_RecommendNo.aspx?id=" & nPrId & "','newwindow','dialogHeight:260px;dialogWidth:400px; dialogTop:screen.height/8;dialogLeft:screen.width/8; edge:sunken ; center: Yes; help: No; resizable: No; status: No; scroll:yes;')){window.location.href =window.location.href;window.location.reload();}", True)
                'BindData()
            End If
        Catch ex As Exception

        End Try
    End Sub

    
End Class
