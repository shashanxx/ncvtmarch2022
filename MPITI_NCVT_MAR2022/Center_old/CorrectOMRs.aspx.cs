using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Class;
using System.Data;
using System.Data.SqlClient;

public partial class Center_CorrectOMRs : ClsErrorLog
{
    CommonPerception MySql = new CommonPerception();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
      //  Session["CenterITICode"] = "GR23000004";
        if (!IsPostBack)
        {
            if (Session["CenterITICode"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            HiddenField1.Value = Session["CenterITICode"].ToString();
            ds = MySql.GetDataSetWithQuery("select ITIName, ITICode from ITImaster where CenterITICode='" + HiddenField1.Value + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddliti.DataSource = ds;
                ddliti.DataTextField = "ITIName";
                ddliti.DataValueField = "ITICode";
                ddliti.DataBind();
                ddliti.Items.Insert(0, new ListItem("Select ITI Name", "0"));
            }
        }
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
    protected void txtOMRCode_TextChanged(object sender, EventArgs e)
    {
        GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
        TextBox txt = (TextBox)currentRow.FindControl("txtOMRCode");

        //if (IsOMRExists(txt.Text.Trim()))
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('OMR you have entered is already exists');", true);
        //    txt.Text = "";
        //}
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddliti.SelectedValue.ToString() != "0")
            {

                ds = MySql.GetDataSetWithQuery("Exec sp_Correction_search @ITICode='" + HiddenField1.Value + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    lblCMessage.Text = "<b>Total No. of Records -</b>" + ds.Tables[0].Rows.Count;

                 btnSave.Visible = true;
                
                   
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

                }
            }
            else
            {
                lblCMessage.Text = "Please select ITI Name.";
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
       
            
        }
        //OMR Grid
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtOMRCode = (e.Row.FindControl("txtOMRCode") as TextBox);
       

            DropDownList ddlpresentabsent = (e.Row.FindControl("ddlpresentabsent") as DropDownList);
            string presentabsent = (e.Row.FindControl("lblpresentabsent") as Label).Text;
            ddlpresentabsent.Items.FindByValue(presentabsent).Selected = true;

            DropDownList ddlsessionme = (e.Row.FindControl("ddlsessionme") as DropDownList);
            string sessionme = (e.Row.FindControl("lblsessionme") as Label).Text;
            ddlsessionme.Items.FindByValue(sessionme).Selected = true;

            txtOMRCode.Visible = true;
              
            //Added
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                    ddlpresentabsent.Visible = true;
                    txtOMRCode.Visible = true;
         
            }
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row1 in GridView1.Rows)
        {
            if (row1.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row1.Cells[0].FindControl("checkCan") as CheckBox);
                if (chkRow.Checked)
                {
                   // CheckedCount = CheckedCount + 1;

                    string tradecodeentered = "";
                    string sessionme = "";
                    string dateofexam = "";
                    string OMRCode = "";
                    string Papertype = "";
                    Papertype = ((row1.Cells[9].FindControl("ddlpprtype") as DropDownList).Text);
                    tradecodeentered = ((row1.Cells[4].FindControl("lbltradecode") as Label).Text);
                    sessionme = ((row1.Cells[8].FindControl("lblsessionme") as Label).Text);
                    dateofexam = ((row1.Cells[7].FindControl("txtDOExam") as Label).Text);
                    OMRCode = ((row1.Cells[6].FindControl("txtOMRCode") as Label).Text);
                     string Presentabsent = ((row1.Cells[5].FindControl("lblpresentabsent") as Label).Text);
                    int TraineeId = Convert.ToInt32((row1.Cells[10].FindControl("lblTraineeID") as Label).Text);
                   // string ExaminerId = ((row1.Cells[11].FindControl("lblexaminerid") as Label).Text);
                    string RollNo = row1.Cells[1].Text;
                   
                
                
                    //PracticalMarks = PracticalMarks == "" ? "0" : PracticalMarks;
                    if (Papertype != "0")
                    {


                        string ins = "";
                        if (Papertype == "1")
                        {
                            ins = "exec SP_CorrectAffectedRecords  @TraineeId=" + TraineeId + " ,@RollNo='" + RollNo + "', @Papertype='" + Papertype + "'";
                        }
                        else if (Papertype == "2")
                        {
                            ins = "exec SP_CorrectAffectedRecords  @TraineeId=" + TraineeId + " ,@RollNo='" + RollNo + "', @Paper2='" + OMRCode + "', @Presentabsent1='" + Presentabsent + "', @TradeCode1='" + tradecodeentered + "', @DateOfExam1='" + dateofexam + "', @Session1='" + sessionme + "', @Papertype='" + Papertype + "'";
                            // ins = "exec SP_Insert_OMRDetails1Test  @TraineeId=" + TraineeId + " ,@RollNo='" + RollNo + "', @Paper2='" + OMRCode + "',@EntryType='" + ddlEntryType.SelectedValue.ToString() + "',  @Presentabsent1='" + Presentabsent + "', @TradeCode1='" + tradecodeentered + "', @DateOfExam1='" + dateofexam + "', @ExaminerId='" + ExaminerId + "', @Session1='" + sessionme + "', @PaperType=" + ddlPaper.SelectedValue + "";
                        }



                        //  string ins = "exec SP_Insert_OMRDetails1Test @TraineeId=" + TraineeId + " ,@RollNo='" + RollNo + "' ,@OMR='" + OMRCode + "',@PracticalMarks=" + PracticalMarks + ",@EntryType='" + ddlEntryType.SelectedValue.ToString() + "', @ExaminerId='" + ExaminerId + "',  @TradeCode='" + tradecodeentered + "', @Session='" + sessionme + "', @DateOfExam='" + dateofexam + "', @PresentAb='" + Presentabsent + "'";
                        // SP_Insert_OMRDetails12
                        bool result = MySql.ExecuteNonQuery(ins);
                        if (result == true)
                        {
                            lblCMessage.Text = "Records Updated successfully.";
                        }
                        else
                        {
                            lblCMessage.Text = "Records not Updated.";
                            return;
                        }
                    }
                    else
                    {
                        lblCMessage.Text = "Select Paper type";
                        return;
                    }
                }
                else
                {
                    lblCMessage.Text = "Select atleast one record for update";
                    return;
                }
               
            }
        }
    }
}