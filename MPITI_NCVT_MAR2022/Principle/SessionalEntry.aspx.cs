using Common.Class;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Principle_DownloadAdmitCard : System.Web.UI.Page
{
    CommonPerception Mysql = new CommonPerception();
    DataTable dtgrid;
    ClsErrorLog errlog = new ClsErrorLog();
    string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
    string numbers = "1234567890";
    string otp = string.Empty;
    string mobileNo = "";
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
            BindTradeList();
            HiddenField2.Value = Session["Username"].ToString();
            btnsave.Visible = false;
            btn_Otp.Visible = false;
            txt_otp.Visible = false;
            btnprint.Visible = false;
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
    private void bindyear()
    {
        ddlAdmissionYear.Items.Add(new ListItem("Select", "0"));
        for (int i = DateTime.Now.Year - 4; i < DateTime.Now.Year; i++)
        {
            ddlAdmissionYear.Items.Add(i.ToString());
        }
    }
    private void BindTradeList()
    {
        DataTable dtTrade = new DataTable();
        dtTrade = Mysql.GetDataTableWithQuery("exec GetSessionalTradeList @ITICode='" + Session["Username"].ToString() + "'");
        if (dtTrade != null && dtTrade.Rows.Count > 0)
        {
            ddlTradeName.DataSource = dtTrade;
            ddlTradeName.DataTextField = "TradeName";
            ddlTradeName.DataValueField = "Tradeid";
            ddlTradeName.DataBind();
        }
        ddlTradeName.Items.Insert(0, new ListItem("Select", "0"));
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (isvalidate())
        {
            if (int.Parse(ddlAdmissionYear.SelectedValue) <= 2017)
            {
                tr_gridview1.Visible = true;
                tr_gridview2.Visible = false;
                FillGrid();
                
            }
            else
            {
                //tr_gridview2.Visible = true;
                //tr_gridview1.Visible = false;

                tr_gridview1.Visible = true;
                tr_gridview2.Visible = false;

                //FillGridYear();
                FillGrid();
            }
        }
    }


    bool isvalidate()
    {
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
        if (ddlAdmissionYear.SelectedValue == "0")
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

    void FillGrid()
    {
        DataSet Ds = new DataSet();
        Ds = Mysql.GetDataSetWithQuery("Exec BindGridinSessional @AdmissionYear=" + ddlAdmissionYear.SelectedValue + ",@Semester=" + ddlSemester.SelectedValue + ", @ExamType='" + ddlexamtype.SelectedValue + "', @Trade=" + ddlTradeName.SelectedValue + ",@ITICode='" + Session["Username"].ToString() + "'");
        if (Ds.Tables[0].Rows.Count > 0)
        {

            GridView1.DataSource = Ds;
            GridView1.DataBind();
            btnsave.Visible = true;
            btnprint.Visible = true;
            lblCMessage.Text = "";
            //btn_Otp.Visible = true;
            //txt_otp.Visible = true;
        }

        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            btnsave.Visible = false;
            //btn_Otp.Visible = false;
            //txt_otp.Visible = false;
            lblCMessage.Text = "No data found";
            btnprint.Visible = false;
        }
    }


    void FillGridYear()
    {
        DataSet Ds = new DataSet();
        Ds = Mysql.GetDataSetWithQuery("Exec BindGridinSessional @AdmissionYear=" + ddlAdmissionYear.SelectedValue + ",@Semester=" + ddlSemester.SelectedValue + ", @ExamType='" + ddlexamtype.SelectedValue + "', @Trade=" + ddlTradeName.SelectedValue + ",@ITICode='" + Session["Username"].ToString() + "'");
        if (Ds.Tables[0].Rows.Count > 0)
        {

            GridView2.DataSource = Ds;
            GridView2.DataBind();
            btnsave.Visible = true;
            btnprint.Visible = true;
            lblCMessage.Text = "";
            //btn_Otp.Visible = true;
            //txt_otp.Visible = true;
        }

        else
        {
            GridView2.DataSource = null;
            GridView2.DataBind();
            btnsave.Visible = false;
            //btn_Otp.Visible = false;
            //txt_otp.Visible = false;
            lblCMessage.Text = "No data found";
            btnprint.Visible = false;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            //if (int.Parse(ddlAdmissionYear.SelectedValue) == 2017)
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
                                int TraineeId = Convert.ToInt32((row1.Cells[3].FindControl("lblTraineeID") as Label).Text);
                                string RollNo = row1.Cells[1].Text;
                                string x1 = (row1.Cells[2].FindControl("txtTradeTheorySessional") as TextBox).Text;
                                string x2 = (row1.Cells[3].FindControl("txtWorkshopCalcSessional") as TextBox).Text;
                                string x3 = (row1.Cells[4].FindControl("txtEDSessional") as TextBox).Text;
                                string x4 = (row1.Cells[5].FindControl("txtTradePracticalSessional") as TextBox).Text;
                                string x5 = "";
                                string x6 = "";
                                string x7 = "";
                                if (ddlTradeName.SelectedValue == "109")
                                {
                                    x5 = (row1.Cells[6].FindControl("txtTradePracticalII") as TextBox).Text;
                                    x6 = (row1.Cells[7].FindControl("txtProjectWork") as TextBox).Text;
                                    x7 = (row1.Cells[8].FindControl("txtTradePracticalIISessional") as TextBox).Text;
                                }                               

                                //tradetype1 = ddlentrytype.SelectedValue;
                                //string ins = "exec SP_Insert_MarksDetailsSessional  @TraineeId=" + TraineeId + ", @RollNo='" + RollNo + "' , @TradeTheory='" + txtTradeTheory + "', @EmployabilitySkills='" + txtEmployabilitySkills + "', @WorkshopCalc='" + txtWorkshopCalc + "', @ED='" + txtED + "', @TradePractical='" + txtTradePractical + "', @LoginId='" + HiddenField2.Value + "'";
                                string ins = "exec SP_Insert_MarksDetailsSessional  @TraineeId=" + TraineeId + ",@RollNo='" + RollNo + "',@TradeTheorySessional='" + x1 + "',@WorkshopCalcSessional='" + x2 + "',@EDSessional='" + x3 + "',@TradePracticalSessional='" + x4 + "',@TradePracticalII='" + x5 + "',@ProjectWork='" + x6 + "',@TradePracticalIISessional='" + x7 + "',@LoginId='" + HiddenField2.Value + "'";
                                Mysql.ExecuteNonQuery(ins);

                            }
                        }
                    }
                    if (CheckedCount > 0)
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        btnsave.Visible = false;
                        //btn_Otp.Visible = false;
                        //txt_otp.Visible = false;
                        //txt_otp.Text = "";
                        //Session["Otp"] = null;
                        lblCMessage.Text = "Records inserted successfully";
                    }
                    else
                    {
                        lblCMessage.Text = "Please select at least one record for update";
                    }
                }
            //}
            //else
            //{
            //    if (isAllDataEnteredYear())
            //    {
            //        //----Insert Marks
            //        int CheckedCount = 0;
            //        foreach (GridViewRow row1 in GridView2.Rows)
            //        {
            //            if (row1.RowType == DataControlRowType.DataRow)
            //            {
            //                CheckBox chkRow = (row1.Cells[0].FindControl("checkCan") as CheckBox);
            //                if (chkRow.Checked)
            //                {
            //                    CheckedCount = CheckedCount + 1;
            //                    int TraineeId = Convert.ToInt32((row1.Cells[3].FindControl("lblTraineeID") as Label).Text);
            //                    string RollNo = row1.Cells[1].Text;
            //                    //string txtTradeTheory = (row1.Cells[2].FindControl("txtTradeTheory") as TextBox).Text;
            //                    //string txtEmployabilitySkills = (row1.Cells[3].FindControl("txtEmployabilitySkills") as TextBox).Text;
            //                    //string txtWorkshopCalc = (row1.Cells[4].FindControl("txtWorkshopCalc") as TextBox).Text;
            //                    //string txtED = (row1.Cells[5].FindControl("txtED") as TextBox).Text;
            //                    string txtSessionalMarks = (row1.Cells[2].FindControl("txtSessionalMarks") as TextBox).Text;
            //                    string txtAttendance = (row1.Cells[3].FindControl("txtAttendance") as TextBox).Text;
            //                    //tradetype1 = ddlentrytype.SelectedValue;
            //                    //string ins = "exec SP_Insert_MarksDetailsSessional  @TraineeId=" + TraineeId + ", @RollNo='" + RollNo + "' , @TradeTheory='" + txtTradeTheory + "', @EmployabilitySkills='" + txtEmployabilitySkills + "', @WorkshopCalc='" + txtWorkshopCalc + "', @ED='" + txtED + "', @TradePractical='" + txtTradePractical + "', @LoginId='" + HiddenField2.Value + "'";
            //                    string ins = "exec SP_Insert_MarksDetailsSessionalYear  @TraineeId=" + TraineeId + ", @RollNo='" + RollNo + "' , @Sessionalmarks='" + txtSessionalMarks + "',@Attendance='" + txtAttendance + "' , @LoginId='" + HiddenField2.Value + "'";
            //                    Mysql.ExecuteNonQuery(ins);

            //                }
            //            }
            //        }
            //        if (CheckedCount > 0)
            //        {
            //            GridView2.DataSource = null;
            //            GridView2.DataBind();
            //            btnsave.Visible = false;
            //            //btn_Otp.Visible = false;
            //            //txt_otp.Visible = false;
            //            //txt_otp.Text = "";
            //            //Session["Otp"] = null;
            //            lblCMessage.Text = "Records inserted successfully";
            //        }
            //        else
            //        {
            //            lblCMessage.Text = "Please select at least one record for update";
            //        }
            //    }
            //}
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

                    string x1 = (row.Cells[2].FindControl("txtTradeTheorySessional") as TextBox).Text;
                    string x2 = (row.Cells[3].FindControl("txtWorkshopCalcSessional") as TextBox).Text;
                    string x3 = (row.Cells[4].FindControl("txtEDSessional") as TextBox).Text;
                    string x4 = (row.Cells[5].FindControl("txtTradePracticalSessional") as TextBox).Text;
                    string x5 = "";
                    string x6 = "";
                    string x7 = "";
                    if (ddlTradeName.SelectedValue == "109")
                    {
                        x5 = (row.Cells[6].FindControl("txtTradePracticalII") as TextBox).Text;
                        x6 = (row.Cells[7].FindControl("txtProjectWork") as TextBox).Text;
                        x7 = (row.Cells[8].FindControl("txtTradePracticalIISessional") as TextBox).Text;
                    }
                    
                    
                    DataTable Maxdt = new DataTable();
                    Maxdt = Mysql.GetDataTableWithQuery("GetSessionalMaxMark @admissionYear=" + ddlAdmissionYear.SelectedValue + ",@semester=" + ddlSemester.SelectedValue + ", @tradeId=" + ddlTradeName.SelectedValue + "");
        
                    if (x1 == "")
                    {
                        (row.Cells[2].FindControl("txtTradeTheorySessional") as TextBox).Focus();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Enter Trade Theory sessional marks.');", true);
                        return false;
                    }
                    else if (x1 != "" && x1.ToLower() != "a")
                    {
                        try
                        {
                            double practmarks = Convert.ToDouble((row.Cells[2].FindControl("txtTradeTheorySessional") as TextBox).Text);
                            if (!string.IsNullOrEmpty(Maxdt.Rows[0]["TradeTheorySessional"].ToString()))
                            {
                                double practmaxmark = Convert.ToDouble(Maxdt.Rows[0]["TradeTheorySessional"]);
                                if (practmarks > practmaxmark)
                                {
                                    (row.Cells[2].FindControl("txtTradeTheorySessional") as TextBox).Focus();
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('" + practmaxmark + " is maximum for Trade Theory Sessional.');", true);
                                    return false;
                                }
                            }
                        }
                        catch(Exception e)
                        {
                            (row.Cells[2].FindControl("txtTradeTheorySessional") as TextBox).Focus();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Enter valid Trade Theory sessional marks.');", true);
                            return false;
                        }
                        
                    }

                    if (x2 == "")
                    {
                        (row.Cells[3].FindControl("txtWorkshopCalcSessional") as TextBox).Focus();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Enter Workshop Calc and Science Sessional marks.');", true);
                        return false;
                    }
                    else if (x2 != "" && x2.ToLower() != "a")
                    {
                        try
                        {
                            double practmarks = Convert.ToDouble((row.Cells[3].FindControl("txtWorkshopCalcSessional") as TextBox).Text);
                            if (!string.IsNullOrEmpty(Maxdt.Rows[0]["WorkshopCalcSessional"].ToString()))
                            {
                                double practmaxmark = Convert.ToDouble(Maxdt.Rows[0]["WorkshopCalcSessional"]);
                                if (practmarks > practmaxmark)
                                {
                                    (row.Cells[3].FindControl("txtWorkshopCalcSessional") as TextBox).Focus();
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('" + practmaxmark + " is maximum for Workshop Calc and Science Sessional.');", true);
                                    return false;
                                }
                            }                            
                        }
                        catch (Exception e)
                        {
                            (row.Cells[3].FindControl("txtWorkshopCalcSessional") as TextBox).Focus();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Enter valid Workshop Calc and Science Sessional mark.');", true);
                            return false;
                        }

                    }


                    if (x3 == "")
                    {
                        (row.Cells[4].FindControl("txtEDSessional") as TextBox).Focus();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Enter Engineering Drawing Sessional marks.');", true);
                        return false;
                    }
                    else if (x3 != "" && x3.ToLower() != "a")
                    {
                        try
                        {
                            double practmarks = Convert.ToDouble((row.Cells[4].FindControl("txtEDSessional") as TextBox).Text);
                            if (!string.IsNullOrEmpty(Maxdt.Rows[0]["EDSessional"].ToString()))
                            {
                                double practmaxmark = Convert.ToDouble(Maxdt.Rows[0]["EDSessional"]);
                                if (practmarks > practmaxmark)
                                {
                                    (row.Cells[4].FindControl("txtEDSessional") as TextBox).Focus();
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('" + practmaxmark + " is maximum for Engineering Drawing Sessional.');", true);
                                    return false;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            (row.Cells[4].FindControl("txtEDSessional") as TextBox).Focus();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Enter valid Engineering Drawing Sessional mark.');", true);
                            return false;
                        }

                    }


                    if (x4 == "")
                    {
                        (row.Cells[5].FindControl("txtTradePracticalSessional") as TextBox).Focus();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Enter Trade Practical Sessional marks.');", true);
                        return false;
                    }
                    else if (x4 != "" && x4.ToLower() != "a")
                    {
                        try
                        {
                            double practmarks = Convert.ToDouble((row.Cells[5].FindControl("txtTradePracticalSessional") as TextBox).Text);
                            if (!string.IsNullOrEmpty(Maxdt.Rows[0]["TradePracticalSessional"].ToString()))
                            {
                                double practmaxmark = Convert.ToDouble(Maxdt.Rows[0]["TradePracticalSessional"]);
                                if (practmarks > practmaxmark)
                                {
                                    (row.Cells[5].FindControl("txtTradePracticalSessional") as TextBox).Focus();
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('" + practmaxmark + " is maximum for Trade Practical Sessional.');", true);
                                    return false;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            (row.Cells[5].FindControl("txtTradePracticalSessional") as TextBox).Focus();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Enter valid Trade Practical Sessional mark.');", true);
                            return false;
                        }

                    }

                    if (ddlTradeName.SelectedValue == "109")
                    {
                        if (x5 == "")
                        {
                            (row.Cells[6].FindControl("txtTradePracticalII") as TextBox).Focus();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Enter Trade Practical II marks.');", true);
                            return false;
                        }
                        else if (x5 != "" && x5.ToLower() != "a")
                        {
                            try
                            {
                                double practmarks = Convert.ToDouble((row.Cells[6].FindControl("txtTradePracticalII") as TextBox).Text);
                                if (!string.IsNullOrEmpty(Maxdt.Rows[0]["TradePracticalII"].ToString()))
                                {
                                    double practmaxmark = Convert.ToDouble(Maxdt.Rows[0]["TradePracticalII"]);
                                    if (practmarks > practmaxmark)
                                    {
                                        (row.Cells[6].FindControl("txtTradePracticalII") as TextBox).Focus();
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('" + practmaxmark + " is maximum for Trade Practical II.');", true);
                                        return false;
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                (row.Cells[6].FindControl("txtTradePracticalII") as TextBox).Focus();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Enter valid Trade Practical II mark.');", true);
                                return false;
                            }

                        }

                        if (x6 == "")
                        {
                            (row.Cells[7].FindControl("txtProjectWork") as TextBox).Focus();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Enter Project Work marks.');", true);
                            return false;
                        }
                        else if (x6 != "" && x6.ToLower() != "a")
                        {
                            try
                            {
                                double practmarks = Convert.ToDouble((row.Cells[7].FindControl("txtProjectWork") as TextBox).Text);
                                if (!string.IsNullOrEmpty(Maxdt.Rows[0]["ProjectWork"].ToString()))
                                {
                                    double practmaxmark = Convert.ToDouble(Maxdt.Rows[0]["ProjectWork"]);
                                    if (practmarks > practmaxmark)
                                    {
                                        (row.Cells[7].FindControl("txtProjectWork") as TextBox).Focus();
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('" + practmaxmark + " is maximum for Project Work.');", true);
                                        return false;
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                (row.Cells[7].FindControl("txtProjectWork") as TextBox).Focus();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Enter valid Project Work mark.');", true);
                                return false;
                            }

                        }


                        if (x7 == "")
                        {
                            (row.Cells[7].FindControl("txtTradePracticalIISessional") as TextBox).Focus();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Enter Trade Practical II Sessional marks.');", true);
                            return false;
                        }
                        else if (x7 != "" && x7.ToLower() != "a")
                        {
                            try
                            {
                                double practmarks = Convert.ToDouble((row.Cells[8].FindControl("txtTradePracticalIISessional") as TextBox).Text);
                                if (!string.IsNullOrEmpty(Maxdt.Rows[0]["TradePracticalIISessional"].ToString()))
                                {
                                    double practmaxmark = Convert.ToDouble(Maxdt.Rows[0]["TradePracticalIISessional"]);
                                    if (practmarks > practmaxmark)
                                    {
                                        (row.Cells[8].FindControl("txtTradePracticalIISessional") as TextBox).Focus();
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('" + practmaxmark + " is maximum for Trade Practical II Sessional.');", true);
                                        return false;
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                (row.Cells[8].FindControl("txtTradePracticalIISessional") as TextBox).Focus();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Enter valid Trade Practical II Sessional Mark.');", true);
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
        return true;
    }


    bool isAllDataEnteredYear()
    {
        int countCheck = 0;
        //----Check all values entered of checked row
        foreach (GridViewRow row in GridView2.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("checkCan") as CheckBox);
                if (chkRow.Checked)
                {
                    countCheck++;
                    string RollNo = row.Cells[1].Text;


                    string x1 = (row.Cells[2].FindControl("txtSessionalMarks") as TextBox).Text;
                    string x5 = (row.Cells[3].FindControl("txtAttendance") as TextBox).Text;
                    string tradeTypeId = "";

                    DataTable dt = new DataTable();
                    dt = Mysql.GetDataTableWithQuery("select * from TradeMaster where Tradeid='" + ddlTradeName.SelectedValue + "'");
                    tradeTypeId = Convert.ToString(dt.Rows[0]["TradetypeID"]);

                    if (x1 == "" && !(tradeTypeId == "1" || tradeTypeId == "2" || tradeTypeId == "3"))
                    {
                        (row.Cells[2].FindControl("txtSessionalMarks") as TextBox).Focus();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Enter  Sessional marks.');", true);
                        return false;
                    }
                    else if (x1 != "" && x1 != "A" && !(tradeTypeId == "1" || tradeTypeId == "2" || tradeTypeId == "3"))
                    {
                        double practmarks = Convert.ToDouble((row.Cells[2].FindControl("txtSessionalMarks") as TextBox).Text);
                        if (practmarks > 200)
                        {
                            (row.Cells[2].FindControl("txtSessionalMarks") as TextBox).Focus();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('200 is maximum for Trade Theory Sessional.');", true);
                            return false;
                        }
                    }
                    if (x5 == "")
                    {
                        (row.Cells[3].FindControl("txtAttendance") as TextBox).Focus();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Enter Attendance.');", true);
                        return false;
                    }
                    else
                    {
                        string practmarks = (row.Cells[3].FindControl("txtAttendance") as TextBox).Text;
                        double Num;
                        bool isNum = double.TryParse(practmarks, out Num);
                        if (!isNum)
                        {
                            (row.Cells[3].FindControl("txtAttendance") as TextBox).Focus();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Enter valid percentage of Attendance.');", true);
                            return false;
                        }

                        string mark = (row.Cells[2].FindControl("txtSessionalMarks") as TextBox).Text;
                        if (mark == "A" && Convert.ToDouble(practmarks) > 0)
                        {
                            (row.Cells[3].FindControl("txtAttendance") as TextBox).Focus();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Enter valid percentage of Attendance.');", true);
                            return false;
                        }

                        string[] val = practmarks.Split('.');
                        if (val.Length > 1)
                        {
                            if (val[1].Length > 2)
                            {
                                (row.Cells[3].FindControl("txtAttendance") as TextBox).Focus();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Upto 2 decimal');", true);
                                return false;
                            }
                        }
                        if (float.Parse(x5) > 100)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Attendance should be less then 100');", true);
                            return false;
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
        return true;
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

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        


        DataTable dt = new DataTable();
        dt = Mysql.GetDataTableWithQuery("GetSessionalMaxMark @admissionYear=" + ddlAdmissionYear.SelectedValue + ",@semester=" + ddlSemester.SelectedValue + ", @tradeId=" + ddlTradeName.SelectedValue + "");
        if (e.Row.RowType == DataControlRowType.Header)
        {
            string ttsmax = "";
            if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["TradeTheorySessional"])))
            {
                ttsmax = "(Max Marks-" + Convert.ToString(dt.Rows[0]["TradeTheorySessional"]) + ")";
            }
            e.Row.Cells[2].Text = "Trade Theory sessional " + ttsmax;

            string WorkshopCalcSessional = "";
            if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["WorkshopCalcSessional"])))
            {
                WorkshopCalcSessional = "(Max Marks-" + Convert.ToString(dt.Rows[0]["WorkshopCalcSessional"]) + ")";
            }
            e.Row.Cells[3].Text = "Workshop Calc and Science Sessional " + WorkshopCalcSessional;

            string EDSessional = "";
            if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["EDSessional"])))
            {
                EDSessional = "(Max Marks-" + Convert.ToString(dt.Rows[0]["EDSessional"]) + ")";
            }
            e.Row.Cells[4].Text = "Engineering Drawing Sessional "+EDSessional;

            string TradePracticalSessional = "";
            if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["TradePracticalSessional"])))
            {
                TradePracticalSessional = "(Max Marks-" + Convert.ToString(dt.Rows[0]["TradePracticalSessional"]) + ")";
            }
            e.Row.Cells[5].Text = "Trade Practical Sessional " + TradePracticalSessional;

            string TradePracticalII = "";
            if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["TradePracticalII"])))
            {
                TradePracticalII = "(Max Marks-" + Convert.ToString(dt.Rows[0]["TradePracticalII"]) + ")";
            }
            e.Row.Cells[6].Text = "Trade Practical II " + TradePracticalII;

            string ProjectWork = "";
            if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ProjectWork"])))
            {
                ProjectWork = "(Max Marks-" + Convert.ToString(dt.Rows[0]["ProjectWork"]) + "";
            }
            e.Row.Cells[7].Text = "Project Work " + ProjectWork;

            string TradePracticalIISessional = "";
            if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["TradePracticalIISessional"])))
            {
                TradePracticalIISessional = "(Max Marks-" + Convert.ToString(dt.Rows[0]["TradePracticalIISessional"]) + "";
            }
            e.Row.Cells[8].Text = "Trade Practical II Sessional " + TradePracticalIISessional;
        }

        if (ddlTradeName.SelectedValue == "110" || ddlTradeName.SelectedValue == "111" || ddlTradeName.SelectedValue == "112" || ddlTradeName.SelectedValue == "113")
        {
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
        }

    }



    protected void btnprint_Click(object sender, EventArgs e)
    {

        Session["AdmissionYear"] = ddlAdmissionYear.SelectedValue.ToString(); ;
        Session["strSemID"] = ddlSemester.SelectedValue.ToString();
        Session["ExamType"] = ddlexamtype.SelectedValue.ToString();
        Session["Trade"] = ddlTradeName.SelectedValue.ToString();
        Session["TradeName"] = ddlTradeName.SelectedItem.Text;
        Session["strITICode"] = Session["Username"].ToString();

        DataTable dt = new DataTable();
        dt = Mysql.GetDataTableWithQuery("select * from  TradeMaster where Tradeid='" + ddlTradeName.SelectedValue + "'");
        Session["TradeDuration"] = Convert.ToString(dt.Rows[0]["duration"]);
        string tradeTypeId = Convert.ToString(dt.Rows[0]["TradetypeID"]);
        string tradeType = "";
        if (tradeTypeId == "1" || tradeTypeId == "2" || tradeTypeId == "3")
            tradeType = "Non-Eng";
        else if (ddlTradeName.SelectedItem.Text == "SURVEYOR" || ddlTradeName.SelectedItem.Text == "DRAUGHTSMAN (CIVIL)" || ddlTradeName.SelectedItem.Text == "DRAUGHTSMAN (MECHANICAL)")
            tradeType = "Eng-3";
        else
            tradeType = "Eng";

        Session["tradeType"] = tradeType;

        string url = "PdfSessionalReports_Blank.aspx";
        string s = "window.open('" + url + "', '_blank');";
        ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
    }

    protected void lnkreportD_Click(object sender, EventArgs e)
    {
        Response.Redirect("SessionalEntryDetailedReport.aspx");
    }
    protected void ddlAdmissionYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (int.Parse(ddlAdmissionYear.SelectedValue) >2017)
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

         if (int.Parse(ddlAdmissionYear.SelectedValue) <2017)
         {
             ddlexamtype.Items.Clear();
             ddlexamtype.Items.Add(new ListItem("Select", "0"));

             ddlexamtype.Items.Add(new ListItem("Ex", "Ex"));
         }
         else
         {
             ddlexamtype.Items.Clear();
             ddlexamtype.Items.Add(new ListItem("Select", "0"));
             ddlexamtype.Items.Add(new ListItem("Reg", "Reg"));
             ddlexamtype.Items.Add(new ListItem("Ex", "Ex"));
         }
    }
}