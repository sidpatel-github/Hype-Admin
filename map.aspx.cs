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

public partial class map : System.Web.UI.Page
{
    Double a1,rate; int a, b;
    Class1 c1 = new Class1();
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
            setstate();
            setcity();
            setarea();

        }
    }

    private void setstate()
    {

        DataTable dt = c1.select("select * from state");
        DropDownList1.DataSource = dt;
        DropDownList1.DataTextField = "sname";
        DropDownList1.DataValueField = "sid";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("all", "-1"));


    }

    private void setcity()
    {
        a = int.Parse(DropDownList1.SelectedValue);
        DataTable dt = c1.select("select * from city where sid = '" + a + "'");
        DropDownList2.DataSource = dt;
        DropDownList2.DataTextField = "cname";
        DropDownList2.DataValueField = "cid";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("all", "-1"));

    }


    private void setarea()
    {
        b = int.Parse(DropDownList2.SelectedValue);
        DataTable dt = c1.select("select * from area where cid='" + b + "'");
        DropDownList3.DataSource = dt;
        DropDownList3.DataTextField = "aname";
        DropDownList3.DataValueField = "aid";
        DropDownList3.DataBind();
        DropDownList3.Items.Insert(0, new ListItem("all", "-1"));
    }

    //select title=area.aname,lat=area.latitude,lng=area.longitude,desc1=area.aname,area.aid,feedback.fid,state.sid,city.cid from area,feedback,state,city where state.sid=1 and city.cid=21 and area.aid=1 and feedback.aid = area.aid ;
    public string ConvertDataTabletoString()
    {
        // String qr = "select title=area.aname,lat=area.latitude,lng=area.longitude,desc1=area.aname,area.aid,feedback.aid from area,feedback";
        String qr = "select title=area.aname,lat=area.latitude,lng=area.longitude,desc1=area.aname,area.aid,feedback.fid,state.sid,city.cid from area,feedback,state,city ";

        if (DropDownList1.SelectedIndex != 0)
        {
            qr += "where state.sid = city.sid and state.sid='" + DropDownList1.SelectedIndex + "'";
        }

        if (DropDownList1.SelectedIndex == 0)
        {
            setcity();
            setarea();
        }

        if (DropDownList2.SelectedIndex != 0)
        {
            qr += "and city.cid = area.cid and city.cid='" + DropDownList2.SelectedIndex + "'";
        }

        if (DropDownList3.SelectedIndex != 0)
        {
            qr += "  and feedback.aid = area.aid and area.aid='" + DropDownList3.SelectedIndex + "'";
            DropDownList4.Enabled = false;
        }

        if (DropDownList4.SelectedIndex != 0)
        {
            rate = DropDownList4.SelectedIndex;
            DropDownList3.Enabled = false;
        }


        String a = Request.QueryString["area"];
        DataTable dt = new DataTable();
        using (  SqlConnection con = new SqlConnection(Class1.datasource))
        {
            using (SqlCommand cmd = new SqlCommand(qr, con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row;
                int i = 0;
                if (dt.Rows.Count == 0)
                {
                    Response.Write("hello");
                }
                foreach (DataRow dr in dt.Rows)
                {

                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "select ISNULL(SUM(CAST(rating AS FLOAT)) / COUNT(*) ,0 ) FROM feedback where aid = '" + dr[4].ToString() + "'";
                    cmd1.Connection = con;

                    cmd.CommandText = "select btype from banner,area where area.aid='" + dr[4].ToString() + "' and area.bid=banner.bid";
                    string amt = (string)cmd.ExecuteScalar();



                    SqlDataReader reader = cmd1.ExecuteReader();
                    if (reader.Read())
                    {
                        a1 = reader.GetDouble(0);

                        dr[0] = dr[0];
                        dr[3] = "feedback : " + a1.ToString() + "<br/>" + " area : " + dr[0] + "<br/>" + "banner : " + amt;
                    }
                    else
                    {
                      //  Response.Write("<script language=javascript>alert('INVALID USERNAME OR PASSWORD');" + "<" + "/" + "script>");

                    }
                    reader.Close();
                    row = new Dictionary<string, object>();
                    double km = GeoCodeCalc.CalcDistance(21.17695, 72.84195, Convert.ToDouble(dt.Rows[i][1].ToString()), Convert.ToDouble(dt.Rows[i][2].ToString()), GeoCodeCalcMeasurement.Kilometers);
                    if (km < 10)
                    {
                        if (a1 >= rate)
                        {
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                    }
                    i++;
                }
                serializer.MaxJsonLength = 50000000;

                return serializer.Serialize(rows);
            }
        }
    }

    public static class GeoCodeCalc
    {
        public const double EarthRadiusInMiles = 3956.0;
        public const double EarthRadiusInKilometers = 6367.0;

        public static double ToRadian(double val) { return val * (Math.PI / 180); }
        public static double DiffRadian(double val1, double val2) { return ToRadian(val2) - ToRadian(val1); }

        public static double CalcDistance(double lat1, double lng1, double lat2, double lng2)
        {
            return CalcDistance(lat1, lng1, lat2, lng2, GeoCodeCalcMeasurement.Miles);
        }

        public static double CalcDistance(double lat1, double lng1, double lat2, double lng2, GeoCodeCalcMeasurement m)
        {
            double radius = GeoCodeCalc.EarthRadiusInMiles;

            if (m == GeoCodeCalcMeasurement.Kilometers) { radius = GeoCodeCalc.EarthRadiusInKilometers; }
            return radius * 2 * Math.Asin(Math.Min(1, Math.Sqrt((Math.Pow(Math.Sin((DiffRadian(lat1, lat2)) / 2.0), 2.0) + Math.Cos(ToRadian(lat1)) * Math.Cos(ToRadian(lat2)) * Math.Pow(Math.Sin((DiffRadian(lng1, lng2)) / 2.0), 2.0)))));
        }
    }

    public enum GeoCodeCalcMeasurement : int
    {
        Miles = 0,
        Kilometers = 1
    }




    protected void initialize_click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "none", "<script>initialize();</script>", false);
    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    { setcity(); }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    { setarea(); }
    
}