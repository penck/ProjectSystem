Imports DBOpProvider
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Web.UI.WebControls
Imports System.Web.HttpContext

Public Class ProjectInfo

#Region "类属性"

    Private _PrId As Integer
    Private _PrName As String
    Private _PrStatus As String
    Private _PrAddTime As DateTime
    Private _UsId As Integer

    Public Property PrId() As Integer
        Get
            PrId = _PrId
        End Get
        Set(ByVal value As Integer)
            _PrId = value
        End Set
    End Property

    Public Property PrName() As String
        Get
            PrName = _PrName
        End Get
        Set(ByVal value As String)
            _PrName = value
        End Set
    End Property

    Public Property PrStatus() As String
        Get
            PrStatus = _PrStatus
        End Get
        Set(ByVal value As String)
            _PrStatus = value
        End Set
    End Property

    Public Property PrAddTime() As DateTime
        Get
            PrAddTime = _PrAddTime
        End Get
        Set(ByVal value As DateTime)
            _PrAddTime = value
        End Set
    End Property

    Public Property UsId() As Integer
        Get
            UsId = _UsId
        End Get
        Set(ByVal value As Integer)
            _UsId = value
        End Set
    End Property

#End Region

    ''' <summary>
    ''' 根据类对象插入数据，返回值为生成的记录编号（即PrId值），如果返回值为0表示插入未成功。
    ''' </summary>
    ''' <param name="cObject">ProjectInfo类对象</param>
    ''' <returns>生成的记录编号（即PrId值）</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function Add(ByVal cObject As ProjectInfo) As Integer
        Try
            Dim nSql As String = ""
            nSql = "insert into [ProjectInfo] ("
            nSql &= "PrName,"
            nSql &= "PrStatus,"
            nSql &= "PrAddTime,"
            nSql &= "UsId"
            nSql &= " ) Values("
            nSql &= " '" & cObject.PrName & "',"
            nSql &= " '" & cObject.PrStatus & "',"
            nSql &= " '" & cObject.PrAddTime & "',"
            nSql &= " '" & cObject.UsId & "'"
            nSql &= ")"
            Dim nReturnValue As Integer = 0
            Dim oSqlHelper As New SqlHelper
            oSqlHelper.RunSqlExec(nSql, nReturnValue)
            If nReturnValue > 0 Then
                nSql = "select max(PrId) from [ProjectInfo]"
                Dim oDatatable As New DataTable
                oSqlHelper.RunSqlDataViewOrTable(nSql, oDatatable)
                Return oDatatable.Rows(0).Item(0)
            Else
                Return 0
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' 根据条件删除表中记录，返回删除的行数。
    ''' </summary>
    ''' <param name="cCondition">sql条件</param>
    ''' <returns>删除的行数</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function Delete(ByVal cCondition As String) As Integer
        Try
            Dim oSqlHelper As New SqlHelper
            Dim nSql As String = ""
            nSql = "Delete from [ProjectInfo]"
            nSql &= " where " & cCondition
            Dim nReturnValue As Integer = 0
            oSqlHelper.RunSqlExec(nSql, nReturnValue)
            Return nReturnValue
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' 根据类对象更新数据，返回更新的行数。
    ''' </summary>
    ''' <param name="cObject">ProjectInfo类对象</param>
    ''' <returns>更新的行数</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function Update(ByVal cObject As ProjectInfo) As Integer
        Try
            Dim oSqlHelper As New SqlHelper
            Dim nSql As String = ""
            nSql = "Update [ProjectInfo] Set "
            nSql &= "PrName='" & cObject.PrName & "',"
            nSql &= "PrStatus='" & cObject.PrStatus & "',"
            nSql &= "PrAddTime='" & cObject.PrAddTime & "',"
            nSql &= "UsId='" & cObject.UsId & "'"
            nSql &= "Where "
            nSql &= "PrId='" & cObject.PrId & "'"
            Dim nReturnValue As Integer = 0
            oSqlHelper.RunSqlExec(nSql, nReturnValue)
            Return nReturnValue
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' 根据条件获取ProjectInfo对象。
    ''' </summary>
    ''' <param name="cCondition">sql条件</param>
    ''' <returns>ProjectInfo对象。</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function GetToObj(Optional ByVal cCondition As String = "") As ProjectInfo
        Try
            Dim nCondition As String = ""
            If cCondition <> "" Then
                nCondition = "where " & cCondition
            End If
            Dim nSql As String = ""
            nSql = "select * from [ProjectInfo] " & nCondition
            Dim oSqlherlper As New SqlHelper
            Dim oDatatable As New DataTable
            oSqlherlper.RunSqlDataViewOrTable(nSql, oDatatable)
            If Not oDatatable Is Nothing AndAlso oDatatable.Rows.Count <> 0 Then
                Dim oProjectInfo As New ProjectInfo
                oProjectInfo.PrId = oDatatable.Rows(0).Item("PrId")
                oProjectInfo.PrName = oDatatable.Rows(0).Item("PrName")
                oProjectInfo.PrStatus = oDatatable.Rows(0).Item("PrStatus")
                oProjectInfo.PrAddTime = oDatatable.Rows(0).Item("PrAddTime")
                oProjectInfo.UsId = oDatatable.Rows(0).Item("UsId")
                Return oProjectInfo
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' 根据条件获取Dataview类对象
    ''' </summary>
    ''' <param name="cCondition">sql条件</param>
    ''' <returns>Dataview类对象</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function GetToDV(Optional ByVal cCondition As String = "") As DataView
        Try
            Dim nCondition As String = ""
            If cCondition <> "" Then
                nCondition = "where " & cCondition
            End If
            Dim nSql As String = ""
            nSql = "select * from [ProjectInfo] " & nCondition
            Dim oSqlherlper As New SqlHelper
            Dim oDataView As New DataView
            oSqlherlper.RunSqlDataViewOrTable(nSql, , oDataView)
            If Not oDataView Is Nothing AndAlso oDataView.Count <> 0 Then
                Return oDataView
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' 根据条件获取ProjectInfo对象。
    ''' </summary>
    ''' <param name="cCondition">sql条件</param>
    ''' <returns>ProjectInfo对象。</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function GetToTopOneObj(Optional ByVal cCondition As String = "") As ProjectInfo
        Try
            Dim nCondition As String = ""
            If cCondition <> "" Then
                nCondition = "where " & cCondition
            End If
            Dim nSql As String = ""
            nSql = "select top 1 * from [ProjectInfo] " & nCondition
            Dim oSqlherlper As New SqlHelper
            Dim oDatatable As New DataTable
            oSqlherlper.RunSqlDataViewOrTable(nSql, oDatatable)
            If Not oDatatable Is Nothing AndAlso oDatatable.Rows.Count <> 0 Then
                Dim oProjectInfo As New ProjectInfo
                oProjectInfo.PrId = oDatatable.Rows(0).Item("PrId")
                oProjectInfo.PrName = oDatatable.Rows(0).Item("PrName")
                oProjectInfo.PrStatus = oDatatable.Rows(0).Item("PrStatus")
                oProjectInfo.PrAddTime = oDatatable.Rows(0).Item("PrAddTime")
                oProjectInfo.UsId = oDatatable.Rows(0).Item("UsId")
                Return oProjectInfo
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
