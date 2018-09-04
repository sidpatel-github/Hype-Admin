using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{    public static String datasource="Data Source=HP-PC\\SQL2008;Initial Catalog=hype;User ID=sa;Password=12345"; 
    SqlConnection cn = new SqlConnection(datasource);
	public Class1()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int query(String qr)
    {
        cn.Open();
        SqlCommand cmd = new SqlCommand(qr, cn);
        int num = cmd.ExecuteNonQuery();
        cn.Close();
        return num;
    }

    public DataTable select(String qr)
    {
        SqlDataAdapter sda = new SqlDataAdapter(qr, cn);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        return dt;
    }

}