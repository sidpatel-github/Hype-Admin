using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.IO;
/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    SqlConnection con = new SqlConnection(Class1.datasource); public Int32 user, userhid;
    public Int64 pno;

    public string user1, username, pname, pusername, poccu, paddr, pemail;

    public WebService()
    {
        //Uncomment the following line if using designed components
        //InitializeComponent();
    }
    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }
    //=============================================================================================================================================================
    public static string CreateRandomotp(int PasswordLength)
    {
        string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
        Random randNum = new Random();
        char[] chars = new char[PasswordLength];
        int allowedCharCount = _allowedChars.Length;
        for (int i = 0; i < PasswordLength; i++)
        {
            chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
        }
        return new string(chars);
    }

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
    //=============================================================================================================================================================
    [WebMethod]
    public string insert(string username, string password, string name, string occupation, string address, string phoneno, string email, string deviceid, string active, string vercode)
    {
        con.Open();

        SqlDataAdapter sda = new SqlDataAdapter("Select * from register where email = '" + email + "' ", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        SqlDataAdapter sda1 = new SqlDataAdapter("Select * from register where username = '" + username + "'", con);
        DataTable dt1 = new DataTable();
        sda1.Fill(dt1);

        if (dt.Rows.Count > 0 || dt1.Rows.Count > 0)
        {
            return "false";
        }
        else
        {
            var fromAddress = "hypescet@gmail.com";
            // any address where the email will be sending
            var toAddress = email;
            //Password of your gmail address
            const string fromPassword = "hype1234";
            // Passing the values and make a email formate to display
            string subject = "otp ver ";//TextBox1.Text.ToString();
            string body = CreateRandomotp(8);//TextBox2.Text + "\n";
            string device = deviceno(5);

            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            // Passing values to smtp object
            smtp.Send(fromAddress, toAddress, subject, body);

            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            String md5password = strBuilder.ToString();
            SqlCommand cmd = new SqlCommand("insert into register(usertype,username,password,name,occupation,address,phoneno,email,deviceid,active,vercode) values ('Client','" + username + "','" + md5password + "','" + name + "','" + occupation + "','" + address + "','" + phoneno + "','" + email + "','" + device + "','" + "deactive" + "','" + body + "')", con);
            cmd.ExecuteNonQuery();




            con.Close();
            return "true";
        }
    }
    //=============================================================================================================================================================
    [WebMethod]
    public string select(string username, string password)
    {
        con.Open();
        MD5 md5 = new MD5CryptoServiceProvider();
        md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
        byte[] result = md5.Hash;
        StringBuilder strBuilder = new StringBuilder();
        for (int i = 0; i < result.Length; i++)
        {
            strBuilder.Append(result[i].ToString("x2"));
        }
        String md5password = strBuilder.ToString();

        SqlDataAdapter sda = new SqlDataAdapter("Select * from register where username='" + username + "' and password = '" + md5password + "' and usertype='client'", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            String LineOfText = "active," + dt.Rows[0][0] + "," + dt.Rows[0][2];
            String[] aryTextFile = LineOfText.Split(',');
            foreach (string word in aryTextFile)
            {
                Console.WriteLine(word);
            }
            user = Int32.Parse(aryTextFile[1]);
            username = aryTextFile[2];
            Console.WriteLine(user);

            if (dt.Rows[0][10].ToString().Equals("active"))
            {
                con.Close();
                return "active," + user + "," + username;
            }
            else
            {
                con.Close();
                return "deactive," + user + "," + username;
            }
        }
        else
        {
            con.Close();
            return "false";
        }
    }
    //=============================================================================================================================================================
    [WebMethod]
    public string selectemail(string email)
    {
        con.Open();
        var fromAddress = "hypescet@gmail.com";
        // any address where the email will be sending
        var toAddress = email;
        //Password of your gmail address
        const string fromPassword = "hype1234";
        // Passing the values and make a email formate to display
        string subject = "otp ver ";//TextBox1.Text.ToString();
        string body = CreateRandomotp(8);//TextBox2.Text + "\n";

        // smtp settings
        var smtp = new System.Net.Mail.SmtpClient();
        {
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
            smtp.Timeout = 20000;
        }
        // Passing values to smtp object


        SqlDataAdapter sda = new SqlDataAdapter("Select * from register where email='" + email + "'", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            smtp.Send(fromAddress, toAddress, subject, body);
            SqlCommand cmd = new SqlCommand("update register set vercode = '" + body + "' where email = '" + email + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return "true";
        }
        else
        {
            con.Close();
            return "false";
        }
    }
    //=============================================================================================================================================================
    [WebMethod]
    public string selectemailver(string email, string otp)
    {
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter("Select * from register where email='" + email + "' and vercode = '" + otp + "'", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            con.Close();
            return "true";
        }
        else
        {
            con.Close();
            return "false";
        }
    }
    //=============================================================================================================================================================
    [WebMethod]
    public string sentotp(string email)
    {
        con.Open();
        var fromAddress = "hypescet@gmail.com";
        // any address where the email will be sending
        var toAddress = email;
        //Password of your gmail address
        const string fromPassword = "hype1234";
        // Passing the values and make a email formate to display
        string subject = "otp ver ";//TextBox1.Text.ToString();
        string body = CreateRandomotp(8);//TextBox2.Text + "\n";
        // smtp settings
        var smtp = new System.Net.Mail.SmtpClient();
        {
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
            smtp.Timeout = 20000;
        }
        // Passing values to smtp object
        smtp.Send(fromAddress, toAddress, subject, body);

        string otp = body;
        SqlCommand cmd = null;

        cmd = new SqlCommand("Update register set vercode='" + body + "' where email = '" + email + "'", con);
        int i = cmd.ExecuteNonQuery();
        if (i == 1)
        {
            con.Close();
            return "true";
        }
        else
        {
            con.Close();
            return "false";
        }
    }
    //=============================================================================================================================================================
    [WebMethod]
    public string selectotp(string otp, string email)
    {
        con.Open();
        SqlCommand cmd = null;
        SqlDataAdapter sda = new SqlDataAdapter("Select vercode from register where email='" + email + "'", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        if (dt.Rows.Count > 0)
        {

            if (dt.Rows[0][0].ToString().Equals(otp))
            {
                cmd = new SqlCommand("Update register set active='" + "active" + "' where email='" + email + "'", con);
                cmd.ExecuteNonQuery(); con.Close();
                return "true";
            }
            else
            {
                con.Close();
                return "false";
            }
        }
        else
        {
            con.Close();
            return "false";
        }
    }
    //=============================================================================================================================================================
    [WebMethod]
    public string delete(int uid)
    {
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter("Delete from register where uid='" + uid + "'", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            con.Close();
            return "false";
        }
        else
        {
            con.Close();
            return "true";
        }
    }
    //=============================================================================================================================================================
    [WebMethod]
    public string uppassword(int uid, string password)
    {
        con.Open();
        MD5 md5 = new MD5CryptoServiceProvider();
        md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
        byte[] result = md5.Hash;
        StringBuilder strBuilder = new StringBuilder();
        for (int i = 0; i < result.Length; i++)
        {
            strBuilder.Append(result[i].ToString("x2"));
        }
        String md5password = strBuilder.ToString();

        SqlCommand cmd = null;
        cmd = new SqlCommand("Update register set password='" + md5password + "' where uid = '" + uid + "'", con);
        int ii = cmd.ExecuteNonQuery();
        if (ii == 1)
        {
            con.Close();
            return "true";
        }
        else
        {
            con.Close();
            return "false";
        }
    }
    //=============================================================================================================================================================
    [WebMethod]
    public string uppasswordemail(string password, String email)
    {
        con.Open();
        MD5 md5 = new MD5CryptoServiceProvider();
        md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
        byte[] result = md5.Hash;
        StringBuilder strBuilder = new StringBuilder();
        for (int i = 0; i < result.Length; i++)
        {
            strBuilder.Append(result[i].ToString("x2"));
        }
        String md5password = strBuilder.ToString();

        SqlCommand cmd = null;
        cmd = new SqlCommand("Update register set password='" + md5password + "' where email = '" + email + "'", con);
        int ii = cmd.ExecuteNonQuery();
        if (ii == 1)
        {
            con.Close();
            return "true";
        }
        else
        {
            con.Close();
            return "false";
        }
    }
    //=============================================================================================================================================================
    [WebMethod]
    public string upprofile(int uid, string username, string name, string address, string phoneno, string email)
    {
        con.Open();
        SqlCommand cmd = null;
        cmd = new SqlCommand("Update register set name = '" + name + "',usertype='Client ', address = '" + address + "', phoneno = '" + phoneno + "', email = '" + email + "', username = '" + username + "' where  uid = '" + uid + "'", con);
        int i = cmd.ExecuteNonQuery();
        if (i == 1)
        {
            con.Close();
            return "true";
        }
        else
        {
            con.Close();
            return "false";
        }

    }
    //=============================================================================================================================================================
    [WebMethod]
    public string overloadprof(int uid)
    {
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter("Select * from register where  uid = '" + uid + "'", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            String LineOfText = "true," + dt.Rows[0][2] + "," + dt.Rows[0][4] + "," + dt.Rows[0][5] + "," + dt.Rows[0][6] + "," + dt.Rows[0][7] + "," + dt.Rows[0][8];
            Console.WriteLine(LineOfText);
            String[] aryTextFile = LineOfText.Split(',');
            foreach (string word in aryTextFile)
            {
                Console.WriteLine(word);
            }
            pusername = aryTextFile[1];
            pname = aryTextFile[2];
            poccu = aryTextFile[3];
            paddr = aryTextFile[4];
            pno = Int64.Parse(aryTextFile[5]);
            pemail = aryTextFile[6];
            con.Close();
            return "true," + pusername + "," + pname + "," + poccu + "," + paddr + "," + pno + "," + pemail;
        }
        else
        {
            con.Close();
            return "false";
        }
    }
    //============================================================================================================================================================    
    [WebMethod]
    public string bookhoarding(int uid, string btype, string size, string bookdate, string expiredate, string area, string city, string state, string image, string price)
    {
        String iname = null;
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into hoarding(uid,btype,size,bookdate,expiredate,area,city,state,image,status,price) values ('" + uid + "','" + btype + "','" + size + "','" + DateTime.Parse(bookdate).ToShortDateString() + "','" + DateTime.Parse(expiredate).ToShortDateString() + "','" + area + "','" + city + "','" + state + "','temp','queue','" + price + "')", con);
        cmd.ExecuteNonQuery();

        SqlDataAdapter sda = new SqlDataAdapter("Select * from hoarding where uid='" + uid + "' and image = 'temp'", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            String LineOfText = "active," + dt.Rows[0][0];
            String[] aryTextFile = LineOfText.Split(',');
            foreach (string word in aryTextFile)
            {
                Console.WriteLine(word);
            }
            userhid = Int32.Parse(aryTextFile[1]);
            Console.WriteLine(userhid);

            iname = userhid.ToString() + uid.ToString() + image;
            SqlCommand cmd1 = new SqlCommand("update hoarding set image='" + iname + "' where hid='" + userhid + "'", con);
            cmd1.ExecuteNonQuery();

            //===================location setting=========    

            SqlDataAdapter sda1 = new SqlDataAdapter("Select area from hoarding where hid='" + userhid + "'", con);
            DataTable dt2 = new DataTable();
            sda1.Fill(dt2);

            String areaholding = dt2.Rows[0][0].ToString();

            SqlDataAdapter sda3 = new SqlDataAdapter("Select latitude,longitude from area where aname='" + areaholding + "'", con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3); //return "dt3.Rows[0][0].ToString()" + "dt3.Rows[0][1].ToString()";


            SqlDataAdapter sda4 = new SqlDataAdapter("insert into location(hid,latitude,longitude) values ('" + userhid + "','" + dt3.Rows[0][0].ToString() + "','" + dt3.Rows[0][1].ToString() + "')", con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);

            System.IO.File.Move(@"C:\inetpub\wwwroot\WebSite5\Uploads\" + image, @"C:\inetpub\wwwroot\WebSite5\Uploads\" + iname);
            //   System.IO.File.Move(@"C:\inetpub\wwwroot\WebSite5\Uploads\" + image, @"C:\inetpub\wwwroot\WebSite5\Uploads\" + iname);

            con.Close();
            //================================================================================    
            return "true," + userhid + "," + iname;

        }
        else
        {
            con.Close();
            return "false," + userhid + "," + iname;
        }


    }
    //============================================================================================================================================================    
    [WebMethod]
    public string bookfeedback(int uid, int hid, string image, string banner, string area)
    {
        con.Open();
        SqlDataAdapter sda1 = new SqlDataAdapter("Select bid from banner where btype = '" + banner + "'", con);
        DataTable dt1 = new DataTable();
        sda1.Fill(dt1);
        String result1 = "";
        result1 = dt1.Rows[0][0] + ":";
        result1 = result1.Trim(':');

        SqlDataAdapter sda11 = new SqlDataAdapter("Select aid from area where aname = '" + area + "'", con);
        DataTable dt11 = new DataTable();
        sda11.Fill(dt11);
        String result11 = "";
        result11 = dt11.Rows[0][0] + ":";
        result11 = result11.Trim(':');

        //  return result1 +"   " + result11;
        SqlCommand cmd = new SqlCommand("insert into feedback(uid,hid,bid,aid,date,time,rating,feed) values ('" + uid + "','" + hid + "','" + result1 + "','" + result11 + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','5','good')", con);
        cmd.ExecuteNonQuery();
        con.Close();
        return "true";
    }
    //============================================================================================================================================================    
    [WebMethod]
    public string bookstatus(int uid, int hid)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into status(uid,hid,status,date,time,remark) values ('" + uid + "','" + hid + "','queue','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','not_verify')", con);
        cmd.ExecuteNonQuery(); con.Close();

        return "true";
    }
    //============================================================================================================================================================
    [WebMethod]
    public string feedback(int uid, string rating, string feed, int hid)
    {
        con.Open();
        SqlCommand cmd = null;
        cmd = new SqlCommand("Update feedback set date = '" + DateTime.Now.ToShortDateString() + "', time = '" + DateTime.Now.ToShortTimeString() + "', rating = '" + rating + "', feed = '" + feed + "' where  uid = '" + uid + "' and hid = '" + hid + "' ", con);
        int i = cmd.ExecuteNonQuery();
        if (i == 1)
        {
            con.Close();
            return "true";
        }
        else
        {
            con.Close();
            return "false";
        }
    }
    //============================================================================================================================================================
    [WebMethod]
    public string urlfetch(int uid)
    {
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter("Select * from hoarding where uid='" + uid + "'", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        String result = "";
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result += dt.Rows[i][0] + ",," + dt.Rows[i][1] + ",," + dt.Rows[i][2] + ",," + dt.Rows[i][3] + ",," + dt.Rows[i][4] + ",," + dt.Rows[i][5] + ",," + dt.Rows[i][6] + ",," + dt.Rows[i][7] + ",," + dt.Rows[i][8] + ",," + dt.Rows[i][9] + ",," + dt.Rows[i][10] + ",," + dt.Rows[i][11] + ":";
            }
            result = result.Trim(':'); con.Close();
            return result;
        }
        else
        {
            con.Close();
            return "false";
        }
    }
    //============================================================================================================================================================
    [WebMethod]
    public string historyfetch(int uid, int hid)
    {
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter("Select * from hoarding where uid='" + uid + "' and hid = '" + hid + "'", con);
        DataTable dt = new DataTable();
        sda.Fill(dt); con.Close();
        return dt.Rows[0][2] + ",," + dt.Rows[0][3] + ",," + dt.Rows[0][4] + ",," + dt.Rows[0][5] + ",," + dt.Rows[0][6] + ",," + dt.Rows[0][7] + ",," + dt.Rows[0][8] + ",," + dt.Rows[0][9] + ",," + dt.Rows[0][11];

    }
    //============================================================================================================================================================
    [WebMethod]
    public string feed(int uid)
    {
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter("Select feedback.uid,feedback.hid,feedback.fid,feedback.date,hoarding.area,hoarding.image,feedback.rating,feedback.feed from hoarding,feedback where feedback.uid = '" + uid + "' and hoarding.uid = '" + uid + "' and feedback.hid = hoarding.hid", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        String result = "";
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result += dt.Rows[i][0] + ",," + dt.Rows[i][1] + ",," + dt.Rows[i][2] + ",," + dt.Rows[i][3] + ",," + dt.Rows[i][4] + ",," + dt.Rows[i][5] + ",," + dt.Rows[i][6] + ",," + dt.Rows[i][7] + "::";
            }
            result = result.Trim(':'); con.Close();
            return result;
        }
        else
        {
            con.Close();
            return "false";
        }

    }
    //============================================================================================================================================================
    [WebMethod]
    public string overloadfeed(int uid, int hid)
    {
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter("Select image,rating,feed from feedback where uid = '" + uid + "' and hid ='" + hid + "'", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        String result = "";
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result += dt.Rows[i][0] + ",," + dt.Rows[i][1] + ",," + dt.Rows[i][2] + ":";
            }
            result = result.Trim(':'); con.Close();
            return result;
        }
        else
        {
            con.Close();
            return "false";
        }

    }
    //============================================================================================================================================================
    [WebMethod]
    public string size(string area)
    {
        con.Open();

        SqlDataAdapter sda1 = new SqlDataAdapter("Select size from area where aname = '" + area + "'", con);
        DataTable dt1 = new DataTable();
        sda1.Fill(dt1);
        String result1 = "";
        result1 = dt1.Rows[0][0] + ":";
        result1 = result1.Trim(':');
        if (dt1.Rows.Count > 0)
        {
            con.Close();
            return result1;
        }
        else
        {
            con.Close();
            return "please select area"; ;
        }
    }
    //============================================================================================================================================================
    [WebMethod]
    public string banner()
    {
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter("Select btype from banner", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        String result = "";
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result += dt.Rows[i][0] + ":";
            }
            result = result.Trim(':'); con.Close();
            return result;
        }
        else
        {
            con.Close();
            return "false";
        }
    }
    //============================================================================================================================================================
    [WebMethod]
    public string state()
    {
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter("Select sname from state", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        String result = "";
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result += dt.Rows[i][0] + ":";
            }
            result = result.Trim(':'); con.Close();
            return result;
        }
        else
        {
            con.Close();
            return "false";
        }
    }
    //============================================================================================================================================================
    [WebMethod]
    public string city(string state)
    {
        con.Open();
        SqlDataAdapter sda1 = new SqlDataAdapter("Select sid from state where sname = '" + state + "'", con);
        DataTable dt1 = new DataTable();
        sda1.Fill(dt1);
        String result1 = "";
        result1 = dt1.Rows[0][0] + ":";
        result1 = result1.Trim(':');
        SqlDataAdapter sda = new SqlDataAdapter("Select cname from city where sid = '" + result1 + "'", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        String result = "";
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result += dt.Rows[i][0] + ":";
            }
            result = result.Trim(':'); con.Close();
            return result;
        }
        else
        {
            con.Close();
            return "false";
        }
    }
    //============================================================================================================================================================
    [WebMethod]
    public string area(int uid, string state, string city, string bann)
    {
        con.Open();
        SqlDataAdapter sda1 = new SqlDataAdapter("Select cid from city where cname = '" + city + "'", con);
        DataTable dt1 = new DataTable();
        sda1.Fill(dt1);
        String result1 = "";
        result1 = dt1.Rows[0][0] + ":";
        result1 = result1.Trim(':');

        SqlDataAdapter sda2 = new SqlDataAdapter("Select bid from banner where btype = '" + bann + "'", con);
        DataTable dt2 = new DataTable();
        sda2.Fill(dt2);
        String result2 = "";
        result2 = dt2.Rows[0][0] + ":";
        result2 = result2.Trim(':');


        SqlDataAdapter sda3 = new SqlDataAdapter("Select occupation from register where uid = '" + uid + "'", con);
        DataTable dt3 = new DataTable();
        sda3.Fill(dt3);
        String result3 = "";
        result3 = dt3.Rows[0][0] + ":";
        result3 = result3.Trim(':');

        SqlDataAdapter sda4 = new SqlDataAdapter("Select sid from state where sname = '" + state + "'", con);
        DataTable dt4 = new DataTable();
        sda4.Fill(dt4);
        String result4 = "";
        result4 = dt4.Rows[0][0] + ":";
        result4 = result4.Trim(':');

        //  return result1 + "  " + result2 + "  " + result3 + " " + result4;
        /*
        SqlDataAdapter sda = new SqlDataAdapter("Select aname from area where cid = '"+ result1 +"' and bid = '"+ result2 +"'", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        String result = "";
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result += dt.Rows[i][0] + ":";
            }
            result = result.Trim(':');
            return result;
        }
        else
        {
            return "avalible only for surat";
        }
        
        SqlDataAdapter sda = new SqlDataAdapter("select a1.aname,r.occupation,'1' as booked from area as a1,hoarding as h1,register as r where r.occupation='" + result3 + "' and r.uid=h1.uid and a1.aname=h1.area and h1.btype='" + bann.ToString() + "' and h1.state='"+state.ToString()+"'  and h1.city='" + city.ToString() + "' and a1.aname  in (select area from hoarding ) group by a1.aname,r.occupation order by r.occupation ", con);  
        DataTable dt = new DataTable();
        sda.Fill(dt);
*/
        /*  if (dt.Rows.Count > 0)
          {
              result = "========area not free=======:";
              for (int i = 0; i < dt.Rows.Count; i++)
              {
                  result += dt.Rows[i][0] + ":";
              }
            
             // result = result.Trim(':');
             // return result;
          }
        
          */
        SqlDataAdapter sda11 = new SqlDataAdapter("select a1.aname,'0' as booked,'no occupation' as occupation from area as a1 where a1.sid = '" + result4 + "' and a1.cid='" + result1 + "' and a1.bid='" + result2 + "' and aname not in (select area from hoarding as h where h.btype='" + bann.ToString() + "' and h.status='queue' or h.status='completed' or h.status='admin_varify') order by booked", con);
        DataTable dt11 = new DataTable();
        sda11.Fill(dt11);
        String result = "";
        if (dt11.Rows.Count > 0)
        {
            result += "=========area free=========:";
            for (int i = 0; i < dt11.Rows.Count; i++)
            {

                result += dt11.Rows[i][0] + ":";
            }

            result = result.Trim(':');
            con.Close();
            return result;
        }
        else
        {
            con.Close();
            return "avalible only for surat";
        }



    }

    //============================================================================================================================================================
    [WebMethod]
    public string areafetch(int uid, string state, string city, string bann)
    {
        con.Open();
        SqlDataAdapter sda1 = new SqlDataAdapter("Select cid from city where cname = '" + city + "'", con);
        DataTable dt1 = new DataTable();
        sda1.Fill(dt1);
        String result1 = "";
        result1 = dt1.Rows[0][0] + ":";
        result1 = result1.Trim(':');

        SqlDataAdapter sda2 = new SqlDataAdapter("Select bid from banner where btype = '" + bann + "'", con);
        DataTable dt2 = new DataTable();
        sda2.Fill(dt2);
        String result2 = "";
        result2 = dt2.Rows[0][0] + ":";
        result2 = result2.Trim(':');


        SqlDataAdapter sda3 = new SqlDataAdapter("Select occupation from register where uid = '" + uid + "'", con);
        DataTable dt3 = new DataTable();
        sda3.Fill(dt3);
        String result3 = "";
        result3 = dt3.Rows[0][0] + ":";
        result3 = result3.Trim(':');

        SqlDataAdapter sda4 = new SqlDataAdapter("Select sid from state where sname = '" + state + "'", con);
        DataTable dt4 = new DataTable();
        sda4.Fill(dt4);
        String result4 = "";
        result4 = dt4.Rows[0][0] + ":";
        result4 = result4.Trim(':');

        //  return result1 + "  " + result2 + "  " + result3 + " " + result4;
        /*
        SqlDataAdapter sda = new SqlDataAdapter("Select aname from area where cid = '"+ result1 +"' and bid = '"+ result2 +"'", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        String result = "";
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result += dt.Rows[i][0] + ":";
            }
            result = result.Trim(':');
            return result;
        }
        else
        {
            return "avalible only for surat";
        }*/
        String result = "";
        SqlDataAdapter sda = new SqlDataAdapter("select a1.aname,r.occupation,'1' as booked from area as a1,hoarding as h1,register as r where r.occupation='" + result3 + "' and r.uid=h1.uid and a1.aname=h1.area and h1.btype='" + bann.ToString() + "' and h1.state='" + state.ToString() + "'  and h1.city='" + city.ToString() + "' and a1.aname  in (select area from hoarding as h where h.status='queue' or h.status='completed' or h.status='admin_varify' ) group by a1.aname,r.occupation order by r.occupation ", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        if (dt.Rows.Count > 0)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result += dt.Rows[i][0] + ":";
            }

            result = result.Trim(':'); con.Close();
            return result;
        }

        /*
        SqlDataAdapter sda11 = new SqlDataAdapter("select a1.aname,'0' as booked,'no occupation' as occupation from area as a1 where a1.sid = '" + result4 + "' and a1.cid='" + result1 + "' and a1.bid='" + result2 + "' and aname not in (select area from hoarding as h1 where h1.btype='" + bann.ToString() + "') order by booked", con);
        DataTable dt11 = new DataTable();
        sda11.Fill(dt11);

        if (dt11.Rows.Count > 0)
        {
            result += "=========area free=========:";
            for (int i = 0; i < dt11.Rows.Count; i++)
            {

                result += dt11.Rows[i][0] + ":";
            }

            result = result.Trim(':');

            return result;
        }*/
        else
        {
            con.Close();
            return "avalible only for surat";
        }



    }

    //============================================================================================================================================================



    [WebMethod]
    public string lanlat(string area)
    {
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter("Select latitude,longitude from area where aname='" + area + "'", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        String result = "";
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result += dt.Rows[i][0] + "`" + dt.Rows[i][1] + ":";
            }
            result = result.Trim(':'); con.Close();
            return result;
        }
        else
        {
            con.Close();
            return "false";
        }

    }
    //============================================================================================================================================================
    [WebMethod]
    public string updatedevice(string uid, string deviceid)
    {
        con.Open();
        SqlCommand cmd = null;
        cmd = new SqlCommand("Update register set deviceid='" + deviceid + "' where uid = '" + uid + "'", con);
        int i = cmd.ExecuteNonQuery();
        if (i == 1)
        {
            con.Close();
            return "true";
        }
        else
        {
            con.Close();
            return "false";
        }

    }
    //==========================================================================================================================================================
    [WebMethod]
    public string chat(int uid, string msg1)
    {
        con.Open();
        SqlDataAdapter sda1 = new SqlDataAdapter("Select username from register where uid = '" + uid + "'", con);
        DataTable dt1 = new DataTable();
        sda1.Fill(dt1);
        String result1 = "";
        result1 = dt1.Rows[0][0] + ":";
        result1 = result1.Trim(':');
        //return result1+","+msg.ToString();

        SqlCommand cmd = new SqlCommand("insert into chatting(sender,reciever,message,date,time,seen) values ('" + result1.ToString() + "','admin',' " + msg1.ToString().Trim() + "'  ,'" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','false')", con);
        cmd.ExecuteNonQuery();
        con.Close();
        return "true";
    }
    //============================================================================================================================================================
    [WebMethod]
    public string chatfetch(int uid)
    {

        con.Open();
        SqlDataAdapter sda11 = new SqlDataAdapter("Select username from register where uid = '" + uid + "'", con);
        DataTable dt11 = new DataTable();
        sda11.Fill(dt11);
        String result1;
        result1 = dt11.Rows[0][0] + ":";
        result1 = result1.Trim(':');


        SqlCommand cmd = null;
        cmd = new SqlCommand("Update chatting set seen ='true' where reciever = '" + result1 + "'", con);//update workerdetail set locfinalimage = '" + iname + "' where hid='" + hid + "' and  locfinalimage ='temp' and uid = '" + uid + "'", con);
        int i = cmd.ExecuteNonQuery();


        /*     SqlDataAdapter sda1 = new SqlDataAdapter("
             DataTable dt1 = new DataTable();
             sda1.Fill(dt1);
             */

        SqlDataAdapter sda = new SqlDataAdapter("Select chatting.* from chatting,register where (register.username=chatting.sender or register.username=chatting.reciever) and uid ='" + uid + "' order by chatid asc", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        String result = "";

        if (dt.Rows.Count > 0)
        {
            for (int ii = 0; ii < dt.Rows.Count; ii++)
            {
                result += dt.Rows[ii][1] + ",," + dt.Rows[ii][2] + ",," + dt.Rows[ii][3] + ",," + dt.Rows[ii][4] + ",," + dt.Rows[ii][5] + ",," + dt.Rows[ii][6] + "#";
            }
            result = result.Trim('#'); con.Close();
            return result;
        }
        else
        {
            con.Close();
            return "false";
        }

        //return dt.Rows[0][1] + ",," + dt.Rows[0][2] + ",," + dt.Rows[0][3] + ",," + dt.Rows[0][4] + ",," + dt.Rows[0][5] + ",," + dt.Rows[0][6] + ":";

    }


    //==========================================================================================================================================================
    [WebMethod]
    public string getprice(string size, string area)
    {
        con.Open();
        SqlDataAdapter sda1 = new SqlDataAdapter("Select price from area where size= '" + size + "' and aname = '" + area + "'", con);
        DataTable dt1 = new DataTable();
        sda1.Fill(dt1);
        String result1 = "";
        String[] result2 = new String[10];

        result1 = dt1.Rows[0][0] + ":";
        result1 = result1.Trim(':');
        result2 = size.Split('*');

        Int16 a = Convert.ToInt16(result2[0]);
        Int16 b = Convert.ToInt16(result2[1]);
        Int16 c = Convert.ToInt16(result1);

        int result3 = a * b * c;

        //return result1+","+msg.ToString();
        /*
        SqlCommand cmd = new SqlCommand("insert into chatting(sender,reciever,message,date,time,seen) values ('" + result1.ToString() + "','admin',' " + msg.ToString() + "'  ,'" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','false')", con);
        cmd.ExecuteNonQuery();
        con.Close();*/
        con.Close();
        return result3.ToString();
    }
    //==========================================================================================================================================================
    [WebMethod]
    public string feedbackarea(string city)
    {
        con.Open();
        SqlDataAdapter sda1 = new SqlDataAdapter("Select cid from city where cname = '" + city + "'", con);
        DataTable dt1 = new DataTable();
        sda1.Fill(dt1);
        String result1 = "";
        result1 = dt1.Rows[0][0] + ":";
        result1 = result1.Trim(':');
        SqlDataAdapter sda = new SqlDataAdapter("Select aname from area where cid = '" + result1 + "'", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        String result = "";
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result += dt.Rows[i][0] + ":";
            }
            result = result.Trim(':'); con.Close();
            return result;
        }
        else
        {
            con.Close();
            return "avalible only for surat";
        }
    }

    //==========================================================================================================================================================
    [WebMethod]
    public string reviewbyarea(string area, string city)
    {
        con.Open();
        SqlDataAdapter sda1 = new SqlDataAdapter("Select city from hoarding where city='" + city + "'", con);
        DataTable dt1 = new DataTable();
        sda1.Fill(dt1);
        if (dt1.Rows.Count == 0)
        {
            return "false";
        }
        SqlDataAdapter sda = new SqlDataAdapter("Select register.username,hoarding.btype,hoarding.area,feedback.rating,feedback.feed from register,hoarding,feedback where register.uid = feedback.uid and feedback.hid = hoarding.hid and hoarding.area = '" + area + "'", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        String reviewstring = "";
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                reviewstring += dt.Rows[i][0].ToString() + ",," + dt.Rows[i][1].ToString() + ",," + dt.Rows[i][2].ToString() + ",," + dt.Rows[i][3].ToString() + ",," + dt.Rows[i][4].ToString() + "#";
            }
            reviewstring = reviewstring.Trim('#'); con.Close();
            return reviewstring;
        }
        else
        {
            con.Close();
            return "falsearea";
        }
    }

    //==========================================================================================================================================================
    [WebMethod]
    public string reviewbybanner(string banner, string city, string state)
    {
        con.Open();

        SqlDataAdapter sda1 = new SqlDataAdapter("Select city from hoarding where city='" + city + "'", con);
        DataTable dt1 = new DataTable();
        sda1.Fill(dt1);
        if (dt1.Rows.Count == 0)
        {
            return "false";
        }
        SqlDataAdapter sda = new SqlDataAdapter("Select register.username,hoarding.btype,hoarding.area,feedback.rating,feedback.feed from register,hoarding,feedback where register.uid = feedback.uid and feedback.hid = hoarding.hid and hoarding.btype = '" + banner + "' and hoarding.city='" + city + "' and hoarding.state='" + state + "'", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        String reviewstring = "";
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                reviewstring += dt.Rows[i][0].ToString() + ",," + dt.Rows[i][1].ToString() + ",," + dt.Rows[i][2].ToString() + ",," + dt.Rows[i][3].ToString() + ",," + dt.Rows[i][4].ToString() + "#";
            }
            reviewstring = reviewstring.Trim('#'); con.Close();
            return reviewstring;
        }
        else
        {
            con.Close();
            return "falsebanner";
        }
    }

    //==========================================================================================================================================================
    [WebMethod]
    public string reviewbyrating(string rating, string city, string state)
    {
        con.Open();
        SqlDataAdapter sda1 = new SqlDataAdapter("Select city from hoarding where city='" + city + "'", con);
        DataTable dt1 = new DataTable();
        sda1.Fill(dt1);
        if (dt1.Rows.Count == 0)
        {
            return "false";
        }
        SqlDataAdapter sda = new SqlDataAdapter("Select register.username,hoarding.btype,hoarding.area,feedback.rating,feedback.feed from register,hoarding,feedback where register.uid = feedback.uid and feedback.hid = hoarding.hid and feedback.rating >= '" + rating + "' and hoarding.city='" + city + "' and hoarding.state='" + state + "' ", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        String reviewstring = "";
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                reviewstring += dt.Rows[i][0].ToString() + ",," + dt.Rows[i][1].ToString() + ",," + dt.Rows[i][2].ToString() + ",," + dt.Rows[i][3].ToString() + ",," + dt.Rows[i][4].ToString() + "#";
            }
            reviewstring = reviewstring.Trim('#'); con.Close();
            return reviewstring;
        }
        else
        {
            con.Close();
            return "falserating";
        }
    }

    //==========================================================================================================================================================
    [WebMethod]
    public string selectuser(string username, string password)
    {
        con.Open();
        MD5 md5 = new MD5CryptoServiceProvider();
        md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
        byte[] result = md5.Hash;
        StringBuilder strBuilder = new StringBuilder();
        for (int i = 0; i < result.Length; i++)
        {
            strBuilder.Append(result[i].ToString("x2"));
        }
        String md5password = strBuilder.ToString();

        SqlDataAdapter sda = new SqlDataAdapter("Select * from register where username='" + username + "' and password = '" + md5password + "' and usertype='worker'", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            String LineOfText = "active," + dt.Rows[0][0];
            String[] aryTextFile = LineOfText.Split(',');
            foreach (string word in aryTextFile)
            {
                Console.WriteLine(word);
            }
            user = Int32.Parse(aryTextFile[1]);
            Console.WriteLine(user);

            if (dt.Rows[0][10].ToString().Equals("active"))
            {
                con.Close();
                return "active," + user;
            }
            else
            {
                con.Close();
                return "deactive," + user;
            }
        }
        else
        {
            con.Close();
            return "false";
        }
    }

    //==========================================================================================================================================================
    [WebMethod]
    public string workerwork(string uid)
    {
        string wid;
        con.Open();
        /*     SqlDataAdapter sda = new SqlDataAdapter("Select uid from register where username='" + username + "' ", con);
             DataTable dt = new DataTable();
             sda.Fill(dt);
             wid = dt.Rows[0][0].ToString();*/
        // return wid;
        // SqlDataAdapter sda1 = new SqlDataAdapter("Select hid,uid,btype,size,bookdate,area,image,status from hoarding where hid IN (select hid from workdistribution where uid='" + wid + "')", con);

        SqlDataAdapter sda1 = new SqlDataAdapter("Select workerdetail.hid,hoarding.uid,btype,size,bookdate,area,image,status.status,status.remark,workerdetail.locfinalimage from status,hoarding,workerdetail where workerdetail.uid='" + uid + "' and status.statusid=workerdetail.statusid and status.hid=hoarding.hid and workerdetail.hid=hoarding.hid", con);
        DataTable dt1 = new DataTable();
        sda1.Fill(dt1);
        String result = "";
        //return dt1.Rows.Count.ToString();
        if (dt1.Rows.Count == 0)
        {
            con.Close();
            return "false";
        }
        else
        {
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                result += dt1.Rows[i][0] + ",," + dt1.Rows[i][1] + ",," + dt1.Rows[i][2] + ",," + dt1.Rows[i][3] + ",," + dt1.Rows[i][4] + ",," + dt1.Rows[i][5] + ",," + dt1.Rows[i][6] + ",," + dt1.Rows[i][7] + ",," + dt1.Rows[i][8] + ",," + dt1.Rows[i][9] + ",,";
                string[] wprice = new string[10];
                wprice = dt1.Rows[i][3].ToString().Split('*');

                int a = Int32.Parse(wprice[0]);
                int b = Int32.Parse(wprice[1]);
                int c = a * b * 1;
                result += c + ":";
            }
            result = result.Trim(':'); con.Close();
            return result;
        }
    }
    //==========================================================================================================================================================
    [WebMethod]
    public string workermap(int hid)
    {

        String str;
        con.Open();
        SqlDataAdapter sda1 = new SqlDataAdapter("Select latitude,longitude from location where hid = '" + hid + "'", con);
        DataTable dt1 = new DataTable();
        sda1.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            str = dt1.Rows[0][0].ToString() + "`" + dt1.Rows[0][1].ToString(); con.Close();
            return str;
        }
        else
        {
            con.Close();
            return "false";
        }

    }

    //==========================================================================================================================================================
    [WebMethod]
    public string upremark(int uid, int hid, string remark)
    {
        con.Open();
        SqlCommand cmd = null;
        cmd = new SqlCommand("Update status set remark = '" + remark + "', date = '" + DateTime.Now.ToShortDateString() + "', time = '" + DateTime.Now.ToShortTimeString() + "' where statusid IN (select statusid from workerdetail where uid='" + uid + "') and hid='" + hid + "' ", con);
        int i = cmd.ExecuteNonQuery();
        if (i == 1)
        {
            con.Close();
            return "true";
        }
        else
        {
            con.Close();
            return "false";
        }

    }
    //============================================================================================================================================================
    [WebMethod]
    public string updateworkerdevice(string uid, string deviceid)
    {
        con.Open();
        SqlCommand cmd = null;
        cmd = new SqlCommand("Update register set deviceid='" + deviceid + "' where uid = '" + uid + "'", con);
        int i = cmd.ExecuteNonQuery();
        if (i == 1)
        {
            con.Close();
            return "true";
        }
        else
        {
            con.Close();
            return "false";
        }

    }
    //============================================================================================================================================================
    [WebMethod]
    public string imghoarding(string hid, string uid, string image)
    {
        con.Open();

        string device1 = deviceno(5);
        SqlCommand cmd1 = null;
        cmd1 = new SqlCommand("Update workerdetail set locfinalimage = 'temp',date='" + DateTime.Now.ToShortDateString() + "',time='" + DateTime.Now.ToShortTimeString() + "' where hid ='" + hid + "' and uid = '" + uid + "'", con);
        cmd1.ExecuteNonQuery();

        String iname = hid.ToString() + uid.ToString() + device1.ToString() + image;

        SqlCommand cmd = null;
        cmd = new SqlCommand("update workerdetail set locfinalimage = '" + iname + "' where hid='" + hid + "' and  locfinalimage ='temp' and uid = '" + uid + "'", con);
        int i = cmd.ExecuteNonQuery();


        SqlCommand cmd2 = null;
        cmd2 = new SqlCommand("update status set status = 'admin_varify',date='" + DateTime.Now.ToShortDateString() + "',time='" + DateTime.Now.ToShortTimeString() + "' where hid='" + hid + "'", con);
        int i2 = cmd2.ExecuteNonQuery();


        System.IO.File.Move(@"C:\inetpub\wwwroot\WebSite5\Uploads\" + image, @"C:\inetpub\wwwroot\WebSite5\Uploads\" + iname);

        if (i == 1 && i2 == 1)
        {
            con.Close();
            return "true";
        }
        else
        {
            con.Close();
            return "false";
        }

    }
    /*   [WebMethod]
       public string count(string h)
       {
           con.Open();
           SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM register where usertype='"+h+"'", con);
           Int32 coun = (Int32)comm.ExecuteScalar();
           return coun.ToString();
       }*/

    //================================================================================================================
    [WebMethod]
    public string suggestion(string occupation)
    {
        con.Open();
        string sugarea="";
        SqlDataAdapter sda = new SqlDataAdapter("select  hoarding.uid from hoarding,register where register.occupation='"+occupation+"' and register.uid=hoarding.uid group by hoarding.uid order by count(*) desc", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SqlDataAdapter sda1 = new SqlDataAdapter("select area from hoarding where uid='"+dt.Rows[i][0]+"' " , con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    sugarea += dt1.Rows[j][0].ToString() + "#";      
                }
                
            }

        }
        else
        {
            return "false";
        }
        sugarea = sugarea.Trim('#');       
        return sugarea;
    }
}