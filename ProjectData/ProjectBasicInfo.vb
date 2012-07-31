Imports DBOpProvider
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Web.HttpContext
Imports System.Web.UI.WebControls

Public Class ProjectBasicInfo

#Region "类属性"

#Region "类属性名称"
    Private _PrBaId As Integer
    Private _PrId As Integer
    Private _PrBaClass As Integer
    Private _PrBaYear As String
    Private _PrBaName As String
    Private _PrBaApplyTime As DateTime
    Private _PrBaArea As Integer
    Private _ReUnId As Integer
    Private _PrBaHostUnit As String
    Private _PrBaHostUnitClass As Integer
    Private _PrBaCooperationUnit As String
    Private _PrBaCooperationUnitClass As Integer
    Private _PrBaIsCxyhz As Integer
    Private _PrBaHzxs As Integer
    Private _PrBaHostName As String
    Private _PrBaHostSex As Integer
    Private _PrBaHostEducation As Integer
    Private _PrBaHostBirth As DateTime
    Private _PrBaHostPosition As Integer
    Private _PrBaHostWorkPhone As String
    Private _PrBaHostMobilePhone As String
    Private _PrBaHostEmail As String
    Private _PrBaAllPeopleNumber As Integer
    Private _PrBaGjzcNumber As Integer
    Private _PrBaZjzcNumber As Integer
    Private _PrBaCjzcNumber As Integer
    Private _PrBaOtherNumber As Integer
    Private _PrBaYfztr As Double
    Private _PrBaSczbk As Double
    Private _PrBaQxczbk As Double
    Private _PrBaDwzc As Double
    Private _PrBaKfxcp As String
    Private _PrBaKfxgy As String
    Private _PrBaKfxzb As String
    Private _PrBaRjzscq As String
    Private _PrBaQdzlx As Integer
    Private _PrBaQzfmzlx As Integer
    Private _PrBaJsbz As String
    Private _PrBaDzwxpz As String
    Private _PrBaYfOther As String
    Private _PrBaXzqy As Integer
    Private _PrBaXcscnl As String
    Private _PrBaLdcytz As Double
    Private _PrBaXzxssr As Double
    Private _PrBaXzls As Double
    Private _PrBaCh As Double
    Private _PrBaYjtt As Integer
    Private _PrBaYjrc As Integer

#End Region

