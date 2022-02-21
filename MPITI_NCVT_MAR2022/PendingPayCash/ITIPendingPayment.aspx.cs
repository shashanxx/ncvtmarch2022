using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Class;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Principle_ITIPendingPayment : System.Web.UI.Page
{
    CommonPerception Mysql = new CommonPerception();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
            Response.Redirect("../Login/LoginNew.aspx");
        else
        {
            DataTable dt = new DataTable();
            dt = Mysql.GetDataTableWithQuery("select distinct ITICode+'-'+ITIName itiname,TTIType from tbl_Student where ITICode='" + Session["Username"].ToString() + "'");
            if (dt != null && dt.Rows.Count > 0)
                lblUName.Text = "Welcome " + Convert.ToString(dt.Rows[0]["itiname"]);
            else
                lblUName.Text = "Welcome " + Session["Username"].ToString();

            btnPayDD.Visible = false;
            if (Convert.ToString(dt.Rows[0]["TTIType"]).ToLower().Trim() == "govt")
            {
                btnPayDD.Visible = true;
            }

            string ITICode = Convert.ToString(Session["Username"]);
            DataSet dsAmount = Mysql.GetDataSet("Select Finalstatus from tbl_ITIPendingAmounts where DGT_InstCode = '" + ITICode + "' and  Active = 1");
            if (dsAmount != null && dsAmount.Tables.Count > 0 && dsAmount.Tables[0].Rows.Count > 0)
            {
                lblFinalAmount.Text = Convert.ToString(dsAmount.Tables[0].Rows[0]["Finalstatus"]);
            }

        }
    }

    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Mysql.UpdateSingleLogin(Session["Username"].ToString(), Convert.ToInt32(Session["UserType"].ToString()), 0);
        Session.Abandon();
        Session.Clear();
        Response.Redirect("../Login/LogOut.aspx");
    }
    protected void btnPayOnline_Click(object sender, EventArgs e)
    {
        Response.Redirect("../PendingPayCash/PayOnline.aspx");
    }
    protected void btnDetails_Click(object sender, EventArgs e)
    {
        //Context.Response.Write("<script language='javascript'>window.open('candidateDetails.aspx?iticode=" + Session["Username"] + "','_newtab');</script>");
        Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('candidateDetails.aspx?iticode=" + Session["Username"] + "','_newtab');", true);
    }
    protected void btnPayDD_Click(object sender, EventArgs e)
    {
        Generate_Order_Details();
        Response.Redirect("../PendingPayCash/DDDetails.aspx");
    }

    public void Generate_Order_Details()
    {
        SqlConnection dbcon = new SqlConnection();
        dbcon = new SqlConnection(CommonPerception.ConnectionString());
        SqlCommand cmdInsert = new SqlCommand();
        cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ITICode", System.Data.SqlDbType.VarChar, 30, "RegistrationId"));
        cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Amount", System.Data.SqlDbType.Decimal, 9, "Amount"));
        cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 100, "RegistrationId"));
        cmdInsert.Parameters["@ITICode"].Value = Session["Username"].ToString();
        cmdInsert.Parameters["@Amount"].Value = lblFinalAmount.Text.ToString();
        cmdInsert.Parameters["@Mode"].Value = "Offline Pending Payment";
        SqlParameter dbparam;
        dbparam = cmdInsert.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4));
        dbparam.Direction = ParameterDirection.Output;
        cmdInsert.CommandText = "[SP_Insert_OrderDetails_Pending]";
        cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
        cmdInsert.Connection = dbcon;

        try
        {
            dbcon.Open();
            cmdInsert.ExecuteNonQuery();
            int PID = (int)cmdInsert.Parameters["@ID"].Value;
            Session["PID"] = PID;
            Session["Amount"] = lblFinalAmount.Text.ToString();
        }
        catch (Exception err)
        {
            Response.Write("Error while Inserting Next Set Of Records<br> Error source : " + err.Message + "<br>" + err.Source);
        }
        finally
        {
            if (dbcon.State == ConnectionState.Open)
            {
                dbcon.Close();
            }
        }
    }
}