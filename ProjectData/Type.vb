Imports DBOpProvider
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Web.UI.WebControls
Imports System.Web.HttpContext

Public Class Type

#Region "类属性"

    Private _TyId As Integer
    Private _TyName As String
    Private _TyClass As String

    Public Property TyId() As Integer
        Get
            TyId = _TyId
        End Get
        Set(ByVal value As Integer)
            _TyId = value
        End Set
    End Property

    Public Property TyName() As String
        Get
            TyName = _TyName
        End Get
        Set(ByVal value As String)
            _TyName = value
        End Set
    End Property

    Public Property TyClass() As String
        Get
            TyClass = _TyClass
        End Get
        Set(ByVal value As String)
            _TyClass = value
        End Set
    End Property

#End Region

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
            nSql = "Select * from [Type] " & nCondition
            Dim oDataTable As New DataTable
            oSqlHelper.RunSqlDataViewOrTable(nSql, oDataTable)
            If Not oDataTable Is Nothing AndAlso oDataTable.Rows.Count > 0 Then
                Dim oLOLIT As New List(Of ListItem)
                For Each oDataRow In oDataTable.Rows
                    Dim oListItem As New ListItem
                    oListItem.Text = oDataRow.Item("TyName")
                    oListItem.Value = oDataRow.Item("TyId")
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

    ''' <summary>
    ''' 根据条件获取Type对象。
    ''' </summary>
    ''' <param name="cCondition">sql条件</param>
    ''' <returns>Type对象。</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function GetToObj(Optional ByVal cCondition As String = "") As Type
        Try
            Dim nCondition As String = ""
            If cCondition <> "" Then
                nCondition = "where " & cCondition
            End If
            Dim nSql As String = ""
            nSql = "select * from [Type] " & nCondition
            Dim oSqlherlper As New SqlHelper
            Dim oDatatable As New DataTable
            oSqlherlper.RunSqlDataViewOrTable(nSql, oDatatable)
            If Not oDatatable Is Nothing AndAlso oDatatable.Rows.Count <> 0 Then
                Dim oType As New Type
                oType.TyId = oDatatable.Rows(0).Item("TyId")
                oType.TyName = oDatatable.Rows(0).Item("TyName")
                oType.TyClass = oDatatable.Rows(0).Item("TyClass")
                Return oType
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
