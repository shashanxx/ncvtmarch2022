using Common.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PayCash_PayOnline : System.Web.UI.Page
{
    CommonPerception Mysql = new CommonPerception();
    bool affectrows = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
            Response.Redirect("../Login/LoginNew.aspx");
        else
            lblUName.Text = "Welcome " + Session["Username"].ToString();
        if (Session["PID"] == null)
            Response.Redirect("../Dashboard.aspx");
        if(!IsPostBack)
            bindPaymentDetails();
    }

    private void bindPaymentDetails()
    {
        lblordernoTextvalue.Text = Session["PID"].ToString();
        lblActualFeeValue.Text = Session["Amount"].ToString();
        lblBankChargesValue.Text = "0";
        lblamountvalue.Text = Session["Amount"].ToString();
    }
    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Response.Redirect("../Login/LogOut.aspx");
    }
    protected void ddlCardType_SelectedIndexChanged(object sender, EventArgs e)
    {
        double TotalAmount = Convert.ToDouble(Session["Amount"].ToString());
        double BankCharges = 0;
        if(ddlCardType.SelectedIndex>0)
        {
            if(ddlCardType.SelectedValue.ToString().ToLower()=="debit card")
            {
                BankCharges = 0;
                //TotalAmount = TotalAmount;
            }
            else
            {
                BankCharges = Convert.ToDouble(((TotalAmount * 1.2) / 100).ToString("##.00"));
                TotalAmount = TotalAmount + BankCharges;
            }
            lblBankChargesValue.Text = BankCharges.ToString();
            lblamountvalue.Text = TotalAmount.ToString();
        }
    }
    private bool Updatedata()
    {
        int PID = Convert.ToInt32(Session["PID"].ToString());
        if (PID > 0)
        {
            affectrows = Mysql.ExecuteNonQuery("exec UpdateBankCharges @CardType='" + ddlCardType.SelectedValue + "',@BankCharges='" + lblBankChargesValue.Text + "',@PID=" + PID + "");
        }
        return affectrows;
    }
    //private void SetPaymentData()
    //{
    //    merchant_id.Value = "rom_185219";
    //    order_id.Value = lblordernoTextvalue.Text;
    //    amount.Value = lblamountvalue.Text;
    //    currency.Value = "INR";
    //    redirect_url.Value = "http://JSSC.cbtexam.in/Principle/Print.aspx";
    //    cancel_url.Value = "http://JSSC.cbtexam.in/Principle/Print.aspx";
    //}

    protected void btnProceed_Click(object sender, EventArgs e)
    {
        if (isvalidate())
        {
            if (Updatedata())
            {
                string Url = "ccavRequestHandler.aspx";
                string Method = "post";
                string FormName = "form1";
                Response.Clear();
                Response.Write("<html><head>");
                Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));
                Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", FormName, Method, Url));
                Response.Write(string.Format("<input type='hidden' name='merchant_id' id='merchant_id' runat='server' value='" + WebConfigurationManager.AppSettings["MerchantID"].ToString() + "' />"));
                Response.Write(string.Format("<input type='hidden' name='order_id' id='order_id' runat='server' value='" + lblordernoTextvalue.Text + "' />"));
                Response.Write(string.Format("<input type='hidden' name='amount' id='amount' runat='server' value='" + lblamountvalue.Text + "' />"));
                Response.Write(string.Format("<input type='hidden' name='currency' id='currency' runat='server' value='INR' />"));
                Response.Write(string.Format("<input type='hidden' name='redirect_url' id='redirect_url' runat='server' value='" + WebConfigurationManager.AppSettings["redirect_url"].ToString() + "' />"));
                Response.Write(string.Format("<input type='hidden' name='cancel_url' id='cancel_url' runat='server' value='" + WebConfigurationManager.AppSettings["cancel_url"].ToString() + "' />"));
                Response.Write("</form>");
                Response.Write("</body></html>");
                Response.End();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('SOME ISSUE TO UPDATE RECORDS.');", true);
            }
        }
    }
    bool isvalidate()
    {
        if (ddlCardType.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('PLEASE CHOOSE CARD TYPE');", true);
            ddlCardType.Focus();
            return false;
        }
        else if (lblamountvalue.Text == "" || lblamountvalue.Text == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('YOUR AMOUNT IS ZERO. PLEASE SUBMIT FORM AGAIN');", true);
            lblamountvalue.Focus();
            return false;
        }
        else
            return true;
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Dashboard.aspx");
    }
}