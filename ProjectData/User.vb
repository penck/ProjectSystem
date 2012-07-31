Imports DBOpProvider
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Web.HttpContext
Imports System.Web.UI.WebControls

Public Class User

#Region "类属性"

    Private _UsId As Integer
    Private _UsName As String
    Private _UsPassword As String
    Private _UsCompany As String
    Private _UsContactName As String
    Private _UsTelephone As String
    Private _UsMobilephone As String
    Private _TypeName As String
    Private _UsAddTime As String

    Public Property UsId() As Integer
        Get
            UsId = _UsId
        End Get
        Set(ByVal value As Integer)
            _UsId = value
        End Set
    End Property

    Public Property UsName() As String
        Get
            UsName = _UsName
        End Get
        Set(ByVal value As String)
            _UsName = value
        End Set
    End Property

    Public Property UsPassword() As String
        Get
            UsPassword = _UsPassword
        End Get
        Set(ByVal value As String)
            _UsPassword = value
        End Set
    End Property

    Public Property UsCompany() As String
        Get
            UsCompany = _UsCompany
        End Get
        Set(ByVal value As String)
            _UsCompany = value
        End Set
    End Property

    Public Property UsContactName() As String
        Get
            UsContactName = _UsContactName
        End Get
        Set(ByVal value As String)
            _UsContactName = value
        End Set
    End Property

    Public Property UsTelephone() As String
        Get
            UsTelephone = _UsTelephone
        End Get
        Set(ByVal value As String)
            _UsTelephone = value
        End Set
    End Property

    Public Property UsMobilephone() As String
        Get
            UsMobilephone = _UsMobilephone
        End Get
        Set(ByVal value As String)
            _UsMobilephone = value
        End Set
    End Property

    Public Property TypeName() As String
        Get
            TypeName = _TypeName
        End Get
        Set(ByVal value As String)
            _TypeName = value
        End Set
    End Property

    Public Property UsAddTime() As String
        Get
            UsAddTime = _UsAddTime
        End Get
        Set(ByVal value As String)
            _UsAddTime = value
        End Set
    End Property

