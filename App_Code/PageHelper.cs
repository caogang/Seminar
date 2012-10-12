using System.Web;
using System.Web.UI;

/// <summary>
/// 用于执行页面相关的操作
/// </summary>
public static class PageHelper
{
    /// <summary>
    /// 获取当前页面
    /// </summary>
    /// <returns>当前页面</returns>
    public static Page GetCurrentPage()
    {
        return (HttpContext.Current.CurrentHandler as Page ?? new Page());
    }
    
    /// <summary>
    /// 获取添加或修改 Query 参数后的Url
    /// </summary>
    /// <param name="name">Query 参数名</param>
    /// <param name="value">Query 参数值</param>
    /// <returns></returns>
    public static string GetUrlWithQuery(string name, string value)
    {
        string query = HttpContext.Current.Request.Url.Query;
        if (name != string.Empty)
        {
            if ((query != string.Empty) && (query != "?"))
            {   //原query不为空
                int startOfName = query.IndexOf("&" + name + "=");
                if (startOfName == -1)
                {
                    startOfName = query.IndexOf("?" + name + "=");
                }
                if (startOfName != -1)
                {   //含有同名参数
                    int endOfValue = query.IndexOf("&", startOfName + 1);
                    if (endOfValue != -1)
                    {   //同名参数后有其他参数
                        query = query.Substring(0, startOfName + 1) + name + "=" + value +
                            query.Substring(endOfValue);
                    }
                    else
                    {   //同名参数后没有其他参数
                        query = query.Substring(0, startOfName + 1) + name + "=" + value;
                    }
                }
                else
                {   //不含有同名参数
                    query += "&" + name + "=" + value;
                }
            }
            else
            {   //原query不为空
                query = "?" + name + "=" + value;
            }
        }
        return HttpContext.Current.Request.Url.LocalPath + query;
    }

    /// <summary>
    /// 重定向页面并添加或修改 Query 参数
    /// </summary>
    /// <param name="name">Query 参数名</param>
    /// <param name="value">Query 参数值</param>
    public static void RedirectWithQuery(string name, string value)
    {
        Redirect(GetUrlWithQuery(name, value));
    }

    /// <summary>
    /// 重定向，其实就是 Response.Redirect()
    /// </summary>
    /// <param name="url">重定向到的Url</param>
    public static void Redirect(string url)
    {
        if (GetCurrentPage().ResolveUrl(url) != HttpContext.Current.Request.Url.PathAndQuery)
        {
            HttpContext.Current.Response.Redirect(GetCurrentPage().ResolveUrl(url), true);
        }
    }

    /// <summary>
    /// 跳转到结果页面并显示操作结果
    /// </summary>
    /// <param name="result">操作结果的描述</param>
    /// <param name="redirect">显示结果后的自动重定向到的页面</param>
    public static void ShowResultPage(string result, string redirect = null)
    {
        if (redirect != null)
        {
            redirect = redirect.ResolveUrl();
            result = result.PrepareForHtml();
            result += string.Format("<br /><br /><a href=\"{0}\">如果您的浏览器没有自动跳转，请点击这里</a>", 
                redirect);
            HttpContext.Current.Session["ResultRedirect"] = redirect;
        }
        HttpContext.Current.Session["Result"] = result;
        if (HttpContext.Current.Request.Url.AbsolutePath.Contains("/Manage/"))
        {
            Redirect("~/Manage/Result.aspx");
        }
        else
        {
            Redirect("~/Error");
        }
    }

    /// <summary>
    /// 刷新页面
    /// </summary>
    public static void Refresh()
    {
        HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.PathAndQuery);
    }

    /// <summary>
    /// 显示带有一段消息和一个确认按钮的警告框
    /// </summary>
    /// <param name="page">当前页面</param>
    /// <param name="message">弹出的对话框中显示的纯文本</param>
    public static void ShowAlert(string message)
    {
        Page page = GetCurrentPage();
        message = message.Replace('\'', '_');
        page.ClientScript.RegisterStartupScript(page.GetType(), "message",
            "<script>alert('"+ message +"');</script>");
    }
}
