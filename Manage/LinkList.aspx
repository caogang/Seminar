<%@ Page Title="友情链接列表" Language="C#" MasterPageFile="~/Manage/Manage.master" AutoEventWireup="true" CodeFile="LinkList.aspx.cs" Inherits="Manage_LinkList" %>

<asp:Content ID="ctContentHead" ContentPlaceHolderID="ctHead" Runat="Server">
    <link rel="stylesheet" type="text/css" href='<%= "Style/LinkList.css".ResolveUrl() %>' />
</asp:Content>
<asp:Content ID="ctContentMain" ContentPlaceHolderID="ctMain" Runat="Server">
    <h1>友情链接列表</h1>
    <p id="list_extra">
        <a href='<%= "LinkEdit.aspx".ResolveUrl() %>'>添加友情链接</a>
    </p>
    <asp:ListView ID="ctContentList" runat="server">
        <LayoutTemplate>
            <table id="link_list" class="list">
                <tr>
                    <th>编号</th>
                    <th>名称</th>
                    <th>链接</th>
                    <th>操作</th>
                </tr>
                <tr runat="server" id="itemPlaceholder"></tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("id") %></td>
                <td><%# Eval("name").ToString().PrepareForHtml() %></td>
                <td><%# Eval("url").ToString().PrepareForHtml() %></td>
                <td>
                    <a href='<%= "LinkEdit.aspx".ResolveUrl() %>?id=<%# Eval("id") %>'>编辑</a>
                    <asp:LinkButton ID="ctDelete" runat="server" OnLoad="ctDelete_Load"
                        OnCommand="ctDelete_Command" CommandArgument='<%# Eval("id") %>'>删除</asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
