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

public partial class Principle_DownloadAdmitCardStenoPrac : System.Web.UI.Page
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
        for (int i = 2019; i <= 2019; i++)
        {
            ddlAdmissionYear.Items.Add(i.ToString());
        }
    }
    private void BindTradeList()
    {
        DataTable dtTrade = new DataTable();
        dtTrade = Mysql.GetDataTableWithQuery("exec GetTradeList_StenoPrac @ITICode='" + Session["Username"].ToString() + "'");
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
        BindGrid();
    }
    protected void BindGrid()
    {
        dtgrid = new DataTable();
        dtgrid = Mysql.GetDataTableWithQuery("exec GetAdmitCardReport_StenoPrac @AdmissionYear=" + ddlAdmissionYear.SelectedValue + ",@Semester=" + ddlSemester.SelectedValue + ", @ExamType='" + ddlexamtype.SelectedValue + "', @Trade=" + ddlTradeName.SelectedValue + ",@ITICode='" + Session["Username"].ToString() + "'");
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
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    HiddenField hdnDownloadPdf = (HiddenField)e.Row.FindControl("hdnDownloadPdf");
        //    HtmlGenericControl dvDownload = (HtmlGenericControl)e.Row.FindControl("dvDownload");
        //    if (hdnDownloadPdf.Value == "1")
        //        dvDownload.Visible = true;
        //}
    }
    protected void ddlAdmissionYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTradeList();


        if (Convert.ToInt32(ddlAdmissionYear.SelectedValue)>=2018)
        {
            lblSemester.Text = "Year";
            ddlSemester.Items.Clear();
            ddlSemester.Items.Add(new ListItem("Select", "0"));
            ddlSemester.Items.Add(new ListItem("1st Year", "2"));
            ddlSemester.Items.Add(new ListItem("2nd Year", "4"));
        }
        else if (ddlAdmissionYear.SelectedValue == "2015")
        {

            lblSemester.Text = "Semester";
            ddlSemester.Items.Clear();
            ddlSemester.Items.Add(new ListItem("Select", "0"));
            //ddlSemester.Items.Add(new ListItem("Sem1", "1"));
            //ddlSemester.Items.Add(new ListItem("Sem2", "2"));
            ddlSemester.Items.Add(new ListItem("Sem3", "3"));
            ddlSemester.Items.Add(new ListItem("Sem4", "4"));
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