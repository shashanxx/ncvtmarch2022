using Common.Class;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Principle_DownloadAdmitCard : System.Web.UI.Page
{
    CommonPerception Mysql = new CommonPerception();
    DataTable dtgrid;
    ClsErrorLog errlog = new ClsErrorLog();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
            Response.Redirect("../Login/LoginNew.aspx");
        else
            lblUName.Text = "Welcome " + Session["Username"].ToString();

        CheckLoginTime();

        if (!IsPostBack)
        {
            bindyear();
            BindTradeList();
            HiddenField2.Value = Session["Username"].ToString();
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
    private void bindyear()
    {
        ddlAdmissionYear.Items.Add(new ListItem("Select", "0"));
        for (int i = DateTime.Now.Year - 4; i < DateTime.Now.Year; i++)
        {
            ddlAdmissionYear.Items.Add(i.ToString());
        }
    }
    private void BindTradeList()
    {
        DataTable dtTrade = new DataTable();
        dtTrade = Mysql.GetDataTableWithQuery("exec GetSessionalTradeList @ITICode='" + Session["Username"].ToString() + "'");
        if (dtTrade != null && dtTrade.Rows.Count > 0)
        {
            ddlTradeName.DataSource = dtTrade;
            ddlTradeName.DataTextField = "TradeName";
            ddlTradeName.DataValueField = "Tradeid";
            ddlTradeName.DataBind();
        }
        ddlTradeName.Items.Insert(0, new ListItem("Select", "0"));
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (isvalidate())
        {
            FillGrid();
        }
    }      

    bool isvalidate()
    {
        //if (ddlexamtype.SelectedValue == "0")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Exam Type');", true);
        //    ddlexamtype.Focus();
        //    return false;
        //}
        return true;
    }

    void FillGrid()
    {
        DataSet Ds = new DataSet();
        Ds = Mysql.GetDataSetWithQuery("Exec getDetailedSessionalReports @AdmissionYear=" + ddlAdmissionYear.SelectedValue + ",@Semester=" + ddlSemester.SelectedValue + ", @ExamType='" + ddlexamtype.SelectedValue + "', @Trade=" + ddlTradeName.SelectedValue + ",@ITICode='" + Session["Username"].ToString() + "'");
        if (int.Parse(ddlAdmissionYear.SelectedValue.ToString()) <= 2017)
        {
            div_sem.Visible = true;
            div_year.Visible = false;
            if (Ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = Ds;
                GridView1.DataBind();
                btnExportToExcel.Visible = true;
                lblCMessage.Text = "";
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                btnExportToExcel.Visible = false;
                lblCMessage.Text = "No data found";
            }
        }
        else
        {
            div_sem.Visible = false;
            div_year.Visible = true;
            if (Ds.Tables[0].Rows.Count > 0)
            {
                GridView2.DataSource = Ds;
                GridView2.DataBind();
                btnExportToExcel.Visible = true;
                lblCMessage.Text = "";
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
                btnExportToExcel.Visible = false;
                lblCMessage.Text = "No data found";
            }
        }
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
        Ds = Mysql.GetDataSetWithQuery("Exec getDetailedSessionalReports @AdmissionYear=" + ddlAdmissionYear.SelectedValue + ",@Semester=" + ddlSemester.SelectedValue + ", @ExamType='" + ddlexamtype.SelectedValue + "', @Trade=" + ddlTradeName.SelectedValue + ",@ITICode='" + Session["Username"].ToString() + "'");
        if (Ds.Tables[0].Rows.Count > 0)
        {
            DataTable dtCloned = Ds.Tables[0];
            string filename = "	SessionalDetailedReport";
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
    protected void ddlAdmissionYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAdmissionYear.SelectedValue == "2018")
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