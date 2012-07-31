Imports System.Text.RegularExpressions

Public Class CheckClass
    '身份证验证程序
    Public Shared Function SfzCheck(ByVal cSfzh As String, ByVal cIsEmpty As Boolean) As String
        Dim arrVerifyCode() As String = {"1", "0", "x", "9", "8", "7", "6", "5", "4", "3", "2"}
        Dim Wi() As Byte = {7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2}
        Dim Checker() As Byte = {1, 9, 8, 7, 6, 5, 4, 3, 2, 1, 1}

        Dim nSfz As String = cSfzh.Trim
        If nSfz = "" And cIsEmpty Then
            Return "身份证号不能为空！<br/>"
        End If
        If nSfz <> "" Then
            If Len(nSfz) < 15 Or Len(nSfz) = 16 Or Len(nSfz) = 17 Or Len(nSfz) > 18 Then
                Return "身份证号共有 15 码或18位！<br/>"
            End If

            Dim Ai As String = ""
            If Len(nSfz) = 18 Then
                Ai = Mid(nSfz, 1, 17)
            ElseIf Len(nSfz) = 15 Then
                Ai = nSfz
                Ai = Left(Ai, 6) & "19" & Mid(Ai, 7, 9)
            End If
            If Not IsNumeric(Ai) Then
                Return "身份证除最后一位外，必须为数字！<br/>"
            End If
            Dim strYear, strMonth, strDay
            strYear = CInt(Mid(Ai, 7, 4))
            strMonth = CInt(Mid(Ai, 11, 2))
            strDay = CInt(Mid(Ai, 13, 2))
            Dim BirthDay As DateTime = DateSerial(strYear, strMonth, strDay)
            If IsDate(BirthDay) Then
                If DateDiff(DateInterval.Year, Now, BirthDay) < -140 Or Format(BirthDay, "yyyyMMdd") > Format(Now, "yyyyMMdd") Then
                    Return "身份证出生年份输入错误！<br/>"
                End If
                If strMonth > 12 Or strDay > 31 Then
                    Return "身份证出生月份输入错误！<br/>"
                End If
            Else
                Return "身份证输入错误！<br/>"
            End If
            Dim i, TotalmulAiWi As Integer
            For i = 0 To 16
                TotalmulAiWi = TotalmulAiWi + CInt(Mid(Ai, i + 1, 1)) * Wi(i)
            Next
            Dim modValue As Byte
            modValue = TotalmulAiWi Mod 11
            Dim strVerifyCode As String
            strVerifyCode = arrVerifyCode(modValue)
            Ai = Ai & strVerifyCode

            If Len(nSfz) = 18 And nSfz.ToLower <> Ai Then
                Return "身份证号码输入错误！<br/>"
            End If
        End If
        Return ""
    End Function

    'Email验证程序
    Public Shared Function EmailCheck(ByVal cEmail As String, ByVal cIsEmpty As Boolean) As String
        Dim nEmail As String = ""
        nEmail = cEmail.Trim
        Dim nCharEmail As Char()
        nCharEmail = nEmail.ToCharArray
        If nEmail = "" And cIsEmpty Then
            Return "Email不能为空！<br/>"
        End If
        If nEmail <> "" Then
            Dim nRegex As New Regex("^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)")
            If Not nRegex.IsMatch(nEmail) Then
                Return "Email格式不正确！<br/>"
            End If
        End If
        Return ""
    End Function

    '电话号码验证程序
    Public Shared Function PhoneCheck(ByVal cPhone As String, ByVal cIsEmpty As Boolean) As String
        Dim nPhone As String = ""
        nPhone = cPhone.Trim
        If nPhone = "" And cIsEmpty Then
            Return "电话号码不能为空！<br/>"
        End If
        If nPhone <> "" Then
            Dim nRegex As New Regex("^(\d{3,4}-)?\d{7,8}$")
            If Not nRegex.IsMatch(nPhone) Then
                Return "电话号码应为数字，模式为XXXX-XXXXXXX!<br/>"
            End If
        End If
        Return ""
    End Function

    '移动电话号码验证程序
    Public Shared Function TelPhoneCheck(ByVal cTelPhone As String, ByVal cIsEmpty As Boolean) As String
        Dim nTelPhone As String = ""
        nTelPhone = cTelPhone.Trim
        If nTelPhone = "" And cIsEmpty Then
            Return "手机号码不能为空！<br/>"
        End If
        If nTelPhone <> "" Then
            Dim nRegex As New Regex("^1[0-9]{10}$")
            If Not nRegex.IsMatch(nTelPhone) Then
                Return "手机号码应为数字，模式为1XXXXXXXXXX!<br/>"
            End If
        End If
        Return ""
    End Function

    '电话和手机号码混合验证程序
    Public Shared Function TelOrPhoneCheck(ByVal cTelOrPhone As String, ByVal cIsEmpty As Boolean) As String
        Dim nTelOrPhone As String = ""
        nTelOrPhone = cTelOrPhone.Trim
        If nTelOrPhone = "" And cIsEmpty Then
            Return "手机或电话号码不能为空！<br/>"
        End If
        If nTelOrPhone <> "" Then
            Dim nRegex As New Regex("^((\d{3,4}-)?\d{7,8})|(1[0-9]{10})$")
            If Not nRegex.IsMatch(nTelOrPhone) Then
                Return "手机或电话号码应为数字且只填一种，模式为XXXX-XXXXXXX或1XXXXXXXXX!<br/>"
            End If
        End If
        Return ""
    End Function

    '腾讯qq号验证程序
    Public Shared Function QqhCheck(ByVal cQqh As String, ByVal cIsEmpty As Boolean) As String
        Dim nQqh As String = ""
        nQqh = cQqh.Trim
        If nQqh = "" And cIsEmpty Then
            Return "QQ号码不能为空！<br/>"
        End If
        If nQqh <> "" Then
            Dim nRegex As New Regex("^[1-9]\d{4,14}$")
            If Not nRegex.IsMatch(nQqh) Then
                Return "QQ号码应为数字且5-14位！<br/>"
            End If
        End If
        Return ""
    End Function

    '邮政编码验证程序
    Public Shared Function YzbmCheck(ByVal cYzbm As String, ByVal cIsEmpty As Boolean) As String
        Dim nYzbm As String = ""
        nYzbm = cYzbm.Trim
        If nYzbm = "" And cIsEmpty Then
            Return "邮政编码不能为空！<br/>"
        End If
        If nYzbm <> "" Then
            Dim nRegex As New Regex("^[a-zA-Z0-9]{6}$")
            If Not nRegex.IsMatch(nYzbm) Then
                Return "邮政编码应为数字6位！<br/>"
            End If
        End If
        Return ""
    End Function

    'Internet地址验证程序
    Public Shared Function InternetUrlCheck(ByVal cInternetUrl As String, ByVal cIsEmpty As Boolean) As String
        Dim nInternetUrl As String = ""
        nInternetUrl = cInternetUrl.Trim
        If nInternetUrl = "" And cIsEmpty Then
            Return "网址不能为空！<br/>"
        End If
        If nInternetUrl <> "" Then
            Dim nRegex As New Regex("^http://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$")
            If Not nRegex.IsMatch(nInternetUrl) Then
                Return "网址必须以http://开头！<br/>"
            End If
        End If
        Return ""
    End Function

    '字符串必须是大写字母
    Public Shared Function StrIscapitalletterCheck(ByVal cString As String, ByVal cIsEmpty As Boolean, ByVal cTag As String) As String
        Dim nString As String = ""
        nString = cString.Trim
        If nString = "" And cIsEmpty Then
            Return cTag & "不能为空！<br/>"
        End If
        If nString <> "" Then
            Dim nRegex As New Regex("^[A-Z]+$")
            If Not nRegex.IsMatch(nString) Then
                Return cTag & "必须为大写字母！<br/>"
            End If
        End If
        Return ""
    End Function

    '字符串必须为X.X样式
    Public Shared Function StrIsNzNCheck(ByVal cStrIsNzN As String, ByVal cIsEmpty As Boolean, ByVal cTag As String, ByVal cNumBeforePoint As Integer, ByVal cNumAfterPoint As Integer) As String
        Dim nStrIsNzN As String = ""
        nStrIsNzN = cStrIsNzN.Trim
        If nStrIsNzN = "" And cIsEmpty Then
            Return cTag & "不能为空！<br/>"
        End If
        If nStrIsNzN <> "" Then
            Dim nRegex As New Regex("^(\d{" & cNumBeforePoint & "}.)?\d{" & cNumAfterPoint & "}$")
            If Not nRegex.IsMatch(nStrIsNzN) Then
                Return cTag & "应为数字，其中小数点前应" & cNumBeforePoint & "位，小数点后应" & cNumAfterPoint & "位!<br/>"
            End If
        End If
        Return ""
    End Function

    '验证带有n位小数的正实数
    Public Shared Function StrIszNCheck(ByVal cStrIsNzN As String, ByVal cIsEmpty As Boolean, ByVal cTag As String, ByVal cNumAfterPoint As Integer) As String
        Dim nStrIsNzN As String = ""
        nStrIsNzN = cStrIsNzN.Trim
        If nStrIsNzN = "" And cIsEmpty Then
            Return cTag & "不能为空！<br/>"

        End If
        If nStrIsNzN <> "" Then
            Dim nRegex As New Regex("^[0-9]+(.[0-9]{" & cNumAfterPoint & "})?$")
            If Not nRegex.IsMatch(nStrIsNzN) Then
                Return cTag & "应为大于零的数字，其中小数点后应" & cNumAfterPoint & "位!<br/>"
            End If
        End If
        Return ""
    End Function

    '字符串最小长度限制判断验证程序
    Public Shared Function StrMinLengthCheck(ByVal cStrMinLength As String, ByVal cIsEmpty As Boolean, ByVal cTag As String, ByVal cLength As Integer) As String
        Dim nStrMinLength As String = ""
        nStrMinLength = cStrMinLength.Trim
        If nStrMinLength = "" And cIsEmpty Then
            Return cTag & "不能为空！<br/>"
        End If
        If nStrMinLength <> "" Then
            If nStrMinLength.Length < cLength Then
                Return cTag & "长度必须大于" & cLength & "个字符！<br/>"
            End If
        End If
        Return ""
    End Function

    '字符串最大长度限制判断验证程序
    Public Shared Function StrMaxLengthCheck(ByVal cStrMaxLength As String, ByVal cIsEmpty As Boolean, ByVal cTag As String, ByVal cLength As Integer) As String
        Dim nStrMaxLength As String = ""
        nStrMaxLength = cStrMaxLength.Trim
        If nStrMaxLength = "" And cIsEmpty Then
            Return cTag & "不能为空！"
        End If
        If nStrMaxLength <> "" Then
            If nStrMaxLength.Length > cLength Then
                Return cTag & "长度必须小于" & cLength & "个字符！<br/>"
            End If
        End If
        Return ""
    End Function

    '字符串是否为空验证程序
    Public Shared Function StrIsEmptyCheck(ByVal cStrIsEmpty As String, ByVal cTag As String) As String
        Dim nStrIsEmpty As String = ""
        nStrIsEmpty = cStrIsEmpty.Trim
        If nStrIsEmpty.Length = 0 Then
            Return cTag & "不能为空！<br/>"
        End If
        Return ""
    End Function

    '字符串是否为数字验证程序
    Public Shared Function StrIsDigitalCheck(ByVal cStrIsDigital As String, ByVal cTag As String, Optional ByVal IsHightZero As Boolean = Nothing, Optional ByVal cIsEmpty As Boolean = False) As String
        Dim nStrIsDigital As String = ""
        nStrIsDigital = cStrIsDigital.Trim
        If cIsEmpty Then
            If nStrIsDigital = "" Then
                Return ""
            End If
        End If
        If Not IsNumeric(nStrIsDigital) Then
            Return cTag & "必须为数字！<br/>"
        End If
        Dim nAChar As Char()
        nAChar = cStrIsDigital.ToCharArray
        For i As Integer = 0 To nAChar.Length - 1
            Dim nChar As Char
            nChar = nAChar(i)
            Dim nValue As Integer = Convert.ToInt32(nChar)
            If (Convert.ToInt32(nChar) >= 48 And Convert.ToInt32(nChar) <= 57) Or Convert.ToInt32(nChar) = 46 Then
            Else
                Return cTag & "必须是半角数字！<br/>"
            End If
        Next
        If Not IsHightZero = Nothing Then
            If IsHightZero And nStrIsDigital < 0 Then
                Return cTag & "数字必须是不小于零！<br/>"
            End If
            If Not IsHightZero And nStrIsDigital > 0 Then
                Return cTag & "数字必须是不大于零！<br/>"
            End If
        End If
        Return ""
    End Function

    '字符串是否为数字验证程序,如验证银行账号等
    Public Shared Function StrIsDigitalCheck(ByVal cStrIsNzN As String, ByVal cIsEmpty As Boolean, ByVal cTag As String) As String
        Dim nStrIsNzN As String = ""
        nStrIsNzN = cStrIsNzN.Trim
        If nStrIsNzN = "" And cIsEmpty Then
            Return cTag & "不能为空！<br/>"
        End If
        If nStrIsNzN <> "" Then
            Dim nRegex As New Regex("^[0-9]*$")
            If Not nRegex.IsMatch(nStrIsNzN) Then
                Return cTag & "应为整数!<br/>"
            End If
        End If
        Return ""
    End Function

    '字符串是否为日期验证程序
    Public Shared Function StrIsDateCheck(ByVal cString As String, ByVal cTag As String) As String
        Dim nString As String = ""
        nString = cString.Trim
        If Not IsDate(nString) Then
            Return cTag & "必须为日期！<br/>"
        End If
        Return ""
    End Function

    '字符串必须为几位
    Public Shared Function StrLengthCheck(ByVal cStrLength As Integer, ByVal cTag As String, ByVal cLength As Integer) As String
        Dim nStrLength As Integer = 0
        nStrLength = cStrLength
        If nStrLength = 0 Then
            Return cTag & "不能为空！<br/>"
        End If
        If nStrLength <> cLength Then
            Return cTag & "长度必须等于" & cLength & "个字符！<br/>"
        End If
        Return ""
    End Function

    '字符串是否为实数验证
    Public Shared Function StrIsShishuCheck(ByVal cStrIsNzN As String, ByVal cIsEmpty As Boolean, ByVal cTag As String) As String
        Dim nStrIsNzN As String = ""
        nStrIsNzN = cStrIsNzN.Trim
        If nStrIsNzN = "" And cIsEmpty Then
            Return cTag & "不能为空！<br/>"
        End If
        If nStrIsNzN <> "" Then
            Dim nRegex As New Regex("^[0-9]+(.[0-9])?$")
            If Not nRegex.IsMatch(nStrIsNzN) Then
                Return cTag & "应为的实数!<br/>"
            End If
        End If
        Return ""
    End Function
End Class
