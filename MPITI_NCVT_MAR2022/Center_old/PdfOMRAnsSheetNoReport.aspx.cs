using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Class;
using System.Data;
using System.Data.SqlClient;

public partial class Center_PdfOMRAnsSheetNoReport : ClsErrorLog
{
    CommonPerception MySql = new CommonPerception();
    string strRollNo = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindOMRDetails();
        }        
    }

    protected void BindOMRDetails()
    {
        DataSet Ds = new DataSet();

        int strSessionID = Convert.ToInt32(Session["rptSessionID"]);
        string strITICode = Convert.ToString(Session["rptITICode"]);
        int strSemID = Convert.ToInt32(Session["rptSemID"]);
        string strTradeCode = Convert.ToString(Session["rptTradeCode"]);
        int strPaperID = Convert.ToInt32(Session["rptPaperID"]);
        string strEntryType = Convert.ToString(Session["rptEntryType"]);
        string strRollnuber = Convert.ToString(Session["rptRollnuber"]); 

        //int strSessionID = Convert.ToInt32(Session["rptSessionID"]);
        //string strITICode = Convert.ToString(Session["rptITICode"]);
        //int strSemID = Convert.ToInt32(Session["rptSemID"]);
        //string strTradeCode = Convert.ToString(Session["rptTradeCode"]);
        //int strPaperID = Convert.ToInt32(Session["rptPaperID"]);
        //string strEntryType = Convert.ToString(Session["rptEntryType"]);
        //string strRollnuber = Convert.ToString(Session["rptRollnuber"]);

        Ds = MySql.GetDataSetWithQuery("Exec sp_getOMRDetails " + strSessionID + ",'" + strITICode + "'," + strSemID + ",'" + strTradeCode + "'," + strPaperID + ",'" + strEntryType + "'");
        if (Ds.Tables[0].Rows.Count > 0)
        {
            lblITIName.Text = Convert.ToString(Ds.Tables[0].Rows[0]["ITIName"]);
            lblTradeName.Text = Convert.ToString(Ds.Tables[0].Rows[0]["TradeName"]);


            lblExamDate.Text = Convert.ToString(Ds.Tables[0].Rows[0]["DateOfExam"]);
           
            lblSemester.Text = Convert.ToString(Ds.Tables[0].Rows[0]["Semester"]);

            string strData = "<table style='width:100%;' cellpadding='0' cellspacing='0'>";

            strData = strData + "<tr>"+
                "<td style='width:12%; border-bottom:1px solid; border-left:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>SR.NO.</td>" +
                "<td style='width:19%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>ROLL NO</td>" +
                "<td style='width:20%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid;font-weight:bold;'>TRAINEE NAME</td>" +
                "<td style='width:26%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>OMR ANSWER SHEET NO.</td>" +
                "<td style='width:19%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>STATUS</td>" +
            "</tr>";

            for (int i = 0; i <= Ds.Tables[0].Rows.Count - 1; i++)
            {
                strData = strData + "<tr>";
                strData = strData + "<td style='border-bottom:1px solid; border-left:1px solid; border-right:1px solid; text-align:center;'>" + (i + 1) + "</td>";
                strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["RollNo"] + "</td>";
                strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid;'>" + Ds.Tables[0].Rows[i]["TraineeName"] + "</td>";
                strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["OMRMarks"] + "</td>";
                strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["PresentAbsent"] + "</td>";
                //strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>PRESENT</td>";

                strData = strData + "</tr>";
            }
            strData = strData + "</table>";

            lblData.Text = strData;
        }
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("ExamCenter.aspx");
    }
}