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

public partial class Principle_StenoFeesCollection : System.Web.UI.Page
{
    CommonPerception Mysql = new CommonPerception();
    DataTable dtgrid;
    bool isGovt = false;
    protected void Page_Load(object sender, EventArgs e)
    {

        // Response.Redirect("../Dashboard.aspx");
        if (Session["Username"] == null)
            Response.Redirect("../Login/LoginNew.aspx");
        else
        {
            CheckForPendingAmount();
            DataTable dt = new DataTable();
            dt = Mysql.GetDataTableWithQuery("select distinct ITICode+'-'+ITIName itiname,TTIType from tbl_Student where ITICode='" + Session["Username"].ToString() + "'");
            if (dt != null && dt.Rows.Count > 0)
                lblUName.Text = "Welcome " + Convert.ToString(dt.Rows[0]["itiname"]);
            else
                lblUName.Text = "Welcome " + Session["Username"].ToString();
            if (dt != null && dt.Rows.Count > 0)
            {
                if (Convert.ToString(dt.Rows[0]["TTIType"]).ToLower().Trim() == "govt")
                {
                    tr_PaymentType.Visible = true;
                    isGovt = true;
                }
                else
                {
                    tr_PaymentType.Visible = false;
                    isGovt = false;
                }
            }

        }



        //if (!IsPostBack)
        //{
        CheckLoginTime();
        //}
        if (!IsPostBack)
        {
            //CheckOldTransaction(Session["Username"].ToString());
            bindyear();

            //GetExamDetails();
            //GetSemester();
        }
        DisplayPendingPaymentDetails(Session["Username"].ToString());
    }

