using Common.Class;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Principle_DownloadAdmitCard : System.Web.UI.Page
{
    CommonPerception Mysql = new CommonPerception();
    DataTable dtgrid;
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
        for (int i = 2015; i <= DateTime.Now.Year; i++)
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
    protected void lnklogout_Click(object sender, EventArgs e)
    {
        //Mysql.UpdateSingleLogin(Session["Username"].ToString(), Convert.ToInt32(Session["UserType"].ToString()), 0);
        //Session.Abandon();
        //Session.Clear();
        Response.Redirect("../Login/LoginNew.aspx");
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Dashboard.aspx");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlAdmissionYear.SelectedValue == "0")
        {
            string message = "alert('Please select Admission Year')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            ddlAdmissionYear.Focus();
            return;
        }
        if (ddlSemester.SelectedValue == "0")
        {
            string message = "alert('Please select Semester/Year')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            ddlSemester.Focus();
            return;
        }
        if (ddlTradeName.SelectedValue == "0")
        {
            string message = "alert('Please select Trade')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            ddlTradeName.Focus();
            return;
        }
        if (ddlexamtype.SelectedValue == "0")
        {
            string message = "alert('Please select Exam Type')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            ddlexamtype.Focus();
            return;
        }
        BindGrid();
    }
    protected void BindGrid()
    {
        dtgrid = new DataTable();
        dtgrid = Mysql.GetDataTableWithQuery("exec GetAdmitCardReportPrac @AdmissionYear=" + ddlAdmissionYear.SelectedValue + ",@Semester=" + ddlSemester.SelectedValue + ", @ExamType='" + ddlexamtype.SelectedValue + "', @Trade=" + ddlTradeName.SelectedValue + ",@ITICode='" + Session["Username"].ToString() + "'");
        if (dtgrid != null && dtgrid.Rows.Count > 0)
        {
            GridView1.DataSource = dtgrid;
            GridView1.DataBind();
            lblCMessage.Text = "";
            //divReport.Visible = true;
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            lblCMessage.Text = "Sorry, No record found";
            //divReport.Visible = false;
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hdnDownloadPdfPrac = (HiddenField)e.Row.FindControl("hdnDownloadPdfPrac");
            HtmlGenericControl dvDownloadPrac = (HtmlGenericControl)e.Row.FindControl("dvDownloadPrac");
            if (hdnDownloadPdfPrac.Value == "1")
                dvDownloadPrac.Visible = true;
        }
    }

    protected void ddlAdmissionYear_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BindTradeList();
        string year = ddlAdmissionYear.SelectedValue;
        if (Convert.ToInt32(year) >= 2018)
        {   
            ddlSemester.Items.Clear();
            ddlSemester.Items.Insert(0, new ListItem("2nd year", "4"));
            ddlSemester.Items.Insert(0, new ListItem("1st year", "2"));
            ddlSemester.Items.Insert(0, new ListItem("Select", "0"));

        }
        else
        {
            ddlSemester.Items.Clear();
            ddlSemester.Items.Insert(0, new ListItem("Sem 4", "4"));
            ddlSemester.Items.Insert(0, new ListItem("Sem 3", "3"));
            ddlSemester.Items.Insert(0, new ListItem("Sem 2", "2"));
            ddlSemester.Items.Insert(0, new ListItem("Sem 1", "1"));
            ddlSemester.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    protected void ddlsemesterchange(object sender, EventArgs e)
    {
        BindTradeList();
        string year = ddlAdmissionYear.SelectedValue;
        if (Convert.ToInt32(year) == 2019 && ddlSemester.SelectedValue=="2")
        {
            ListItem itemToRemove = ddlTradeName.Items.FindByValue("16");
            if (itemToRemove != null)
            {
                ddlTradeName.Items.Remove(itemToRemove);
            }
            ListItem itemToRemove1 = ddlTradeName.Items.FindByValue("17");
            if (itemToRemove1 != null)
            {
                ddlTradeName.Items.Remove(itemToRemove1);
            }
            ListItem itemToRemove2 = ddlTradeName.Items.FindByValue("13");
            if (itemToRemove2 != null)
            {
                ddlTradeName.Items.Remove(itemToRemove2);
            }
        }

        if(ddlSemester.SelectedValue == "4")
        {
            DataTable dtTrade = new DataTable();
            dtTrade = Mysql.GetDataTableWithQuery("exec GetTradeList_TwoYear @ITICode='" + Session["Username"].ToString() + "'");
            if (dtTrade != null && dtTrade.Rows.Count > 0)
            {
                ddlTradeName.DataSource = dtTrade;
                ddlTradeName.DataTextField = "TradeName";
                ddlTradeName.DataValueField = "Tradeid";
                ddlTradeName.DataBind();
            }
            ddlTradeName.Items.Insert(0, new ListItem("Select", "0"));

        }
        
    }
}