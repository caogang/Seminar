using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Manage_ArticleList : System.Web.UI.Page
{
    public static DataTable ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ds = SqlHelper.ExecuteAdapter("SELECT * FROM [Seminar].[dbo].[Article] ");
            this.Repeater1.DataSource = pds(ds, "page");
            Repeater1.DataBind();
        }
    }

    protected void change_password(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        int rowIndex = ((RepeaterItem)lnk.NamingContainer).ItemIndex;//获取点击的行号
        string id = ((Label)Repeater1.Items[rowIndex].FindControl("label1")).Text;//获得Label的值
        PageHelper.Redirect("AdminEdit.aspx?id=" + id);
    }

    protected void delete(object sender, EventArgs e)
    {
            LinkButton lnk = (LinkButton)sender;
            int rowIndex = ((RepeaterItem)lnk.NamingContainer).ItemIndex;//获取点击的行号
            string id = ((Label)Repeater1.Items[rowIndex].FindControl("label1")).Text;//获得Label的值
            object f = SqlHelper.ExecuteScalar("select name from admin where id='" + id + "'").ToString();
            int n = SqlHelper.ExecuteNonQuery("DELETE FROM admin WHERE id = '" + id + "'");
            if (n > 0)
            {
                ds = SqlHelper.ExecuteAdapter("select * from admin ");
                this.Repeater1.DataSource = pds(ds, "page");
                Repeater1.DataBind();
            }

    }

    protected void ddlp_SelectedIndexChanged(object sender, EventArgs e)
    {//脚模板中的下拉列表框更改时激发
        string pg = Convert.ToString((Convert.ToInt32(((DropDownList)sender).SelectedValue) - 1));//获取列表框当前选中项
        Response.Redirect("AdminList.aspx?page=" + pg);//页面转向
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        PageHelper.Redirect("AdminEdit.aspx");
    }
    protected void Repeater1_ItemDataBound(object source, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Footer)
        {
            DropDownList ddlp = (DropDownList)e.Item.FindControl("ddlp");

            HyperLink lpfirst = (HyperLink)e.Item.FindControl("hlfir");
            HyperLink lpprev = (HyperLink)e.Item.FindControl("hlp");
            HyperLink lpnext = (HyperLink)e.Item.FindControl("hln");
            HyperLink lplast = (HyperLink)e.Item.FindControl("hlla");

            pds(ds, "page").CurrentPageIndex = ddlp.SelectedIndex;

            int n = Convert.ToInt32(pds(ds, "page").PageCount);//n为分页数
            int i = Convert.ToInt32(pds(ds, "page").CurrentPageIndex);//i为当前页

            Label lblpc = (Label)e.Item.FindControl("lblpc");
            lblpc.Text = n.ToString();
            Label lblp = (Label)e.Item.FindControl("lblp");
            lblp.Text = Convert.ToString(pds(ds, "page").CurrentPageIndex + 1);

            if (!IsPostBack)
            {
                for (int j = 0; j < n; j++)
                {
                    ddlp.Items.Add(Convert.ToString(j + 1));
                }
            }

            if (i <= 0)
            {
                lpfirst.Enabled = false;
                lpprev.Enabled = false;
                lplast.Enabled = true;
                lpnext.Enabled = true;
            }
            else
            {
                lpprev.NavigateUrl = "?page=" + (i - 1);
            }
            if (i >= n - 1)
            {
                lpfirst.Enabled = true;
                lplast.Enabled = false;
                lpnext.Enabled = false;
                lpprev.Enabled = true;
            }
            else
            {
                lpnext.NavigateUrl = "?page=" + (i + 1);
            }

            lpfirst.NavigateUrl = "?page=0";//向本页传递参数page
            lplast.NavigateUrl = "?page=" + (n - 1);

            ddlp.SelectedIndex = Convert.ToInt32(pds(ds, "page").CurrentPageIndex);//更新下拉列表框中的当前选中页序号
        }
    }
    private PagedDataSource pds(DataTable ds, string a)
    {
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = ds.DefaultView;
        pds.AllowPaging = true;//允许分页
        pds.PageSize = 5;//单页显示项数
        pds.CurrentPageIndex = Convert.ToInt32(Request.QueryString[a]);
        return pds;
    }

    protected void Bou(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        int rowIndex = ((RepeaterItem)lnk.NamingContainer).ItemIndex;//获取点击的行号
        string id = ((Label)Repeater1.Items[rowIndex].FindControl("label1")).Text;//获得Label的值
        int n = SqlHelper.ExecuteNonQuery("UPDATE [Seminar].[dbo].[Article] SET [Boutique] = (Boutique+1)%2 WHERE id=" + id);
        if (n > 0)
        {
            ds = SqlHelper.ExecuteAdapter("SELECT * FROM [Seminar].[dbo].[Article]");
            this.Repeater1.DataSource = pds(ds, "page");
            Repeater1.DataBind();
        }

    }

    protected void R_Top(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        int rowIndex = ((RepeaterItem)lnk.NamingContainer).ItemIndex;//获取点击的行号
        string id = ((Label)Repeater1.Items[rowIndex].FindControl("label1")).Text;//获得Label的值
        int n = SqlHelper.ExecuteNonQuery("UPDATE [Seminar].[dbo].[Article] SET [Top] = (Top+1)%2 WHERE id=" + id);
        if (n > 0)
        {
            ds = SqlHelper.ExecuteAdapter("SELECT * FROM [Seminar].[dbo].[Article]");
            this.Repeater1.DataSource = pds(ds, "page");
            Repeater1.DataBind();
        }
    }
}