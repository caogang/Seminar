using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Security.Cryptography;

public partial class ArticleEdit : System.Web.UI.Page
{
    private int articleId;

    protected void Page_Load(object sender, EventArgs e)
    {
        articleId = (Request.QueryString["id"] ?? "-1").ToInt();

        if (!IsPostBack)
        {
            #region 标题
            ctTitle.Attributes.Add("onfocus", "if (this.value=='标题') this.value=''");
            ctTitle.Attributes.Add("onblur", "if (this.value=='') this.value='标题'");
            #endregion

            #region 提交按钮
            ctSubmit.Attributes.Add("OnClick", "return preSubmit();");
            #endregion

            #region 加载 CKFinder
            CKFinder.FileBrowser ckfinder = new CKFinder.FileBrowser();
            ckfinder.BasePath = "~/Control/ckfinder/".ResolveUrl();
            ckfinder.SetupCKEditor(ctContent);
            #endregion

            #region 加载分类
            ctType.Items.Add("分类");
            foreach (string articleClass in DataHelper.ArticleClass)
            {
                ctType.Items.Add(articleClass);
            }
            #endregion

            #region 载入文章
            if (articleId != -1)
            {
                string sqlExp = @"
SELECT [class]
      ,[title]
      ,[content]
  FROM [Tibet].[dbo].[article]
 WHERE [id] = '{0}'
";
                sqlExp = string.Format(sqlExp, articleId);
                DataTable article = SqlHelper.ExecuteAdapter(sqlExp);

                (ctType.Items.FindByValue(article.Rows[0]["class"].ToString()) ??
                    ctType.Items[0]).Selected = true;
                ctTitle.Text = article.Rows[0]["title"].ToString();
                ctContent.Text = article.Rows[0]["content"].ToString();
            }
            #endregion
        }
    }

    protected void ctSubmit_Click(object sender, EventArgs e)
    {
        string sqlExp;

        #region 准备数据
        string title = ctTitle.Text.PrepareForSql();
        string type = DataHelper.ArticleClass.Contains(ctType.Text) ? ctType.Text : "";
        string content = ctContent.Text;
        DateTime datetime = DateTime.Now;
        #endregion

        #region 创建日志
        DataHelper.CreateLog((articleId == -1) ? "发布文章" : "修改文章 " + articleId);
        #endregion

        #region 创建文章
        if (articleId == -1)
        {
            sqlExp = @"
INSERT INTO [Tibet].[dbo].[article]
           ([publisher]
           ,[post_date])
     VALUES
           ('{0}'
           ,'{1}')
";
            sqlExp = string.Format(sqlExp, Session["admin_id"], datetime);
            if (SqlHelper.ExecuteNonQuery(sqlExp) != 1)
            {
                PageHelper.ShowResultPage("初始化文章失败，请联系管理员");
            }
            sqlExp = @"
  SELECT TOP 1 
         [id]
    FROM [Tibet].[dbo].[article]
   WHERE [publisher] = '{0}' and
         [post_date] = '{1}'
ORDER BY [edit_date] DESC
";
            sqlExp = string.Format(sqlExp, Session["admin_id"], datetime);
            articleId = (int)(SqlHelper.ExecuteScalar(sqlExp) ?? -1);
            if (articleId == -1)
            {
                PageHelper.ShowResultPage("初始化文章失败，请联系管理员");
            }
        }
        #endregion

        #region 修改文章
        sqlExp = @"
UPDATE [Tibet].[dbo].[article]
   SET [class] = '{1}'
      ,[title] = '{2}'
      ,[content] = '{3}'
      ,[edit_date] = '{4}'
 WHERE [id] = '{0}'
";
        sqlExp = string.Format(sqlExp, articleId, type, title, content, datetime);
        if (SqlHelper.ExecuteNonQuery(sqlExp) != 1)
        {
            PageHelper.ShowResultPage("提交失败");
        }
        PageHelper.ShowResultPage("提交成功", "ArticleList.aspx");
        #endregion
    }
}