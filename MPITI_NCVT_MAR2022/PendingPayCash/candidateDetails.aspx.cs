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
using System.Web.UI.HtmlControls;
using System.Drawing;

public partial class JD_DD_Approval : System.Web.UI.Page
{
    ClsErrorLog errlog = new ClsErrorLog();
    CommonPerception MySql = new CommonPerception();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
        {
            Response.Redirect("../Login/LoginNew.aspx");
        }
        if (!IsPostBack)
        {
            lblUName.Text = "Welcome " + Convert.ToString(Session["Username"]);
            FillGrid();
        }
    }    

    void FillGrid()
    {
        DataSet Ds = new DataSet();
        Ds = MySql.GetDataSetWithQuery("Exec sp_getPendingCandidateDetails @ITICode='" + Session["Username"] + "'");
        if (Ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = Ds;
            GridView1.DataBind();
            lblCMessage.Text = "";
            btnprint.Visible = true;
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            lblCMessage.Text = "No data found";
            btnprint.Visible = false;
        }
    }

    protected void btnprint_Click(object sender, EventArgs e)
    {
        try
        {            
            DataSet dt = new DataSet();
            dt = MySql.GetDataSetWithQuery("Exec sp_getPendingCandidateDetails @ITICode='" + Session["Username"] + "'");

            if (dt.Tables[0].Rows.Count > 0)
            {                
                string filename = Session["Username"]+"_CandidateDetails";
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
}