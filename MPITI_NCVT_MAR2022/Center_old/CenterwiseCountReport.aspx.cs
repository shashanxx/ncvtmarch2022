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

public partial class Center_CenterwiseCountReport : System.Web.UI.Page
{
    CommonPerception MySql = new CommonPerception();
    DataSet dsgetData = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CenterITICode"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
           
            BindSessionName();
        }
        Divgrid.Visible = false;
        btnsave.Visible = false;
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
        if (ddlSession.SelectedValue == "0")
        {
            lblCMessage.Text = "Select Session";
            return;
        }

        if (ddlentrytype.SelectedValue=="0")
        {
            lblCMessage.Text = "Select Entry Type";
            return;
        }

        //OMR region
        if (ddlSession.SelectedValue != "0" && ddlentrytype.SelectedValue=="O")
        {
            btnSubmit.Visible = false;
            GridView1.DataSource = null;
            lblCMessage.Text = "Please wait...";
            dsgetData = MySql.GetDataSetWithQuery("exec Sp_ForCountreport_CenterLogin @Session='" + ddlSession.SelectedValue.ToString() + "', @CenterITICode='"+Convert.ToString(Session["CenterITICode"])+"'");

            if (dsgetData.Tables[0].Rows.Count > 0)
            {
                GridView2Prac.Visible = false;
                GridView1.Visible = true;
                btnSubmit.Visible = true;
                lblCMessage.Text = "";
                lbls2.Text = ddlSession.SelectedItem.Text.ToString();
                lblentrytype2.Text = ddlentrytype.SelectedItem.Text.ToString();
                // lblsem2.Text = ddlSemester.SelectedItem.Text.ToString();
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
     


        if (ddlSession.SelectedValue != "0" && ddlentrytype.SelectedValue == "P")
        {
            btnSubmit.Visible = false;
            GridView2Prac.DataSource = null;
            lblCMessage.Text = "Please wait...";
            dsgetData = MySql.GetDataSetWithQuery("exec Sp_ForCountreport_CenterLogin_Practical @Session='" + ddlSession.SelectedValue.ToString() + "', @CenterITICode='" + Convert.ToString(Session["CenterITICode"]) + "'");

            if (dsgetData.Tables[0].Rows.Count > 0)
            {
                GridView1.Visible = false;
                GridView2Prac.Visible = true;
                btnSubmit.Visible = true;
                lblCMessage.Text = "";
                lbls2.Text = ddlSession.SelectedItem.Text.ToString();
                lblentrytype2.Text = ddlentrytype.SelectedItem.Text.ToString();
                // lblsem2.Text = ddlSemester.SelectedItem.Text.ToString();
                GridView2Prac.DataSource = dsgetData;
                GridView2Prac.DataBind();
                btnsave.Visible = true;
                Divgrid.Visible = true;

            }
            else
            {
                btnSubmit.Visible = true;
                GridView2Prac.DataSource = null;
                GridView2Prac.DataBind();
                lblCMessage.Text = "No Data Found";
                btnsave.Visible = false;
                Divgrid.Visible = false;
            }
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            Divgrid.Visible = true;
            HtmlForm form = new HtmlForm();

            string attachment = "attachment; filename=CenterReportsEntryCount.xls";

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
    protected void btnchangepass_Click(object sender, EventArgs e)
    {
        Session["CenterITICode"] = Session["CenterITICode"].ToString();
        Response.Redirect("ChangePassword.aspx");
    }
    protected void btnlogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }
}