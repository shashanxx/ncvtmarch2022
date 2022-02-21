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

public partial class Principle_PrVerificationNew : System.Web.UI.Page
{
    CommonPerception Mysql = new CommonPerception();
    DataTable dtgrid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
            Response.Redirect("../Login/LoginNew.aspx");
        else
            lblUName.Text ="Welcome "+ Session["Username"].ToString();
        
        if (!IsPostBack)
        {
            bindyear();
            BindTradeList();
            //GetExamDetails();
            //GetSemester();
        }
    }

    private void bindyear()
    {
        ddlAdmissionYear.Items.Add(new ListItem("Select", "0"));
        for (int i = DateTime.Now.Year - 3; i < DateTime.Now.Year + 1; i++)
        {
            ddlAdmissionYear.Items.Add(i.ToString());
        }
    }
    private void BindTradeList()
    {
        DataTable dtTrade = new DataTable();
        dtTrade = Mysql.GetDataTableWithQuery("exec GetTradeList @ITICode='" + Session["Username"].ToString() + "'");
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
                //foreach(GridViewRow gvr in GridView1.Rows)
                //{
                //    Label lblRollNo = (Label)gvr.FindControl("lblRollNo");
                //    DropDownList ddlCanEligibility = (DropDownList)gvr.FindControl("ddlCanEligibility");
                //    DropDownList ddlAttendance = (DropDownList)gvr.FindControl("ddlAttendance");
                //    DropDownList ddlSessMarks = (DropDownList)gvr.FindControl("ddlSessMarks");
                //    CheckBox chkTradeTheory = (CheckBox)gvr.FindControl("chkTradeTheory");
                //    CheckBox chkEmpSkills = (CheckBox)gvr.FindControl("chkEmpSkills");
                //    CheckBox chkWorkshopCalc = (CheckBox)gvr.FindControl("chkWorkshopCalc");
                //    CheckBox chkEngDrawing = (CheckBox)gvr.FindControl("chkEngDrawing");
                //    CheckBox chkPractical = (CheckBox)gvr.FindControl("chkPractical");
                //    TextBox txtAmount = (TextBox)gvr.FindControl("txtAmount");
                //    Label lblCanEligibility = (Label)gvr.FindControl("lblCanEligibility");
                //    if (lblCanEligibility.Text != "discharge")
                //    {
                //        affectrows = Mysql.ExecuteNonQuery("exec UpdateStudentDetails @RollNumber='" + lblRollNo.Text + "',@Eligibility='" + ddlCanEligibility.SelectedValue + "',@Attendance='" + ddlAttendance.SelectedValue + "',@Sessionalmarks='" + ddlSessMarks.SelectedValue
                //            + "',@TradeTheory=" + (chkTradeTheory.Checked ? 1 : 0) + ",@Employabilityskills=" + (chkEmpSkills.Checked ? 1 : 0) + ",@WorkshopCalcScience=" + (chkWorkshopCalc.Checked ? 1 : 0) + ",@EngineeringDrawing=" + (chkEngDrawing.Checked ? 1 : 0) + ",@practical=" + (chkPractical.Checked ? 1 : 0)
                //            + ",@Amount=" + txtAmount.Text + "");
                //    }
                //}
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
                    //if (TotalAmountforpaid>0)
                    //{

                    //}

                    //if (PID > 0)
                    //{
                    int flag = 0;
                    string NPID = "NULL";
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

                            if (flag == 0)
                            {
                                if (dtfinaltable.Rows[i]["Eligibility"].ToString().ToLower() == "for verification" && dtfinaltable.Rows[i]["ChoiceLocked"].ToString().ToLower() == "yes" && dtfinaltable.Rows[i]["PaymentStatus"].ToString().ToLower() == "no" && Convert.ToDouble(dtfinaltable.Rows[i]["Amount"]) > 0)
                                {
                                    PID = Mysql.InsertITIPayment(TotalAmountforpaid, Session["Username"].ToString());
                                    Session["PID"] = PID;
                                    flag = 1;
                                }
                            }

                            if (dtfinaltable.Rows[i]["Eligibility"].ToString().ToLower() == "for verification" && dtfinaltable.Rows[i]["ChoiceLocked"].ToString().ToLower() == "yes" && dtfinaltable.Rows[i]["PaymentStatus"].ToString().ToLower() == "no" && Convert.ToDouble(dtfinaltable.Rows[i]["Amount"])>0)
                                NPID = PID.ToString();
                            else
                                NPID = "NULL";

                            affectrows = Mysql.ExecuteNonQuery("exec UpdateStudentDetails @RollNumber='" + dtfinaltable.Rows[i]["RollNumber"] + "',@Eligibility='" + dtfinaltable.Rows[i]["Eligibility"] + "',@Attendance='" + dtfinaltable.Rows[i]["Attendance"] + "',@Sessionalmarks='" + dtfinaltable.Rows[i]["Sessionalmarks"]
                                + "',@Paper1=" + (dtfinaltable.Rows[i]["Paper1"].ToString() == "true" ? 1 : 0) + ",@Paper2=" + (dtfinaltable.Rows[i]["Paper2"].ToString() == "true" ? 1 : 0) + ",@practical=" + (dtfinaltable.Rows[i]["practical"].ToString() == "true" ? 1 : 0)
                                + ",@Amount=" + dtfinaltable.Rows[i]["Amount"] + ",@SessionId='" + Session.SessionID + "',@PID=" + NPID + ",@ApprovalStatus='" + ApprovalStatus + "',@Paper1Status='" + dtfinaltable.Rows[i]["Paper1Status"] + "|" + dtfinaltable.Rows[i]["Paper1Header"]
                                + "',@Paper2Status='" + dtfinaltable.Rows[i]["Paper2Status"] + "|" + dtfinaltable.Rows[i]["Paper2Header"] + "',@PracticalStatus='" + dtfinaltable.Rows[i]["PracticalStatus"] + "|" + "',@Paper3=" + (dtfinaltable.Rows[i]["Paper3"].ToString() == "true" ? 1 : 0) + ",@Paper3Status='" + dtfinaltable.Rows[i]["Paper3Status"] + "|" + dtfinaltable.Rows[i]["Paper3Header"]
                                + "',@AdmissionYear=" + dtfinaltable.Rows[i]["AdmissionYear"] + ",@Semester=" + dtfinaltable.Rows[i]["Semester"] + ",@Trade='" + dtfinaltable.Rows[i]["Trade"] + "',@ExamType='" + dtfinaltable.Rows[i]["ExamType"] + "',@VerifiedBy='" + Session["Username"].ToString() + "'");
                            if(!affectrows)
                            {
                                affectrows = Mysql.ExecuteNonQuery("exec UpdateStudentDetails @RollNumber='" + dtfinaltable.Rows[i]["RollNumber"] + "',@Eligibility='" + dtfinaltable.Rows[i]["Eligibility"] + "',@Attendance='" + dtfinaltable.Rows[i]["Attendance"] + "',@Sessionalmarks='" + dtfinaltable.Rows[i]["Sessionalmarks"]
                                + "',@Paper1=" + (dtfinaltable.Rows[i]["Paper1"].ToString() == "true" ? 1 : 0) + ",@Paper2=" + (dtfinaltable.Rows[i]["Paper2"].ToString() == "true" ? 1 : 0) + ",@practical=" + (dtfinaltable.Rows[i]["practical"].ToString() == "true" ? 1 : 0)
                                + ",@Amount=" + dtfinaltable.Rows[i]["Amount"] + ",@SessionId='" + Session.SessionID + "',@PID=" + NPID + ",@ApprovalStatus='" + ApprovalStatus + "',@Paper1Status='" + dtfinaltable.Rows[i]["Paper1Status"] + "|" + dtfinaltable.Rows[i]["Paper1Header"]
                                + "',@Paper2Status='" + dtfinaltable.Rows[i]["Paper2Status"] + "|" + dtfinaltable.Rows[i]["Paper2Header"] + "',@PracticalStatus='" + dtfinaltable.Rows[i]["PracticalStatus"] + "|" + "',@Paper3=" + (dtfinaltable.Rows[i]["Paper3"].ToString() == "true" ? 1 : 0) + ",@Paper3Status='" + dtfinaltable.Rows[i]["Paper3Status"] + "|" + dtfinaltable.Rows[i]["Paper3Header"]
                                + "',@AdmissionYear=" + dtfinaltable.Rows[i]["AdmissionYear"] + ",@Semester=" + dtfinaltable.Rows[i]["Semester"] + ",@Trade='" + dtfinaltable.Rows[i]["Trade"] + "',@ExamType='" + dtfinaltable.Rows[i]["ExamType"] + "',@VerifiedBy='" + Session["Username"].ToString() + "'");
                            }
                            if (!affectrows)
                            {
                                CommonUtilities.LogFileWrite("PrVerification Page Student Updation Issue:" + "exec UpdateStudentDetails @RollNumber='" + dtfinaltable.Rows[i]["RollNumber"] + "',@Eligibility='" + dtfinaltable.Rows[i]["Eligibility"] + "',@Attendance='" + dtfinaltable.Rows[i]["Attendance"] + "',@Sessionalmarks='" + dtfinaltable.Rows[i]["Sessionalmarks"]
                                + "',@Paper1=" + (dtfinaltable.Rows[i]["Paper1"].ToString() == "true" ? 1 : 0) + ",@Paper2=" + (dtfinaltable.Rows[i]["Paper2"].ToString() == "true" ? 1 : 0) + ",@practical=" + (dtfinaltable.Rows[i]["practical"].ToString() == "true" ? 1 : 0)
                                + ",@Amount=" + dtfinaltable.Rows[i]["Amount"] + ",@SessionId='" + Session.SessionID + "',@PID=" + NPID + ",@ApprovalStatus='" + ApprovalStatus + "',@Paper1Status='" + dtfinaltable.Rows[i]["Paper1Status"] + "|" + dtfinaltable.Rows[i]["Paper1Header"]
                                + "',@Paper2Status='" + dtfinaltable.Rows[i]["Paper2Status"] + "|" + dtfinaltable.Rows[i]["Paper2Header"] + "',@PracticalStatus='" + dtfinaltable.Rows[i]["PracticalStatus"] + "|" + "',@Paper3=" + (dtfinaltable.Rows[i]["Paper3"].ToString() == "true" ? 1 : 0) + ",@Paper3Status='" + dtfinaltable.Rows[i]["Paper3Status"] + "|" + dtfinaltable.Rows[i]["Paper3Header"]
                                + "',@AdmissionYear=" + dtfinaltable.Rows[i]["AdmissionYear"] + ",@Semester=" + dtfinaltable.Rows[i]["Semester"] + ",@Trade='" + dtfinaltable.Rows[i]["Trade"] + "',@ExamType='" + dtfinaltable.Rows[i]["ExamType"] + "',@VerifiedBy='" + Session["Username"].ToString() + "'");
                                break;
                            }
                        }
                    }
                    if (!affectrows)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Error Occured'); window.location='" + Request.ApplicationPath + "Principle/PrVerificationNew.aspx';", true);
                    }
                    else if (Convert.ToInt32(Session["PID"].ToString()) > 0)
                    {
                        Response.Redirect("PaymentSummary.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('No verification selected.');", true);
                    }
                    //start old code after redirect Payment Summary page
                    //if(TotalAmountforpaid>0)
                    //{
                    //    Session["PID"] = PID;
                    //    Session["Amount"] = TotalAmountforpaid;
                    //    //redirect to payment gateway
                    //}
                    //else
                    //{
                    //    if(PID>0)
                    //    {
                    //        Mysql.ExecuteNonQuery("exec UpdatePaymentStatus " + PID + ",'Offline','Yes'");
                    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Verify Successfully'); window.location='" + Request.ApplicationPath + "Principle/PrVerificationNew.aspx';", true);
                    //    }
                    //}
                    //end old code after redirect Payment Summary page
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Some Issue occure at the time of insertion');", true);
                    //}
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('ViewState is null. Please submit all information again.');", true);
                }


                //if(affectrows)
                //{
                //    BindGrid();
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Verify Successfully');", true);
                //}
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

    //protected void GetExamDetails()
    //{
    //    try
    //    {
    //        ddlexamtype.Items.Clear();
    //        ds = Mysql.GetDataSetWithQuery("exec GetExamDetails");
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            ddlexamtype.DataSource = ds;
    //            ddlexamtype.DataTextField = "ExamType";
    //            ddlexamtype.DataValueField = "Id";
    //            ddlexamtype.DataBind();
    //        }
    //        ddlexamtype.Items.Insert(0, new ListItem("-SELECT-", "0"));
    //    }
    //    catch (Exception ex)
    //    {

    //        throw;
    //    }

    //}
    //protected void GetTradeDetails(int ExamId)
    //{
    //    ddlTradeName.SelectedIndex = -1;
    //    ddlTradeName.Items.Clear();
    //    DataTable dt = new DataTable();
    //    dt = Mysql.GetDataTableWithQuery("exec GetTradeDetails @ExamId='" + ExamId + "'");
    //    if (dt!=null && dt.Rows.Count > 0)
    //    {
    //        ddlTradeName.DataSource = dt;
    //        ddlTradeName.DataTextField = "TradeName";
    //        ddlTradeName.DataValueField = "TradeName";
    //        ddlTradeName.DataBind();
    //    }
    //    ddlTradeName.Items.Insert(0, new ListItem("Select", "0"));
    //}

    //protected void ddlexamtype_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    GetTradeDetails(Convert.ToInt32(ddlexamtype.SelectedValue));
    //}
    //protected void GetSemester()
    //{
    //    ddlSemester.SelectedIndex = -1;
    //    ddlSemester.Items.Clear();
    //    ds = Mysql.GetDataSetWithQuery("exec GetSemester");
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        ddlSemester.DataSource = ds;
    //        ddlSemester.DataTextField = "Semester";
    //        ddlSemester.DataValueField = "Id";
    //        ddlSemester.DataBind();
    //    }
    //    ddlSemester.Items.Insert(0, new ListItem("-SELECT-", "0"));
    //}

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
        else
            return true;
    }


    bool isvalidategrid()
    {
        //if (ddlAdmissionYear.SelectedValue == "0")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select admission year');", true);
        //    ddlAdmissionYear.Focus();
        //    return false;
        //}
        //else
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
                                chkPaper1.Enabled = true;

                            if (Convert.ToInt32(hdnPaper2fee.Value) == 0)
                                chkPaper2.Enabled = false;
                            else
                                chkPaper2.Enabled = true;

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
                            chkPaper1.Enabled = true;
                            chkPaper2.Enabled = true;
                            chkPaper3.Enabled = true;
                            chkPractical.Enabled = true;
                        }
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
            dtgrid = Mysql.GetDataTableWithQuery("exec GetStudentDetailsForVerification_New @AdmissionYear=" + ddlAdmissionYear.SelectedValue + ",@Semester=" + ddlSemester.SelectedValue + ", @ExamType='" + ddlexamtype.SelectedValue + "', @Trade='" + ddlTradeName.SelectedItem.Text + "',@ITICode='" + Session["Username"].ToString() + "'");
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
            if (hdnrows.Value=="0")
            {
                btnGridPrevious.Visible = false;
            }
            if (dtgrid.Rows[0]["Paper1Status"].ToString().ToLower() == "yes")
                GridView1.Columns[8].HeaderText = dtgrid.Rows[0]["Paper1Header"].ToString();

            if (dtgrid.Rows[0]["Paper2Status"].ToString().ToLower() == "yes")
                GridView1.Columns[9].HeaderText = dtgrid.Rows[0]["Paper2Header"].ToString();

            if (dtgrid.Rows[0]["Paper3Status"].ToString().ToLower() == "yes")
                GridView1.Columns[10].HeaderText = dtgrid.Rows[0]["Paper3Header"].ToString();

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

            //if (dtgrid.Rows[0]["Paper4"].ToString().ToLower() == "no")
            //    GridView1.Columns[11].Visible = false;

            //if (dtgrid.Rows[0]["Paper5"].ToString().ToLower() == "no")
            //    GridView1.Columns[12].Visible = false;

            //if (Convert.ToDouble(dtgrid.Rows[0]["PracticalFees"].ToString()) == 0)
            //    GridView1.Columns[12].Visible = false;
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
        foreach(GridViewRow gvr in GridView1.Rows)
        {
            DropDownList ddlCanEligibility = (DropDownList)gvr.FindControl("ddlCanEligibility");
            DropDownList ddlAttendance = (DropDownList)gvr.FindControl("ddlAttendance");
            DropDownList ddlSessMarks = (DropDownList)gvr.FindControl("ddlSessMarks");
            CheckBox chkPaper1 = (CheckBox)gvr.FindControl("chkPaper1");
            CheckBox chkPaper2 = (CheckBox)gvr.FindControl("chkPaper2");
            CheckBox chkPaper3 = (CheckBox)gvr.FindControl("chkPaper3");
            //CheckBox chkWorkshopCalc = (CheckBox)gvr.FindControl("chkWorkshopCalc");
            //CheckBox chkEngDrawing = (CheckBox)gvr.FindControl("chkEngDrawing");
            CheckBox chkPractical = (CheckBox)gvr.FindControl("chkPractical");
            TextBox txtAmount = (TextBox)gvr.FindControl("txtAmount");
            dtupdate.Rows[i]["Eligibility"] = ddlCanEligibility.SelectedValue;
            dtupdate.Rows[i]["Attendance"] = ddlAttendance.SelectedValue;
            dtupdate.Rows[i]["Sessionalmarks"] = ddlSessMarks.SelectedValue;
            dtupdate.Rows[i]["Paper1"] = (chkPaper1.Checked ? "true" : "false");
            dtupdate.Rows[i]["Paper2"] = (chkPaper2.Checked ? "true" : "false");
            dtupdate.Rows[i]["Paper3"] = (chkPaper3.Checked ? "true" : "false");
            //dtupdate.Rows[i]["WorkshopCalcScience"] = (chkWorkshopCalc.Checked ? "true" : "false");
            //dtupdate.Rows[i]["EngineeringDrawing"] = (chkEngDrawing.Checked ? "true" : "false");
            dtupdate.Rows[i]["practical"] = (chkPractical.Checked ? "true" : "false");
            dtupdate.Rows[i]["Amount"] = txtAmount.Text;
            i++;
        }
        dtupdate.AcceptChanges();
        //hdntbledited.Value = "Yes";
        ViewState["TotalRecords"] = dtupdate;
    }
}