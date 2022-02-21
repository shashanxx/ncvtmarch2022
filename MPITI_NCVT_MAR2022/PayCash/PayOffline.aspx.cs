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
    string strOrder_No = "";
    static int lcOrderID;
    string TrackYourIP = string.Empty;
    SqlConnection dbcon = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblUName.Text = "Welcome " + Request.QueryString["Username"].ToString();
        //if (Session["Username"] == null)
        //    Response.Redirect("../Login/LoginNew.aspx");
        //else
        //    lblUName.Text = "Welcome " + Session["Username"].ToString();
        //if (Session["PID"] == null)
        //    Response.Redirect("../Dashboard.aspx");
        //if (!IsPostBack)
        //{
            //CheckLoginTime();
        //}
        //CheckPIDExists(Convert.ToInt32(Session["PID"].ToString()));

        //if(!IsPostBack)
        //    bindPaymentDetails();
    }
    private void CheckLoginTime()
    {
        string UsrName = Mysql.SingleCellResultInString("exec CheckLoginTime @UserName='" + Session["Username"].ToString() + "',@UserType=" + Convert.ToInt32(Session["UserType"].ToString()) + ",@LoginDate='" + Session["LoginTime"].ToString() + "'");
        if (string.IsNullOrEmpty(UsrName))
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("../Login/LogOut.aspx");
        }
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
        Mysql.UpdateSingleLogin(Session["Username"].ToString(), Convert.ToInt32(Session["UserType"].ToString()), 0);
        Session.Abandon();
        Session.Clear();
        Response.Redirect("../Login/LogOut.aspx");
    }
    protected void ddlCardType_SelectedIndexChanged(object sender, EventArgs e)
    {
        double TotalAmount =  Convert.ToDouble(txtActualFeeValue.Text);
        //double TotalAmount = Convert.ToDouble(Session["Amount"].ToString());
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
            Generate_Order_Details();
            Generate_Order();
            //if (Updatedata())
            //{
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
                Response.Write(string.Format("<input type='hidden' name='redirect_url' id='redirect_url' runat='server' value='" + WebConfigurationManager.AppSettings["redirect_url_Off"].ToString() + "' />"));
                Response.Write(string.Format("<input type='hidden' name='cancel_url' id='cancel_url' runat='server' value='" + WebConfigurationManager.AppSettings["cancel_url_Off"].ToString() + "' />"));
                Response.Write("</form>");
                Response.Write("</body></html>");
                Response.End();
            //}
            //else
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('SOME ISSUE TO UPDATE RECORDS.');", true);
            //}
        }
    }

    public void Generate_Order_Details()
    {
        dbcon = new SqlConnection(Common.Class.CommonPerception.ConnectionString());
        SqlCommand cmdInsert = new SqlCommand();
        cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RegistrationId", System.Data.SqlDbType.VarChar, 30, "RegistrationId"));
        cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Amount", System.Data.SqlDbType.Decimal, 9, "Amount"));
        cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Actual_Amount", System.Data.SqlDbType.Decimal, 9, "Actual_Amount"));
        cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Bank_charges", System.Data.SqlDbType.Decimal, 9, "Bank_charges"));
        cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Order_No", System.Data.SqlDbType.VarChar, 50, "Order_No"));
        cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@mode", System.Data.SqlDbType.VarChar, 50, "mode"));
        cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TrackYourIP", System.Data.SqlDbType.VarChar, 50, "TrackYourIP"));
        cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Card_type", System.Data.SqlDbType.VarChar, 50, "Card_type"));

        cmdInsert.Parameters["@RegistrationId"].Value = Request.QueryString["Username"].ToString();
        cmdInsert.Parameters["@Amount"].Value = lblamountvalue.Text.ToString();
        cmdInsert.Parameters["@mode"].Value = "InOnline";
        cmdInsert.Parameters["@TrackYourIP"].Value = TrackYourIP;
        cmdInsert.Parameters["@Actual_Amount"].Value = txtActualFeeValue.Text.ToString();
        cmdInsert.Parameters["@Bank_charges"].Value = lblBankChargesValue.Text.ToString();
        cmdInsert.Parameters["@Card_type"].Value = ddlCardType.SelectedItem.Text; ;

        Int32 _phdStatus = 0;
        string strLocalOrder_No = "MPITI-NCVT";
        string strGetOrderNo;

        strLocalOrder_No = strLocalOrder_No + "-" + "OFF";

        strOrder_No = strLocalOrder_No;
        lblordernoTextvalue.Text = strOrder_No;
        cmdInsert.Parameters["@Order_No"].Value = strOrder_No;
        SqlParameter dbparam;
        dbparam = cmdInsert.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4));
        dbparam.Direction = ParameterDirection.Output;
        cmdInsert.CommandText = "SP_Insert_OrderDetails";
        cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
        cmdInsert.Connection = dbcon;

        try
        {
            dbcon.Open();
            cmdInsert.ExecuteNonQuery();
            lcOrderID = (int)cmdInsert.Parameters["@ID"].Value;
            strOrder_No = strLocalOrder_No.ToString() + lcOrderID.ToString();
            lblordernoTextvalue.Text = strOrder_No;
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

    public void Generate_Order()
    {
        dbcon = new SqlConnection(Common.Class.CommonPerception.ConnectionString());
        SqlCommand cmdInsert = new SqlCommand();
        cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RegistrationId", System.Data.SqlDbType.VarChar, 30, "RegistrationId"));
        cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Amount", System.Data.SqlDbType.Decimal, 9, "Amount"));
        cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Order_id", System.Data.SqlDbType.VarChar, 50, "OrderDetials_Id"));

        cmdInsert.Parameters["@RegistrationId"].Value = Request.QueryString["Username"].ToString();
        cmdInsert.Parameters["@Amount"].Value = lblamountvalue.Text;
        cmdInsert.Parameters["@Order_id"].Value = lcOrderID;

        cmdInsert.CommandText = "SP_Insert_Orders";
        cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
        cmdInsert.Connection = dbcon;
        try
        {
            dbcon.Open();
            cmdInsert.ExecuteNonQuery();
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
    private void CheckPIDExists(int CurrentPID)
    {
        string CPID = Mysql.SingleCellResultInString("exec CheckPIDExists @PID=" + CurrentPID + "");
        if (string.IsNullOrEmpty(CPID))
        {
            Response.Redirect("PrVerificationNew.aspx");
        }
    }    
}