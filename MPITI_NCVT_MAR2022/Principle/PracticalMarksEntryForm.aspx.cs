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


public partial class Center_Joindirector : System.Web.UI.Page
{
    ClsErrorLog errlog = new ClsErrorLog();
    CommonPerception MySql = new CommonPerception();
    DataSet ds = new DataSet();
    string tradetype1 = "";
    string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
    string numbers = "1234567890";
    string otp = string.Empty;
    string mobileNo = "";
    string zone = "";

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
            //zone = Convert.ToString(dt.Rows[0]["zone"]);
            //Session["Zone"] = zone;
            HiddenField2.Value = Session["Username"].ToString();
            btnsave.Visible = false;
            btn_Otp.Visible = false;
            txt_otp.Visible = false;
            btnprint.Visible = false;

            BindDistrict();
        }
    }

    protected void BindDistrict()
    {
        string UserID = Convert.ToString(Session["UserID"]);
        DataTable dtDistrict = new DataTable();
        dtDistrict = MySql.GetDataTableWithQuery("sp_GetDistrictByUserID '" + UserID + "'");
        if (dtDistrict != null && dtDistrict.Rows.Count > 0)
        {
            ddldistrict.DataSource = dtDistrict;
            ddldistrict.DataTextField = "ExistsDistrict";
            ddldistrict.DataValueField = "LcaseDistrict";
            ddldistrict.DataBind();
        }
        ddldistrict.Items.Insert(0, new ListItem("Select District", "0"));
    }

    protected void BindNameOfITI(string District)
    {
        string UserID = Convert.ToString(Session["UserID"]);
        string Username = Convert.ToString(Session["Username"]);

        ddlNameofITI.Items.Clear();
        DataTable dtITICodeName = new DataTable();
        dtITICodeName = MySql.GetDataTableWithQuery("sp_GetITINameByUserNameAndDistrict '" + UserID + "', '" + District + "'");
        if (dtITICodeName != null && dtITICodeName.Rows.Count > 0)
        {
            ddlNameofITI.DataSource = dtITICodeName;
            ddlNameofITI.DataTextField = "ITIName";
            ddlNameofITI.DataValueField = "ITICode";
            ddlNameofITI.DataBind();
        }
        ddlNameofITI.Items.Insert(0, new ListItem("Select", "0"));
    }

    protected void BindTradeName()
    {
        string UserID = Convert.ToString(Session["UserID"]);
        string Username = Convert.ToString(Session["Username"]);
        DataTable dtTrade = new DataTable();
        ddlTradeName.Items.Clear();
        dtTrade = MySql.GetDataTableWithQuery("sp_GetTradeNameByUserName '" + UserID + "','" + ddldistrict.SelectedValue + "' ,'" + ddlNameofITI.SelectedValue + "'");
        if (dtTrade != null && dtTrade.Rows.Count > 0)
        {
            ddlTradeName.DataSource = dtTrade;
            ddlTradeName.DataTextField = "TradeName";
            ddlTradeName.DataValueField = "Tradeid";
            ddlTradeName.DataBind();
        }
        ddlTradeName.Items.Insert(0, new ListItem("Select", "0"));
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            lblCMessage.Text = "";
            if (isvalidate())
            {
                FillGrid();
            }
        }
        catch (Exception ex)
        {
            errlog.LogError(ex);
        }
    }

    void FillGrid()
    {
        DataSet Ds = new DataSet();
        Ds = MySql.GetDataSetWithQuery("Exec BindGridinNodal @AdmissionYear=" + ddlAdmissionYear.SelectedValue + ",@Semester=" + ddlSemester.SelectedValue + ", @ExamType='" + ddlexamtype.SelectedValue + "', @Trade=" + ddlTradeName.SelectedValue + ",@ITICode='" + ddlNameofITI.SelectedValue + "', @District='" + ddldistrict.SelectedValue + "'");
        if (Ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = Ds;
            GridView1.DataBind();

            btnsave.Visible = true;
            btnprint.Visible = true;
            btn_Otp.Visible = true;
            txt_otp.Visible = true;
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            btnsave.Visible = false;
            btn_Otp.Visible = false;
            txt_otp.Visible = false;
            lblCMessage.Text = "No data found";
            btnprint.Visible = false;
        }
    }

    protected void checkAll_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox ChkBoxHeader = (CheckBox)GridView1.HeaderRow.FindControl("checkAll");
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox ChkBoxRows = (CheckBox)row.FindControl("checkCan");
                if (ChkBoxHeader.Checked == true)
                {
                    ChkBoxRows.Checked = true;
                }
                else
                {
                    ChkBoxRows.Checked = false;
                }
            }
        }
        catch (Exception ex)
        {
            errlog.LogError(ex);
        }



    }

    protected void btnExit_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Abandon();
            Response.Redirect("../Login/LoginNew.aspx");
        }
        catch (Exception ex)
        {
            errlog.LogError(ex);
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
        string Message = "OTP for MP ITI NCVT Entry: '" + otp + "'";
        DataTable dt = new DataTable();
        dt = MySql.GetDataTableWithQuery("select * from  tbl_User_Profile where Name='" + Session["Username"].ToString() + "'");
        mobileNo = Convert.ToString(dt.Rows[0]["MobileNo"]);
        string gateway2use = "https://api.equence.in/pushsms?username=aptech_trans&password=-ZE56_nr&from=MYEXMN&to=" + mobileNo + "&tmplId=1107161518675589233&text=" + Message + "";
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
        System.Net.WebRequest request = System.Net.WebRequest.Create(gateway2use);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Thread.Sleep(500); response.Close();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (isAllDataEntered())
            {
                //----Insert Marks
                int CheckedCount = 0;
                foreach (GridViewRow row1 in GridView1.Rows)
                {
                    if (row1.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row1.Cells[0].FindControl("checkCan") as CheckBox);
                        if (chkRow.Checked)
                        {
                            CheckedCount = CheckedCount + 1;
                            int TraineeId = Convert.ToInt32((row1.Cells[3].FindControl("lblTraineeID") as Label).Text);
                            string RollNo = row1.Cells[1].Text;
                            string practmarks = (row1.Cells[2].FindControl("txtpractmarks") as TextBox).Text;
                            tradetype1 = ddlentrytype.SelectedValue;
                            string ins = "exec SP_Insert_MarksDetailsJD  @TraineeId='" + TraineeId + "', @RollNo='" + RollNo + "' , @Marks='" + practmarks + "' , @MarksType='" + tradetype1 + "', @LoginId='" + HiddenField2.Value + "'";
                            MySql.ExecuteNonQuery(ins);

                        }
                    }
                }
                if (CheckedCount > 0)
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    btnsave.Visible = false;
                    btn_Otp.Visible = false;
                    txt_otp.Visible = false;
                    txt_otp.Text = "";
                    Session["Otp"] = null;
                    lblCMessage.Text = "Records inserted successfully";
                }
                else
                {
                    lblCMessage.Text = "Please select at least one record for update";
                }
            }
        }
        catch (Exception ex)
        {
            errlog.LogError(ex);
        }
    }

    bool isAllDataEntered()
    {
        int countCheck = 0;
        //----Check all values entered of checked row
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("checkCan") as CheckBox);
                if (chkRow.Checked)
                {
                    countCheck++;
                    string RollNo = row.Cells[1].Text;

                    string x = (row.Cells[2].FindControl("txtpractmarks") as TextBox).Text;
                    if (x == "")
                    {
                        (row.Cells[2].FindControl("txtpractmarks") as TextBox).Focus();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Enter marks.');", true);
                        return false;
                    }
                    else if (x == "A")
                    {
                        string practmarks = (row.Cells[2].FindControl("txtpractmarks") as TextBox).Text;
                    }
                    else
                    {
                        double practmarks = Convert.ToDouble((row.Cells[2].FindControl("txtpractmarks") as TextBox).Text);
                        if (practmarks > 0)
                        {
                            string tradeTypeId = "";
                            DataTable dt = new DataTable();
                            dt = MySql.GetDataTableWithQuery("select * from TradeMaster where Tradeid='" + ddlTradeName.SelectedValue + "'");
                            tradeTypeId = Convert.ToString(dt.Rows[0]["TradetypeID"]);
                            if (tradeTypeId == "1" && practmarks > 100 && Convert.ToInt32(ddlAdmissionYear.SelectedValue) < 2018)
                            {
                                (row.Cells[2].FindControl("txtpractmarks") as TextBox).Focus();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('100 is maximum for Non- Engineering Trades.');", true);
                                return false;
                            }else if(tradeTypeId == "1" && practmarks > 250 && Convert.ToInt32(ddlAdmissionYear.SelectedValue) >= 2018)
                            {
                                (row.Cells[2].FindControl("txtpractmarks") as TextBox).Focus();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('250 is maximum for Non- Engineering Trades.');", true);
                                return false;
                            }
                            
                            if ((tradeTypeId == "2" || tradeTypeId == "3") && practmarks > 270)
                            {
                                (row.Cells[2].FindControl("txtpractmarks") as TextBox).Focus();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('270 is maximum for Engineering Trades.');", true);
                                return false;
                            }

                            if (practmarks > 250 && Convert.ToInt32(ddlAdmissionYear.SelectedValue) >= 2018)
                            {
                                (row.Cells[2].FindControl("txtpractmarks") as TextBox).Focus();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('250 is maximum for Practical marks.');", true);
                                return false;
                            }

                            if (ddlTradeName.SelectedValue == "109" && practmarks > 140)
                            {
                                (row.Cells[2].FindControl("txtpractmarks") as TextBox).Focus();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('140 is maximum for Practical marks.');", true);
                                return false;
                            }


                            if ((ddlTradeName.SelectedValue=="113" || ddlTradeName.SelectedValue=="112" || ddlTradeName.SelectedValue=="111" || ddlTradeName.SelectedValue == "110") && ddlSemester.SelectedValue=="2" && practmarks>150){
                                (row.Cells[2].FindControl("txtpractmarks") as TextBox).Focus();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('150 is maximum for Practical marks.');", true);
                                return false;
                            }

                            if ((ddlTradeName.SelectedValue == "113" || ddlTradeName.SelectedValue == "112" || ddlTradeName.SelectedValue == "111" || ddlTradeName.SelectedValue == "110") && ddlSemester.SelectedValue == "4" && practmarks > 90)
                            {
                                (row.Cells[2].FindControl("txtpractmarks") as TextBox).Focus();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('90 is maximum for Practical marks.');", true);
                                return false;
                            }
                        }
                    }
                }
            }
        }
        if (countCheck == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select at least one record for update.');", true);
            return false;
        }
        if (txt_otp.Text.Trim() == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Enter OTP');", true);
            txt_otp.Focus();
            return false;
        }
        if (txt_otp.Text.Trim() != Session["Otp"].ToString())
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Invalid OTP. Please Enter correct OTP');", true);
            txt_otp.Focus();
            return false;
        }
        return true;
    }

    //-----Search Validation
    bool isvalidate()
    {
        if (ddldistrict.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select District');", true);
            ddldistrict.Focus();
            return false;
        }
        if (ddlentrytype.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Entry Type');", true);
            ddlentrytype.Focus();
            return false;
        }
        if (ddlNameofITI.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Name Of ITI');", true);
            ddlNameofITI.Focus();
            return false;
        }
        if (ddlSemester.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Semester');", true);
            ddlSemester.Focus();
            return false;
        }
        if (ddlTradeName.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Trade Name');", true);
            ddlTradeName.Focus();
            return false;
        }
        if (ddlAdmissionYear.SelectedValue == "YEAR")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Admission Year');", true);
            ddlAdmissionYear.Focus();
            return false;
        }
        if (ddlexamtype.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Exam Type');", true);
            ddlexamtype.Focus();
            return false;
        }
        return true;
    }

    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindNameOfITI(ddldistrict.SelectedValue);
    }

    protected void ddlNameofITI_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTradeName();
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            string tradeTypeId = "";
            DataTable dt = new DataTable();
            dt = MySql.GetDataTableWithQuery("select * from TradeMaster where Tradeid='" + ddlTradeName.SelectedValue + "'");
            tradeTypeId = Convert.ToString(dt.Rows[0]["TradetypeID"]);
            if (tradeTypeId == "1" && Convert.ToInt32(ddlAdmissionYear.SelectedValue) < 2018)
            {
                e.Row.Cells[2].Text = "Non- Engineering Trades Marks(out of 100)";
            }
            else if (tradeTypeId == "1" && Convert.ToInt32(ddlAdmissionYear.SelectedValue) >= 2018)
            {
                e.Row.Cells[2].Text = "Non- Engineering Trades Marks(out of 250)";
            }
            else if((tradeTypeId == "2" || tradeTypeId == "3" ) && Convert.ToInt32(ddlAdmissionYear.SelectedValue) < 2018)
            {
                e.Row.Cells[2].Text = "Engineering Trades Marks(out of 270)";
            }
            else if ((tradeTypeId == "2" || tradeTypeId == "3") && Convert.ToInt32(ddlAdmissionYear.SelectedValue) >= 2018)
            {
                e.Row.Cells[2].Text = "Engineering Trades Marks(out of 250)";
            }


            if (ddlTradeName.SelectedValue == "109" )
            {
                e.Row.Cells[2].Text = "Engineering Trades Marks(out of 140)";
            }


            if ((ddlTradeName.SelectedValue == "113" || ddlTradeName.SelectedValue == "112" || ddlTradeName.SelectedValue == "111" || ddlTradeName.SelectedValue == "110") && ddlSemester.SelectedValue == "2" )
            {
                e.Row.Cells[2].Text = "Engineering Trades Marks(out of 150)";
            }

            if ((ddlTradeName.SelectedValue == "113" || ddlTradeName.SelectedValue == "112" || ddlTradeName.SelectedValue == "111" || ddlTradeName.SelectedValue == "110") && ddlSemester.SelectedValue == "4")
            {
                e.Row.Cells[2].Text = "Engineering Trades Marks(out of 90)";
            }

        }
        //else if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    TextBox txt = (e.Row.FindControl("txtpractmarks") as TextBox);
        //    if (ddlentrytype.SelectedValue.ToString() == "ED")
        //    {               
        //        txt.MaxLength = 2;
        //    }
        //    else if (ddlentrytype.SelectedValue.ToString() == "SE" || ddlentrytype.SelectedValue.ToString() == "SH")
        //    {
        //        txt.MaxLength = 3;
        //    }
        //}
    }

    protected void btnprint_Click(object sender, EventArgs e)
    {

        Session["AdmissionYear"] = ddlAdmissionYear.SelectedValue.ToString(); ;
        Session["strSemID"] = ddlSemester.SelectedValue.ToString();
        Session["ExamType"] = ddlexamtype.SelectedValue.ToString();
        //Session["EntryType"] = ddlentrytype.SelectedValue.ToString();
        Session["Trade"] = ddlTradeName.SelectedValue.ToString();
        Session["strITICode"] = ddlNameofITI.SelectedValue.ToString();
        Session["District"] = ddldistrict.SelectedValue.ToString();
        Session["ITIName"] = ddlNameofITI.SelectedItem.Text;
        Session["TradeName"] = ddlTradeName.SelectedItem.Text;

        DataTable dt = new DataTable();
        dt = MySql.GetDataTableWithQuery("select * from  TradeMaster where Tradeid='" + ddlTradeName.SelectedValue + "'");
        Session["TradeDuration"] = Convert.ToString(dt.Rows[0]["duration"]);

        string url = "PdfNodalReports_Blank.aspx";
        string s = "window.open('" + url + "', 'popup_window', 'width=900,height=800,left=100,top=100,resizable=no');";
        ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
    }

    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("../Login/LoginNew.aspx");
    }

    protected void lnkreport_Click(object sender, EventArgs e)
    {
        Response.Redirect("NodalAdminReports.aspx");
    }

    protected void lnkreportD_Click(object sender, EventArgs e)
    {
        Response.Redirect("NodalDetaileedReport.aspx");
    }
    protected void ddlAdmissionYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ddlAdmissionYear.SelectedValue)>= 2018)
        {
            lblSemester.Text = "Year";
            ddlSemester.Items.Clear();
            ddlSemester.Items.Add(new ListItem("Select", "0"));
            ddlSemester.Items.Add(new ListItem("1st Year", "2"));
            ddlSemester.Items.Add(new ListItem("2nd Year", "4"));
        }
        else
        {
            lblSemester.Text = "Semester";
            ddlSemester.Items.Clear();
            ddlSemester.Items.Add(new ListItem("Select", "0"));
            ddlSemester.Items.Add(new ListItem("Sem1", "1"));
            ddlSemester.Items.Add(new ListItem("Sem2", "2"));
            ddlSemester.Items.Add(new ListItem("Sem3", "3"));
            ddlSemester.Items.Add(new ListItem("Sem4", "4"));

        }
    }
}