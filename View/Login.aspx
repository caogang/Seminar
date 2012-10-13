<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="View_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Manage/Index.aspx" 
            DisplayRememberMe="False" FailureText="您的登录不成功！请重试！" 
            onauthenticate="Login1_Authenticate" PasswordLabelText="密码：" 
            PasswordRequiredErrorMessage="必须填写密码！" RememberMeText="" 
            UserNameLabelText="用户名：" UserNameRequiredErrorMessage="必须填写用户名！" 
            ViewStateMode="Enabled" >
        </asp:Login>
    
    </div>
    </form>
</body>
</html>
