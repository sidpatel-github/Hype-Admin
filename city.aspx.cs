using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class city : System.Web.UI.Page
{
    Class1 c1 = new Class1();
    int flag = 1;

    private void setgrid()
    {
        DataTable dt = c1.select("select cid , cname as city , sid as state from city");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    private void setstate()
    {
        DataTable dt = c1.select("select * from state");
        DropDownList1.DataSource = dt;
        DropDownList1.DataTextField = "sname";
        DropDownList1.DataValueField = "sid";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("please select state", "-1"));
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
        {
            Response.Redirect("login.aspx");
        }

        if (!IsPostBack)
        {
            //Response.Write(Session["name"].ToString());
       //     RequiredFieldValidator1.Enabled = true;
       //     RequiredFieldValidator2.Enabled = true;
            Label1.Text = "WELCOME : ADMIN " + Session["name"].ToString();
            setstate();
            setgrid();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (HiddenField1.Value.Equals("insert") && !TextBox1.Text.Equals("") && !DropDownList1.SelectedItem.Value.ToString().Equals(""))
        {
            DataTable dt = c1.select("select cname from city where sid= '"+DropDownList1.SelectedValue.ToString()+"' ");
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
                c1.query("insert into city(cname,sid) values('" + TextBox1.Text + "','" + DropDownList1.SelectedItem.Value + "')");
                Response.Write("<script language=javascript>alert('SUCESSFULLY RECORDED');" + "<" + "/" + "script>");
//                Response.Write("successfully inserted !!");
                setgrid();
                cleardata();
            }
            else
            {
                Response.Write("<script language=javascript>alert('city already entered');" + "<" + "/" + "script>");
      //          Response.Write("city already entered");
                cleardata();
            }
        }
        else
        {
            c1.query("update city set cname='" + TextBox1.Text + "' , sid = '" + DropDownList1.SelectedValue + "' where cid='" + HiddenField2.Value + "' ");
            Response.Write("<script language=javascript>alert('SUCESSFULLY UPDATED');" + "<" + "/" + "script>");
            //   Response.Write("successfully updated !!");
            setgrid();
        }
        HiddenField1.Value = "insert";

    /*    Response.Write(DropDownList1.SelectedIndex.ToString());
        Response.Write(DropDownList1.SelectedItem.ToString());
        Response.Write(DropDownList1.SelectedValue.ToString());
        */
    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        HiddenField1.Value = "update";
        HiddenField2.Value = GridView1.Rows[e.NewSelectedIndex].Cells[2].Text;
        TextBox1.Text = GridView1.Rows[e.NewSelectedIndex].Cells[3].Text;

        for (int i = 0; i < DropDownList1.Items.Count; i++)
        {
            if (DropDownList1.Items[i].Value.Equals(GridView1.Rows[e.NewSelectedIndex].Cells[4].Text))
            {
                DropDownList1.SelectedIndex = i;
            }
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        c1.query("delete from city where cid ='" + GridView1.Rows[e.RowIndex].Cells[2].Text + "'");
        Response.Write("<script language=javascript>alert('SUCESSFULLY DELETED');" + "<" + "/" + "script>");
        setgrid();
        cleardata();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        DropDownList1.SelectedIndex = 0;
       // RequiredFieldValidator1.Enabled = false;
       // RequiredFieldValidator2.Enabled = false;
        HiddenField1.Value = "insert";
    }


    protected void  cleardata()
    {
        TextBox1.Text = "";
        DropDownList1.SelectedIndex = 0;
        HiddenField1.Value = "insert";
    
    }
    
}