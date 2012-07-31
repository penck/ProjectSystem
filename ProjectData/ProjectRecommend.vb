Imports DBOpProvider
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Web.HttpContext
Imports System.Web.UI.WebControls

Public Class ProjectRecommend

#Region "类属性"

    Private _PrReId As Integer
    Private _PrId As Integer
    Private _PrReNo As String
    Private _PrReIsTj As Boolean
    Private _PrReTjYy As String
    Private _PrReIsTh As Boolean
    Private _PrReThYy As String
    Private _PrReUserName As String

    Public Property PrReId() As Integer
        Get
            PrReId = _PrReId
        End Get
        Set(ByVal value As Integer)
            _PrReId = value
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

    Public Property PrReNo() As String
        Get
            PrReNo = _PrReNo
        End Get
        Set(ByVal value As String)
            _PrReNo = value
        End Set
    End Property

    Public Property PrReIsTj() As Boolean
        Get
            PrReIsTj = _PrReIsTj
        End Get
        Set(ByVal value As Boolean)
            _PrReIsTj = value
        End Set
    End Property

    Public Property PrReTjYy() As String
        Get
            PrReTjYy = _PrReTjYy
        End Get
        Set(ByVal value As String)
            _PrReTjYy = value
        End Set
    End Property

    Public Property PrReIsTh() As Boolean
        Get
            PrReIsTh = _PrReIsTh
        End Get
        Set(ByVal value As Boolean)
            _PrReIsTh = value
        End Set
    End Property

    Public Property PrReThYy() As String
        Get
            PrReThYy = _PrReThYy
        End Get
        Set(ByVal value As String)
            _PrReThYy = value
        End Set
    End Property

    Public Property PrReUserName() As String
        Get
            PrReUserName = _PrReUserName
        End Get
        Set(ByVal value As String)
            _PrReUserName = value
        End Set
    End Property

