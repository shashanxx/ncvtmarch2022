using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Class;
using System.Data;
using System.Data.SqlClient;

public partial class Center_EditExamCenter : ClsErrorLog
{
    CommonPerception MySql = new CommonPerception();
    DataSet dsgetData = new DataSet();
    string ITICode = "";
    string classification = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["CenterITICode"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            BindSessionName();
            BindSemesterMaster();

            BindPaperMaster();
            BindDuration();
            BindSlot();
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
                Fillgrid();
            }
        }
        catch (Exception ex)
        {
            LogError(ex);
        }
    }

    void Fillgrid()
    {
        if (txtRollNo.Text.Trim() == "")
        {
            dsgetData = MySql.GetDataSetWithQuery("Exec Sp_BindGridinCenter_Update1 " + Convert.ToInt32(ddlSession.SelectedValue) + ", '" + Convert.ToString(ddlNameofITI.SelectedValue) + "'," + Convert.ToInt32(ddlSemester.SelectedValue) + ",'" + Convert.ToString(ddlTradeName.SelectedValue) + "'," + Convert.ToInt32(ddlPaper.SelectedValue) + ",'" + Convert.ToString(ddlEntryType.SelectedValue) + "'");
        }
        else
        {
            dsgetData = MySql.GetDataSetWithQuery("Exec Sp_BindGridinCenter_Update1 " + Convert.ToInt32(ddlSession.SelectedValue) + ", '" + Convert.ToString(ddlNameofITI.SelectedValue) + "'," + Convert.ToInt32(ddlSemester.SelectedValue) + ",'" + Convert.ToString(ddlTradeName.SelectedValue) + "'," + Convert.ToInt32(ddlPaper.SelectedValue) + ",'" + Convert.ToString(ddlEntryType.SelectedValue) + "','" + Convert.ToString(txtRollNo.Text) + "'");
        }

        if (dsgetData.Tables[0].Rows.Count > 0)
        {
            if(ddlEntryType.SelectedValue=="O")
            {
                GridView2.Visible = false;
                GridView1.Visible = true;
                GridView1.DataSource = dsgetData;
                GridView1.DataBind();
            
               
            }
            else
            {
                GridView2.Visible = true;
                GridView1.Visible = false;
                GridView2.DataSource = dsgetData;
                GridView2.DataBind();
            }
        
            lblCMessage.Text = "<b>Total No. of Records -</b>" + dsgetData.Tables[0].Rows.Count;
            btnSave.Visible = true;
            btnupdate.Visible = false;
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            GridView2.DataSource = null;
            GridView2.DataBind();
            lblCMessage.Text = "<b>Records Not Found</b>";
            btnSave.Visible = false;
            btnupdate.Visible = false;
        }
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        //OMR Grid

        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (ddlEntryType.SelectedValue.ToString() == "O")
            {
                e.Row.Cells[7].Text = "OMR Answer Sheet No";
                //e.Row.Cells[5].Visible = true;
                //e.Row.Cells[8].Visible = true;
                //e.Row.Cells[9].Visible = true;
            }
            //else
            //{
            //    classification = MySql.SingleCellResultInString("select Classification from Tradecodemaster where TradeCode='" + ddlTradeName.SelectedValue.ToString() + "'");
 
            //    if (classification == "Engineering")
            //    {
            //        e.Row.Cells[7].Visible = true;
            //        e.Row.Cells[7].Text = "Practical Marks(out of 270)";
            //    }
            //    else if (classification == "Non-Engineering")
            //    {
            //        e.Row.Cells[7].Visible = true;
            //        e.Row.Cells[7].Text = "Practical Marks(out of 100)";
            //    }
            
            //    e.Row.Cells[5].Visible = true;

   
            //    e.Row.Cells[8].Visible = false;
            //    e.Row.Cells[9].Visible = false;
            //    e.Row.Cells[7].Visible = true;
            //}
        }
        //OMR Grid
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtOMRCode = (e.Row.FindControl("txtOMRCode") as TextBox);
            TextBox txtPracMarks = (e.Row.FindControl("txtPracticalMarks") as TextBox);

            DropDownList ddlpresentabsent = (e.Row.FindControl("ddlpresentabsent") as DropDownList);




            string presentabsent = (e.Row.FindControl("lblpresentabsent") as Label).Text;
            ddlpresentabsent.Items.FindByValue(presentabsent).Selected = true;



            if (ddlEntryType.SelectedValue.ToString() == "O")
            {

                DropDownList ddlsessionme = (e.Row.FindControl("ddlsessionme") as DropDownList);
                string sessionme = (e.Row.FindControl("lblsessionme") as Label).Text;
                ddlsessionme.Items.FindByValue(sessionme).Selected = true;

                txtOMRCode.Visible = true;
                txtPracMarks.Visible = false;
            }
            //if (ddlEntryType.SelectedValue.ToString() == "P")
            //{
            //    txtOMRCode.Visible = false;
            //    txtPracMarks.Visible = true;
            //}


            //Added
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                //OMR
                if (ddlEntryType.SelectedValue.ToString() == "O")
                {

                    ddlpresentabsent.Visible = true;
                    txtOMRCode.Visible = true;
                    txtPracMarks.Visible = false;

                    //present/absent
                    e.Row.Cells[7].Visible = true;
                    e.Row.Cells[5].Visible = true;
                    e.Row.Cells[8].Visible = true;
                    e.Row.Cells[9].Visible = true;
                //    e.Row.Cells[10].Visible = true;
                }
                //Practical
                //if (ddlEntryType.SelectedValue.ToString() == "P")
                //{
                //    ddlpresentabsent.Visible = true;
                //    e.Row.Cells[3].Visible = false;

                //    txtOMRCode.Visible = false;
                //    txtPracMarks.Visible = true;
                //    e.Row.Cells[7].Visible = true;
                //    e.Row.Cells[5].Visible = true;
                //    e.Row.Cells[8].Visible = false;
                //    e.Row.Cells[9].Visible = false;
                //   // e.Row.Cells[10].Visible = false;
                //    //if (ddlpresentabsent.SelectedItem.Text.ToString() == "Present")
                //    //{
                //    //    txtPracMarks.Visible = true;

                //}
            }
        }
    }
 

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            lblCMessage.Text = "";
            if (isAllDataEntered())
            {
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

                            string tradecodeentered = "";
                            string sessionme = "";
                            string dateofexam = "";
                            tradecodeentered = ((row1.Cells[5].FindControl("txttradecode") as TextBox).Text);
                            sessionme = ((row1.Cells[9].FindControl("ddlsessionme") as DropDownList).Text);
                            dateofexam = ((row1.Cells[8].FindControl("txtDOExam") as TextBox).Text);

                            string Presentabsent = ((row1.Cells[5].FindControl("ddlpresentabsent") as DropDownList).Text);
                            int TraineeId = Convert.ToInt32((row1.Cells[10].FindControl("lblTraineeID") as Label).Text);
                            string ExaminerId=((row1.Cells[11].FindControl("lblexaminerid") as Label).Text);
                            string RollNo = row1.Cells[1].Text;
                            string OMRCode = "";
                            string PracticalMarks = "";
                            if (ddlEntryType.SelectedValue.ToString() == "O")
                            {
                                OMRCode = (row1.Cells[7].FindControl("txtOMRCode") as TextBox).Text;
                            }
                            else
                            {
                                PracticalMarks = (row1.Cells[7].FindControl("txtPracticalMarks") as TextBox).Text;
                            }
                            PracticalMarks = PracticalMarks == "" ? "0" : PracticalMarks;

                            string ins = "";
                            if (ddlPaper.SelectedValue == "1")
                            {
                                ins = "exec SP_Insert_OMRDetails1Test  @TraineeId=" + TraineeId + " ,@RollNo='" + RollNo + "', @OMR='" + OMRCode + "',@EntryType='" + ddlEntryType.SelectedValue.ToString() + "', @PresentAb='" + Presentabsent + "', @TradeCode='" + tradecodeentered + "', @DateOfExam='" + dateofexam + "', @ExaminerId='" + ExaminerId + "', @Session='" + sessionme + "', @PaperType=" + ddlPaper.SelectedValue + "";
                            }
                            else
                            {
                                ins = "exec SP_Insert_OMRDetails1Test  @TraineeId=" + TraineeId + " ,@RollNo='" + RollNo + "', @Paper2='" + OMRCode + "',@EntryType='" + ddlEntryType.SelectedValue.ToString() + "',  @Presentabsent1='" + Presentabsent + "', @TradeCode1='" + tradecodeentered + "', @DateOfExam1='" + dateofexam + "', @ExaminerId='" + ExaminerId + "', @Session1='" + sessionme + "', @PaperType=" + ddlPaper.SelectedValue + "";
                            }



                          //  string ins = "exec SP_Insert_OMRDetails1Test @TraineeId=" + TraineeId + " ,@RollNo='" + RollNo + "' ,@OMR='" + OMRCode + "',@PracticalMarks=" + PracticalMarks + ",@EntryType='" + ddlEntryType.SelectedValue.ToString() + "', @ExaminerId='" + ExaminerId + "',  @TradeCode='" + tradecodeentered + "', @Session='" + sessionme + "', @DateOfExam='" + dateofexam + "', @PresentAb='" + Presentabsent + "'";
                          // SP_Insert_OMRDetails12
                            bool result = MySql.ExecuteNonQuery(ins);
                            if (result==true)
                            {
                                lblCMessage.Text = "Records Updated successfully.";
                            }
                            else
                            {
                                lblCMessage.Text = "Records not Updated.";
                            }
                        }
                    }
                }

                //Grid 2 Practical
                foreach (GridViewRow row1 in GridView2.Rows)
                {
                    if (row1.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row1.Cells[0].FindControl("checkCan") as CheckBox);
                        if (chkRow.Checked)
                        {
                            CheckedCount = CheckedCount + 1;
                  
                            int TraineeId = Convert.ToInt32((row1.Cells[7].FindControl("lblTraineeID") as Label).Text);
                            string ExaminerId = ((row1.Cells[8].FindControl("lblexaminerid") as Label).Text);

                            string Presentabsent = ((row1.Cells[5].FindControl("ddlpresentabsent1") as DropDownList).Text);
                            string RollNo = row1.Cells[1].Text;
                            string OMRCode = "";
                            string PracticalMarks = "";
                          
                            if (ddlEntryType.SelectedValue.ToString() == "O")
                            {
                                OMRCode = (row1.Cells[6].FindControl("txtOMRCode") as TextBox).Text;
                            }
                            else
                            {
                                PracticalMarks = (row1.Cells[6].FindControl("txtPracticalMarks") as TextBox).Text;
                            }
                            PracticalMarks = PracticalMarks == "" ? "0" : PracticalMarks;
                            string ins = "exec SP_Insert_OMRDetails1Test  @TraineeId=" + TraineeId + " ,@RollNo='" + RollNo + "', @PracticalMarks=" + PracticalMarks + ",@EntryType='" + ddlEntryType.SelectedValue.ToString() + "', @ExaminerId='" + ExaminerId + "', @PresentAb='" + Presentabsent + "'";
                            bool result = MySql.ExecuteNonQuery(ins);
                            if (result == true)
                            {
                                lblCMessage.Text = "Records Updated successfully.";
                            }
                            else
                            {
                                lblCMessage.Text = "Records not Updated.";
                            }
                        }
                    }
                }
                if (CheckedCount > 0)
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                    btnSave.Visible = false;
                    lblCMessage.Text = "Records Updated successfully.";
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
                    string OMRCode = (row.Cells[6].FindControl("txtOMRCode") as TextBox).Text;
                    //string PracticalMarks = (row.Cells[5].FindControl("txtPracticalMarks") as TextBox).Text;
                    int PracticalMarks = 0;
                    if (ddlEntryType.SelectedValue.ToString() == "O")
                    {
                        PracticalMarks = 0;
                    }
                    else
                    {
                        PracticalMarks = Convert.ToInt32((row.Cells[6].FindControl("txtPracticalMarks") as TextBox).Text);
                    }

                   // int PracticalMarks = Convert.ToInt32((row.Cells[4].FindControl("txtPracticalMarks") as TextBox).Text);

                    if (ddlEntryType.SelectedValue.ToString() == "O" && OMRCode.Trim() == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('OMR clode of all checked data is required');", true);
                        return false;
                    }

                    if (ddlEntryType.SelectedValue.ToString() == "O" && OMRCode.Length < 7)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('OMR Code Should be 7 digits');", true);
                        return false;
                    }

                    //if (ddlEntryType.SelectedValue.ToString() == "P" && PracticalMarks == "")
                    //{
                    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Practical marks of all checked data is required');", true);
                    //    return false;
                    //}

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

        foreach (GridViewRow row in GridView2.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("checkCan") as CheckBox);
                if (chkRow.Checked)
                {
                    string RollNo = row.Cells[1].Text;
                    string OMRCode = (row.Cells[6].FindControl("txtOMRCode") as TextBox).Text;
                    //string PracticalMarks = (row.Cells[5].FindControl("txtPracticalMarks") as TextBox).Text;
                    int PracticalMarks = 0;
                    if (ddlEntryType.SelectedValue.ToString() == "O")
                    {
                        PracticalMarks = 0;
                    }
                    else
                    {
                        PracticalMarks = Convert.ToInt32((row.Cells[6].FindControl("txtPracticalMarks") as TextBox).Text);
                    }

                    // int PracticalMarks = Convert.ToInt32((row.Cells[4].FindControl("txtPracticalMarks") as TextBox).Text);

                    if (ddlEntryType.SelectedValue.ToString() == "O" && OMRCode.Trim() == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('OMR clode of all checked data is required');", true);
                        return false;
                    }

                    if (ddlEntryType.SelectedValue.ToString() == "O" && OMRCode.Length < 7)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('OMR Code Should be 7 digits');", true);
                        return false;
                    }

                    //if (ddlEntryType.SelectedValue.ToString() == "P" && PracticalMarks == "")
                    //{
                    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Practical marks of all checked data is required');", true);
                    //    return false;
                    //}

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
        if (ddlPaper.SelectedValue == "1")
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

    protected void txtRollNo_TextChanged(object sender, EventArgs e)
    {
        Fillgrid();
    }
    protected void ddlEntryType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEntryType.SelectedValue.ToString() == "O")
        {
            ddlPaper.Visible = true;
            lblPaper.Visible = true;

        }
        else
        {
            ddlPaper.SelectedIndex = -1;
            ddlPaper.Visible = false;
            lblPaper.Visible = false;

        }

    }
    protected void btnupdate_Click(object sender, EventArgs e)
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
        //else if (ddlEntryType.SelectedValue == "P")
        //{
        //    Session["rptSessionID"] = Convert.ToInt32(ddlSession.SelectedValue);
        //    Session["rptITICode"] = Convert.ToString(ddlNameofITI.SelectedValue);
        //    Session["rptSemID"] = Convert.ToInt32(ddlSemester.SelectedValue);
        //    Session["rptTradeCode"] = Convert.ToString(ddlTradeName.SelectedValue);
        //    Session["rptPaperID"] = Convert.ToInt32(ddlPaper.SelectedValue);
        //    Session["rptEntryType"] = Convert.ToString(ddlEntryType.SelectedValue);
        //    Session["rptRollnuber"] = null;
        //    string x = hdnExaminerId.Value;
        //    Session["rptExaminerId"] = hdnExaminerId.Value;

        //    string url = "PdfPracticalMarksReport.aspx";
        //    string s = "window.open('" + url + "', 'popup_window', 'width=900,height=800,left=100,top=100,resizable=no');";
        //    ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);

        //    // Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('PdfOMRAnsSheetNoReport.aspx','_newtab');", true);
        //    // Response.Redirect("PdfPracticalMarksReport.aspx");    
        //}
        //Session["rptSessionID"] = Convert.ToInt32(ddlSession.SelectedValue);
        //Session["rptITICode"] = Convert.ToString(ddlNameofITI.SelectedValue);
        //Session["rptSemID"] = Convert.ToInt32(ddlSemester.SelectedValue);
        //Session["rptTradeCode"] = Convert.ToString(ddlTradeName.SelectedValue);
        //Session["rptPaperID"] = Convert.ToInt32(ddlPaper.SelectedValue);
        //Session["rptEntryType"] = Convert.ToString(ddlEntryType.SelectedValue);
        //Session["rptRollnuber"] = null;
        //Response.Redirect("PdfOMRAnsSheetNoReport.aspx");
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
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
          if (e.Row.RowType == DataControlRowType.Header)
         {
          
           
                classification = MySql.SingleCellResultInString("select Classification from Tradecodemaster where TradeCode='" + ddlTradeName.SelectedValue.ToString() + "'");
 
                if (classification == "Engineering")
                {
                    e.Row.Cells[7].Visible = true;
                    e.Row.Cells[7].Text = "Practical Marks(out of 270)";
                }
                else if (classification == "Non-Engineering")
                {
                    e.Row.Cells[7].Visible = true;
                    e.Row.Cells[7].Text = "Practical Marks(out of 100)";
                }
            
                //e.Row.Cells[5].Visible = true;

   
                //e.Row.Cells[8].Visible = false;
                //e.Row.Cells[9].Visible = false;
                //e.Row.Cells[7].Visible = true;
           
        }
        //OMR Grid
          if (e.Row.RowType == DataControlRowType.DataRow)
          {
              TextBox txtOMRCode = (e.Row.FindControl("txtOMRCode") as TextBox);
              TextBox txtPracMarks = (e.Row.FindControl("txtPracticalMarks") as TextBox);

              DropDownList ddlpresentabsent = (e.Row.FindControl("ddlpresentabsent1") as DropDownList);

              string presentabsent = (e.Row.FindControl("lblpresentabsent1") as Label).Text;
              ddlpresentabsent.Items.FindByValue(presentabsent).Selected = true;



              if (ddlEntryType.SelectedValue.ToString() == "P")
              {
                  txtOMRCode.Visible = false;
                  txtPracMarks.Visible = true;
              }


              //Added
              if (e.Row.RowType == DataControlRowType.DataRow)
              {
             //Practical
                  if (ddlEntryType.SelectedValue.ToString() == "P")
                  {
                      ddlpresentabsent.Visible = true;
              
                  }
              }
          }
    }

}