#End Region

    ''' <summary>
    ''' 根据类对象插入数据，返回值为生成的记录编号（即UsId值），如果返回值为0表示插入未成功。
    ''' </summary>
    ''' <param name="cObject">User类对象</param>
    ''' <returns>生成的记录编号（即UsId值）</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function Add(ByVal cObject As User) As Integer
        Try
            Dim nSql As String = ""
            nSql = "insert into [User] ("
            nSql &= "UsName,"
            nSql &= "UsPassword,"
            nSql &= "UsCompany,"
            nSql &= "UsContactName,"
            nSql &= "UsTelephone,"
            nSql &= "UsMobilephone,"
            nSql &= "TypeName,"
            nSql &= "UsAddTime"
            nSql &= " ) Values("
            nSql &= " '" & cObject.UsName & "',"
            nSql &= " '" & cObject.UsPassword & "',"
            nSql &= " '" & cObject.UsCompany & "',"
            nSql &= " '" & cObject.UsContactName & "',"
            nSql &= " '" & cObject.UsTelephone & "',"
            nSql &= " '" & cObject.UsMobilephone & "',"
            nSql &= " '" & cObject.TypeName & "',"
            nSql &= " '" & cObject.UsAddTime & "'"
            nSql &= ")"
            Dim nReturnValue As Integer = 0
            Dim oSqlHelper As New SqlHelper
            oSqlHelper.RunSqlExec(nSql, nReturnValue)
            If nReturnValue > 0 Then
                nSql = "select max(UsId) from [User]"
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
            nSql = "Delete from [User]"
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
    ''' <param name="cObject">User类对象</param>
    ''' <returns>更新的行数</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function Update(ByVal cObject As User) As Integer
        Try
            Dim oSqlHelper As New SqlHelper
            Dim nSql As String = ""
            nSql = "Update [User] Set "
            nSql &= "UsName='" & cObject.UsName & "',"
            nSql &= "UsPassword='" & cObject.UsPassword & "',"
            nSql &= "UsCompany='" & cObject.UsCompany & "',"
            nSql &= "UsContactName='" & cObject.UsContactName & "',"
            nSql &= "UsTelephone='" & cObject.UsTelephone & "',"
            nSql &= "UsMobilephone='" & cObject.UsMobilephone & "',"
            nSql &= "TypeName='" & cObject.TypeName & "',"
            nSql &= "UsAddTime='" & cObject.UsAddTime & "'"
            nSql &= "Where "
            nSql &= "UsId='" & cObject.UsId & "'"
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
    ''' <returns>User对象。</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function GetToObj(Optional ByVal cCondition As String = "") As User
        Try
            Dim nCondition As String = ""
            If cCondition <> "" Then
                nCondition = "where " & cCondition
            End If
            Dim nSql As String = ""
            nSql = "select * from [User] " & nCondition
            Dim oSqlherlper As New SqlHelper
            Dim oDatatable As New DataTable
            oSqlherlper.RunSqlDataViewOrTable(nSql, oDatatable)
            If Not oDatatable Is Nothing AndAlso oDatatable.Rows.Count <> 0 Then
                Dim oUser As New User
                oUser.UsId = oDatatable.Rows(0).Item("UsId")
                oUser.UsName = oDatatable.Rows(0).Item("UsName")
                oUser.UsPassword = oDatatable.Rows(0).Item("UsPassword")
                oUser.UsCompany = oDatatable.Rows(0).Item("UsCompany")
                oUser.UsContactName = oDatatable.Rows(0).Item("UsContactName")
                oUser.UsTelephone = oDatatable.Rows(0).Item("UsTelephone")
                oUser.UsMobilephone = oDatatable.Rows(0).Item("UsMobilephone")
                oUser.TypeName = oDatatable.Rows(0).Item("TypeName")
                oUser.UsAddTime = oDatatable.Rows(0).Item("UsAddTime")
                Return oUser
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' 根据Session("UsName")，获取用户对象
    ''' </summary>
    ''' <param name="cKeyName"></param>
    ''' <returns>返回User对象</returns>
    ''' <remarks></remarks>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function GetUserBySession(ByVal cKeyName As String) As User
        Try
            Dim nUsName As String = ""
            If Not Current.Session(cKeyName) Is Nothing AndAlso Current.Session(cKeyName) <> "" Then
                nUsName = Current.Session(cKeyName)
                Dim nstrCondition As String
                nstrCondition = "UsName='" & nUsName & "'"
                Dim oUserInfo As New User
                oUserInfo = oUserInfo.GetToObj(nstrCondition)
                If Not oUserInfo Is Nothing Then
                    Return oUserInfo
                End If
            Else
                Dim nRdUrl As String = ""
                nRdUrl = Current.Request.Url.ToString.Replace(Current.Request.RawUrl, "") & Current.Request.ApplicationPath & "/index.aspx"
                Current.Response.Write("<script>javascript:top.location.href='" & nRdUrl & "';</script>")
            End If
            Return Nothing
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' 获得用户登录状态，返回1表示登录成功，返回2表示密码不正确，返回3表示该用户不存在
    ''' </summary>
    ''' <param name="cUsName"></param>
    ''' <param name="cUsPassword"></param>
    ''' <returns> 判断用户是否登录，返回1表示登录成功，返回2表示密码不正确，返回3表示该用户不存在</returns>
    ''' <remarks></remarks>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function GetLoginStatus(ByVal cUsType As String, ByVal cUsName As String, ByVal cUsPassword As String) As Integer
        Try
            Dim oUser As New User
            Dim nCondition As String
            nCondition = "UsName = '" & cUsName & "' and TypeName='" & cUsType & "'"
            oUser = oUser.GetToObj(nCondition)
            If Not oUser Is Nothing Then
                If oUser.UsPassword = cUsPassword Then
                    Return 1
                Else
                    Return 2
                End If
            Else
                Return 3
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' 根据条件判断用户是否存在
    ''' </summary>
    ''' <returns>返回true表示存在，false表示不存在</returns>
    ''' <remarks>根据条件判断用户是否存在
    ''' </remarks>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function IsExistUser(ByVal cCondition As String) As Boolean
        Dim oSqlHelper As New SqlHelper
        Try
            Dim nCondition As String = ""
            nCondition = " where " & cCondition
            Dim nSql As String = ""
            nSql = "select * from [User]" & nCondition
            Dim oDatatable As New DataTable
            oSqlHelper.RunSqlDataViewOrTable(nSql, oDatatable)
            If oDatatable.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class
