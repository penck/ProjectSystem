Imports DBOpProvider
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Web.UI.WebControls
Imports System.Web.HttpContext

Public Class NoticeInfo

#Region "类属性"

    Private _NoId As Integer
    Private _NoTitle As String
    Private _NoContent As String
    Private _NoAnnounce As String
    Private _NoAccept As String
    Private _NoYear As String
    Private _NoAddUser As String
    Private _NoAddTime As DateTime

    Public Property NoId() As Integer
        Get
            NoId = _NoId
        End Get
        Set(ByVal value As Integer)
            _NoId = value
        End Set
    End Property

    Public Property NoTitle() As String
        Get
            NoTitle = _NoTitle
        End Get
        Set(ByVal value As String)
            _NoTitle = value
        End Set
    End Property

    Public Property NoContent() As String
        Get
            NoContent = _NoContent
        End Get
        Set(ByVal value As String)
            _NoContent = value
        End Set
    End Property

    Public Property NoAnnounce() As String
        Get
            NoAnnounce = _NoAnnounce
        End Get
        Set(ByVal value As String)
            _NoAnnounce = value
        End Set
    End Property

    Public Property NoAccept() As String
        Get
            NoAccept = _NoAccept
        End Get
        Set(ByVal value As String)
            _NoAccept = value
        End Set
    End Property

    Public Property NoYear() As String
        Get
            NoYear = _NoYear
        End Get
        Set(ByVal value As String)
            _NoYear = value
        End Set
    End Property

    Public Property NoAddUser() As String
        Get
            NoAddUser = _NoAddUser
        End Get
        Set(ByVal value As String)
            _NoAddUser = value
        End Set
    End Property

    Public Property NoAddTime() As DateTime
        Get
            NoAddTime = _NoAddTime
        End Get
        Set(ByVal value As DateTime)
            _NoAddTime = value
        End Set
    End Property

