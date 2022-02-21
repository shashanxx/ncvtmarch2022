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

public partial class Admin_CenterAdminOMRMasterData : System.Web.UI.Page
{
    CommonPerception MySql = new CommonPerception();
    DataSet dsgetData = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login"].ToString() != "Admin")
        {
            Response.Redirect("../Center/Login.aspx");
        }
        if (!IsPostBack)
        {
            BindSessionName();
            BindSemesterMaster();
            Divgrid.Visible = false;
            btnsave.Visible = false;
        }
        
    }
   
    protected void ddlentrytype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlentrytype.SelectedValue.ToString()=="O")
        {
            trpprtype.Visible = true;
            trpprline.Visible = true;
            trsem.Visible = false;
            trsem2.Visible = false;
        }
        else
        {
            trpprtype.Visible = false;
            trpprline.Visible = false;
            trsem.Visible = true;
            trsem2.Visible = true;

        }
    }
    protected void ddlPapertype_SelectedIndexChanged(object sender, EventArgs e)
    {

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

        if(ddlSession.SelectedValue=="0")
        {
            lblCMessage.Text = "Select Session";
            return;
        }
        if(ddlentrytype.SelectedValue=="0")
        {
            lblCMessage.Text = "Select Entry type";
            return;
        }
        if (ddlentrytype.SelectedValue=="O" && ddlPapertype.SelectedValue == "0")
        {
            lblCMessage.Text = "Select Paper";
            return;
        }

        if (ddlentrytype.SelectedValue == "P" && ddlsemster.SelectedValue == "0")
        {
            lblCMessage.Text = "Select Semester";
            return;
        }
        if (ddlentrytype.SelectedValue== "O")
        {
            btnSubmit.Visible = false;
            GridView1.DataSource = null;
            lblCMessage.Text = "Please wait...";
            //Practical
            //Sp_AdminReports_getPracticalMarks
            if(ddlentrytype.SelectedValue=="O")
            {
                dsgetData = MySql.GetDataSetWithQuery("exec GetAdmin_OMRMasterData @Papertype='" + ddlPapertype.SelectedValue.ToString() + "', @Session='" + ddlSession.SelectedValue.ToString() + "'");
            }
          
         

            if (dsgetData.Tables[0].Rows.Count > 0)
            {
                GridView2.Visible = false;
                btnSubmit.Visible = true;
                lblCMessage.Text = "";
                lbls2.Text = ddlSession.SelectedItem.Text.ToString();
                lblentry.Text = ddlentrytype.SelectedItem.Text.ToString();
                // lblsem2.Text = ddlSemester.SelectedItem.Text.ToString();
                GridView1.DataSource = dsgetData;
                GridView1.DataBind();
                btnsave.Visible = true;
                Divgrid.Visible = true;
                btnsave.Visible = true;

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
        else if (ddlentrytype.SelectedValue == "P")
           {
               dsgetData = MySql.GetDataSetWithQuery("exec Sp_AdminReports_getPracticalMarks @Session='" + ddlSession.SelectedValue.ToString() + "', @Semester='"+ddlsemster.SelectedValue.ToString()+"'");
           
            
            if (dsgetData.Tables[0].Rows.Count > 0)
            {
                GridView1.Visible = false;
                btnSubmit.Visible = true;
                lblCMessage.Text = "";
                lbls2.Text = ddlSession.SelectedItem.Text.ToString();
                lblentry.Text = ddlentrytype.SelectedItem.Text.ToString();
                // lblsem2.Text = ddlSemester.SelectedItem.Text.ToString();
                GridView2.DataSource = dsgetData;
                GridView2.DataBind();
                btnsave.Visible = true;
                Divgrid.Visible = true;
                btnsave.Visible = true;

            }
            else
            {
                btnSubmit.Visible = true;
                GridView2.DataSource = null;
                GridView2.DataBind();
                lblCMessage.Text = "No Data Found";
                btnsave.Visible = false;
                Divgrid.Visible = false;
            }
           }
        
        else
        {
            lblCMessage.Text = "Select Entry Type";
            return;
        }

        //else
        //{
        //    btnSubmit.Visible = false;
        //    GridView1.DataSource = null;
        //    lblCMessage.Text = "Please wait...";
        //    dsgetData = MySql.GetDataSetWithQuery("exec GetAdmin_OMRMasterData @Papertype='" + ddlPapertype.SelectedValue.ToString() + "', @Session='" + ddlSession.SelectedValue.ToString() + "'");
        //}

   
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            Divgrid.Visible = true;
            HtmlForm form = new HtmlForm();

            string attachment = "attachment; filename=ITICenterAdminOMRReports.xls";

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

    protected void BindSemesterMaster()
    {
        ddlsemster.Items.Clear();
        DataSet Ds = new DataSet();
        Ds = MySql.GetDataSetWithQuery("Exec sp_getSemestermaster");
        if (Ds.Tables[0].Rows.Count > 0)
        {
            ddlsemster.DataSource = Ds;
            ddlsemster.DataTextField = "Semester";
            ddlsemster.DataValueField = "ID";
            ddlsemster.DataBind();
            ddlsemster.Items.Insert(0, new ListItem("Select Semester", "0"));
        }
    }
   
}