using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;



public partial class feedback : System.Web.UI.Page
{
    Class1 c1 = new Class1();
    int selectedstate, selectedcity;
    String option;

    private void setgridbyarea()
    {
        DataTable dt = c1.select("Select feedback.hid,register.username,hoarding.btype,hoarding.area,feedback.rating,feedback.feed from register,hoarding,feedback where register.uid = feedback.uid and feedback.hid = hoarding.hid and hoarding.area = '" + DropDownList4.SelectedValue.ToString() + "' order by hoarding.hid asc");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    private void setgridbybanner()
    {
        DataTable dt1 = c1.select("Select feedback.hid,register.username,hoarding.btype,hoarding.area,feedback.rating,feedback.feed from register,hoarding,feedback where register.uid = feedback.uid and feedback.hid = hoarding.hid and hoarding.btype = '" + DropDownList3.SelectedValue.ToString() + "' and hoarding.city='" + DropDownList2.SelectedItem.ToString() + "' and hoarding.state='" + DropDownList1.SelectedItem.ToString() + "' order by hoarding.hid asc");
        GridView1.DataSource = dt1;
        GridView1.DataBind();
    }


    private void setgridbyrating()
    {
        DataTable dt1 = c1.select("Select feedback.hid,register.username,hoarding.btype,hoarding.area,feedback.rating,feedback.feed from register,hoarding,feedback where register.uid = feedback.uid and feedback.hid = hoarding.hid and feedback.rating >= '" + DropDownList5.SelectedValue.ToString() + "' and hoarding.city='" + DropDownList2.SelectedItem.ToString() + "' and hoarding.state='" + DropDownList1.SelectedItem.ToString() + "'order by hoarding.hid asc ");
        GridView1.DataSource = dt1;
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
                Label6.Text = "WELCOME : ADMIN " + Session["name"].ToString();
                //Response.Write(Session["name"].ToString());
                setstate();
                setbanner();
                setcity();
                setarea();
                setgridbyarea();


            }
    }


    private void setstate()
    {
        DataTable dt = c1.select("select * from state");
        DropDownList1.DataSource = dt;
        DropDownList1.DataTextField = "sname";
        DropDownList1.DataValueField = "sid";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("please select state", "-1"));
        DropDownList5.Items.Insert(0, new ListItem("please select rating", "-1"));
    }

    private void setcity()
    {
        selectedstate = int.Parse(DropDownList1.SelectedValue);
        DataTable dt = c1.select("select * from city where sid='" + selectedstate + "'");
        DropDownList2.DataSource = dt;
        DropDownList2.DataTextField = "cname";
        DropDownList2.DataValueField = "cid";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("please select city", "-1"));
    }

    private void setbanner()
    {
        DataTable dt = c1.select("select * from banner");
        DropDownList3.DataSource = dt;
        DropDownList3.DataTextField = "btype";
        DropDownList3.DataValueField = "btype";
        DropDownList3.DataBind();
        DropDownList3.Items.Insert(0, new ListItem("please select banner type", "-1"));
    }


    private void setarea()
    {
        selectedcity = int.Parse(DropDownList2.SelectedValue);
        DataTable dt = c1.select("Select * from area where cid ='" + selectedcity + "'");
        DropDownList4.DataSource = dt;
        DropDownList4.DataTextField = "aname";
        DropDownList4.DataValueField = "aname";
        DropDownList4.DataBind();
        DropDownList4.Items.Insert(0, new ListItem("please select area", "-1"));
    }



    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        setarea();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        setcity();
    }


    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        option = RadioButtonList1.SelectedItem.ToString();
        if (option.Equals("BY AREA"))
        {
            DropDownList3.Enabled = false;
            DropDownList4.Enabled = true;
            DropDownList5.Enabled = false;
            DropDownList3.SelectedIndex = 0;
            DropDownList5.SelectedIndex = 0;
            RequiredFieldValidator3.Enabled = false;
            RequiredFieldValidator4.Enabled = true;
            RequiredFieldValidator5.Enabled = false;


        }
        else if (option.Equals("BY BANNERTYPE"))
        {
            DropDownList3.Enabled = true;
            DropDownList4.Enabled = false;
            DropDownList5.Enabled = false;
            DropDownList4.SelectedIndex = 0;
            DropDownList5.SelectedIndex = 0;
            RequiredFieldValidator3.Enabled = true;
            RequiredFieldValidator4.Enabled = false;
            RequiredFieldValidator5.Enabled = false;
            setbanner();
        }
        else
        {
            DropDownList3.Enabled = false;
            DropDownList4.Enabled = false;
            DropDownList5.Enabled = true;
            DropDownList3.SelectedIndex = 0;
            DropDownList4.SelectedIndex = 0;
            RequiredFieldValidator3.Enabled = false;
            RequiredFieldValidator4.Enabled = false;
            RequiredFieldValidator5.Enabled = true;
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
         setgridbybanner();
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        setgridbyarea();
    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        setgridbyrating();
    }

    
    
}