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
        string Order_Id = string.Empty;

        try
        {
            string workingKey = WebConfigurationManager.AppSettings["WORKINGKEY"].ToString();//put in the 32bit alpha numeric key in the quotes provided here
                                                                                             //string workingKey = "4DBBAE3B6C724FBE2345648BF74B1DFF";
            CCACrypto ccaCrypto = new CCACrypto();
            string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"], workingKey);
           // CommonUtilities.LogFileWrite(encResponse);
            NameValueCollection Params = new NameValueCollection();
            string[] segments = encResponse.Split('&');

           
            string Auth_Status = string.Empty;
            string Currency = string.Empty;
            string Amount = string.Empty;
            string bank_ref_no = string.Empty;
            string tracking_id = string.Empty;
            string Trans_Code = string.Empty;
            string Trans_Msg = string.Empty;

            #region segments
            foreach (string seg in segments)
            {

                string[] parts = seg.Split('=');
                if (parts[0] == "order_id")
                {
                    Order_Id = parts[1];
                }
                if (parts[0] == "bank_ref_no")
                {
                    bank_ref_no = parts[1];
                }
                if (parts[0] == "tracking_id")
                {
                    tracking_id = parts[1];
                }
                if (parts[0] == "order_status")
                {
                    Auth_Status = parts[1];
                }
                if (parts[0] == "currency")
                {
                    Currency = parts[1];
                }

                if (parts[0] == "mer_amount")
                {
                    Amount = parts[1];
                }

            }

           
            DataSet ds = Mysql.GetDataSet("select iticode from tbl_ITIPaymentDetails where pid='" + Order_Id + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["Username"] = Convert.ToString(ds.Tables[0].Rows[0]["iticode"]);
                Session["PID"] = Order_Id;
                Session["PaymentMode"] = "Online";
            }




            DataTable dt = new DataTable();
            dt = Mysql.GetDataTableWithQuery("select distinct ITICode+'-'+ITIName itiname from tbl_Student where ITICode='" + Session["Username"].ToString() + "'");
            if (dt != null && dt.Rows.Count > 0)
                lblUName.Text = "Welcome " + Convert.ToString(dt.Rows[0]["itiname"]);
            else
                lblUName.Text = "Welcome " + Session["Username"].ToString();



            if (!IsPostBack)
            {
                if (Session["PID"] == null)
                    Response.Redirect("../Dashboard.aspx");

                string PID = Session["PID"].ToString();
                lblPID.Text = "PID: " + PID;
                string ITICode = Session["Username"].ToString();

                string paymentMode = Session["PaymentMode"] == null ? "NOT IDENTIFIED" : Session["PaymentMode"].ToString();
                if (paymentMode == "Online" || paymentMode == "NOT IDENTIFIED")
                {

                    #endregion

                    if (Auth_Status == "Success")
                    {
                        Trans_Code = "0";
                        Trans_Msg = "Thank you for Successful Transaction.";
                        //CommonUtilities.LogFileWrite(string.Format("Auth suuccess received PID {0} OrderId {1}", PID.ToString(), Order_Id));

                        //CommonUtilities.LogFileWrite("Auth suuccess received PID- " + PID.ToString() + " Order ID- " + Order_Id.ToString());

                        //Mysql.ExecuteNonQuery("exec UpdatePaymentStatus " + Convert.ToInt32(Order_Id) + ",'" + Order_Id + "','Yes','" + Session["PaymentMode"].ToString() + "','" + Trans_Code + "','" + Trans_Msg + "'");

                        try
                        {
                            string PaymentMode = String.IsNullOrEmpty(Session["PaymentMode"].ToString()) ? String.Empty : Session["PaymentMode"].ToString();
                            int UpdateStatus = Mysql.UpdatePaymentStatus(Convert.ToInt32(Order_Id), Order_Id, "Yes", PaymentMode, Trans_Code, Trans_Msg, bank_ref_no, tracking_id);
                            if (UpdateStatus == 1)
                            {
                                dvstatus.InnerHtml = "Thank you for Successful Transaction.<br>We have received payment of Amount " + Amount + "";
                                dvstatus.Style.Add("color", "Green");
                                // CommonUtilities.LogFileWrite("UpdatePaymentStatus executed:" + PID.ToString());
                            }
                            else
                            {
                                dvstatus.InnerHtml = "Error Occurd while data update";
                                dvstatus.Style.Add("color", "Red");
                                //CommonUtilities.LogFileWrite("UpdatePaymentStatus Error executed:" + PID.ToString());
                            }
                        }
                        catch (Exception ex1)
                        {
                            //CommonUtilities.LogError(ex1);
                        }
                    }
                    else
                    {
                        if (Auth_Status == "Failure")
                        {
                            Trans_Code = "1";
                            Trans_Msg = "Thank you for transacting. <br>However,the transaction has been declined.";
                            dvstatus.InnerHtml = "Thank you for transacting. <br>However,the transaction has been declined.";
                            dvstatus.Style.Add("color", "Red");
                        }
                        else if (Auth_Status == "Invalid")
                        {
                            Trans_Code = "2";
                            Trans_Msg = "Thank you for transacting. <br>However,the transaction has been declined.";
                            dvstatus.InnerHtml = "Thank you for transacting. <br>However,the transaction has been declined.";
                            dvstatus.Style.Add("color", "Red");
                        }
                        else
                        {
                            Trans_Code = "3";
                            Trans_Msg = "System/Technical Error.";
                            dvstatus.InnerHtml = "System/Technical Error.";
                            dvstatus.Style.Add("color", "Red");
                        }
                        //CommonUtilities.LogFileWrite("Auth failed received:" + PID.ToString());
                        Mysql.ExecuteNonQuery("exec UpdatePaymentStatus " + Convert.ToInt32(Order_Id) + ",'" + Order_Id + "','No','" + Session["PaymentMode"].ToString() + "','" + Trans_Code + "','" + Trans_Msg + "','" + bank_ref_no + "','" + tracking_id + "'");
                        //CommonUtilities.LogFileWrite("UpdatePaymentStatus executed:" + PID.ToString());
                    }
                }
                else if (paymentMode == "DD")
                {
                    dvstatus.InnerHtml = "Thank you for Successful Transaction with DD.";
                    dvstatus.Style.Add("color", "Green");
                }
                BindPaymentSummary(Convert.ToInt32(PID), ITICode);
                Session["PID"] = null;
                Session["Amount"] = null;
                Session["PaymentMode"] = null;
            }
        }
        catch (Exception ex)
        {
           

        }
    }
    private void BindPaymentSummary(int PID, string ITICode)
    {
        dtgrid = new DataTable();
        dtgrid = Mysql.GetDataTableWithQuery("exec GetPaymentDetails @PID=" + PID + ",@ITICode='" + ITICode + "'");
        if (dtgrid != null && dtgrid.Rows.Count > 0)
        {
            if (dtgrid.Rows[0]["Paper1Status"].ToString().ToLower().Contains("yes|"))
                GridView1.Columns[10].HeaderText = dtgrid.Rows[0]["Paper1Status"].ToString().Split('|')[1];

            if (dtgrid.Rows[0]["Paper2Status"].ToString().ToLower().Contains("yes|"))
                GridView1.Columns[11].HeaderText = dtgrid.Rows[0]["Paper2Status"].ToString().Split('|')[1];

            if (dtgrid.Rows[0]["Paper3Status"].ToString().ToLower().Contains("yes|"))
                GridView1.Columns[12].HeaderText = dtgrid.Rows[0]["Paper3Status"].ToString().Split('|')[1];

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

            //if (dtgrid.Rows[0]["Paper1Status"].ToString().ToLower().Contains("no|"))
            //    GridView1.Columns[5].Visible = false;
            //if (dtgrid.Rows[0]["Paper2Status"].ToString().ToLower().Contains("no|"))
            //    GridView1.Columns[6].Visible = false;
            //if (dtgrid.Rows[0]["Paper3Status"].ToString().ToLower().Contains("no|"))
            //    GridView1.Columns[7].Visible = false;
            //if (dtgrid.Rows[0]["PracticalStatus"].ToString().ToLower().Contains("no|"))
            //    GridView1.Columns[8].Visible = false;
        }
    }
    protected void lnklogout_Click(object sender, EventArgs e)
    {
        //Mysql.UpdateSingleLogin(Session["Username"].ToString(), Convert.ToInt32(Session["UserType"].ToString()), 0);
        Session.Abandon();
        Session.Clear();
        Response.Redirect("../Login/LogOut.aspx");
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Login/LogOut.aspx");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblPaymentStatus = (Label)e.Row.FindControl("lblPaymentStatus");
            HiddenField hdnPayMode = (HiddenField)e.Row.FindControl("hdnPayMode");
            HiddenField hdnTID = (HiddenField)e.Row.FindControl("hdnTID");
            if (lblPaymentStatus.Text == "Successful")
                lblPaymentStatus.ForeColor = System.Drawing.Color.Green;
            else
                lblPaymentStatus.ForeColor = System.Drawing.Color.Red;

            if (hdnPayMode.Value.ToLower() == "payment through dd")
                lblPaymentStatus.Text = hdnPayMode.Value + " - " + hdnTID.Value;
        }
    }
}