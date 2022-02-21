using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Class;
using System.Data;
using System.Data.SqlClient;


public partial class Student_WelcomePage : ClsErrorLog
{
    CommonPerception Mysql = new CommonPerception();
    DataSet ds = new DataSet();
    string CID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
            Response.Redirect("../Login/LoginNew.aspx");
        else
        {
            lblUName.Text = "Welcome " + Session["Username"].ToString();
            CID = Convert.ToString(Session["Username"]);
        }
        if (!IsPostBack)
        {
            lblmsg.Text = "Exam City preferences are saved successfully.";
            GetCandidateName();
        }
    }

    protected void btnexit_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Login/LoginNew.aspx");
    }

    protected void GetVerificationstatus()//Need to develop more
    {
        string str = Mysql.SingleCellResultInString("select * from tbl_Student where RollNumber='" + CID + "'");
        if(string.IsNullOrEmpty(str))
        {
            lblverificationstatus.Text = "";
        }
    }
    protected void GetCandidateName()
    {
        string strstdName = Mysql.SingleCellResultInString("GetCandidateDetails @RollNumber='" + CID + "'");
        ds = Mysql.GetDataSetWithQuery("GetCandidateDetails @RollNumber = '" + CID + "'");
        if(ds.Tables[0].Rows.Count>0)
        {
            lblcandidatename.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            lblexamcity1.Text = ds.Tables[0].Rows[0]["examcity1"].ToString();
            lblexamcity2.Text = ds.Tables[0].Rows[0]["examcity2"].ToString();
            lblexamcity3.Text = ds.Tables[0].Rows[0]["examcity3"].ToString();
            lbldistrict.Text = ds.Tables[0].Rows[0]["district"].ToString();
            lblzone.Text = ds.Tables[0].Rows[0]["division"].ToString();
            lblverificationstatus.Text= ds.Tables[0].Rows[0]["ApprovalStatus"].ToString();
            if (lblverificationstatus.Text == "Approval Pending")
            {
                lblpendingmsg.Text = "(Verification is pending, please contact your respective ITI)";
            }
        }
        
    }
    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Response.Redirect("../Login/LogOut.aspx");
    }
}