using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Resources;
using System.Globalization;
using System.Threading;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;
using System.Web.Mail;
using System.Data.SqlClient;
using IntegrationKit;
using System.Collections.Specialized;
using CCA.Util;
using Common.Class;

public partial class PayOnline : ClsErrorLog
{
    #region Variables
    ResourceManager rm;
    CultureInfo ci;

    CommonPerception MySql = new CommonPerception();
    SqlDataReader dtr;
    libfuncs myUtility = new libfuncs();
    int FeesAmt;
    static int lcOrderID;
    string Category = "";
    string postid = "";
    string Exservice = "";
    string isPH = "";
    string Departmental = "";
    string strOrder_No = "";
    DataSet dsFeesAmt = new DataSet();
    static int amt = 0;
    string TrackYourIP = string.Empty;
    SqlConnection dbcon = new SqlConnection();
    int Ocategory;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
            Response.Redirect("../Login/LoginNew.aspx");

        if (!IsPostBack)
        {
            FeesAmount(Convert.ToString(Category));
            GetUserSelection();
        }
    }
    private void LoadString(CultureInfo ci)
    {
        #region Homepage
        //lblorderno.Text = rm.GetString("lblorderno", ci);
        //lblamount.Text = rm.GetString("lblamount", ci);

        //lblActualFee.Text = rm.GetString("lblActualFee", ci);
        //lblBankCharges.Text = rm.GetString("lblBankCharges", ci);
        #endregion
    }
    #region  Fees Amount

    public void FeesAmount(string Category)
    {
        lblamountvalue.Text = "";
        string ITICode = Convert.ToString(Session["Username"]);

        string FeeAmount = MySql.SingleCellResultInString("Select Finalstatus from tbl_ITIPendingAmounts where DGT_InstCode = '" + ITICode + "' and  Active = 1");

        lblActualFeeValue.Text = FeeAmount;
        lblBankChargesValue.Text = "0.00";
        lblamountvalue.Text = FeeAmount;
    }

    #endregion
    public void GetUserSelection()
    {
        Generate_Order_Details();
        //Generate_Order();
        GenerateURL();
    }
    public void Generate_Order_Details()
    {
        dbcon = new SqlConnection(CommonPerception.ConnectionString());
        SqlCommand cmdInsert = new SqlCommand();
        cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ITICode", System.Data.SqlDbType.VarChar, 30, "RegistrationId"));
        cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Amount", System.Data.SqlDbType.Decimal, 9, "Amount"));
        cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 100, "Mode"));

        cmdInsert.Parameters["@ITICode"].Value = Session["Username"].ToString();
        cmdInsert.Parameters["@Amount"].Value = lblamountvalue.Text.ToString();
        cmdInsert.Parameters["@Mode"].Value = "Online Pending Payment";

        Int32 _phdStatus = 0;
        string strLocalOrder_No = "";
        string strGetOrderNo;

        strOrder_No = strLocalOrder_No;
        lblordernoTextvalue.Text = strOrder_No;
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
            lcOrderID = (int)cmdInsert.Parameters["@ID"].Value;
            strOrder_No = strLocalOrder_No.ToString() + lcOrderID.ToString();// +lcGetOrderNo.ToString();
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
        dbcon = new SqlConnection(CommonPerception.ConnectionString());
        SqlCommand cmdInsert = new SqlCommand();
        cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RegistrationId", System.Data.SqlDbType.VarChar, 30, "RegistrationId"));
        cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Amount", System.Data.SqlDbType.Decimal, 9, "Amount"));
        cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Order_id", System.Data.SqlDbType.VarChar, 50, "OrderDetials_Id"));

        cmdInsert.Parameters["@RegistrationId"].Value = Session["Username"].ToString();
        cmdInsert.Parameters["@Amount"].Value = lblamountvalue.Text;
        cmdInsert.Parameters["@Order_id"].Value = lcOrderID;

        cmdInsert.CommandText = "SP_Insert_Orders_Pending";
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
    protected void GenerateURL()
    {
        string Amt = lblamountvalue.Text.ToString();
        //  Amt = "1.00";
        string order = lblordernoTextvalue.Text.ToString();

        merchant_id.Value = "202733";
        order_id.Value = order;
        amount.Value = Amt;
        currency.Value = "INR";
        if (lblamountvalue.Text != "")
        {
            redirect_url.Value = "http://mpitincvtjan2019.cbtexam.in:8080//PendingPayCash/Response.aspx";//live
            cancel_url.Value = "http://mpitincvtjan2019.cbtexam.in:8080//PendingPayCash/Response.aspx";//live
        }
    }
    protected void lnklogout_Click(object sender, EventArgs e)
    {
        MySql.UpdateSingleLogin(Session["Username"].ToString(), Convert.ToInt32(Session["UserType"].ToString()), 0);
        Session.Abandon();
        Session.Clear();
        Response.Redirect("../Login/LogOut.aspx");
    }
}