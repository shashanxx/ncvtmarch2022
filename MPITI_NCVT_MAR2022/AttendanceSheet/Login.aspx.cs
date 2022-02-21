/* =======================================================================================================================
 PROJECT DETAILS
--Client  : AICTE -CMAT Project
--Developer:Bipin OJha
--Version  :4.0
--Created Date: 23rd July 2012
--Modified Date :            
--Marjor work : Help desk Application
 =========================================================================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Class;

using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Mail;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;
using System.Diagnostics;
using System.Web.Resources;
using System.Web.Handlers;

public partial class HelpDesk_Login : System.Web.UI.Page
{
    CommonPerception Mysql = new CommonPerception();
    string ClientName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //  Response.Write("abc");
            chk1.Checked = true;
        }


    }
    protected void chk1_CheckedChanged(object sender, EventArgs e)
    {
        if (chk1.Checked == true)
        {
            chk2.Checked = false; chk3.Checked = false;

        }
    }
    protected void chk2_CheckedChanged(object sender, EventArgs e)
    {
        if (chk2.Checked == true)
        {
            chk1.Checked = false; chk3.Checked = false;

        }
    }
    protected void chk3_CheckedChanged(object sender, EventArgs e)
    {
        if (chk3.Checked == true)
        {
            chk1.Checked = false; chk2.Checked = false;

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ClientName = "MPITI";

        DataSet DsCreateSession = new DataSet();
        DsCreateSession = Mysql.GetDataSetWithQuery("Exec Sp_CCLogin '" + txtLoginId.Text.ToString().Trim() + "' ,'" + txtPassword.Text.ToString().Trim() + "'");
        if (DsCreateSession.Tables[0].Rows.Count > 0)
        {
            Session["AdminId"] = DsCreateSession.Tables[0].Rows[0]["admin_login_id"];
            Session["Role"] = DsCreateSession.Tables[0].Rows[0]["role"];
            Session["LoginId"] = DsCreateSession.Tables[0].Rows[0]["username"];
            Session["Password"] = DsCreateSession.Tables[0].Rows[0]["password"].ToString();
            if (DsCreateSession.Tables[0].Rows[0]["role"].ToString().Trim() == "Center")
            {
                Session["Collegeadmin"] = "Center";
                Session["CentreCode"] = txtLoginId.Text.ToString().Trim();
                Response.Redirect("../AttendanceSheet/GenerateRoaster.aspx", false);
            }
            else
            {
                //
            }

        }
        //}

        else
        {
            txtLoginId.Text = string.Empty; txtPassword.Text = string.Empty;
            string scriptSTR = "<script language=javascript>alert('Oops! Invalid Login Id and password');</script>";
            if (!Page.IsStartupScriptRegistered("clientscript"))
            {
                Page.RegisterStartupScript("clientscript", scriptSTR);
            }
        }


    }
}