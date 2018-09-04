using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class state : System.Web.UI.Page
{

    Class1 c1 = new Class1();
    int flag = 1;
    private void setgrid()
    {
        DataTable dt = c1.select("select sid , sname as state from state");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (HiddenField1.Value.Equals("insert") && !TextBox1.Text.Equals(""))
        {
            DataTable dt = c1.select("select sname from state");
            foreach (DataRow row in dt.Rows)
            {
                foreach (string item in row.ItemArray)
                {
                    if (TextBox1.Text.ToLower().Equals(item.ToLower()))
                    {
                        flag = 0;
                        break;
                    }
                }
            }
            if (flag == 1)
            {
                c1.query("insert into state(sname) values('" + TextBox1.Text + "')");
                Response.Write("<script language=javascript>alert('SUCESSFULLY RECORDED');" + "<" + "/" + "script>");
               // Response.Write("successfully inserted !!");
                setgrid();
                cleardata();
            }
            else
            {
                Response.Write("<script language=javascript>alert('STATE FOUND IN DATABASE');" + "<" + "/" + "script>");
                //Response.Write("state already entered");
                setgrid();
                cleardata();
            }
        }
        else
        {
            c1.query("update state set sname='" + TextBox1.Text + "' where sid='" + HiddenField2.Value + "' ");
            Response.Write("<script language=javascript>alert('SUCESSFULLY UPDATED');" + "<" + "/" + "script>");
//            Response.Write("successfully updated !!");
            setgrid();
            cleardata();
        }
        HiddenField1.Value = "insert";
    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        HiddenField1.Value = "update";
        HiddenField2.Value = GridView1.Rows[e.NewSelectedIndex].Cells[2].Text;
        TextBox1.Text = GridView1.Rows[e.NewSelectedIndex].Cells[3].Text;
        
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        c1.query("delete from state where sid ='" + GridView1.Rows[e.RowIndex].Cells[2].Text + "'");
        Response.Write("<script language=javascript>alert('SUCESSFULLY DELETED');" + "<" + "/" + "script>");
        setgrid();

    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        TextBox1.Text = "";
        

    }

    protected void cleardata()
    {
        TextBox1.Text = "";
        HiddenField1.Value = "insert";
        
    }
}