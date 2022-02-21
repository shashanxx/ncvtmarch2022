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
            if (Convert.ToInt32(Session["UserType"].ToString()) == 0)
            {
                ititr.Visible = true;
                byrollnumTital.Visible = true;
                byrollnumtxtbox.Visible = true;
                bindIti();
            }

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
        for (int i = DateTime.Now.Year - 6; i < DateTime.Now.Year ; i++)
        {
            ddlAdmissionYear.Items.Add(i.ToString());
        }
    }

    private void BindTradeList()
    {
        DataTable dtTrade = new DataTable();
        dtTrade = Mysql.GetDataTableWithQuery("select distinct tm.Tradeid,tm.TradeName from tbl_Student ts join TradeMaster tm on lower(ts.Trade)=lower(tm.TradeName) where ts.Trade in ('SECRETARIAL PRACTICE (ENGLISH)','Stenographer & Secretarial Assistant (English)','Stenographer & Secretarial Assistant (Hindi)') and ts.ITICode='" + Session["Username"].ToString() + "'");
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
        if (Convert.ToInt32(Session["UserType"].ToString()) == 0)
        {
            if (string.IsNullOrEmpty(rollnumber.Text.ToString()))
            {
                if (ddliti.SelectedValue.ToString() == "0")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select ITI');", true);
                    return;
                }
            }
            SuperAdminBindGrid(ddliti.SelectedItem.Text.ToString());
        }
        else
        {
            BindGrid();
        }
    }

    protected void SuperAdminBindGrid(string iticode)
    {
        dtgrid = new DataTable();

        if (string.IsNullOrEmpty(rollnumber.Text.ToString()))
        {
            dtgrid = Mysql.GetDataTableWithQuery("exec GetWPMList @AdmissionYear=" + ddlAdmissionYear.SelectedValue + ",@Semester=" + ddlSemester.SelectedValue + ", @ExamType='" + ddlexamtype.SelectedValue + "', @Trade=" + ddlTradeName.SelectedValue + ",@ITICode='" + iticode + "'");
        }
        else
        {
            dtgrid = Mysql.GetDataTableWithQuery("exec GetWPMListByRollNumber @rollnumber='" + rollnumber.Text.ToString() + "'");
        }



        if (dtgrid != null && dtgrid.Rows.Count > 0)
        {
            tbl_note.Visible = true;
            GridView1.DataSource = dtgrid;
            GridView1.DataBind();
            lblCMessage.Text = "";
            //divReport.Visible = true;
        }
        else
        {
            tbl_note.Visible = false;
            GridView1.DataSource = null;
            GridView1.DataBind();
            lblCMessage.Text = "Sorry, No record found";
            //divReport.Visible = false;
        }
    }

    private void bindIti()
    {
        DataTable itidt = new DataTable();
        itidt = Mysql.GetDataTableWithQuery("exec GetItiList");
        if (itidt != null && itidt.Rows.Count > 0)
        {
            ddliti.DataSource = itidt;
            ddliti.DataTextField = "username";
            ddliti.DataValueField = "userid";
            ddliti.DataBind();
        }
        ddliti.Items.Insert(0, new ListItem("Select", "0"));
        ddlTradeName.Items.Clear();
        ddlTradeName.Items.Insert(0, new ListItem("Select", "0"));
    }

    protected void ddliti_change(object sender, EventArgs e)
    {
        if (ddliti.SelectedValue.ToString() != "0")
        {
            BindITITradeList(ddliti.SelectedItem.Text.ToString());
        }
    }

    private void BindITITradeList(string iticode)
    {
        ddlTradeName.Items.Clear();
        DataTable dtTrade = new DataTable();
        dtTrade = Mysql.GetDataTableWithQuery("select distinct tm.Tradeid,tm.TradeName from tbl_Student ts join TradeMaster tm on lower(ts.Trade)=lower(tm.TradeName) where ts.Trade in ('SECRETARIAL PRACTICE (ENGLISH)','STENOGRAPHER AND SECRETARIAL ASSISTANT (ENGLISH)','STENOGRAPHER AND SECRETARIAL ASSISTANT (HINDI)') and ts.ITICode='" + iticode + "'");
        if (dtTrade != null && dtTrade.Rows.Count > 0)
        {
            ddlTradeName.DataSource = dtTrade;
            ddlTradeName.DataTextField = "TradeName";
            ddlTradeName.DataValueField = "Tradeid";
            ddlTradeName.DataBind();
        }
        ddlTradeName.Items.Insert(0, new ListItem("Select", "0"));
    }

    protected void BindGrid()
    {
        dtgrid = new DataTable();
        dtgrid = Mysql.GetDataTableWithQuery("exec GetWPMList @AdmissionYear=" + ddlAdmissionYear.SelectedValue + ",@Semester=" + ddlSemester.SelectedValue + ", @ExamType='" + ddlexamtype.SelectedValue + "', @Trade=" + ddlTradeName.SelectedValue + ",@ITICode='" + Session["Username"].ToString() + "'");
        if (dtgrid != null && dtgrid.Rows.Count > 0)
        {
            tbl_note.Visible = true;
            GridView1.DataSource = dtgrid;
            GridView1.DataBind();
            lblCMessage.Text = "";
            //divReport.Visible = true;
        }
        else
        {
            tbl_note.Visible = false;
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
            Label txt = (e.Row.FindControl("lblWPMResult") as Label);
            HtmlImage img = (e.Row.FindControl("img_pdf") as HtmlImage);
            if (txt.Text == "PASS")
                img.Visible = true;
            else
                img.Visible = false;
        }
    }

    protected void ddlAdmissionYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTradeList();

        if (ddlAdmissionYear.SelectedValue == "2018" || ddlAdmissionYear.SelectedValue == "2019")
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