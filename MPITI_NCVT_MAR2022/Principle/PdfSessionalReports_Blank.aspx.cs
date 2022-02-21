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
    int admissionyear;
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
        string strTrade = Session["Trade"].ToString();
        string strTradeDuration = Session["TradeDuration"].ToString();
        string strITICode = Session["strITICode"].ToString();
        string strExamName = "SESSIONAL MARKS ENTRY";
        string tradeType = Session["tradeType"].ToString();

        //lblITIName.Text = Session["strITICode"].ToString() + '-' + Session["ITIName"].ToString();
        lblAdmissionYear.Text = strAdmissionYear;
        admissionyear = int.Parse(strAdmissionYear);
        lblITIName.Text = Session["strITICode"].ToString();
        lblTradeName.Text = Session["TradeName"].ToString();
        if (admissionyear <= 2017)
        {
            lblSemester.Text = "Sem-" + Session["strSemID"].ToString();
        }
        else if (admissionyear > 2017 && Session["strSemID"].ToString() == "2")
        {
            lblSemester.Text = "1st Year";
        }
        else if (admissionyear > 2017 && Session["strSemID"].ToString() == "4")
        {
            lblSemester.Text = "2nd Year";
        }
        lblAdmissionYear.Text = strAdmissionYear;
        tbExamType.InnerText = strExamName;
        lblTradeDuration.Text = strTradeDuration;


        Ds = MySql.GetDataSetWithQuery("Exec BindGridinSessional_Print @AdmissionYear=" + strAdmissionYear + ",@Semester=" + strSemID + ", @ExamType='" + strExamType + "', @Trade=" + strTrade + ",@ITICode='" + strITICode + "'");
        
            if (Ds.Tables[0].Rows.Count > 0)
            {

                string strData = "<table style='width:100%;' cellpadding='0' cellspacing='0'>";

                strData = strData + "<tr>" +
                    "<td style='width:5%; border-bottom:1px solid; border-left:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>SR.NO.</td>" +
                    "<td style='width:10%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>ROLL NO</td>";
                //"<td style='width:15%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Employability Skills Sessional</td>";

                strData = strData +
                    "<td style='width:15%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Trade Theory sessional</td>" +
                    "<td style='width:15%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Present/Absent</td>" +
                    "<td style='width:15%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Workshop Calc & Science Sessional</td>" +
                    "<td style='width:15%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Present/Absent</td>" +
                    "<td style='width:15%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Engineering Drawing Sessional</td>" +
                    "<td style='width:15%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Present/Absent</td>" +
                    "<td style='width:15%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Trade Practical Sessional</td>" +
                    "<td style='width:15%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Present/Absent</td>";
                if (strTrade == "109")
                {
                    strData += "<td style='width:15%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Trade Practical II</td>" +
                    "<td style='width:15%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Present/Absent</td>" +
                    "<td style='width:15%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Project Work</td>" +
                    "<td style='width:15%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Present/Absent</td>" +
                    "<td style='width:15%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Trade Practical II Sessional</td>" +
                   "<td style='width:10%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Present/Absent</td>";
                    
                }
                    strData += "</tr>";


                for (int i = 0; i <= Ds.Tables[0].Rows.Count - 1; i++)
                {
                    strData = strData + "<tr>";
                    strData = strData + "<td style='border-bottom:1px solid; border-left:1px solid; border-right:1px solid; text-align:center;'>" + (i + 1) + "</td>";
                    strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["RollNo"] + "</td>";


                    strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["TradeTheorySessional"] + "</td>";
                    strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["Absent"] + "</td>";

                    strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["WorkshopCalcSessional"] + "</td>";
                    strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["Absent1"] + "</td>";

                    strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["EDSessional"] + "</td>";
                    strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["Absent2"] + "</td>";

                    strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["TradePracticalSessional"] + "</td>";
                    strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["Absent3"] + "</td>";

                    if (strTrade == "109")
                    {

                        strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["TradePracticalII"] + "</td>";
                        strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["Absent4"] + "</td>";

                        strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["ProjectWork"] + "</td>";
                        strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["Absent5"] + "</td>";

                        strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["TradePracticalIISessional"] + "</td>";
                        strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["Absent6"] + "</td>";
                    }
                    strData = strData + "</tr>";
                }
                strData = strData +
                "<tr height='20Px'><td colspan='16'></td><tr></table>";
                lblData.Text = strData;
            }
       
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("Joindirector.aspx");
    }
}