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

public partial class Admin_AdminStudentVerification : System.Web.UI.Page
{
    CommonPerception Mysql = new CommonPerception();
    DataTable dtgrid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
            Response.Redirect("../Login/LoginNew.aspx");
        else
            lblUName.Text = "Welcome " + Session["Username"].ToString();

        //if (!IsPostBack)
        //{
            CheckLoginTime();
       // }
        if (!IsPostBack)
        {
            BindDivisionList();
            BindITINameList();
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
    private void BindDivisionList()
    {
        DataTable dtDivision = new DataTable();
        dtDivision = Mysql.GetDataTableWithQuery("exec GetAllDivisionList ");
        if (dtDivision != null && dtDivision.Rows.Count > 0)
        {
            ddlDivision.DataSource = dtDivision;
            ddlDivision.DataTextField = "Division";
            ddlDivision.DataValueField = "LcaseDivision";
            ddlDivision.DataBind();
        }
        ddlDivision.Items.Insert(0, new ListItem("Select", "0"));
        ddlDistrict.Items.Insert(0, new ListItem("Select", "0"));
    }
    private void BindITINameList()
    {
        DataTable dtITICodeName = new DataTable();
        dtITICodeName = Mysql.GetDataTableWithQuery("exec GetITICodeName @ExistsZone='" + ddlDivision.SelectedValue.ToString() + "',@District='" + ddlDistrict.SelectedValue.ToString() + "'");
        if (dtITICodeName != null && dtITICodeName.Rows.Count > 0)
        {
            ddlITICode.DataSource = dtITICodeName;
            ddlITICode.DataTextField = "ItiCodeName";
            ddlITICode.DataValueField = "ITICode";
            ddlITICode.DataBind();
        }
        ddlITICode.Items.Insert(0, new ListItem("Select", "0"));
    }
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlDistrict.Items.Clear();
        if (ddlDivision.SelectedIndex > 0)
        {
            DataTable dtDistrict = new DataTable();
            dtDistrict = Mysql.GetDataTableWithQuery("exec GetDistList '" + ddlDivision.SelectedValue.ToString() + "'");
            if (dtDistrict != null && dtDistrict.Rows.Count > 0)
            {
                ddlDistrict.DataSource = dtDistrict;
                ddlDistrict.DataTextField = "District";
                ddlDistrict.DataValueField = "LcaseDistrict";
                ddlDistrict.DataBind();
            }
        }
        ddlDistrict.Items.Insert(0, new ListItem("Select", "0"));
        BindITINameList();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (isvalidate())
            {
                ViewState["TotalRecords"] = null;
                hdnrows.Value = "0";
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
        if (ddlDivision.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select Zone');", true);
            ddlDivision.Focus();
            return false;
        }
        else if (ddlDistrict.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select District');", true);
            ddlDistrict.Focus();
            return false;
        }
        else if (ddlITICode.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select ITI Name');", true);
            ddlITICode.Focus();
            return false;
        }
        else if (ddlStatus.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select Status');", true);
            ddlStatus.Focus();
            return false;
        }
        else
            return true;
    }
    protected void BindGrid()
    {
        if (ViewState["TotalRecords"] == null)
        {
            dtgrid = new DataTable();
            dtgrid = Mysql.GetDataTableWithQuery("exec GetStudentStatusForVerificationAdmin @Division='" + ddlDivision.SelectedValue + "', @District='" + ddlDistrict.SelectedValue + "', @ITICode='" + ddlITICode.SelectedValue + "', @ApprovalStatus='" + ddlStatus.SelectedValue + "'");
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
            int PageSize = Convert.ToInt32(WebConfigurationManager.AppSettings["PageSize"].ToString());

            if ((dtgrid.Rows.Count - Convert.ToInt32(hdnrows.Value)) > PageSize)
            {
                dtgrid = dtgrid.AsEnumerable().Skip(Convert.ToInt32(hdnrows.Value)).Take(PageSize).CopyToDataTable();
                if (dtgrid.Rows[0]["ApprovalStatus"].ToString().ToLower() == "discharged")
                {
                    btnNext.Visible = false;
                    btnGridNext.Visible = true;
                }
                else
                {
                    btnNext.Visible = true;
                    btnGridNext.Visible = false;
                }
                btnSave.Visible = false;
                btnGridPrevious.Visible = true;
            }
            else
            {
                dtgrid = dtgrid.AsEnumerable().Skip(Convert.ToInt32(hdnrows.Value)).Take(dtgrid.Rows.Count).CopyToDataTable();
                if (dtgrid.Rows[0]["ApprovalStatus"].ToString().ToLower() == "discharged")
                {
                    btnSave.Visible = true;
                }
                else
                {
                    btnSave.Visible = false;
                }
                btnNext.Visible = false;
                btnGridNext.Visible = false;
                btnGridPrevious.Visible = true;
            }
            if (hdnrows.Value == "0")
            {

                //if (dtgrid.Rows[0]["ApprovalStatus"].ToString().ToLower() == "discharged")
                //{
                //    btnSave.Visible = true;
                //}
                //else
                //{
                //    btnSave.Visible = false;
                //}
                btnGridPrevious.Visible = false;
            }

            GridView1.DataSource = dtgrid;
            GridView1.DataBind();
            lblCMessage.Text = "";
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            btnSave.Visible = false;
            btnGridPrevious.Visible = false;
            btnGridNext.Visible = false;
            lblCMessage.Text = "Sorry, No record found";
            btnNext.Visible = false;
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
    protected void btnNext_Click(object sender, EventArgs e)
    {
        int PageSize = Convert.ToInt32(WebConfigurationManager.AppSettings["PageSize"].ToString());
        hdnrows.Value = (Convert.ToInt32(hdnrows.Value) + PageSize).ToString();
        BindGrid();
    }
    private void Updateintable()
    {
        int i = Convert.ToInt32(hdnrows.Value);
        DataTable dtupdate = (DataTable)ViewState["TotalRecords"];
        foreach (GridViewRow gvr in GridView1.Rows)
        {
            DropDownList ddlCanEligibility = (DropDownList)gvr.FindControl("ddlCanEligibility");
            dtupdate.Rows[i]["Eligibility"] = ddlCanEligibility.SelectedValue;
            i++;
        }
        dtupdate.AcceptChanges();
        ViewState["TotalRecords"] = dtupdate;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (isvalidategrid())
        {
            Updateintable();
            bool affectrows = false;
            if (ViewState["TotalRecords"] != null)
            {
                DataTable dtfinaltable = (DataTable)ViewState["TotalRecords"];
                string ApprovalStatus = string.Empty;
                for (int i = 0; i < dtfinaltable.Rows.Count; i++)
                {
                    if (dtfinaltable.Rows[i]["Eligibility"].ToString() != "0")
                    {
                        if (dtfinaltable.Rows[i]["Eligibility"].ToString().ToLower() == "for verification")
                            ApprovalStatus = "Approved";
                        else if (dtfinaltable.Rows[i]["Eligibility"].ToString().ToLower() == "for non-verification")
                            ApprovalStatus = "Approval Pending";

                        affectrows = Mysql.ExecuteNonQuery("exec UpdateStudentStatusbyAdmin @RollNumber='" + dtfinaltable.Rows[i]["RollNumber"] + "',@Eligibility='" + dtfinaltable.Rows[i]["Eligibility"] + "',@ApprovalStatus='" + ApprovalStatus + "',@AdmissionYear=" + dtfinaltable.Rows[i]["AdmissionYear"] + ",@Semester=" + dtfinaltable.Rows[i]["Semester"] + ",@Trade='" + dtfinaltable.Rows[i]["Trade"] + "',@ExamType='" + dtfinaltable.Rows[i]["ExamType"] + "',@UpdatedByAdmin='" + Session["Username"].ToString() + "'");
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('ViewState is null. Please submit all information again.');", true);
            }

            if (affectrows)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Verify Successfully');", true);
                btnSubmit_Click(sender, e);
            }
        }
    }
    bool isvalidategrid()
    {
        DateTime VerificationDate = Convert.ToDateTime(WebConfigurationManager.AppSettings["VerificationDate"].ToString());
        int result = DateTime.Compare(DateTime.Now.Date, VerificationDate);
        if (result>0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Date for this module has been expired');", true);
            return false;
        }
        //foreach(GridViewRow gvr in GridView1.Rows)
        //{
        //    DropDownList ddlCanEligibility = (DropDownList)gvr.FindControl("ddlCanEligibility");
        //    if (ddlCanEligibility.SelectedValue == "0")
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select candidates eligibility');", true);
        //        ddlCanEligibility.Focus();
        //        return false;
        //    }
        //}
        return true;
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hdnApprovalStatus = (HiddenField)e.Row.FindControl("hdnApprovalStatus");
            DropDownList ddlCanEligibility = (DropDownList)e.Row.FindControl("ddlCanEligibility");
            Label lblCanEligibility = (Label)e.Row.FindControl("lblCanEligibility");
            if (hdnApprovalStatus.Value.ToLower() == "discharged")
            {
                lblCanEligibility.Visible = false;
                ddlCanEligibility.Visible = true;
                ddlCanEligibility.SelectedValue = lblCanEligibility.Text;
            }
            else
            {
                lblCanEligibility.Visible = true;
                ddlCanEligibility.Visible = false;
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
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindITINameList();
    }
}