Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Drawing.Text
Imports System.Drawing

Partial Class ValidateImage
    Inherits System.Web.UI.Page

    Private ImagePath As String = "images/validator.jpg"


    Private Function GetRandomint() As String
        Dim random As Random = New Random
        Return (random.Next(1000, 9999).ToString())
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim nChkCode As Integer = 0
        nChkCode = GetRandomint()
        Response.Cookies("ChkCode").Value = nChkCode
        Dim bitMapImage As Bitmap = New Bitmap(Server.MapPath(ImagePath))
        Dim graphicImage As Graphics = Graphics.FromImage(bitMapImage)

        '///设置画笔的输出模式
        graphicImage.SmoothingMode = SmoothingMode.AntiAlias

        '///添加文本字符串
        graphicImage.DrawString(nChkCode.ToString, New Font("Arial", 18), SystemBrushes.WindowText, New Point(0, 0))

        '///设置图像输出的格式
        Response.ContentType = "image/jpeg"

        '///保存数据流
        bitMapImage.Save(Response.OutputStream, ImageFormat.Jpeg)

        '///释放占用的资源
        graphicImage.Dispose()
        bitMapImage.Dispose()
    End Sub
End Class
