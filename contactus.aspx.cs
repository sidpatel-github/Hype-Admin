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


public partial class contactus : System.Web.UI.Page
{
    Class1 fun = new Class1(); 
    int RowIndex;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            Label5.Text = "WELCOME : ADMIN " + Session["name"].ToString();
            //Response.Write(Session["name"].ToString());
            setgrid();
        }
    }
    private void setgrid()
    {
        DataTable dt = fun.select("select * from contactus");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        var fromAddress = TextBox2.Text;
        var toAddress = TextBox1.Text;
        const string fromPassword = "hype1234";
        string subject = TextBox3.Text;
        string body = TextBox4.Text;

        var smtp = new System.Net.Mail.SmtpClient();
        {
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
            smtp.Timeout = 20000;
        }
        if (smtp.Timeout <= 20000)
        {
            smtp.Send(fromAddress, toAddress, subject, body);
            fun.query("update contactus set interaction='" + true + "' where srno='" + HiddenField1.Value + "'");
            Response.Write("<script language=javascript>alert('SUCESSFULLY SEND');" + "<" + "/" + "script>");
            //Response.Write("successfully sent !!");
            setgrid();
        }
        else
        {
            Response.Write("<script language=javascript>alert('UNSUCESSFULLY SEND');" + "<" + "/" + "script>");
            //Response.Write("unsuccessfully sent!!");
            setgrid();
        }
        cleardata();
    }
    public void cleardata()
    {
        TextBox1.Text = "";
        TextBox2.Text = "hypescet@gmail.com";
        TextBox3.Text = "";
        TextBox4.Text = "";
        HiddenField1.Value = "insert";


    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        HiddenField1.Value = GridView1.Rows[e.NewSelectedIndex].Cells[2].Text;
        TextBox1.Text = GridView1.Rows[e.NewSelectedIndex].Cells[4].Text;
        TextBox3.Text = GridView1.Rows[e.NewSelectedIndex].Cells[5].Text;
        TextBox4.Text = "how may i help you!";
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "hypescet@gmail.com";
        TextBox3.Text = "";
        TextBox4.Text = "";
        HiddenField1.Value = "insert";
    }
    protected void HiddenField1_ValueChanged(object sender, EventArgs e)
    {

    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        RowIndex = Convert.ToInt32((e.CommandArgument).ToString());
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        HiddenField1.Value = GridView1.Rows[e.RowIndex].Cells[2].Text;
        fun.query("delete from contactus where srno='" + HiddenField1.Value + "'");
        //Response.Write("successfully updated !!");
        Response.Write("<script language=javascript>alert('SUCESSFULLY DELETED');" + "<" + "/" + "script>");
        setgrid();
    }
    
}
    