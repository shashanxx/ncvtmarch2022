using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Class;
using System.Data;
using System.Data.SqlClient;


public partial class Principle_PrVerification : ClsErrorLog
{

    CommonPerception Mysql = new CommonPerception();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetExamDetails();
            GetSemester();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (isvalidate())
            {
                BindGrid();
            }
        }
        catch (Exception ex)
        {

            throw;
        }


    }

    protected void GetExamDetails()
    {
        try
        {
            ddlexamtype.Items.Clear();
            ds = Mysql.GetDataSetWithQuery("exec GetExamDetails");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlexamtype.DataSource = ds;
                ddlexamtype.DataTextField = "ExamType";
                ddlexamtype.DataValueField = "Id";
                ddlexamtype.DataBind();
            }
            ddlexamtype.Items.Insert(0, new ListItem("-SELECT-", "0"));
        }
        catch (Exception ex)
        {

            throw;
        }

    }
    protected void GetTradeDetails(int ExamId)
    {
        ddlTradeName.SelectedIndex = -1;
        ddlTradeName.Items.Clear();
        ds = Mysql.GetDataSetWithQuery("exec GetTradeDetails @ExamId='" + ExamId + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlTradeName.DataSource = ds;
            ddlTradeName.DataTextField = "TradeName";
            ddlTradeName.DataValueField = "TradeCode";
            ddlTradeName.DataBind();
        }
        ddlTradeName.Items.Insert(0, new ListItem("-SELECT-", "0"));
    }

    protected void ddlexamtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetTradeDetails(Convert.ToInt32(ddlexamtype.SelectedValue));
    }
    protected void GetSemester()
    {
        ddlSemester.SelectedIndex = -1;
        ddlSemester.Items.Clear();
        ds = Mysql.GetDataSetWithQuery("exec GetSemester");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlSemester.DataSource = ds;
            ddlSemester.DataTextField = "Semester";
            ddlSemester.DataValueField = "Id";
            ddlSemester.DataBind();
        }
        ddlSemester.Items.Insert(0, new ListItem("-SELECT-", "0"));
    }

    protected void BindGrid()
    {
        ds = Mysql.GetDataSetWithQuery("exec GetDatainGrid @ExamType='" + ddlexamtype.SelectedValue + "', @TradeCode='" + ddlTradeName.SelectedValue + "', @ITICode='" + Convert.ToString(Session["Username"]) + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
            btnSave.Visible = true;
        }
    }
    bool isvalidate()
    {
        if (ddlexamtype.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select Exam');", true);
            ddlexamtype.Focus();
            return false;
        }
        if (ddlTradeName.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select Trade');", true);
            ddlTradeName.Focus();
            return false;
        }
        if (ddlSemester.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select Semester');", true);
            ddlSemester.Focus();
            return false;
        }
        return true;
    }

   



    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView1.Columns[4].Visible = false;
            GridView1.Columns[5].Visible = false;
            //   strsql = Mysql.SingleCellResultInString("select Classification from tblpapers where TradeCode='" + ddlTradeName.SelectedValue.ToString() + "'");
            DataSet ds = new DataSet();
            ds = Mysql.GetDataSetWithQuery("select isnull(PaperName, '') as PaperName from tblpapers ppr left join tblTradeMaster td on ppr.tradeid=td.id where td.tradecode='" + ddlTradeName.SelectedValue + "'");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                int j = Convert.ToInt32(2 + i); //2 hardcode
                GridView1.Columns[j].Visible = true;
                e.Row.Cells[j].Text = ds.Tables[0].Rows[0]["PaperName"].ToString();
            }
        }
    }

    
}