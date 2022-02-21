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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;

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
        string UserID = Convert.ToString(Session["UserID"]);
        DataTable dtDistrict = new DataTable();
        dtDistrict = MySql.GetDataTableWithQuery("sp_GetDistrictByUserID1 '" + UserID + "'");
        if (dtDistrict != null && dtDistrict.Rows.Count > 0)
        {
            ddldistrict.DataSource = dtDistrict;
            ddldistrict.DataTextField = "ExistsDistrict";
            ddldistrict.DataValueField = "LcaseDistrict";
            ddldistrict.DataBind();
        }
        ddldistrict.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select District", "0"));
    }

    protected void BindNameOfITI(string District)
    {
        string UserID = Convert.ToString(Session["UserID"]);
        string Username = Convert.ToString(Session["Username"]);

        ddlNameofITI.Items.Clear();
        DataTable dtITICodeName = new DataTable();
        dtITICodeName = MySql.GetDataTableWithQuery("sp_GetITINameByUserNameAndDistrict1 '" + UserID + "', '" + District + "'");
        if (dtITICodeName != null && dtITICodeName.Rows.Count > 0)
        {
            ddlNameofITI.DataSource = dtITICodeName;
            ddlNameofITI.DataTextField = "ITIName";
            ddlNameofITI.DataValueField = "ITICode";
            ddlNameofITI.DataBind();
        }
        ddlNameofITI.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
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
        ddlTradeName.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));

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
            string filename = "	NodalDetailedReport";
            string attachment = "attachment; filename=" + filename + ".xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/excel";
            StringWriter stw = new StringWriter();
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            GridView dgGrid = new GridView();
            if (ddlentrytype.SelectedValue != "ED" && ddlSemester.SelectedValue == "2")
            {

            }
            else
            {
                dtCloned.Columns.RemoveAt(2);
                dtCloned.AcceptChanges();
            }
            dgGrid.DataSource = dtCloned;
            dgGrid.DataBind();

            dgGrid.RenderControl(htextw);
            Response.Write(stw.ToString());
            Response.End();
        }
    }

    protected void btnExportToPDF_Click(object sender, EventArgs e)
    {
        try
        {
            if (isvalidate())
            {
                ExportToPDF();
            }
        }
        catch (Exception ex)
        {
            errlog.LogError(ex);
        }
    }

    public void ExportToPDF()
    {
        DataSet Ds = new DataSet();
        Ds = MySql.GetDataSetWithQuery("Exec getDetailedJDReports @AdmissionYear=" + ddlAdmissionYear.SelectedValue + ",@Semester=" + ddlSemester.SelectedValue + ", @ExamType='" + ddlexamtype.SelectedValue + "', @Trade=" + ddlTradeName.SelectedValue + ",@ITICode='" + ddlNameofITI.SelectedValue + "', @Division='" + Session["Zone"].ToString() + "', @District='" + ddldistrict.SelectedValue + "', @EntryType='" + ddlentrytype.SelectedValue + "'");
        if (Ds.Tables[0].Rows.Count > 0)
        {
            //DataTable dtCloned = Ds.Tables[0];
            //string filename = "	JDDetailedReport";
            //string attachment = "attachment; filename=" + filename + ".pdf";
            //Response.ClearContent();
            //Response.AddHeader("content-disposition", attachment);
            //Response.ContentType = "application/pdf";
            //StringWriter stw = new StringWriter();
            //HtmlTextWriter htextw = new HtmlTextWriter(stw);
            //GridView dgGrid = new GridView();
            //if (ddlentrytype.SelectedValue != "ED" && ddlSemester.SelectedValue == "2")
            //{

            //}
            //else
            //{
            //    dtCloned.Columns.RemoveAt(2);
            //    dtCloned.AcceptChanges();
            //}
            //dgGrid.DataSource = dtCloned;
            //dgGrid.DataBind();

            //dgGrid.RenderControl(htextw);
            //Response.Write(stw.ToString());
            //Response.End();
            string filename = "	NodalDetailedReport";
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition",
             "attachment;filename=" + filename + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            DataTable dtCloned = Ds.Tables[0];
            GridView dgGrid = new GridView();
            if (ddlentrytype.SelectedValue != "ED" && ddlSemester.SelectedValue == "2")
            {

            }
            else
            {
                dtCloned.Columns.RemoveAt(2);
                dtCloned.AcceptChanges();
            }
            dgGrid.DataSource = dtCloned;
            dgGrid.DataBind();
            //GridView1.AllowPaging = false;
            //GridView1.DataBind();
            //GridView1.RenderControl(hw);
            dgGrid.AllowPaging = false;
            dgGrid.DataBind();
            dgGrid.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
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
            if (ddlentrytype.SelectedValue != "ED" && (ddlSemester.SelectedValue == "2" || ddlSemester.SelectedValue == "0"))
            {
                GridView1.Columns[2].Visible = true;
            }
            else
            {
                GridView1.Columns[2].Visible = false;
            }
            btnExportToExcel.Visible = true;
           // btnExportToPDF.Visible = true;
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            lblCMessage.Text = "No data found";
            btnExportToExcel.Visible = false;
            //btnExportToPDF.Visible = false;
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
    protected void ddlAdmissionYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAdmissionYear.SelectedValue == "2018")
        {
            lblSemester.Text = "Year";
            ddlSemester.Items.Clear();
            ddlSemester.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "0"));
            ddlSemester.Items.Add(new System.Web.UI.WebControls.ListItem("1st Year", "2"));
            ddlSemester.Items.Add(new System.Web.UI.WebControls.ListItem("2nd Year", "4"));
        }
        else
        {
            lblSemester.Text = "Semester";
            ddlSemester.Items.Clear();
            ddlSemester.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "0"));
            ddlSemester.Items.Add(new System.Web.UI.WebControls.ListItem("Sem1", "1"));
            ddlSemester.Items.Add(new System.Web.UI.WebControls.ListItem("Sem2", "2"));
            ddlSemester.Items.Add(new System.Web.UI.WebControls.ListItem("Sem3", "3"));
            ddlSemester.Items.Add(new System.Web.UI.WebControls.ListItem("Sem4", "4"));

        }
    }
}