#End Region

    ''' <summary>
    ''' 根据类对象插入数据，返回值为生成的记录编号（即PrReId值），如果返回值为0表示插入未成功。
    ''' </summary>
    ''' <param name="cObject">ProjectRecommend类对象</param>
    ''' <returns>生成的记录编号（即PrReId值）</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function Add(ByVal cObject As ProjectRecommend) As Integer
        Try
            Dim nSql As String = ""
            nSql = "insert into [ProjectRecommend] ("
            nSql &= "PrId,"
            nSql &= "PrReNo,"
            nSql &= "PrReIsTj,"
            nSql &= "PrReTjYy,"
            nSql &= "PrReIsTh,"
            nSql &= "PrReThYy,"
            nSql &= "PrReUserName"
            nSql &= " ) Values("
            nSql &= " '" & cObject.PrId & "',"
            nSql &= " '" & cObject.PrReNo & "',"
            nSql &= " '" & cObject.PrReIsTj & "',"
            nSql &= " '" & cObject.PrReTjYy & "',"
            nSql &= " '" & cObject.PrReIsTh & "',"
            nSql &= " '" & cObject.PrReThYy & "',"
            nSql &= " '" & cObject.PrReUserName & "'"
            nSql &= ")"
            Dim nReturnValue As Integer = 0
            Dim oSqlHelper As New SqlHelper
            oSqlHelper.RunSqlExec(nSql, nReturnValue)
            If nReturnValue > 0 Then
                nSql = "select max(PrReId) from [ProjectRecommend]"
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
            nSql = "Delete from [ProjectRecommend]"
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
    ''' <param name="cObject">ProjectRecommend类对象</param>
    ''' <returns>更新的行数</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function Update(ByVal cObject As ProjectRecommend) As Integer
        Try
            Dim oSqlHelper As New SqlHelper
            Dim nSql As String = ""
            nSql = "Update [ProjectRecommend] Set "
            nSql &= "PrId='" & cObject.PrId & "',"
            nSql &= "PrReNo='" & cObject.PrReNo & "',"
            nSql &= "PrReIsTj='" & cObject.PrReIsTj & "',"
            nSql &= "PrReTjYy='" & cObject.PrReTjYy & "',"
            nSql &= "PrReIsTh='" & cObject.PrReIsTh & "',"
            nSql &= "PrReThYy='" & cObject.PrReThYy & "',"
            nSql &= "PrReUserName='" & cObject.PrReUserName & "'"
            nSql &= "Where "
            nSql &= "PrReId='" & cObject.PrReId & "'"
            Dim nReturnValue As Integer = 0
            oSqlHelper.RunSqlExec(nSql, nReturnValue)
            Return nReturnValue
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' 根据条件获取ProjectRecommend对象。
    ''' </summary>
    ''' <param name="cCondition">sql条件</param>
    ''' <returns>ProjectRecommend对象。</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function GetToObj(Optional ByVal cCondition As String = "") As ProjectRecommend
        Try
            Dim nCondition As String = ""
            If cCondition <> "" Then
                nCondition = "where " & cCondition
            End If
            Dim nSql As String = ""
            nSql = "select * from [ProjectRecommend] " & nCondition
            Dim oSqlherlper As New SqlHelper
            Dim oDatatable As New DataTable
            oSqlherlper.RunSqlDataViewOrTable(nSql, oDatatable)
            If Not oDatatable Is Nothing AndAlso oDatatable.Rows.Count <> 0 Then
                Dim oProjectRecommend As New ProjectRecommend
                oProjectRecommend.PrReId = oDatatable.Rows(0).Item("PrReId")
                oProjectRecommend.PrId = oDatatable.Rows(0).Item("PrId")
                oProjectRecommend.PrReNo = oDatatable.Rows(0).Item("PrReNo")
                oProjectRecommend.PrReIsTj = oDatatable.Rows(0).Item("PrReIsTj")
                oProjectRecommend.PrReTjYy = oDatatable.Rows(0).Item("PrReTjYy")
                oProjectRecommend.PrReIsTh = oDatatable.Rows(0).Item("PrReIsTh")
                oProjectRecommend.PrReThYy = oDatatable.Rows(0).Item("PrReThYy")
                oProjectRecommend.PrReUserName = oDatatable.Rows(0).Item("PrReUserName")
                Return oProjectRecommend
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
            nSql = "select * from [V_ProjectRecommend] " & nCondition
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
    ''' 根据条件获取List强类型ProjectRecommend对象。
    ''' </summary>
    ''' <param name="cCondition">sql条件</param>
    ''' <returns>List(Of ProjectRecommend)对象</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function GetToLOObj(Optional ByVal cCondition As String = "") As List(Of ProjectRecommend)
        Try
            Dim nCondition As String = ""
            If cCondition <> "" Then
                nCondition = "where " & cCondition
            End If
            Dim nSql As String = ""
            nSql = "select * from [ProjectRecommend] " & nCondition
            Dim oSqlherlper As New SqlHelper
            Dim oDatatable As New DataTable
            oSqlherlper.RunSqlDataViewOrTable(nSql, oDatatable)
            If Not oDatatable Is Nothing AndAlso oDatatable.Rows.Count <> 0 Then
                Dim oLOObj As New List(Of ProjectRecommend)
                For Each oDataRow In oDatatable.Rows
                    Dim oProjectRecommend As New ProjectRecommend
                    oProjectRecommend.PrReId = oDataRow.Item("PrReId")
                    oProjectRecommend.PrId = oDataRow.Item("PrId")
                    oProjectRecommend.PrReNo = oDataRow.Item("PrReNo")
                    oProjectRecommend.PrReIsTj = oDataRow.Item("PrReIsTj")
                    oProjectRecommend.PrReTjYy = oDataRow.Item("PrReTjYy")
                    oProjectRecommend.PrReIsTh = oDataRow.Item("PrReIsTh")
                    oProjectRecommend.PrReThYy = oDataRow.Item("PrReThYy")
                    oProjectRecommend.PrReUserName = oDataRow.Item("PrReUserName")
                    oLOObj.Add(oProjectRecommend)
                Next
                Return oLOObj
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
