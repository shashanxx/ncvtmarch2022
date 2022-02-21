using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnStudLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Student/StudentEntry.aspx");
    }


    //protected void btnprLogin_Click(object sender, EventArgs e)
    //{
    //    Session["Username"] = txtpusername.Value;
    //    Response.Redirect("../Principle/PrVerification.aspx");
    //}

    protected void btnprLogin_Click(object sender, EventArgs e)
    {
        if (txtpusername.Value == "ITI123456" && txtppassword.Value == "123456")
        {
            Session["Username"] = txtpusername.Value;
            Response.Redirect("../Dashboard.aspx");
        }
        else
        { 
        
        }
    }
}