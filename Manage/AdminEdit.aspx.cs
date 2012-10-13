using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manage_RenamePwd : System.Web.UI.Page
{
    string userid;
    protected void Page_Load(object sender, EventArgs e)
    {
       userid = Session["admin_id"].ToString();
    }
    protected void reload()
    {
        TextBox1.Text = null;
        TextBox2.Text = null;
        TextBox3.Text = null;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        reload();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string oldPwd = DataHelper.PasswordEncrypt(TextBox1.Text);
        string newPwd = DataHelper.PasswordEncrypt(TextBox2.Text);
        string repeatPwd = DataHelper.PasswordEncrypt(TextBox3.Text);
        string sql="SELECT PassWord  FROM [Seminar].[dbo].[User] where [ID]="+userid+"";
        string pwd = SqlHelper.ExecuteScalar(sql).ToString();
        if (oldPwd.Equals(pwd))
        {
            if (newPwd.Equals(repeatPwd))
            {
                string updatesql = "UPDATE [Seminar].[dbo].[User] SET [PassWord] = '" + newPwd + "' WHERE [ID] = " + userid + "";
                SqlHelper.ExecuteNonQuery(updatesql);
                /*PageHelper.ShowAlert("修改成功！");
                reload();
                PageHelper.ShowResultPage("修改成功！", "~/View/Default.aspx");*/
                Response.Write("<script language='javascript'>alert('修改成功！');location='Index.aspx';</script>");
            }
            else
            {
                PageHelper.ShowAlert("两次密码输入不一致！请重新输入！");
                reload();
                return;
            }
        }
        else
        {
            PageHelper.ShowAlert("原密码不正确！请重新输入！");
            reload();
            return;
        }
    }
}