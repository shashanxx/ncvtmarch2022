using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Class;
using System.Data;
using System.Data.SqlClient;

public partial class Center_PdfJDReports_Blank : System.Web.UI.Page
{
    CommonPerception MySql = new CommonPerception();
    string strRollNo = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindOMRDetails();
        }
    }

    protected void BindOMRDetails()
    {
        DataSet Ds = new DataSet();

        string strAdmissionYear = Session["AdmissionYear"].ToString();
        string strSemID = Session["strSemID"].ToString();
        string strExamType = Session["ExamType"].ToString();
        string strEntryType = Session["EntryType"].ToString();
        string strTrade = Session["Trade"].ToString();
        string strTradeDuration = Session["TradeDuration"].ToString();
        string strITICode = Session["strITICode"].ToString();
        string strDivision = Session["Username"].ToString();
        string strDistrict = Session["District"].ToString();
        string strExamName = "ENGG DRAWING MARKS ENTRY";
        if (strEntryType == "ED")
        {
            strExamName = "ENGG DRAWING MARKS ENTRY";
        }
        else if (strEntryType == "SE")
        {
            strExamName = "STENOGRAPHER & SECRETARIAL ASSISTANT (ENGLISH)";
            //strTrade = "Stenographer & Secretarial Assistant (English)";
            strTradeDuration = "";
        }
        else if (strEntryType == "SH")
        {
            strExamName = "STENOGRAPHER & SECRETARIAL ASSISTANT (HINDI)";
            //strTrade = "Stenographer & Secretarial Assistant (Hindi)";
            strTradeDuration = "";
        }
        else if (strEntryType == "SP")
        {
            strExamName = "Secretarial Practice (English)";
            //strTrade = "Secretarial Practice (English)";
            strTradeDuration = "";
        }

        string semesterstr = "";
        if (Convert.ToInt32(strAdmissionYear) >= 2018)
        {
            if (Session["strSemID"].ToString() == "2")
            {
                semesterstr = "Year-1";
            }
            if (Session["strSemID"].ToString() == "4")
            {
                semesterstr = "Year-2";
            }            
        }
        else
        {
            semesterstr = "Sem-"+ Session["strSemID"].ToString();
        }

        lblITIName.Text = Session["strITICode"].ToString() + '-' + Session["ITIName"].ToString();
        lblTradeName.Text = strExamName;
        lblSemester.Text = semesterstr;
        lblAdmissionYear.Text = strAdmissionYear;
        tbExamType.InnerText = strExamName;
        lblTradeDuration.Text = strTradeDuration;


        Ds = MySql.GetDataSetWithQuery("Exec BindGridinJD_Print1 @AdmissionYear=" + strAdmissionYear + ",@Semester=" + strSemID + ", @ExamType='" + strExamType + "', @Trade=" + strTrade + ",@ITICode='" + strITICode + "', @Division='" + strDivision + "', @District='" + strDistrict + "', @EntryType='" + strEntryType + "'");
        if (Ds.Tables[0].Rows.Count > 0)
        {


            string strData = "<table style='width:100%;' cellpadding='0' cellspacing='0'>";

            strData = strData + "<tr>" +
                "<td style='width:12%; border-bottom:1px solid; border-left:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>SR.NO.</td>" +
                "<td style='width:19%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>ROLL NO</td>";

            if (strEntryType != "ED")
            {
                strData = strData + "<td style='width:19%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Practical Marks</td>";
                if (strSemID == "2")
                {
                    strData = strData + "<td style='width:19%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Dictation 100 WPM</td>";
                }
            }
            else
            {
                strData = strData + "<td style='width:19%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>ED Marks(50)</td>";
            }
            strData = strData + "<td style='width:26%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Present/Absent</td>" +
                "<td style='width:26%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Marks Entered Date</td>" +
            "</tr>";


            for (int i = 0; i <= Ds.Tables[0].Rows.Count - 1; i++)
            {
                strData = strData + "<tr>";
                strData = strData + "<td style='border-bottom:1px solid; border-left:1px solid; border-right:1px solid; text-align:center;'>" + (i + 1) + "</td>";
                strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["RollNo"] + "</td>";
                strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["Pmarks"] + "</td>";
                if (strEntryType != "ED" && strSemID == "2")
                {
                    strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["dictation100"] + "</td>";
                }
                strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["Absent"] + "</td>";
                strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["Cdate"] + "</td>";

                strData = strData + "</tr>";
            }
            strData = strData +
            "<tr height='20Px'><td colspan='3'></td><tr></table>";

            lblData.Text = strData;
        }
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("PracticalMarksEntryForm1.aspx");
    }
}