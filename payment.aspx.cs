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
using System.IO;

public partial class payment : System.Web.UI.Page
{
    Class1 c1 = new Class1(); int a111;
    SqlConnection con = new SqlConnection(Class1.datasource);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            Label2.Text = "WELCOME : ADMIN " + Session["name"].ToString();
            //Response.Write(Session["name"].ToString());
            setworker();
            workerhoarding();

        }
    }

    private void workerhoarding()
    {
        DataTable dt1 = c1.select("select count(*) as 'no of order',register.username from workerdetail as w1,register where w1.uid=register.uid group by w1.uid,register.username union select '0' as 'count',register.username from register where register.usertype='worker' and register.uid not in(select distinct(uid) from workerdetail) order by username ASC");
        GridView2.DataSource = dt1;
        GridView2.DataBind();

    }
    
   
    private void setworker()
    {
        DataTable dt = c1.select("select * from register where usertype = 'worker'");
        DropDownList1.DataSource = dt;
        DropDownList1.DataTextField = "username";
        DropDownList1.DataValueField = "uid";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("please select worker", "-1"));
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        setgridbyworker();
    }


    private void setgridbyworker()
    {
        SqlCommand cmd1 = new SqlCommand();
        cmd1.CommandType = CommandType.Text;
        cmd1.CommandText = "select uid from register where username = '" + DropDownList1.SelectedItem + "'";
        cmd1.Connection = con;
        con.Open();
        SqlDataReader reader111 = cmd1.ExecuteReader();
        while (reader111.Read())
        {
            a111 = reader111.GetInt32(0);
        }
        reader111.Close();

        SqlDataAdapter sda1 = new SqlDataAdapter("Select workerdetail.hid,hoarding.uid,btype,size,bookdate,area,image,status.status,status.remark,workerdetail.locfinalimage from status,hoarding,workerdetail where workerdetail.uid='" + a111.ToString() + "' and status.statusid=workerdetail.statusid and status.hid=hoarding.hid and workerdetail.hid=hoarding.hid", con);
        DataTable dt1 = new DataTable();
        sda1.Fill(dt1);
        //        dt1.Columns.Add("price");

        GridView1.DataSource = dt1;
        GridView1.DataBind();
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            String[] ar = dt1.Rows[i][3].ToString().Split('*');
            String ans = (Convert.ToInt32(ar[0]) * Convert.ToInt32(ar[1])) + "";
            //dt1.Rows[i]["price"] = ans;

            GridView1.Rows[i].Cells[0].Text = ans;
        }
        string a1;
        int a = 0;
        for (int i = 0; i < dt1.Rows.Count; i++)
        {

            a += Convert.ToInt32(GridView1.Rows[i].Cells[0].Text);


            //            GridView1.Rows[i].Cells[0].Text = ans;
        } a1 = a.ToString();
        Label1.Text = a1;
    }
    



}

