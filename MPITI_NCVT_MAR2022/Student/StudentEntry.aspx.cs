using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Class;
using System.Data;
using System.Data.SqlClient;


public partial class Student_StudentEntry : ClsErrorLog
{
    CommonPerception Mysql = new CommonPerception();
    DataSet ds = new DataSet();
    string CID;
    protected void Page_Load(object sender, EventArgs e)
    {

        //Response.Redirect("../Dashboard.aspx");
        // Session["Canid"] = "ABC001";
        if (Session["Username"] == null)
            Response.Redirect("../Login/LoginNew.aspx");
        else
        {
            lblUName.Text = "Welcome " + Session["Username"].ToString();
            CID = Convert.ToString(Session["Username"]);
            CheckStudentStatus();
        }
       // if (!IsPostBack)
        //{
            CheckLoginTime();
        //}
        if (!IsPostBack)
        {
            
            BindExamCity1();
            BindDistrict();
            BindZone();
            GetCandidateName();
        }
    }
    private void CheckLoginTime()
    {
        string UsrName = Mysql.SingleCellResultInString("exec CheckLoginTime @UserName='" + Session["Username"].ToString() + "',@UserType=" + Convert.ToInt32(Session["UserType"].ToString()) + ",@LoginDate='" + Session["LoginTime"].ToString() + "'");
        if (string.IsNullOrEmpty(UsrName))
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("../Login/LogOut.aspx");
        }
    }
    protected void btnexit_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Login/LoginNew.aspx");
    }

    protected void BindExamCity1()
    {
        ddlexamcity1.Items.Clear();
        ds = Mysql.GetDataSetWithQuery("exec GetExamCity");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlexamcity1.DataSource = ds;
            ddlexamcity1.DataTextField = "CityName";
            ddlexamcity1.DataValueField = "ID";
            ddlexamcity1.DataBind();
        }
        ddlexamcity1.Items.Insert(0, new ListItem("SELECT", "0"));
    }

    protected void BindDistrict()
    {
       
        DataSet dsdistrict = Mysql.GetDataSetWithQuery("exec GetDistrict");
        if (dsdistrict.Tables[0].Rows.Count > 0)
        {
            ddldistrict.DataSource = dsdistrict;
            ddldistrict.DataTextField = "DistrictName" ;
            ddldistrict.DataValueField = "districtID";
            ddldistrict.DataBind();
        }
        ddldistrict.Items.Insert(0, new ListItem("SELECT", "0"));
    }

    protected void BindZone()
    {
        
        DataSet dsZone = Mysql.GetDataSetWithQuery("exec GetZone");
        if (dsZone.Tables[0].Rows.Count > 0)
        {
            ddlzone.DataSource = dsZone;
            ddlzone.DataTextField = "ZoneName";
            ddlzone.DataValueField = "zoneid";
            ddlzone.DataBind();
        }
        ddlzone.Items.Insert(0, new ListItem("SELECT", "0"));
    }


    protected void ddlexamcity1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlexamcity2.Items.Clear();
        ddlexamcity3.Items.Clear();
        //ddldistrict.Items.Clear();
        //ddlzone.Items.Clear();
        ds = Mysql.GetDataSetWithQuery("exec GetExamCityOthers @ID1='" + ddlexamcity1.SelectedValue + "', @ID2=''");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlexamcity2.DataSource = ds;
            ddlexamcity2.DataTextField = "CityName";
            ddlexamcity2.DataValueField = "ID";
            ddlexamcity2.DataBind();
        }
        ddlexamcity2.Items.Insert(0, new ListItem("SELECT", "0"));
    }

    protected void ddlexamcity2_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlexamcity3.Items.Clear();
        //ddldistrict.Items.Clear();
        //ddlzone.Items.Clear();
        ds = Mysql.GetDataSetWithQuery("exec GetExamCityOthers @ID1='" + ddlexamcity1.SelectedValue + "', @ID2='" + ddlexamcity2.SelectedValue + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlexamcity3.DataSource = ds;
            ddlexamcity3.DataTextField = "CityName";
            ddlexamcity3.DataValueField = "ID";
            ddlexamcity3.DataBind();
        }
        ddlexamcity3.Items.Insert(0, new ListItem("SELECT", "0"));
     
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (ddlexamcity1.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Exam City 1');", true);
            ddlexamcity1.Focus();
            return;
        }

        if (ddlexamcity2.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Exam City 2');", true);
            ddlexamcity2.Focus();
            return;
        }

        if (ddlexamcity3.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Exam City 3');", true);
            ddlexamcity3.Focus();
            return;
        }

        if (ddldistrict.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select district');", true);
            ddldistrict.Focus();
            return;
        }

        if (ddlzone.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select zone');", true);
            ddlzone.Focus();
            return;
        }
        bool res = Mysql.ExecuteNonQuery("exec spUpdateStudentExamCity @RollNumber='" + CID + "', @ExamCity1='" + ddlexamcity1.SelectedValue + "', @ExamCity2='" + ddlexamcity2.SelectedValue + "', @ExamCity3='" + ddlexamcity3.SelectedValue + "', @district='" + ddldistrict.SelectedItem.Text + "',@division='" + ddlzone.SelectedItem.Text + "'");
        if (res)
        {
            Response.Redirect("WelcomePage.aspx");
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Something Went Wrong.');", true);
            //  ddlexamcity1.Focus();
            return;
        }
    }
    protected void CheckStudentStatus()
    {
        string strstdstatus = Mysql.SingleCellResultInString("getChoiceStatus @RollNumber='" + CID + "'");
        if (!string.IsNullOrEmpty(strstdstatus))
        {
            if (strstdstatus == "Yes")
            {
                Response.Redirect("WelcomePage.aspx");
            }
            else
            {

            }
        }
    }
    protected void GetCandidateName()
    {
        string strstdName = Mysql.SingleCellResultInString("GetCandidateDetails @RollNumber='" + CID + "'");
        if (!string.IsNullOrEmpty(strstdName))
        {
            lblcandidatename.Text = strstdName;
        }
    }
    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Mysql.UpdateSingleLogin(Session["Username"].ToString(), Convert.ToInt32(Session["UserType"].ToString()), 0);
        Session.Abandon();
        Session.Clear();
        Response.Redirect("../Login/LogOut.aspx");
    }
    
 
}