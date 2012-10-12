using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manage_ArticleList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["publisher"] == "me")
        {
            PageHelper.RedirectWithQuery("publisher", Session["admin_id"].ToString());
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        string sqlExp = @"
SELECT [article].[id]
      ,[publisher]
      ,[class]
      ,[title]
      ,[content]
      ,[post_date]
      ,[edit_date]
      ,[view_count]
      ,[name]
  FROM [Tibet].[dbo].[article] LEFT JOIN
       [Tibet].[dbo].[admin]
    ON [publisher] = [admin].[id]
 WHERE (1 = 1)
";
        string condition = Request.QueryString["class"];
        if (condition != null)
        {
            sqlExp += string.Format(" and (class = '{0}')", condition.PrepareForSql());
        }
        condition = Request.QueryString["publisher"];
        if (condition != null)
        {
            sqlExp += string.Format(" and (publisher = '{0}')", condition.PrepareForSql());
        }
        sqlExp += @"ORDER BY [post_date] DESC";

        ctContentList.DataSource = SqlHelper.ExecuteAdapter(sqlExp);
        ctContentList.DataBind();
    }
    protected void ctContentPager_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["page"] == "all")
        {
            (sender as DataPager).QueryStringField = "";
            (sender as DataPager).PageSize = 100000;
            (sender as DataPager).NamingContainer.FindControl("ctContentPagerPanel").Visible = false;
        }
    }
    protected void ctShowAllPage_Click(object sender, EventArgs e)
    {
        PageHelper.RedirectWithQuery("page", "all");
    }
    protected void ctDelete_Load(object sender, EventArgs e)
    {
        (sender as LinkButton).Attributes.Add("OnClick", "return deleteConfirm();");
    }
    protected void ctDelete_Command(object sender, CommandEventArgs e)
    {
        DataHelper.CreateLog("删除文章 " + e.CommandArgument);
        string sqlExp = @"
DELETE FROM [Tibet].[dbo].[article]
      WHERE id = '{0}'
";
        sqlExp = string.Format(sqlExp, e.CommandArgument);
        if (SqlHelper.ExecuteNonQuery(sqlExp) != 1)
        {
            PageHelper.ShowResultPage("删除失败，待删除的文章不存在");
        }
    }
}