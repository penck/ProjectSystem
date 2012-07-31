Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.ComponentModel
Imports System.Collections

Public Class SqlHelper
    '连接数据源字符串变量
    Private MyConnection As SqlConnection = Nothing
    Public strConn As String = ConfigurationManager.ConnectionStrings("SQLCONNECTIONSTRING").ToString()
    

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
                MyConnection = New SqlConnection(strConn)
            End If
            If MyConnection.State = ConnectionState.Closed Then
                MyConnection.Open()
            End If
            flag = False
        Catch ex As Exception
            flag = True
            ' MsgBox("网络不通或数据库服务器已停止，请检查网络是否连接或与管理员联系！")
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
    Private Function CreateParam(ByVal cParamName As String, ByVal cDbType As SqlDbType, ByVal cSize As Integer, ByVal cDirection As ParameterDirection, ByVal cValue As Object) As SqlParameter
        Dim nParam As SqlParameter
        If cSize > 0 Then
            nParam = New SqlParameter(cParamName, cDbType, cSize)
        Else
            nParam = New SqlParameter(cParamName, cDbType)
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
    Public Function CreateInParam(ByVal cParamName As String, ByVal cDbType As SqlDbType, ByVal cSize As Integer, ByVal cValue As Object) As SqlParameter
        Return CreateParam(cParamName, cDbType, cSize, ParameterDirection.Input, cValue)
    End Function

    ''' <summary>
    ''' 传入输出参数
    ''' </summary>
    ''' <param name="cParamName">存储过程</param>
    ''' <param name="cDbType">参数类型</param>
    ''' <param name="cSize">参数大小</param>
    ''' <param name="cValue">参数值</param>
    ''' <returns>返回sqlParam输入参数</returns>
    ''' <remarks></remarks>
    Public Function CreateOutParam(ByVal cParamName As String, ByVal cDbType As SqlDbType, ByVal cSize As Integer, Optional ByVal cValue As Object = Nothing) As SqlParameter
        Return CreateParam(cParamName, cDbType, cSize, ParameterDirection.Output, cValue)
    End Function

    ''' <summary>
    ''' 创建一个SqlCommand对象的函数，以执行存储过程
    ''' </summary>
    ''' <param name="cProcName">存储过程的名称</param>
    ''' <param name="cPrams">存储过程的参数</param>
    ''' <returns>返回返回SqlCommand对象</returns>
    ''' <remarks></remarks>
    Private Function CreateProcCommand(ByVal cProcName As String, ByRef cPrams() As SqlParameter) As SqlCommand
        Open()
        Dim nCmd As SqlCommand = New SqlCommand(cProcName, MyConnection)
        nCmd.CommandType = CommandType.StoredProcedure
        If Not IsNothing(cPrams) Then
            Dim nParameter As SqlParameter
            For Each nParameter In cPrams
                nCmd.Parameters.Add(nParameter)
            Next
        End If
        Return nCmd
    End Function

    ''' <summary>
    ''' 创建一个SqlCommand对象的函数，以执行sql语句
    ''' </summary>
    ''' <param name="cCmdText">sql语句</param>
    ''' <returns>返回返回SqlCommand对象</returns>
    ''' <remarks></remarks>
    Private Function CreateSQLCommand(ByVal cCmdText As String) As SqlCommand
        Open()
        Dim nCmd As SqlCommand = New SqlCommand(cCmdText, MyConnection)
        Return nCmd
    End Function

    ''' <summary>
    ''' 创建一个SqlDataAdapter对象的函数，以执行存储过程
    ''' </summary>
    ''' <param name="cProcName">存储过程的名称</param>
    ''' <param name="cPrams">存储过程的参数</param>
    ''' <returns>返回返回SqlDataAdapter对象</returns>
    ''' <remarks></remarks>
    Private Function CreateProcDataAdapter(ByVal cProcName As String, ByRef cPrams() As SqlParameter) As SqlDataAdapter
        Open()
        Dim da As SqlDataAdapter = New SqlDataAdapter(cProcName, MyConnection)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        If Not IsNothing(cPrams) Then
            Dim nParameter As SqlParameter
            For Each nParameter In cPrams
                da.SelectCommand.Parameters.Add(nParameter)
            Next
        End If
        Return da
    End Function

    ''' <summary>
    ''' 创建一个SqlDataAdapter对象的函数，以执行sql语句
    ''' </summary>
    ''' <param name="cCmdText">sql语句</param>
    ''' <returns>返回返回SqlDataAdapter对象</returns>
    ''' <remarks></remarks>
    Private Function CreateSQLDataAdapter(ByVal cCmdText As String) As SqlDataAdapter
        Open()
        Dim da As SqlDataAdapter = New SqlDataAdapter(cCmdText, MyConnection)
        Return da
    End Function

    ''' <summary>
    ''' 执行无结果的存储过程，返回结果为表示错误信息的字符串，空字符串表示无错误
    ''' </summary>
    ''' <param name="cProcName">存储过程名称</param>
    ''' <param name="cPrams">【可选参数】存储过程所需参数</param>
    ''' <returns>返回空字符串或表示错误信息的字符串</returns>
    ''' <remarks></remarks>
    Public Function RunProcExec(ByVal cProcName As String, Optional ByRef cPrams() As SqlParameter = Nothing, Optional ByRef cOutputValue As Integer = 0) As String
        Dim nErrorMsg As String = ""
        Dim nCmd As SqlCommand
        Try
            nCmd = CreateProcCommand(cProcName, cPrams)
            cOutputValue = nCmd.ExecuteNonQuery()
        Catch ex As Exception
            nErrorMsg = ex.Message & cProcName
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
    Public Function RunSqlExecByPram(ByVal cSqlText As String, ByVal cPrams() As SqlParameter, Optional ByRef cOutputValue As Integer = 0) As String
        Dim nErrorMsg As String = ""
        Dim nCmd As SqlCommand
        Try
            nCmd = CreateSQLCommand(cSqlText)
            If Not IsNothing(cPrams) Then
                Dim nParameter As SqlParameter
                For Each nParameter In cPrams
                    nCmd.Parameters.Add(nParameter)
                Next
            End If
            cOutputValue = nCmd.ExecuteNonQuery()
        Catch ex As Exception
            nErrorMsg = ex.Message & cSqlText
            Throw New Exception(nErrorMsg)
        Finally
            Close()
        End Try
        Return nErrorMsg
    End Function

    ''' <summary>
    ''' 执行无结果的sql语句，返回结果为表示错误信息的字符串，空字符串表示无错误
    ''' </summary>
    ''' <param name="cSqlText">sql语句</param>
    ''' <returns>返回空字符串或表示错误信息的字符串</returns>
    ''' <remarks></remarks>
    Public Function RunSqlExec(ByVal cSqlText As String, Optional ByRef cOutputValue As Integer = 0) As String
        Dim nErrorMsg As String = ""
        Dim nCmd As SqlCommand
        Try
            nCmd = CreateSQLCommand(cSqlText)
            cOutputValue = nCmd.ExecuteNonQuery()
        Catch ex As Exception
            nErrorMsg = ex.Message & cSqlText
            Throw New Exception(nErrorMsg)
        Finally
            Close()
        End Try
        Return nErrorMsg
    End Function

    ''' <summary>
    ''' 执行存储过程，以引用方式传递SqlDataReader对象，返回结果为表示错误信息的字符串，空字符串表示无错误
    ''' </summary>
    ''' <param name="cProcName">存储过程名称</param>
    ''' <param name="cDatareader">传入需读取数据库数据的Datareader对象</param>
    ''' <param name="cPrams">【可选参数】存储过程所需要的参数</param>
    ''' <returns>返回空字符串或表示错误信息的字符串</returns>
    ''' <remarks></remarks>
    Public Function RunProcReader(ByVal cProcName As String, ByRef cDatareader As SqlDataReader, Optional ByRef cPrams() As SqlParameter = Nothing) As String
        Dim nErrorMsg As String = ""
        Dim nCmd As SqlCommand
        Try
            nCmd = CreateProcCommand(cProcName, cPrams)
            cDatareader = nCmd.ExecuteReader
        Catch ex As Exception
            cDatareader = Nothing
            nErrorMsg = ex.Message & cProcName
            Throw New Exception(nErrorMsg)
        End Try
        Return nErrorMsg
    End Function

    ''' <summary>
    ''' 执行sql语句，以引用方式传递SqlDataReader对象，返回结果为表示错误信息的字符串，空字符串表示无错误
    ''' </summary>
    ''' <param name="cSqlText">sql语句</param>
    ''' <returns>返回空字符串或表示错误信息的字符串</returns>
    ''' <remarks></remarks>
    Public Function RunSqlReader(ByVal cSqlText As String, ByRef cDatareader As SqlDataReader) As String
        Dim nErrorMsg As String = ""
        Dim nCmd As SqlCommand
        Try
            nCmd = CreateSQLCommand(cSqlText)
            cDatareader = nCmd.ExecuteReader
        Catch ex As Exception
            cDatareader = Nothing
            nErrorMsg = ex.Message & cSqlText
            Throw New Exception(nErrorMsg)
        End Try
        Return nErrorMsg
    End Function

    ''' <summary>
    '''  执行存储过程，以引用方式传递DataSet对象，返回结果为表示错误信息的字符串，空字符串表示无错误
    ''' </summary>
    ''' <param name="cProcName">存储过程名称</param>
    ''' <param name="cDataSet">传入需要存储暑假的DataSet对象</param>
    ''' <param name="cPrams">【可选参数】存储过程所需要的参数</param>
    ''' <returns>返回空字符串或表示错误信息的字符串</returns>
    ''' <remarks></remarks>
    Public Function RunProcDataset(ByVal cProcName As String, ByRef cDataSet As DataSet, Optional ByRef cPrams() As SqlParameter = Nothing) As String
        Dim nErrorMsg As String = ""
        If IsNothing(cDataSet) Then
            cDataSet = New DataSet
        End If
        Dim myDa As SqlDataAdapter
        Try
            myDa = CreateProcDataAdapter(cProcName, cPrams)
            myDa.Fill(cDataSet)
        Catch ex As Exception
            nErrorMsg = ex.Message & cProcName
            Throw New Exception(nErrorMsg)
        Finally
            Close()
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
        Dim myDa As SqlDataAdapter
        Try
            myDa = CreateSQLDataAdapter(cSqlText)
            myDa.Fill(cDataSet)
        Catch ex As Exception
            nErrorMsg = ex.Message & cSqlText
            Throw New Exception(nErrorMsg)
        Finally
            Close()
        End Try
        Return nErrorMsg
    End Function

    ''' <summary>
    '''  执行存储过程，以引用方式传递Dataview对象或DataTable对象，返回结果为表示错误信息的字符串，空字符串表示无错误
    ''' </summary>
    ''' <param name="cProcName">存储过程名称</param>
    ''' <param name="cPrams">【可选参数】存储过程所需要的参数</param>
    ''' <param name="cDataTable">【可选参数】传入要存储数据的数据表对象</param>
    ''' <param name="cDataview">【可选参数】传入要存储数据的数据视图对象</param>
    ''' <returns>返回空字符串或表示错误信息的字符串</returns>
    ''' <remarks></remarks>    
    Public Function RunProcDataViewOrTable(ByVal cProcName As String, Optional ByRef cPrams() As SqlParameter = Nothing, Optional ByRef cDataTable As DataTable = Nothing, Optional ByRef cDataview As DataView = Nothing) As String
        Dim nErrorMsg As String = ""
        Dim nDataSet As DataSet = New DataSet
        Dim myDa As SqlDataAdapter
        Try
            myDa = CreateProcDataAdapter(cProcName, cPrams)
            myDa.Fill(nDataSet)
            cDataTable = nDataSet.Tables(0)
            cDataview = nDataSet.Tables(0).DefaultView
        Catch ex As Exception
            cDataview = Nothing
            cDataTable = Nothing
            nErrorMsg = ex.Message & cProcName
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
        Dim myDa As SqlDataAdapter
        Try
            myDa = CreateSQLDataAdapter(cSqlText)
            myDa.Fill(nDataSet)
            cDataTable = nDataSet.Tables(0)
            cDataview = nDataSet.Tables(0).DefaultView
        Catch ex As Exception
            cDataview = Nothing
            cDataTable = Nothing
            nErrorMsg = ex.Message & cSqlText
            Throw New Exception(nErrorMsg)
        Finally
            Close()
        End Try
        Return nErrorMsg
    End Function

    Public Function RunByKeyDataViewOrTable(ByVal cFieldNames As String, ByRef cTableName As String, Optional ByVal cCondition As String = "", Optional ByRef cDataTable As DataTable = Nothing, Optional ByRef cDataview As DataView = Nothing) As String
        Dim nErrorMsg As String = ""
        Dim nDataSet As DataSet = New DataSet
        Dim myDa As SqlDataAdapter
        Dim nSql As String
        nSql = "select " & cFieldNames & " from " & cTableName & " " & cCondition
        Try
            myDa = CreateSQLDataAdapter(nSql)
            myDa.Fill(nDataSet)
            cDataTable = nDataSet.Tables(0)
            cDataview = nDataSet.Tables(0).DefaultView
        Catch ex As Exception
            cDataview = Nothing
            cDataTable = Nothing
            nErrorMsg = ex.Message & nSql
            Throw New Exception(nErrorMsg)
        Finally
            Close()
        End Try
        Return nErrorMsg
    End Function

    Public Function RunByKeyReader(ByVal cFieldNames As String, ByRef cTableName As String, Optional ByVal cCondition As String = "", Optional ByRef cDatareader As SqlDataReader = Nothing) As String
        Dim nErrorMsg As String = ""
        Dim nCmd As SqlCommand
        Dim nSql As String
        nSql = "select " & cFieldNames & " from " & cTableName & " " & cCondition
        Try
            nCmd = CreateSQLCommand(nSql)
            cDatareader = nCmd.ExecuteReader
        Catch ex As Exception
            cDatareader = Nothing
            nErrorMsg = ex.Message & nSql
            Throw New Exception(nErrorMsg)
        End Try
        Return nErrorMsg
    End Function
End Class
