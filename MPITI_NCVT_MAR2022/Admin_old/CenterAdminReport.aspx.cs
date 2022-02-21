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

public partial class Admin_CenterAdminReport : System.Web.UI.Page
{
    CommonPerception MySql = new CommonPerception();
    DataSet dsgetData = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Login"].ToString() != "Admin")
        {
            Response.Redirect("../Center/Login.aspx");
        }
        if (!IsPostBack)
        {
            BindSemesterMaster();
            BindSessionName();
        }
        Divgrid.Visible = false;
        btnsave.Visible = false;
    }
    protected void BindSemesterMaster()
    {
        ddlSemester.Items.Clear();
        DataSet Ds = new DataSet();
        Ds = MySql.GetDataSetWithQuery("Exec sp_getSemestermaster");
        if (Ds.Tables[0].Rows.Count > 0)
        {
            ddlSemester.DataSource = Ds;
            ddlSemester.DataTextField = "Semester";
            ddlSemester.DataValueField = "ID";
            ddlSemester.DataBind();
            ddlSemester.Items.Insert(0, new ListItem("Select Semester", "0"));
            ddlSemester.Items.Insert(5, new ListItem("All", "5"));
        }
    }
    protected void BindSessionName()
    {
        ddlSession.Items.Clear();
        DataSet Ds = new DataSet();
        Ds = MySql.GetDataSetWithQuery("Exec sp_getSessionMaster");
        if (Ds.Tables[0].Rows.Count > 0)
        {
            ddlSession.DataSource = Ds;
            ddlSession.DataTextField = "Session";
            ddlSession.DataValueField = "ID";
            ddlSession.DataBind();
            ddlSession.Items.Insert(0, new ListItem("Select Session Name", "0"));
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblCMessage.Text = "";
      
        GridView1.DataBind();
   
       
        if (ddlSemester.SelectedValue == "5")
        {
            btnSubmit.Visible = false;
            GridView1.DataSource = null;
            lblCMessage.Text = "Please wait...";
          dsgetData = MySql.GetDataSetWithQuery("exec Sp_ForAdminReportsofOMR1 @Session='" + ddlSession.SelectedValue.ToString() + "'");
        }
        else

        {
            btnSubmit.Visible = false;
            GridView1.DataSource = null;
            lblCMessage.Text = "Please wait...";
            dsgetData = MySql.GetDataSetWithQuery("exec Sp_ForAdminReportsofOMR1 @Session='" + ddlSession.SelectedValue.ToString() + "', @Semester='" + ddlSemester.SelectedValue.ToString() + "'"); }
          
        if (dsgetData.Tables[0].Rows.Count > 0)
        {
            btnSubmit.Visible = true;
            lblCMessage.Text = "";
            lbls2.Text = ddlSession.SelectedItem.Text.ToString();
            lblsem2.Text = ddlSemester.SelectedItem.Text.ToString();
            GridView1.DataSource = dsgetData;
            GridView1.DataBind();
            btnsave.Visible = true;
            Divgrid.Visible = true;
           
        }
        else
        {
            btnSubmit.Visible = true;
            GridView1.DataSource = null;
            GridView1.DataBind();
            lblCMessage.Text = "No Data Found";
            btnsave.Visible = false;
            Divgrid.Visible = false;
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            Divgrid.Visible = true;
            HtmlForm form = new HtmlForm();

            string attachment = "attachment; filename=ITIAdminReports.xls";

            Response.ClearContent();

            Response.AddHeader("content-disposition", attachment);

            Response.ContentType = "application/ms-excel";

            StringWriter stw = new StringWriter();

            HtmlTextWriter htextw = new HtmlTextWriter(stw);

            form.Controls.Add(Divgrid);

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
        Response.Redirect("../Center/Login.aspx");
    }
}