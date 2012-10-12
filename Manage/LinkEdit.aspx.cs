using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Manage_LinkEdit : System.Web.UI.Page
{
    private int linkId;

    protected void Page_Load(object sender, EventArgs e)
    {
        linkId = (Request.QueryString["id"] ?? "-1").ToInt();

        if (!IsPostBack)
        {
            #region 载入友情链接
            if (linkId != -1)
            {
                string sqlExp = @"
SELECT [id]
      ,[name]
      ,[url]
  FROM [Tibet].[dbo].[link]
 WHERE [id] = '{0}'
";
                sqlExp = string.Format(sqlExp, linkId);
                DataTable link = SqlHelper.ExecuteAdapter(sqlExp);

                ctName.Text = link.Rows[0]["name"].ToString();
                ctUrl.Text = link.Rows[0]["url"].ToString();
            }
            #endregion
        }
    }
    protected void ctSubmit_Click(object sender, EventArgs e)
    {
        string sqlExp;

        #region 准备数据
        string name = ctName.Text.PrepareForSql();
        string url = ctUrl.Text.PrepareForSql();
        url = url.Contains("://") ? url : "http://" + url;
        #endregion

        #region 创建日志
        DataHelper.CreateLog((linkId == -1) ? "添加友情链接" : "修改友情链接 " + linkId);
        #endregion

        #region 创建友情链接
        if (linkId == -1)
        {
            sqlExp = @"
INSERT INTO [Tibet].[dbo].[link]
           ([name]
           ,[url])
     VALUES
           (''
           ,'')
";
            if (SqlHelper.ExecuteNonQuery(sqlExp) != 1)
            {
                PageHelper.ShowResultPage("初始化友情链接失败，请联系管理员");
            }
            sqlExp = @"
  SELECT TOP 1 
         [id]
    FROM [Tibet].[dbo].[link]
   WHERE [name] = '' and
         [url] = ''
ORDER BY [id] DESC
";
            linkId = (int)(SqlHelper.ExecuteScalar(sqlExp) ?? -1);
            if (linkId == -1)
            {
                PageHelper.ShowResultPage("初始化友情链接失败，请联系管理员");
            }
        }
        #endregion

        #region 修改友情链接
        sqlExp = @"
UPDATE [Tibet].[dbo].[link]
   SET [name] = '{1}'
      ,[url] = '{2}'
 WHERE [id] = '{0}'
";
        sqlExp = string.Format(sqlExp, linkId, name, url);
        if (SqlHelper.ExecuteNonQuery(sqlExp) != 1)
        {
            PageHelper.ShowResultPage("提交失败");
        }
        PageHelper.ShowResultPage("提交成功", "LinkList.aspx");
        #endregion
    }
}