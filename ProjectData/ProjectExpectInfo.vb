Imports DBOpProvider
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Web.HttpContext
Imports System.Web.UI.WebControls

Public Class ProjectExpectInfo

#Region "类属性"

    Private _PrExId As Integer
    Private _PrId As Integer
    Private _PrExWcsj As DateTime
    Private _PrExZyyjnr As String
    Private _PrExYqmb As String
    Private _PrExDwzhqc As String
    Private _PrExKhhqc As String
    Private _PrExKhhzh As String

    Public Property PrExId() As Integer
        Get
            PrExId = _PrExId
        End Get
        Set(ByVal value As Integer)
            _PrExId = value
        End Set
    End Property

    Public Property PrId() As Integer
        Get
            PrId = _PrId
        End Get
        Set(ByVal value As Integer)
            _PrId = value
        End Set
    End Property

    Public Property PrExWcsj() As DateTime
        Get
            PrExWcsj = _PrExWcsj
        End Get
        Set(ByVal value As DateTime)
            _PrExWcsj = value
        End Set
    End Property

    Public Property PrExZyyjnr() As String
        Get
            PrExZyyjnr = _PrExZyyjnr
        End Get
        Set(ByVal value As String)
            _PrExZyyjnr = value
        End Set
    End Property

    Public Property PrExYqmb() As String
        Get
            PrExYqmb = _PrExYqmb
        End Get
        Set(ByVal value As String)
            _PrExYqmb = value
        End Set
    End Property

    Public Property PrExDwzhqc() As String
        Get
            PrExDwzhqc = _PrExDwzhqc
        End Get
        Set(ByVal value As String)
            _PrExDwzhqc = value
        End Set
    End Property

    Public Property PrExKhhqc() As String
        Get
            PrExKhhqc = _PrExKhhqc
        End Get
        Set(ByVal value As String)
            _PrExKhhqc = value
        End Set
    End Property

    Public Property PrExKhhzh() As String
        Get
            PrExKhhzh = _PrExKhhzh
        End Get
        Set(ByVal value As String)
            _PrExKhhzh = value
        End Set
    End Property

#End Region

    ''' <summary>
    ''' 根据类对象插入数据，返回值为生成的记录编号（即PrExId值），如果返回值为0表示插入未成功。
    ''' </summary>
    ''' <param name="cObject">ProjectExpectInfo类对象</param>
    ''' <returns>生成的记录编号（即PrExId值）</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function Add(ByVal cObject As ProjectExpectInfo) As Integer
        Try
            Dim nSql As String = ""
            nSql = "insert into [ProjectExpectInfo] ("
            nSql &= "PrId,"
            nSql &= "PrExWcsj,"
            nSql &= "PrExZyyjnr,"
            nSql &= "PrExYqmb,"
            nSql &= "PrExDwzhqc,"
            nSql &= "PrExKhhqc,"
            nSql &= "PrExKhhzh"
            nSql &= " ) Values("
            nSql &= " '" & cObject.PrId & "',"
            nSql &= " '" & cObject.PrExWcsj & "',"
            nSql &= " '" & cObject.PrExZyyjnr & "',"
            nSql &= " '" & cObject.PrExYqmb & "',"
            nSql &= " '" & cObject.PrExDwzhqc & "',"
            nSql &= " '" & cObject.PrExKhhqc & "',"
            nSql &= " '" & cObject.PrExKhhzh & "'"
            nSql &= ")"
            Dim nReturnValue As Integer = 0
            Dim oSqlHelper As New SqlHelper
            oSqlHelper.RunSqlExec(nSql, nReturnValue)
            If nReturnValue > 0 Then
                nSql = "select max(PrExId) from [ProjectExpectInfo]"
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
            nSql = "Delete from [ProjectExpectInfo]"
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
    ''' <param name="cObject">ProjectExpectInfo类对象</param>
    ''' <returns>更新的行数</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function Update(ByVal cObject As ProjectExpectInfo) As Integer
        Try
            Dim oSqlHelper As New SqlHelper
            Dim nSql As String = ""
            nSql = "Update [ProjectExpectInfo] Set "
            nSql &= "PrId='" & cObject.PrId & "',"
            nSql &= "PrExWcsj='" & cObject.PrExWcsj & "',"
            nSql &= "PrExZyyjnr='" & cObject.PrExZyyjnr & "',"
            nSql &= "PrExYqmb='" & cObject.PrExYqmb & "',"
            nSql &= "PrExDwzhqc='" & cObject.PrExDwzhqc & "',"
            nSql &= "PrExKhhqc='" & cObject.PrExKhhqc & "',"
            nSql &= "PrExKhhzh='" & cObject.PrExKhhzh & "'"
            nSql &= "Where "
            nSql &= "PrExId='" & cObject.PrExId & "'"
            Dim nReturnValue As Integer = 0
            oSqlHelper.RunSqlExec(nSql, nReturnValue)
            Return nReturnValue
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' 根据条件获取ProjectExpectInfo对象。
    ''' </summary>
    ''' <param name="cCondition">sql条件</param>
    ''' <returns>ProjectExpectInfo对象。</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function GetToObj(Optional ByVal cCondition As String = "") As ProjectExpectInfo
        Try
            Dim nCondition As String = ""
            If cCondition <> "" Then
                nCondition = "where " & cCondition
            End If
            Dim nSql As String = ""
            nSql = "select * from [ProjectExpectInfo] " & nCondition
            Dim oSqlherlper As New SqlHelper
            Dim oDatatable As New DataTable
            oSqlherlper.RunSqlDataViewOrTable(nSql, oDatatable)
            If Not oDatatable Is Nothing AndAlso oDatatable.Rows.Count <> 0 Then
                Dim oProjectExpectInfo As New ProjectExpectInfo
                oProjectExpectInfo.PrExId = oDatatable.Rows(0).Item("PrExId")
                oProjectExpectInfo.PrId = oDatatable.Rows(0).Item("PrId")
                oProjectExpectInfo.PrExWcsj = oDatatable.Rows(0).Item("PrExWcsj")
                oProjectExpectInfo.PrExZyyjnr = oDatatable.Rows(0).Item("PrExZyyjnr")
                oProjectExpectInfo.PrExYqmb = oDatatable.Rows(0).Item("PrExYqmb")
                oProjectExpectInfo.PrExDwzhqc = oDatatable.Rows(0).Item("PrExDwzhqc")
                oProjectExpectInfo.PrExKhhqc = oDatatable.Rows(0).Item("PrExKhhqc")
                oProjectExpectInfo.PrExKhhzh = oDatatable.Rows(0).Item("PrExKhhzh")
                Return oProjectExpectInfo
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class
