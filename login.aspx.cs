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
using System.Net.Mail;

public partial class login : System.Web.UI.Page
{
    
    Class1 fun = new Class1();
    DataTable dt;
    protected override void OnPreInit(EventArgs e)
    {
        string userID = (string)(Session["name"]);
        if (userID != null)
        {
            Response.Redirect("login.aspx");
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        dt = fun.select("select * from register where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "' and usertype='admin'");
        if (dt.Rows.Count > 0)
        {
            // String a = TextBox1.Text;
            Session["name"] = TextBox1.Text;
            //Session.Timeout = 30;
            Response.Redirect("simple.aspx");
           // Response.Write("<script language=javascript>alert('WELCOME ADMIN'+'"+TextBox1.Text+"');" + "<" + "/" + "script>");


        }
        else
        {
            Response.Write("<script language=javascript>alert('INVALID USERNAME OR PASSWORD');" + "<" + "/" + "script>");
        }
       
    }


     protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }

     protected void Button3_Click(object sender, EventArgs e)
     {
         dt = fun.select("select * from register where email='" + TextBox3.Text + "' and usertype='admin'");
         if (dt.Rows.Count > 0)
         {
             System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
             mail.To.Add(TextBox3.Text);
             mail.From = new MailAddress("hypescet@gmail.com", "Password Recovery", System.Text.Encoding.UTF8);
             mail.Subject = "This mail is send from asp.net application";
             mail.SubjectEncoding = System.Text.Encoding.UTF8;
             mail.Body = "your password is " + dt.Rows[0][3].ToString();
             mail.BodyEncoding = System.Text.Encoding.UTF8;
             mail.IsBodyHtml = true;
             mail.Priority = MailPriority.High;
             SmtpClient client = new SmtpClient();
             client.Credentials = new System.Net.NetworkCredential("hypescet@gmail.com", "hype1234");
             client.Port = 587;
             client.Host = "smtp.gmail.com";
             client.EnableSsl = true;
             try
             {
                 client.Send(mail);
                 Page.RegisterStartupScript("UserMsg", "<script>alert('Successfully Send...');if(alert){ window.location='login.aspx';}</script>");
             }
             catch (Exception ex)
             {
                 Exception ex2 = ex;
                 string errorMessage = string.Empty;
                 while (ex2 != null)
                 {
                     errorMessage += ex2.ToString();
                     ex2 = ex2.InnerException;
                 }
                 Page.RegisterStartupScript("UserMsg", "<script>alert('Sending Failed...');if(alert){ window.location='login.aspx';}</script>");
             }
         }
         else
         {
             Page.RegisterStartupScript("UserMsg", "<script>alert('Email Doesnt Exists...');if(alert){ window.location='login.aspx';}</script>");
         }

     }
}