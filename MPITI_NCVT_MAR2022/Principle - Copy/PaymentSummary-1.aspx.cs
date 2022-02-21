using Common.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Principle_PaymentSummary : System.Web.UI.Page
{
    CommonPerception Mysql = new CommonPerception();
    DataTable dtgrid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
            Response.Redirect("../Login/LoginNew.aspx");
        else
            lblUName.Text = "Welcome " + Session["Username"].ToString();
        if (Session["PID"]==null)
            Response.Redirect("../Dashboard.aspx");

        BindPaymentSummary();
    }
    private void BindPaymentSummary()
    {
        int PID = Convert.ToInt32(Session["PID"].ToString());
        if (PID > 0)
        {
            dtgrid = new DataTable();
            dtgrid = Mysql.GetDataTableWithQuery("exec GetPaymentSummary @PID=" + PID + ",@ITICode='" + Session["Username"].ToString() + "'");
            if (dtgrid != null && dtgrid.Rows.Count > 0)
            {
                if (dtgrid.Rows[0]["Paper1Status"].ToString().ToLower().Contains("yes|"))
                    GridView1.Columns[5].HeaderText = dtgrid.Rows[0]["Paper1Status"].ToString().Split('|')[1];

                if (dtgrid.Rows[0]["Paper2Status"].ToString().ToLower().Contains("yes|"))
                    GridView1.Columns[6].HeaderText = dtgrid.Rows[0]["Paper2Status"].ToString().Split('|')[1];

                if (dtgrid.Rows[0]["Paper3Status"].ToString().ToLower().Contains("yes|"))
                    GridView1.Columns[7].HeaderText = dtgrid.Rows[0]["Paper3Status"].ToString().Split('|')[1];

                GridView1.DataSource = dtgrid;
                GridView1.DataBind();
                lbltotalstucount.Text = dtgrid.Rows.Count.ToString();
                lbltotalstuPayment.Text = dtgrid.Rows[0]["TotalAmount"].ToString();
                divtotal.Visible = true;
                divDisclaimer.Visible = true;

                if (dtgrid.Rows[0]["Paper1Status"].ToString().ToLower().Contains("no|"))
                    GridView1.Columns[5].Visible = false; 
                if (dtgrid.Rows[0]["Paper2Status"].ToString().ToLower().Contains("no|"))
                    GridView1.Columns[6].Visible = false;
                if (dtgrid.Rows[0]["Paper3Status"].ToString().ToLower().Contains("no|"))
                    GridView1.Columns[7].Visible = false;
                if (dtgrid.Rows[0]["PracticalStatus"].ToString().ToLower().Contains("no|"))
                    GridView1.Columns[8].Visible = false; 

                if (Convert.ToDecimal(lbltotalstuPayment.Text) > 0)
                {
                    btnProceed.Visible = true;
                    btnExit.Visible = true;
                    btnFinalVerify.Visible = false;
                    Session["Amount"] = dtgrid.Rows[0]["TotalAmount"].ToString();
                    if (dtgrid.Rows[0]["TTIType"].ToString().ToLower() == "govt")
                        btnProceedDD.Visible = true;
                    else
                        btnProceedDD.Visible = false;
                }
                else
                {
                    btnProceedDD.Visible = false;
                    btnProceed.Visible = false;
                    btnExit.Visible = true;
                    //btnFinalVerify.Visible = true;
                }
            }
        }
    }
    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Response.Redirect("../Login/LogOut.aspx");
    }
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        if (isvalidate())
        {
            Session["PaymentMode"] = "Online";
            UpdatePrincipalDetails();
            Response.Redirect("../PayCash/PayOnline.aspx");
        }
    }
    protected void btnFinalVerify_Click(object sender, EventArgs e)
    {
        if (isvalidate())
        {
            UpdatePrincipalDetails();
            Mysql.ExecuteNonQuery("exec UpdatePaymentStatus " + Convert.ToInt32(Session["PID"].ToString()) + ",'','Yes','Offline','',''");
            Session["PID"] = null;
            Session["Amount"] = null;
            Session["PaymentMode"] = null;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Verified Successfully'); window.location='" + Request.ApplicationPath + "Principle/PrVerificationNew.aspx';", true);
        }
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Dashboard.aspx");
    }
    protected void btnProceedDD_Click(object sender, EventArgs e)
    {
        if(isvalidate())
        {
            Session["PaymentMode"] = "DD";
            UpdatePrincipalDetails();
            Response.Redirect("DDDetails.aspx");
        }
    }
    private void UpdatePrincipalDetails()
    {
        bool affectrows = false;
        int PID = Convert.ToInt32(Session["PID"].ToString());
        if (PID > 0)
        {
            affectrows = Mysql.ExecuteNonQuery("exec UpdatePrincipalDetails @PrinicipalName='" + txtPName.Text + "',@PrincipalMobileNo='" + txtPMobileNo.Text + "',@PID=" + PID + ",@ITICode='" + Session["Username"].ToString() + "'");
        }
    }
    bool isvalidate()
    {
        if (string.IsNullOrEmpty(txtPName.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Enter Prinicipal Name');", true);
            txtPName.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtPMobileNo.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Enter Principal Mobile Number');", true);
            txtPMobileNo.Focus();
            return false;
        }
        else if (txtPMobileNo.Text.Length<10)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Enter Valid Mobile Number');", true);
            txtPMobileNo.Focus();
            return false;
        }
        else if (!CHKAGR.Checked)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Disclaimer');", true);
            CHKAGR.Focus();
            return false;
        }
        else
            return true;
    }
}