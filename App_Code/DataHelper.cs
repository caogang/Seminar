using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

/// <summary>
/// 数据处理及某些常量
/// </summary>
public static class DataHelper
{
    /// <summary>
    /// 用不可逆算法加密密码
    /// </summary>
    /// <param name="password">原密码字符串</param>
    /// <returns>加密后的字符串</returns>
    public static string PasswordEncrypt(string password)
    {
        return BitConverter.ToString(
            new System.Security.Cryptography.SHA1CryptoServiceProvider().ComputeHash(
                Encoding.Default.GetBytes(
                    "Seminar_" + password
                )
            )
        ).Replace("-", "");
    }

    /// <summary>
    /// 为 SQL 语句准备字符串，替换某些字符
    /// </summary>
    /// <param name="source">源字符串</param>
    /// <returns>替换后的字符串</returns>
    public static string PrepareForSql(this string source)
    {
        return source
            .Replace("\u200b", "")
            .Replace("'", "''");
    }
    /// <summary>
    /// 为 HTML 准备字符串，替换某些字符
    /// </summary>
    /// <param name="source">源字符串</param>
    /// <returns>替换后的字符串</returns>
    public static string PrepareForHtml(this string source)
    {
        Regex anyChar = new Regex("(.)");
        return anyChar.Replace(source, "$1\u200b")
            .Replace("&", "&amp;")
            .Replace(" ", "&nbsp;")
            .Replace("<", "&lt;")
            .Replace(">", "&gt;")
            .Replace("\"", "&quot;")
            .Replace("'", "&apos;")
            .Replace("\n", "<br />")
            ;
    }

    /// <summary>
    /// 将 URL 转换为在请求客户端可用的 URL
    /// </summary>
    /// <param name="source">与 TemplateSourceDirectory 属性相关联的 URL</param>
    /// <returns>转换后的 URL</returns>
    public static string ResolveUrl(this string source)
    {
        return PageHelper.GetCurrentPage().ResolveUrl(source);
    }

    /// <summary>
    /// 转换为整型
    /// </summary>
    /// <param name="source">源字符串</param>
    /// <returns>转换成的整型，出错时返回 -1</returns>
    public static int ToInt(this string source)
    {
        int result;
        try
        {
            result = Convert.ToInt32(source);
        }
        catch
        {
            result = -1;
        }
        return result;
    }

    #region 内建文章分类
    /// <summary>
    /// 内建文章分类
    /// </summary>
    public static readonly HashSet<string> ArticleClass = new HashSet<string>(new string[]{
        "组织工作",
        "党的知识",
        "原著导读",
        "先进事迹",
        "创先争优",
        "党务公开",
        "工作文件下载",
        "时事关注",
        "工作制度",
        "理论中心",
        "党校在线",
        "组织工作",
        });
    #endregion

    /// <summary>
    /// 创建日志
    /// </summary>
    /// <param name="info">日志内容</param>
    public static void CreateLog(string info)
    {
        DateTime datetime = DateTime.Now;
        info = info.PrepareForSql();
        string ip = HttpContext.Current.Request.UserHostAddress;
        string operater = HttpContext.Current.Session["admin_id"].ToString() ?? "-1";
        string sqlExp = @"
INSERT INTO [Tibet].[dbo].[log]
           ([time]
           ,[info]
           ,[ip]
           ,[operater])
     VALUES
           ('{0}'
           ,'{1}'
           ,'{2}'
           ,'{3}')
";
        sqlExp = string.Format(sqlExp, datetime, info, ip, operater);
        SqlHelper.ExecuteNonQuery(sqlExp);
    }

    /// <summary>
    /// 在 Debug 模式下执行 Debug 处理
    /// </summary>
    [System.Diagnostics.Conditional("DEBUG")]
    public static void Debug()
    {
        if (SqlHelper.ExceptionMessage != "")
        {
            PageHelper.ShowResultPage(SqlHelper.ExceptionMessage.PrepareForHtml());
        }
    }
}