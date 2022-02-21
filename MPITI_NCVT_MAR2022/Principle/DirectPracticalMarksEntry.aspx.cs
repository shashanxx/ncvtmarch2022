using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Class;
using System.Data;
using System.Net;
using System.Threading;
using System.Data.SqlClient;
using System.Text;

public partial class Principle_DirectPracticalMarksEntry : System.Web.UI.Page
{
    ClsErrorLog errlog = new ClsErrorLog();
    CommonPerception MySql = new CommonPerception();
    DataSet ds = new DataSet();
    string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
    string numbers = "1234567890";
    string otp = string.Empty;
    string mobileNo = "";
    public string userType = "";
    DataTable dt = new DataTable();



    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
        {
            Response.Redirect("../Login/LoginNew.aspx");
        }
        if (!IsPostBack)
        {

            lblUName.Text = "Welcome " + Convert.ToString(Session["Username"]);
            DataTable dt = new DataTable();
            dt = MySql.GetDataTableWithQuery("select * from  tbl_User_Profile where Name='" + Session["Username"].ToString() + "'");
            mobileNo = Convert.ToString(dt.Rows[0]["MobileNo"]);
            userType = Convert.ToString(dt.Rows[0]["userType"]);
            hfUserType.Value = Convert.ToString(dt.Rows[0]["userType"]);
            HiddenField2.Value = Session["userType"].ToString();
            //btnsave.Visible = false;
            //btn_Otp.Visible = false;
            //txt_otp.Visible = false;
            //btnprint.Visible = false;
            BindEntryType(userType);
        }
    }

    private void BindEntryType(string userType)
    {
        if (userType == "6")
        {
            ddlentrytype.Items.FindByValue("PR").Enabled = false;
            ddlTradeType.Visible = false;
            td_tradeType.Visible = false;
            tdMarks.Visible = true;
        }
        else
        {
            ddlTradeType.Visible = true;
            td_tradeType.Visible = true;
            ddlentrytype.Items.FindByValue("0").Enabled = false;
            ddlentrytype.Items.FindByValue("ED").Enabled = false;
            ddlentrytype.Items.FindByValue("SE").Enabled = false;
            ddlentrytype.Items.FindByValue("SH").Enabled = false;
            ddlentrytype.Items.FindByValue("SP").Enabled = false;
            ddlentrytype.Items.FindByValue("PR").Selected = true;
            tdDict100.Visible = false;
            tdMarks.Visible = true;
        }
    }

    protected void btn_Otp_Click(object sender, EventArgs e)
    {
        try
        {
            GenerateOTP();
        }
        catch (Exception ex)
        {
            errlog.LogError(ex);
        }
    }

    protected void GenerateOTP()
    {
        DataTable dtData = new DataTable();
        if (ViewState["table"] != null)
        {
            dtData = (DataTable)ViewState["table"];
            if (dtData.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('No Data Found.');", true);
                return;
            }
            string characters = numbers;
            int length = int.Parse("6");

            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }
            Session["Otp"] = otp;
            string Message = "OTP for MP ITI NCVT Marks Entry: '" + otp + "'";
            DataTable dt = new DataTable();
            dt = MySql.GetDataTableWithQuery("select * from  tbl_User_Profile where Name='" + Session["Username"].ToString() + "'");
            mobileNo = Convert.ToString(dt.Rows[0]["MobileNo"]);
            string gateway2use = "https://api.equence.in/pushsms?username=aptech_trans&password=-ZE56_nr&from=ATTEST&to=" + mobileNo + "&text=" + Message + "";
            System.Net.WebRequest request = System.Net.WebRequest.Create(gateway2use);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Thread.Sleep(500); response.Close();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('No Data Found.');", true);
            return;
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtData = new DataTable();
            if (ViewState["table"] != null)
            {
                dtData = (DataTable)ViewState["table"];
                if (dtData.Rows.Count == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('No Data Found.');", true);
                    return;
                }
                if (isAllDataEntered())
                {
                    dt = (DataTable)ViewState["table"];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //string ins = "exec SP_Insert_DirectMarksDetails  @ITICode=" + Convert.ToString(dt.Rows[i]["ITICode"]) + ", @RollNo=" + Convert.ToString(dt.Rows[i]["RollNumber"]) + " , @Marks='" + Convert.ToString(dt.Rows[i]["Marks"]) + "' , @MarksType='" + Convert.ToString(dt.Rows[i]["EntryType"]) + "', @LoginId='" + Session["Username"].ToString() + "', @Semester='" + Convert.ToString(dt.Rows[i]["Semester"]) + "',@TradeType='" + Convert.ToString(dt.Rows[i]["TradeType"]) + "'";
                        string ins = "exec SP_Insert_DirectMarksDetails  @ITICode=" + Convert.ToString(dt.Rows[i]["ITICode"]) + ", @RollNo=" + Convert.ToString(dt.Rows[i]["RollNumber"]) + " , @Marks='" + Convert.ToString(dt.Rows[i]["Marks"]) + "' , @MarksType='" + Convert.ToString(dt.Rows[i]["EntryType"]) + "', @name='" + Convert.ToString(dt.Rows[i]["Name"]) + "', @100Wpm='" + Convert.ToString(dt.Rows[i]["100Wpm"]) + "', @LoginId='" + Session["Username"].ToString() + "', @Semester='" + Convert.ToString(dt.Rows[i]["Semester"]) + "',@TradeType='" + Convert.ToString(dt.Rows[i]["TradeType"]) + "'";
                        MySql.ExecuteNonQuery(ins);
                    }
                    ClearForm();
                    grd_candidate.DataSource = null;
                    grd_candidate.DataBind();
                    btnsave.Visible = false;
                    btn_Otp.Visible = false;
                    txt_otp.Visible = false;
                    txt_otp.Text = "";
                    Session["Otp"] = null;
                    ViewState["table"] = null;
                    dt = null;
                    hd_isAdd.Value = "0";
                    lblCMessage.Text = "Records inserted successfully";
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('No Data Found.');", true);
                return;
            }
        }
        catch (Exception ex)
        {
            errlog.LogError(ex);
        }
    }

    protected void btnprint_Click(object sender, EventArgs e)
    {
        //Session["EntryType"] = ddlentrytype.SelectedValue.ToString();
        Session["EntryType"] = ddlentrytype.SelectedValue;
        string url = "PdfPracticalMarksReports_Blank.aspx";
        string s = "window.open('" + url + "', '_blank');";
        ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            lblCMessage.Text = "";
            if (isvalidate())
            {
                btn_Otp.Visible = true;
                txt_otp.Visible = true;
                btnsave.Visible = true;

                if (hd_isAdd.Value == "0")
                {
                    hd_isAdd.Value = "1";
                    dt.Columns.Add("ITICode", typeof(string));
                    dt.Columns.Add("RollNumber", typeof(string));
                    dt.Columns.Add("Semester", typeof(string));
                    dt.Columns.Add("Name", typeof(string));
                    dt.Columns.Add("100Wpm", typeof(string));
                    dt.Columns.Add("Marks", typeof(string));
                    dt.Columns.Add("EntryType", typeof(string));
                    dt.Columns.Add("TradeType", typeof(string));
                    dt.Columns.Add("Remove", typeof(string));

                    DataRow dr = dt.NewRow();

                    dr["ITICode"] = txt_ItiCode.Text;
                    dr["RollNumber"] = txt_rollno.Text;
                    dr["Semester"] = ddlSemester.SelectedValue;
                    dr["Name"] = txt_name.Text;
                    dr["100Wpm"] = ddl_dictation100.SelectedValue;
                    dr["Marks"] = txt_marks.Text;
                    dr["EntryType"] = ddlentrytype.SelectedValue;
                    dr["Remove"] = "Remove";
                    if (HiddenField2.Value == "2")
                    {
                        dr["TradeType"] = ddlTradeType.SelectedValue;
                    }
                    else
                    {
                        dr["TradeType"] = "-";
                    }
                    dt.Rows.Add(dr);
                    ViewState["table"] = dt;

                    grd_candidate.DataSource = dt;
                    grd_candidate.DataBind();
                    if (HiddenField2.Value == "2")
                    {
                        grd_candidate.Columns[4].Visible = false;
                        grd_candidate.Columns[7].Visible = true;
                    }
                    else
                    {
                        grd_candidate.Columns[4].Visible = true;
                        grd_candidate.Columns[7].Visible = false;
                    }

                    ClearForm();
                }
                else
                {
                    if (ViewState["table"] != null)
                    {
                        dt = (DataTable)ViewState["table"];
                        DataRow dr = dt.NewRow();

                        dr["ITICode"] = txt_ItiCode.Text;
                        dr["RollNumber"] = txt_rollno.Text;
                        dr["Semester"] = ddlSemester.SelectedValue;
                        dr["Name"] = txt_name.Text;
                        dr["100Wpm"] = ddl_dictation100.SelectedValue;
                        dr["Marks"] = txt_marks.Text;
                        dr["EntryType"] = ddlentrytype.SelectedValue;
                        dr["Remove"] = "Remove";
                        if (HiddenField2.Value == "2")
                            dr["TradeType"] = ddlTradeType.SelectedValue;
                        else
                            dr["TradeType"] = "-";

                        dt.Rows.Add(dr);
                        ViewState["table"] = dt;
                        grd_candidate.DataSource = dt;
                        grd_candidate.DataBind();
                        if (HiddenField2.Value == "2")
                        {
                            grd_candidate.Columns[4].Visible = false;
                            grd_candidate.Columns[7].Visible = true;
                        }
                        else
                        {
                            grd_candidate.Columns[4].Visible = true;
                            grd_candidate.Columns[7].Visible = false;
                        }

                        ClearForm();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            errlog.LogError(ex);
        }
    }

    bool isvalidate()
    {
        if (ddlentrytype.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Entry Type');", true);
            ddlentrytype.Focus();
            return false;
        }
        if (ddlTradeType.SelectedValue == "0" && HiddenField2.Value == "2")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Trade Type');", true);
            ddlTradeType.Focus();
            return false;
        }
        if (txt_ItiCode.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter MIS CODE');", true);
            txt_ItiCode.Focus();
            return false;
        }
        if (txt_ItiCode.Text.Length != 10)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Length of MIS CODE must be 10');", true);
            txt_ItiCode.Focus();
            return false;
        }
        if (txt_rollno.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter Roll Number');", true);
            txt_rollno.Focus();
            return false;
        }
        if (txt_rollno.Text.Length != 12)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Length of Roll Number must be 12');", true);
            txt_rollno.Focus();
            return false;
        }
        //if (txt_name.Text == "")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter Candidate Name');", true);
        //    txt_name.Focus();
        //    return false;
        //}
        if (ddlSemester.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Semester');", true);
            ddlSemester.Focus();
            return false;
        }
        if (tdDict100.Visible)
        {
            if (ddl_dictation100.SelectedValue == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Dictation 100WPM');", true);
                ddl_dictation100.Focus();
                return false;
            }
        }

        if (tdMarks.Visible)
        {
            if (txt_marks.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter Marks');", true);
                txt_marks.Focus();
                return false;
            }

            if (txt_marks.Text.ToUpper() != "NA")
            {
                double practmarks = Convert.ToDouble(txt_marks.Text);
                if (ddlentrytype.SelectedValue == "PR" && ddlTradeType.SelectedValue == "Engg" && practmarks > 270)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('270 is maximum for Engineering Trades.');", true);
                    txt_marks.Focus();
                    return false;
                }
                if (ddlentrytype.SelectedValue == "PR" && ddlTradeType.SelectedValue == "Non-Engg" && practmarks > 100)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('100 is maximum for Non- Engineering Trades.');", true);
                    txt_marks.Focus();
                    return false;
                }
                else if (ddlentrytype.SelectedValue == "ED" && practmarks > 75)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('75 is maximum for Engineering Drawing.');", true);
                    txt_marks.Focus();
                    return false;
                }
                else if ((ddlentrytype.SelectedValue == "SH" || ddlentrytype.SelectedValue == "SE" || ddlentrytype.SelectedValue == "SP") && practmarks > 100)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('100 is maximum.');", true);
                    txt_marks.Focus();
                    return false;
                }
            }
        }

        //Approved and Private 
        int ExistsCount = MySql.SingleCellResult("select Count(*) from tbl_Student S Where RollNumber = '" + txt_rollno.Text.Trim() + "' and Semester = '" + ddlSemester.SelectedValue
                + "' and ApprovalStatus in ('Approved') and ttitype in ('private ','PVT')");

        if (ExistsCount > 0)
        {

        }
        else
        {
            if (ddlentrytype.SelectedValue == "ED")
            {
                DataTable dtStudData = new DataTable();
                dtStudData = MySql.GetDataTableWithQuery("select ApprovalStatus from tbl_Student S Where RollNumber = '" + txt_rollno.Text.Trim() + "' and Semester = '" + ddlSemester.SelectedValue
                    + "' and ApprovalStatus in ('Verified','Verified Manual','Approved') and Paper3 = 1");
                if (dtStudData.Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Student Status are Verified/Verified Manual/Approved');", true);
                    return false;
                }
            }
            else
            {
                DataTable dtEDData = new DataTable();
                dtEDData = MySql.GetDataTableWithQuery("select ApprovalStatus from tbl_Student S Where RollNumber = '" + txt_rollno.Text.Trim() + "' and Semester = '" + ddlSemester.SelectedValue
                    + "' and  ApprovalStatus in ('Verified','Verified Manual','Approved') and practical = 1");
                if (dtEDData.Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Student Status are Verified/Verified Manual/Approved.');", true);
                    return false;
                }
            }
        }

        DataTable dtrecord = new DataTable();
        dtrecord = MySql.GetDataTableWithQuery("select * from tbl_PracMarks P where P.RollNumber='" + txt_rollno.Text.Trim() + "' and P.Semester='" + ddlSemester.SelectedValue + "' and EntryType='" + ddlentrytype.Text + "' and IsActive=1");

        if (dtrecord.Rows.Count > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Entered combination of Roll Number, Semester & Entry Type is already exists in the database.');", true);
            txt_rollno.Focus();
            return false;
        }

        if (hd_isAdd.Value == "1")
        {
            if (ViewState["table"] != null)
            {
                dt = (DataTable)ViewState["table"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["RollNumber"].ToString() == txt_rollno.Text && dt.Rows[i]["Semester"].ToString() == ddlSemester.SelectedValue && dt.Rows[i]["EntryType"].ToString() == ddlentrytype.SelectedValue)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Entered combination of Roll Number, Semester & Entry Type is already entered.');", true);
                        txt_rollno.Focus();
                        return false;
                    }
                }
            }
        }
        return true;
    }

    private void ClearForm()
    {
        txt_ItiCode.Text = "";
        txt_rollno.Text = "";
        txt_name.Text = "";
        txt_marks.Text = "";
        ddl_dictation100.SelectedValue = "0";
        ddlSemester.SelectedValue = "0";
    }

    bool isAllDataEntered()
    {
        if (txt_otp.Text.Trim() == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please generate & enter OTP');", true);
            txt_otp.Focus();
            return false;
        }
        if (txt_otp.Text.Trim() != Convert.ToString(Session["Otp"]))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Invalid OTP. Please Enter correct OTP');", true);
            txt_otp.Focus();
            return false;
        }
        return true;
    }

    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("../Login/LoginNew.aspx");
    }

    protected void ddlentrytype_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSemester.Items.FindByValue("1").Enabled = true;
        if (hfUserType.Value == "6")
            tdDict100.Visible = true;

        if (ddlentrytype.SelectedValue == "ED")
        {
            ddlSemester.Items.FindByValue("1").Enabled = false;
            tdDict100.Visible = false;
        }

    }
    protected void grd_candidate_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow gvr1 = (GridViewRow)btn.NamingContainer;
        int index = gvr1.RowIndex;
        string value = grd_candidate.Rows[index].Cells[1].Text;
        if (ViewState["table"] != null)
        {
            dt = (DataTable)ViewState["table"];
            dt.Rows.RemoveAt(index);
            ViewState["table"] = dt;
            grd_candidate.DataSource = dt;
            grd_candidate.DataBind();
        }
    }
}