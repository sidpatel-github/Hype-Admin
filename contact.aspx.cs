using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class contact : System.Web.UI.Page
{
    Class1 c1 = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        ////Response.Write(Session["name"].ToString());
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    c1.query("insert into contactus(name,email,summary,description,date,time,interaction) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextArea1.InnerText + "','" +DateTime.Now.ToShortDateString()+"','"+DateTime.Now.ToShortTimeString()+"','"+false+"')");
    Response.Write("<script language=javascript>alert('YOUR RESPONCE IS REGISTER');" + "<" + "/" + "script>");
    cleardata();
    }
    
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextArea1.InnerText = "";
    
    }
    public void cleardata()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextArea1.InnerText = "";


    }
}