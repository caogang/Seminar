<%@ Page Title="首页" Language="C#" MasterPageFile="~/Manage/Manage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Manage_Index" %>

<asp:Content ID="ctContentHead" ContentPlaceHolderID="ctHead" Runat="Server">
    <link rel="stylesheet" type="text/css" href='<%= "Style/Index.css".ResolveUrl() %>' />
</asp:Content>
<asp:Content ID="ctContentMain" ContentPlaceHolderID="ctMain" Runat="Server">
    <h1>欢迎进入后台管理系统</h1>
    <ul id="index">
        <li><a><%= Session["admin_name"].ToString() %></a>
            <ul>
                <li><a href='<%= "Logout.aspx".ResolveUrl() %>'>退出登录</a></li>
                <li><a href='<%= "AdminEdit.aspx".ResolveUrl() %>?id=<%= Session["admin_id"].ToString() %>'>修改密码</a></li>
           </ul>
        </li>
        <li><a href='<%= "ArticleList.aspx".ResolveUrl() %>'>文章管理</a>
            <ul>
                <li><a href='<%= "ArticleList.aspx".ResolveUrl() %>'>文章列表</a></li>
                <li><a href='<%= "ArticleList.aspx".ResolveUrl() %>?publisher=me'>我的文章</a></li>
                <li><a href='<%= "ArticleEdit.aspx".ResolveUrl() %>'>发布文章</a></li>
            </ul>
        </li>
        <li><a href='<%= "LinkList.aspx".ResolveUrl() %>'>友情链接管理</a>
            <ul>
                <li><a href='<%= "LinkList.aspx".ResolveUrl() %>'>友情链接列表</a></li>
                <li><a href='<%= "LinkEdit.aspx".ResolveUrl() %>'>添加友情链接</a></li>
            </ul>
        </li>
        
    </ul>
</asp:Content>
