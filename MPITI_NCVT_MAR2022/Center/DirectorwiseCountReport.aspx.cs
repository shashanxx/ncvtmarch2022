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

public partial class Center_DirectorwiseCountReport : System.Web.UI.Page
{
    CommonPerception MySql = new CommonPerception();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["centerlogin"] == null || Session["Zone"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            BindSessionName();
            BindSemesterMaster();

        }
        divreports.Visible = false;
        btnprint.Visible = false;


    }
    protected void btnchangepass_Click(object sender, EventArgs e)
    {
        Session["CenterITICode"] = HiddenField2.Value;
        Response.Redirect("ChangePassword.aspx");
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
            lblCMessage.Text = "";
        }
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
        }
        lblCMessage.Text = "";
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {

            Fillgrid();

        }
        catch (Exception ex)
        {

        }
    }


    public void Fillgrid()
    {
        string session = ddlSession.SelectedValue.ToString();

        string semester = ddlSemester.SelectedValue.ToString();

        // string Papertype = ddlPaper.SelectedValue.ToString();
        lbls2.Text = ddlSession.SelectedItem.Text.ToString();
        lblsem2.Text = ddlSemester.SelectedValue.ToString();
        lblentryType.Text = ddlEntryType.SelectedItem.Text.ToString();
        string Actioncase = "";
        DataSet ds = new DataSet();
        if(ddlSession.SelectedValue=="0")
        {
            lblCMessage.Text = "Select Session";
            return;
        }
        if(ddlSemester.SelectedValue=="0")
        {
            lblCMessage.Text = "Select Semester";
            return;
        }
        if (ddlEntryType.SelectedValue=="0")
        {
            lblCMessage.Text = "Select Entry Type";
            return;
        }

        if (ddlEntryType.SelectedValue=="ED")
        {
            ds = MySql.GetDataSetWithQuery("Exec sp_getJDwiseCountReports @session= '" + session + "', @Semester='" + semester + "', @ZoneName='" + Convert.ToString(Session["Zone"]) + "'");
        }
        else if (ddlEntryType.SelectedValue.ToString() == "Steno")
        {
            ds = MySql.GetDataSetWithQuery("Exec sp_getJDwiseCountReports_Steno @session= '" + session + "', @Semester='" + semester + "', @ZoneName='" + Convert.ToString(Session["Zone"]) + "'");
        }
        else
        {
            lblCMessage.Text = "Select Entry Type";
        }




        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
            divreports.Visible = true;
            btnprint.Visible = true;

            //HiddenField1.Value = MySql.SingleCellResultInString(tradetype);

            //Hiddenvalue = Convert.ToBoolean(HiddenField1.Value);

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
    protected void btnprint_Click(object sender, EventArgs e)
    {
        try
        {

            divreports.Visible = true;
            HtmlForm form = new HtmlForm();

            string attachment = "attachment; filename=ITIJDCountReports.xls";

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
        Response.Redirect("../Center/Login.aspx");
    }
 
    protected void btnlogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }

}