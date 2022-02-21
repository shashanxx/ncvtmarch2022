using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Class;
using System.Data;
using System.Data.SqlClient;

public partial class Center_ExamCenterReport : ClsErrorLog
{
    CommonPerception MySql = new CommonPerception();
    DataSet dsgetData = new DataSet();
    string ITICode = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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
                dsgetData = MySql.GetDataSetWithQuery("Exec Sp_BindGridinCenter_ForReport " + Convert.ToInt32(ddlSession.SelectedValue) + ",'" + Convert.ToString(ddlNameofITI.SelectedValue) + "'," + Convert.ToInt32(ddlSemester.SelectedValue) + ",'" + Convert.ToString(ddlTradeName.SelectedValue) + "'," + Convert.ToInt32(ddlPaper.SelectedValue) + ",'" + Convert.ToString(ddlEntryType.SelectedValue) + "', '" + ddlexaminer.SelectedValue.ToString() + "'");
                if (dsgetData.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = dsgetData;
                    GridView1.DataBind();
                    lblCMessage.Text = "<b>Total No. of Records -</b>" + dsgetData.Tables[0].Rows.Count;
                    btnSave.Visible = false;
                    btnPrint.Visible = true;
                    btnPrint.Enabled = true;
                    hiddenExaminerid.Value = dsgetData.Tables[0].Rows[0]["ExaminerId"].ToString();
                    //DataSet ds = new DataSet();
                    //ds = MySql.GetDataSetWithQuery("Exec BindExaminerDropDown " + Convert.ToInt32(ddlSession.SelectedValue) + ",'" + Convert.ToString(ddlNameofITI.SelectedValue) + "'," + Convert.ToInt32(ddlSemester.SelectedValue) + ",'" + Convert.ToString(ddlTradeName.SelectedValue) + "'");
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    ddlexaminer.DataSource = ds;
                    //    ddlexaminer.DataTextField = "ExternalName";
                    //    ddlexaminer.DataValueField = "ExaminerId";
                    //    ddlexaminer.DataBind();
                    //    ddlexaminer.Items.Insert(0, new ListItem("Select Examiner", "0"));
                    //}


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
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (ddlEntryType.SelectedValue.ToString() == "O")
            {
                e.Row.Cells[5].Text = "Enter OMR Answer Sheet No";
            }
            else
            {
                e.Row.Cells[5].Text = "Enter Practical Marks";
            }
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtOMRCode = (e.Row.FindControl("txtOMRCode") as TextBox);
            TextBox txtPracMarks = (e.Row.FindControl("txtPracticalMarks") as TextBox);
            if (ddlEntryType.SelectedValue.ToString() == "O")
            {
                txtOMRCode.Visible = true;
                txtPracMarks.Visible = false;
            }
            if (ddlEntryType.SelectedValue.ToString() == "P")
            {
                txtOMRCode.Visible = false;
                txtPracMarks.Visible = true;
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

                    //   hdnExaminerId.Value = Convert.ToString(InsertExaminer());

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
                            DropDownList ddlpresentabsent = (DropDownList)row1.Cells[5].FindControl("ddlpresentabsent");
                            int TraineeId = Convert.ToInt32((row1.Cells[5].FindControl("lblTraineeID") as Label).Text);
                            string RollNo = row1.Cells[1].Text;
                            string OMRCode = "";
                            string PracticalMarks = "";
                            string PresentAb = "";
                            string ExaminerId = "";
                            if (ddlEntryType.SelectedValue.ToString() == "O")
                            {
                                //OMRCode = (row1.Cells[4].FindControl("txtOMRCode") as TextBox).Text;
                                OMRCode = (row1.Cells[5].FindControl("txtOMRCode") as TextBox).Text;
                            }
                            else
                            {
                                //PracticalMarks = (row1.Cells[4].FindControl("txtPracticalMarks") as TextBox).Text;
                                PracticalMarks = (row1.Cells[5].FindControl("txtPracticalMarks") as TextBox).Text;
                                PresentAb = ddlpresentabsent.SelectedValue.ToString();
                                //  ExaminerId = hdnExaminerId.Value;

                            }
                            PracticalMarks = PracticalMarks == "" ? "0" : PracticalMarks;
                            //string ins = "exec SP_Insert_OMRDetails  @TraineeId=" + TraineeId + " ,@RollNo='" + RollNo + "' ,@OMR='" + OMRCode + "',@PracticalMarks=" + PracticalMarks + ",@EntryType='" + ddlEntryType.SelectedValue.ToString() + "', @PresentAb='" + PresentAb + "', @ExaminerId='" + ExaminerId + "'";
                            string ins = "exec SP_Insert_OMRDetails  @TraineeId=" + TraineeId + " ,@RollNo='" + RollNo + "' ,@OMR='" + OMRCode + "',@PracticalMarks=" + PracticalMarks + ",@EntryType='" + ddlEntryType.SelectedValue.ToString() + "', @PresentAb='" + PresentAb + "', @ExaminerId='" + ExaminerId + "'";
                            bool result = MySql.ExecuteNonQuery(ins);
                            if (result == true)
                            {
                                btnPrint.Enabled = true;
                            }
                        }
                    }
                }
                if (CheckedCount > 0)
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    btnSave.Visible = false;
                    lblCMessage.Text = "Records Saved successfully";
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
        //----Check all values entered of checked row
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("checkCan") as CheckBox);
                if (chkRow.Checked)
                {
                    string RollNo = row.Cells[1].Text;
                    string OMRCode = (row.Cells[5].FindControl("txtOMRCode") as TextBox).Text;
                    //string PracticalMarks = (row.Cells[5].FindControl("txtPracticalMarks") as TextBox).Text;
                    string PracticalMarks = (row.Cells[5].FindControl("txtPracticalMarks") as TextBox).Text;
                    DropDownList ddlpresentabsent = (DropDownList)row.Cells[4].FindControl("ddlpresentabsent");

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
                    if (ddlEntryType.SelectedValue.ToString() == "P" && ddlpresentabsent.SelectedValue == "P")
                    {
                        if (ddlEntryType.SelectedValue.ToString() == "P" && PracticalMarks == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Practical marks of all checked data is required');", true);
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

        //if (ddlEntryType.SelectedValue.ToString() == "P" && ddlexaminer.SelectedValue=="0")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select Examiner');", true);
        //    ddlTradeName.Focus();
        //    return false;
        //}

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
    protected void ddlEntryType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEntryType.SelectedValue.ToString() == "O")
        {
            tr1.Visible = true;
            tr2.Visible = true;
            trInt.Visible = false;
            trIntAdd.Visible = false;
            trIntPost.Visible = false;
            //trInt1.Visible = false;
            trInt2.Visible = false;
            trexaminerDDl.Visible = false;
        }
        else
        {
            ddlPaper.SelectedIndex = -1;
            tr1.Visible = false;
            tr2.Visible = false;
            trInt.Visible = false;
            trIntAdd.Visible = false;
            trIntPost.Visible = false;
            //trInt1.Visible = true;
            trInt2.Visible = false;
            trexaminerDDl.Visible = true;
        }
        {
            try
            {
                if (isvalidate())
                {
                    //dsgetData = MySql.GetDataSetWithQuery("Exec Sp_BindGridinCenter_ForReport " + Convert.ToInt32(ddlSession.SelectedValue) + ",'" + Convert.ToString(ddlNameofITI.SelectedValue) + "'," + Convert.ToInt32(ddlSemester.SelectedValue) + ",'" + Convert.ToString(ddlTradeName.SelectedValue) + "'," + Convert.ToInt32(ddlPaper.SelectedValue) + ",'" + Convert.ToString(ddlEntryType.SelectedValue) + "'");
                    //if (dsgetData.Tables[0].Rows.Count > 0)
                    //{
                    //GridView1.DataSource = dsgetData;
                    //GridView1.DataBind();
                    //lblCMessage.Text = "<b>Total No. of Records -</b>" + dsgetData.Tables[0].Rows.Count;
                    //btnSave.Visible = false;
                    //btnPrint.Visible = true;
                    //btnPrint.Enabled = true;
                    //hiddenExaminerid.Value = dsgetData.Tables[0].Rows[0]["ExaminerId"].ToString();
                    DataSet ds = new DataSet();
                    ds = MySql.GetDataSetWithQuery("Exec BindExaminerDropDown " + Convert.ToInt32(ddlSession.SelectedValue) + ",'" + Convert.ToString(ddlNameofITI.SelectedValue) + "'," + Convert.ToInt32(ddlSemester.SelectedValue) + ",'" + Convert.ToString(ddlTradeName.SelectedValue) + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlexaminer.DataSource = ds;
                        ddlexaminer.DataTextField = "ExternalName";
                        ddlexaminer.DataValueField = "ExaminerId";
                        ddlexaminer.DataBind();
                        ddlexaminer.Items.Insert(0, new ListItem("Select Examiner", "0"));
                    }
                    else
                    {
                        ddlexaminer.DataSource = null;
                    }



                    //}
                    //else
                    //{
                    //    GridView1.DataSource = null;
                    //    GridView1.DataBind();
                    //    lblCMessage.Text = "<b>Records Not Found</b>";
                    //    btnSave.Visible = false;
                    //    btnPrint.Enabled = false;
                    //}
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }
    }
    protected void ddlpresentabsent_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        int iRow = ((GridViewRow)(ddl.Parent.BindingContainer)).RowIndex;
        if (GridView1.Rows.Count > 0)
        {
            DropDownList ddlpresentabsent = (DropDownList)GridView1.Rows[iRow].Cells[5].FindControl("ddlpresentabsent");
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

        dbcom.Parameters["@IntName"].Value = txtIntName.Text.ToString();
        dbcom.Parameters["@IntAdd"].Value = txtIntAdd.Text.ToString();
        dbcom.Parameters["@IntPost"].Value = txtIntPost.Text.ToString();
        dbcom.Parameters["@ExName"].Value = txtExName.Text.ToString();
        dbcom.Parameters["@ExAdd"].Value = txtExAdd.Text.ToString();
        dbcom.Parameters["@ExPost"].Value = txtExPost.Text.ToString();

        dbcom.Parameters.AddWithValue("@ExaninerId", 0);
        dbcom.Parameters["@ExaninerId"].Direction = ParameterDirection.Output;
        dbcom.ExecuteNonQuery();
        return (int)dbcom.Parameters["@ExaninerId"].Value;
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

            Session["rptExaminerId"] = hiddenExaminerid.Value;

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