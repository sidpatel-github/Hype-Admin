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

public partial class status : System.Web.UI.Page
{
    Class1 fun = new Class1();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            Label1.Text = "WELCOME : ADMIN " + Session["name"].ToString();
            //Response.Write(Session["name"].ToString());
            setgrid();
        }

    }
    private void setgrid()
    {
        DataTable dt = fun.select("select s.statusid,s.hid,s.status,s.date,s.time,s.remark from status as s ");
        GridView4.DataSource = dt;
        GridView4.DataBind();
    }

    protected void GridView4_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    public void cleardata()
    {



    }

    protected void GridView4_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {



    }



    protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}