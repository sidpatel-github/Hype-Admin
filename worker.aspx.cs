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


public partial class worker : System.Web.UI.Page
{
    Class1 fun = new Class1();
    int a, aa, a1, a111; string a11111, b111, c11;
    String a11, a1111, val, val1;
    SqlConnection con = new SqlConnection(Class1.datasource);

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
            workerhoarding();
        }

    }
    private void setgrid()
    {
        DataTable dt = fun.select("select register.username as worker_name,wd.hid,hoarding.area,wd.date as 'photo date',wd.time as 'photo time',status.status,status.remark,'Uploads/'+hoarding.image as 'client image','Uploads/'+wd.locfinalimage as 'worker image',wd1.date as 'work given' from hoarding,register,status,workerdetail as wd,workdistribution as wd1 where register.uid=wd.uid and hoarding.hid=wd.hid and status.statusid=wd.statusid and wd.uid=wd1.uid and hoarding.hid=wd1.hid");
        GridView6.DataSource = dt;
        GridView6.DataBind();
    }

    protected void GridView6_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int RowIndex = e.RowIndex;

        if (GridView6.Rows[e.RowIndex].Cells[9].Text.Equals("completed"))
        {
            Response.Write("<script language=javascript>alert('ALREADY COMPLETED');" + "<" + "/" + "script>");
            //            Response.Write("already completed");
            //Response.Redirect("~/worker.aspx");
        }
        else if (GridView6.Rows[e.RowIndex].Cells[9].Text.Trim().Equals("rejected"))
        {
            Response.Write("<script language=javascript>alert('ALREADY REJECTED');" + "<" + "/" + "script>");
            //            Response.Write("already rejected");
        }

        else
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select statusid from workerdetail where hid = '" + GridView6.Rows[RowIndex].Cells[5].Text + "' ";
            cmd.Connection = con;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                aa = reader.GetInt32(0);
            } Response.Write(aa);
            reader.Close();
            //Response.Write(a);
            fun.query("update status set status = 'rejected',remark='banner not proper fixed do it again', date = '" + DateTime.Now.ToShortDateString() + "' ,time = '" + DateTime.Now.ToShortTimeString() + "' where statusid = '" + aa + "'");
            // fun.query("update workerdetail set date = '" + DateTime.Now.ToShortDateString() + "' ,time = '" + DateTime.Now.ToShortTimeString() + "' where statusid = '" + aa + "'");


            cmd.CommandText = "select uid from workerdetail where hid = '" + GridView6.Rows[RowIndex].Cells[5].Text + "' ";
            cmd.Connection = con;
            SqlDataReader reader111 = cmd.ExecuteReader();
            while (reader111.Read())
            {
                a111 = reader111.GetInt32(0);
            }
            //       Response.Write(a111); // a1111==worker device
            reader111.Close();

            cmd.CommandText = "select deviceid,username from register where uid = '" + a111 + "' ";
            cmd.Connection = con;
            SqlDataReader reader1111 = cmd.ExecuteReader();
            while (reader1111.Read())
            {
                a1111 = reader1111.GetString(0);
                a11111 = reader1111.GetString(1);

            }
            Response.Write(a1111); // a1111==worker device worker a1111
            reader1111.Close();


            String ApplicationID = "AIzaSyC2Tigh9hTgJHgpWOwCVkQd0OdCxFILSwI";
            String SENDER_ID = "82716677818";
            val1 = "hoarding reject as it is not properly fixed";
            fun.query("insert into chatting(sender,reciever,message,date,time,seen) values('admin','" + a11111.ToString() + "','" + val1 + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','false')");

            WebRequest tRequest1;
            tRequest1 = WebRequest.Create("https://android.googleapis.com/gcm/send"); tRequest1.Method = "post";
            tRequest1.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            tRequest1.Headers.Add(string.Format("Authorization: key={0}", ApplicationID)); tRequest1.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
            string postData1 = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.tickerText=ticker&data.contentTitle=HYPE&data.message=" + val1 + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + a1111 + "";

            Console.WriteLine(postData1);

            Byte[] byteArray1 = Encoding.UTF8.GetBytes(postData1);
            tRequest1.ContentLength = byteArray1.Length;
            Stream dataStream1 = tRequest1.GetRequestStream();
            dataStream1.Write(byteArray1, 0, byteArray1.Length);
            dataStream1.Close();
            WebResponse tResponse1 = tRequest1.GetResponse(); dataStream1 = tResponse1.GetResponseStream();
            StreamReader tReader1 = new StreamReader(dataStream1);
            String sResponseFromServer1 = tReader1.ReadToEnd();  //Get response from GCM server  
            Response.Write(sResponseFromServer1); //Assigning GCM response to Label text
            tReader1.Close(); dataStream1.Close();
            tResponse1.Close();
            Response.Redirect("~/worker.aspx");

            Response.Write("else");
        }
    }
    private void workerhoarding()
    {
        DataTable dt1 = fun.select("select count(*) as 'no of order',register.username from workerdetail as w1,register where w1.uid=register.uid group by w1.uid,register.username union select '0' as 'count',register.username from register where register.usertype='worker' and register.uid not in(select distinct(uid) from workerdetail) order by username ASC");
        GridView7.DataSource = dt1;
        GridView7.DataBind();

    }
    protected void GridView6_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

        int RowIndex = Convert.ToInt32((e.NewSelectedIndex).ToString());

        //  Response.Write("dd" + GridView6.Rows[RowIndex].Cells[11].Text + "sd");
        // Response.Write(RowIndex);
        if (GridView6.Rows[RowIndex].Cells[9].Text.Trim().Equals("rejected"))
        {
            Response.Write("<script language=javascript>alert('BANNER IS REJECTED');" + "<" + "/" + "script>");
            //Response.Write("banner is rejected");
            // Response.Redirect("~/worker.aspx");
        }
        else if (GridView6.Rows[RowIndex].Cells[9].Text.Equals("completed"))
        {
            Response.Write("<script language=javascript>alert('BANNER ALREADY DONE');" + "<" + "/" + "script>");
            //Response.Write("already done");
            // Response.Redirect("~/worker.aspx");
        }
        else
        {
            /*    SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select hid from workerdetail where uid='" + GridView6.Rows[RowIndex].Cells[5].Text + "'";
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    a = reader.GetInt32(0);   //client hid
                }
                //   Response.Write(a);
                */
            fun.query("update status set status = 'completed', date = '" + DateTime.Now.ToShortDateString() + "', time = '" + DateTime.Now.ToShortTimeString() + "', remark = 'complete_verify' where hid = '" + GridView6.Rows[RowIndex].Cells[5].Text + "'");
            fun.query("update hoarding set status = 'completed' where hid = '" + GridView6.Rows[RowIndex].Cells[5].Text + "'");
            //  fun.query("update workerdetail set date = '" + DateTime.Now.ToShortDateString() + "', time = '" + DateTime.Now.ToShortTimeString() + "' where hid = '" + GridView6.Rows[RowIndex].Cells[5].Text + "' ");


            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select uid from hoarding where hid = '" + GridView6.Rows[RowIndex].Cells[5].Text + "' ";
            cmd1.Connection = con;
            con.Open();
            SqlDataReader reader2 = cmd1.ExecuteReader();
            while (reader2.Read())
            {
                a1 = reader2.GetInt32(0); //client uid
            }
            // Response.Write(a1); // a1===9;
            reader2.Close();


            cmd1.CommandText = "select deviceid,username from register where uid = '" + a1 + "' ";
            cmd1.Connection = con;
            SqlDataReader reader11 = cmd1.ExecuteReader();
            while (reader11.Read())
            {
                a11 = reader11.GetString(0); //client deviceid
                c11 = reader11.GetString(1); //cliet name
            }
            Response.Write(a11);// a11==device; client a11
            reader11.Close();

            cmd1.CommandText = "select uid from workerdetail where hid = '" + GridView6.Rows[RowIndex].Cells[5].Text + "'";
            cmd1.Connection = con;
            SqlDataReader reader111 = cmd1.ExecuteReader();
            while (reader111.Read())
            {
                a111 = reader111.GetInt32(0);
            }
            //       Response.Write(a111); // a1111==worker device
            reader111.Close();
            cmd1.CommandText = "select deviceid,username from register where uid = '" + a111 + "' ";
            cmd1.Connection = con;
            SqlDataReader reader1111 = cmd1.ExecuteReader();
            while (reader1111.Read())
            {
                a1111 = reader1111.GetString(0);
                b111 = reader1111.GetString(1);
            }
            Response.Write(a1111); // a1111==worker device worker a1111
            reader1111.Close();



            //  String RegId = "APA91bGRVLRAfIhykRKybyW4QTgvNeerFeY8WUddR8ENN4Q2sBTRWboSy53K_t5J0CtQ1nwNVDS8hVUQTNO7WkkJokb7OFHno3fIQ9y2VvrFsgFYntV3XcgiIfj36Q31a58kCFl629Ui";
            String ApplicationID = "AIzaSyC2Tigh9hTgJHgpWOwCVkQd0OdCxFILSwI";
            String SENDER_ID = "82716677818";
            //  var value = "hello"; //message text box
            val = "your hoarding is completed";

            fun.query("insert into chatting(sender,reciever,message,date,time,seen) values('admin','" + c11.ToString() + "','" + val + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','false')");

            WebRequest tRequest;
            tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send"); tRequest.Method = "post";
            tRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            tRequest.Headers.Add(string.Format("Authorization: key={0}", ApplicationID)); tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
            //Data post to the Server
            string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.tickerText=ticker&data.contentTitle=HYPE&data.message=" + val + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + a11 + "";
            Console.WriteLine(postData);


            Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            tRequest.ContentLength = byteArray.Length;
            Stream dataStream = tRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse tResponse = tRequest.GetResponse(); dataStream = tResponse.GetResponseStream();
            StreamReader tReader = new StreamReader(dataStream);
            String sResponseFromServer = tReader.ReadToEnd();  //Get response from GCM server  
            Response.Write(sResponseFromServer); //Assigning GCM response to Label text
            tReader.Close(); dataStream.Close();
            tResponse.Close();

            val1 = "you hoarding is good";
            fun.query("insert into chatting(sender,reciever,message,date,time,seen) values('admin','" + b111.ToString() + "','" + val + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','false')");

            WebRequest tRequest1;
            tRequest1 = WebRequest.Create("https://android.googleapis.com/gcm/send"); tRequest1.Method = "post";
            tRequest1.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            tRequest1.Headers.Add(string.Format("Authorization: key={0}", ApplicationID)); tRequest1.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
            string postData1 = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.tickerText=ticker&data.contentTitle=HYPE&data.message=" + val1 + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + a1111 + "";

            Console.WriteLine(postData1);

            Byte[] byteArray1 = Encoding.UTF8.GetBytes(postData1);
            tRequest1.ContentLength = byteArray1.Length;
            Stream dataStream1 = tRequest1.GetRequestStream();
            dataStream1.Write(byteArray1, 0, byteArray1.Length);
            dataStream1.Close();
            WebResponse tResponse1 = tRequest1.GetResponse(); dataStream1 = tResponse1.GetResponseStream();
            StreamReader tReader1 = new StreamReader(dataStream1);
            String sResponseFromServer1 = tReader1.ReadToEnd();  //Get response from GCM server  
            Response.Write(sResponseFromServer1); //Assigning GCM response to Label text
            tReader1.Close(); dataStream1.Close();
            tResponse1.Close();

            Response.Redirect("~/worker.aspx");

            // Response.Write("else");
        }

    }
    protected void GridView6_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView6_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}
