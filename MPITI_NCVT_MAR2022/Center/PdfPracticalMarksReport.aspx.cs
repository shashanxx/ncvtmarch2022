using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Class;
using System.Data;
using System.Data.SqlClient;

public partial class Center_PdfPracticalMarksReport : ClsErrorLog
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
        string strExaminerId = Convert.ToString(Session["rptExaminerId"]);

        //int strSessionID = 2;
        //string strITICode = "PR23000230";
        //int strSemID = 3;
        //string strTradeCode = "231";
        //int strPaperID = 0;
        //string strEntryType = "P";
        ////string strRollnuber = null;
        //string strExaminerId = "22";
       
        DataSet dsExaminer=new DataSet();

        dsExaminer = MySql.GetDataSet("SELECT ExaminerId, InternalName, IAdd, IPost, ExternalName, ExAdd, ExPost, CONVERT(VARCHAR(11), ExamDate, 106) As ExamDate  FROM  Tbl_ExaminerMaster WHERE examinerid='" + strExaminerId + "'");
        if (dsExaminer.Tables[0].Rows.Count > 0)
        {


            Ds = MySql.GetDataSetWithQuery("Exec sp_getOMRDetails " + strSessionID + ",'" + strITICode + "'," + strSemID + ",'" + strTradeCode + "'," + strPaperID + ",'" + strEntryType + "', '" + strExaminerId + "'");
            if (Ds.Tables[0].Rows.Count > 0)
            {
                lblITIName.Text = Convert.ToString(Ds.Tables[0].Rows[0]["ITIName"]);
                lblTradeName.Text = Convert.ToString(Ds.Tables[0].Rows[0]["TradeName"]);
                lblExamDate.Text = dsExaminer.Tables[0].Rows[0]["ExamDate"].ToString();
                lblSemester.Text = Convert.ToString(Ds.Tables[0].Rows[0]["Semester"]);

                string strData = "<table style='width:100%;' cellpadding='0' cellspacing='0'>";

                strData = strData + "<tr>" +
                    "<td style='width:12%; border-bottom:1px solid; border-left:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>SR.NO.</td>" +
                    "<td style='width:19%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>ROLL NO</td>" +
                    "<td style='width:20%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid;font-weight:bold;text-align:center;'>TRAINEE NAME</td>" +
                    "<td style='width:26%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Present/Absent</td>" +
                    "<td style='width:19%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>PracticalMatks</td>" +
                    "</tr>";


                for (int i = 0; i <= Ds.Tables[0].Rows.Count - 1; i++)
                {
                    strData = strData + "<tr>";
                    strData = strData + "<td style='border-bottom:1px solid; border-left:1px solid; border-right:1px solid; text-align:center;'>" + (i + 1) + "</td>";
                    strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["RollNo"] + "</td>";
                    strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid;text-align:center;'>" + Ds.Tables[0].Rows[i]["TraineeName"] + "</td>";
                    strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["presentabsent"] + "</td>";
                    strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["PracticalMarks"] + "</td>";
                    //strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["PresentAbsent"] + "</td>";
                    //strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>PRESENT</td>";

                    strData = strData + "</tr>";
                }
                strData = strData +
                "<tr height='20Px'><td colspan='5'></td><tr>" +
                "<tr><td style='font-weight:bold'>Internal Name:</td><td style='text-align:center;'>" + dsExaminer.Tables[0].Rows[0]["InternalName"] + "</td><td></td><td style='font-weight:bold;'>External Name</td><td style='text-align:center;'>" + dsExaminer.Tables[0].Rows[0]["ExternalName"] + "</td></tr>" +
                "<tr><td style='font-weight:bold'>Address:</td><td style='text-align:center;'>" + dsExaminer.Tables[0].Rows[0]["IAdd"] + "</td><td></td><td style='font-weight:bold;'>Address</td><td style='text-align:center;'>" + dsExaminer.Tables[0].Rows[0]["ExAdd"] + "</td></tr>" +
                "<tr><td style='font-weight:bold'>Post:</td><td style='text-align:center;'>" + dsExaminer.Tables[0].Rows[0]["IPost"] + "</td><td></td><td style='font-weight:bold;'>Post</td><td style='text-align:center;'>" + dsExaminer.Tables[0].Rows[0]["ExPost"] + "</td></tr>" +

                "</table>";

                lblData.Text = strData;
            }
        }
        else
        {
            Response.Redirect("ExamCenterReport.aspx");
        }
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("ExamCenter.aspx");
    }
}