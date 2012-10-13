using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class View_Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       /* switch ((Page.RouteData.Values["info"] ?? "").ToString())
        {
            case "404":
                PageHelper.ShowResultPage("您访问的页面不存在", "~/Index");
                break;
            default:
                break;
        }

        object redirect = Session["ResultRedirect"];
        if (redirect != null)
        {
            HtmlMeta autoRefresh = new HtmlMeta();
            autoRefresh.HttpEquiv = "refresh";
            autoRefresh.Content = "5;url=" + redirect.ToString();
            Page.Header.Controls.Add(autoRefresh);
        }
        ctContent.Text = (Session["Result"] ??
            "请使用 PageHelper.ShowResultPage 方法而不是直接跳转到本页").ToString();*/
    }
}