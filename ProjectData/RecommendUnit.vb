Imports DBOpProvider
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Web.UI.WebControls
Imports System.Web.HttpContext

Public Class RecommendUnit

#Region "类属性"

    Private _ReUnId As Integer
    Private _ReUnTypeId As Integer
    Private _ReUnName As String

    Public Property ReUnId() As Integer
        Get
            ReUnId = _ReUnId
        End Get
        Set(ByVal value As Integer)
            _ReUnId = value
        End Set
    End Property

    Public Property ReUnTypeId() As Integer
        Get
            ReUnTypeId = _ReUnTypeId
        End Get
        Set(ByVal value As Integer)
            _ReUnTypeId = value
        End Set
    End Property

    Public Property ReUnName() As String
        Get
            ReUnName = _ReUnName
        End Get
        Set(ByVal value As String)
            _ReUnName = value
        End Set
    End Property

#End Region

    ''' <summary>
    ''' 根据条件获取RecommendUnit对象。
    ''' </summary>
    ''' <param name="cCondition">sql条件</param>
    ''' <returns>RecommendUnit对象。</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function GetToObj(Optional ByVal cCondition As String = "") As RecommendUnit
        Try
            Dim nCondition As String = ""
            If cCondition <> "" Then
                nCondition = "where " & cCondition
            End If
            Dim nSql As String = ""
            nSql = "select * from [RecommendUnit] " & nCondition
            Dim oSqlherlper As New SqlHelper
            Dim oDatatable As New DataTable
            oSqlherlper.RunSqlDataViewOrTable(nSql, oDatatable)
            If Not oDatatable Is Nothing AndAlso oDatatable.Rows.Count <> 0 Then
                Dim oRecommendUnit As New RecommendUnit
                oRecommendUnit.ReUnId = oDatatable.Rows(0).Item("ReUnId")
                oRecommendUnit.ReUnTypeId = oDatatable.Rows(0).Item("ReUnTypeId")
                oRecommendUnit.ReUnName = oDatatable.Rows(0).Item("ReUnName")
                Return oRecommendUnit
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' 根据条件获取List(Of ListItem)类对象
    ''' </summary>
    ''' <param name="cCondition">sql条件</param>
    ''' <returns>List(Of ListItem)类对象</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function GetToLOLIT(Optional ByVal cCondition As String = "") As List(Of ListItem)
        Try
            Dim nCondition As String = ""
            If cCondition <> "" Then
                nCondition = " where  " & cCondition
            End If
            Dim oSqlHelper As New SqlHelper
            Dim nSql As String = ""
            nSql = "Select * from [RecommendUnit] " & nCondition
            Dim oDataTable As New DataTable
            oSqlHelper.RunSqlDataViewOrTable(nSql, oDataTable)
            If Not oDataTable Is Nothing AndAlso oDataTable.Rows.Count > 0 Then
                Dim oLOLIT As New List(Of ListItem)
                For Each oDataRow In oDataTable.Rows
                    Dim oListItem As New ListItem
                    oListItem.Text = oDataRow.Item("ReUnName")
                    oListItem.Value = oDataRow.Item("ReUnId")
                    oLOLIT.Add(oListItem)
                Next
                Return oLOLIT
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class
