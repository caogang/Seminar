<%@ Page Title="文章列表" Language="C#" MasterPageFile="~/Manage/Manage.master" AutoEventWireup="true" CodeFile="ArticleList.aspx.cs" Inherits="Manage_ArticleList" %>

<asp:Content ID="ctContentHead" ContentPlaceHolderID="ctHead" Runat="Server">
    <link rel="stylesheet" type="text/css" href='<%= "Style/ArticleList.css".ResolveUrl() %>' />
</asp:Content>
<asp:Content ID="ctContentMain" ContentPlaceHolderID="ctMain" Runat="Server">
    <h1>文章列表</h1>
    <p id="list_extra">
        <a href='<%= "ArticleList.aspx".ResolveUrl() %>?publisher=me'>我的文章</a>
        <a href='<%= "ArticleEdit.aspx".ResolveUrl() %>'>发布文章</a>
    </p>
    <asp:ListView ID="ctContentList" runat="server">
        <LayoutTemplate>
            <table id="article_list" class="list">
                <tr>
                    <th>编号</th>
                    <th>分类</th>
                    <th>标题</th>
                    <th>发布时间</th>
                    <th>发布者</th>
                    <th>操作</th>
                </tr>
                <tr runat="server" id="itemPlaceholder"></tr>
            </table>
            <asp:Panel ID="ctContentPagerPanel" runat="server" CssClass="pager">
                页码：
                <asp:DataPager ID="ctContentPager" runat="server" PageSize="20" QueryStringField="page"
                    OnLoad="ctContentPager_Load">
                    <Fields>
                        <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False" 
                            FirstPageText="首页" PreviousPageText="上一页 " />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ShowPreviousPageButton="False" ShowLastPageButton="True" 
                            LastPageText="尾页" NextPageText=" 下一页" />
                    </Fields>
                </asp:DataPager>
                <a href='<%= PageHelper.GetUrlWithQuery("page", "all") %>'>全部</a>
            </asp:Panel>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("id") %></td>
                <td><a href='<%# PageHelper.GetUrlWithQuery("class", Eval("class").ToString()) %>'>
                    <%# Eval("class") %></a></td>
                <td><a href='<%= "~/Content".ResolveUrl() %>/<%# Eval("id") %>' target="_blank">
                    <%# Eval("title").ToString().PrepareForHtml() %></a></td>
                <td><%# Eval("post_date") %></td>
                <td><a href='<%# PageHelper.GetUrlWithQuery("publisher", Eval("publisher").ToString()) %>'>
                    <%# Eval("name").ToString().PrepareForHtml() %></a></td>
                <td>
                    <a href='<%= "ArticleEdit.aspx".ResolveUrl() %>?id=<%# Eval("id") %>'>编辑</a>
                    <asp:LinkButton ID="ctDelete" runat="server" OnLoad="ctDelete_Load"
                        OnCommand="ctDelete_Command" CommandArgument='<%# Eval("id") %>'>删除</asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