#Region "类属性过程"

    Public Property PrBaId() As Integer
        Get
            PrBaId = _PrBaId
        End Get
        Set(ByVal value As Integer)
            _PrBaId = value
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

    Public Property PrBaClass() As Integer
        Get
            PrBaClass = _PrBaClass
        End Get
        Set(ByVal value As Integer)
            _PrBaClass = value
        End Set
    End Property

    Public Property PrBaYear() As String
        Get
            PrBaYear = _PrBaYear
        End Get
        Set(ByVal value As String)
            _PrBaYear = value
        End Set
    End Property

    Public Property PrBaName() As String
        Get
            PrBaName = _PrBaName
        End Get
        Set(ByVal value As String)
            _PrBaName = value
        End Set
    End Property

    Public Property PrBaApplyTime() As DateTime
        Get
            PrBaApplyTime = _PrBaApplyTime
        End Get
        Set(ByVal value As DateTime)
            _PrBaApplyTime = value
        End Set
    End Property

    Public Property PrBaArea() As Integer
        Get
            PrBaArea = _PrBaArea
        End Get
        Set(ByVal value As Integer)
            _PrBaArea = value
        End Set
    End Property

    Public Property ReUnId() As Integer
        Get
            ReUnId = _ReUnId
        End Get
        Set(ByVal value As Integer)
            _ReUnId = value
        End Set
    End Property

    Public Property PrBaHostUnit() As String
        Get
            PrBaHostUnit = _PrBaHostUnit
        End Get
        Set(ByVal value As String)
            _PrBaHostUnit = value
        End Set
    End Property

    Public Property PrBaHostUnitClass() As Integer
        Get
            PrBaHostUnitClass = _PrBaHostUnitClass
        End Get
        Set(ByVal value As Integer)
            _PrBaHostUnitClass = value
        End Set
    End Property

    Public Property PrBaCooperationUnit() As String
        Get
            PrBaCooperationUnit = _PrBaCooperationUnit
        End Get
        Set(ByVal value As String)
            _PrBaCooperationUnit = value
        End Set
    End Property

    Public Property PrBaCooperationUnitClass() As Integer
        Get
            PrBaCooperationUnitClass = _PrBaCooperationUnitClass
        End Get
        Set(ByVal value As Integer)
            _PrBaCooperationUnitClass = value
        End Set
    End Property

    Public Property PrBaIsCxyhz() As Integer
        Get
            PrBaIsCxyhz = _PrBaIsCxyhz
        End Get
        Set(ByVal value As Integer)
            _PrBaIsCxyhz = value
        End Set
    End Property

    Public Property PrBaHzxs() As Integer
        Get
            PrBaHzxs = _PrBaHzxs
        End Get
        Set(ByVal value As Integer)
            _PrBaHzxs = value
        End Set
    End Property

    Public Property PrBaHostName() As String
        Get
            PrBaHostName = _PrBaHostName
        End Get
        Set(ByVal value As String)
            _PrBaHostName = value
        End Set
    End Property

    Public Property PrBaHostSex() As Integer
        Get
            PrBaHostSex = _PrBaHostSex
        End Get
        Set(ByVal value As Integer)
            _PrBaHostSex = value
        End Set
    End Property

    Public Property PrBaHostEducation() As Integer
        Get
            PrBaHostEducation = _PrBaHostEducation
        End Get
        Set(ByVal value As Integer)
            _PrBaHostEducation = value
        End Set
    End Property

    Public Property PrBaHostBirth() As DateTime
        Get
            PrBaHostBirth = _PrBaHostBirth
        End Get
        Set(ByVal value As DateTime)
            _PrBaHostBirth = value
        End Set
    End Property

    Public Property PrBaHostPosition() As Integer
        Get
            PrBaHostPosition = _PrBaHostPosition
        End Get
        Set(ByVal value As Integer)
            _PrBaHostPosition = value
        End Set
    End Property

    Public Property PrBaHostWorkPhone() As String
        Get
            PrBaHostWorkPhone = _PrBaHostWorkPhone
        End Get
        Set(ByVal value As String)
            _PrBaHostWorkPhone = value
        End Set
    End Property

    Public Property PrBaHostMobilePhone() As String
        Get
            PrBaHostMobilePhone = _PrBaHostMobilePhone
        End Get
        Set(ByVal value As String)
            _PrBaHostMobilePhone = value
        End Set
    End Property

    Public Property PrBaHostEmail() As String
        Get
            PrBaHostEmail = _PrBaHostEmail
        End Get
        Set(ByVal value As String)
            _PrBaHostEmail = value
        End Set
    End Property

    Public Property PrBaAllPeopleNumber() As Integer
        Get
            PrBaAllPeopleNumber = _PrBaAllPeopleNumber
        End Get
        Set(ByVal value As Integer)
            _PrBaAllPeopleNumber = value
        End Set
    End Property

    Public Property PrBaGjzcNumber() As Integer
        Get
            PrBaGjzcNumber = _PrBaGjzcNumber
        End Get
        Set(ByVal value As Integer)
            _PrBaGjzcNumber = value
        End Set
    End Property

    Public Property PrBaZjzcNumber() As Integer
        Get
            PrBaZjzcNumber = _PrBaZjzcNumber
        End Get
        Set(ByVal value As Integer)
            _PrBaZjzcNumber = value
        End Set
    End Property

    Public Property PrBaCjzcNumber() As Integer
        Get
            PrBaCjzcNumber = _PrBaCjzcNumber
        End Get
        Set(ByVal value As Integer)
            _PrBaCjzcNumber = value
        End Set
    End Property

    Public Property PrBaOtherNumber() As Integer
        Get
            PrBaOtherNumber = _PrBaOtherNumber
        End Get
        Set(ByVal value As Integer)
            _PrBaOtherNumber = value
        End Set
    End Property

    Public Property PrBaYfztr() As Double
        Get
            PrBaYfztr = _PrBaYfztr
        End Get
        Set(ByVal value As Double)
            _PrBaYfztr = value
        End Set
    End Property

    Public Property PrBaSczbk() As Double
        Get
            PrBaSczbk = _PrBaSczbk
        End Get
        Set(ByVal value As Double)
            _PrBaSczbk = value
        End Set
    End Property

    Public Property PrBaQxczbk() As Double
        Get
            PrBaQxczbk = _PrBaQxczbk
        End Get
        Set(ByVal value As Double)
            _PrBaQxczbk = value
        End Set
    End Property

    Public Property PrBaDwzc() As Double
        Get
            PrBaDwzc = _PrBaDwzc
        End Get
        Set(ByVal value As Double)
            _PrBaDwzc = value
        End Set
    End Property

    Public Property PrBaKfxcp() As String
        Get
            PrBaKfxcp = _PrBaKfxcp
        End Get
        Set(ByVal value As String)
            _PrBaKfxcp = value
        End Set
    End Property

    Public Property PrBaKfxgy() As String
        Get
            PrBaKfxgy = _PrBaKfxgy
        End Get
        Set(ByVal value As String)
            _PrBaKfxgy = value
        End Set
    End Property

    Public Property PrBaKfxzb() As String
        Get
            PrBaKfxzb = _PrBaKfxzb
        End Get
        Set(ByVal value As String)
            _PrBaKfxzb = value
        End Set
    End Property

    Public Property PrBaRjzscq() As String
        Get
            PrBaRjzscq = _PrBaRjzscq
        End Get
        Set(ByVal value As String)
            _PrBaRjzscq = value
        End Set
    End Property

    Public Property PrBaQdzlx() As Integer
        Get
            PrBaQdzlx = _PrBaQdzlx
        End Get
        Set(ByVal value As Integer)
            _PrBaQdzlx = value
        End Set
    End Property

    Public Property PrBaQzfmzlx() As Integer
        Get
            PrBaQzfmzlx = _PrBaQzfmzlx
        End Get
        Set(ByVal value As Integer)
            _PrBaQzfmzlx = value
        End Set
    End Property

    Public Property PrBaJsbz() As String
        Get
            PrBaJsbz = _PrBaJsbz
        End Get
        Set(ByVal value As String)
            _PrBaJsbz = value
        End Set
    End Property

    Public Property PrBaDzwxpz() As String
        Get
            PrBaDzwxpz = _PrBaDzwxpz
        End Get
        Set(ByVal value As String)
            _PrBaDzwxpz = value
        End Set
    End Property

    Public Property PrBaYfOther() As String
        Get
            PrBaYfOther = _PrBaYfOther
        End Get
        Set(ByVal value As String)
            _PrBaYfOther = value
        End Set
    End Property

    Public Property PrBaXzqy() As Integer
        Get
            PrBaXzqy = _PrBaXzqy
        End Get
        Set(ByVal value As Integer)
            _PrBaXzqy = value
        End Set
    End Property

    Public Property PrBaXcscnl() As String
        Get
            PrBaXcscnl = _PrBaXcscnl
        End Get
        Set(ByVal value As String)
            _PrBaXcscnl = value
        End Set
    End Property

    Public Property PrBaLdcytz() As Double
        Get
            PrBaLdcytz = _PrBaLdcytz
        End Get
        Set(ByVal value As Double)
            _PrBaLdcytz = value
        End Set
    End Property

    Public Property PrBaXzxssr() As Double
        Get
            PrBaXzxssr = _PrBaXzxssr
        End Get
        Set(ByVal value As Double)
            _PrBaXzxssr = value
        End Set
    End Property

    Public Property PrBaXzls() As Double
        Get
            PrBaXzls = _PrBaXzls
        End Get
        Set(ByVal value As Double)
            _PrBaXzls = value
        End Set
    End Property

    Public Property PrBaCh() As Double
        Get
            PrBaCh = _PrBaCh
        End Get
        Set(ByVal value As Double)
            _PrBaCh = value
        End Set
    End Property

    Public Property PrBaYjtt() As Integer
        Get
            PrBaYjtt = _PrBaYjtt
        End Get
        Set(ByVal value As Integer)
            _PrBaYjtt = value
        End Set
    End Property

    Public Property PrBaYjrc() As Integer
        Get
            PrBaYjrc = _PrBaYjrc
        End Get
        Set(ByVal value As Integer)
            _PrBaYjrc = value
        End Set
    End Property

