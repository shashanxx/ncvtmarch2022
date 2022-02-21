using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Class;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;
using System.Web.Mail;

public partial class Admin_JoinDirectorAdminReports : ClsErrorLog
{
    CommonPerception MySql = new CommonPerception();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
        {
            Response.Redirect("../Login/LoginNew.aspx");
        }
        if (!IsPostBack)
        {
            lblUName.Text = "Welcome " + Convert.ToString(Session["Username"]);
            BindTradeName();
        }
        divreports.Visible = false;
        btnprint.Visible = false;
    }

    protected void BindTradeName()
    {
        DataTable dtTrade = new DataTable();
        dtTrade = MySql.GetDataTableWithQuery("select distinct tm.Tradeid,tm.TradeName from tbl_Student ts join TradeMaster tm on lower(ts.Trade)=lower(tm.TradeName) where TradetypeID in (2,3) order by TradeName");
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
            ddlTradeName.Items.Remove(ddlTradeName.Items.FindByValue("33"));
            ddlTradeName.Items.Remove(ddlTradeName.Items.FindByValue("34"));
            ddlTradeName.Items.Remove(ddlTradeName.Items.FindByValue("29"));

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
            if (isvalidate())
            {
                Fillgrid();
            }
        }
        catch (Exception ex)
        {
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
        //if (ddlSemester.SelectedValue == "0")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Semester');", true);
        //    ddlSemester.Focus();
        //    return false;
        //}
        //if (ddlTradeName.SelectedValue == "0")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Trade Name');", true);
        //    ddlTradeName.Focus();
        //    return false;
        //}
        //if (ddlAdmissionYear.SelectedValue == "YEAR")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Admission Year');", true);
        //    ddlAdmissionYear.Focus();
        //    return false;
        //}
        if (ddlexamtype.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Exam Type');", true);
            ddlexamtype.Focus();
            return false;
        }
        return true;
    }

    public void Fillgrid()
    {
        DataSet ds = new DataSet();
        ds = MySql.GetDataSetWithQuery("Exec getAdminPracticalMarksSummaryReports @AdmissionYear=" + ddlAdmissionYear.SelectedValue + ",@Semester=" + ddlSemester.SelectedValue + ", @ExamType='" + ddlexamtype.SelectedValue + "', @Trade=" + ddlTradeName.SelectedValue + ",@EntryType='" + ddlentrytype.SelectedValue + "'");

        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
            divreports.Visible = true;
            btnprint.Visible = true;
            lblCMessage.Text = "";
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            divreports.Visible = false;
            btnprint.Visible = false;
            lblCMessage.Text = "No data found";
        }
    }

    protected void ddlentrytype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try { 
        BindTradeName();
        if (ddlentrytype.SelectedValue == "ED")
            ddlSemester.Items.FindByValue("1").Enabled = false;
        else
            ddlSemester.Items.FindByValue("1").Enabled = true;
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnprint_Click(object sender, EventArgs e)
    {
        try
        {
            divreports.Visible = true;
            HtmlForm form = new HtmlForm();

            string attachment = "attachment; filename=ITIAdminPracticalSummaryReports.xls";

            Response.ClearContent();

            Response.AddHeader("content-disposition", attachment);

            Response.ContentType = "application/ms-excel";

            StringWriter stw = new StringWriter();

            HtmlTextWriter htextw = new HtmlTextWriter(stw);

            form.Controls.Add(divreports);

            this.Controls.Add(form);

            form.RenderControl(htextw);

            Response.Write(stw.ToString());

            Response.End();

        }
        catch (Exception ex)
        {
            string sss = ex.ToString();
        }
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Login/LoginNew.aspx");
    }
    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("../Login/LoginNew.aspx");
    }

    protected void ddlAdmissionYear_SelectedIndexChanged(object sender, EventArgs e)
    {
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