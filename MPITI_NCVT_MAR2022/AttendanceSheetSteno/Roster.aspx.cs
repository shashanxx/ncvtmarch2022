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
using System.Drawing;
using System.Drawing.Imaging;

public partial class SchedulerJune2016_Roster : System.Web.UI.Page
{
    string strcenterid = "";
    string StartPoint = "";
    string strslot = "";
    string strShift = "";
    string strdate = "";
    string showstrtime = "";
    CommonPerception MySql = new CommonPerception();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            strcenterid = Request.QueryString["centerid"].ToString();
            strslot = Request.QueryString["slot"].ToString();
            strdate = Request.QueryString["date"].ToString();
            if (strslot == "1")
            {
                strShift = "1900-01-01 10:00:00.000";
                showstrtime = "10:00 AM";
            }
            else if (strslot == "2")
            {
                strShift = "1900-01-01 10:30:00.000";
                showstrtime = "10:30 AM";
            }
            else if (strslot == "3")
            {
                strShift = "1900-01-01 14:00:00.000";
                showstrtime = "02:00 PM";
            }
            else if (strslot == "4")
            {
                strShift = "1900-01-01 15:00:00.000";
                showstrtime = "03:00 PM";
            }

            roster2();
        }
    }

    void roster2()
    {
        DataSet ds = MySql.GetDataSetWithQuery("Exec SP_GenerateRoaster_steno '" + strcenterid + "',  '" + strShift + "',  '" + strdate + " 00:00:00.000' ");
        DataTable dt = ds.Tables[0];
        int startpage = 0;
        int mod = Convert.ToInt32(ds.Tables[0].Rows.Count) % 10 > 0 ? 1 : 0;
        int endpage = ((Convert.ToInt32(ds.Tables[0].Rows.Count)) / 10) + mod;
        StringBuilder html = new StringBuilder();

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            if (i == 0 || i % 10 == 0)
            {
                if (i > 0)
                {
                    html.Append("<tr>");
                    html.Append("<td colspan='3' style='vertical-align:bottom;height:105px;text-align:center;'>");
                    html.Append("INVIGILATOR'S SIGNATURE");
                    html.Append("</td>");
                    html.Append("<td style='vertical-align:bottom;height:105px;text-align:center;' colspan='3'>");
                    html.Append("SIGNATURE OF OFFICER IN-CHARGE");
                    html.Append("</td>");
                    html.Append("<td colspan='2' style='vertical-align:bottom;height:105px;text-align:center;'>");
                    html.Append("SIGNATURE OF CENTRE SUPERVISOR");
                    html.Append("</td>");
                    html.Append("</tr>");

                    html.Append("</table>");
                    html.Append("</br><div class='pagebreak'></div>");

                }
                startpage = (i / 10) + 1;
                html.Append("<table border = '0' style='font-family: Verdana; font-size: small;border-width: 1px; cellpadding='0'; cellspacing='0'' width='100%' >");

                html.Append("<tr width='100%'>");
                html.Append("<td align='left' width='20%'>");
                html.Append("");
                html.Append("</td>");
                html.Append("<td align='center' style='font-size:15px;'>");
                html.Append("<b>MP ITI NCVT Steno Typing Test Exam Oct-2021");
                //html.Append(Convert.ToString(ds.Tables[0].Rows[i]["PostName"]).ToUpper());
                html.Append("</b></td>");
                html.Append("</tr>");
                html.Append("</table>");

                html.Append("<table border = '0' style='font-family: Verdana; font-size: small;border-width: 1px; cellpadding='0'; cellspacing='0'' width='100%' >");
                html.Append("<tr>");
                //html.Append("<td align='left' style='font-size:15px;'>");
                //html.Append("<b>");
                //html.Append("VENUE CODE :");
                //html.Append(Convert.ToString(ds.Tables[0].Rows[i]["vcode"]).ToUpper());
                //html.Append("</b></td>");
                html.Append("<td colspan='2' align='right'>");
                html.Append("Page No. <span style='font-size: 16px; color: green; font-weight: bold'>" + startpage + "</span>");
                html.Append("</td>");
                html.Append("</tr>");

                html.Append("<tr nowrap='nowrap'>");
                html.Append("<td align='left' style='font-size:15px;'>");
                html.Append("<b>");
                html.Append("VENUE NAME :");
                html.Append(Convert.ToString(ds.Tables[0].Rows[i]["Center"]).ToUpper());
                //html.Append("<br>");
                html.Append(", ");
                html.Append(Convert.ToString(ds.Tables[0].Rows[i]["Address"]).ToUpper());
                html.Append("</b></td>");
                html.Append("<td align='left' style='font-size:15px;' width='35%'>");
                html.Append("<b>");
                html.Append("EXAM DATE:");
                html.Append(Convert.ToString(ds.Tables[0].Rows[i]["ExamDate"]).ToUpper());
                html.Append("<br>");
                //html.Append("EXAM TIME :");
                //html.Append(Convert.ToString(ds.Tables[0].Rows[i]["ExamTime"]).ToUpper());
                html.Append("Shift:");
                html.Append(showstrtime);
                html.Append("</b></td>");
                html.Append("</tr>");
                
                html.Append("</table>");

                html.Append("<table cellspacing='0' border='1' style='font-family: Verdana; font-size: small;border:1px solid black;' width='100%' >");

                html.Append("<tr width='100%'>");
                html.Append("<td width='5%' style='font-size:15px;height:30px;'>");
                html.Append("<b>SL.NO.</b></td>");

                html.Append("<td width='10%' style='font-size:15px;height:30px;'>");
                html.Append("<b>ROLL NO.</b></td>");

                html.Append("<td width='20%' style='font-size:15px;height:30px;'>");
                html.Append("<b>CANDIDATE NAME</b></td>");

                html.Append("<td width='10%' style='font-size:15px;height:30px;'>");
                html.Append("<b>DOB</b></td>");

                html.Append("<td width='10%' style='font-size:15px;height:30px;'>");
                html.Append("<b>PIN Number</b></td>");

                html.Append("<td width='10%' style='font-size:15px;height:30px;'>");
                html.Append("<b>YEAR</b></td>");

                html.Append("<td width='10%' style='font-size:15px;height:30px;'>");
                html.Append("<b>EXAM TYPE</b></td>");

                html.Append("<td width='15%' style='font-size:15px;height:30px;'>");
                html.Append("<b>ITI NAME</b></td>");

                html.Append("<td width='10%' style='font-size:15px;height:30px;'>");
                html.Append("<b>SIGNATURE</b></td>");

                html.Append("</tr>");

            }

            html.Append("<tr width='100%'>");
            html.Append("<td width='5%' style='font-size:12px;height:105px;text-align:center;'>");
            html.Append("<b>");
            html.Append(i+1);
            html.Append(" </b></td>");

            html.Append("<td width='10%' style='font-size:12px;text-align:center;'>");
            html.Append("<b>");
            html.Append(Convert.ToString(ds.Tables[0].Rows[i]["RollNumber"]));
            html.Append(" </b></td>");

            html.Append("<td width='20%' style='font-size:12px;'>");
            html.Append("<b>");
            html.Append(Convert.ToString(ds.Tables[0].Rows[i]["Name"]));           
            html.Append(" </b></td>");

            html.Append("<td width='10%' style='font-size:12px;text-align:center;'>");
            html.Append("<b>");
            html.Append(Convert.ToString(ds.Tables[0].Rows[i]["DOB"]));
            html.Append(" </b></td>");

            html.Append("<td width='10%' style='font-size:12px;text-align:center;'>");
            html.Append("<b>");
            html.Append(Convert.ToString(ds.Tables[0].Rows[i]["PIN"]));
            html.Append(" </b></td>");

            html.Append("<td width='10%' style='font-size:12px;text-align:center;'>");
            html.Append("<b>");
            html.Append(Convert.ToString(ds.Tables[0].Rows[i]["Semester"]));
            html.Append(" </b></td>");

            html.Append("<td width='10%' style='font-size:12px;text-align:center;'>");
            html.Append("<b>");
            html.Append(Convert.ToString(ds.Tables[0].Rows[i]["Examtype"]));
            html.Append(" </b></td>");

            html.Append("<td width='15%' style='font-size:12px;'>");
            html.Append("<b>");
            html.Append(Convert.ToString(ds.Tables[0].Rows[i]["ITIName"]));
            html.Append(" </b></td>");

            html.Append("<td width='10%'>");            
            html.Append(" </td>");

            html.Append("</tr>");            
        }

        html.Append("<tr>");
        html.Append("<td colspan='3' style='vertical-align:bottom;height:105px;text-align:center;'>");
        html.Append("INVIGILATOR'S SIGNATURE");
        html.Append("</td>");
        html.Append("<td style='vertical-align:bottom;height:105px;text-align:center;' colspan='3'>");
        html.Append("SIGNATURE OF OFFICER IN-CHARGE");
        html.Append("</td>");
        html.Append("<td colspan='2' style='vertical-align:bottom;height:105px;text-align:center;'>");
        html.Append("SIGNATURE OF CENTRE SUPERVISOR");
        html.Append("</td>");
        html.Append("</tr>");

        html.Append("</table>");
        PlaceHolder1.Controls.Add(new LiteralControl(html.ToString()));
    }


}