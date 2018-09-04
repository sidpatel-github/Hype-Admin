using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;


public partial class fileupload : System.Web.UI.Page
{
    protected HtmlInputFile filMyFile;
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpPostedFile file = Request.Files["uploadedfile"];

        //check file was submitted
        if (file != null && file.ContentLength > 0)
        {
            string fname = Path.GetFileName(file.FileName);
            file.SaveAs(Server.MapPath("~/Uploads/" + fname));
            Response.Write("Uploaded !!");
        }
    }
}