<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminEdit.aspx.cs" Inherits="Manage_RenamePwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="原   密   码 :" Width="103px"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;
        <br />
        <asp:Label ID="Label2" runat="server" Text="修改后的密码:" Width="110px"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="重复密码:" Width="109px"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="重置" 
            Width="72px" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="确认" 
            Width="73px" />
    
    </div>
    </form>
</body>
</html>
