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
using System.Globalization;
using System.Threading;
using System.Text;
using System.Net;
using System.IO;

public partial class hoarding : System.Web.UI.Page
{
    Class1 fun = new Class1();
    SqlConnection con = new SqlConnection(Class1.datasource); 
    int a, a1; 
    String z1, z11, z111, z1111, zq,a112, aall12;
    int a1b, ab, a12;
    string a11b, zqb,zq2, aallb;
    int RowIndex;
    String aall;
    string username;
    String a11, a111, selectedvalue;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
        {
            Response.Redirect("login.aspx");
        }
        
        if (!IsPostBack)
        {   Label1.Text= "WELCOME : ADMIN " +Session["name"].ToString();
            setgrid();
        }

    }

    private void setgrid()
    {
        DataTable dt = fun.select("select hoarding.hid,register.name,btype,bookdate,expiredate,state,city,area,size,'Uploads/'+image as 'image1',hoarding.status,hoarding.price,status.date from status,hoarding,register where hoarding.uid=register.uid and hoarding.hid=status.hid ");//order by hoarding.bookdate asc
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }
   
    protected void GridView2_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        RowIndex = Convert.ToInt32((e.CommandArgument).ToString());
        
        
        if (e.CommandName.Equals("worker"))
        {
            if (GridView2.Rows[RowIndex].Cells[16].Text.Equals("accepted") || GridView2.Rows[RowIndex].Cells[16].Text.Equals("completed"))
            {
                Response.Write("<script language=javascript>alert('banner in already given');" + "<" + "/" + "script>");
         //       Response.Write("banner in already given");
            }
            else if (GridView2.Rows[RowIndex].Cells[16].Text.Equals("expired"))
            {
                Response.Write("<script language=javascript>alert('banner is already expired');" + "<" + "/" + "script>");
         //       Response.Write("banner is already expired");
            }
            else if (GridView2.Rows[RowIndex].Cells[16].Text.Equals("queue"))
            {
                Response.Write("<script language=javascript>alert('first ask for payment');" + "<" + "/" + "script>");
                //       Response.Write("banner is already expired");
            }

            else
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select statusid from status where hid = '" + GridView2.Rows[RowIndex].Cells[6].Text + "' ";
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    a = reader.GetInt32(0);
                }
                reader.Close();
                DropDownList ddl = (DropDownList)GridView2.Rows[RowIndex].FindControl("dduser");
                selectedvalue = ddl.SelectedValue;
                fun.query("insert into workdistribution(hid, uid, date, time, statusid) values('" + GridView2.Rows[RowIndex].Cells[6].Text + "','" + selectedvalue + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','" + a + "')");
                fun.query("insert into workerdetail(uid, hid,locfinalimage, date, time, statusid) values('" + selectedvalue + "','" + GridView2.Rows[RowIndex].Cells[6].Text + "','worker_image_upload.jpg','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','" + a + "')");
                fun.query("update status set status = 'accepted', date = '" + DateTime.Now.ToShortDateString() + "', time = '" + DateTime.Now.ToShortTimeString() + "', remark = 'admin_verify' where hid = '" + GridView2.Rows[RowIndex].Cells[6].Text + "'");
                fun.query("update hoarding set status = 'accepted' where hid = '" + GridView2.Rows[RowIndex].Cells[6].Text + "'");

                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "select uid from hoarding where hid = '" + GridView2.Rows[RowIndex].Cells[6].Text + "' ";
                cmd1.Connection = con;
                //con.Open();
                SqlDataReader reader2 = cmd1.ExecuteReader();
                while (reader2.Read())
                {
                    a1 = reader2.GetInt32(0);
                }
                // Response.Write(a1);
                reader2.Close();


                cmd1.CommandText = "select deviceid,username from register where uid = '" + a1 + "' ";
                cmd1.Connection = con;
                SqlDataReader reader11 = cmd1.ExecuteReader();
                while (reader11.Read())
                {
                    a11 = reader11.GetString(0);
                    z111 = reader11.GetString(1);
                }
                // Response.Write(a11);
                reader11.Close();

                cmd1.CommandText = "select deviceid,username from register where uid = '" + selectedvalue + "' ";
                cmd1.Connection = con;
                SqlDataReader reader111 = cmd1.ExecuteReader();
                while (reader111.Read())
                {
                    a111 = reader111.GetString(0);
                    z1111 = reader111.GetString(1);
                }
                //  Response.Write(a111);
                
                //  String RegId = "APA91bGRVLRAfIhykRKybyW4QTgvNeerFeY8WUddR8ENN4Q2sBTRWboSy53K_t5J0CtQ1nwNVDS8hVUQTNO7WkkJokb7OFHno3fIQ9y2VvrFsgFYntV3XcgiIfj36Q31a58kCFl629Ui";
                String ApplicationID = "AIzaSyC2Tigh9hTgJHgpWOwCVkQd0OdCxFILSwI";
                String SENDER_ID = "82716677818";
                //  var value = "hello"; //message text box
                String val = "your hoarding is selected";

                fun.query("insert into chatting(sender,reciever,message,date,time,seen) values('admin','" + z111.ToString() + "','" + val.ToString() + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','false')");
        
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

                String val1 = "you have hoarding to do";
                WebRequest tRequest1;
                tRequest1 = WebRequest.Create("https://android.googleapis.com/gcm/send"); tRequest1.Method = "post";
                tRequest1.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                tRequest1.Headers.Add(string.Format("Authorization: key={0}", ApplicationID)); tRequest1.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                string postData1 = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.tickerText=ticker&data.contentTitle=HYPE&data.message=" + val1 + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + a111 + "";

                fun.query("insert into chatting(sender,reciever,message,date,time,seen) values('admin','" + z1111.ToString() + "','" + val1.ToString() + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','false')");
        
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
                Response.Redirect("~/hoarding.aspx");
            }
        }

        if (e.CommandName.Equals("expire"))
        {   
            String edate = DateTime.Now.ToShortDateString();
            String toddate = DateTime.Now.ToShortDateString();
            String paydate = GridView2.Rows[RowIndex].Cells[18].Text;
            String expiry = GridView2.Rows[RowIndex].Cells[10].Text;
            DateTime dt = Convert.ToDateTime(toddate.ToString());
            DateTime dt1 = Convert.ToDateTime(paydate.ToString());
            DateTime dt2 = Convert.ToDateTime(expiry.ToString());
            
            TimeSpan ts = dt.Subtract(dt1);
            String diffDate = ts.Days.ToString();

            TimeSpan ts1 = dt.Subtract(dt2);
            String diffDate1 = ts1.Days.ToString();

         //   Response.Write(diffDate1 + diffDate);

            if (GridView2.Rows[RowIndex].Cells[16].Text.Equals("queue"))
            {
                Response.Write("<script language=javascript>alert('banner not accepted');" + "<" + "/" + "script>");
              //  Response.Write("banner not accepted");
            }
            else if (Int32.Parse(diffDate) < 4 && GridView2.Rows[RowIndex].Cells[16].Text.Equals("ask4pay"))
            {
                Response.Write("<script language=javascript>alert('payment period not over');" + "<" + "/" + "script>");
           //     Response.Write("payment period not over");                
            }
            else if (GridView2.Rows[RowIndex].Cells[16].Text.Equals("ask4pay") && Int32.Parse(diffDate) > 4)
            {
                Response.Write("banner status updated to expired");

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select statusid from status where hid = '" + GridView2.Rows[RowIndex].Cells[6].Text + "' ";
                cmd.Connection = con;
                con.Open();
                SqlDataReader readerb = cmd.ExecuteReader();
                while (readerb.Read())
                {
                    ab = readerb.GetInt32(0);
                }
                readerb.Close();//status id


                fun.query("delete from status where hid = '" + GridView2.Rows[RowIndex].Cells[6].Text + "'");
                fun.query("update hoarding set status = 'expired' where hid = '" + GridView2.Rows[RowIndex].Cells[6].Text + "'");
                fun.query("delete from workdistribution where hid = '" + GridView2.Rows[RowIndex].Cells[6].Text + "'");
                fun.query("delete from workerdetail where hid = '" + GridView2.Rows[RowIndex].Cells[6].Text + "'");
                fun.query("delete from location where hid = '" + GridView2.Rows[RowIndex].Cells[6].Text + "'");
                fun.query("delete from feedback where hid = '" + GridView2.Rows[RowIndex].Cells[6].Text + "'");



                SqlCommand cmd1b = new SqlCommand();
                cmd1b.CommandType = CommandType.Text;
                cmd1b.CommandText = "select uid from hoarding where hid = '" + GridView2.Rows[RowIndex].Cells[6].Text + "' ";
                cmd1b.Connection = con;
                //con.Open();
                SqlDataReader reader2b = cmd1b.ExecuteReader();
                while (reader2b.Read())
                {
                    a1b = reader2b.GetInt32(0);
                }
                // Response.Write(a1);
                reader2b.Close();


                cmd1b.CommandText = "select deviceid,username from register where uid = '" + a1b + "' ";
                cmd1b.Connection = con;
                SqlDataReader reader11b = cmd1b.ExecuteReader();
                while (reader11b.Read())
                {
                    a11b = reader11b.GetString(0);
                    zqb = reader11b.GetString(1);
                }
           //     Response.Write(zqb);
                reader11b.Close();

                // Response.Write("banner status updated to expired");




                //  String RegId = "APA91bGRVLRAfIhykRKybyW4QTgvNeerFeY8WUddR8ENN4Q2sBTRWboSy53K_t5J0CtQ1nwNVDS8hVUQTNO7WkkJokb7OFHno3fIQ9y2VvrFsgFYntV3XcgiIfj36Q31a58kCFl629Ui";
                String ApplicationID = "AIzaSyC2Tigh9hTgJHgpWOwCVkQd0OdCxFILSwI";
                String SENDER_ID = "82716677818";
                //  var value = "hello"; //message text box
                String valb = "hoarding remove as no payment";

            //      fun.query("insert into chatting(sender,reciever,message,date,time,seen)values('admin','"+z1111.ToString()+"','"+val1.ToString()+"','"+DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','false')");
        
                fun.query("insert into chatting(sender,reciever,message,date,time,seen)values('admin','"+zqb.ToString()+"','"+valb.ToString()+"','"+DateTime.Now.ToShortDateString()+"','"+DateTime.Now.ToShortTimeString()+"','false')");

                WebRequest tRequest;
                tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send"); tRequest.Method = "post";
                tRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", ApplicationID)); tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                //Data post to the Server
                string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.tickerText=ticker&data.contentTitle=HYPE&data.message=" + valb + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + a11b + "";
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




                SqlDataAdapter sdab = new SqlDataAdapter("Select * from register", con);
                DataTable dt21b = new DataTable();
                sdab.Fill(dt21b);
              String resultb = "";
                if (dt21b.Rows.Count > 0)
                {
                    for (int i = 0; i < dt21b.Rows.Count; i++)
                    {
                        resultb += dt21b.Rows[i][10] + ":";
                    }
                    resultb = resultb.Trim(':');
                }
                String[] datasb = resultb.Split(':');

                for (int i = 0; i < datasb.Length; i++)
                {
                    aallb = datasb[i].ToString();
                    
                }

                SqlDataAdapter sdasda = new SqlDataAdapter("Select * from register where usertype='client'", con);
                DataTable dtdt = new DataTable();
                sdasda.Fill(dtdt);
                String resultsda = "";
                if (dtdt.Rows.Count > 0)
                {
                    for (int i = 0; i < dtdt.Rows.Count; i++)
                    {
                        resultsda += dtdt.Rows[i][2] + ":";
                    }
                    resultsda = resultsda.Trim(':');
                }
                String[] datasdt = resultsda.Split(':');

                for (int i = 0; i < datasdt.Length; i++)
                {
                   String RegId1dt = datasdt[i].ToString();
                   String val11b = GridView2.Rows[RowIndex].Cells[13].Text + " is avalible";
                   fun.query("insert into chatting(sender,reciever,message,date,time,seen) values('admin','" + RegId1dt.ToString() + "','" + val11b.ToString() + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','false')");
                }
                Response.Write("<script language=javascript>alert('SUCESSFULLY SEND');" + "<" + "/" + "script>");
                //           Response.Write("successfully send !!");

                String val1b = GridView2.Rows[RowIndex].Cells[13].Text + " is avalible";
                WebRequest tRequest1;
                tRequest1 = WebRequest.Create("https://android.googleapis.com/gcm/send"); tRequest1.Method = "post";
                tRequest1.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                tRequest1.Headers.Add(string.Format("Authorization: key={0}", ApplicationID)); tRequest1.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

               

                fun.query("insert into chatting(sender,reciever,message,date,time,seen)values('admin','" + zqb.ToString() + "','" + val1b.ToString() + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','false')");


                string postData1 = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.tickerText=ticker&data.contentTitle=HYPE&data.message=" + val1b + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + aallb + "";
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
                Response.Redirect("~/hoarding.aspx");
            }
            else if (GridView2.Rows[RowIndex].Cells[10].Text.Equals(edate) || Int16.Parse(diffDate1) > 0)
            {

                Response.Write("banner status updated to expired");

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select statusid from status where hid = '" + GridView2.Rows[RowIndex].Cells[6].Text + "' ";
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    a = reader.GetInt32(0);
                }
                reader.Close();//status id


                fun.query("delete from status where hid = '" + GridView2.Rows[RowIndex].Cells[6].Text + "'");
                fun.query("update hoarding set status = 'expired' where hid = '" + GridView2.Rows[RowIndex].Cells[6].Text + "'");
                fun.query("delete from workdistribution where hid = '" + GridView2.Rows[RowIndex].Cells[6].Text + "'");
                fun.query("delete from workerdetail where hid = '" + GridView2.Rows[RowIndex].Cells[6].Text + "'");
                fun.query("delete from location where hid = '" + GridView2.Rows[RowIndex].Cells[6].Text + "'");



                SqlCommand cmd12 = new SqlCommand();
                cmd12.CommandType = CommandType.Text;
                cmd12.CommandText = "select uid from hoarding where hid = '" + GridView2.Rows[RowIndex].Cells[6].Text + "' ";
                cmd12.Connection = con;
                //con.Open();
                SqlDataReader reader22 = cmd12.ExecuteReader();
                while (reader22.Read())
                {
                    a12 = reader22.GetInt32(0);
                }
                // Response.Write(a1);
                reader22.Close();


                cmd12.CommandText = "select deviceid,username from register where uid = '" + a12 + "' ";
                cmd12.Connection = con;
                SqlDataReader reader112 = cmd12.ExecuteReader();
                while (reader112.Read())
                {
                    a112 = reader112.GetString(0);
                    zq2 = reader112.GetString(1);
                }
                // Response.Write(a11);
                reader112.Close();

                // Response.Write("banner status updated to expired");




                //  String RegId = "APA91bGRVLRAfIhykRKybyW4QTgvNeerFeY8WUddR8ENN4Q2sBTRWboSy53K_t5J0CtQ1nwNVDS8hVUQTNO7WkkJokb7OFHno3fIQ9y2VvrFsgFYntV3XcgiIfj36Q31a58kCFl629Ui";
                String ApplicationID = "AIzaSyC2Tigh9hTgJHgpWOwCVkQd0OdCxFILSwI";
                String SENDER_ID = "82716677818";
                //  var value = "hello"; //message text box
                String val2 = "your hoarding is remove";


                fun.query("insert into chatting(sender,reciever,message,date,time,seen) values('admin','" + zq2.ToString() + "','" + val2.ToString() + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','false')");

                WebRequest tRequest;
                tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send"); tRequest.Method = "post";
                tRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", ApplicationID)); tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                //Data post to the Server
                string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.tickerText=ticker&data.contentTitle=HYPE&data.message=" + val2 + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + a112 + "";
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




                SqlDataAdapter sda12 = new SqlDataAdapter("Select * from register", con);
                DataTable dt2112 = new DataTable();
                sda12.Fill(dt2112);
                String result12 = "";
                if (dt2112.Rows.Count > 0)
                {
                    for (int i = 0; i < dt2112.Rows.Count; i++)
                    {
                        result12 += dt2112.Rows[i][10] + ":";
                    }
                    result12 = result12.Trim(':');
                }
                String[] datas12 = result12.Split(':');

                for (int i = 0; i < datas12.Length; i++)
                {
                    aall12 = datas12[i].ToString();

                }


                SqlDataAdapter sdasda = new SqlDataAdapter("Select * from register where usertype='client'", con);
                DataTable dtdt = new DataTable();
                sdasda.Fill(dtdt);
                String resultsda = "";
                if (dtdt.Rows.Count > 0)
                {
                    for (int i = 0; i < dtdt.Rows.Count; i++)
                    {
                        resultsda += dtdt.Rows[i][2] + ":";
                    }
                    resultsda = resultsda.Trim(':');
                }
                String[] datasdt = resultsda.Split(':');

                for (int i = 0; i < datasdt.Length; i++)
                {
                    String RegId1dt = datasdt[i].ToString();
                    String val11b = GridView2.Rows[RowIndex].Cells[13].Text + " is avalible";
                    fun.query("insert into chatting(sender,reciever,message,date,time,seen) values('admin','" + RegId1dt.ToString() + "','" + val11b.ToString() + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','false')");
                }
                Response.Write("<script language=javascript>alert('SUCESSFULLY SEND');" + "<" + "/" + "script>");
                //           Response.Write("successfully send !!");


                String val112= GridView2.Rows[RowIndex].Cells[13].Text + " is avalible";
                WebRequest tRequest1;
                tRequest1 = WebRequest.Create("https://android.googleapis.com/gcm/send"); tRequest1.Method = "post";
                tRequest1.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                tRequest1.Headers.Add(string.Format("Authorization: key={0}", ApplicationID)); tRequest1.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));



                string postData1 = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.tickerText=ticker&data.contentTitle=HYPE&data.message=" + val112 + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + aall12 + "";
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
                Response.Redirect("~/hoarding.aspx");
            }
            else if (!GridView2.Rows[RowIndex].Cells[10].Text.Equals(edate) || GridView2.Rows[RowIndex].Cells[16].Text.Equals("complete") || GridView2.Rows[RowIndex].Cells[16].Text.Equals("accepted"))
            {
                Response.Write("<script language=javascript>alert('banner currently in used');" + "<" + "/" + "script>");
                //      Response.Write("banner currently in used");
            }
            else if (GridView2.Rows[RowIndex].Cells[16].Text.Equals("expired"))
            {
                Response.Write("<script language=javascript>alert('banner already expired');" + "<" + "/" + "script>");
                //       Response.Write("banner already expired");
            }

            
            else { }
        }
        if (e.CommandName.Equals("pay"))
        {
            if ( GridView2.Rows[RowIndex].Cells[16].Text.Equals("accepted") || GridView2.Rows[RowIndex].Cells[16].Text.Equals("completed") || GridView2.Rows[RowIndex].Cells[16].Text.Equals("expired"))
            {
                Response.Write("<script language=javascript>alert('pay in already given');" + "<" + "/" + "script>");
          //      Response.Write("pay in already given");
            }
            else if (GridView2.Rows[RowIndex].Cells[16].Text.Equals("ask4pay"))
            {
                Response.Write("<script language=javascript>alert('pay request already generated');" + "<" + "/" + "script>");
            //    Response.Write("pay request already generated");
            }
            else
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select statusid from status where hid = '" + GridView2.Rows[RowIndex].Cells[6].Text + "' ";
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    a = reader.GetInt32(0);
                }
                reader.Close();
                DropDownList ddl = (DropDownList)GridView2.Rows[RowIndex].FindControl("dduser");
                selectedvalue = ddl.SelectedValue;
                fun.query("update status set status = 'ask4pay', date = '" + DateTime.Now.ToShortDateString() + "', time = '" + DateTime.Now.ToShortTimeString() + "', remark = 'payment' where hid = '" + GridView2.Rows[RowIndex].Cells[6].Text + "'");
                fun.query("update hoarding set status = 'ask4pay' where hid = '" + GridView2.Rows[RowIndex].Cells[6].Text + "'");

                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "select uid from hoarding where hid = '" + GridView2.Rows[RowIndex].Cells[6].Text + "' ";
                cmd1.Connection = con;
                //con.Open();
                SqlDataReader reader2 = cmd1.ExecuteReader();
                while (reader2.Read())
                {
                    a1 = reader2.GetInt32(0);
                }
                // Response.Write(a1);
                reader2.Close();


                cmd1.CommandText = "select deviceid,username from register where uid = '" + a1 + "' ";
                cmd1.Connection = con;
                SqlDataReader reader11 = cmd1.ExecuteReader();
                while (reader11.Read())
                {
                    a11 = reader11.GetString(0);
                    z1 = reader11.GetString(1);
                }
                // Response.Write(a11);
                reader11.Close();



                //  String RegId = "APA91bGRVLRAfIhykRKybyW4QTgvNeerFeY8WUddR8ENN4Q2sBTRWboSy53K_t5J0CtQ1nwNVDS8hVUQTNO7WkkJokb7OFHno3fIQ9y2VvrFsgFYntV3XcgiIfj36Q31a58kCFl629Ui";
                String ApplicationID = "AIzaSyC2Tigh9hTgJHgpWOwCVkQd0OdCxFILSwI";
                String SENDER_ID = "82716677818";
                //  var value = "hello"; //message text box
                String val = "hoarding acccepted pay " + GridView2.Rows[RowIndex].Cells[17].Text + "rupees in 2 days";

                WebRequest tRequest;
                tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send"); tRequest.Method = "post";
                tRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", ApplicationID)); tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                //Data post to the Server
                string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.tickerText=ticker&data.contentTitle=HYPE&data.message=" + val + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + a11 + "";
                Console.WriteLine(postData);
                fun.query("insert into chatting(sender,reciever,message,date,time,seen) values('admin','" + z1.ToString() + "','" + val.ToString() + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','false')");
        
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

                Response.Redirect("~/hoarding.aspx");
            }
        }
    }



    protected void GridView2_RowDeleting(object sender, EventArgs e)
    {
       
        if (GridView2.Rows[RowIndex].Cells[16].Text.Equals("accepted") || GridView2.Rows[RowIndex].Cells[16].Text.Equals("completed"))
        {
            Response.Write("<script language=javascript>alert('banner in used');" + "<" + "/" + "script>");
        //    Response.Write("banner in used");
        }
        else if (GridView2.Rows[RowIndex].Cells[16].Text.Equals("ask4pay"))
        {
            Response.Write("<script language=javascript>alert('banner pay in process');" + "<" + "/" + "script>");
       //     Response.Write("banner pay in process");
        }

        else if (GridView2.Rows[RowIndex].Cells[16].Text.Equals("expired"))
        {
            Response.Write("<script language=javascript>alert('banner in already expired');" + "<" + "/" + "script>");
       //     Response.Write("banner in already expired");
        }
        else
        {

            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select uid from hoarding where hid = '" + GridView2.Rows[RowIndex].Cells[6].Text + "' ";
            cmd1.Connection = con;
            con.Open();
            SqlDataReader reader2 = cmd1.ExecuteReader();
            while (reader2.Read())
            {
                a1 = reader2.GetInt32(0);
            }
            // Response.Write(a1);
            reader2.Close();


            cmd1.CommandText = "select deviceid,username from register where uid = '" + a1 + "' ";
            cmd1.Connection = con;
            SqlDataReader reader11 = cmd1.ExecuteReader();
            while (reader11.Read())
            {
                a11 = reader11.GetString(0);
                z11 = reader11.GetString(1);
            }
            //Response.Write(z1);
            reader11.Close();

            fun.query("delete from hoarding where hid ='" + GridView2.Rows[RowIndex].Cells[6].Text + "'");
            fun.query("delete from feedback where hid ='" + GridView2.Rows[RowIndex].Cells[6].Text + "'");
            fun.query("delete from status where hid ='" + GridView2.Rows[RowIndex].Cells[6].Text + "'");
            fun.query("delete from location where hid ='" + GridView2.Rows[RowIndex].Cells[6].Text + "'");

            Response.Write("successfully deleted !!");


            String ApplicationID = "AIzaSyC2Tigh9hTgJHgpWOwCVkQd0OdCxFILSwI";
            String SENDER_ID = "82716677818";
            //  var value = "hello"; //message text box
            String val = "your hoarding is cancel as it was in valid";


            WebRequest tRequest;
            tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send"); tRequest.Method = "post";
            tRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            tRequest.Headers.Add(string.Format("Authorization: key={0}", ApplicationID)); tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
            //Data post to the Server
            string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.tickerText=ticker&data.contentTitle=HYPE&data.message=" + val + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + a11 + "";
            Console.WriteLine(postData);

            fun.query("insert into chatting(sender,reciever,message,date,time,seen) values('admin','" + z11.ToString() + "','" + val.ToString() + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','false')");
            
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

            Response.Redirect("~/hoarding.aspx");
        }

    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var ddl = (DropDownList)e.Row.FindControl("dduser");
            DataTable dt = fun.select("select * from register where usertype='worker'");
            ddl.DataSource = dt;
            ddl.DataTextField = "username";
            ddl.DataValueField = "uid";
            ddl.DataBind();
        }
        
            
    }


    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}


/* String toddate = DateTime.Now.ToShortDateString();
        String paydate = GridView2.Rows[RowIndex].Cells[18].Text;
        int a = Int16.Parse(toddate);
        int b = Int16.Parse(paydate);
        int c = a - b ;
        if (c <= 3)
        {
            Response.Write("time 4 payment not over");
        }**/