#End Region

    ''' <summary>
    ''' 根据类对象插入数据，返回值为生成的记录编号（即NoId值），如果返回值为0表示插入未成功。
    ''' </summary>
    ''' <param name="cObject">NoticeInfo类对象</param>
    ''' <returns>生成的记录编号（即NoId值）</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function Add(ByVal cObject As NoticeInfo) As Integer
        Try
            Dim nSql As String = ""
            nSql = "insert into [NoticeInfo] ("
            nSql &= "NoTitle,"
            nSql &= "NoContent,"
            nSql &= "NoAnnounce,"
            nSql &= "NoAccept,"
            nSql &= "NoYear,"
            nSql &= "NoAddUser,"
            nSql &= "NoAddTime"
            nSql &= " ) Values("
            nSql &= " '" & cObject.NoTitle & "',"
            nSql &= " '" & cObject.NoContent & "',"
            nSql &= " '" & cObject.NoAnnounce & "',"
            nSql &= " '" & cObject.NoAccept & "',"
            nSql &= " '" & cObject.NoYear & "',"
            nSql &= " '" & cObject.NoAddUser & "',"
            nSql &= " '" & cObject.NoAddTime & "'"
            nSql &= ")"
            Dim nReturnValue As Integer = 0
            Dim oSqlHelper As New SqlHelper
            oSqlHelper.RunSqlExec(nSql, nReturnValue)
            If nReturnValue > 0 Then
                nSql = "select max(NoId) from [NoticeInfo]"
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
            nSql = "Delete from [NoticeInfo]"
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
    ''' <param name="cObject">NoticeInfo类对象</param>
    ''' <returns>更新的行数</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function Update(ByVal cObject As NoticeInfo) As Integer
        Try
            Dim oSqlHelper As New SqlHelper
            Dim nSql As String = ""
            nSql = "Update [NoticeInfo] Set "
            nSql &= "NoTitle='" & cObject.NoTitle & "',"
            nSql &= "NoContent='" & cObject.NoContent & "',"
            nSql &= "NoAnnounce='" & cObject.NoAnnounce & "',"
            nSql &= "NoAccept='" & cObject.NoAccept & "',"
            nSql &= "NoYear='" & cObject.NoYear & "',"
            nSql &= "NoAddUser='" & cObject.NoAddUser & "',"
            nSql &= "NoAddTime='" & cObject.NoAddTime & "'"
            nSql &= "Where "
            nSql &= "NoId='" & cObject.NoId & "'"
            Dim nReturnValue As Integer = 0
            oSqlHelper.RunSqlExec(nSql, nReturnValue)
            Return nReturnValue
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' 根据条件获取User对象。
    ''' </summary>
    ''' <param name="cCondition">sql条件</param>
    ''' <returns>NoticeInfo对象。</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function GetToObj(Optional ByVal cCondition As String = "") As NoticeInfo
        Try
            Dim nCondition As String = ""
            If cCondition <> "" Then
                nCondition = "where " & cCondition
            End If
            Dim nSql As String = ""
            nSql = "select * from [NoticeInfo] " & nCondition
            Dim oSqlherlper As New SqlHelper
            Dim oDatatable As New DataTable
            oSqlherlper.RunSqlDataViewOrTable(nSql, oDatatable)
            If Not oDatatable Is Nothing AndAlso oDatatable.Rows.Count <> 0 Then
                Dim oNoticeInfo As New NoticeInfo
                oNoticeInfo.NoId = oDatatable.Rows(0).Item("NoId")
                oNoticeInfo.NoTitle = oDatatable.Rows(0).Item("NoTitle")
                oNoticeInfo.NoContent = oDatatable.Rows(0).Item("NoContent")
                oNoticeInfo.NoAnnounce = oDatatable.Rows(0).Item("NoAnnounce")
                oNoticeInfo.NoAccept = oDatatable.Rows(0).Item("NoAccept")
                oNoticeInfo.NoYear = oDatatable.Rows(0).Item("NoYear")
                oNoticeInfo.NoAddUser = oDatatable.Rows(0).Item("NoAddUser")
                oNoticeInfo.NoAddTime = oDatatable.Rows(0).Item("NoAddTime")
                Return oNoticeInfo
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
            nSql = "select * from [NoticeInfo] " & nCondition
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
    ''' 根据条件获取List强类型NoticeInfo对象。
    ''' </summary>
    ''' <param name="cCondition">sql条件</param>
    ''' <returns>List(Of NoticeInfo)对象</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function GetToLOObj(Optional ByVal cCondition As String = "") As List(Of NoticeInfo)
        Try
            Dim nCondition As String = ""
            If cCondition <> "" Then
                nCondition = "where " & cCondition
            End If
            Dim nSql As String = ""
            nSql = "select * from [NoticeInfo] " & nCondition
            Dim oSqlherlper As New SqlHelper
            Dim oDatatable As New DataTable
            oSqlherlper.RunSqlDataViewOrTable(nSql, oDatatable)
            If Not oDatatable Is Nothing AndAlso oDatatable.Rows.Count <> 0 Then
                Dim oLOObj As New List(Of NoticeInfo)
                For Each oDataRow In oDatatable.Rows
                    Dim oNoticeInfo As New NoticeInfo
                    oNoticeInfo.NoId = oDataRow.Item("NoId")
                    oNoticeInfo.NoTitle = oDataRow.Item("NoTitle")
                    oNoticeInfo.NoContent = oDataRow.Item("NoContent")
                    oNoticeInfo.NoAnnounce = oDataRow.Item("NoAnnounce")
                    oNoticeInfo.NoAccept = oDataRow.Item("NoAccept")
                    oNoticeInfo.NoYear = oDataRow.Item("NoYear")
                    oNoticeInfo.NoAddUser = oDataRow.Item("NoAddUser")
                    oNoticeInfo.NoAddTime = oDataRow.Item("NoAddTime")
                    oLOObj.Add(oNoticeInfo)
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
