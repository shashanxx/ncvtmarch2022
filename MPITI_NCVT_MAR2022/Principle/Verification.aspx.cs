using Common.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Principle_Verification : System.Web.UI.Page
{
    CommonPerception Mysql = new CommonPerception();
    DataSet ds = new DataSet();
    string strSQL = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ds = Mysql.GetDataSetWithQuery("select RollNumber,Name,FatherName,DOB from tbl_Student");
            GridView1.DataSource = ds;
            GridView1.DataBind();
            //GetExamDetails();
            //GetSemester();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Boolean result = false;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            Label lblrollnumber = (Label)GridView1.Rows[i].Cells[0].FindControl("lblrollnumber");
            CheckBox chkpprtradetheory = (CheckBox)GridView1.Rows[i].Cells[4].FindControl("chkpprtradetheory");
            CheckBox chkEmployabilitySkills = (CheckBox)GridView1.Rows[i].Cells[5].FindControl("chkEmployabilitySkills");
            CheckBox chkWorkshopCalcScience = (CheckBox)GridView1.Rows[i].Cells[6].FindControl("chkWorkshopCalcScience");
            CheckBox chkEngineeringDrawing = (CheckBox)GridView1.Rows[i].Cells[6].FindControl("chkEngineeringDrawing");
            CheckBox chkpractical = (CheckBox)GridView1.Rows[i].Cells[7].FindControl("chkpractical");
          
            if (chkpprtradetheory.Checked)
            {
                string TradeTheory = "TradeTheory";
                strSQL = "EXEC StudentUpdate @Rollnumber='" + lblrollnumber.Text + "', @columnname =" + TradeTheory + " , @eligibility='more than eighty',	@choicelocked='Yes',	@attendance='more than 80 %',	@sessionmarks'more than 40 %',@amount='300' ";

                result = Mysql.ExecuteNonQuery(strSQL);
            }
            
            TextBox txtdesignation = (TextBox)GridView1.Rows[i].Cells[2].FindControl("txtdesignation");
            TextBox txtkeyexperience = (TextBox)GridView1.Rows[i].Cells[3].FindControl("txtkeyexperience");
           

            //string[] fromdate = txtfrom.Text.Split('/');
            //string newfromdate = fromdate[2] + "-" + fromdate[1] + "-" + fromdate[0];

            //string[] todate = txtto.Text.Split('/');
            //string newtodate = todate[2] + "-" + todate[1] + "-" + todate[0];

            //strSQL = "EXEC sp_InsertNUpdateExperienceDetails @CanId='" + CID + "', @orgniastionname = '" + txtorganizationname.Text + "', @designation='" + txtdesignation.Text + "',	@keyexperience='"
            //          + txtkeyexperience.Text + "',	@Fromdate='" + newfromdate + "',	@Todate='" + newtodate + "',@duration='" + txtduration.Text + "',	@Status='" + Status + "',@ExpDesc='" + ExpDesc + "'";

            //result = Mysql.ExecuteNonQuery(strSQL);


        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {


        //try
        //{
        //    if (isvalidate())
        //    {
        //        BindGrid();
        //    }
        //}
        //catch (Exception ex)
        //{

        //    throw;
        //}


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
        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    GridView1.Columns[4].Visible = false;
        //    GridView1.Columns[5].Visible = false;
        //    //   strsql = Mysql.SingleCellResultInString("select Classification from tblpapers where TradeCode='" + ddlTradeName.SelectedValue.ToString() + "'");
        //    DataSet ds = new DataSet();
        //    ds = Mysql.GetDataSetWithQuery("select isnull(PaperName, '') as PaperName from tblpapers ppr left join tblTradeMaster td on ppr.tradeid=td.id where td.tradecode='" + ddlTradeName.SelectedValue + "'");
        //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        int j = Convert.ToInt32(2 + i); //2 hardcode
        //        GridView1.Columns[j].Visible = true;
        //        e.Row.Cells[j].Text = ds.Tables[0].Rows[0]["PaperName"].ToString();
        //    }
        //}
    }

}