using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class View_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        String username = Login1.UserName;
        String pwd = DataHelper.PasswordEncrypt(Login1.Password);
        string t = DataHelper.PasswordEncrypt("admin");
        string sql="SELECT *  FROM [Seminar].[dbo].[User] where [UserName]='"+username+"' and [PassWord]='"+pwd+"'";
        object user = SqlHelper.ExecuteScalar(sql);
        if (user != null)
        {
            e.Authenticated = true;
            Session["admin_id"] = user;
        }
        else
        {
            e.Authenticated = false;
        }
       /* SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Seminar"].ConnectionString.ToString());
        connection.Open();
        SqlCommand mycommand = new SqlCommand();
        mycommand.Connection = connection;
        mycommand.CommandText = "SELECT *  FROM [Seminar].[dbo].[User] where [UserName]='"+username+"' and [PassWord]='"+pwd+"'";
        object t= mycommand.ExecuteScalar();
        if (t != null)
        {
            e.Authenticated = true;
            Session["Admin_ID"] = username;
        }
        else
        {
            e.Authenticated = false;
        }
        conn.close();*/
    }
}