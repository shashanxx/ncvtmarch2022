using Common.Class;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public partial class Principle_AddRollnumber : System.Web.UI.Page
{
    CommonPerception Mysql = new CommonPerception();
    DataTable dtgrid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
            Response.Redirect("../Login/LoginNew.aspx");
        else
            lblUName.Text = "Welcome " + Session["Username"].ToString();

        CheckLoginTime();

        if (!IsPostBack)
        {
            bindyear();  

        }

    }
    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Mysql.UpdateSingleLogin(Session["Username"].ToString(), Convert.ToInt32(Session["UserType"].ToString()), 0);
        Session.Abandon();
        Session.Clear();
        Response.Redirect("../Login/LogOut.aspx");
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Dashboard.aspx");
    }
    private void bindyear()
    {
        ddlAdmissionYear.Items.Add(new ListItem("Select", "0"));
        for (int i = DateTime.Now.Year - 2; i < DateTime.Now.Year; i++)
        {
            ddlAdmissionYear.Items.Add(i.ToString());
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void ddlAdmissionYear_change(object sender, EventArgs e)
    {
        BindTradeList();
        DataTable dtTrade = new DataTable();
        //dtTrade = Mysql.GetDataTableWithQuery("select distinct Semester from tbl_Student_withoutrollno where ITICode='" + Session["Username"].ToString() + "' and AdmissionYear='" + ddlAdmissionYear.SelectedValue.ToString() + "'");
        //if (dtTrade != null && dtTrade.Rows.Count > 0)
        //{
        //    ddlSemester.DataSource = dtTrade;
        //    ddlSemester.DataTextField = "Semester";
        //    ddlSemester.DataValueField = "Semester";
        //    ddlSemester.DataBind();
        //}
        //ddlSemester.Items.Insert(0, new ListItem("Select", "0"));

    }
    private void BindTradeList()
    {
        DataTable dtTrade = new DataTable();
        dtTrade = Mysql.GetDataTableWithQuery("select distinct Trade from tbl_Student_withoutrollno where ITICode='" + Session["Username"].ToString() + "' and AdmissionYear='"+ ddlAdmissionYear.SelectedValue.ToString() + "'");
        if (dtTrade != null && dtTrade.Rows.Count > 0)
        {
            ddlTradeName.DataSource = dtTrade;
            ddlTradeName.DataTextField = "Trade";
            ddlTradeName.DataValueField = "Trade";
            ddlTradeName.DataBind();
        }
        ddlTradeName.Items.Insert(0, new ListItem("Select", "0"));
    }


    void BindData()
    {
        int status = 1;
        string errormsgstring = "";
        if (ddlAdmissionYear.SelectedValue == "0")
        {
            status = 0;
            errormsgstring += "Please select admission year<br/>";
        }

        if (ddlSemester.SelectedValue == "0")
        {
            status = 0;
            errormsgstring += "Please select Semester<br/>";
        }
        if (ddlTradeName.SelectedValue == "0")
        {
            status = 0;
            errormsgstring += "Please select Trade<br/>";
        }
        if (ddlexamtype.SelectedValue == "0")
        {
            status = 0;
            errormsgstring += "Please select Exam Type<br/>";
        }
        if (status == 1)
        {
            DataSet ds = new DataSet();
            ds = Mysql.GetDataSet("select id,Rollnumber,Name,FatherName,CONVERT(char(10),DOB,126) as DOB,admissionyear,Semester,Trade,ITICode,ITIname from tbl_Student_withoutrollno where admissionyear='" + ddlAdmissionYear.SelectedValue.ToString() + "' And Semester='" + ddlSemester.SelectedValue.ToString() + "' and Trade='" + ddlTradeName.SelectedValue.ToString() + "' and Examtype='"+ddlexamtype.SelectedValue.ToString()+ "' and ITICode='"+ Session["Username"].ToString() + "' and rollnumber is null"); 
            gv.DataSource = ds;
            gv.DataBind();
        }
        else
        {
            errormsg.Text = errormsgstring;
        }        
    }


    protected void Editdata(object s, GridViewEditEventArgs e)
    {
        gv.EditIndex = e.NewEditIndex;
        BindData();
    }
    protected void Canceldata(object s, GridViewCancelEditEventArgs e)
    {
        gv.EditIndex = -1;
        BindData();
    }
    protected void Updatedata(object s, GridViewUpdateEventArgs e)
    {
        int i = e.RowIndex;
        string RollNumber = (gv.Rows[e.RowIndex].FindControl("lblStartingRollNo2") as Label).Text + (gv.Rows[e.RowIndex].FindControl("txRollNumber") as TextBox).Text;   
        string sem= (gv.Rows[e.RowIndex].FindControl("lblSemester") as Label).Text;
        string id = (gv.Rows[e.RowIndex].FindControl("Hiddenid") as HiddenField).Value;
        gv.EditIndex = -1;
        int rollPrefix = (gv.Rows[e.RowIndex].FindControl("txRollNumber") as TextBox).Text.IndexOf("19082");
        bool rollPrefix1 = (gv.Rows[e.RowIndex].FindControl("txRollNumber") as TextBox).Text.StartsWith("19082");
        string RollNumberText = (gv.Rows[e.RowIndex].FindControl("txRollNumber") as TextBox).Text;
        BindData();
        DataSet ds = new DataSet();
        if (string.IsNullOrEmpty(RollNumber.Trim()))
        {
            errormsg.Text = "Please enter Rollnumber";
        }
        if (string.IsNullOrEmpty(RollNumberText.Trim()))
        {
            errormsg.Text = "Please enter Rollnumber";
        }
        else if (RollNumber.Length > 15)
        {
            errormsg.Text = "Please enter valid Rollnumber";
        }
        else if (rollPrefix == 0 && rollPrefix1)
        {
            errormsg.Text = "Please enter valid Rollnumber without 19082 as starting roll number";
        }
        else
        {
            ds = Mysql.GetDataSet("select * from tbl_student where rollnumber='" + RollNumber + "' and Semester='" + sem + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                errormsg.Text = "RollNumber already exists with same semester/Year";
            }
            else
            {
                errormsg.Text = "";
                bool res = Mysql.ExecuteNonQuery("update tbl_Student_withoutrollno set rollnumber='" + RollNumber + "' where id='" + id + "'");
                if (res)
                {
                    bool res1 = Mysql.ExecuteNonQuery("insert into tbl_Student(isActivatedNewIti,RollNumber,Name,FatherName,MotherName,DOB,Gender,category,Eligibility,ChoiceLocked,AdmissionYear,Trade,TTIType,ITIName,ITICode,Semester,Examtype,IsEdited,ApprovalStatus,ExistsZone,ExistsDistrict,ExamPattern) select '1' as isActivatedNewIti,RollNumber,Name,FatherName,MotherName,DOB,Gender,category,Eligibility,ChoiceLocked,AdmissionYear,Trade,TTIType,ITIName,ITICode,Semester,Examtype,IsEdited,ApprovalStatus,ExistsZone,ExistsDistrict,ExamPattern from tbl_Student_withoutrollno where id='" + id + "'");
                    if (res1)
                    {
                        DataSet ds1 = new DataSet();
                        ds1 = Mysql.GetDataSet("select * from tbl_user where username='" + RollNumber + "'");
                        if (ds1.Tables[0].Rows.Count == 0)
                        {
                            bool res2 = Mysql.ExecuteNonQuery("insert into tbl_user(UserName,Password,UserType,UserTypeId,IsActive,ChangePasswordAttempt)select top 1 RollNumber as username,REPLACE(CONVERT(CHAR(10),DOB,103), '/', '') as Password,'1' as UserType,rollnumber as UserTypeId,'0' as IsActive,'0' as ChangePasswordAttempt from tbl_student where rollnumber='" + RollNumber + "' and Semester='" + sem + "'");
                        }
                    }
                }
            }
        }
        
        BindData();
    }
    protected void pageddata(object s, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        BindData();
    }
}