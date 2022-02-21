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
using System.Drawing;

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
        }
    }  

    protected void btnprint_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dt = new DataSet();
            dt = MySql.GetDataSet("sp_GetSessionalSummaryReport");

            if (dt.Tables[0].Rows.Count > 0)
            {
                string filename = "SessionalSummaryReport";
                string attachment = "attachment; filename=" + filename + ".xls";
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/excel";
                StringWriter stw = new StringWriter();
                HtmlTextWriter htextw = new HtmlTextWriter(stw);
                GridView dgGrid = new GridView();
                dgGrid.DataSource = dt;
                dgGrid.DataBind();
                dgGrid.HeaderRow.BackColor = Color.LightGray;
                dgGrid.HeaderRow.Font.Bold = true;
                dgGrid.RenderControl(htextw);
                Response.Write(stw.ToString());
                Response.End();
            }
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
}