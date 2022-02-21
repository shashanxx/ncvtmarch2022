using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Class;
using System.Data;
using System.Net;
using System.IO;
using System.Threading;
using System.Data.SqlClient;


public partial class Center_Joindirector : System.Web.UI.Page
{
    ClsErrorLog errlog = new ClsErrorLog();
    CommonPerception MySql = new CommonPerception();
    DataSet ds = new DataSet();
    string tradetype1 = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
        {
            Response.Redirect("../Login/LoginNew.aspx");
        }
        if (!IsPostBack)
        {
            lblUName.Text = "Welcome " + Convert.ToString(Session["Username"]);
            DataTable dt = new DataTable();
            dt = MySql.GetDataTableWithQuery("select * from  tbl_User_Profile where Name='" + Session["Username"].ToString() + "'");
            Session["Zone"] = Convert.ToString(dt.Rows[0]["zone"]); 
            HiddenField2.Value = Session["Username"].ToString();
            BindDistrict();
            BindNameOfITI("0");
            BindTradeName();
        }
    }

    protected void BindDistrict()
    {
        DataTable dtDistrict = new DataTable();
        dtDistrict = MySql.GetDataTableWithQuery("exec GetAllDistrictListbyZone @UserName='" + Session["Username"].ToString() + "',@UserType=" + Session["UserType"].ToString() + ",@UserTypeId=" + Session["UserTypeId"] + "");
        if (dtDistrict != null && dtDistrict.Rows.Count > 0)
        {
            ddldistrict.DataSource = dtDistrict;
            ddldistrict.DataTextField = "ExistsDistrict";
            ddldistrict.DataValueField = "LcaseDistrict";
            ddldistrict.DataBind();
        }
        ddldistrict.Items.Insert(0, new ListItem("Select District", "0"));
    }

    protected void BindNameOfITI(string District)
    {
        ddlNameofITI.Items.Clear();
        DataTable dtITICodeName = new DataTable();
        dtITICodeName = MySql.GetDataTableWithQuery("exec GetAllITINamebyZone @UserName='" + Session["Username"].ToString() + "',@UserType=" + Session["UserType"].ToString() + ",@UserTypeId=" + Session["UserTypeId"] + ",@ExistsDistrict='" + District + "'");
        if (dtITICodeName != null && dtITICodeName.Rows.Count > 0)
        {
            ddlNameofITI.DataSource = dtITICodeName;
            ddlNameofITI.DataTextField = "ITIName";
            ddlNameofITI.DataValueField = "ITICode";
            ddlNameofITI.DataBind();
        }
        ddlNameofITI.Items.Insert(0, new ListItem("Select", "0"));
    }

    protected void BindTradeName()
    {
        DataTable dtTrade = new DataTable();
        dtTrade = MySql.GetDataTableWithQuery("exec GetAllTradeListJD  @District='" + ddldistrict.SelectedValue.ToString() + "',@ITICode='" + ddlNameofITI.SelectedValue.ToString() + "'");
        if (dtTrade != null && dtTrade.Rows.Count > 0)
        {
            ddlTradeName.DataSource = dtTrade;
            ddlTradeName.DataTextField = "TradeName";
            ddlTradeName.DataValueField = "Tradeid";
            ddlTradeName.DataBind();
        }
        ddlTradeName.Items.Insert(0, new ListItem("Select", "0"));

        if (ddlentrytype.SelectedValue == "ED")
        {
            ddlTradeName.Enabled = true;
        }
        else
        {
            ddlTradeName.Enabled = false;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            lblCMessage.Text = "";
            if (isvalidate())
            {
                FillGrid();
            }
        }
        catch (Exception ex)
        {
            errlog.LogError(ex);
        }
    }

    bool isvalidate()
    {
        if (ddlentrytype.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Entry Type');", true);
            ddlentrytype.Focus();
            return false;
        }
        if (ddlexamtype.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Exam Type');", true);
            ddlexamtype.Focus();
            return false;
        }
        return true;
    }

    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            if (isvalidate())
            {
                ExportToExcel();
            }
        }
        catch (Exception ex)
        {
            errlog.LogError(ex);
        }
    }

    public void ExportToExcel()
    {
        DataSet Ds = new DataSet();
        Ds = MySql.GetDataSetWithQuery("Exec getDetailedJDReports @AdmissionYear=" + ddlAdmissionYear.SelectedValue + ",@Semester=" + ddlSemester.SelectedValue + ", @ExamType='" + ddlexamtype.SelectedValue + "', @Trade=" + ddlTradeName.SelectedValue + ",@ITICode='" + ddlNameofITI.SelectedValue + "', @Division='" + Session["Zone"].ToString() + "', @District='" + ddldistrict.SelectedValue + "', @EntryType='" + ddlentrytype.SelectedValue + "'");
        if (Ds.Tables[0].Rows.Count > 0)
        {
            DataTable dtCloned = Ds.Tables[0];
            string filename = "	JDDetailedReport";
            string attachment = "attachment; filename=" + filename + ".xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/excel";
            StringWriter stw = new StringWriter();
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            GridView dgGrid = new GridView();
            dgGrid.DataSource = dtCloned;
            dgGrid.DataBind();            
            dgGrid.RenderControl(htextw);
            Response.Write(stw.ToString());
            Response.End();
        }
    }

    void FillGrid()
    {
        DataSet Ds = new DataSet();
        Ds = MySql.GetDataSetWithQuery("Exec getDetailedJDReports @AdmissionYear=" + ddlAdmissionYear.SelectedValue + ",@Semester=" + ddlSemester.SelectedValue + ", @ExamType='" + ddlexamtype.SelectedValue + "', @Trade=" + ddlTradeName.SelectedValue + ",@ITICode='" + ddlNameofITI.SelectedValue + "', @Division='" + Session["Zone"].ToString() + "', @District='" + ddldistrict.SelectedValue + "', @EntryType='" + ddlentrytype.SelectedValue + "'");
        if (Ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = Ds;
            GridView1.DataBind();
            btnExportToExcel.Visible = true;
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            lblCMessage.Text = "No data found";
        }
    }

    protected void checkAll_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox ChkBoxHeader = (CheckBox)GridView1.HeaderRow.FindControl("checkAll");
            foreach (GridViewRow row in GridView1.Rows)
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
            errlog.LogError(ex);
        }
    }

    protected void btnExit_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Abandon();
            Response.Redirect("../Login/LoginNew.aspx");
        }
        catch (Exception ex)
        {
            errlog.LogError(ex);
        }
    }

    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindNameOfITI(ddldistrict.SelectedValue);
    }

    protected void ddlNameofITI_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTradeName();
    }

    protected void ddlentrytype_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTradeName();
        if (ddlentrytype.SelectedValue == "ED")
            ddlSemester.Items.FindByValue("1").Enabled = false;
        else
            ddlSemester.Items.FindByValue("1").Enabled = true;
    }

    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("../Login/LoginNew.aspx");
    }
}