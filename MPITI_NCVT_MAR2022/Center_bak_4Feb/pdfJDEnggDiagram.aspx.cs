using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Class;
using System.Data;
using System.Data.SqlClient;

public partial class Center_pdfJDEnggDiagram : System.Web.UI.Page
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



       // string Actioncase = "caseEDSem4";
       // int strsession = 2;
       // string strITICode = "PU23000473";
       // int strSemID = 4;
       //string strTradeCode = "231";

        string Actioncase = Session["Actioncase"].ToString();
        string strsession = Session["strsession"].ToString();
        string strITICode = Session["strITICode"].ToString();
        string strSemID = Session["strSemID"].ToString();
        string strTradeCode = Session["strTradeCode"].ToString();
 
        //int strPaperID = 0;
        //string strEntryType = "P";
        ////string strRollnuber = null;
        //string strExaminerId = "22";

     //   DataSet dsExaminer = new DataSet();

       // dsExaminer = MySql.GetDataSet("SELECT ExaminerId, InternalName, IAdd, IPost, ExternalName, ExAdd, ExPost, CONVERT(VARCHAR(11), ExamDate, 106) As ExamDate  FROM  Tbl_ExaminerMaster WHERE examinerid='" + strExaminerId + "'");

       Ds = MySql.GetDataSetWithQuery("Exec BindGridinJDForReports @Actioncase=" + Actioncase + ",@session='" + strsession + "',@ITICode='" + strITICode + "', @Semester='" + strSemID + "', @TradeCode='" + strTradeCode + "'");
        if (Ds.Tables[0].Rows.Count > 0)
        {
            lblITIName.Text = Convert.ToString(Ds.Tables[0].Rows[0]["ITIName"]);
            lblTradeName.Text = Convert.ToString(Ds.Tables[0].Rows[0]["TradeName"]);
           // lblExamDate.Text = dsExaminer.Tables[0].Rows[0]["ExamDate"].ToString();
            lblSemester.Text = Convert.ToString(Ds.Tables[0].Rows[0]["Semester"]);

            string strData = "<table style='width:100%;' cellpadding='0' cellspacing='0'>";

            strData = strData + "<tr>" +
                "<td style='width:12%; border-bottom:1px solid; border-left:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>SR.NO.</td>" +
                "<td style='width:19%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>ROLL NO</td>" +
                //"<td style='width:20%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid;font-weight:bold;text-align:center;'>TRAINEE NAME</td>" +
                //"<td style='width:26%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Present/Absent</td>" +
                "<td style='width:19%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>PracticalMatks</td>" +
               "<td style='width:26%; border-bottom:1px solid; border-right:1px solid; border-top:1px solid; text-align:center;font-weight:bold;'>Present/Absent</td>"+ 
                "</tr>";


            for (int i = 0; i <= Ds.Tables[0].Rows.Count - 1; i++)
            {
                strData = strData + "<tr>";
                strData = strData + "<td style='border-bottom:1px solid; border-left:1px solid; border-right:1px solid; text-align:center;'>" + (i + 1) + "</td>";
                strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["RollNo"] + "</td>";
                //strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid;text-align:center;'>" + Ds.Tables[0].Rows[i]["TraineeName"] + "</td>";
               // strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["presentabsent"] + "</td>";
                strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["Marks"] + "</td>";
                //strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>" + Ds.Tables[0].Rows[i]["PresentAbsent"] + "</td>";
               strData = strData + "<td style='border-bottom:1px solid; border-right:1px solid; text-align:center;'>PRESENT</td>";

                strData = strData + "</tr>";
            }
            strData = strData +
            "<tr height='20Px'><td colspan='5'></td><tr>" +
           // "<tr><td style='font-weight:bold'>Internal Name:</td><td style='text-align:center;'>" + dsExaminer.Tables[0].Rows[0]["InternalName"] + "</td><td></td><td style='font-weight:bold;'>External Name</td><td style='text-align:center;'>" + dsExaminer.Tables[0].Rows[0]["ExternalName"] + "</td></tr>" +
            //"<tr><td style='font-weight:bold'>Address:</td><td style='text-align:center;'>" + dsExaminer.Tables[0].Rows[0]["IAdd"] + "</td><td></td><td style='font-weight:bold;'>Address</td><td style='text-align:center;'>" + dsExaminer.Tables[0].Rows[0]["ExAdd"] + "</td></tr>" +
           // "<tr><td style='font-weight:bold'>Post:</td><td style='text-align:center;'>" + dsExaminer.Tables[0].Rows[0]["IPost"] + "</td><td></td><td style='font-weight:bold;'>Post</td><td style='text-align:center;'>" + dsExaminer.Tables[0].Rows[0]["ExPost"] + "</td></tr>" +

            "</table>";

            lblData.Text = strData;
        }
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("ExamCenter.aspx");
    }
}