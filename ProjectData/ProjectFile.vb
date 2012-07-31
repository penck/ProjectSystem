Imports DBOpProvider
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Web.HttpContext
Imports System.Web.UI.WebControls

Public Class ProjectFile

#Region "类属性"

    Private _PrFiId As Integer
    Private _PrId As Integer
    Private _PrFiName As String
    Private _PrFiAddress As String
    Private _PrFiClass As String

    Public Property PrFiId() As Integer
        Get
            PrFiId = _PrFiId
        End Get
        Set(ByVal value As Integer)
            _PrFiId = value
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

    Public Property PrFiName() As String
        Get
            PrFiName = _PrFiName
        End Get
        Set(ByVal value As String)
            _PrFiName = value
        End Set
    End Property

    Public Property PrFiAddress() As String
        Get
            PrFiAddress = _PrFiAddress
        End Get
        Set(ByVal value As String)
            _PrFiAddress = value
        End Set
    End Property

    Public Property PrFiClass() As String
        Get
            PrFiClass = _PrFiClass
        End Get
        Set(ByVal value As String)
            _PrFiClass = value
        End Set
    End Property

#End Region

    ''' <summary>
    ''' 根据类对象插入数据，返回值为生成的记录编号（即PrFiId值），如果返回值为0表示插入未成功。
    ''' </summary>
    ''' <param name="cObject">ProjectFile类对象</param>
    ''' <returns>生成的记录编号（即PrFiId值）</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function Add(ByVal cObject As ProjectFile) As Integer
        Try
            Dim nSql As String = ""
            nSql = "insert into [ProjectFile] ("
            nSql &= "PrId,"
            nSql &= "PrFiName,"
            nSql &= "PrFiAddress,"
            nSql &= "PrFiClass"
            nSql &= " ) Values("
            nSql &= " '" & cObject.PrId & "',"
            nSql &= " '" & cObject.PrFiName & "',"
            nSql &= " '" & cObject.PrFiAddress & "',"
            nSql &= " '" & cObject.PrFiClass & "'"
            nSql &= ")"
            Dim nReturnValue As Integer = 0
            Dim oSqlHelper As New SqlHelper
            oSqlHelper.RunSqlExec(nSql, nReturnValue)
            If nReturnValue > 0 Then
                nSql = "select max(PrFiId) from [ProjectFile]"
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
            nSql = "Delete from [ProjectFile]"
            nSql &= " where " & cCondition
            Dim nReturnValue As Integer = 0
            oSqlHelper.RunSqlExec(nSql, nReturnValue)
            Return nReturnValue
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' 根据条件获取ProjectFile对象。
    ''' </summary>
    ''' <param name="cCondition">sql条件</param>
    ''' <returns>ProjectFile对象。</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function GetToObj(Optional ByVal cCondition As String = "") As ProjectFile
        Try
            Dim nCondition As String = ""
            If cCondition <> "" Then
                nCondition = "where " & cCondition
            End If
            Dim nSql As String = ""
            nSql = "select * from [ProjectFile] " & nCondition
            Dim oSqlherlper As New SqlHelper
            Dim oDatatable As New DataTable
            oSqlherlper.RunSqlDataViewOrTable(nSql, oDatatable)
            If Not oDatatable Is Nothing AndAlso oDatatable.Rows.Count <> 0 Then
                Dim oProjectFile As New ProjectFile
                oProjectFile.PrFiId = oDatatable.Rows(0).Item("PrFiId")
                oProjectFile.PrId = oDatatable.Rows(0).Item("PrId")
                oProjectFile.PrFiName = oDatatable.Rows(0).Item("PrFiName")
                oProjectFile.PrFiAddress = oDatatable.Rows(0).Item("PrFiAddress")
                oProjectFile.PrFiClass = oDatatable.Rows(0).Item("PrFiClass")
                Return oProjectFile
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
            nSql = "select * from [ProjectFile] " & nCondition
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
    ''' 根据条件获取List强类型ProjectFile对象。
    ''' </summary>
    ''' <param name="cCondition">sql条件</param>
    ''' <returns>List(Of ProjectFile)对象</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function GetToLOObj(Optional ByVal cCondition As String = "") As List(Of ProjectFile)
        Try
            Dim nCondition As String = ""
            If cCondition <> "" Then
                nCondition = "where " & cCondition
            End If
            Dim nSql As String = ""
            nSql = "select * from [ProjectFile] " & nCondition
            Dim oSqlherlper As New SqlHelper
            Dim oDatatable As New DataTable
            oSqlherlper.RunSqlDataViewOrTable(nSql, oDatatable)
            If Not oDatatable Is Nothing AndAlso oDatatable.Rows.Count <> 0 Then
                Dim oLOObj As New List(Of ProjectFile)
                For Each oDataRow In oDatatable.Rows
                    Dim oProjectFile As New ProjectFile
                    oProjectFile.PrFiId = oDataRow.Item("PrFiId")
                    oProjectFile.PrId = oDataRow.Item("PrId")
                    oProjectFile.PrFiName = oDataRow.Item("PrFiName")
                    oProjectFile.PrFiAddress = oDataRow.Item("PrFiAddress")
                    oProjectFile.PrFiClass = oDataRow.Item("PrFiClass")
                    oLOObj.Add(oProjectFile)
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
