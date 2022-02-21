using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Class;
using System.Data;
using System.Data.SqlClient;

public partial class Center_ExamCenter : ClsErrorLog
{
    CommonPerception MySql = new CommonPerception();
    DataSet dsgetData = new DataSet();
    string ITICode = "";
    string classification = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["centerlogin"] == null  || Session["OTPValid"] == "No")
        {
            Response.Redirect("Login.aspx");
        }
        
            if (!IsPostBack)
            {
                if (Session["OTPValid"].ToString() == "Yes")
                {
                    if (Session["CenterITICode"] == null)
                    {
                        Response.Redirect("Login.aspx");
                    }
                    HiddenFieldLoginId.Value = Session["CenterITICode"].ToString();
                    BindSessionName();
                    BindSemesterMaster();

                    BindPaperMaster();
                    BindDuration();
                    BindSlot();
                }
            }
    }

    protected void BindSessionName()
    {
        ddlSession.Items.Clear();
        DataSet Ds = new DataSet();
        Ds = MySql.GetDataSetWithQuery("Exec sp_getSessionMaster");
        if (Ds.Tables[0].Rows.Count > 0)
        {
            ddlSession.DataSource = Ds;
            ddlSession.DataTextField = "Session";
            ddlSession.DataValueField = "ID";
            ddlSession.DataBind();
            ddlSession.Items.Insert(0, new ListItem("Select Session Name", "0"));
        }
    }

    protected void BindNameOfITI(int SessionID)
    {
        ddlNameofITI.Items.Clear();
        DataSet Ds = new DataSet();
        Ds = MySql.GetDataSetWithQuery("Exec sp_getITIMaster " + SessionID + ",'" + Convert.ToString(Session["CenterITICode"]) + "'");
        if (Ds.Tables[0].Rows.Count > 0)
        {
            ddlNameofITI.DataSource = Ds;
            ddlNameofITI.DataTextField = "ITIName";
            ddlNameofITI.DataValueField = "ITICode";
            ddlNameofITI.DataBind();
            ddlNameofITI.Items.Insert(0, new ListItem("Select ITI Name", "0"));
        }
    }

    protected void BindSemesterMaster()
    {
        ddlSemester.Items.Clear();
        DataSet Ds = new DataSet();
        Ds = MySql.GetDataSetWithQuery("Exec sp_getSemestermaster");
        if (Ds.Tables[0].Rows.Count > 0)
        {
            ddlSemester.DataSource = Ds;
            ddlSemester.DataTextField = "Semester";
            ddlSemester.DataValueField = "ID";
            ddlSemester.DataBind();
            ddlSemester.Items.Insert(0, new ListItem("Select Semester", "0"));
        }
    }

    protected void BindTradeName(string ITICode)
    {
        ddlTradeName.Items.Clear();
        DataSet Ds = new DataSet();
        Ds = MySql.GetDataSetWithQuery("Exec sp_getTradeName @ITICode='" + ddlNameofITI.SelectedValue.ToString() + "'");
        if (Ds.Tables[0].Rows.Count > 0)
        {
            ddlTradeName.DataSource = Ds;
            ddlTradeName.DataTextField = "TradeName";
            ddlTradeName.DataValueField = "TradeCode";
            ddlTradeName.DataBind();
            ddlTradeName.Items.Insert(0, new ListItem("Select Trade Name", "0"));
        }
    }

    protected void BindPaperMaster()
    {
        ddlPaper.Items.Clear();
        DataSet Ds = new DataSet();
        Ds = MySql.GetDataSetWithQuery("Exec sp_getPaperMaster");
        if (Ds.Tables[0].Rows.Count > 0)
        {
            ddlPaper.DataSource = Ds;
            ddlPaper.DataTextField = "Paper";
            ddlPaper.DataValueField = "ID";
            ddlPaper.DataBind();
            ddlPaper.Items.Insert(0, new ListItem("Select Paper", "0"));
        }
    }

    protected void BindDuration()
    {
        ddlDuration.Items.Clear();
        DataSet Ds = new DataSet();
        Ds = MySql.GetDataSetWithQuery("Exec sp_getDurationmaster");
        if (Ds.Tables[0].Rows.Count > 0)
        {
            ddlDuration.DataSource = Ds;
            ddlDuration.DataTextField = "Duration";
            ddlDuration.DataValueField = "ID";
            ddlDuration.DataBind();
            ddlDuration.Items.Insert(0, new ListItem("Select Duration", "0"));
        }
    }

    protected void BindSlot()
    {
        ddlSlot.Items.Clear();
        DataSet Ds = new DataSet();
        Ds = MySql.GetDataSetWithQuery("Exec sp_getSlotmaster");
        if (Ds.Tables[0].Rows.Count > 0)
        {
            ddlSlot.DataSource = Ds;
            ddlSlot.DataTextField = "Slot";
            ddlSlot.DataValueField = "ID";
            ddlSlot.DataBind();
            ddlSlot.Items.Insert(0, new ListItem("Select Slot", "0"));
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (isvalidate())
            {
                dsgetData = MySql.GetDataSetWithQuery("Exec Sp_BindGridinCenter " + Convert.ToInt32(ddlSession.SelectedValue) + ",'" + Convert.ToString(ddlNameofITI.SelectedValue) + "'," + Convert.ToInt32(ddlSemester.SelectedValue) + ",'" + Convert.ToString(ddlTradeName.SelectedValue) + "'," + Convert.ToInt32(ddlPaper.SelectedValue) + ",'" + Convert.ToString(ddlEntryType.SelectedValue) + "'");
                if (dsgetData.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = dsgetData;
                    GridView1.DataBind();
                    lblCMessage.Text = "<b>Total No. of Records -</b>" + dsgetData.Tables[0].Rows.Count;
                    btnSave.Visible = true;
                    btnPrint.Visible = true;
                    btnPrint.Enabled = true;

                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    lblCMessage.Text = "<b>Records Not Found</b>";
                    btnSave.Visible = false;
                    btnPrint.Enabled = false;
                }

            }
        }
        catch (Exception ex)
        {
            LogError(ex);
        }
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        TextBox PracMarks = (e.Row.FindControl("txtPracticalMarks") as TextBox);
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (ddlEntryType.SelectedValue.ToString() == "O")
            {
                e.Row.Cells[8].Text = "Enter OMR Answer Sheet No";
                e.Row.Cells[7].Text = "Present/Absent";
                e.Row.Cells[7].Visible = true;
                //e.Row.Cells[3].Visible = true;
                //e.Row.Cells[6].Visible = true;
                //e.Row.Cells[9].Visible = true;
                //e.Row.Cells[10].Visible = true;
            }
            else
            {
                //practical marks
                e.Row.Cells[6].Text = "";
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[7].Text = "Present/Absent";
                classification = MySql.SingleCellResultInString("select Classification from Tradecodemaster where TradeCode='" + ddlTradeName.SelectedValue.ToString() + "'");
                // e.Row.Cells[8].Text = "Enter Practical Marks(270)";
                if (classification == "Engineering")
                {
                    e.Row.Cells[8].Visible = true;
                    e.Row.Cells[8].Text = "Practical Marks(out of 270)";
                }
                else if (classification == "Non-Engineering")
                {
                    e.Row.Cells[7].Visible = true;
                    e.Row.Cells[8].Text = "Practical Marks(out of 100)";
                }



                // e.Row.Cells[8].Text = "";
                // e.Row.Cells[8].Visible = false;
                e.Row.Cells[9].Text = "";
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[10].Text = "";
                e.Row.Cells[10].Visible = false;
                // e.Row.Cells[8].Text = "";
                // e.Row.Cells[8].Visible = false;
                //e.Row.Cells[3].Visible = false;
                //e.Row.Cells[6].Visible = false;
                //e.Row.Cells[9].Visible = false;
                //e.Row.Cells[10].Visible = false;

            }
        }


        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            TextBox txtOMRCode = (e.Row.FindControl("txtOMRCode") as TextBox);
            TextBox txtPracMarks = (e.Row.FindControl("txtPracticalMarks") as TextBox);
            DropDownList ddlpresentabsent = (e.Row.FindControl("ddlpresentabsent") as DropDownList);
            //OMR
            if (ddlEntryType.SelectedValue.ToString() == "O")
            {

                ddlpresentabsent.Visible = true;
                txtOMRCode.Visible = true;
                txtPracMarks.Visible = false;

                //present/absent
                e.Row.Cells[7].Visible = true;
                e.Row.Cells[3].Visible = true;
                e.Row.Cells[6].Visible = true;
                e.Row.Cells[9].Visible = true;
                e.Row.Cells[10].Visible = true;
            }
            //Practical
            if (ddlEntryType.SelectedValue.ToString() == "P")
            {
                ddlpresentabsent.Visible = true;
                e.Row.Cells[3].Visible = false;

                txtOMRCode.Visible = false;
                txtPracMarks.Visible = true;
                e.Row.Cells[7].Visible = true;
                e.Row.Cells[3].Visible = true;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[10].Visible = false;
                //if (ddlpresentabsent.SelectedItem.Text.ToString() == "Present")
                //{
                //    txtPracMarks.Visible = true;
                //}
                //else
                //{
                //    txtPracMarks.Visible = false;
                //}


            }
            //TextBox txtPracMarks = (e.Row.FindControl("txtPracticalMarks") as TextBox);
            //if (ddlTradeName.SelectedValue == "258" || ddlTradeName.SelectedValue == "259")
            //{
            //    txtPracMarks.Enabled = false;
            //}
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (isAllDataEntered())
            {
                //Check if Practical or not and insert internal data
                if (ddlEntryType.SelectedValue.ToString() == "P")
                {
                    if (txtIntName.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter Internal Name');", true);
                        txtIntName.Focus();
                        return;
                    }
                    if (txtIntAdd.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter Internal Address');", true);
                        txtIntAdd.Focus();
                        return;
                    }
                    if (txtIntPost.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter Internal Post');", true);
                        txtIntPost.Focus();
                        return;
                    }
                    if (txtExName.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter External Name');", true);
                        txtExName.Focus();
                        return;
                    }
                    if (txtExAdd.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter External Address');", true);
                        txtExAdd.Focus();
                        return;
                    }
                    if (txtExPost.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter External Post');", true);
                        txtExPost.Focus();
                        return;
                    }
                    if (txtdob.Value == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter External Post');", true);
                        txtExPost.Focus();
                        return;
                    }

                    hdnExaminerId.Value = Convert.ToString(InsertExaminer());

                }


                //----Insert OMR and Practical Marks
                int CheckedCount = 0;
                foreach (GridViewRow row1 in GridView1.Rows)
                {
                    if (row1.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row1.Cells[0].FindControl("checkCan") as CheckBox);
                        if (chkRow.Checked)
                        {
                            CheckedCount = CheckedCount + 1;
                            DropDownList ddlpresentabsent = (DropDownList)row1.Cells[7].FindControl("ddlpresentabsent");
                            DropDownList ddlsessionme = (DropDownList)row1.Cells[10].FindControl("ddlsessionme");
                            int TraineeId = Convert.ToInt32((row1.Cells[11].FindControl("lblTraineeID") as Label).Text);
                            string RollNo = row1.Cells[1].Text;
                            string OMRCode = "";
                            string PracticalMarks = "0";
                            string PresentAb = "";
                            string ExaminerId = "";
                            string Tradecode = "";
                            string dateofexam = "0";
                            string Session = "";

                            //DateTime doe = Convert.ToDateTime(dateofexam);
                            if (ddlEntryType.SelectedValue.ToString() == "O")
                            {
                                //OMRCode = (row1.Cells[4].FindControl("txtOMRCode") as TextBox).Text;
                                OMRCode = (row1.Cells[8].FindControl("txtOMRCode") as TextBox).Text;
                                PresentAb = ddlpresentabsent.SelectedValue.ToString();
                                Tradecode = (row1.Cells[6].FindControl("txttradecode") as TextBox).Text;
                                dateofexam = (row1.Cells[9].FindControl("txtDOExam") as TextBox).Text;
                                if (dateofexam == "")
                                {
                                    dateofexam = "0";
                                }
                                Session = ddlsessionme.SelectedValue.ToString();
                            }
                            else
                            {
                                //PracticalMarks = (row1.Cells[4].FindControl("txtPracticalMarks") as TextBox).Text;
                                PracticalMarks = (row1.Cells[8].FindControl("txtPracticalMarks") as TextBox).Text;
                                PresentAb = ddlpresentabsent.SelectedValue.ToString();
                                ExaminerId = hdnExaminerId.Value;

                            }
                            PracticalMarks = PracticalMarks == "" ? "0" : PracticalMarks;
                            string ins = "";
                            //string ins = "exec SP_Insert_OMRDetails  @TraineeId=" + TraineeId + " ,@RollNo='" + RollNo + "' ,@OMR='" + OMRCode + "',@PracticalMarks=" + PracticalMarks + ",@EntryType='" + ddlEntryType.SelectedValue.ToString() + "', @PresentAb='" + PresentAb + "', @ExaminerId='" + ExaminerId + "'";
                            if (ddlPaper.SelectedValue == "1")
                            {
                                ins = "exec SP_Insert_OMRDetails1Test  @TraineeId=" + TraineeId + " ,@RollNo='" + RollNo + "', @OMR='" + OMRCode + "',@PracticalMarks=" + PracticalMarks + ",@EntryType='" + ddlEntryType.SelectedValue.ToString() + "', @PresentAb='" + PresentAb + "', @ExaminerId='" + ExaminerId + "', @TradeCode='" + Tradecode + "', @DateOfExam='" + dateofexam + "', @Session='" + Session + "', @PaperType=" + ddlPaper.SelectedValue + "";
                            }
                            else
                            {
                                ins = "exec SP_Insert_OMRDetails1Test  @TraineeId=" + TraineeId + " ,@RollNo='" + RollNo + "', @Paper2='" + OMRCode + "',@PracticalMarks=" + PracticalMarks + ",@EntryType='" + ddlEntryType.SelectedValue.ToString() + "',  @Presentabsent1='" + PresentAb + "', @ExaminerId='" + ExaminerId + "', @TradeCode1='" + Tradecode + "', @DateOfExam1='" + dateofexam + "', @Session1='" + Session + "', @PaperType=" + ddlPaper.SelectedValue + "";
                            }

                            bool result = MySql.ExecuteNonQuery(ins);
                            if (result == true)
                            {
                                lblCMessage.Text = "Records Saved successfully";
                                btnPrint.Enabled = true;
                            }
                            else
                            {
                                lblCMessage.Text = "Record not saved";
                            }
                        }
                    }
                }
                if (CheckedCount > 0)
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    btnSave.Visible = false;

                }
                else
                {
                    lblCMessage.Text = "Please select at least one record for update";
                }
            }

        }
        catch (Exception ex)
        {
            LogError(ex);
        }
    }

    //-----Save Validation
    bool isAllDataEntered()
    {


        classification = MySql.SingleCellResultInString("select Classification from Tradecodemaster where TradeCode='" + ddlTradeName.SelectedValue.ToString() + "'");
        //----Check all values entered of checked row
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            { 
               
                CheckBox chkRow = (row.Cells[0].FindControl("checkCan") as CheckBox);
                if (chkRow.Checked)
                {
                    string RollNo = row.Cells[1].Text;
                    string OMRCode = (row.Cells[8].FindControl("txtOMRCode") as TextBox).Text;
                     DropDownList ddlpresentabsent = (DropDownList)row.Cells[7].FindControl("ddlpresentabsent");
                    //string PracticalMarks = (row.Cells[5].FindControl("txtPracticalMarks") as TextBox).Text;
                    int PracticalMarks = 0;
                    if (ddlEntryType.SelectedValue.ToString() == "O")
                    {
                        PracticalMarks = 0;
                    }
                    else
                    {
                        if (ddlpresentabsent.SelectedValue=="P")
                        {
                            PracticalMarks = Convert.ToInt32((row.Cells[8].FindControl("txtPracticalMarks") as TextBox).Text);
                        }
                        else
                        {
                            PracticalMarks = 0;
                        }
                       
                    }


                   
                    string Examdate = (row.Cells[9].FindControl("txtDOExam") as TextBox).Text;
                    DropDownList ddlsessionme = (DropDownList)row.Cells[10].FindControl("ddlsessionme");


                    if (ddlEntryType.SelectedValue.ToString() == "O" && ddlpresentabsent.SelectedValue.ToString() == "P" && OMRCode.Trim() == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('OMR code of all present checked data is required');", true);
                        return false;
                    }
                    if (ddlEntryType.SelectedValue.ToString() == "O" && ddlpresentabsent.SelectedValue.ToString() == "P" && Examdate.Length < 8)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Enter proper Date of Exam');", true);
                        return false;
                    }

                    if (ddlEntryType.SelectedValue.ToString() == "O" && ddlpresentabsent.SelectedValue.ToString() == "P" && OMRCode.Length < 7)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('OMR Code Should be 7 digits');", true);
                        return false;
                    }


                    if (PracticalMarks > 0)
                    {
                        if (classification == "Engineering" && PracticalMarks > 270)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('270 is maximum marks for this trade.');", true);
                            return false;
                        }
                        else if (classification == "Non-Engineering" && PracticalMarks > 100)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('100 is maximum marks for this trade.');", true);
                            return false;
                        }
                    }
                    ////if (ddlEntryType.SelectedValue.ToString() == "P" && ddlpresentabsent.SelectedValue == "P")
                    //{
                    //    if (ddlEntryType.SelectedValue.ToString() == "P" && PracticalMarks == "")
                    //    {
                    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Practical marks of all checked data is required');", true);
                    //        return false;
                    //    }
                    //}



                    //if (ddlTradeName.SelectedValue != "258" || ddlTradeName.SelectedValue != "259")
                    //{
                    //    if (PracticalMarks.Trim() == "")
                    //    {
                    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('OMR/Practical Marks of all checked data is required');", true);
                    //        return false;
                    //    }
                    //}
                }
            }
        }
        return true;
    }

    //-----Search Validation
    bool isvalidate()
    {
        if (ddlSession.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select session');", true);
            ddlSession.Focus();
            return false;
        }
        if (ddlNameofITI.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select name of ITI');", true);
            ddlNameofITI.Focus();
            return false;
        }
        if (ddlSemester.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select semester');", true);
            ddlSemester.Focus();
            return false;
        }
        if (ddlTradeName.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select trade name');", true);
            ddlTradeName.Focus();
            return false;
        }
        if (ddlEntryType.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select entry Type');", true);
            ddlEntryType.Focus();
            return false;
        }
        if (ddlEntryType.SelectedValue.ToString() == "O")
        {
            if (ddlPaper.SelectedValue == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select paper');", true);
                ddlPaper.Focus();
                return false;
            }
        }

        if (ddlTradeName.SelectedValue == "258" || ddlTradeName.SelectedValue == "259")
        {
            if (ddlEntryType.SelectedValue.ToString() == "P")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('You are not allowed to enter practical marks for this trade');", true);
                ddlTradeName.Focus();
                return false;
            }
        }

        //if (ddlDuration.SelectedValue == "0")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Duration');", true);
        //    ddlDuration.Focus();
        //    return false;
        //}
        //if (ddlSlot.SelectedValue == "0")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Slot');", true);
        //    ddlSlot.Focus();
        //    return false;
        //}

        return true;
    }

    protected void checkAll_CheckedChanged(object sender, EventArgs e)
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

    protected void btnExit_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }

    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindNameOfITI(Convert.ToInt32(ddlSession.SelectedValue));
    }

    protected void txtOMRCode_TextChanged(object sender, EventArgs e)
    {
        GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
        TextBox txt = (TextBox)currentRow.FindControl("txtOMRCode");

        if (IsOMRExists(txt.Text.Trim()))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('OMR you have entered is already exists');", true);
            txt.Text = "";
        }
    }

    bool IsOMRExists(string strOMR)
    {
        DataSet DsIsOMRExists = new DataSet();
        if(ddlPaper.SelectedValue=="1")
        {
            DsIsOMRExists = MySql.GetDataSetWithQuery("Exec sp_CheckIsOMRExists @OMR='" + strOMR + "', @PaperType='" + ddlPaper.SelectedValue.ToString() + "'");
        }
        else
        {
            DsIsOMRExists = MySql.GetDataSetWithQuery("Exec sp_CheckIsOMRExists  @Paper2='" + strOMR + "', @PaperType='" + ddlPaper.SelectedValue.ToString() + "'");
        }
       
        if (DsIsOMRExists.Tables[0].Rows.Count > 0)
        {
            return true;
        }
        return false;
    }
    protected void ddlEntryType_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblCMessage.Text = "";
        if (ddlEntryType.SelectedValue.ToString() == "O")
        {
            tr1.Visible = true;
            tr2.Visible = true;
            trInt.Visible = false;
            trIntAdd.Visible = false;
            trIntPost.Visible = false;
            trexamdate.Visible = false;
            //trInt1.Visible = false;
            trInt2.Visible = false;

        }
        else
        {
            ddlPaper.SelectedIndex = -1;
            tr1.Visible = false;
            tr2.Visible = false;
            trInt.Visible = true;
            trIntAdd.Visible = true;
            trIntPost.Visible = true;
            //trInt1.Visible = true;
            trexamdate.Visible = true;
            trInt2.Visible = true;

        }
    }
    protected void ddlpresentabsent_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        int iRow = ((GridViewRow)(ddl.Parent.BindingContainer)).RowIndex;

        if (ddlEntryType.SelectedValue.ToString() == "P")
        {

            if (GridView1.Rows.Count > 0)
            {
                DropDownList ddlpresentabsent = (DropDownList)GridView1.Rows[iRow].Cells[7].FindControl("ddlpresentabsent");
                TextBox txtPracticalMarks = (TextBox)GridView1.Rows[iRow].Cells[6].FindControl("txtPracticalMarks");
                if (ddlpresentabsent.SelectedValue == "A")
                {
                    txtPracticalMarks.Enabled = false;
                }
                else if (ddlpresentabsent.SelectedValue == "P")
                {
                    txtPracticalMarks.Enabled = true;
                }
                else
                {
                    txtPracticalMarks.Enabled = false;
                }

            }
        }
        else if (ddlEntryType.SelectedValue.ToString() == "O")
        {
            DropDownList ddlpresentabsent = (DropDownList)GridView1.Rows[iRow].Cells[7].FindControl("ddlpresentabsent");
            TextBox txtomransno = (TextBox)GridView1.Rows[iRow].Cells[8].FindControl("txtOMRCode");
            TextBox txtDOExam = (TextBox)GridView1.Rows[iRow].Cells[9].FindControl("txtDOExam");
            if (ddlpresentabsent.SelectedValue == "A")
            {
                txtomransno.Enabled = false;
                txtDOExam.Enabled = false;
            }
            else if (ddlpresentabsent.SelectedValue == "P")
            {
                txtomransno.Enabled = true;
                txtDOExam.Enabled = true;
            }
            else
            {
                txtomransno.Enabled = false;
                txtDOExam.Enabled = false;
            }



        }

    }

    public int InsertExaminer()
    {
        SqlConnection dbcon = new SqlConnection(CommonPerception.ConnectionString());
        dbcon.Open();
        SqlCommand dbcom = new SqlCommand("Sp_InsertExaminer", dbcon);
        dbcom.CommandType = CommandType.StoredProcedure;
        dbcom.CommandText = "Sp_InsertExaminer";

        dbcom.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IntName", System.Data.SqlDbType.VarChar, 200, "IntName"));
        dbcom.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IntAdd", System.Data.SqlDbType.VarChar, 200, "IntAdd"));
        dbcom.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IntPost", System.Data.SqlDbType.VarChar, 200, "IntPost"));
        dbcom.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExName", System.Data.SqlDbType.VarChar, 200, "ExName"));
        dbcom.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExAdd", System.Data.SqlDbType.VarChar, 200, "ExAdd"));
        dbcom.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExPost", System.Data.SqlDbType.VarChar, 200, "ExPost"));
        dbcom.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExamDate", System.Data.SqlDbType.DateTime, 200, "ExamDate"));

        dbcom.Parameters["@IntName"].Value = txtIntName.Text.ToString();
        dbcom.Parameters["@IntAdd"].Value = txtIntAdd.Text.ToString();
        dbcom.Parameters["@IntPost"].Value = txtIntPost.Text.ToString();
        dbcom.Parameters["@ExName"].Value = txtExName.Text.ToString();
        dbcom.Parameters["@ExAdd"].Value = txtExAdd.Text.ToString();
        dbcom.Parameters["@ExPost"].Value = txtExPost.Text.ToString();

        string txt = txtdob.Value.ToString();
        txt = ChangeFormat(Convert.ToDateTime(txt), "yyyy-MM-dd");
        string extra;
        extra = " 00:00:00.000";
        string txtvalue = txt + extra;
        dbcom.Parameters["@ExamDate"].Value = Convert.ToDateTime(txtvalue);

        dbcom.Parameters.AddWithValue("@ExaninerId", 0);
        dbcom.Parameters["@ExaninerId"].Direction = ParameterDirection.Output;
        dbcom.ExecuteNonQuery();
        return (int)dbcom.Parameters["@ExaninerId"].Value;
    }

    public string ChangeFormat(DateTime dtm, string format)
    {

        return dtm.ToString(format);

    }
    protected void btnReport_Click(object sender, EventArgs e)
    {

    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        if (ddlEntryType.SelectedValue == "O")
        {
            Session["rptSessionID"] = Convert.ToInt32(ddlSession.SelectedValue);
            Session["rptITICode"] = Convert.ToString(ddlNameofITI.SelectedValue);
            Session["rptSemID"] = Convert.ToInt32(ddlSemester.SelectedValue);
            Session["rptTradeCode"] = Convert.ToString(ddlTradeName.SelectedValue);
            Session["rptPaperID"] = Convert.ToInt32(ddlPaper.SelectedValue);
            Session["rptEntryType"] = Convert.ToString(ddlEntryType.SelectedValue);
            Session["rptRollnuber"] = null;
            // Response.Write("<script> window.open('PdfOMRAnsSheetNoReport.aspx','_blank' ); </script>");
            //Response.End();
            string url = "PdfOMRAnsSheetNoReport.aspx";
            string s = "window.open('" + url + "', 'popup_window', 'width=900,height=800,left=100,top=100,resizable=no');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.popup('PdfOMRAnsSheetNoReport.aspx','_newtab');", true);
            //Response.Redirect("PdfOMRAnsSheetNoReport.aspx");
        }
        else if (ddlEntryType.SelectedValue == "P")
        {
            Session["rptSessionID"] = Convert.ToInt32(ddlSession.SelectedValue);
            Session["rptITICode"] = Convert.ToString(ddlNameofITI.SelectedValue);
            Session["rptSemID"] = Convert.ToInt32(ddlSemester.SelectedValue);
            Session["rptTradeCode"] = Convert.ToString(ddlTradeName.SelectedValue);
            Session["rptPaperID"] = Convert.ToInt32(ddlPaper.SelectedValue);
            Session["rptEntryType"] = Convert.ToString(ddlEntryType.SelectedValue);
            Session["rptRollnuber"] = null;
            string x = hdnExaminerId.Value;
            Session["rptExaminerId"] = hdnExaminerId.Value;

            string url = "PdfPracticalMarksReport.aspx";
            string s = "window.open('" + url + "', 'popup_window', 'width=900,height=800,left=100,top=100,resizable=no');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);

            // Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('PdfOMRAnsSheetNoReport.aspx','_newtab');", true);
            // Response.Redirect("PdfPracticalMarksReport.aspx");    
        }
    }
    protected void ddlNameofITI_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTradeName(Convert.ToString(ITICode));
    }
    protected void btnchangepass_Click(object sender, EventArgs e)
    {
        Session["CenterITICode"] = Session["CenterITICode"].ToString();
        Response.Redirect("ChangePassword.aspx");
    }
    protected void btnlogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }

}