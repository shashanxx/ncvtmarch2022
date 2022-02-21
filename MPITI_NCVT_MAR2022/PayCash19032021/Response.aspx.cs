/********************************************************************************************          
Client           :  AICTE   
Purpose          :  Response froM Gateway
Created By       :  Mr.Bipin ojha           
Created Date     :  25/05/2012         
Modified By      :            
Modified Date    :            
Purpose          : As per response update candidate details/payment/approve  

================================================================================================*/
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
using System.IO;
using System.Web.Mail;
using System.Text.RegularExpressions;
using System.Collections.Generic;

using System.Data.SqlClient;
using System.Linq;
//using Property_Layer;
//using Business_Layer;
//using Data_Layer;

using IntegrationKit;
using System.Collections.Specialized;
using CCA.Util;

using System.Resources;
using System.Globalization;
using System.Threading;
using Common.Class;
using System.Web.Configuration;

public partial class BillPay_Response : System.Web.UI.Page
{
    int RespCode = 1;
    libfuncs myUtility = new libfuncs();
    SqlConnection dbcon;
    SqlDataReader dbreader;
    string Merchant_Id = "", Order_Id = "", Amount = "", Auth_Status = "", Currency = "", status = "";
    static string Checksum = "";
    string strResponse = "";
    CommonPerception MySql = new CommonPerception();
    ResourceManager rm;
    CultureInfo ci;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!IsPostBack)
            {

                
               

            }

            string workingKey = WebConfigurationManager.AppSettings["WORKINGKEY"].ToString(); ;//put in the 32bit alpha numeric key in the quotes provided here
            CCACrypto ccaCrypto = new CCACrypto();
            string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"], workingKey);
            NameValueCollection Params = new NameValueCollection();
            string[] segments = encResponse.Split('&');
            foreach (string seg in segments)
            {
                string[] parts = seg.Split('=');
                if (parts.Length > 0)
                {
                    string Key = parts[0].Trim();
                    string Value = parts[1].Trim();
                    Params.Add(Key, Value);
                }
            }

            for (int i = 0; i < Params.Count; i++)
            {
                //Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");

                //---Added by pradeep to create response string for our response page
                //--0 - order_id  /   3 - order_Status  /   9 - currency    /   10 - amount
                if (i == 0 || i == 3 || i == 9 || i == 10)
                {
                    strResponse = strResponse + Params[i] + ",";
                }
                //---Added by pradeep to create response string for our response page
            }

            string[] pResponse = strResponse.Split(',');

            respid.Text = pResponse[0].ToString().Trim();
            Order_Id = pResponse[0].ToString().Trim();
            Auth_Status = pResponse[1].ToString().Trim();
            Currency = pResponse[2].ToString().Trim();
            Amount = pResponse[3].ToString().Trim();

            if (Auth_Status == "Success")
            {
                btnProceed.Visible = true;
                respcd.Text = "0";
                lblInfo.Text = "Thank you for Successful Transaction.";
            }
            else if (Auth_Status == "Failure")
            {
                btnProceed.Visible = false;
                respcd.Text = "1";
                respmsg.Text = "Thank you for transacting with CMAT <br>However,the transaction has been declined.";
                respmsg.ForeColor = System.Drawing.Color.Red;
                lblInfo.Text = "Since your transaction has been declined, you need to Re-Login and Re-Initiate the payment process";
            }
            else if (Auth_Status == "Invalid")
            {
                btnProceed.Visible = false;
                respcd.Text = "2";
                respmsg.Text = "Thank you for transacting with us. We will keep you posted regarding the status of your order through e-mail";
                respmsg.ForeColor = System.Drawing.Color.Red;
                lblInfo.Text = "Thank you for your interest, you need to Re-Login and do the Payment";
            }
            else
            {
                btnProceed.Visible = false;
                respcd.Text = "3";
                respmsg.Text = "System/Technical Error.";
                respmsg.ForeColor = System.Drawing.Color.Red;
                lblInfo.Text = "Thank you for your interest, you need to Re-Login and do the Payment";
            }

            RespCode = Convert.ToInt32(respcd.Text);
            dbcon = new SqlConnection(CommonPerception.ConnectionString());
            //if (!IsPostBack && Checksum == "true")
            if (!IsPostBack)
            {
                updateOrders(Convert.ToInt32(RespCode), respmsg.Text, Order_Id);
                if (respcd.Text == "0")
                {
                    btnPlzTry.Visible = false;
                    btnProceed.Visible = true;
                    string statuslock = "N";
                    updateselection(statuslock, Order_Id);
                }
                else
                {
                    btnPlzTry.Visible = true;
                    btnProceed.Visible = false;
                    string statuslock = "Y";
                    updateselection(statuslock, Order_Id);
                }
                GetuserDetails(Order_Id);
            }
        }
    }

    

    private void GetuserDetails(string order_no)
    {
        string strReg_id, strEnrNo, strCName, strPwd, strDob;
        string strUserDetails = "Select canid as RegistrationId,CandidateName as CName,Password, DOB as DateofBirth from dbo.tbabmcandidateinfo where canid in  (select RegistrationId from dbo.tborder_details where order_no='" + order_no + "')";
        dbreader = MySql.GetDataReader(strUserDetails);
        while (dbreader.Read())
        {
            strReg_id = dbreader[0].ToString();
            Session["CandidateId"] = strReg_id.Trim();
            strEnrNo = dbreader[0].ToString();
            strCName = dbreader[1].ToString();
            strPwd = dbreader[2].ToString();
            strDob = dbreader[3].ToString();
            Session["Order_no"] = order_no.ToString();

        }



    }
    private void updateOrders(int Transactioncode, string Transactionmsg, string Order_No1)
    {
        dbcon.Open();
        SqlCommand cmdUpdate = new SqlCommand();
        cmdUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Trans_code", System.Data.SqlDbType.Int, 4, "Trans_code"));
        cmdUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Trans_msg", System.Data.SqlDbType.VarChar, 500, "Trans_msg"));
        cmdUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Order_No", System.Data.SqlDbType.VarChar, 50, "Order_No"));

        cmdUpdate.Parameters["@Trans_code"].Value = Transactioncode.ToString();
        cmdUpdate.Parameters["@Trans_msg"].Value = Transactionmsg;
        cmdUpdate.Parameters["@Order_No"].Value = Order_No1;
        cmdUpdate.CommandText = "SP_UpdateOrders";
        cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
        cmdUpdate.Connection = dbcon;
        cmdUpdate.ExecuteNonQuery();
        dbcon.Close();
    }

    private void updateselection(string lockstatus, string Order_No2)
    {
        dbcon.Open();
        SqlCommand cmdUpdate = new SqlCommand();

        cmdUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lock", System.Data.SqlDbType.VarChar, 50, "Lock"));
        cmdUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Order_No", System.Data.SqlDbType.VarChar, 50, "Order_No"));
        cmdUpdate.Parameters["@Lock"].Value = lockstatus;
        cmdUpdate.Parameters["@Order_No"].Value = Order_No2;
        cmdUpdate.CommandText = "SP_UpdateSelection";
        cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
        cmdUpdate.Connection = dbcon;
        cmdUpdate.ExecuteNonQuery();
        dbcon.Close();

    }

    protected void btnProceed_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Candidate/ApplicationForm.aspx",false);
    }
    protected void btnPlzTry_Click(object sender, EventArgs e)
    {
        Response.Redirect("PayOnline.aspx");
    }
}
