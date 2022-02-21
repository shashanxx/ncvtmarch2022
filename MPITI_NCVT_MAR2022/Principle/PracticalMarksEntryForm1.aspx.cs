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
            //try
            //{
            lblUName.Text = "Welcome " + Convert.ToString(Session["Username"]);
            DataTable dt = new DataTable();
            dt = MySql.GetDataTableWithQuery("select * from  tbl_User_Profile where Name='" + Session["Username"].ToString() + "'");
            mobileNo = Convert.ToString(dt.Rows[0]["MobileNo"]);
            zone = Convert.ToString(dt.Rows[0]["zone"]);
            Session["Zone"] = zone;
            HiddenField2.Value = Session["Username"].ToString();
            btnsave.Visible = false;
            btn_Otp.Visible = false;
            txt_otp.Visible = false;
            btnprint.Visible = false;
            BindDistrict();
            //}
            //catch (Exception ex)
            //{

            //}
        }
    }

    protected void BindDistrict()
    {
        //try
        //{
        string UserID = Convert.ToString(Session["UserID"]);
        DataTable dtDistrict = new DataTable();
        dtDistrict = MySql.GetDataTableWithQuery("sp_GetDistrictByUserID1 '" + UserID + "'");
        if (dtDistrict != null && dtDistrict.Rows.Count > 0)
        {
            ddldistrict.DataSource = dtDistrict;
            ddldistrict.DataTextField = "ExistsDistrict";
            ddldistrict.DataValueField = "LcaseDistrict";
            ddldistrict.DataBind();
        }
        ddldistrict.Items.Insert(0, new ListItem("Select District", "0"));
        //}
        //catch (Exception ex)
        //{

        //}
    }

    protected void BindNameOfITI(string District)
    {
        //try
        //{
        string UserID = Convert.ToString(Session["UserID"]);
        string Username = Convert.ToString(Session["Username"]);

        ddlNameofITI.Items.Clear();
        DataTable dtITICodeName = new DataTable();
        dtITICodeName = MySql.GetDataTableWithQuery("sp_GetITINameByUserNameAndDistrict1 '" + UserID + "', '" + District + "'");
        if (dtITICodeName != null && dtITICodeName.Rows.Count > 0)
        {
            ddlNameofITI.DataSource = dtITICodeName;
            ddlNameofITI.DataTextField = "ITIName";
            ddlNameofITI.DataValueField = "ITICode";
            ddlNameofITI.DataBind();
        }
        ddlNameofITI.Items.Insert(0, new ListItem("Select", "0"));
        //}
        //catch (Exception ex)
        //{

        //}
    }

    protected void BindTradeName()
    {
        //try
        //{
        DataTable dtTrade = new DataTable();
        dtTrade = MySql.GetDataTableWithQuery("exec GetAllTradeListJD  @District='" + ddldistrict.SelectedValue.ToString() + "',@ITICode='" + ddlNameofITI.SelectedValue.ToString() + "'");
        if (dtTrade != null && dtTrade.Rows.Count > 0)
        {
            ddlTradeName.DataSource = dtTrade;
            ddlTradeName.DataTextField = "TradeName";
            ddlTradeName.DataValueField = "Tradeid";
            ddlTradeName.DataBind();
        }
        ddlTradeName.Items.Insert(0, new ListItem("Select", "0"));
        if (ddlentrytype.SelectedValue == "ED")
        {
            ddlTradeName.Enabled = true;
        }
        else
        {
            ddlTradeName.Enabled = false;
        }
        //}
        //catch (Exception ex)
        //{

        //}
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //try
        //{
        lblCMessage.Text = "";
        if (isvalidate())
        {
            FillGrid();
        }
        //}
        //catch (Exception ex)
        //{

        //}
    }

    void FillGrid()
    {
        //try
        //{
        DataSet Ds = new DataSet();
        Ds = MySql.GetDataSetWithQuery("Exec BindGridinJD @AdmissionYear=" + ddlAdmissionYear.SelectedValue + ",@Semester=" + ddlSemester.SelectedValue + ", @ExamType='" + ddlexamtype.SelectedValue + "', @Trade=" + ddlTradeName.SelectedValue + ",@ITICode='" + ddlNameofITI.SelectedValue + "', @Division='" + Session["Zone"].ToString() + "', @District='" + ddldistrict.SelectedValue + "', @EntryType='" + ddlentrytype.SelectedValue + "'");
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
        //}
        //catch (Exception ex)
        //{

        //}
    }

    protected void checkAll_CheckedChanged(object sender, EventArgs e)
    {
        //try
        //{
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
        //}
        //catch (Exception ex)
        //{

        //}
    }

    protected void btnExit_Click(object sender, EventArgs e)
    {
        //try
        //{
        Session.Abandon();
        Response.Redirect("../Login/LoginNew.aspx");
        //}
        //catch (Exception ex)
        //{

        //}
    }

    protected void btn_Otp_Click(object sender, EventArgs e)
    {
        //try
        //{
        GenerateOTP();
        //}
        //catch (Exception ex)
        //{

        //}
    }

    protected void GenerateOTP()
    {
        //try
        //{
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
        //Response.Write(otp);
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
        //}
        //catch (Exception ex)
        //{

        //}
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //try
        //{
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
                        int TraineeId = Convert.ToInt32((row1.Cells[4].FindControl("lblTraineeID") as Label).Text);
                        string RollNo = row1.Cells[1].Text;
                        string practmarks = (row1.Cells[2].FindControl("txtpractmarks") as TextBox).Text;
                        string dictation100 = (row1.Cells[3].FindControl("ddl_dictation100") as DropDownList).SelectedValue;
                        tradetype1 = ddlentrytype.SelectedValue;
                        string ins = "exec SP_Insert_MarksDetailsJD  @TraineeId=" + TraineeId + ", @RollNo='" + RollNo + "' , @Marks='" + practmarks + "', @Dictation100='" + dictation100 + "' , @MarksType='" + tradetype1 + "', @LoginId='" + HiddenField2.Value + "'";
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
        //}
        //catch (Exception ex)
        //{

        //}
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
                    string x2 = (row.Cells[3].FindControl("ddl_dictation100") as DropDownList).SelectedValue;
                    if (x == "")
                    {
                        (row.Cells[2].FindControl("txtpractmarks") as TextBox).Focus();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Enter marks.');", true);
                        return false;
                    }
                    else if (x == "A" || x == "NA")
                    {
                        string practmarks = (row.Cells[2].FindControl("txtpractmarks") as TextBox).Text;
                    }
                    else
                    {
                        double practmarks = Convert.ToDouble((row.Cells[2].FindControl("txtpractmarks") as TextBox).Text);
                        if (practmarks > 0)
                        {
                            if (ddlentrytype.SelectedValue.ToString() == "ED" && (ddlTradeName.SelectedValue == "113" || ddlTradeName.SelectedValue == "112" || ddlTradeName.SelectedValue == "111" || ddlTradeName.SelectedValue == "110") && practmarks > 240 && Convert.ToInt32(ddlAdmissionYear.SelectedValue) >= 2018 && ddlSemester.SelectedValue == "2")
                            {
                                (row.Cells[2].FindControl("txtpractmarks") as TextBox).Focus();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('240 is maximum practical marks.');", true);
                                return false;
                            }
                            else if (ddlentrytype.SelectedValue.ToString() == "ED" && (ddlTradeName.SelectedValue == "113" || ddlTradeName.SelectedValue == "112" || ddlTradeName.SelectedValue == "111" || ddlTradeName.SelectedValue == "110") && practmarks > 240 && Convert.ToInt32(ddlAdmissionYear.SelectedValue) >= 2018 && ddlSemester.SelectedValue == "4")
                            {
                                (row.Cells[2].FindControl("txtpractmarks") as TextBox).Focus();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('60 is maximum practical marks.');", true);
                                return false;
                            }
                            else if (ddlentrytype.SelectedValue.ToString() == "ED" && (ddlTradeName.SelectedValue == "109") && practmarks > 150 && Convert.ToInt32(ddlAdmissionYear.SelectedValue) >= 2018)
                            {
                                (row.Cells[2].FindControl("txtpractmarks") as TextBox).Focus();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('150 is maximum practical marks.');", true);
                                return false;
                            }
                            else if (ddlentrytype.SelectedValue == "ED" && practmarks > 75 && (ddlTradeName.SelectedValue != "113" && ddlTradeName.SelectedValue != "112" && ddlTradeName.SelectedValue != "111" && ddlTradeName.SelectedValue != "110" && ddlTradeName.SelectedValue != "109"))
                            {
                                (row.Cells[2].FindControl("txtpractmarks") as TextBox).Focus();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('75 is maximum for ED marks.');", true);
                                return false;
                            }

                            if ((ddlentrytype.SelectedValue == "SH" || ddlentrytype.SelectedValue == "SE") && practmarks > 100 && Convert.ToInt32(ddlAdmissionYear.SelectedValue) < 2018)
                            {
                                (row.Cells[2].FindControl("txtpractmarks") as TextBox).Focus();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('100 is maximum for Steno practical marks.');", true);
                                return false;
                            }
                            if ((ddlentrytype.SelectedValue == "SP") && practmarks > 100 && Convert.ToInt32(ddlAdmissionYear.SelectedValue) < 2018)
                            {
                                (row.Cells[2].FindControl("txtpractmarks") as TextBox).Focus();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('100 is maximum for Secretarial Practice practical marks.');", true);
                                return false;
                            }


                            if ((ddlentrytype.SelectedValue == "SH" || ddlentrytype.SelectedValue == "SE") && practmarks > 250 && Convert.ToInt32(ddlAdmissionYear.SelectedValue) >= 2018)
                            {
                                (row.Cells[2].FindControl("txtpractmarks") as TextBox).Focus();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('250 is maximum for Steno practical marks.');", true);
                                return false;
                            }
                            if ((ddlentrytype.SelectedValue == "SP") && practmarks > 250 && Convert.ToInt32(ddlAdmissionYear.SelectedValue) >= 2018)
                            {
                                (row.Cells[2].FindControl("txtpractmarks") as TextBox).Focus();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('250 is maximum for Secretarial Practice practical marks.');", true);
                                return false;
                            }

                            if (ddlentrytype.SelectedValue.ToString() == "ED" && (ddlTradeName.SelectedValue != "29" && ddlTradeName.SelectedValue != "33" && ddlTradeName.SelectedValue != "34" && ddlTradeName.SelectedValue != "113" && ddlTradeName.SelectedValue != "112" && ddlTradeName.SelectedValue != "111" && ddlTradeName.SelectedValue != "110" && ddlTradeName.SelectedValue != "109") && practmarks > 50 && Convert.ToInt32(ddlAdmissionYear.SelectedValue) >= 2018)
                            {
                                (row.Cells[2].FindControl("txtpractmarks") as TextBox).Focus();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('50 is maximum practical marks.');", true);
                                return false;
                            }
                        }
                    }
                    if (x2 == "0" && ddlentrytype.SelectedValue.ToString() != "ED" && ddlSemester.SelectedValue == "2")
                    {
                        (row.Cells[3].FindControl("ddl_dictation100") as DropDownList).Focus();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Select Dictation 100 WPM.');", true);
                        return false;
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
        if (ddlTradeName.SelectedValue == "0" && ddlentrytype.SelectedValue == "ED")
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
        //try
        //{
        BindNameOfITI(ddldistrict.SelectedValue);
        //}
        //catch (Exception ex)
        //{

        //}
    }

    protected void ddlentrytype_SelectedIndexChanged(object sender, EventArgs e)
    {
        //try
        //{
        BindTradeName();
        if (ddlentrytype.SelectedValue == "ED")
            ddlSemester.Items.FindByValue("1").Enabled = false;
        else
            ddlSemester.Items.FindByValue("1").Enabled = true;
        //}
        //catch (Exception ex)
        //{

        //}
    }

    protected void ddlNameofITI_SelectedIndexChanged(object sender, EventArgs e)
    {
        //try
        //{
        BindTradeName();
        //}
        //catch (Exception ex)
        //{

        //}
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        //try
        //{
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (ddlentrytype.SelectedValue.ToString() == "ED")
            {
                e.Row.Cells[2].Text = "ED Marks(75)";
            }
            else if ((ddlentrytype.SelectedValue.ToString() == "SE" || ddlentrytype.SelectedValue.ToString() == "SH") && Convert.ToInt32(ddlAdmissionYear.SelectedValue) < 2018)
            {
                e.Row.Cells[2].Text = "Steno Practical Marks(out of 100)";
            }
            else if (ddlentrytype.SelectedValue.ToString() == "SP" && Convert.ToInt32(ddlAdmissionYear.SelectedValue) < 2018)
            {
                e.Row.Cells[2].Text = "Secretarial Practice Practical Marks(out of 100)";
            }
            else if ((ddlentrytype.SelectedValue.ToString() == "SE" || ddlentrytype.SelectedValue.ToString() == "SH") && Convert.ToInt32(ddlAdmissionYear.SelectedValue) >= 2018)
            {
                e.Row.Cells[2].Text = "Steno Practical Marks(out of 250)";
            }
            else if (ddlentrytype.SelectedValue.ToString() == "SP" && Convert.ToInt32(ddlAdmissionYear.SelectedValue) >= 2018)
            {
                e.Row.Cells[2].Text = "Secretarial Practice Practical Marks(out of 250)";
            }

            if (ddlentrytype.SelectedValue.ToString() == "ED" && (ddlTradeName.SelectedValue != "29" && ddlTradeName.SelectedValue != "33" && ddlTradeName.SelectedValue != "34") && Convert.ToInt32(ddlAdmissionYear.SelectedValue) >= 2018)
            {
                e.Row.Cells[2].Text = "ED Marks(50)";
            }


            if (ddlentrytype.SelectedValue.ToString() == "ED" && (ddlTradeName.SelectedValue == "113" || ddlTradeName.SelectedValue == "112" || ddlTradeName.SelectedValue == "111" || ddlTradeName.SelectedValue == "110") && Convert.ToInt32(ddlAdmissionYear.SelectedValue) >= 2018 && ddlSemester.SelectedValue == "2")
            {
                e.Row.Cells[2].Text = "ED Marks(240)";
            }
            if (ddlentrytype.SelectedValue.ToString() == "ED" && (ddlTradeName.SelectedValue == "113" || ddlTradeName.SelectedValue == "112" || ddlTradeName.SelectedValue == "111" || ddlTradeName.SelectedValue == "110") && Convert.ToInt32(ddlAdmissionYear.SelectedValue) >= 2018 && ddlSemester.SelectedValue == "4")
            {
                e.Row.Cells[2].Text = "ED Marks(60)";
            }

            if (ddlentrytype.SelectedValue.ToString() == "ED" && (ddlTradeName.SelectedValue == "109") && Convert.ToInt32(ddlAdmissionYear.SelectedValue) >= 2018)
            {
                e.Row.Cells[2].Text = "ED Marks(150)";
            }

        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txt = (e.Row.FindControl("txtpractmarks") as TextBox);
            if (ddlentrytype.SelectedValue.ToString() == "ED")
            {
                txt.MaxLength = 3;
            }
            else if (ddlentrytype.SelectedValue.ToString() == "SE" || ddlentrytype.SelectedValue.ToString() == "SH" || ddlentrytype.SelectedValue.ToString() == "SP")
            {
                txt.MaxLength = 5;
            }
        }
        //e.Row.Cells[2].Visible = false;
        if (ddlentrytype.SelectedValue.ToString() == "ED" || ddlSemester.SelectedValue != "2")
            e.Row.Cells[3].Visible = false;
        else
            e.Row.Cells[3].Visible = true;
        //}
        //catch (Exception ex)
        //{

        //}
    }

    protected void btnprint_Click(object sender, EventArgs e)
    {
        //try
        //{
        Session["AdmissionYear"] = ddlAdmissionYear.SelectedValue.ToString();
        Session["strSemID"] = ddlSemester.SelectedValue.ToString();
        Session["ExamType"] = ddlexamtype.SelectedValue.ToString();
        Session["EntryType"] = ddlentrytype.SelectedValue.ToString();
        Session["Trade"] = ddlTradeName.SelectedValue.ToString();
        Session["strITICode"] = ddlNameofITI.SelectedValue.ToString();
        Session["District"] = ddldistrict.SelectedValue.ToString();
        Session["ITIName"] = ddlNameofITI.SelectedItem.Text;
        Session["TradeName"] = ddlTradeName.SelectedItem.Text;

        //DataTable dt = new DataTable();
        //dt = MySql.GetDataTableWithQuery("select * from  TradeMaster where Tradeid='" + ddlTradeName.SelectedValue + "'");
        //Session["TradeDuration"] = Convert.ToString(dt.Rows[0]["duration"]);
        Session["TradeDuration"] = "";

        string url = "PdfJDReports_Blank.aspx";
        string s = "window.open('" + url + "', '_blank');";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", s, true);
        //}
        //catch (Exception ex)
        //{

        //}
    }

    protected void lnklogout_Click(object sender, EventArgs e)
    {
        //try
        //{
        Session.Abandon();
        Response.Redirect("../Login/LoginNew.aspx");
        //}
        //catch (Exception ex)
        //{

        //}
    }

    protected void lnkreport_Click(object sender, EventArgs e)
    {
        //try
        //{
        Response.Redirect("JoinDirectorAdminReports.aspx");
        //}
        //catch (Exception ex)
        //{

        //}
    }

    protected void lnkreportD_Click(object sender, EventArgs e)
    {
        //try
        //{
        Response.Redirect("JoindirectorDetaileedReport.aspx");
        //}
        //catch (Exception ex)
        //{

        //}
    }
    protected void ddlAdmissionYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        //try
        //{
        if (Convert.ToInt32(ddlAdmissionYear.SelectedValue) >= 2018)
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
        //}
        //catch (Exception ex)
        //{

        //}
    }
}
