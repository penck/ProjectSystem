Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Configuration
Imports System.ComponentModel
Imports System.Collections

''' <summary>
''' 连接web.config中配置的数据库
''' </summary>
''' <remarks></remarks>
Public Class OleDbHelper
    '连接数据源字符串变量
    Private MyConnection As OleDbConnection = Nothing
    Public StrConn As String = ConfigurationManager.AppSettings("OLECONNECTIONSTRING") & System.Web.HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath) & ConfigurationManager.AppSettings("DBName")

    ''' <summary>
    ''' 根据用户的app.config或config.config配置中ConnectionStrings的值打开数据库连接
    ''' 私有过程，只供类内部使用
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Open()
        Dim flag As Boolean = True
        'While flag
        Try
            If IsNothing(MyConnection) Then
                MyConnection = New OleDbConnection(StrConn)
            End If
            If MyConnection.State = ConnectionState.Closed Then
                MyConnection.Open()
            End If
            flag = False
        Catch ex As Exception
            flag = True
            MsgBox("网络不通或数据库服务器已停止，请检查网络是否连接或与管理员联系！" & ex.Message & StrConn)
        End Try
        'End While

    End Sub

    ''' <summary>
    ''' 关闭数据库连接
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Close()
        If Not IsNothing(MyConnection) Then
            If MyConnection.State = ConnectionState.Open Then
                MyConnection.Close()
            End If
        End If
    End Sub

    ''' <summary>
    ''' 释放资源
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Dispose()
        If Not IsNothing(MyConnection) Then
            MyConnection.Dispose()
            MyConnection = Nothing
        End If
    End Sub

    ''' <summary>
    ''' 生成存储过程参数
    ''' </summary>
    ''' <param name="cParamName">存储过程名称</param>
    ''' <param name="cDbType">参数类型</param>
    ''' <param name="cSize">参数大小</param>
    ''' <param name="cDirection">参数方向</param>
    ''' <param name="cValue">参数值</param>
    ''' <returns>返回sqlParam参数</returns>
    ''' <remarks></remarks>
    Public Function CreateParam(ByVal cParamName As String, ByVal cDbType As OleDbType, ByVal cSize As Integer, ByVal cDirection As ParameterDirection, ByVal cValue As Object) As OleDbParameter
        Dim nParam As OleDbParameter
        If cSize > 0 Then
            nParam = New OleDbParameter(cParamName, cDbType, cSize)
        Else
            nParam = New OleDbParameter(cParamName, cDbType)
        End If
        nParam.Direction = cDirection
        If Not (cDirection = ParameterDirection.Output And IsNothing(cValue)) Then
            nParam.Value = cValue
        End If
        Return nParam
    End Function

    ''' <summary>
    ''' 传入输入参数
    ''' </summary>
    ''' <param name="cParamName">存储过程</param>
    ''' <param name="cDbType">参数类型</param>
    ''' <param name="cSize">参数大小</param>
    ''' <param name="cValue">参数值</param>
    ''' <returns>返回sqlParam输入参数</returns>
    ''' <remarks></remarks>
    Public Function CreateInParam(ByVal cParamName As String, ByVal cDbType As OleDbType, ByVal cSize As Integer, ByVal cValue As Object) As OleDbParameter
        Return CreateParam(cParamName, cDbType, cSize, ParameterDirection.Input, cValue)
    End Function

    ''' <summary>
    ''' 传入输出参数
    ''' </summary>
    ''' <param name="cParamName">存储过程</param>
    ''' <param name="cDbType">参数类型</param>
    ''' <param name="cSize">参数大小</param>
    ''' <returns>返回sqlParam输入参数</returns>
    ''' <remarks></remarks>
    Public Function CreateOutParam(ByVal cParamName As String, ByVal cDbType As OleDbType, ByVal cSize As Integer) As OleDbParameter
        Return CreateParam(cParamName, cDbType, cSize, ParameterDirection.Output, Nothing)
    End Function

    ''' <summary>
    ''' 创建一个OleDbCommand对象的函数，以执行sql语句
    ''' </summary>
    ''' <param name="cCmdText">sql语句</param>
    ''' <returns>返回返回OleDbCommand对象</returns>
    ''' <remarks></remarks>
    Private Function CreateOleDbCommand(ByVal cCmdText As String) As OleDbCommand
        Open()
        Dim nCmd As OleDbCommand = New OleDbCommand(cCmdText, MyConnection)
        Return nCmd
    End Function


    ''' <summary>
    ''' 创建一个OleDbDataAdapter对象的函数，以执行sql语句
    ''' </summary>
    ''' <param name="cCmdText">sql语句</param>
    ''' <returns>返回返回OleDbDataAdapter对象</returns>
    ''' <remarks></remarks>
    Private Function CreateOleDbDataAdapter(ByVal cCmdText As String) As OleDbDataAdapter
        Open()
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(cCmdText, MyConnection)
        Return da
    End Function


    ''' <summary>
    ''' 执行无结果的sql语句，返回结果为表示错误信息的字符串，空字符串表示无错误
    ''' </summary>
    ''' <param name="cSqlText">sql语句</param>
    ''' <returns>返回空字符串或表示错误信息的字符串</returns>
    ''' <remarks></remarks>
    Public Function RunSqlExec(ByVal cSqlText As String, Optional ByRef cOutputValue As Integer = 0) As String
        Dim nErrorMsg As String = ""
        Dim nCmd As OleDbCommand
        Try
            nCmd = CreateOleDbCommand(cSqlText)
            cOutputValue = nCmd.ExecuteNonQuery()
        Catch ex As OleDbException
            Throw New Exception(ex.ErrorCode)
        Catch ex As Exception
            nErrorMsg = "操作出错！错误信息如下：" & ex.Message & " 错误信息系统已记录。" & cSqlText
            Throw New Exception(nErrorMsg)
        Finally
            Close()
        End Try
        Return nErrorMsg
    End Function

    ''' <summary>
    ''' 执行无结果的带参数sql语句，返回结果为表示错误信息的字符串，空字符串表示无错误
    ''' </summary>
    ''' <param name="cSqlText">sql语句</param>
    ''' <returns>返回空字符串或表示错误信息的字符串</returns>
    ''' <remarks></remarks>
    Public Function RunSqlExecByPram(ByVal cSqlText As String, ByVal cPrams() As OleDbParameter, Optional ByRef cOutputValue As Integer = 0) As String
        Dim nErrorMsg As String = ""
        Dim nCmd As OleDbCommand
        Try
            nCmd = CreateOleDbCommand(cSqlText)
            If Not IsNothing(cPrams) Then
                Dim nParameter As OleDbParameter
                For Each nParameter In cPrams
                    nCmd.Parameters.Add(nParameter)
                Next
            End If
            cOutputValue = nCmd.ExecuteNonQuery()
        Catch ex As OleDbException
            Throw New Exception(ex.ErrorCode)
        Catch ex As Exception
            nErrorMsg = "操作出错！错误信息如下：" & ex.Message & " 错误信息系统已记录。" & cSqlText
            Throw New Exception(nErrorMsg)
        Finally
            Close()
        End Try
        Return nErrorMsg
    End Function


    ''' <summary>
    ''' 执行sql语句，以引用方式传递OleDbDataReader对象，返回结果为表示错误信息的字符串，空字符串表示无错误
    ''' </summary>
    ''' <param name="cSqlText">sql语句</param>
    ''' <returns>返回空字符串或表示错误信息的字符串</returns>
    ''' <remarks></remarks>
    Public Function RunSqlReader(ByVal cSqlText As String, ByRef cDatareader As OleDbDataReader) As String
        Dim nErrorMsg As String = ""
        Dim nCmd As OleDbCommand
        Try
            nCmd = CreateOleDbCommand(cSqlText)
            cDatareader = nCmd.ExecuteReader
        Catch ex As Exception
            cDatareader = Nothing
            nErrorMsg = "操作出错！错误信息如下：" & ex.Message & " 错误信息系统已记录。" & cSqlText
            Throw New Exception(nErrorMsg)
        End Try
        Return nErrorMsg
    End Function

    ''' <summary>
    ''' 执行Sql语句，以引用方式传递DataSet对象，返回结果为表示错误信息的字符串，空字符串表示无错误
    ''' </summary>
    ''' <param name="cSqlText">sql语句</param>
    ''' <returns>返回空字符串或表示错误信息的字符串</returns>
    ''' <remarks></remarks>
    Public Function RunSqlDataset(ByVal cSqlText As String, ByRef cDataSet As DataSet) As String
        Dim nErrorMsg As String = ""
        If IsNothing(cDataSet) Then
            cDataSet = New DataSet
        End If
        Dim myDa As OleDbDataAdapter
        Try
            myDa = CreateOleDbDataAdapter(cSqlText)
            myDa.Fill(cDataSet)
        Catch ex As Exception
            nErrorMsg = "操作出错！错误信息如下：" & ex.Message & " 错误信息系统已记录。" & cSqlText
            Throw New Exception(nErrorMsg)
        Finally
            Close()
        End Try
        Return nErrorMsg
    End Function

    ''' <summary>
    ''' 执行Sql语句，以引用方式传递Dataview对象或DataTable对象，返回结果为表示错误信息的字符串，空字符串表示无错误
    ''' </summary>
    ''' <param name="cSqlText">sql语句</param>
    ''' <returns>返回空字符串或表示错误信息的字符串</returns>
    ''' <remarks></remarks>
    Public Function RunSqlDataViewOrTable(ByVal cSqlText As String, Optional ByRef cDataTable As DataTable = Nothing, Optional ByRef cDataview As DataView = Nothing) As String
        Dim nErrorMsg As String = ""
        Dim nDataSet As DataSet = New DataSet
        Dim myDa As OleDbDataAdapter
        Try
            myDa = CreateOleDbDataAdapter(cSqlText)
            myDa.Fill(nDataSet)
            cDataTable = nDataSet.Tables(0)
            cDataview = nDataSet.Tables(0).DefaultView
        Catch ex As Exception
            cDataview = Nothing
            cDataTable = Nothing
            nErrorMsg = "操作出错！错误信息如下：" & ex.Message & " 错误信息系统已记录。" & cSqlText
            Throw New Exception(nErrorMsg)
        Finally
            Close()
        End Try
        Return nErrorMsg
    End Function

    ''' <summary>
    ''' 执行通过参数组合的sql语句，以引用方式传递Dataview对象或DataTable对象，返回结果为表示错误信息的字符串，空字符串表示无错误
    ''' </summary>
    ''' <param name="cFieldNames">字段名集合</param>
    ''' <param name="cTableName">源数据库表名</param>
    ''' <param name="cCondition">条件（where开始）</param>
    ''' <param name="cDataTable">DataTable变量</param>
    ''' <param name="cDataview">Dataview变量</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RunByKeyDataViewOrTable(ByVal cFieldNames As String, ByRef cTableName As String, Optional ByVal cCondition As String = "", Optional ByRef cDataTable As DataTable = Nothing, Optional ByRef cDataview As DataView = Nothing) As String
        Dim nErrorMsg As String = ""
        Dim nDataSet As DataSet = New DataSet
        Dim myDa As OleDbDataAdapter
        Dim nSql As String
        nSql = "select " & cFieldNames & " from " & cTableName & " " & cCondition
        Try
            myDa = CreateOleDbDataAdapter(nSql)
            myDa.Fill(nDataSet)
            cDataTable = nDataSet.Tables(0)
            cDataview = nDataSet.Tables(0).DefaultView
        Catch ex As Exception
            cDataview = Nothing
            cDataTable = Nothing
            nErrorMsg = "操作出错！错误信息如下：" & ex.Message & " 错误信息系统已记录。" & nSql
            Throw New Exception(nErrorMsg)
        Finally
            Close()
        End Try
        Return nErrorMsg
    End Function

    ''' <summary>
    ''' 执行通过参数组合的sql语句，以引用方式传递OleDbDataReader对象，返回结果为表示错误信息的字符串，空字符串表示无错误
    ''' </summary>
    ''' <param name="cFieldNames">字段名集合</param>
    ''' <param name="cTableName">源数据库表名</param>
    ''' <param name="cCondition">条件（where开始)</param>
    ''' <param name="cDatareader">OleDbDataReader变量</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RunByKeyReader(ByVal cFieldNames As String, ByRef cTableName As String, Optional ByVal cCondition As String = "", Optional ByRef cDatareader As OleDbDataReader = Nothing) As String
        Dim nErrorMsg As String = ""
        Dim nCmd As OleDbCommand
        Dim nSql As String
        nSql = "select " & cFieldNames & " from " & cTableName & " " & cCondition
        Try
            nCmd = CreateOleDbCommand(nSql)
            cDatareader = nCmd.ExecuteReader
        Catch ex As Exception
            cDatareader = Nothing
            nErrorMsg = "操作出错！错误信息如下：" & ex.Message & " 错误信息系统已记录。" & nSql
            Throw New Exception(nErrorMsg)
        End Try
        Return nErrorMsg
    End Function

    Public Function GetTableName() As DataTable
        Dim nErrorMsg As String = ""
        Dim nDataSet As DataSet = New DataSet
        Dim nDataTable As New DataTable
        Try
            Open()
            nDataTable = MyConnection.GetSchema("Tables")
            Close()
        Catch ex As Exception
            Throw New Exception(nErrorMsg)
        Finally
            Close()
        End Try
        Return nDataTable
    End Function
End Class
