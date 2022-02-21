using Common.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_UpdateCanInfo : System.Web.UI.Page
{
    public enum Operation { Search, Edit, Cancel }
    CommonPerception Mysql = new CommonPerception();
    protected void Page_Load(object sender, EventArgs e)
    {
        string UserName = Convert.ToString(Session["Username"]);
        //if (UserName != "Operation")
        //{
        //    Response.Redirect("../Login/LoginNew.aspx");
        //}

        if (!IsPostBack)
        {
            //GetTrade();
            //GetITIData();
        }
    }

    private void GetTrade()
    {
        DataSet ds = Mysql.GetDataSet("Select distinct TradeId, TradeName Trade from TradeMaster");
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                ViewState["tblTrade"] = ds.Tables[0];
            }
        }
    }
    private void GetITIData()
    {
        DataSet ds = Mysql.GetDataSet("Select * from ITIMasterdata");
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                ViewState["ITIMasterdata"] = ds.Tables[0];
            }
        }
    }
    protected void lnklogout_Click(object sender, EventArgs e)
    {
        //Mysql.UpdateSingleLogin(Session["Username"].ToString(), Convert.ToInt32(Session["UserType"].ToString()), 0);
        //Session.Abandon();
        //Session.Clear();
        //Response.Redirect("../Login/Logout.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGridView(Operation.Search);
    }
    private void BindGridView(Operation Operation)
    {
        try
        {
            if (Operation == Operation.Search)
            {
                gvData.EditIndex = -1;
                //gvDataDiff.EditIndex = -1;
            }
            DataTable dt = new DataTable();
            string RollNo = txtSearch.Text.Trim();
            DataSet ds = Mysql.GetDataSet("sp_getCandidateData '" + RollNo + "'");
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0].Clone();
                    dt.ImportRow(ds.Tables[0].Rows[0]);
                    gvData.DataSource = dt;
                    gvData.DataBind();

                    //gvDataDiff.DataSource = ds.Tables[0];
                    //gvDataDiff.DataBind();
                }
            }
        }
        catch (Exception ex)
        { }
    }
    protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DropDownList ddlTrade = (DropDownList)e.Row.FindControl("ddlTrade");
                if (ddlTrade != null)
                {
                    if (ViewState["tblTrade"] == null)
                    {
                        GetTrade();
                    }
                    ddlTrade.DataSource = (DataTable)ViewState["tblTrade"];
                    ddlTrade.DataTextField = "Trade";
                    ddlTrade.DataValueField = "Trade";
                    ddlTrade.DataBind();
                    string selectedCity = DataBinder.Eval(e.Row.DataItem, "Trade").ToString();
                    ddlTrade.Items.FindByText(selectedCity).Selected = true;
                }

                DropDownList ddlITICode = (DropDownList)e.Row.FindControl("ddlITICode");
                if (ddlITICode != null)
                {
                    if (ViewState["ITIMasterdata"] == null)
                    {
                        GetITIData();
                    }
                    ddlITICode.DataSource = (DataTable)ViewState["ITIMasterdata"];
                    ddlITICode.DataTextField = "UserID";
                    ddlITICode.DataValueField = "UserID";
                    ddlITICode.DataBind();
                    string selectedCity = DataBinder.Eval(e.Row.DataItem, "ITICode").ToString();
                    ddlITICode.Items.FindByText(selectedCity).Selected = true;
                }
            }
        }
    }

    protected void gvData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            if (((GridView)(sender)).ID == "gvData")
            {
                gvData.EditIndex = e.NewEditIndex;
                GridViewRow row = gvData.Rows[e.NewEditIndex];
            }
            else
            {
                //gvDataDiff.EditIndex = e.NewEditIndex;
            }
            this.BindGridView(Operation.Edit);
        }
        catch (Exception ex)
        { }
    }
    protected void gvData_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = gvData.Rows[e.RowIndex];
        int UserID = Convert.ToInt32(gvData.DataKeys[e.RowIndex].Values[0]);
        string Name = (row.FindControl("txtName") as TextBox).Text;
        string txtName = (row.FindControl("txtName") as TextBox).Text;
        string txtRollNumber = (row.FindControl("txtRollNumber") as TextBox).Text;
        string txtFatherName = (row.FindControl("txtFatherName") as TextBox).Text;
        string txtMotherName = (row.FindControl("txtMotherName") as TextBox).Text;
        string txtDOB = (row.FindControl("txtDOB") as TextBox).Text;
        string ddlGender = (row.FindControl("ddlGender") as DropDownList).SelectedValue;
        string ddlCategory = (row.FindControl("ddlCategory") as DropDownList).SelectedValue;
        //string txtITIName = (row.FindControl("txtITIName") as Label).Text;
        //string ddlTTIType = (row.FindControl("ddlTTIType") as DropDownList).SelectedValue;
        //string ddlITICode = (row.FindControl("ddlITICode") as DropDownList).SelectedValue;
        //string txtDivision = (row.FindControl("txtDivision") as TextBox).Text;
        //string txtDistrict = (row.FindControl("txtDistrict") as TextBox).Text;
        //string txtExistsZone = (row.FindControl("txtExistsZone") as Label).Text;
        //string txtExistsDistrict = (row.FindControl("txtExistsDistrict") as Label).Text;
        //string txtEligibility = (row.FindControl("ddlEligibility") as DropDownList).Text;
        //string ddlAdmissionYear = (row.FindControl("ddlAdmissionYear") as DropDownList).SelectedValue;
        //string ddlTrade = (row.FindControl("ddlTrade") as DropDownList).SelectedValue;

        if (txtName == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter Name.');", true);
            return;
        }
        if (txtFatherName == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter FatherName.');", true);
            return;
        }
        if (txtMotherName == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter MotherName.');", true);
            return;
        }
        if (txtDOB == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter DOB.');", true);
            return;
        }
        try
        {
            Convert.ToDateTime(txtDOB);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select valid DOB.');", true);
            return;
        }

        if (ddlGender == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter Gender.');", true);
            return;
        }
        if (ddlCategory == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter Category.');", true);
            return;
        }
        //if (txtITIName == "")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter ITIName.');", true);
        //    return;
        //}
        //if (ddlTTIType == "")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter TTIType.');", true);
        //    return;
        //}
        //if (ddlTTIType.ToUpper() == "GOVT" || ddlTTIType.ToUpper() == "PVT")
        //{

        //}
        //else
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select GOVT/PVT TTIType only.');", true);
        //    return;
        //}

        //if (ddlITICode == "")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter ITICode.');", true);
        //    return;
        //}
        //if (txtDivision == "")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter Division.');", true);
        //    return;
        //}
        //if (txtDistrict == "")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter District.');", true);
        //    return;
        //}
        //if (txtExistsZone == "")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter ExistsZone.');", true);
        //    return;
        //}
        //if (txtExistsDistrict == "")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter ExistsDistrict.');", true);
        //    return;
        //}
        //if (txtEligibility == "")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter Eligibility.');", true);
        //    return;
        //}
        //if (ddlAdmissionYear == "")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter AdmissionYear.');", true);
        //    return;
        //}
        //if (ddlTrade == "")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter Trade.');", true);
        //    return;
        //}

        int Updated = Mysql.SingleCellResult("Update tbl_Student Set Name = '" + txtName + "',FatherName = '" + txtFatherName + "',MotherName = '" + txtMotherName
            + "',DOB = '" + txtDOB + "',Gender = '" + ddlGender + "',Category = '" + ddlCategory + "' Where RollNumber = '" + txtRollNumber + "' SELECT @@ROWCOUNT");


        if (Updated <= 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Unable to Save.');", true);
            return;
        }
        else
        {
            gvData.EditIndex = -1;
            this.BindGridView(Operation.Edit);
        }

    }
    protected void gvData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            if (((GridView)(sender)).ID == "gvData")
            {
                gvData.EditIndex = -1;
            }
            else
            {
                //gvDataDiff.EditIndex = -1;
            }
            this.BindGridView(Operation.Cancel);
        }
        catch (Exception ex)
        { }
    }
    protected void gvDataDiff_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = gvDataDiff.Rows[e.RowIndex];
        int Id = Convert.ToInt32(gvDataDiff.DataKeys[e.RowIndex].Values[0]);
        string ddlSemester = (row.FindControl("ddlSemester") as DropDownList).SelectedValue;
        string ddlExamType = (row.FindControl("ddlExamType") as DropDownList).SelectedValue;
        string ddlBeforePaper1 = (row.FindControl("ddlBeforePaper1") as DropDownList).SelectedValue;

        if (ddlBeforePaper1 == "Yes")
            ddlBeforePaper1 = "";
        else
            ddlBeforePaper1 = "0";

        string ddlBeforePaper2 = (row.FindControl("ddlBeforePaper2") as DropDownList).SelectedValue;
        if (ddlBeforePaper2 == "Yes")
            ddlBeforePaper2 = "";
        else
            ddlBeforePaper2 = "0";

        string ddlBeforePaper3 = (row.FindControl("ddlBeforePaper3") as DropDownList).SelectedValue;
        if (ddlBeforePaper3 == "Yes")
            ddlBeforePaper3 = "";
        else
            ddlBeforePaper3 = "0";

        string ddlBeforePaper4 = (row.FindControl("ddlBeforePaper4") as DropDownList).SelectedValue;
        if (ddlBeforePaper4 == "Yes")
            ddlBeforePaper4 = "";
        else
            ddlBeforePaper4 = "0";

        int Updated = Mysql.SingleCellResult("Update tbl_Student Set ExamType = '" + ddlExamType + "',chkPaper1 = '" + ddlBeforePaper1 + "',chkPaper2 = '"
            + ddlBeforePaper2 + "',chkPaper3 = '" + ddlBeforePaper3 + "',chkPractical = '" + ddlBeforePaper4 + "' WHERE id = '" + Id + "' and Semester = '" + ddlSemester + "' SELECT @@ROWCOUNT");

        if (Updated <= 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Unable to Save.');", true);
            return;
        }
        else
        {
            gvDataDiff.EditIndex = -1;
            this.BindGridView(Operation.Edit);
        }


    }
    protected void gvDataDiff_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void ddlITICode_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvData.Rows)
        {
            string ddlITICode = (row.FindControl("ddlITICode") as DropDownList).SelectedValue;
            if (ViewState["ITIMasterdata"] == null)
            {
                GetITIData();
            }
            DataTable ITIMasterdata = (DataTable)ViewState["ITIMasterdata"];
            DataRow[] dr = ITIMasterdata.Select("UserID = '" + ddlITICode + "'");
            if (dr.Length > 0)
            {
                (row.FindControl("txtITIName") as Label).Text = Convert.ToString(dr[0].ItemArray[4]);
                (row.FindControl("txtExistsZone") as Label).Text = Convert.ToString(dr[0].ItemArray[1]);
                (row.FindControl("txtExistsDistrict") as Label).Text = Convert.ToString(dr[0].ItemArray[2]);
            }

        }
    }
}