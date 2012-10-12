<%@ Page Title="友情链接编辑" Language="C#" MasterPageFile="~/Manage/Manage.master" AutoEventWireup="true" CodeFile="LinkEdit.aspx.cs" Inherits="Manage_LinkEdit" %>

<asp:Content ID="ctContentHead" ContentPlaceHolderID="ctHead" Runat="Server">
    <link rel="stylesheet" type="text/css" href='<%= "Style/LinkEdit.css".ResolveUrl() %>' />
</asp:Content>
<asp:Content ID="ctContentMain" ContentPlaceHolderID="ctMain" Runat="Server">
    <h1>友情链接编辑</h1>
    <div id="link_edit">
        名称：<asp:TextBox ID="ctName" runat="server"></asp:TextBox>
        链接：<asp:TextBox ID="ctUrl" runat="server"></asp:TextBox>
        <asp:Button ID="ctSubmit" runat="server" Text="提交" onclick="ctSubmit_Click" />
    </div>
</asp:Content>