#End Region

#End Region

#Region "类方法"

    ''' <summary>
    ''' 根据类对象插入数据，返回值为生成的记录编号（即PrBaId值），如果返回值为0表示插入未成功。
    ''' </summary>
    ''' <param name="cObject">ProjectBasicInfo类对象</param>
    ''' <returns>生成的记录编号（即PrBaId值）</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function Add(ByVal cObject As ProjectBasicInfo) As Integer
        Try
            Dim nSql As String = ""
            nSql = "insert into [ProjectBasicInfo] ("
            nSql &= "PrId,"
            nSql &= "PrBaClass,"
            nSql &= "PrBaYear,"
            nSql &= "PrBaName,"
            nSql &= "PrBaApplyTime,"
            nSql &= "PrBaArea,"
            nSql &= "ReUnId,"
            nSql &= "PrBaHostUnit,"
            nSql &= "PrBaHostUnitClass,"
            nSql &= "PrBaCooperationUnit,"
            nSql &= "PrBaCooperationUnitClass,"
            nSql &= "PrBaIsCxyhz,"
            nSql &= "PrBaHzxs,"
            nSql &= "PrBaHostName,"
            nSql &= "PrBaHostSex,"
            nSql &= "PrBaHostEducation,"
            nSql &= "PrBaHostBirth,"
            nSql &= "PrBaHostPosition,"
            nSql &= "PrBaHostWorkPhone,"
            nSql &= "PrBaHostMobilePhone,"
            nSql &= "PrBaHostEmail,"
            nSql &= "PrBaAllPeopleNumber,"
            nSql &= "PrBaGjzcNumber,"
            nSql &= "PrBaZjzcNumber,"
            nSql &= "PrBaCjzcNumber,"
            nSql &= "PrBaOtherNumber,"
            nSql &= "PrBaYfztr,"
            nSql &= "PrBaSczbk,"
            nSql &= "PrBaQxczbk,"
            nSql &= "PrBaDwzc,"
            nSql &= "PrBaKfxcp,"
            nSql &= "PrBaKfxgy,"
            nSql &= "PrBaKfxzb,"
            nSql &= "PrBaRjzscq,"
            nSql &= "PrBaQdzlx,"
            nSql &= "PrBaQzfmzlx,"
            nSql &= "PrBaJsbz,"
            nSql &= "PrBaDzwxpz,"
            nSql &= "PrBaYfOther,"
            nSql &= "PrBaXzqy,"
            nSql &= "PrBaXcscnl,"
            nSql &= "PrBaLdcytz,"
            nSql &= "PrBaXzxssr,"
            nSql &= "PrBaXzls,"
            nSql &= "PrBaCh,"
            nSql &= "PrBaYjtt,"
            nSql &= "PrBaYjrc"
            nSql &= " ) Values("
            nSql &= " '" & cObject.PrId & "',"
            nSql &= " '" & cObject.PrBaClass & "',"
            nSql &= " '" & cObject.PrBaYear & "',"
            nSql &= " '" & cObject.PrBaName & "',"
            nSql &= " '" & cObject.PrBaApplyTime & "',"
            nSql &= " '" & cObject.PrBaArea & "',"
            nSql &= " '" & cObject.ReUnId & "',"
            nSql &= " '" & cObject.PrBaHostUnit & "',"
            nSql &= " '" & cObject.PrBaHostUnitClass & "',"
            nSql &= " '" & cObject.PrBaCooperationUnit & "',"
            nSql &= " '" & cObject.PrBaCooperationUnitClass & "',"
            nSql &= " '" & cObject.PrBaIsCxyhz & "',"
            nSql &= " '" & cObject.PrBaHzxs & "',"
            nSql &= " '" & cObject.PrBaHostName & "',"
            nSql &= " '" & cObject.PrBaHostSex & "',"
            nSql &= " '" & cObject.PrBaHostEducation & "',"
            nSql &= " '" & cObject.PrBaHostBirth & "',"
            nSql &= " '" & cObject.PrBaHostPosition & "',"
            nSql &= " '" & cObject.PrBaHostWorkPhone & "',"
            nSql &= " '" & cObject.PrBaHostMobilePhone & "',"
            nSql &= " '" & cObject.PrBaHostEmail & "',"
            nSql &= " '" & cObject.PrBaAllPeopleNumber & "',"
            nSql &= " '" & cObject.PrBaGjzcNumber & "',"
            nSql &= " '" & cObject.PrBaZjzcNumber & "',"
            nSql &= " '" & cObject.PrBaCjzcNumber & "',"
            nSql &= " '" & cObject.PrBaOtherNumber & "',"
            nSql &= " '" & cObject.PrBaYfztr & "',"
            nSql &= " '" & cObject.PrBaSczbk & "',"
            nSql &= " '" & cObject.PrBaQxczbk & "',"
            nSql &= " '" & cObject.PrBaDwzc & "',"
            nSql &= " '" & cObject.PrBaKfxcp & "',"
            nSql &= " '" & cObject.PrBaKfxgy & "',"
            nSql &= " '" & cObject.PrBaKfxzb & "',"
            nSql &= " '" & cObject.PrBaRjzscq & "',"
            nSql &= " '" & cObject.PrBaQdzlx & "',"
            nSql &= " '" & cObject.PrBaQzfmzlx & "',"
            nSql &= " '" & cObject.PrBaJsbz & "',"
            nSql &= " '" & cObject.PrBaDzwxpz & "',"
            nSql &= " '" & cObject.PrBaYfOther & "',"
            nSql &= " '" & cObject.PrBaXzqy & "',"
            nSql &= " '" & cObject.PrBaXcscnl & "',"
            nSql &= " '" & cObject.PrBaLdcytz & "',"
            nSql &= " '" & cObject.PrBaXzxssr & "',"
            nSql &= " '" & cObject.PrBaXzls & "',"
            nSql &= " '" & cObject.PrBaCh & "',"
            nSql &= " '" & cObject.PrBaYjtt & "',"
            nSql &= " '" & cObject.PrBaYjrc & "'"
            nSql &= ")"
            Dim nReturnValue As Integer = 0
            Dim oSqlHelper As New SqlHelper
            oSqlHelper.RunSqlExec(nSql, nReturnValue)
            If nReturnValue > 0 Then
                nSql = "select max(PrBaId) from [ProjectBasicInfo]"
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
    ''' 根据类对象更新数据，返回更新的行数。
    ''' </summary>
    ''' <param name="cObject">ProjectBasicInfo类对象</param>
    ''' <returns>更新的行数</returns>
    ''' <author>刘和明</author>
    ''' <updatetime>2012/4/20</updatetime>
    Public Function Update(ByVal cObject As ProjectBasicInfo) As Integer
        Try
            Dim oSqlHelper As New SqlHelper
            Dim nSql As String = ""
            nSql = "Update [ProjectBasicInfo] Set "
            nSql &= "PrId='" & cObject.PrId & "',"
            nSql &= "PrBaClass='" & cObject.PrBaClass & "',"
            nSql &= "PrBaYear='" & cObject.PrBaYear & "',"
            nSql &= "PrBaName='" & cObject.PrBaName & "',"
            nSql &= "PrBaApplyTime='" & cObject.PrBaApplyTime & "',"
            nSql &= "PrBaArea='" & cObject.PrBaArea & "',"
            nSql &= "ReUnId='" & cObject.ReUnId & "',"
            nSql &= "PrBaHostUnit='" & cObject.PrBaHostUnit & "',"
            nSql &= "PrBaHostUnitClass='" & cObject.PrBaHostUnitClass & "',"
            nSql &= "PrBaCooperationUnit='" & cObject.PrBaCooperationUnit & "',"
            nSql &= "PrBaCooperationUnitClass='" & cObject.PrBaCooperationUnitClass & "',"
            nSql &= "PrBaIsCxyhz='" & cObject.PrBaIsCxyhz & "',"
            nSql &= "PrBaHzxs='" & cObject.PrBaHzxs & "',"
            nSql &= "PrBaHostName='" & cObject.PrBaHostName & "',"
            nSql &= "PrBaHostSex='" & cObject.PrBaHostSex & "',"
            nSql &= "PrBaHostEducation='" & cObject.PrBaHostEducation & "',"
            nSql &= "PrBaHostBirth='" & cObject.PrBaHostBirth & "',"
            nSql &= "PrBaHostPosition='" & cObject.PrBaHostPosition & "',"
            nSql &= "PrBaHostWorkPhone='" & cObject.PrBaHostWorkPhone & "',"
            nSql &= "PrBaHostMobilePhone='" & cObject.PrBaHostMobilePhone & "',"
            nSql &= "PrBaHostEmail='" & cObject.PrBaHostEmail & "',"
            nSql &= "PrBaAllPeopleNumber='" & cObject.PrBaAllPeopleNumber & "',"
            nSql &= "PrBaGjzcNumber='" & cObject.PrBaGjzcNumber & "',"
            nSql &= "PrBaZjzcNumber='" & cObject.PrBaZjzcNumber & "',"
            nSql &= "PrBaCjzcNumber='" & cObject.PrBaCjzcNumber & "',"
            nSql &= "PrBaOtherNumber='" & cObject.PrBaOtherNumber & "',"
            nSql &= "PrBaYfztr='" & cObject.PrBaYfztr & "',"
            nSql &= "PrBaSczbk='" & cObject.PrBaSczbk & "',"
            nSql &= "PrBaQxczbk='" & cObject.PrBaQxczbk & "',"
            nSql &= "PrBaDwzc='" & cObject.PrBaDwzc & "',"
            nSql &= "PrBaKfxcp='" & cObject.PrBaKfxcp & "',"
            nSql &= "PrBaKfxgy='" & cObject.PrBaKfxgy & "',"
            nSql &= "PrBaKfxzb='" & cObject.PrBaKfxzb & "',"
            nSql &= "PrBaRjzscq='" & cObject.PrBaRjzscq & "',"
            nSql &= "PrBaQdzlx='" & cObject.PrBaQdzlx & "',"
            nSql &= "PrBaQzfmzlx='" & cObject.PrBaQzfmzlx & "',"
            nSql &= "PrBaJsbz='" & cObject.PrBaJsbz & "',"
            nSql &= "PrBaDzwxpz='" & cObject.PrBaDzwxpz & "',"
            nSql &= "PrBaYfOther='" & cObject.PrBaYfOther & "',"
            nSql &= "PrBaXzqy='" & cObject.PrBaXzqy & "',"
            nSql &= "PrBaXcscnl='" & cObject.PrBaXcscnl & "',"
            nSql &= "PrBaLdcytz='" & cObject.PrBaLdcytz & "',"
            nSql &= "PrBaXzxssr='" & cObject.PrBaXzxssr & "',"
            nSql &= "PrBaXzls='" & cObject.PrBaXzls & "',"
            nSql &= "PrBaCh='" & cObject.PrBaCh & "',"
            nSql &= "PrBaYjtt='" & cObject.PrBaYjtt & "',"
            nSql &= "PrBaYjrc='" & cObject.PrBaYjrc & "'"
            nSql &= "Where "
            nSql &= "PrBaId='" & cObject.PrBaId & "'"
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
    Public Function GetToObj(Optional ByVal cCondition As String = "") As ProjectBasicInfo
        Try
            Dim nCondition As String = ""
            If cCondition <> "" Then
                nCondition = "where " & cCondition
            End If
            Dim nSql As String = ""
            nSql = "select * from [ProjectBasicInfo] " & nCondition
            Dim oSqlherlper As New SqlHelper
            Dim oDatatable As New DataTable
            oSqlherlper.RunSqlDataViewOrTable(nSql, oDatatable)
            If Not oDatatable Is Nothing AndAlso oDatatable.Rows.Count <> 0 Then
                Dim oProjectBasicInfo As New ProjectBasicInfo
                oProjectBasicInfo.PrBaId = oDatatable.Rows(0).Item("PrBaId")
                oProjectBasicInfo.PrId = oDatatable.Rows(0).Item("PrId")
                oProjectBasicInfo.PrBaClass = oDatatable.Rows(0).Item("PrBaClass")
                oProjectBasicInfo.PrBaYear = oDatatable.Rows(0).Item("PrBaYear")
                oProjectBasicInfo.PrBaName = oDatatable.Rows(0).Item("PrBaName")
                oProjectBasicInfo.PrBaApplyTime = oDatatable.Rows(0).Item("PrBaApplyTime")
                oProjectBasicInfo.PrBaArea = oDatatable.Rows(0).Item("PrBaArea")
                oProjectBasicInfo.ReUnId = oDatatable.Rows(0).Item("ReUnId")
                oProjectBasicInfo.PrBaHostUnit = oDatatable.Rows(0).Item("PrBaHostUnit")
                oProjectBasicInfo.PrBaHostUnitClass = oDatatable.Rows(0).Item("PrBaHostUnitClass")
                oProjectBasicInfo.PrBaCooperationUnit = oDatatable.Rows(0).Item("PrBaCooperationUnit")
                oProjectBasicInfo.PrBaCooperationUnitClass = oDatatable.Rows(0).Item("PrBaCooperationUnitClass")
                oProjectBasicInfo.PrBaIsCxyhz = oDatatable.Rows(0).Item("PrBaIsCxyhz")
                oProjectBasicInfo.PrBaHzxs = oDatatable.Rows(0).Item("PrBaHzxs")
                oProjectBasicInfo.PrBaHostName = oDatatable.Rows(0).Item("PrBaHostName")
                oProjectBasicInfo.PrBaHostSex = oDatatable.Rows(0).Item("PrBaHostSex")
                oProjectBasicInfo.PrBaHostEducation = oDatatable.Rows(0).Item("PrBaHostEducation")
                oProjectBasicInfo.PrBaHostBirth = oDatatable.Rows(0).Item("PrBaHostBirth")
                oProjectBasicInfo.PrBaHostPosition = oDatatable.Rows(0).Item("PrBaHostPosition")
                oProjectBasicInfo.PrBaHostWorkPhone = oDatatable.Rows(0).Item("PrBaHostWorkPhone")
                oProjectBasicInfo.PrBaHostMobilePhone = oDatatable.Rows(0).Item("PrBaHostMobilePhone")
                oProjectBasicInfo.PrBaHostEmail = oDatatable.Rows(0).Item("PrBaHostEmail")
                oProjectBasicInfo.PrBaAllPeopleNumber = oDatatable.Rows(0).Item("PrBaAllPeopleNumber")
                oProjectBasicInfo.PrBaGjzcNumber = oDatatable.Rows(0).Item("PrBaGjzcNumber")
                oProjectBasicInfo.PrBaZjzcNumber = oDatatable.Rows(0).Item("PrBaZjzcNumber")
                oProjectBasicInfo.PrBaCjzcNumber = oDatatable.Rows(0).Item("PrBaCjzcNumber")
                oProjectBasicInfo.PrBaOtherNumber = oDatatable.Rows(0).Item("PrBaOtherNumber")
                oProjectBasicInfo.PrBaYfztr = oDatatable.Rows(0).Item("PrBaYfztr")
                oProjectBasicInfo.PrBaSczbk = oDatatable.Rows(0).Item("PrBaSczbk")
                oProjectBasicInfo.PrBaQxczbk = oDatatable.Rows(0).Item("PrBaQxczbk")
                oProjectBasicInfo.PrBaDwzc = oDatatable.Rows(0).Item("PrBaDwzc")
                oProjectBasicInfo.PrBaKfxcp = oDatatable.Rows(0).Item("PrBaKfxcp")
                oProjectBasicInfo.PrBaKfxgy = oDatatable.Rows(0).Item("PrBaKfxgy")
                oProjectBasicInfo.PrBaKfxzb = oDatatable.Rows(0).Item("PrBaKfxzb")
                oProjectBasicInfo.PrBaRjzscq = oDatatable.Rows(0).Item("PrBaRjzscq")
                oProjectBasicInfo.PrBaQdzlx = oDatatable.Rows(0).Item("PrBaQdzlx")
                oProjectBasicInfo.PrBaQzfmzlx = oDatatable.Rows(0).Item("PrBaQzfmzlx")
                oProjectBasicInfo.PrBaJsbz = oDatatable.Rows(0).Item("PrBaJsbz")
                oProjectBasicInfo.PrBaDzwxpz = oDatatable.Rows(0).Item("PrBaDzwxpz")
                oProjectBasicInfo.PrBaYfOther = oDatatable.Rows(0).Item("PrBaYfOther")
                oProjectBasicInfo.PrBaXzqy = oDatatable.Rows(0).Item("PrBaXzqy")
                oProjectBasicInfo.PrBaXcscnl = oDatatable.Rows(0).Item("PrBaXcscnl")
                oProjectBasicInfo.PrBaLdcytz = oDatatable.Rows(0).Item("PrBaLdcytz")
                oProjectBasicInfo.PrBaXzxssr = oDatatable.Rows(0).Item("PrBaXzxssr")
                oProjectBasicInfo.PrBaXzls = oDatatable.Rows(0).Item("PrBaXzls")
                oProjectBasicInfo.PrBaCh = oDatatable.Rows(0).Item("PrBaCh")
                oProjectBasicInfo.PrBaYjtt = oDatatable.Rows(0).Item("PrBaYjtt")
                oProjectBasicInfo.PrBaYjrc = oDatatable.Rows(0).Item("PrBaYjrc")
                Return oProjectBasicInfo
            Else
                Return Nothing
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
            nSql = "Delete from [ProjectBasicInfo]"
            nSql &= " where " & cCondition
            Dim nReturnValue As Integer = 0
            oSqlHelper.RunSqlExec(nSql, nReturnValue)
            Return nReturnValue
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

#End Region

End Class