    private void DisplayPendingPaymentDetails(string ITICode)
    {
        trPayment.Visible = false;
        DataSet ds = Mysql.GetDataSet("Select FinalStatus,Order_no, convert(varchar(10), LockDate, 105) LockDate  from [tbl_ITIPendingAmounts] where DGT_InstCode = '" + ITICode + "' and Active = 2 ");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            trPayment.Visible = true;
            lblPaymentAmount.Text = Convert.ToString(ds.Tables[0].Rows[0]["FinalStatus"]);
            lblOrderNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["Order_no"]);
            lblPaymentDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["LockDate"]);
        }
    }

    private void CheckForPendingAmount()
    {
        int AmountPending = 0;
        string ITICode = Convert.ToString(Session["Username"]);
        AmountPending = Mysql.SingleCellResult("Select Count(*) from tbl_ITIPendingAmounts where DGT_InstCode = '" + ITICode + "' and  Active = 1");
        if (AmountPending > 0)
        {
            Response.Redirect("../PendingPayCash/ITIPendingPayment.aspx");
        }
    }

    private void bindyear()
    {
        ddlAdmissionYear.Items.Add(new ListItem("Select", "0"));
        //for (int i = DateTime.Now.Year - 3; i < DateTime.Now.Year + 1; i++)
        for (int i = 2019; i <= 2019; i++)
        {
            ddlAdmissionYear.Items.Add(i.ToString());
        }
    }
    private void BindTradeList()
    {
        DataTable dtTrade = new DataTable();
        dtTrade = Mysql.GetDataTableWithQuery("exec GetStenoTradeList @ITICode='" + Session["Username"].ToString() + "',@Admissionyear='" + ddlAdmissionYear.SelectedValue + "'");
        ddlTradeName.Items.Clear();
        if (dtTrade != null && dtTrade.Rows.Count > 0)
        {

            ddlTradeName.DataSource = dtTrade;
            ddlTradeName.DataTextField = "TradeName";
            ddlTradeName.DataValueField = "Tradeid";
            ddlTradeName.DataBind();
        }
        ddlTradeName.Items.Insert(0, new ListItem("Select", "0"));
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (isvalidategrid())
            {
                Updateintable();
                bool affectrows = false;
              
                if (ViewState["TotalRecords"] != null)
                {
                    DataTable dtfinaltable = (DataTable)ViewState["TotalRecords"];
                    double TotalAmountforpaid = 0;
                    int PID = 0;
                    try
                    {
                        var TotalStuPayment = dtfinaltable.Compute("SUM(Amount)", "Eligibility='for verification' and ChoiceLocked='Yes' and PaymentStatus='No'");
                        if (TotalStuPayment != null && TotalStuPayment.ToString() != "")
                            TotalAmountforpaid = Convert.ToDouble(Convert.ToDouble(TotalStuPayment.ToString()).ToString("##.00"));
                    }
                    catch { }
                   
                    int flag = 0;
                    string NPID = "NULL";
                    string NewPID = "NULL";
                    string ApprovalStatus = string.Empty;
                    for (int i = 0; i < dtfinaltable.Rows.Count; i++)
                    {
                        if (dtfinaltable.Rows[i]["isedited"].ToString().ToLower() == "yes")
                        {
                            if (dtfinaltable.Rows[i]["Eligibility"].ToString().ToLower() == "for verification")
                                ApprovalStatus = "Approved";
                            else if (dtfinaltable.Rows[i]["Eligibility"].ToString().ToLower() == "for non-verification")
                                ApprovalStatus = "Approval Pending";
                            else if (dtfinaltable.Rows[i]["Eligibility"].ToString().ToLower() == "discharge")
                                ApprovalStatus = "Discharged";

                            if (flag == 0 && ddlPaymentType.SelectedValue != "dd")
                            {
                                if (dtfinaltable.Rows[i]["Eligibility"].ToString().ToLower() == "for verification" && dtfinaltable.Rows[i]["ChoiceLocked"].ToString().ToLower() == "yes" && dtfinaltable.Rows[i]["PaymentStatus"].ToString().ToLower() == "no" && Convert.ToDouble(dtfinaltable.Rows[i]["Amount"]) > 0)
                                {
                                    PID = Mysql.InsertITIPayment(TotalAmountforpaid, Session["Username"].ToString());
                                    Session["PID"] = PID;
                                    flag = 1;
                                }
                            }
                            else
                                Session["PID"] = "0";

                            if (dtfinaltable.Rows[i]["Eligibility"].ToString().ToLower() == "for verification" && dtfinaltable.Rows[i]["ChoiceLocked"].ToString().ToLower() == "yes" && dtfinaltable.Rows[i]["PaymentStatus"].ToString().ToLower() == "no" && Convert.ToDouble(dtfinaltable.Rows[i]["Amount"]) > 0)
                            { NPID = PID.ToString(); NewPID = NPID; }
                            else
                                NPID = "NULL";


                            affectrows = Mysql.ExecuteNonQuery("exec UpdateStudentDetails @RollNumber='" + dtfinaltable.Rows[i]["RollNumber"] + "',@Eligibility='" + dtfinaltable.Rows[i]["Eligibility"] + "',@Attendance='" + dtfinaltable.Rows[i]["Attendance"] + "',@Sessionalmarks='" + dtfinaltable.Rows[i]["Sessionalmarks"]
                                + "',@Paper1=" + (dtfinaltable.Rows[i]["Paper1"].ToString() == "true" ? 1 : 0) + ",@Paper2=" + (dtfinaltable.Rows[i]["Paper2"].ToString() == "true" ? 1 : 0) + ",@practical=" + (dtfinaltable.Rows[i]["practical"].ToString() == "true" ? 1 : 0)
                                + ",@Amount=" + dtfinaltable.Rows[i]["Amount"] + ",@SessionId='" + Session.SessionID + "',@PID=" + NPID + ",@ApprovalStatus='" + ApprovalStatus + "',@Paper1Status='" + dtfinaltable.Rows[i]["Paper1Status"] + "|" + dtfinaltable.Rows[i]["Paper1Header"]
                                + "',@Paper2Status='" + dtfinaltable.Rows[i]["Paper2Status"] + "|" + dtfinaltable.Rows[i]["Paper2Header"] + "',@PracticalStatus='" + dtfinaltable.Rows[i]["PracticalStatus"] + "|" + "',@Paper3=" + (dtfinaltable.Rows[i]["Paper3"].ToString() == "true" ? 1 : 0) + ",@Paper3Status='" + dtfinaltable.Rows[i]["Paper3Status"] + "|" + dtfinaltable.Rows[i]["Paper3Header"]
                                + "',@AdmissionYear=" + dtfinaltable.Rows[i]["AdmissionYear"] + ",@Semester=" + dtfinaltable.Rows[i]["Semester"] + ",@Trade='" + dtfinaltable.Rows[i]["Trade"] + "',@ExamType='" + dtfinaltable.Rows[i]["ExamType"] + "',@VerifiedBy='" + Session["Username"].ToString() + "',@PaymentType='" + ddlPaymentType.SelectedValue + "'");
                            if (!affectrows)
                            {
                                affectrows = Mysql.ExecuteNonQuery("exec UpdateStudentDetails @RollNumber='" + dtfinaltable.Rows[i]["RollNumber"] + "',@Eligibility='" + dtfinaltable.Rows[i]["Eligibility"] + "',@Attendance='" + dtfinaltable.Rows[i]["Attendance"] + "',@Sessionalmarks='" + dtfinaltable.Rows[i]["Sessionalmarks"]
                                + "',@Paper1=" + (dtfinaltable.Rows[i]["Paper1"].ToString() == "true" ? 1 : 0) + ",@Paper2=" + (dtfinaltable.Rows[i]["Paper2"].ToString() == "true" ? 1 : 0) + ",@practical=" + (dtfinaltable.Rows[i]["practical"].ToString() == "true" ? 1 : 0)
                                + ",@Amount=" + dtfinaltable.Rows[i]["Amount"] + ",@SessionId='" + Session.SessionID + "',@PID=" + NPID + ",@ApprovalStatus='" + ApprovalStatus + "',@Paper1Status='" + dtfinaltable.Rows[i]["Paper1Status"] + "|" + dtfinaltable.Rows[i]["Paper1Header"]
                                + "',@Paper2Status='" + dtfinaltable.Rows[i]["Paper2Status"] + "|" + dtfinaltable.Rows[i]["Paper2Header"] + "',@PracticalStatus='" + dtfinaltable.Rows[i]["PracticalStatus"] + "|" + "',@Paper3=" + (dtfinaltable.Rows[i]["Paper3"].ToString() == "true" ? 1 : 0) + ",@Paper3Status='" + dtfinaltable.Rows[i]["Paper3Status"] + "|" + dtfinaltable.Rows[i]["Paper3Header"]
                                + "',@AdmissionYear=" + dtfinaltable.Rows[i]["AdmissionYear"] + ",@Semester=" + dtfinaltable.Rows[i]["Semester"] + ",@Trade='" + dtfinaltable.Rows[i]["Trade"] + "',@ExamType='" + dtfinaltable.Rows[i]["ExamType"] + "',@VerifiedBy='" + Session["Username"].ToString() + "',@PaymentType='" + ddlPaymentType.SelectedValue + "'");
                            }
                            if (!affectrows)
                            {
                                CommonUtilities.LogFileWrite("PrVerification Page Student Updation Issue:" + "exec UpdateStudentDetails @RollNumber='" + dtfinaltable.Rows[i]["RollNumber"] + "',@Eligibility='" + dtfinaltable.Rows[i]["Eligibility"] + "',@Attendance='" + dtfinaltable.Rows[i]["Attendance"] + "',@Sessionalmarks='" + dtfinaltable.Rows[i]["Sessionalmarks"]
                                + "',@Paper1=" + (dtfinaltable.Rows[i]["Paper1"].ToString() == "true" ? 1 : 0) + ",@Paper2=" + (dtfinaltable.Rows[i]["Paper2"].ToString() == "true" ? 1 : 0) + ",@practical=" + (dtfinaltable.Rows[i]["practical"].ToString() == "true" ? 1 : 0)
                                + ",@Amount=" + dtfinaltable.Rows[i]["Amount"] + ",@SessionId='" + Session.SessionID + "',@PID=" + NPID + ",@ApprovalStatus='" + ApprovalStatus + "',@Paper1Status='" + dtfinaltable.Rows[i]["Paper1Status"] + "|" + dtfinaltable.Rows[i]["Paper1Header"]
                                + "',@Paper2Status='" + dtfinaltable.Rows[i]["Paper2Status"] + "|" + dtfinaltable.Rows[i]["Paper2Header"] + "',@PracticalStatus='" + dtfinaltable.Rows[i]["PracticalStatus"] + "|" + "',@Paper3=" + (dtfinaltable.Rows[i]["Paper3"].ToString() == "true" ? 1 : 0) + ",@Paper3Status='" + dtfinaltable.Rows[i]["Paper3Status"] + "|" + dtfinaltable.Rows[i]["Paper3Header"]
                                + "',@AdmissionYear=" + dtfinaltable.Rows[i]["AdmissionYear"] + ",@Semester=" + dtfinaltable.Rows[i]["Semester"] + ",@Trade='" + dtfinaltable.Rows[i]["Trade"] + "',@ExamType='" + dtfinaltable.Rows[i]["ExamType"] + "',@VerifiedBy='" + Session["Username"].ToString() + "',@PaymentType='" + ddlPaymentType.SelectedValue + "'");
                                break;
                            }
                        }
                    }
                    if (!affectrows)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Error Occured'); window.location='" + Request.ApplicationPath + "Principle/PrVerificationNew.aspx';", true);
                    }
                    else if (ddlPaymentType.SelectedValue != "dd")
                    {
                        if (Convert.ToInt32(NewPID.ToString()) > 0)
                        {
                            Session["PID"] = NewPID;
                            Response.Redirect("PaymentSummary.aspx", false);
                        }
                    }
                    
                    else if (ddlPaymentType.SelectedValue == "dd")
                    {
                        hdnrows.Value = "0";
                        ViewState["TotalRecords"] = null;
                        BindGrid();
                        BindPaymentSummary();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('No verification selected.');", true);
                    }
                   
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('ViewState is null. Please submit all information again.');", true);
                }


            }
        }
        catch (Exception ex)
        {
            CommonUtilities.LogError(ex);
        }
    }

    private void BindPaymentSummary()
    {
        try
        {
            dtgrid = new DataTable();
            dtgrid = Mysql.GetDataTableWithQuery("exec GetDDPaymentSummary @ITICode='" + Session["Username"].ToString() + "'");
            div_DDPayment.Visible = false;
            GridView2.DataSource = null;
            GridView2.DataBind();
            if (dtgrid != null && dtgrid.Rows.Count > 0)
            {
                GridView2.DataSource = dtgrid;
                GridView2.DataBind();
                GridViewRow head = GridView2.HeaderRow;
                string year = ddlAdmissionYear.Text;
                if (int.Parse(year) >= 2018)
                {

                    head.Cells[8].Text = "Year";
                    //GridView2.Columns[9].HeaderText = "Year";
                }
                else
                    head.Cells[8].Text = "Semester";
                //GridView2.Columns[9].HeaderText = "Semester";
                lbltotalstucountDD.Text = dtgrid.Rows.Count.ToString();
                div_DDPayment.Visible = true;
            }
            else
            {
                div_DDPayment.Visible = false;
                GridView2.DataSource = null;
                GridView2.DataBind();
            }
        }
        catch (Exception ex)
        {
            CommonUtilities.LogError(ex);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (isvalidate())
            {
                ViewState["TotalRecords"] = null;
                hdnrows.Value = "0";
                hdnexamtype.Value = ddlexamtype.SelectedValue.ToString();
                BindGrid();
            }
        }
        catch (Exception ex)
        {

            throw;
        }


    }

    bool isvalidate()
    {
        if (ddlAdmissionYear.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select admission year');", true);
            ddlAdmissionYear.Focus();
            return false;
        }
        else if (ddlTradeName.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select trade name');", true);
            ddlTradeName.Focus();
            return false;
        }
        else if (ddlSemester.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select Semester');", true);
            ddlSemester.Focus();
            return false;
        }
        else if (ddlexamtype.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select exam type');", true);
            ddlexamtype.Focus();
            return false;
        }
        else if (ddlPaymentType.SelectedValue == "0" && isGovt)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select payment type');", true);
            ddlPaymentType.Focus();
            return false;
        }
        else
            return true;
    }


    bool isvalidategrid()
    {
      
        return true;
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hdnCanEligibility = (HiddenField)e.Row.FindControl("hdnCanEligibility");
            DropDownList ddlCanEligibility = (DropDownList)e.Row.FindControl("ddlCanEligibility");
            Label lblCanEligibility = (Label)e.Row.FindControl("lblCanEligibility");
            HiddenField hdnAttendance = (HiddenField)e.Row.FindControl("hdnAttendance");
            DropDownList ddlAttendance = (DropDownList)e.Row.FindControl("ddlAttendance");
            Label lblAttendance = (Label)e.Row.FindControl("lblAttendance");
            HiddenField hdnSessMarks = (HiddenField)e.Row.FindControl("hdnSessMarks");
            DropDownList ddlSessMarks = (DropDownList)e.Row.FindControl("ddlSessMarks");
            Label lblSessMarks = (Label)e.Row.FindControl("lblSessMarks");
            CheckBox chkPaper1 = (CheckBox)e.Row.FindControl("chkPaper1");
            CheckBox chkPaper2 = (CheckBox)e.Row.FindControl("chkPaper2");
            CheckBox chkPaper3 = (CheckBox)e.Row.FindControl("chkPaper3");
            CheckBox chkPractical = (CheckBox)e.Row.FindControl("chkPractical");
            HiddenField hdntbledited = (HiddenField)e.Row.FindControl("hdntbledited");
            HiddenField hdnPaymentStatus = (HiddenField)e.Row.FindControl("hdnPaymentStatus");
            HiddenField hdnPaper1fee = (HiddenField)e.Row.FindControl("hdnPaper1fee");
            HiddenField hdnPaper2fee = (HiddenField)e.Row.FindControl("hdnPaper2fee");
            HiddenField hdnPaper3fee = (HiddenField)e.Row.FindControl("hdnPaper3fee");
            HiddenField hdnPracticalFees = (HiddenField)e.Row.FindControl("hdnPracticalFees");
            HiddenField hdnPaper1chk = (HiddenField)e.Row.FindControl("hdnPaper1chk");
            HiddenField hdnPaper2chk = (HiddenField)e.Row.FindControl("hdnPaper2chk");
            HiddenField hdnPaper3chk = (HiddenField)e.Row.FindControl("hdnPaper3chk");
            HiddenField hdnPracticalchk = (HiddenField)e.Row.FindControl("hdnPracticalchk");

            ddlCanEligibility.SelectedValue = "for non-verification";

            if (hdnCanEligibility.Value != "0" && (hdnCanEligibility.Value == "discharge" || hdnCanEligibility.Value == "for verification"))
            {
                ddlCanEligibility.SelectedValue = hdnCanEligibility.Value;
                ddlAttendance.SelectedValue = hdnAttendance.Value;
                ddlSessMarks.SelectedValue = hdnSessMarks.Value;
                if (hdntbledited.Value.ToLower() == "yes" && hdnPaymentStatus.Value.ToLower() == "no")
                {
                    if (hdnCanEligibility.Value == "for verification")
                    {
                        ddlAttendance.Enabled = true;
                        ddlSessMarks.Enabled = true;
                        if (hdnexamtype.Value.ToLower() == "reg")
                        {
                            if (Convert.ToInt32(hdnPaper1fee.Value) == 0)
                                chkPaper1.Enabled = false;
                            else
                                chkPaper1.Enabled = false;

                            if (Convert.ToInt32(hdnPaper2fee.Value) == 0)
                                chkPaper2.Enabled = false;
                            else
                                chkPaper2.Enabled = false;

                            if (Convert.ToInt32(hdnPaper3fee.Value) == 0)
                                chkPaper3.Enabled = false;
                            else
                                chkPaper3.Enabled = true;

                            if (Convert.ToInt32(hdnPracticalFees.Value) == 0)
                                chkPractical.Enabled = false;
                            else
                                chkPractical.Enabled = true;
                        }
                        else
                        {
                            chkPaper1.Enabled = false;
                            chkPaper2.Enabled = false;
                            chkPaper3.Enabled = true;
                            chkPractical.Enabled = true;
                        }

                        if (Convert.ToString(hdnPaper1chk.Value) == "0")
                            chkPaper1.Enabled = false;
                        else
                            chkPaper1.Enabled = false;

                        if (Convert.ToString(hdnPaper2chk.Value) == "0")
                            chkPaper2.Enabled = false;
                        else
                            chkPaper2.Enabled = false;

                        if (Convert.ToString(hdnPaper3chk.Value) == "0")
                            chkPaper3.Enabled = false;
                        else
                            chkPaper3.Enabled = true;

                        if (Convert.ToString(hdnPracticalchk.Value) == "0")
                            chkPractical.Enabled = false;
                        else
                            chkPractical.Enabled = true;
                    }
                    else
                    {
                        chkPaper1.Enabled = false;
                        chkPaper2.Enabled = false;
                        chkPaper3.Enabled = false;
                        chkPractical.Enabled = false;
                        chkPaper1.Checked = false;
                        chkPaper2.Checked = false;
                        chkPaper3.Checked = false;
                        chkPractical.Checked = false;
                        ddlAttendance.Enabled = false;
                        ddlSessMarks.Enabled = false;
                    }
                    lblCanEligibility.Visible = false;
                    ddlCanEligibility.Style.Add("display", "block");
                    ddlAttendance.Style.Add("display", "block");
                    ddlSessMarks.Style.Add("display", "block");
                }
                else
                {
                    lblCanEligibility.Style.Add("font-weight", "bold");
                    if (hdnCanEligibility.Value == "for verification")
                    {
                        lblCanEligibility.Text = "Verified";
                        lblSessMarks.Visible = true;
                        lblAttendance.Visible = true;
                        lblCanEligibility.ForeColor = System.Drawing.Color.Green;
                    }
                    else if (hdnCanEligibility.Value == "discharge")
                    {
                        lblCanEligibility.ForeColor = System.Drawing.Color.Red;
                    }
                    lblCanEligibility.Visible = true;
                    ddlCanEligibility.Style.Add("display", "none");
                    ddlAttendance.Style.Add("display", "none");
                    ddlSessMarks.Style.Add("display", "none");
                }
            }
            else
            {
                if (hdnCanEligibility.Value != "0" && hdnCanEligibility.Value == "for non-verification")
                {
                    ddlAttendance.Enabled = false;
                    ddlSessMarks.Enabled = false;
                    chkPaper1.Enabled = false;
                    chkPaper2.Enabled = false;
                    chkPaper3.Enabled = false;
                    chkPractical.Enabled = false;
                }
                ddlCanEligibility.SelectedValue = hdnCanEligibility.Value;
                ddlAttendance.SelectedValue = hdnAttendance.Value;
                ddlSessMarks.SelectedValue = hdnSessMarks.Value;
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
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Dashboard.aspx");
    }
    protected void BindGrid()
    {
        if (ViewState["TotalRecords"] == null)
        {
            dtgrid = new DataTable();
            dtgrid = Mysql.GetDataTableWithQuery("exec GetStudentDetailsForVerification_New_Steno @AdmissionYear=" + ddlAdmissionYear.SelectedValue + ",@Semester=" + ddlSemester.SelectedValue + ", @ExamType='" + ddlexamtype.SelectedValue + "', @Trade='" + ddlTradeName.SelectedItem.Text + "',@ITICode='" + Session["Username"].ToString() + "'");
            if (dtgrid != null && dtgrid.Rows.Count > 0)
            {
                ViewState["TotalRecords"] = dtgrid;
            }
        }
        else
        {
            dtgrid = (DataTable)ViewState["TotalRecords"];
        }
        if (dtgrid != null && dtgrid.Rows.Count > 0)
        {
            lbltotalstucount.Text = Convert.ToInt32(dtgrid.Compute("COUNT(Eligibility)", "Eligibility='for verification' and ChoiceLocked='Yes' and PaymentStatus='No'")).ToString();
            try
            {
                var TotalStuPayment = dtgrid.Compute("SUM(Amount)", "Eligibility='for verification' and ChoiceLocked='Yes' and PaymentStatus='No'");
                if (TotalStuPayment != null && TotalStuPayment.ToString() != "")
                    lbltotalstuPayment.Text = TotalStuPayment.ToString();
                else
                    lbltotalstuPayment.Text = "0";
            }
            catch { }

            int PageSize = Convert.ToInt32(WebConfigurationManager.AppSettings["PageSize"].ToString());

            if ((dtgrid.Rows.Count - Convert.ToInt32(hdnrows.Value)) > PageSize)
            {
                dtgrid = dtgrid.AsEnumerable().Skip(Convert.ToInt32(hdnrows.Value)).Take(PageSize).CopyToDataTable();
                btnGridNext.Visible = true;
                btnSave.Visible = false;
                btnGridPrevious.Visible = true;
            }
            else
            {
                dtgrid = dtgrid.AsEnumerable().Skip(Convert.ToInt32(hdnrows.Value)).Take(dtgrid.Rows.Count).CopyToDataTable();
                btnGridNext.Visible = false;
                btnSave.Visible = true;
                btnGridPrevious.Visible = true;
            }
            if (hdnrows.Value == "0")
            {
                btnGridPrevious.Visible = false;
            }
            if (dtgrid.Rows[0]["Paper1Status"].ToString().ToLower() == "yes")
            {
                GridView1.Columns[8].Visible = true;
                GridView1.Columns[8].HeaderText = dtgrid.Rows[0]["Paper1Header"].ToString();
            }

            if (dtgrid.Rows[0]["Paper2Status"].ToString().ToLower() == "yes")
            {
                GridView1.Columns[9].Visible = true;
                GridView1.Columns[9].HeaderText = dtgrid.Rows[0]["Paper2Header"].ToString();
            }

            if (dtgrid.Rows[0]["Paper3Status"].ToString().ToLower() == "yes")
            {
                GridView1.Columns[10].Visible = true;
                GridView1.Columns[10].HeaderText = dtgrid.Rows[0]["Paper3Header"].ToString();
            }

            if (dtgrid.Rows[0]["PracticalStatus"].ToString().ToLower() == "yes")
                GridView1.Columns[11].Visible = true;

            GridView1.DataSource = dtgrid;
            GridView1.DataBind();
            lblCMessage.Text = "";
            divtotal.Visible = true;
            //column hide behalf of paper
            if (dtgrid.Rows[0]["Paper1Status"].ToString().ToLower() == "no")
                GridView1.Columns[8].Visible = false;

            if (dtgrid.Rows[0]["Paper2Status"].ToString().ToLower() == "no")
                GridView1.Columns[9].Visible = false;

            if (dtgrid.Rows[0]["Paper3Status"].ToString().ToLower() == "no")
                GridView1.Columns[10].Visible = false;

            if (dtgrid.Rows[0]["PracticalStatus"].ToString().ToLower() == "no")
                GridView1.Columns[11].Visible = false;

         
        }
        else
        {
            lbltotalstucount.Text = "0";
            lbltotalstuPayment.Text = "0";
            GridView1.DataSource = null;
            GridView1.DataBind();
            btnSave.Visible = false;
            btnGridPrevious.Visible = false;
            btnGridNext.Visible = false;
            lblCMessage.Text = "Sorry, No record found";
            divtotal.Visible = false;
        }
    }
    protected void btnGridNext_Click(object sender, EventArgs e)
    {
        int PageSize = Convert.ToInt32(WebConfigurationManager.AppSettings["PageSize"].ToString());
        Updateintable();
        hdnrows.Value = (Convert.ToInt32(hdnrows.Value) + PageSize).ToString();
        BindGrid();
    }
    protected void btnGridPrevious_Click(object sender, EventArgs e)
    {
        int PageSize = Convert.ToInt32(WebConfigurationManager.AppSettings["PageSize"].ToString());
        hdnrows.Value = (Convert.ToInt32(hdnrows.Value) - PageSize).ToString();
        BindGrid();
    }
    private void Updateintable()
    {
        int i = Convert.ToInt32(hdnrows.Value);
        DataTable dtupdate = (DataTable)ViewState["TotalRecords"];
        double PaperSumAmount = 0;
        foreach (GridViewRow gvr in GridView1.Rows)
        {
            PaperSumAmount = 0;
            DropDownList ddlCanEligibility = (DropDownList)gvr.FindControl("ddlCanEligibility");
            DropDownList ddlAttendance = (DropDownList)gvr.FindControl("ddlAttendance");
            DropDownList ddlSessMarks = (DropDownList)gvr.FindControl("ddlSessMarks");
            CheckBox chkPaper1 = (CheckBox)gvr.FindControl("chkPaper1");
            CheckBox chkPaper2 = (CheckBox)gvr.FindControl("chkPaper2");
            CheckBox chkPaper3 = (CheckBox)gvr.FindControl("chkPaper3");
             CheckBox chkPractical = (CheckBox)gvr.FindControl("chkPractical");
            TextBox txtAmount = (TextBox)gvr.FindControl("txtAmount");
            dtupdate.Rows[i]["Eligibility"] = ddlCanEligibility.SelectedValue;
            dtupdate.Rows[i]["Attendance"] = ddlAttendance.SelectedValue;
            dtupdate.Rows[i]["Sessionalmarks"] = ddlSessMarks.SelectedValue;
            dtupdate.Rows[i]["Paper1"] = (chkPaper1.Checked ? "true" : "false");
            dtupdate.Rows[i]["Paper2"] = (chkPaper2.Checked ? "true" : "false");
            dtupdate.Rows[i]["Paper3"] = (chkPaper3.Checked ? "true" : "false");
             dtupdate.Rows[i]["practical"] = (chkPractical.Checked ? "true" : "false");
            dtupdate.Rows[i]["Amount"] = txtAmount.Text;
            if (ddlCanEligibility.SelectedValue.ToString().ToLower() == "for verification" && dtupdate.Rows[i]["ChoiceLocked"].ToString().ToLower() == "yes" && dtupdate.Rows[i]["PaymentStatus"].ToString().ToLower() == "no")
            {
                if (dtupdate.Rows[i]["Paper1Status"].ToString().ToLower() == "yes" && chkPaper1.Checked)
                    PaperSumAmount += Convert.ToDouble(dtupdate.Rows[i]["Paper1fee"].ToString());

                if (dtupdate.Rows[i]["Paper2Status"].ToString().ToLower() == "yes" && chkPaper2.Checked)
                    PaperSumAmount += Convert.ToDouble(dtupdate.Rows[i]["Paper2fee"].ToString());

                if (dtupdate.Rows[i]["Paper3Status"].ToString().ToLower() == "yes" || dtupdate.Rows[i]["PracticalStatus"].ToString().ToLower() == "yes")
                {
                    if (dtupdate.Rows[i]["Paper3Status"].ToString().ToLower() == "yes" && chkPaper3.Checked)
                        PaperSumAmount += Convert.ToDouble(dtupdate.Rows[i]["Paper3fee"].ToString());
                    else if (dtupdate.Rows[i]["PracticalStatus"].ToString().ToLower() == "yes" && chkPractical.Checked)
                        PaperSumAmount += Convert.ToDouble(dtupdate.Rows[i]["PracticalFees"].ToString());
                }

                dtupdate.Rows[i]["Amount"] = PaperSumAmount;
            }
            
            i++;
        }
        dtupdate.AcceptChanges();
        
        ViewState["TotalRecords"] = dtupdate;
    }
    private void CheckOldTransaction(string ITICode)
    {
        string OldPID = Mysql.SingleCellResultInString("exec GetOldTransactionDetails @ITICode='" + ITICode + "'");
        if (!string.IsNullOrEmpty(OldPID))
        {
            Session["PID"] = OldPID;
            Response.Redirect("PaymentSummary.aspx?OTrans=yes");
        }
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

    protected void ddlPaymentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPaymentType.SelectedValue == "dd")
        {
            div_DDPayment.Visible = true;
            BindPaymentSummary();
        }
        else
        {
            div_DDPayment.Visible = false;
        }
    }

    protected void btnDDSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (isCandidateSelected())
            {

                //----Insert Marks
                int CheckedCount = 0;
                double TotalAmountforpaid = 0;
                int flag = 0;
                int PID = 0;
                foreach (GridViewRow row1 in GridView2.Rows)
                {
                    if (row1.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row1.Cells[0].FindControl("checkCan") as CheckBox);
                        if (chkRow.Checked)
                        {
                            string amount = Convert.ToString((row1.Cells[14].FindControl("txtAmount") as TextBox).Text);
                            TotalAmountforpaid += Convert.ToDouble(Convert.ToDouble(amount).ToString("##.00"));
                        }
                    }
                }

                PID = Mysql.InsertITIPayment(TotalAmountforpaid, Session["Username"].ToString());
                Session["PID"] = PID;

                foreach (GridViewRow row1 in GridView2.Rows)
                {
                    if (row1.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row1.Cells[0].FindControl("checkCan") as CheckBox);
                        if (chkRow.Checked)
                        {
                            CheckedCount = CheckedCount + 1;
                            string RollNo = Convert.ToString((row1.Cells[1].FindControl("lblRollNo") as Label).Text);
                            string sem;
                            if (Convert.ToString((row1.Cells[8].FindControl("lblSemester") as Label).Text) == "1" && Convert.ToInt32((row1.Cells[6].FindControl("lblAdmissionYear") as Label).Text) >= 2018)
                            {
                                sem = "2";
                            }
                            else if (Convert.ToString((row1.Cells[8].FindControl("lblSemester") as Label).Text) == "2" && Convert.ToInt32((row1.Cells[6].FindControl("lblAdmissionYear") as Label).Text) >= 2018)
                            {
                                sem = "4";
                            }
                            else
                            {
                                sem = Convert.ToString((row1.Cells[8].FindControl("lblSemester") as Label).Text);
                            }
                            string trade = Convert.ToString((row1.Cells[7].FindControl("lblTrade") as Label).Text);
                            string admissionYear = Convert.ToString((row1.Cells[6].FindControl("lblAdmissionYear") as Label).Text);
                            string examType = Convert.ToString((row1.Cells[9].FindControl("lblExamtype") as Label).Text);
                            string ins = "exec SP_SaveDDPyment  @PID='" + PID + "',@AdmissionYear=" + admissionYear + ", @RollNo='" + RollNo + "' , @ITICode='" + Session["Username"].ToString() + "' , @Trade='" + trade + "', @ExamType='" + examType + "',@Semester='" + sem + "'";
                            Mysql.ExecuteNonQuery(ins);
                        }
                    }
                }
                if (CheckedCount > 0)
                {
                    Response.Redirect("DDPaymentSummary.aspx", false);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select at least one record.');", true);
                }
            }
        }
        catch (Exception ex)
        {
            CommonUtilities.LogError(ex);
        }
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            if (isCandidateSelected())
            {
                //----Insert Marks
                int CheckedCount = 0;
                foreach (GridViewRow row1 in GridView2.Rows)
                {
                    if (row1.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row1.Cells[0].FindControl("checkCan") as CheckBox);
                        if (chkRow.Checked)
                        {
                            CheckedCount = CheckedCount + 1;
                            string RollNo = Convert.ToString((row1.Cells[1].FindControl("lblRollNo") as Label).Text);
                            string sem;
                            if (Convert.ToString((row1.Cells[8].FindControl("lblSemester") as Label).Text) == "1" && Convert.ToInt32((row1.Cells[6].FindControl("lblAdmissionYear") as Label).Text) >= 2018)
                            {
                                sem = "2";
                            }
                            else if (Convert.ToString((row1.Cells[8].FindControl("lblSemester") as Label).Text) == "2" && Convert.ToInt32((row1.Cells[6].FindControl("lblAdmissionYear") as Label).Text) >= 2018)
                            {
                                sem = "4";
                            }
                            else
                            {
                                sem = Convert.ToString((row1.Cells[8].FindControl("lblSemester") as Label).Text);
                            }
                            string trade = Convert.ToString((row1.Cells[7].FindControl("lblTrade") as Label).Text);
                            string admissionYear = Convert.ToString((row1.Cells[6].FindControl("lblAdmissionYear") as Label).Text);
                            string examType = Convert.ToString((row1.Cells[9].FindControl("lblExamtype") as Label).Text);
                            string ins = "exec SP_RemoveDDPyment  @AdmissionYear=" + admissionYear + ", @RollNo='" + RollNo + "' , @ITICode='" + Session["Username"].ToString() + "' , @Trade='" + trade + "', @ExamType='" + examType + "',@Semester='" + sem + "'";
                            Mysql.ExecuteNonQuery(ins);
                        }
                    }
                }
                if (CheckedCount > 0)
                {
                    ViewState["TotalRecords"] = null;
                    hdnrows.Value = "0";
                    BindGrid();
                    BindPaymentSummary();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select at least one record.');", true);
                }
            }
        }
        catch (Exception ex)
        {
            CommonUtilities.LogError(ex);
        }
    }

    protected void checkAll_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox ChkBoxHeader = (CheckBox)GridView2.HeaderRow.FindControl("checkAll");
            foreach (GridViewRow row in GridView2.Rows)
            {
                CheckBox ChkBoxRows = (CheckBox)row.FindControl("checkCan");
                if (ChkBoxHeader.Checked == true)
                {
                    ChkBoxRows.Checked = true;
                }
                else
                {
                    ChkBoxRows.Checked = false;
                }
            }
        }
        catch (Exception ex)
        {
            CommonUtilities.LogError(ex);
        }
    }

    bool isCandidateSelected()
    {
        int countCheck = 0;
        //----Check all values entered of checked row
        foreach (GridViewRow row in GridView2.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("checkCan") as CheckBox);
                if (chkRow.Checked)
                    countCheck++;
            }
        }
        if (countCheck == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select at least one record.');", true);
            return false;
        }
        return true;
    }

    protected void ddlAdmissionYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTradeList();

        if (Convert.ToInt32(ddlAdmissionYear.SelectedValue) >= 2018)
        {
            lblSemester.Text = "Year";
            ddlSemester.Items.Clear();
            ddlSemester.Items.Add(new ListItem("Select", "0"));
            ddlSemester.Items.Add(new ListItem("1st Year", "2"));
            ddlSemester.Items.Add(new ListItem("2nd Year", "4"));
        }
        else
        {
            lblSemester.Text = "Semester";
            ddlSemester.Items.Clear();
            ddlSemester.Items.Add(new ListItem("Select", "0"));
            ddlSemester.Items.Add(new ListItem("Sem1", "1"));
            ddlSemester.Items.Add(new ListItem("Sem2", "2"));
            ddlSemester.Items.Add(new ListItem("Sem3", "3"));
            ddlSemester.Items.Add(new ListItem("Sem4", "4"));

        }
    }
}