using CCA.Util;
using Common.Class;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Principle_Print : System.Web.UI.Page
{
    CommonPerception Mysql = new CommonPerception();
    DataTable dtgrid;
    string strResponse = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Redirect("../Dashboard.aspx", false);
        try
        {
            if (Session["Username"] == null)
                Response.Redirect("../Login/LoginNew.aspx");
            else
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["pid"] != null && Request.QueryString["itiCode"] != null)
                    {

                        string PID = Convert.ToString(Request.QueryString["pid"]);
                        lblPID.Text = "PID: " + PID;
                        string ITICode = Convert.ToString(Request.QueryString["itiCode"]);

                        DataTable dt = new DataTable();
                        dt = Mysql.GetDataTableWithQuery("select distinct ITICode+'-'+ITIName itiname from tbl_Student where ITICode='" + ITICode + "'");
                        if (dt != null && dt.Rows.Count > 0)
                            lblUName.Text = "Welcome " + Convert.ToString(dt.Rows[0]["itiname"]);
                        else
                            lblUName.Text = "Welcome " + Session["Username"].ToString();

                        BindPaymentSummary(Convert.ToInt32(PID), ITICode);
                    }
                    else
                        Response.Redirect("../Dashboard.aspx");
                }                
            }            
        }
        catch (Exception ex)
        {
            CommonUtilities.LogError(ex);
        }
    }
    private void BindPaymentSummary(int PID, string ITICode)
    {
        dtgrid = new DataTable();
        dtgrid = Mysql.GetDataTableWithQuery("exec GetPaymentDetails @PID=" + PID + ",@ITICode='" + ITICode + "'");
        if (dtgrid != null && dtgrid.Rows.Count > 0)
        {
            if (dtgrid.Rows[0]["Paper1Status"].ToString().ToLower().Contains("yes|"))
                GridView1.Columns[9].HeaderText = dtgrid.Rows[0]["Paper1Status"].ToString().Split('|')[1];

            if (dtgrid.Rows[0]["Paper2Status"].ToString().ToLower().Contains("yes|"))
                GridView1.Columns[10].HeaderText = dtgrid.Rows[0]["Paper2Status"].ToString().Split('|')[1];
            GridView1.DataSource = dtgrid;
            GridView1.DataBind();
            lbltotalstucount.Text = dtgrid.Rows.Count.ToString();
            lbltotalstuPayment.Text = dtgrid.Rows[0]["TotalAmount"].ToString();
            lblItiCode.Text = dtgrid.Rows[0]["ITICode"].ToString();
            lblItiName.Text = dtgrid.Rows[0]["ITIName"].ToString();

            lblPName.Text = dtgrid.Rows[0]["PrinicipalName"].ToString();
            lblPMobileNo.Text = dtgrid.Rows[0]["PrincipalMobileNo"].ToString();
            divtotal.Visible = true;
            divPrincipalInfo.Visible = true;

            if (dtgrid.Rows[0]["Paper1Status"].ToString().ToLower().Contains("no|"))
                GridView1.Columns[9].Visible = false;
            if (dtgrid.Rows[0]["Paper2Status"].ToString().ToLower().Contains("no|"))
                GridView1.Columns[10].Visible = false;
            if (dtgrid.Rows[0]["PracticalStatus"].ToString().ToLower().Contains("no|"))
                GridView1.Columns[11].Visible = false; 
        }
    }
    
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Label lblPaymentStatus = (Label)e.Row.FindControl("lblPaymentStatus");
            //HiddenField hdnPayMode = (HiddenField)e.Row.FindControl("hdnPayMode");
            //HiddenField hdnTID = (HiddenField)e.Row.FindControl("hdnTID");
            //if(lblPaymentStatus.Text=="Successful")
            //    lblPaymentStatus.ForeColor = System.Drawing.Color.Green;
            //else
            //    lblPaymentStatus.ForeColor = System.Drawing.Color.Red;

            //if (hdnPayMode.Value.ToLower() == "payment through dd")
            //    lblPaymentStatus.Text = hdnPayMode.Value + " - " + hdnTID.Value;
        }
    }
}