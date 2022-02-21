using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Common.Class;
using System.Resources;
using System.Globalization;
using System.Threading;
using System.Text.RegularExpressions;
using System.Text;
using System.Web.Mail;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Net;
using System.Drawing.Imaging;
using System.IO;

public partial class Candidate_EntryForm : ClsErrorLog
{
    CommonPerception Mysql = new CommonPerception();
    string CanId = string.Empty;
    string unique = "", username = "", Password = "";
    bool blins = false;
    string ins = "";
    string insedu = "";
    bool binsedu = false;
    string dateString = "";
    int year = 0;
    int day = 0;
    int month = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Session["UserId"] = "2";


            if (!IsPostBack)
            {
                if (Session["Username"] == null)
                    Response.Redirect("../Login/LoginNew.aspx");
                else
                {
                    lblUName.Text = "Welcome " + Convert.ToString(Session["Username"]);
                    txtITICode.Text = Convert.ToString(Session["Username"]);
                    FillExamCity();
                    FillTrade();
                }
                
                if (Convert.ToString(Session["ID"]) == "")
                {
                    txtTransDateTime.Text=DateTime.Now.ToString();
                    txtTransDateTime.Enabled = false;
                    btnSubmit.Text = "Submit";
                }
                    
                else
                {
                    FillForm();
                    btnSubmit.Text = "Update";
                }                
            }
        }
        catch (Exception ex)
        {
            LogError(ex);
        }
    }

    private void FillForm()
    {
        DataSet ds = new DataSet();
        ds = Mysql.GetDataSetWithQuery("SP_GetStudentOfflineDet '" + Convert.ToString(Session["ID"]) + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtITIContactNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["ITIContactNo"]);
            txtRollNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["RollNumber"]);
            txtName.Text = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
            drpddate.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["day"]);
            drpdmonth.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["month"]);
            drpdyear.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["year"]);
            drpAdmissionYear.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["AdmissionYear"]);
            drpTrade.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["trade"]);
            drpSem.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Sem"]);
            drpExamType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ExamType"]);
            drpPaper1.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Paper1"]);
            drpPaper2.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Paper2"]);
            drpPaper3.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Paper3"]);
            drpPaper4.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Paper4"]);
            drpPrefCity1.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PrefCity1"]);
            ddlExamcenter_SelectedIndexChanged(this, EventArgs.Empty);
            drpPrefCity2.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PrefCity2"]);
            ddlExamcenter2_SelectedIndexChanged(this, EventArgs.Empty);
            drpPrefCity3.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PrefCity3"]);
            drpCurrentStatus.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CurrentStatus"]);
            txtAmount.Text = Convert.ToString(ds.Tables[0].Rows[0]["Amount"]);
            txtTransDateTime.Text = Convert.ToString(ds.Tables[0].Rows[0]["TransDate"]);
            txtPaymentRefNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["PaymentRefNo"]);

            txtITICode.Enabled = false;
            txtRollNumber.Enabled = false;
            drpAdmissionYear.Enabled = false;
            drpTrade.Enabled = false;
            drpSem.Enabled = false;
            drpExamType.Enabled = false;
            txtTransDateTime.Enabled = false;
        }
    }
    void FillExamCity()
    {
        DataSet dsexamcity = new DataSet();
        dsexamcity = Mysql.GetDataSetWithQuery("sp_getexamCity");
        if (dsexamcity.Tables[0].Rows.Count > 0)
        {
            drpPrefCity1.DataSource = dsexamcity;
            drpPrefCity1.DataTextField = "CityName";
            drpPrefCity1.DataValueField = "Id";
            drpPrefCity1.DataBind();
            drpPrefCity1.Items.Insert(0, new ListItem("--SELECT--", "0"));
        }
    }

    void FillTrade()
    {
        DataSet dsexamcity = new DataSet();
        dsexamcity = Mysql.GetDataSetWithQuery("sp_getTrade");
        if (dsexamcity.Tables[0].Rows.Count > 0)
        {
            drpTrade.DataSource = dsexamcity;
            drpTrade.DataTextField = "TradeName";
            drpTrade.DataValueField = "Tradeid";
            drpTrade.DataBind();
            drpTrade.Items.Insert(0, new ListItem("--SELECT--", "0"));
        }
    }

    protected void ddlExamcenter_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpPrefCity2.Items.Clear();
        drpPrefCity3.Items.Clear();
        string value = drpPrefCity1.SelectedValue;
        DataSet dsexamcity = new DataSet();
        dsexamcity = Mysql.GetDataSetWithQuery("GetExamCityOthers '" + value + "',''");
        if (dsexamcity.Tables[0].Rows.Count > 0)
        {
            drpPrefCity2.DataSource = dsexamcity;
            drpPrefCity2.DataTextField = "CityName";
            drpPrefCity2.DataValueField = "Id";
            drpPrefCity2.DataBind();
            drpPrefCity2.Items.Insert(0, new ListItem("--SELECT--", "0"));
        }
    }

    protected void ddlExamcenter2_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpPrefCity3.Items.Clear();
        DataSet dsexamcity = new DataSet();
        dsexamcity = Mysql.GetDataSetWithQuery("GetExamCityOthers '" + drpPrefCity1.SelectedValue + "','" + drpPrefCity2.SelectedValue + "'");
        if (dsexamcity.Tables[0].Rows.Count > 0)
        {
            drpPrefCity3.DataSource = dsexamcity;
            drpPrefCity3.DataTextField = "CityName";
            drpPrefCity3.DataValueField = "Id";
            drpPrefCity3.DataBind();
            drpPrefCity3.Items.Insert(0, new ListItem("--SELECT--", "0"));
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (isvalidate())
            {
            if (btnSubmit.Text == "Update")
            {
                string dateString = drpdyear.SelectedValue + "-" + drpdmonth.SelectedValue + "-" + drpddate.SelectedValue;
                ins = "exec SP_Update_StudentOfflineDet  @ITICode='" + Convert.ToString(Session["Username"]) + "', @ID='" + Convert.ToString(Session["ID"]) + "', @ITIContactNo='" + txtITIContactNo.Text + "', @RollNumber='" + txtRollNumber.Text + "', " +
                  "@Name='" + txtName.Text.ToUpper().Trim() + " ', @DOB='" + dateString + "', @AdmissionYear='" + drpAdmissionYear.SelectedValue + "', @Trade='"
                  + drpTrade.SelectedValue + "', @Sem='" + drpSem.SelectedValue + "',@ExamType='" + drpExamType.SelectedValue + "',@Paper1='" + drpPaper1.SelectedValue + "'," +
                  "@Paper2='" + drpPaper2.SelectedValue + "',@Paper3='" + drpPaper3.SelectedValue + "',@Paper4='" + drpPaper4.SelectedValue + "',@PrefCity1='" + drpPrefCity1.SelectedValue + "'," +
                  "@PrefCity2='" + drpPrefCity2.SelectedValue + "',@PrefCity3='" + drpPrefCity3.SelectedValue + "',@CurrentStatus='" + drpCurrentStatus.SelectedValue + "'," +
                  "@Amount='" + txtAmount.Text + "',@TransDate='" + txtTransDateTime.Text + "',@PaymentRefNo='" + txtPaymentRefNo.Text + "'," +
                  "@UpdatedBy='" + Convert.ToString(Session["Username"]) + "'";
            }
            else
            {
                string dateString = drpdyear.SelectedValue + "-" + drpdmonth.SelectedValue + "-" + drpddate.SelectedValue;
                ins = "exec SP_Insert_StudentOfflineDet  @ITICode='" + Convert.ToString(Session["Username"]) + "', @ITIContactNo='" + txtITIContactNo.Text + "', @RollNumber='" + txtRollNumber.Text + "', " +
                  "@Name='" + txtName.Text.ToUpper().Trim() + " ', @DOB='" + dateString + "', @AdmissionYear='" + drpAdmissionYear.SelectedValue + "', @Trade='"
                  + drpTrade.SelectedValue + "', @Sem='" + drpSem.SelectedValue + "',@ExamType='" + drpExamType.SelectedValue + "',@Paper1='" + drpPaper1.SelectedValue + "'," +
                  "@Paper2='" + drpPaper2.SelectedValue + "',@Paper3='" + drpPaper3.SelectedValue + "',@Paper4='" + drpPaper4.SelectedValue + "',@PrefCity1='" + drpPrefCity1.SelectedValue + "'," +
                  "@PrefCity2='" + drpPrefCity2.SelectedValue + "',@PrefCity3='" + drpPrefCity3.SelectedValue + "',@CurrentStatus='" + drpCurrentStatus.SelectedValue + "'," +
                  "@Amount='" + txtAmount.Text + "',@TransDate='" + txtTransDateTime.Text + "',@PaymentRefNo='" + txtPaymentRefNo.Text + "'," +
                  "@CreatedBy='" + Convert.ToString(Session["Username"]) + "'";


            }
            blins = Mysql.ExecuteNonQuery(ins);
            if (blins == true)
            {
                try
                {
                    Response.Redirect("OfflineCandidateList.aspx");
                }
                catch (Exception ex)
                {
                    LogError(ex);
                }
            }
            else
            {
                string message = "alert('Sorry !! Your Registration is not succcessful !!! Please try again !!')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            }
        }
        catch (Exception ex)
        {
            LogError(ex);
        }
    }

    bool isvalidate()
    {
        try
        {
            if (txtITIContactNo.Text.ToString() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter ITI Contact No');", true);
                txtITIContactNo.Focus();
                return false;
            }
            if (txtRollNumber.Text.ToString() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter Roll Number');", true);
                txtRollNumber.Focus();
                return false;
            }
            if (txtName.Text.ToString() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter Name');", true);
                txtName.Focus();
                return false;
            }
            if (drpddate.SelectedValue != "0" && drpdmonth.SelectedValue != "0" && drpdyear.SelectedValue != "YEAR")
            {

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter valid Date of birth');", true);
                drpddate.SelectedIndex = -1;
                drpdmonth.SelectedIndex = -1;
                drpdyear.SelectedIndex = -1;
                drpddate.Focus();
                return false;

            }
            if (drpAdmissionYear.SelectedValue == "YEAR")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select Admission Year');", true);
                drpAdmissionYear.Focus();
                return false;
            }
            if (drpTrade.SelectedValue == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select Trade');", true);
                drpTrade.Focus();
                return false;
            }
            if (drpSem.SelectedValue == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select Semester');", true);
                drpSem.Focus();
                return false;
            }
            if (drpExamType.SelectedValue == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select Exam Type');", true);
                drpExamType.Focus();
                return false;
            }
            if (drpPaper1.SelectedValue == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select Paper 1');", true);
                drpPaper1.Focus();
                return false;
            }
            if (drpPaper2.SelectedValue == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select Paper 2');", true);
                drpPaper2.Focus();
                return false;
            }
            if (drpPaper3.SelectedValue == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select Paper 3');", true);
                drpPaper3.Focus();
                return false;
            }
            if (drpPaper4.SelectedValue == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select Paper 4');", true);
                drpPaper4.Focus();
                return false;
            }
            if (drpPrefCity1.SelectedValue == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select Preference City 1');", true);
                drpPrefCity1.Focus();
                return false;
            }
            if (drpPrefCity2.SelectedValue == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select Preference City 2');", true);
                drpPrefCity2.Focus();
                return false;
            }
            if (drpPrefCity3.SelectedValue == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select Preference City 3');", true);
                drpPrefCity3.Focus();
                return false;
            }
            if (drpCurrentStatus.SelectedValue == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select Preference Current Status');", true);
                drpCurrentStatus.Focus();
                return false;
            }
            if (txtAmount.Text.ToString() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter Amount');", true);
                txtAmount.Focus();
                return false;
            }
            if (txtPaymentRefNo.Text.ToString() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter PaymentReferenceNo');", true);
                txtPaymentRefNo.Focus();
                return false;
            }         

            
            return true;
        }
        catch (Exception ex)
        {
            //LogError(ex);
            return false;
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("OfflineCandidateList.aspx");
    }



}