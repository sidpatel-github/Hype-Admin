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


public partial class register : System.Web.UI.Page
{
    Class1 fun = new Class1();
    int flag = 1, flag1 = 1; 

    public static string deviceno(int lenght)
    {
        string _allowedChars = "0123456789";
        Random randNum = new Random();
        char[] chars = new char[lenght];
        int allowedCharCount = _allowedChars.Length;
        for (int i = 0; i < lenght; i++)
        {
            chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
        }
        return new string(chars);
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

    private void setgrid()
    {
        DataTable dt = fun.select("select uid,usertype,username,password,name,occupation,address,phoneno,active,email from register where usertype = 'worker'");
        GridView3.DataSource = dt;
        GridView3.DataBind();
    }
    protected void  Button1_Click(object sender, EventArgs e)
    {

       
        MD5 md5 = new MD5CryptoServiceProvider();
        md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(TextBox3.Text));
        byte[] result = md5.Hash;
        StringBuilder strBuilder = new StringBuilder();
        for (int i = 0; i < result.Length; i++)
        {
            strBuilder.Append(result[i].ToString("x2"));
        }
        String md5password = strBuilder.ToString();
        String device = deviceno(5);


        if (HiddenField1.Value.Equals("insert") && !TextBox1.Text.Equals("") && !TextBox2.Text.Equals("") && !TextBox3.Text.Equals("") && !TextBox4.Text.Equals("") && !TextBox5.Text.Equals("") && !TextBox6.Text.Equals("") && !TextBox7.Text.Equals(""))
        {

            DataTable dt = fun.select("select username from register where username = '" + TextBox2.Text.ToString() + "'");
            foreach (DataRow row in dt.Rows)//sid= '" + DropDownList1.SelectedValue.ToString() + "' and cid = '" + DropDownList2.SelectedValue.ToString() + "' and 
            {
                foreach (string item in row.ItemArray)
                {
                    if (TextBox2.Text.ToLower().Equals(item.ToLower()))
                    {
                        flag = 0;
                        break;
                    }
                }
            }

            DataTable dt1 = fun.select("select email from register where email = '" + TextBox7.Text.ToString() + "' ");
            foreach (DataRow row in dt.Rows)//sid= '" + DropDownList1.SelectedValue.ToString() + "' and cid = '" + DropDownList2.SelectedValue.ToString() + "' and 
            {
                foreach (string item in row.ItemArray)
                {
                    if (TextBox7.Text.ToLower().Equals(item.ToLower()))
                    {
                        flag1 = 0;
                        break;
                    }
                }
            }


            if (flag.Equals("1") && flag1.Equals("1"))
            {
                /*   if (TextBox4.Text.Equals(TextBox3.Text))
                   {*/
                fun.query("insert into register(usertype,name,username,password,occupation,address,phoneno,email,deviceid,active,vercode) values('worker','" + TextBox1.Text + "','" + TextBox2.Text + "','" + md5password + "','HOARDING FITTING','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + device + "','active','no_verify_needed')");
                Response.Write("<script language=javascript>alert('SUCCESSFULLY RECORDED');" + "<" + "/" + "script>");
                //Response.Write("successfully inserted !!");
             }
             else
            { 
                Response.Write("<script language=javascript>alert('username or email found in database');" + "<" + "/" + "script>"); 
            } 
            
        }
        else
        {
            fun.query("update register set name='" + TextBox1.Text + "',password='" + md5password + "' ,username='" + TextBox2.Text + "' ,address='" + TextBox5.Text + "',phoneno='" + TextBox6.Text + "',email='" + TextBox7.Text + "' where uid='" + HiddenField2.Value + "'");
            Response.Write("<script language=javascript>alert('SUCESSFULLY UPDATED');" + "<" + "/" + "script>");
        }
        
        HiddenField1.Value = "insert";
        setgrid();
        cleardata();
    }

   


     protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        fun.query("delete from register where uid ='" + GridView3.Rows[e.RowIndex].Cells[2].Text + "'");
        setgrid();
        cleardata();
        Response.Write("<script language=javascript>alert('SUCESSFULLY DELETED');" + "<" + "/" + "script>");
    }

    public void cleardata()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
    
    
    }

    protected void GridView3_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        HiddenField1.Value = "update";
        HiddenField2.Value = GridView3.Rows[e.NewSelectedIndex].Cells[2].Text;
        TextBox1.Text = GridView3.Rows[e.NewSelectedIndex].Cells[6].Text;
        TextBox2.Text = GridView3.Rows[e.NewSelectedIndex].Cells[4].Text;
        TextBox5.Text = GridView3.Rows[e.NewSelectedIndex].Cells[8].Text;
        TextBox6.Text = GridView3.Rows[e.NewSelectedIndex].Cells[9].Text;
        TextBox7.Text = GridView3.Rows[e.NewSelectedIndex].Cells[11].Text;


    }

    protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        HiddenField1.Value = "insert";
    }
    
}