using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manage_Manage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataHelper.Debug();

        // 避免系统设置影响 Datetime 格式
        System.Threading.Thread.CurrentThread.CurrentCulture =
            new System.Globalization.CultureInfo("zh-CN", false);

        if ((Session["admin_id"] == null) || (Session["admin_name"] == null))
        {
            PageHelper.Redirect("~/Error/404");
        }

        if (!SqlHelper.Connectable)
        {
            PageHelper.ShowResultPage("严重异常，无法连接到数据库");
        }

        Page.Title += " - 西藏职业技术学院党委组织宣传部网站管理系统";
    }
}