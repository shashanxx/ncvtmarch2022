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
            //BindTradeName();
        }
        //divreports.Visible = false;
        //btnprint.Visible = false;
    }

    protected void BindTradeName()
    {
        //DataTable dtTrade = new DataTable();
        //dtTrade = MySql.GetDataTableWithQuery("select distinct tm.Tradeid,tm.TradeName from tbl_Student ts join TradeMaster tm on lower(ts.Trade)=lower(tm.TradeName) where TradetypeID in (2,3) order by TradeName");
        //if (dtTrade != null && dtTrade.Rows.Count > 0)
        //{
        //    ddlTradeName.DataSource = dtTrade;
        //    ddlTradeName.DataTextField = "TradeName";
        //    ddlTradeName.DataValueField = "Tradeid";
        //    ddlTradeName.DataBind();
        //}
        //ddlTradeName.Items.Insert(0, new ListItem("Select", "0"));

        //if (ddlentrytype.SelectedValue == "ED")
        //{
        //    ddlTradeName.Enabled = true;
        //}
        //else
        //{
        //    ddlTradeName.Enabled = false;
        //}
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (isvalidate())
            {
                Fillgrid();
            }
        }
        catch (Exception ex)
        {
        }
    }

    bool isvalidate()
    {
        //if (ddlentrytype.SelectedValue == "0")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Entry Type');", true);
        //    ddlentrytype.Focus();
        //    return false;
        //}
        //if (ddlSemester.SelectedValue == "0")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Semester');", true);
        //    ddlSemester.Focus();
        //    return false;
        //}
        //if (ddlTradeName.SelectedValue == "0")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Trade Name');", true);
        //    ddlTradeName.Focus();
        //    return false;
        //}
        //if (ddlAdmissionYear.SelectedValue == "YEAR")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Admission Year');", true);
        //    ddlAdmissionYear.Focus();
        //    return false;
        //}
        //if (ddlexamtype.SelectedValue == "0")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Exam Type');", true);
        //    ddlexamtype.Focus();
        //    return false;
        //}
        return true;
    }

    public void Fillgrid()
    {
        //DataSet ds = new DataSet();
        //ds = MySql.GetDataSetWithQuery("Exec getAdminPracticalMarksSummaryReports @AdmissionYear=" + ddlAdmissionYear.SelectedValue + ",@Semester=" + ddlSemester.SelectedValue + ", @ExamType='" + ddlexamtype.SelectedValue + "', @Trade=" + ddlTradeName.SelectedValue + ",@EntryType='" + ddlentrytype.SelectedValue + "'");

        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    GridView1.DataSource = ds;
        //    GridView1.DataBind();
        //    divreports.Visible = true;
        //    btnprint.Visible = true;
        //    lblCMessage.Text = "";
        //}
        //else
        //{
        //    GridView1.DataSource = null;
        //    GridView1.DataBind();
        //    divreports.Visible = false;
        //    btnprint.Visible = false;
        //    lblCMessage.Text = "No data found";
        //}
    }

    protected void ddlentrytype_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindTradeName();
        //if (ddlentrytype.SelectedValue == "ED")
        //    ddlSemester.Items.FindByValue("1").Enabled = false;
        //else
        //    ddlSemester.Items.FindByValue("1").Enabled = true;
    }

    protected void btnprint_Click(object sender, EventArgs e)
    {
        try
        {
            //divreports.Visible = true;
            //HtmlForm form = new HtmlForm();

            //string attachment = "attachment; filename=ITIAdminPracticalSummaryReports.xls";

            //Response.ClearContent();

            //Response.AddHeader("content-disposition", attachment);

            //Response.ContentType = "application/ms-excel";

            //StringWriter stw = new StringWriter();

            //HtmlTextWriter htextw = new HtmlTextWriter(stw);

            //form.Controls.Add(divreports);

            //this.Controls.Add(form);

            //form.RenderControl(htextw);

            //Response.Write(stw.ToString());

            //Response.End();
            DataSet dt = new DataSet();
            dt = MySql.GetDataSet("sp_GetNodalITISummaryReport");

            if (dt.Tables[0].Rows.Count > 0)
            {
                //DataTable dtdata = dt.Tables[0];
                //DataTable dtCloned = dtdata.Clone();
                //dtCloned.Columns[0].DataType = typeof(string);
                //dtCloned.Columns[1].DataType = typeof(string);
                //dtCloned.Columns[2].DataType = typeof(string);
                //dtCloned.Columns[3].DataType = typeof(string);
                //dtCloned.Columns[4].DataType = typeof(string);
                //dtCloned.Columns[5].DataType = typeof(string);

                //foreach (DataRow row in dtdata.Rows)
                //{
                //    dtCloned.ImportRow(row);
                //}
                //DataRow dr = dtCloned.NewRow();
                //dr[0] = "MP ITI NCVT Exam Aug-2018";

                //dtCloned.Rows.InsertAt(dr, 0);

                //DataRow dr2 = dtCloned.NewRow();
                //dr2[0] = "Center Name";
                //dr2[2] = CenterName;
                //dtCloned.Rows.InsertAt(dr2, 1);

                //DataRow dr3 = dtCloned.NewRow();
                //dr3[0] = "Date of Exam";
                //dr3[2] = RadioButtonList3.SelectedItem.Text.ToString();
                //dtCloned.Rows.InsertAt(dr3, 2);

                //DataRow dr4 = dtCloned.NewRow();
                //dr4[0] = "Shift";
                //if (RadioButtonList2.SelectedValue == "1")
                //{
                //    dr4[2] = "Shift - 1";
                //}
                //else if (RadioButtonList2.SelectedValue == "2")
                //{
                //    dr4[2] = "Shift - 2";
                //}
                //else if (RadioButtonList2.SelectedValue == "3")
                //{
                //    dr4[2] = "Shift - 3";
                //}
                //dtCloned.Rows.InsertAt(dr4, 3);

                //DataRow dr5 = dtCloned.NewRow();

                //dr5[0] = "ROLL NO.";
                //dr5[1] = "CANDIDATE NAME";
                //dr5[2] = "DOB";
                //dr5[3] = "SEMESTER";
                //dr5[4] = "EXAM TYPE";
                //dr5[5] = "ITI NAME";
                //dtCloned.Rows.InsertAt(dr5, 4);


                string filename = "NodalITISummaryReport";
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
                //dgGrid.HeaderRow.Cells[0].Visible = false;
                //dgGrid.HeaderRow.Cells[1].Visible = false;
                //dgGrid.HeaderRow.Cells[2].Visible = false;
                //dgGrid.HeaderRow.Cells[3].Visible = false;
                //dgGrid.HeaderRow.Cells[4].Visible = false;
                //dgGrid.HeaderRow.Cells[5].Visible = false;

                //int count = 0; ;
                //foreach (GridViewRow row in dgGrid.Rows)
                //{
                //    //if (row.RowIndex == 0)
                    //{
                    //    row.BackColor = Color.LightGray;
                    //    row.Font.Bold = true;
                        //row.Cells[1].Visible = false;
                        //row.Cells[2].Visible = false;
                        //row.Cells[3].Visible = false;
                        //row.Cells[4].Visible = false;
                        //row.Cells[5].Visible = false;

                        //row.Cells[0].Attributes.Add("colspan", "6");
                        //row.Cells[0].Attributes.Add("style", "text-align: center");
                    //}
                    //if (row.RowIndex == 1 || row.RowIndex == 2 || row.RowIndex == 3)
                    //{
                    //    row.BackColor = Color.LightGray;
                    //    row.Cells[1].Visible = false;
                    //    row.Cells[3].Visible = false;
                    //    row.Cells[4].Visible = false;
                    //    row.Cells[5].Visible = false;
                    //    row.Cells[0].Attributes.Add("colspan", "2");
                    //    row.Cells[0].Attributes.Add("style", "text-align: center");
                    //    row.Cells[2].Attributes.Add("colspan", "4");
                    //    row.Cells[2].Attributes.Add("style", "text-align: center");
                    //}
                //}
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