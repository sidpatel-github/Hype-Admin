using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class area : System.Web.UI.Page
{
    int flag = 1,flag1=1;
    int a;
    static string fname;
    static bool isValidFile = false;
    static string dbimage;
    static string extension;
    String random;
    Class1 c1 = new Class1();
    private void setgrid()
    {
        DataTable dt = c1.select("select aid , aname as area , cid,sid,bid,image ,latitude ,longitude,size,price from area");
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
        random = deviceno(4);
        if (Session["name"] == null)
        {
            Response.Redirect("login.aspx");
        }

        if (!IsPostBack)
        {
            
            Label5.Text = "WELCOME : ADMIN " + Session["name"].ToString();
            setstate();
            setbanner();
            setcity();
            setgrid();

        }
    }

    private void setstate()
    {
        DataTable dt = c1.select("select * from state");
        DropDownList1.DataSource = dt;
        DropDownList1.DataTextField = "sname";
        DropDownList1.DataValueField = "sid";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("please select state", "-1"));
    }

    private void setcity()
    {
        a = int.Parse(DropDownList1.SelectedValue);
        DataTable dt = c1.select("select * from city where sid='" + a + "'");
        DropDownList2.DataSource = dt;
        DropDownList2.DataTextField = "cname";
        DropDownList2.DataValueField = "cid";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("please select city", "-1"));
    }

    private void setbanner()
    {
        DataTable dt = c1.select("select * from banner");
        DropDownList3.DataSource = dt;
        DropDownList3.DataTextField = "btype";
        DropDownList3.DataValueField = "bid";
        DropDownList3.DataBind();
        DropDownList3.Items.Insert(0, new ListItem("please select banner type", "-1"));
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
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        DropDownList1.ClearSelection();
        DropDownList2.ClearSelection();
        DropDownList3.ClearSelection();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        setcity();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string imagename;
        Label4.Text = "";   
        filevalidate();

        if (HiddenField1.Value.Equals("insert") && !TextBox1.Text.Equals("") && !DropDownList1.SelectedItem.Value.ToString().Equals(""))
        {
            
            
            DataTable dt = c1.select("select latitude from area where latitude = '" + TextBox3.Text.ToString() + "' ");
            foreach (DataRow row in dt.Rows)//sid= '" + DropDownList1.SelectedValue.ToString() + "' and cid = '" + DropDownList2.SelectedValue.ToString() + "' and 
            {
                foreach (string item in row.ItemArray)
                {
                    if (TextBox3.Text.ToLower().Equals(item.ToLower()))
                    {
                        flag = 0;
                        break;
                    }
                    Response.Write(item.ToString());
                }
                
            }
            
            
            DataTable dt1 = c1.select("select longitude from area where longitude = '" + TextBox2.Text.ToString() + "'");
            foreach (DataRow row in dt.Rows)//sid= '" + DropDownList1.SelectedValue.ToString() + "' and cid = '" + DropDownList2.SelectedValue.ToString() + "' and 
            {
                foreach (string item in row.ItemArray)
                {
                    if (TextBox2.Text.ToLower().Equals(item.ToLower()))
                    {
                        flag1 = 0;
                        break;
                    }
                }
            }
 
            

            if (flag == 1 && flag1 == 1) 
            {
                c1.query("insert into area(aname,cid,sid,bid,image,latitude,longitude,size,price) values('" + TextBox1.Text + "','" + DropDownList2.SelectedItem.Value + "','" + DropDownList1.SelectedItem.Value + "','" + DropDownList3.SelectedItem.Value + "','temp','" + TextBox3.Text + "','" + TextBox2.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "')");
                setgrid();
                GridViewRow r = GridView1.Rows[GridView1.Rows.Count - 1];
                TableCell tc = r.Cells[2];
                imagename = tc.Text;
                fname = imagename + extension;
                Response.Write(imagename);
                c1.query("update area set image='" + fname + "' where aid='" + Int32.Parse(imagename) + "'");
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fname);
                Response.Write("<script language=javascript>alert('SUCESSFULLY RECORDED');" + "<" + "/" + "script>");
//                Response.Write("successfully inserted !!");
                setgrid();
                clearsection();
            }

            else
            {
                Response.Write("<script language=javascript>alert('LONGITUDE LATITUDE PRESENT IN DATABASE');" + "<" + "/" + "script>");
//                Response.Write("long lat  already entered");
                clearsection();
            }

        }
             
        else// if (HiddenField2.Value.Equals("update") && isValidFile.Equals(true))
        {

            if (FileUpload1.HasFile.Equals(false))
            {
                isValidFile = true;
                c1.query("update area set aname='" + TextBox1.Text + "' , cid = '" + DropDownList2.SelectedValue + "' , sid = '" + DropDownList1.SelectedValue + "' ,bid = '" + DropDownList3.SelectedValue + "',latitude= '" + TextBox3.Text + "' ,longitude='" + TextBox2.Text + "',size='" + TextBox4.Text + "', price='" + TextBox5.Text + "' where aid='" + HiddenField2.Value + "'");
                clearsection();
                Response.Write("<script language=javascript>alert('SUCESSFULLY UPDATED');" + "<" + "/" + "script>");
//                Response.Write("successfully updated !!");
            }
            else
            {

                filevalidate();

                if (isValidFile.Equals(true))
                {
                    fname = HiddenField2.Value + extension;
                    c1.query("update area set aname='" + TextBox1.Text + "' , cid = '" + DropDownList2.SelectedValue + "' , sid = '" + DropDownList1.SelectedValue + "' ,bid = '" + DropDownList3.SelectedValue + "' ,image='" + fname + "',latitude= '" + TextBox3.Text + "' ,longitude='" + TextBox2.Text + "',size='" + TextBox4.Text + "', price='"+TextBox5.Text+"' where aid='" + HiddenField2.Value + "'");
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fname);
                    Response.Write("<script language=javascript>alert('SUCESSFULLY UPDATED');" + "<" + "/" + "script>");
//                    Response.Write("successfully updated !!");
                }
            }
            setgrid();
        }
        //else
        //{
        //    filevalidate();
        //}


        if (isValidFile.Equals(true))
        {
            clearsection();
            HiddenField1.Value = "insert";
        }
    }


    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

        HiddenField1.Value = "update";
        RequiredFieldValidator7.Enabled = false;
        HiddenField2.Value = GridView1.Rows[e.NewSelectedIndex].Cells[2].Text;
        dbimage = GridView1.Rows[e.NewSelectedIndex].Cells[7].Text;
        TextBox1.Text = GridView1.Rows[e.NewSelectedIndex].Cells[3].Text;
        TextBox3.Text = GridView1.Rows[e.NewSelectedIndex].Cells[8].Text;
        TextBox2.Text = GridView1.Rows[e.NewSelectedIndex].Cells[9].Text;
        TextBox4.Text = GridView1.Rows[e.NewSelectedIndex].Cells[10].Text;
        TextBox5.Text = GridView1.Rows[e.NewSelectedIndex].Cells[11].Text;

        for (int i = 0; i < DropDownList1.Items.Count; i++)
        {
            if (DropDownList1.Items[i].Value.Equals(GridView1.Rows[e.NewSelectedIndex].Cells[5].Text))
            {
                DropDownList1.SelectedIndex = i;
            }
        }
        setcity();
        for (int i = 0; i < DropDownList2.Items.Count; i++)
        {
            if (DropDownList2.Items[i].Value.Equals(GridView1.Rows[e.NewSelectedIndex].Cells[4].Text))
            {
                DropDownList2.SelectedIndex = i;
            }
        }
        for (int i = 0; i < DropDownList3.Items.Count; i++)
        {
            if (DropDownList3.Items[i].Value.Equals(GridView1.Rows[e.NewSelectedIndex].Cells[6].Text))
            {
                DropDownList3.SelectedIndex = i;
            }
        }

    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string delfilename = GridView1.Rows[e.RowIndex].Cells[7].Text;
        string delpath = Server.MapPath("Uploads//" + delfilename);
        FileInfo del = new FileInfo(delpath);
        if (del.Exists)
        {
            del.Delete();
            c1.query("delete from area where aid ='" + GridView1.Rows[e.RowIndex].Cells[2].Text + "'");
            setgrid();
        }
        else
        {
            Response.Write("<script language=javascript>alert('IMAGE NOT FOUND');" + "<" + "/" + "script>");
//            Response.Write("image not found");
        }

    }


    protected void Button2_Click(object sender, EventArgs e)
    {
       
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        DropDownList1.SelectedIndex = 0;
        DropDownList2.SelectedIndex = 0;
        DropDownList3.SelectedIndex = 0;
        HiddenField1.Value = "insert";
    }
}/*SqlConnection con1 = new SqlConnection("Data Source=SHUBHAM-PC\\MSSQLSER2008;Initial Catalog=hype;Persist Security Info=True;User ID=sa;Password=shubham");
             con1.Open();

             SqlDataAdapter sda1 = new SqlDataAdapter("select username,email from register where usertype='worker' and username='" + TextBox2.Text.ToString() + "' and email='" + TextBox7.Text.ToString() + "' ", con1);
             DataTable dt1 = new DataTable();
             sda1.Fill(dt1);

             for (int i = 0; i < dt1.Rows.Count; i++)
             {
                 if (dt1.Rows[i][0].ToString().ToLower().Equals(TextBox2.Text.ToString().ToLower()) ||  dt1.Rows[i][1].ToString().ToLower().Equals(TextBox7.Text.ToString().ToLower()))
                 {
                     Response.Write(dt1.Rows[i][0].ToString().ToLower());
                     Response.Write(dt1.Rows[i][1].ToString().ToLower());
                  
                         flag = 0;
                         break;
                     
                 }
             }*/