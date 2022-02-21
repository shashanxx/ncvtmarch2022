using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Class;
using System.Data;
using System.Data.SqlClient;

public partial class Center_ChangePassword : System.Web.UI.Page
{
    CommonPerception MySql = new CommonPerception();
    string loginid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        loginid = Session["CenterITICode"].ToString();



        if (Session["CenterITICode"].ToString() != "" || Session["CenterITICode"].ToString() == null)
        {
            loginid = Session["CenterITICode"].ToString();
            
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
        if(!IsPostBack)
        {
            bindPassRecoveryQue();
        }


    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = MySql.GetDataSetWithQuery("select * from LoginMaster where LoginId='" + loginid + "' and Password='" + txtoldpass.Text.ToString() + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {


            string qry = "sp_changePassword @LoginId='" + loginid + "' , @Password='" + txtnewPassword.Text.ToString() + "', @PassRecQueId='" + ddlpassque.SelectedValue + "', @PassRecAns='" + txtans.Text.ToString() + "'";
            bool result = MySql.ExecuteNonQuery(qry);
            if (result == true)
            {
                lblError.Text = "Password change successfully";
            }
            else
            {
                lblError.Text = "Not updated.";
            }
        }
        else
        {
            lblError.Text = "Old password does not match.";
        }


    }
    protected void btnlogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Login.aspx");
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