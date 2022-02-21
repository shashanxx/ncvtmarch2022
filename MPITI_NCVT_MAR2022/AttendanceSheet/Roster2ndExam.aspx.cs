using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using Common.Class;

public partial class AttendanceSheet_Roster2ndExam : System.Web.UI.Page
{
    string strcenterid = "";
    string strslot = "";
    string strexamtime = "";
    string strexammode = "";
    string strcount = "";
    string seat = "";
    CommonPerception MySql = new CommonPerception();

    protected void Page_Load(object sender, EventArgs e)

    {
        if (!IsPostBack)
        {

            // strcenterid = "101"; 
           strcenterid= Request.QueryString["centerid"].ToString();
            // strslot = "1"; 
          strslot=  Request.QueryString["slot"].ToString();
            //  strexamtime = "2017-08-26";
           strexamtime= Request.QueryString["examtime"].ToString();

             strexammode = "Online"; 
         //  strexammode =Request.QueryString["ExamMode"].ToString();
                                  // strcount = Request.QueryString["count"].ToString();

            if (strexammode == "Online")
            {
                roster2();
            }


        }


    }

    void roster2()
    {

        DataSet ds = MySql.GetDataSetWithQuery("Exec SP_GenerateRoaster '" + strcenterid + "','" + strslot + "','" + strexamtime + "' ");
        if (ds.Tables[0].Rows.Count > 0)
        {


            DataTable dt = ds.Tables[0];
            //string strcentercode = Convert.ToString(ds.Tables[0].Rows[0]["CenterCode"]);
            int startpage = 0;
            int mod = Convert.ToInt32(ds.Tables[0].Rows.Count) % 10 > 0 ? 1 : 0;
            int endpage = (Convert.ToInt32(ds.Tables[0].Rows.Count) / 10) + mod;
            StringBuilder html = new StringBuilder();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                // string strpost = Convert.ToString(ds.Tables[0].Rows[0]["POSTNAME1"]).ToUpper();

                if (i == 0 || i % 10 == 0)
                {
                    if (i > 0)
                    {
                        html.Append("<tr>");
                        html.Append("<td   align='center' colspan='3' style='height:25px' bgcolor='Silver' >");
                        html.Append("TOTAL PRESENT");
                        html.Append("</td>");
                        html.Append("<td   align='center' colspan='4'  >");
                        html.Append("");
                        html.Append("</td>");
                        html.Append("<td   align='center' colspan='3' style='height:25px' bgcolor='Silver' >");
                        html.Append("TOTAL ABSENT");
                        html.Append("</td>");
                        html.Append("<td   align='center' colspan='3'  >");
                        html.Append("");
                        html.Append("</td>");
                        html.Append("</tr>");

                        html.Append("<tr>");
                        html.Append("<td   align='center' colspan='3' style='height:75px' bgcolor='Silver' >");
                        html.Append("INVIGILATOR'S SIGNATURE");
                        html.Append("</td>");
                        html.Append("<td   align='center' colspan='4'  >");
                        html.Append("");
                        html.Append("</td>");
                        html.Append("<td   align='center' colspan='3' style='height:75px' bgcolor='Silver' >");
                        html.Append("INVIGILATOR'S MOBILE NO");
                        html.Append("</td>");
                        html.Append("<td   align='center' colspan='3'  >");
                        html.Append("");
                        html.Append("</td>");
                        html.Append("</tr>");

                        html.Append("</table>");
                        html.Append("</br>");
                        //html.Append("</br>");
                        // html.Append("</br>");
                        //html.Append("</br>");
                        // html.Append("</br>");

                    }
                    startpage = (i / 10) + 1;
                    html.Append("<table border = '0' style='font-family: Verdana; font-size: small;border-width: 1px; cellpadding='0'; cellspacing='0'' width='100%' >");
                    html.Append("<tr>");
                    html.Append("<td align='center' style='padding-left:150px'>");
                    html.Append("<b><u>JPSICE-2017 (MAIN EXAM)</br>ATTENDANCE SHEET </u></b>");
                    html.Append("</td>");
                    html.Append("<td align='right'>");
                    html.Append("Page <span style=color: navy; font-weight: bold>" + startpage + "</span> of <span style='font-size: 16px; color: green; font-weight: bold'>" + endpage + "</span> pages");
                    html.Append("</td>");
                    html.Append("</tr>");
                    html.Append("</table>");
                    // html.Append("</br>");
                    // html.Append("</br>");

                    html.Append("<table border = '1' style='font-family: Verdana; font-size: small;border-width: 1px; cellpadding='0'; cellspacing='0'' width=100%>");
                    html.Append("<tr>");
                    html.Append("<td colspan='12'>");
                    html.Append("<table border = '1' style='font-family: Verdana; text-align:center; font-size: small;border-width: 1px; cellpadding='0'; cellspacing='0'' width=100% >");
                    html.Append("<tr style=height:60px>");
                    html.Append("<td  width=10% align='center' bgcolor='Silver' >");
                    html.Append("CENTER NAME");
                    html.Append("</td>");
                    html.Append("<td width='20%'>");
                    html.Append(Convert.ToString(ds.Tables[0].Rows[i]["CollegeName"]).ToUpper());
                    html.Append("<br/>");
                    html.Append(Convert.ToString(ds.Tables[0].Rows[i]["CollegeAddress"]).ToUpper());
                    html.Append("</td>");
                    html.Append("<td width='10%'  align='center' bgcolor='Silver' >");
                    html.Append("EXAM DATE");
                    html.Append("</td>");
                    html.Append("<td width='20%' colspan='3'>");
                    html.Append(Convert.ToString(ds.Tables[0].Rows[i]["phase2ExamDate"]).ToUpper());
                    html.Append("</td>");
                    //html.Append("<td width='20%'>PAPER 2 <br/>");
                    //html.Append(Convert.ToString(ds.Tables[0].Rows[i]["ExamDate"]).ToUpper());
                    //html.Append("</td>");
                    //html.Append("<td width='20%'>PAPER 3 <br/>");
                    //html.Append(Convert.ToString(ds.Tables[0].Rows[i]["ExamDate"]).ToUpper());
                    html.Append("</td>");
                    html.Append("</tr>");

                    html.Append("<tr>");
                    html.Append("<td  width=10% align='center' bgcolor='Silver' >");
                    html.Append("EXAM NAME");
                    html.Append("</td>");
                    html.Append("<td width='20%'>");
                    html.Append("Jharkhand Combined Police Sub Inspector Competitive Examination- 2017 (Main Exam)");
                    //html.Append(Convert.ToString(ds.Tables[0].Rows[i]["CollegeName"]).ToUpper());
                    //html.Append("<br/>");
                    //html.Append(Convert.ToString(ds.Tables[0].Rows[i]["CollegeAddress"]).ToUpper());
                    html.Append("</td>");
                    html.Append("<td width='10%'  align='center' bgcolor='Silver' >");
                    html.Append("EXAM TIME");
                    html.Append("</td>");
                    html.Append("<td width='20%'> PAPER 1 <br/>");
                    html.Append(Convert.ToString(ds.Tables[0].Rows[i]["Phase2Slot1SlotTiming"]).ToUpper());
                    html.Append("</td>");
                    html.Append("<td width='20%'> PAPER 2 <br/>");
                    html.Append(Convert.ToString(ds.Tables[0].Rows[i]["Phase2Slot2SlotTiming"]).ToUpper());
                    html.Append("</td>");
                    html.Append("<td width='20%'> PAPER 3 <br/>");
                    html.Append(Convert.ToString(ds.Tables[0].Rows[i]["Phase2Slot3SlotTiming"]).ToUpper());
                    html.Append("</td>");
                    html.Append("</tr>");
                    html.Append("</table>");


                    html.Append("</td>");
                    html.Append("</tr>");

                    html.Append("<tr>");
                    html.Append("<td width=5%  align='center'  bgcolor='Silver' >");
                    html.Append("S.NO");
                    html.Append("</td>");

                    html.Append("<td width=5%  align='center' colspan='1' bgcolor='Silver' >");
                    html.Append("ROLL NO.");
                    html.Append("</td>");

                    html.Append("<td  width=22% align='center' colspan='2' bgcolor='Silver'>");
                    html.Append("CANDIDATE NAME");
                    html.Append("</td>");
                    html.Append("<td  width=10% align='center' colspan='2' bgcolor='Silver'>");
                    html.Append("CANDIDATE PIC");
                    html.Append("</td>");
                    html.Append("<td width=10%   align='center' colspan='2' bgcolor='Silver'>");
                    html.Append("CANDIDATE <br/> SIGNATURE");
                    html.Append("</td>");
                    html.Append("<td  width=8%   align='center' colspan='1' bgcolor='Silver'>");
                    html.Append("SYSTEM NO.");
                    html.Append("</td>");
                    html.Append("<td width=10%    align='center' colspan='1' bgcolor='Silver'>");
                    html.Append("PAPER 1 <br/> CANDIDATE SIGNATURE");
                    html.Append("</td>");
                    html.Append("<td width=10%    align='center' colspan='1' bgcolor='Silver'>");
                    html.Append("PAPER 2 <br/> CANDIDATE SIGNATURE");
                    html.Append("</td>");
                    html.Append("<td width=10%    align='center' colspan='1' bgcolor='Silver'>");
                    html.Append("PAPER 3 <br/> CANDIDATE SIGNATURE");
                    html.Append("</td>");
                    html.Append("</tr>");
                }



                html.Append("<tr>");
                html.Append("<td   align='center'   >");
                html.Append(Convert.ToString(ds.Tables[0].Rows[i]["row"]));
                html.Append("</td>");

                html.Append("<td   align='center' colspan='1'>");
                html.Append(Convert.ToString(ds.Tables[0].Rows[i]["RollNo"]));
                html.Append("</td>");
                html.Append("<td   align='center' colspan='2'>");
                html.Append(Convert.ToString(ds.Tables[0].Rows[i]["CandidateName"]));
                html.Append("</td>");
                html.Append("<td   align='center' colspan='2' >");
                html.Append("<img Width='100px' Height='100px' src=\"" + Convert.ToString(ds.Tables[0].Rows[i]["PhotoPath"]) + "\">");
                html.Append("</td>");
                html.Append("<td   align='center' colspan='2' >");
                html.Append("<img Width='100px' Height='100px' src=\"" + Convert.ToString(ds.Tables[0].Rows[i]["SignPath"]) + "\">");
                html.Append("</td>");
                html.Append("<td   align='center'   >");
                html.Append("</td>");
                html.Append("<td   align='center' colspan='1' >");
                html.Append("");
                html.Append("</td>");
                html.Append("<td   align='center' colspan='1' >");
                html.Append("");
                html.Append("</td>");
                html.Append("<td   align='center' colspan='1' >");
                html.Append("");
                html.Append("</td>");
                html.Append("</tr>");
            }

            html.Append("<tr>");
            html.Append("<td   align='center' colspan='3' style='height:25px' bgcolor='Silver' >");
            html.Append("TOTAL PRESENT");
            html.Append("</td>");
            html.Append("<td   align='center' colspan='4'  >");
            html.Append("");
            html.Append("</td>");
            html.Append("<td   align='center' colspan='3' style='height:25px' bgcolor='Silver' >");
            html.Append("TOTAL ABSENT");
            html.Append("</td>");
            html.Append("<td   align='center' colspan='3'  >");
            html.Append("");
            html.Append("</td>");
            html.Append("</tr>");

            html.Append("<tr>");
            html.Append("<td   align='center' colspan='3' style='height:75px' bgcolor='Silver' >");
            html.Append("INVIGILATOR'S SIGNATURE");
            html.Append("</td>");
            html.Append("<td   align='center' colspan='4'  >");
            html.Append("");
            html.Append("</td>");
            html.Append("<td   align='center' colspan='3' style='height:75px' bgcolor='Silver' >");
            html.Append("INVIGILATOR'S MOBILE NO");
            html.Append("</td>");
            html.Append("<td   align='center' colspan='3'  >");
            html.Append("");
            html.Append("</td>");
            html.Append("</tr>");

            html.Append("</table>");

            PlaceHolder1.Controls.Add(new LiteralControl(html.ToString()));
        }
        else
        {
            Response.Write("No Data Found");
        }
    }
}