using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;


public partial class banner : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(Class1.datasource);
    int a;
    static string fname;
    static bool isValidFile = false;
    static string dbimage;
    static bool isvalidtxt = false;
    static string extension;
    String ran;
    Class1 c1 = new Class1();
    int flag = 1;

    private void setgrid()
    {
        DataTable dt = c1.select("select bid,btype as 'banner type',image from banner");
        GridView1.DataSource = dt;
        GridView1.DataBind();
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
    protected void Page_Load(object sender, EventArgs e)
    {
        ran = deviceno(4);
        if (Session["name"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            Label1.Text = "WELCOME : ADMIN " + Session["name"].ToString();
            setgrid();

        }
    }

    void btypeValid()
    {

        con.Open();

        SqlDataAdapter sda2 = new SqlDataAdapter("select btype from banner", con);
        DataTable dt1 = new DataTable();
        sda2.Fill(dt1);

        RequiredFieldValidator4.Enabled = true;

        string[] validtype = { "hoarding", "kiosh", "fob", "gantry", "Bus Queue Shelters", "Bus Branding", "Mobile Vans", "LED Screen" };

        for (int i = 0; i < dt1.Rows.Count; i++)
        {

            if (TextBox4.Text.ToString().Equals(dt1.Rows[i][0].ToString()))
            {
                isvalidtxt = false;
            }

            else
            {
                isvalidtxt = true;

            }
        } con.Close();
    }

    void filevalidate()
    {
        RequiredFieldValidator7.Enabled = true;
        isValidFile = false;
        string[] validFileTypes = { ".bmp", ".gif", ".png", ".jpg", ".jpeg" };

        // fname = FileUpload1.FileName;

        extension = Path.GetExtension(FileUpload1.PostedFile.FileName.ToLower());

        if (FileUpload1.HasFile)
        {
            for (int i = 0; i < validFileTypes.Length; i++)
            {
                if (extension.Equals(validFileTypes[i]))
                {
                    isValidFile = true;
                    break;
                }
            }

            if (isValidFile.Equals(false))
            {
                Label4.ForeColor = System.Drawing.Color.Red;
                Label4.Text = "Invalid File. Please upload a File with extension " + string.Join(",", validFileTypes);
            }
            else
            {
                Label4.Text = "";
                //  FileUpload1.PostedFile.SaveAs(Server.MapPath("~/image/") + fname);
            }
        }
    }

    void clearsection()
    {
        TextBox4.Text = "";

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        string imagename;
        Label4.Text = "";
        btypeValid();
        filevalidate();

        if (HiddenField1.Value.Equals("insert") && isValidFile.Equals(true) && isvalidtxt.Equals(true))
        {

            DataTable dt = c1.select("select btype from banner");
            foreach (DataRow row in dt.Rows)
            {
                foreach (string item in row.ItemArray)
                {
                    if (TextBox4.Text.ToLower().Equals(item.ToLower()))
                    {
                        flag = 0;
                        break;
                    }
                }
            }
            if (flag == 1)
            {
                c1.query("insert into banner(btype,image) values('" + TextBox4.Text + "','temp')");
                setgrid();
                // Response.Write("successfully inserted !!");

                GridViewRow r = GridView1.Rows[GridView1.Rows.Count - 1];
                TableCell tc = r.Cells[2];
                imagename = tc.Text;
                fname = imagename + extension;
              //  Response.Write(imagename);
                c1.query("update banner set image='" + fname + "' where bid='" + Int32.Parse(imagename) + "'");
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fname);
                Response.Write("<script language=javascript>alert('SUCESSFULLY RECORDED');" + "<" + "/" + "script>");
//                Response.Write("successfully inserted !!");
                Response.Redirect("~/banner.aspx");
                setgrid();
            }
            else
            {
                Response.Write("<script language=javascript>alert('banner already entered');" + "<" + "/" + "script>");
          //      Response.Write("banner already entered");
              //  Response.Redirect("~/banner.aspx");
            }
        }

        else// if (HiddenField2.Value.Equals("update") && isValidFile.Equals(true))
        {

            if (FileUpload1.HasFile.Equals(false))
            {
                isValidFile = true;
                c1.query("update banner set btype='" + TextBox4.Text + "' where bid='" + HiddenField2.Value + "'");
                clearsection();
                Response.Write("<script language=javascript>alert('SUCESSFULLY UPDATED');" + "<" + "/" + "script>");
//                Response.Write("successfully updated !!");Response.Redirect("~/banner.aspx");
                Response.Redirect("~/banner.aspx");
            }
            else
            {


                filevalidate();


                if (isValidFile.Equals(true))
                {
                    fname = HiddenField2.Value + extension;
                    c1.query("update banner set btype='" + TextBox4.Text + "' where bid='" + HiddenField2.Value + "'");
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fname);
                    Response.Write("<script language=javascript>alert('SUCESSFULLY UPDATED');" + "<" + "/" + "script>");
                    //Response.Write("successfully updated !!");
                    Response.Redirect("~/banner.aspx");
                }
            }
            setgrid();
        }

    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

        HiddenField1.Value = "update";
        RequiredFieldValidator7.Enabled = false;
        HiddenField2.Value = GridView1.Rows[e.NewSelectedIndex].Cells[2].Text;
        dbimage = GridView1.Rows[e.NewSelectedIndex].Cells[4].Text;
        TextBox4.Text = GridView1.Rows[e.NewSelectedIndex].Cells[3].Text;
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string delfilename = GridView1.Rows[e.RowIndex].Cells[4].Text;
        string delpath = Server.MapPath("Uploads//" + delfilename);
        FileInfo del = new FileInfo(delpath);
        if (del.Exists)
        {
            del.Delete();
            c1.query("delete from banner where bid ='" + GridView1.Rows[e.RowIndex].Cells[2].Text + "'");
            Response.Write("<script language=javascript>alert('SUCESSFULLY DELETED');" + "<" + "/" + "script>");
            setgrid();
            Response.Redirect("~/banner.aspx");
        }
        else
        {
            Response.Write("<script language=javascript>alert('IMAGE NOT FOUND');" + "<" + "/" + "script>");
            //Response.Write("image not found"); 
            setgrid();
            Response.Redirect("~/banner.aspx");
        }


    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox4.Text = "";
        HiddenField1.Value = "insert";
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
