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

public partial class JD_DD_Approval : System.Web.UI.Page
{
    ClsErrorLog errlog = new ClsErrorLog();
    CommonPerception MySql = new CommonPerception();
    DataSet ds = new DataSet();
    string DDImgPath = System.Configuration.ConfigurationManager.AppSettings["DDImgPath"];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
        {
            Response.Redirect("../Login/LoginNew.aspx");
        }
        if (!IsPostBack)
        {
            lblUName.Text = "Welcome " + Convert.ToString(Session["Username"]);
            DataTable dt = new DataTable();
            dt = MySql.GetDataTableWithQuery("select * from  tbl_User_Profile where Name='" + Session["Username"].ToString() + "'");
            Session["Zone"] = Convert.ToString(dt.Rows[0]["zone"]);
            HiddenField2.Value = Session["Username"].ToString();
            BindDistrict();
            BindNameOfITI("0");
        }
    }

    protected void BindDistrict()
    {
        DataTable dtDistrict = new DataTable();
        dtDistrict = MySql.GetDataTableWithQuery("exec GetAllDistrictListbyZone @UserName='" + Session["Username"].ToString() + "',@UserType=" + Session["UserType"].ToString() + ",@UserTypeId=" + Session["UserTypeId"] + "");
        if (dtDistrict != null && dtDistrict.Rows.Count > 0)
        {
            ddldistrict.DataSource = dtDistrict;
            ddldistrict.DataTextField = "ExistsDistrict";
            ddldistrict.DataValueField = "LcaseDistrict";
            ddldistrict.DataBind();
        }
        ddldistrict.Items.Insert(0, new ListItem("Select District", "0"));
    }

    protected void BindNameOfITI(string District)
    {
        ddlNameofITI.Items.Clear();
        DataTable dtITICodeName = new DataTable();
        dtITICodeName = MySql.GetDataTableWithQuery("exec GetAllITINamebyZone @UserName='" + Session["Username"].ToString() + "',@UserType=" + Session["UserType"].ToString() + ",@UserTypeId=" + Session["UserTypeId"] + ",@ExistsDistrict='" + District + "'");
        if (dtITICodeName != null && dtITICodeName.Rows.Count > 0)
        {
            ddlNameofITI.DataSource = dtITICodeName;
            ddlNameofITI.DataTextField = "ITIName";
            ddlNameofITI.DataValueField = "ITICode";
            ddlNameofITI.DataBind();
        }
        ddlNameofITI.Items.Insert(0, new ListItem("Select", "0"));
    }

    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindNameOfITI(ddldistrict.SelectedValue);
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label txt = (e.Row.FindControl("lblStatus") as Label);
            Button btn = (e.Row.FindControl("btnApprove") as Button);
            Label lbl = (e.Row.FindControl("lblStatustxt") as Label);
            if (txt.Text == "1")
            {
                btn.Visible = false;
                lbl.Visible = true;
            }                
            else
            {
                btn.Visible = true;
                lbl.Visible = false;
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            lblCMessage.Text = "";
            if (isvalidate())
            {
                FillGrid();
            }
        }
        catch (Exception ex)
        {
            errlog.LogError(ex);
        }
    }

    protected void btnApprove_Click(object sender, EventArgs e)
    {
        try
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string pid = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
            DataTable dt = new DataTable();
            dt = MySql.GetDataTableWithQuery("update tbl_ITIPaymentDetails set  ApprovedbyJD='1',ApprovedBy='" + Session["Username"].ToString() + "',ApprovedDate=getDate() where PID='" + pid + "'");

            FillGrid();
        }
        catch (Exception ex)
        {
            errlog.LogError(ex);
        }
    }

    void FillGrid()
    {
        DataSet Ds = new DataSet();
        Ds = MySql.GetDataSetWithQuery("Exec sp_getDDDetail @ITICode='" + ddlNameofITI.SelectedValue + "'");
        if (Ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = Ds;
            GridView1.DataBind();
            lblCMessage.Text = "";
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            lblCMessage.Text = "No data found";
        }
    }

    bool isvalidate()
    {
        if (ddldistrict.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select District');", true);
            ddldistrict.Focus();
            return false;
        }
        if (ddlNameofITI.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Name of ITI');", true);
            ddlNameofITI.Focus();
            return false;
        }
        return true;
    }

    protected void btnExit_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Abandon();
            Response.Redirect("../Login/LoginNew.aspx");
        }
        catch (Exception ex)
        {
            errlog.LogError(ex);
        }
    }

    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("../Login/LoginNew.aspx");
    }
}