using Common.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Principle_DDDetails : System.Web.UI.Page
{
    CommonPerception Mysql = new CommonPerception();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
            Response.Redirect("../Login/LoginNew.aspx");
        else
            lblUName.Text = "Welcome " + Session["Username"].ToString();
        if (Session["PID"] == null)
            Response.Redirect("../Dashboard.aspx");

        txtAmount.Text = Session["Amount"].ToString();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (isvalidate())
        {
            bool affectrows = false;
            int PID = Convert.ToInt32(Session["PID"].ToString());
            if (PID > 0)
            {
                string[] DDDate = txtDDDate.Text.Split('/');
                string NewDDDate = DDDate[2] + "-" + DDDate[1] + "-" + DDDate[0];
                affectrows = Mysql.ExecuteNonQuery("exec InsertDDDetails @DDNumber='" + txtDDnumber.Text + "',@BankName='" + txtBankName.Text + "',@IssuingBranch='" + txtIssuingBranch.Text + "',@DDDate='" + NewDDDate + "',@TotalAmount=" + Convert.ToDouble(txtAmount.Text).ToString("##.00") + ",@PaymentStatus='Yes',@PaymentMode='Payment through DD',@PID=" + PID + "");
                if (affectrows)
                    Response.Redirect("Print.aspx");
                else
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Some issue in update dd details. Please submit all information again.');", true);
            }
        }
    }
    bool isvalidate()
    {
        if (string.IsNullOrEmpty(txtDDnumber.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Enter DD Number');", true);
            txtDDnumber.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtBankName.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Enter Bank Name');", true);
            txtBankName.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtIssuingBranch.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Enter Issuing Branch');", true);
            txtIssuingBranch.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtDDDate.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Enter DD Date');", true);
            txtDDDate.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtAmount.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Enter Amount');", true);
            txtAmount.Focus();
            return false;
        }
        else
            return true;
    }
    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Response.Redirect("../Login/LogOut.aspx");
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Dashboard.aspx");
    }
}