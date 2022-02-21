using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Class;
using System.Data;
using System.Data.SqlClient;

public partial class Principle_PdfPracticalMarksReports_Blank : System.Web.UI.Page
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
        string strEntryType = Session["EntryType"].ToString();
        string strExamName = "PRACTICAL MARKS ENTRY";

        if (strEntryType == "ED" || strEntryType == "SE" || strEntryType == "SH" || strEntryType == "SP")
        {
            strExamName = "ED/STENO/SP MARKS ENTRY";
        }
        else if (strEntryType == "PR")
        {
            strExamName = "PRACTICAL MARKS ENTRY";
        }
        else if (strEntryType == "WPM")
        {
            strExamName = "WPM MARKS ENTRY";
        }
        DataTable dt = MySql.GetDataTableWithQuery("select * from  tbl_User_Profile where Name='" + Session["Username"].ToString() + "'");
        string userType = Convert.ToString(dt.Rows[0]["userType"]);

        tbExamType.InnerText = strExamName;
        lblUName.Text = Convert.ToString(Session["Username"]);

        Ds = MySql.GetDataSetWithQuery("Exec BindGridinPracticalMarks_Print @UserName='" + Convert.ToString(Session["Username"]) + "'");
        if (Ds.Tables[0].Rows.Count > 0)
        {


            string strData = "<br /><table style='width:100%;' cellpadding='0' cellspacing='0'>";

            strData = strData + "<tr width='100%'>" +
                "<td style='width:5%; border-bottom:1px solid; border-left:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>SR.NO.</td>" +
                "<td style='width:10%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>MIS CODE</td>" +
                "<td style='width:10%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Roll Number</td>" +
                "<td style='width:10%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Candidate Name</td>" +
                "<td style='width:10%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Semester</td>" +
               "<td style='width:10%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Marks</td>";
            if (userType == "6")
            {
                strData = strData + "<td style='width:20%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Dictation 100WPM</td>";
            }
            strData = strData + "<td style='width:20%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>EntryType</td>";

            if (userType == "2")
            {
                strData = strData + "<td style='width:10%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>TradeType</td>";
            }

            strData = strData + "</tr>";


            for (int i = 0; i <= Ds.Tables[0].Rows.Count - 1; i++)
            {
                strData = strData + "<tr>";
                strData = strData + "<td style='border-bottom:1px solid; border-left:1px solid; border-right:1px solid; text-align:center;'>" + (i + 1) + "</td>";
                strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["ITICode"] + "</td>";
                strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["RollNumber"] + "</td>";
                strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["name"] + "</td>";
                strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["Semester"] + "</td>";
                strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["Marks"] + "</td>";
                if (userType == "6")
                {
                    strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["DictText"] + "</td>";
                }
                strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["EntryTypeText"] + "</td>";
                if (userType == "2")
                {
                    strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["TradeTypeText"] + "</td>";
                }
                strData = strData + "</tr>";
            }
            strData = strData +
            "<tr height='20Px'><td colspan='6'></td><tr></table>";

            lblData.Text = strData;
        }
    }
}