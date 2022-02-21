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

public partial class Principle_DownloadMarkEntryReport : System.Web.UI.Page
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
            BindITIList();
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
        ddlAdmissionYear.Items.Add(new ListItem("All", "0"));
        for (int i = 2015; i <= 2019; i++)
        {
            ddlAdmissionYear.Items.Add(i.ToString());
        }
    }
    private void BindITIList()
    {
        DataTable dtTrade = new DataTable();
        dtTrade = Mysql.GetDataTableWithQuery("exec GetMISITIList @MISNodalITICode='" + Session["Username"].ToString() + "'");
        if (dtTrade != null && dtTrade.Rows.Count > 0)
        {
            ddlITIName.DataSource = dtTrade;
            ddlITIName.DataTextField = "ITIName";
            ddlITIName.DataValueField = "ITICode";
            ddlITIName.DataBind();
        }
        ddlITIName.Items.Insert(0, new ListItem("All", "0"));
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
        //if (ddlAdmissionYear.SelectedValue == "0")
        //{
        //    string message = "alert('Please select Admission Year')";
        //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //    ddlAdmissionYear.Focus();
        //    return;
        //}
        //if (ddlSemester.SelectedValue == "0")
        //{
        //    string message = "alert('Please select Semester/Year')";
        //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //    ddlSemester.Focus();
        //    return;
        //}
        ////if (ddlITIName.SelectedValue == "0")
        ////{
        ////    string message = "alert('Please select ITI')";
        ////    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        ////    ddlITIName.Focus();
        ////    return;
        ////}
        //if (ddlmarkentrytype.SelectedValue == "0")
        //{
        //    string message = "alert('Please select Mark entry Type')";
        //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //    ddlmarkentrytype.Focus();
        //    return;
        //}
        BindGrid();
    }
    protected void BindGrid()
    {
        dtgrid = new DataTable();
        dtgrid = Mysql.GetDataTableWithQuery("exec GetMITIMarkentryReport @AdmissionYear=" + ddlAdmissionYear.SelectedValue + ",@Semester=" + ddlSemester.SelectedValue + ", @ddlmarkentrytype='" + ddlmarkentrytype.SelectedValue + "', @ddlITIName='" + ddlITIName.SelectedValue + "',@MISNodalITICode='" + Session["Username"].ToString() + "'");
        if (dtgrid != null && dtgrid.Rows.Count > 0)
        {
            GridView1.DataSource = dtgrid;
            GridView1.DataBind();
            lblCMessage.Text = "";
            btndownloadmarkentryReport.Visible = true;
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            lblCMessage.Text = "Sorry, No record found";
            btndownloadmarkentryReport.Visible = false;
        }
    }

    protected void downloadmarkentryReport(object sender, EventArgs e)
    {
        string file = "MarkEntryReport";
        DataTable dt = new DataTable();
        dt = Mysql.GetDataTableWithQuery("exec GetMITIMarkentryReport @AdmissionYear=" + ddlAdmissionYear.SelectedValue + ",@Semester=" + ddlSemester.SelectedValue + ", @ddlmarkentrytype='" + ddlmarkentrytype.SelectedValue + "', @ddlITIName='" + ddlITIName.SelectedValue + "',@MISNodalITICode='" + Session["Username"].ToString() + "'");
        if (dt != null && dt.Rows.Count > 0)
        {
            if (dt.Rows.Count > 0)

            {
                HtmlForm form = new HtmlForm();
                string filename = file + DateTime.Now;
                string attachment = "attachment; filename=" + filename + ".xls";
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/excel";
                StringWriter stw = new StringWriter();
                HtmlTextWriter htextw = new HtmlTextWriter(stw);
                DataGrid dgGrid = new DataGrid();
                dgGrid.DataSource = dt;
                dgGrid.DataBind();
                //dgGrid.HeaderStyle.BackColor = Color.Green;
                dgGrid.RenderControl(htextw);
                Response.Write(stw.ToString());
                Response.End();
            }
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
            
        }
    }

    protected void ddlAdmissionYear_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        string year = ddlAdmissionYear.SelectedValue;
        if (Convert.ToInt32(year) >= 2018)
        {
            ddlSemester.Items.Clear();
            ddlSemester.Items.Insert(0, new ListItem("2nd year", "4"));
            ddlSemester.Items.Insert(0, new ListItem("1st year", "2"));
            ddlSemester.Items.Insert(0, new ListItem("All", "0"));
        }
        else
        {
            ddlSemester.Items.Clear();
            ddlSemester.Items.Insert(0, new ListItem("Sem 4", "4"));
            ddlSemester.Items.Insert(0, new ListItem("Sem 3", "3"));
            ddlSemester.Items.Insert(0, new ListItem("Sem 2", "2"));
            ddlSemester.Items.Insert(0, new ListItem("Sem 1", "1"));
            ddlSemester.Items.Insert(0, new ListItem("All", "0"));
        }
    }   
}