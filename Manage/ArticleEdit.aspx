<%@ Page Title="文章编辑" Language="C#" MasterPageFile="~/Manage/Manage.master" AutoEventWireup="true" CodeFile="ArticleEdit.aspx.cs" Inherits="ArticleEdit" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="ctContentHead" ContentPlaceHolderID="ctHead" Runat="Server">
    <link rel="stylesheet" type="text/css" href='<%= "Style/ArticleEdit.css".ResolveUrl() %>' />
</asp:Content>
<asp:Content ID="ctContentMain" ContentPlaceHolderID="ctMain" Runat="Server">
    <h1>文章编辑</h1>
    <asp:DropDownList ID="ctType" runat="server"></asp:DropDownList>
    <asp:TextBox ID="ctTitle" runat="server" MaxLength="100">标题</asp:TextBox>
    <div><CKEditor:CKEditorControl ID="ctContent" runat="server" Height="400px" 
        BasePath="~/Control/ckeditor"></CKEditor:CKEditorControl></div>
    <asp:Button ID="ctSubmit" runat="server" Text="提交" onclick="ctSubmit_Click" />
</asp:Content>
