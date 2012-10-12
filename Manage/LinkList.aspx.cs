using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manage_LinkList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        string sqlExp = @"
SELECT [id]
      ,[name]
      ,[url]
  FROM [Tibet].[dbo].[link]
";
        ctContentList.DataSource = SqlHelper.ExecuteAdapter(sqlExp);
        ctContentList.DataBind();
    }
    protected void ctDelete_Load(object sender, EventArgs e)
    {
        (sender as LinkButton).Attributes.Add("OnClick", "return deleteConfirm();");
    }
    protected void ctDelete_Command(object sender, CommandEventArgs e)
    {
        DataHelper.CreateLog("删除友情链接 " + e.CommandArgument);
        string sqlExp = @"
DELETE FROM [Tibet].[dbo].[link]
      WHERE id = '{0}'
";
        sqlExp = string.Format(sqlExp, e.CommandArgument);
        if (SqlHelper.ExecuteNonQuery(sqlExp) != 1)
        {
            PageHelper.ShowResultPage("删除失败，待删除的友情链接不存在");
        }
    }
}