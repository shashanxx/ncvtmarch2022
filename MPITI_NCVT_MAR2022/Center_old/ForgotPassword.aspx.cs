using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Class;
using System.Data;
using System.Data.SqlClient;

public partial class Center_ForgotPassword : System.Web.UI.Page
{
    CommonPerception MySql = new CommonPerception();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblpasslbl.Visible = false;
            bindPassRecoveryQue();
        }

    }
    protected void btnlogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }


    protected void btnshowpass_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = MySql.GetDataSetWithQuery("Exec GetPassword @LoginId='" + txtloginid.Text.ToString() + "', @PassRecQueId=" + ddlpassque.SelectedValue + ", @PassRecAns='"+txtans.Text.ToString()+"'");

        if(ds.Tables[0].Rows.Count>0)
        {
            lblpasslbl.Visible = true;
            lblpass.Text = ds.Tables[0].Rows[0]["Password"].ToString();
        }
        else
        {
            lblpasslbl.Visible = false;
            lblpass.Text = "";
            lblError.Text = "Invalid details";
        }
    }
    protected void bindPassRecoveryQue()
    {
        ddlpassque.Items.Clear();
        DataSet Ds = new DataSet();
        Ds = MySql.GetDataSetWithQuery("Exec getPassRecoveryQue");
        if (Ds.Tables[0].Rows.Count > 0)
        {
            ddlpassque.DataSource = Ds;
            ddlpassque.DataTextField = "PasswordQue";
            ddlpassque.DataValueField = "Id";
            ddlpassque.DataBind();
            ddlpassque.Items.Insert(0, new ListItem("Select Question", "0"));
        }
    }
}