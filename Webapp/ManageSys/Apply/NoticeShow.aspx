<%@ Page Title="" Language="VB" MasterPageFile="~/ManageSys/Apply/ApplyUser.master" AutoEventWireup="false" CodeFile="NoticeShow.aspx.vb" Inherits="ManageSys_Apply_NoticeShow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style =" text-align :center ; font-size :25px;">
        <asp:Label ID="lblNoTitle" runat="server" Text=""></asp:Label></div>
    <div style =" text-align :center ; font-size :12px;">发布者:
        <asp:Label ID="lblNoAnnounce" runat="server" Text=""></asp:Label>&nbsp;&nbsp;发布时间:
        <asp:Label ID="lblNoAddTime" runat="server" Text=""></asp:Label></div>
    <div style ="font-size :18px;">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblNoContent" runat="server" Text=""></asp:Label></div>
</asp:Content>

