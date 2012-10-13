<%@ Page Title="文章列表" Language="C#" MasterPageFile="~/Manage/Manage.master" AutoEventWireup="true" CodeFile="ArticleList.aspx.cs" Inherits="Manage_ArticleList" %>

<asp:Content ID="ctContentHead" ContentPlaceHolderID="ctHead" Runat="Server">
    <link rel="stylesheet" type="text/css" href='<%= "Style/ArticleList.css".ResolveUrl() %>' />
</asp:Content>
<asp:Content ID="ctContentMain" ContentPlaceHolderID="ctMain" Runat="Server">
    <h1>文章列表</h1>
    <p id="list_extra">
        <a href='<%= "ArticleEdit.aspx".ResolveUrl() %>'>发布文章</a>
    </p>
     <asp:Repeater ID="Repeater1" runat="server"  
        OnItemDataBound="Repeater1_ItemDataBound">
    <HeaderTemplate>
        <table id="admin_list" class="list">
            <tr>
                <th>编号</th>
                <th>标题</th>
                <th>内容</th>
                <th>分类</th>
                <th>图片</th>
                <th>发布时间</th>
                <th>精品</th>
                <th>置顶</th>
                <th>操作</th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
            <tr>
                <a href='<%= "ArticleList.aspx".ResolveUrl() %>?id=<%#DataBinder.Eval(Container.DataItem,"id")%>'></a> 
                <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"id") %>' visible = "false"></asp:Label>
                <td><%#DataBinder.Eval(Container.DataItem,"ID")%> </td>
                <td><%#DataBinder.Eval(Container.DataItem,"Title").ToString().PrepareForHtml()%> </td>
                <td><%#DataBinder.Eval(Container.DataItem,"Content")%> </td>
                <td><%#DataBinder.Eval(Container.DataItem,"Class")%> </td>
                <td><%#DataBinder.Eval(Container.DataItem, "Picture").ToString().PrepareForHtml()%> </td>
                <td><%#DataBinder.Eval(Container.DataItem, "PostDate")%> </td>
                <td><%#DataBinder.Eval(Container.DataItem, "Boutique")%> </td>
                <td><%#DataBinder.Eval(Container.DataItem, "Top")%> </td>
                <td>
                    <asp:LinkButton ID="Button1" runat="server" Text="修改"  OnClick="change_password"/>
                    <asp:LinkButton ID="Bou" runat="server" Text="精品"  OnClick="Bou"/>
                    <asp:LinkButton ID="Top" runat="server" Text="置顶"  OnClick="R_Top"/>             
                    <asp:LinkButton ID="Button3" runat="server" Text="删除" OnClick="delete" />
                </td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
        <div class="pager">
            共<asp:Label ID="lblpc" runat="server" Text="Label"></asp:Label>页 当前为第
            <asp:Label ID="lblp" runat="server" Text="Label"></asp:Label>页
            <asp:HyperLink ID="hlfir" runat="server" Text="首页"></asp:HyperLink>
            <asp:HyperLink ID="hlp" runat="server" Text="上一页"></asp:HyperLink>
            <asp:HyperLink ID="hln" runat="server" Text="下一页"></asp:HyperLink>
            <asp:HyperLink ID="hlla" runat="server" Text="尾页"></asp:HyperLink>
                跳至第
                <asp:DropDownList ID="ddlp" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlp_SelectedIndexChanged" >
                </asp:DropDownList>页
        </div>
    </FooterTemplate>
    </asp:Repeater>
</asp:Content>
