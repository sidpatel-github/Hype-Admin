using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Net;

public partial class registerclient : System.Web.UI.Page
{
    Class1 c1 = new Class1();
    private void setgrid()
    {
        DataTable dt = c1.select("select uid,username,name,occupation,address,phoneno,email,active,vercode from register where usertype='client'");
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
         //   Label1.Text = "WELCOME : ADMIN " + Session["name"].ToString();
            //Response.Write(Session["name"].ToString());
            setgrid();
        }
    }



    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        c1.query("delete from register where uid ='" + GridView2.Rows[e.RowIndex].Cells[1].Text + "' and usertype='client'");
        setgrid();
    }


}