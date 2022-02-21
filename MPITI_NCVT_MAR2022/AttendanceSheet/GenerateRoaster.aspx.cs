/* =============================================================================================================
 * Project:CMAT
 * Module : Entry College AND Create College Capacity
 * Developed By : Bipin Ojha
 * Created Date: 10 Aug 2012
 * 
 * =========================================================================================================*/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Common.Class;
//using Property_Layer;
//using Business_Layer;
//using Data_Layer;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;
using System.Web.Mail;
//using MSCaptcha;
using System.Security.Cryptography;
//using CaptchaDotNet2.Security.Cryptography;
using System.Globalization;
using System.Threading;
using System.Net;
//using CollegeEntry;
//using EvoPdf;
using System.Drawing;
//using EvoPdf;
//using KeepAutomation.Barcode.Bean;
//using KeepAutomation.Barcode;
using System.Drawing.Imaging;


public partial class SchedulerSep2014_GenerateRoaster : System.Web.UI.Page
{
    CommonPerception MySql = new CommonPerception();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(Convert.ToString(Session["CentreCode"])))
        {
            Response.Redirect("../AttendanceSheet/Login.aspx");
        }
        if (!IsPostBack)
        {
            CenterList();
        }
    }

    #region Clearfileds()
    void Clearfields()
    {


    }

    #endregion


    protected void btnCreate_Click(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedIndex == 0)
        {

            string scriptSTR = "<script language=javascript>alert('Please select at least one Centre !');</script>";
            if (!Page.IsStartupScriptRegistered("clientscript"))
            {
                Page.RegisterStartupScript("clientscript", scriptSTR);
            }
            return;
        }
        if (RadioButtonList3.SelectedIndex == -1)
        {
            string scriptSTR = "<script language=javascript>alert('Please select at least one Date !');</script>";
            if (!Page.IsStartupScriptRegistered("clientscript"))
            {
                Page.RegisterStartupScript("clientscript", scriptSTR);
            }
            return;
        }
        if (RadioButtonList2.SelectedIndex == -1)
        {
            string scriptSTR = "<script language=javascript>alert('Please select at least one Slot !');</script>";
            if (!Page.IsStartupScriptRegistered("clientscript"))
            {
                Page.RegisterStartupScript("clientscript", scriptSTR);
            }
            return;
        }
        //string str = MySql.SingleCellResultInString("select CenterID as CenterId from CenterMaster where [TC CODE]='" + Session["CentreCode"] + "'");
        Response.Redirect("Roster.aspx?centerid=" + Convert.ToString(Session["CentreCode"]) + "&Slot=" + RadioButtonList2.SelectedValue + "&date=" + RadioButtonList3.SelectedValue);
    }

    #region Created Center list
    protected void CenterList()
    {
        DataSet DsCenterlist = new DataSet();
        DsCenterlist = null;

        DsCenterlist = MySql.GetDataSetWithQuery("select [Centre Name]+'|'+TCCode as CollegeName,CenterID as CenterId from CenterMaster where CenterId='" + Session["CentreCode"] + "'");
        //DsCenterlist = MySql.GetDataSetWithQuery("select Center as CollegeName,CenterID as CenterId from CenterMaster where CenterId='" + Session["CentreCode"] + "'");
        if (DsCenterlist.Tables[0].Rows.Count > 0)
        {
            trcenterlist.Visible = true;
            RadioButtonList1.DataSource = DsCenterlist;
            RadioButtonList1.DataTextField = "CollegeName";
            RadioButtonList1.DataValueField = "CenterId";
            RadioButtonList1.DataBind();
            RadioButtonList1.Items.Insert(0, new ListItem("Select one centre from list", "0"));
        }
        else
        {
            Session.Abandon();
            Response.Write("<script  language='javascript' align='center'>window.alert('There is No Data scheduled for this Centre');history.back(-1);</script> ");
        }
    }

    #endregion

    public void ExportToExcel()
    {
        DataSet dt = new DataSet();
        string Date = RadioButtonList3.SelectedValue;
        string CenterName = RadioButtonList1.SelectedItem.Text;
        string slot = RadioButtonList2.SelectedItem.Text;

        dt = MySql.GetDataSet("sp_GetExcelData '" + RadioButtonList1.SelectedValue + "','" + RadioButtonList2.SelectedValue + "','" + RadioButtonList3.SelectedValue + "'");

        if (dt.Tables[0].Rows.Count > 0)
        {
            DataTable dtdata = dt.Tables[0];
            DataTable dtCloned = dtdata.Clone();
            dtCloned.Columns[0].DataType = typeof(string);
            dtCloned.Columns[1].DataType = typeof(string);
            dtCloned.Columns[2].DataType = typeof(string);
            dtCloned.Columns[3].DataType = typeof(string);
            dtCloned.Columns[4].DataType = typeof(string);
            dtCloned.Columns[5].DataType = typeof(string);

            foreach (DataRow row in dtdata.Rows)
            {
                dtCloned.ImportRow(row);
            }
            DataRow dr = dtCloned.NewRow();
            dr[0] = "MP ITI NCVT Exam Aug-2019";
           
            dtCloned.Rows.InsertAt(dr, 0);

            DataRow dr2 = dtCloned.NewRow();
            dr2[0] = "Center Name";
            dr2[2] = CenterName;
            dtCloned.Rows.InsertAt(dr2, 1);

            DataRow dr3 = dtCloned.NewRow();
            dr3[0] = "Date of Exam";
            dr3[2] = RadioButtonList3.SelectedItem.Text.ToString();
            dtCloned.Rows.InsertAt(dr3, 2);

            DataRow dr4 = dtCloned.NewRow();
            dr4[0] = "Shift";

            dr4[2] = RadioButtonList2.SelectedItem.Text;
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
            dtCloned.Rows.InsertAt(dr4, 3);

            DataRow dr5 = dtCloned.NewRow();
            
            dr5[0] = "ROLL NO.";
            dr5[1] = "CANDIDATE NAME";
            dr5[2] = "DOB";
            dr5[3] = "SEMESTER";
            dr5[4] = "EXAM TYPE";
            dr5[5] = "ITI NAME";
            dtCloned.Rows.InsertAt(dr5, 4);


            string filename = RadioButtonList1.SelectedItem.Text;
            string attachment = "attachment; filename=" + filename + ".xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/excel";
            StringWriter stw = new StringWriter();
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            GridView dgGrid = new GridView();
            dgGrid.DataSource = dtCloned;
            dgGrid.DataBind();

            dgGrid.HeaderRow.Cells[0].Visible = false;
            dgGrid.HeaderRow.Cells[1].Visible = false;
            dgGrid.HeaderRow.Cells[2].Visible = false;
            dgGrid.HeaderRow.Cells[3].Visible = false;           
            dgGrid.HeaderRow.Cells[4].Visible = false;
            dgGrid.HeaderRow.Cells[5].Visible = false;

            int  count=0;;
            foreach (GridViewRow row in dgGrid.Rows)
            {
                if (row.RowIndex == 0)
                {
                    row.BackColor = Color.LightGray;
                    row.Cells[1].Visible = false;
                    row.Cells[2].Visible = false;
                    row.Cells[3].Visible = false;
                    row.Cells[4].Visible = false;
                    row.Cells[5].Visible = false;

                    row.Cells[0].Attributes.Add("colspan", "6");
                    row.Cells[0].Attributes.Add("style", "text-align: center");
                }
                if (row.RowIndex == 1 || row.RowIndex == 2 || row.RowIndex == 3)
                {
                    row.BackColor = Color.LightGray;
                    row.Cells[1].Visible = false;
                    row.Cells[3].Visible = false;
                    row.Cells[4].Visible = false;
                    row.Cells[5].Visible = false;
                    row.Cells[0].Attributes.Add("colspan", "2");
                    row.Cells[0].Attributes.Add("style", "text-align: center");
                    row.Cells[2].Attributes.Add("colspan", "4");
                    row.Cells[2].Attributes.Add("style", "text-align: center");
                }
            }
            dgGrid.RenderControl(htextw);
            Response.Write(stw.ToString());
            Response.End();
        }
    }



    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            if (RadioButtonList1.SelectedIndex == 0)
            {

                string scriptSTR = "<script language=javascript>alert('Please select at least one Centre !');</script>";
                if (!Page.IsStartupScriptRegistered("clientscript"))
                {
                    Page.RegisterStartupScript("clientscript", scriptSTR);
                }
                return;
            }
            if (RadioButtonList3.SelectedIndex == -1)
            {
                string scriptSTR = "<script language=javascript>alert('Please select at least one Date !');</script>";
                if (!Page.IsStartupScriptRegistered("clientscript"))
                {
                    Page.RegisterStartupScript("clientscript", scriptSTR);
                }
                return;
            }
            if (RadioButtonList2.SelectedIndex == -1)
            {
                string scriptSTR = "<script language=javascript>alert('Please select at least one Slot !');</script>";
                if (!Page.IsStartupScriptRegistered("clientscript"))
                {
                    Page.RegisterStartupScript("clientscript", scriptSTR);
                }
                return;
            }
            ExportToExcel();
        }
        catch (Exception ex) 
        {
        }
    }

}