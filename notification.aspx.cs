using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class notification : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(Class1.datasource);
    Class1 c1 = new Class1();
    public static String RegId, RegId1;

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
            setcustomer();
            setcustomer1();
            setgrid();
        }

    }

    private void setcustomer()
    {
        DataTable dt = c1.select("select * from register ");
        DropDownList1.DataSource = dt;
        DropDownList1.DataTextField = "username";
        DropDownList1.DataValueField = "uid";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("all", "-1"));
    }

    private void setcustomer1()
    {
        DataTable dt = c1.select("select * from register");
        DropDownList2.DataSource = dt;
        DropDownList2.DataTextField = "username";
        DropDownList2.DataValueField = "uid";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("all", "-1"));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!TextArea1.InnerText.Equals(""))
        {
            if (DropDownList1.SelectedIndex != 0)
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "select deviceid from register where username = '" + DropDownList1.SelectedItem.ToString() + "'";
                cmd1.Connection = con;
                SqlDataReader reader = cmd1.ExecuteReader();
                if (reader.Read())
                {
                    RegId = reader.GetString(0);
                }
                con.Close();
            }

            if (DropDownList1.SelectedIndex == 0)
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select * from register where usertype='client' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                String result = "";
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result += dt.Rows[i][9] + ":";
                    }
                    result = result.Trim(':');
                }
                String[] datas = result.Split(':');

                for (int i = 0; i < datas.Length; i++)
                {
                    RegId = datas[i].ToString();

                }
                con.Close();
            }
        }
        else
        {
            Response.Write("<script language=javascript>alert('PLEASE ENTER IN TEXT AREA');" + "<" + "/" + "script>");
//            Response.Write("please inter into textarea");
        }


        //  String RegId = "APA91bGRVLRAfIhykRKybyW4QTgvNeerFeY8WUddR8ENN4Q2sBTRWboSy53K_t5J0CtQ1nwNVDS8hVUQTNO7WkkJokb7OFHno3fIQ9y2VvrFsgFYntV3XcgiIfj36Q31a58kCFl629Ui";
        String ApplicationID = "AIzaSyC2Tigh9hTgJHgpWOwCVkQd0OdCxFILSwI";
        String SENDER_ID = "82716677818";
        //  var value = "hello"; //message text box

        WebRequest tRequest;
        tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send"); tRequest.Method = "post";
        tRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
        tRequest.Headers.Add(string.Format("Authorization: key={0}", ApplicationID)); tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
        //Data post to the Server
        string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.tickerText=ticker&data.contentTitle=HYPE&data.message=" + TextArea1.InnerText + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + RegId + "";
        Console.WriteLine(postData);

        Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        tRequest.ContentLength = byteArray.Length;
        Stream dataStream = tRequest.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();
        WebResponse tResponse = tRequest.GetResponse(); dataStream = tResponse.GetResponseStream();
        StreamReader tReader = new StreamReader(dataStream);
        String sResponseFromServer = tReader.ReadToEnd();  //Get response from GCM server  
        Label1.Text = sResponseFromServer; //Assigning GCM response to Label text

        if (DropDownList1.SelectedItem.ToString().Equals("all"))
        {

            SqlDataAdapter sda = new SqlDataAdapter("Select * from register where usertype='client'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            String result = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    result += dt.Rows[i][2] + ":";
                }
                result = result.Trim(':');
            }
            String[] datas = result.Split(':');

            for (int i = 0; i < datas.Length; i++)
            {
                RegId1 = datas[i].ToString();

                c1.query("insert into chatting(sender,reciever,message,date,time,seen) values('admin','" + RegId1.ToString() + "','" + TextArea1.InnerText + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','false')");
            }
            Response.Write("<script language=javascript>alert('SUCESSFULLY SEND');" + "<" + "/" + "script>");
 //           Response.Write("successfully send !!");

        }
        else
        {
            c1.query("insert into chatting(sender,reciever,message,date,time,seen) values('admin','" + DropDownList1.SelectedItem.ToString() + "','" + TextArea1.InnerText + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','false')");
            Response.Write("<script language=javascript>alert('SUCESSFULLY SEND');" + "<" + "/" + "script>");
            //Response.Write("successfully inserted !!");
        }

        setgrid();
        cleardata();
        tReader.Close(); dataStream.Close();
        tResponse.Close();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        TextArea1.InnerText = "";
        DropDownList1.ClearSelection();
    }


    private void setgrid()
    {
        DataTable dt = c1.select("select chatid,sender,reciever,message,date,time,seen from chatting ORDER BY chatid DESC");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        c1.query("delete from chatting where chatid ='" + GridView1.Rows[e.RowIndex].Cells[2].Text + "'");
        setgrid();
        cleardata();
        Response.Write("<script language=javascript>alert('SUCESSFULLY DELETED');" + "<" + "/" + "script>");
   //     Response.Write("successfully deleted !!");
    }
    protected void HiddenField1_ValueChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public void cleardata()
    {
        TextArea1.InnerText = "";
        DropDownList1.ClearSelection();
    }
    public void cleardata1()
    {
        TextArea2.InnerText = "";
        DropDownList2.ClearSelection();
        DropDownList3.ClearSelection();
    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        TextArea2.InnerText = GridView1.Rows[e.NewSelectedIndex].Cells[5].Text;
        if (GridView1.Rows[e.NewSelectedIndex].Cells[3].Text.Equals("admin"))
        {
            TextArea2.InnerText = GridView1.Rows[e.NewSelectedIndex].Cells[5].Text;
            // setgrid();
            // cleardata1();

        }
        else
        {
            c1.query("update chatting set seen ='" + true + "' where chatid ='" + GridView1.Rows[e.NewSelectedIndex].Cells[2].Text + "'");
            // setgrid();
            //  cleardata1();
        }
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextArea2.InnerText = "";
        if (DropDownList2.SelectedItem.ToString().Equals("all") && DropDownList3.SelectedItem.ToString().Equals("all"))
        {
            DataTable dt = c1.select("select chatid,sender,reciever,message,date,time,seen from chatting ORDER BY chatid DESC ");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            //    cleardata1();
        }
        else if (DropDownList2.SelectedItem.ToString().Equals("all") && DropDownList3.SelectedItem.ToString().Equals("read"))
        {
            DataTable dt = c1.select("select chatid,sender,reciever,message,date,time,seen from chatting where seen='" + true + "' ORDER BY chatid DESC ");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            //    cleardata1();
        }
        else if (DropDownList2.SelectedItem.ToString().Equals("all") && DropDownList3.SelectedItem.ToString().Equals("unread"))
        {
            DataTable dt = c1.select("select chatid,sender,reciever,message,date,time,seen from chatting where seen='" + false + "'ORDER BY chatid DESC ");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            //    cleardata1();

        }
        else if ((!DropDownList2.SelectedItem.ToString().Trim().Equals("all")) && DropDownList3.SelectedItem.ToString().Equals("all"))
        {
            DataTable dt = c1.select("select * from chatting where sender ='" + DropDownList2.SelectedItem.ToString() + "' or  reciever='" + DropDownList2.SelectedItem.ToString() + "' ORDER BY chatid DESC ");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            // cleardata1();
        }
        else if ((!DropDownList2.SelectedItem.ToString().Trim().Equals("all")) && DropDownList3.SelectedItem.ToString().Equals("read"))
        {
            DataTable dt = c1.select("select * from chatting where (sender ='" + DropDownList2.SelectedItem.ToString() + "' and seen='" + true + "')  or  (reciever='" + DropDownList2.SelectedItem.ToString() + "' and seen='" + true + "') ORDER BY chatid DESC ");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            // cleardata1();
        }
        else if ((!DropDownList2.SelectedItem.ToString().Trim().Equals("all")) && DropDownList3.SelectedItem.ToString().Equals("unread"))
        {
            DataTable dt = c1.select("select * from chatting where (sender ='" + DropDownList2.SelectedItem.ToString() + "' and seen='" + false + "')  or  (reciever='" + DropDownList2.SelectedItem.ToString() + "' and seen='" + false + "')  ORDER BY chatid DESC ");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            // cleardata1();

        }
        else { }
    }

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextArea2.InnerText = "";
        if (DropDownList2.SelectedItem.ToString().Equals("all") && DropDownList3.SelectedItem.ToString().Equals("all"))
        {
            DataTable dt = c1.select("select chatid,sender,reciever,message,date,time,seen from chatting ORDER BY chatid DESC ");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            //    cleardata1();
        }
        else if (DropDownList2.SelectedItem.ToString().Equals("all") && DropDownList3.SelectedItem.ToString().Equals("read"))
        {
            DataTable dt = c1.select("select chatid,sender,reciever,message,date,time,seen from chatting where seen='" + true + "' ORDER BY chatid DESC ");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            //    cleardata1();
        }
        else if (DropDownList2.SelectedItem.ToString().Equals("all") && DropDownList3.SelectedItem.ToString().Equals("unread"))
        {
            DataTable dt = c1.select("select chatid,sender,reciever,message,date,time,seen from chatting where seen='" + false + "'ORDER BY chatid DESC ");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            //    cleardata1();

        }
        else if ((!DropDownList2.SelectedItem.ToString().Trim().Equals("all")) && DropDownList3.SelectedItem.ToString().Equals("all"))
        {
            DataTable dt = c1.select("select * from chatting where sender ='" + DropDownList2.SelectedItem.ToString() + "' or  reciever='" + DropDownList2.SelectedItem.ToString() + "' ORDER BY chatid DESC ");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            // cleardata1();
        }
        else if ((!DropDownList2.SelectedItem.ToString().Trim().Equals("all")) && DropDownList3.SelectedItem.ToString().Equals("read"))
        {
            DataTable dt = c1.select("select * from chatting where (sender ='" + DropDownList2.SelectedItem.ToString() + "' and seen='" + true + "')  or  (reciever='" + DropDownList2.SelectedItem.ToString() + "' and seen='" + true + "') ORDER BY chatid DESC ");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            // cleardata1();
        }
        else if ((!DropDownList2.SelectedItem.ToString().Trim().Equals("all")) && DropDownList3.SelectedItem.ToString().Equals("unread"))
        {
            DataTable dt = c1.select("select * from chatting where (sender ='" + DropDownList2.SelectedItem.ToString() + "' and seen='" + false + "')  or  (reciever='" + DropDownList2.SelectedItem.ToString() + "' and seen='" + false + "')  ORDER BY chatid DESC ");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            // cleardata1();

        }
        else { }

    }



    protected void Button5_Click(object sender, EventArgs e)
    {
        cleardata1();
        setgrid();
    }
    
    
}