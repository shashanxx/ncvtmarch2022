using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Class;
using System.Data;
using System.Data.SqlClient;
public partial class Center_UpdateJoinDirectorMarks : System.Web.UI.Page
{
    ClsErrorLog errlog = new ClsErrorLog();
    CommonPerception MySql = new CommonPerception();
    DataSet ds = new DataSet();
    string tradetype = "";
    string tradetype1 = "";
    bool Hiddenvalue;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["centerlogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            btnsave.Visible = false;
            BindSessionName();
            // BindNameOfITI();
            BindSemesterMaster();
      
           // BindPaperMaster();
            BindDistrict(Convert.ToString(Session["Zone"]));
            // BindDuration();
            // BindSlot();
            hiddenloginid.Value = Session["LoginId"].ToString();
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
    protected void BindDistrict(string Zone)
    {
        if (Session["Zone"] != null)
        {


            ddldistrict.Items.Clear();
            DataSet Ds = new DataSet();
            Ds = MySql.GetDataSetWithQuery("Exec sp_getDistrict @Zone='" + Convert.ToString(Session["Zone"]) + "' ");
            if (Ds.Tables[0].Rows.Count > 0)
            {
                ddldistrict.DataSource = Ds;
                ddldistrict.DataTextField = "District";
                ddldistrict.DataValueField = "DisId";
                ddldistrict.DataBind();
                ddldistrict.Items.Insert(0, new ListItem("Select District", "0"));
            }
        }
    }

    protected void BindNameOfITI(string session, string District)
    {
        ddlNameofITI.Items.Clear();
        DataSet Ds = new DataSet();
        Ds = MySql.GetDataSetWithQuery("Exec sp_getITIMasterJD @SessionID='" + session + "', @District='" + District + "'");
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

    protected void BindTradeName(string remarks, string Jd1)
    {
        ddlTradeName.Items.Clear();
        DataSet Ds = new DataSet();
        Ds = MySql.GetDataSetWithQuery("Exec sp_getTradeNameJD @Remark='" + remarks + "', @jd='" + Jd1 + "'");
        if (Ds.Tables[0].Rows.Count > 0)
        {
            ddlTradeName.DataSource = Ds;
            ddlTradeName.DataTextField = "TradeName";
            ddlTradeName.DataValueField = "TradeCode";
            ddlTradeName.DataBind();
            ddlTradeName.Items.Insert(0, new ListItem("Select Trade Name", "0"));
        }
    }

    //protected void BindPaperMaster()
    //{
    //    try
    //    {

    //        ddlPaper.Items.Clear();
    //        DataSet Ds = new DataSet();
    //        Ds = MySql.GetDataSetWithQuery("Exec sp_getPaperMaster");
    //        if (Ds.Tables[0].Rows.Count > 0)
    //        {
    //            ddlPaper.DataSource = Ds;
    //            ddlPaper.DataTextField = "Paper";
    //            ddlPaper.DataValueField = "ID";
    //            ddlPaper.DataBind();
    //            ddlPaper.Items.Insert(0, new ListItem("Select Paper", "0"));
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        errlog.LogError(ex);
    //    }

    //}

    //protected void BindDuration()
    //{
    //    ddlDuration.Items.Clear();
    //    DataSet Ds = new DataSet();
    //    Ds = MySql.GetDataSetWithQuery("Exec sp_getDurationmaster");
    //    if (Ds.Tables[0].Rows.Count > 0)
    //    {
    //        ddlDuration.DataSource = Ds;
    //        ddlDuration.DataTextField = "Duration";
    //        ddlDuration.DataValueField = "ID";
    //        ddlDuration.DataBind();
    //        ddlDuration.Items.Insert(0, new ListItem("Select Duration", "0"));
    //    }
    //}

    //protected void BindSlot()
    //{
    //    ddlSlot.Items.Clear();
    //    DataSet Ds = new DataSet();
    //    Ds = MySql.GetDataSetWithQuery("Exec sp_getSlotmaster");
    //    if (Ds.Tables[0].Rows.Count > 0)
    //    {
    //        ddlSlot.DataSource = Ds;
    //        ddlSlot.DataTextField = "Slot";
    //        ddlSlot.DataValueField = "ID";
    //        ddlSlot.DataBind();
    //        ddlSlot.Items.Insert(0, new ListItem("Select Slot", "0"));
    //    }
    //}

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
            errlog.LogError(ex);
        }

    }
    void Fillgrid()
    {
        string session = ddlSession.SelectedValue.ToString();
        string ITICode = ddlNameofITI.SelectedValue.ToString();
        string semester = ddlSemester.SelectedValue.ToString();
        string Tradecode = ddlTradeName.SelectedValue.ToString();
       // string Papertype = ddlPaper.SelectedValue.ToString();

        string Actioncase = "";
        //Edited on 30july16
        if (ddlentrytype.SelectedValue.ToString() == "ED" && ddlSemester.SelectedValue.ToString() == "4")
        {
            Actioncase = "caseEDSem4";
        }
        else if (ddlentrytype.SelectedValue.ToString() == "ED" && ddlSemester.SelectedValue.ToString() != "4")
        {
            Actioncase = "caseEDSemOthers";
        }
        else if (ddlentrytype.SelectedValue.ToString() == "TT" && ddlSemester.SelectedValue.ToString() == "4")
        {
            Actioncase = "caseTTSem4";
        }
        else if (ddlentrytype.SelectedValue.ToString() == "TT" && ddlSemester.SelectedValue.ToString() != "4")
        {
            Actioncase = "caseTTSemOthers";
        }
        DataSet Ds = new DataSet();
        if (txtrollno.Text.Trim() == "")
        {
            Ds = MySql.GetDataSetWithQuery("Exec BindGridinJDForUpdate1 @Actioncase ='" + Actioncase + "' , @session='" + session + "', @ITICode='" + ITICode + "', @Semester='" + semester + "', @TradeCode='" + Tradecode + "'");
        }
        else
        {
            Ds = MySql.GetDataSetWithQuery("Exec BindGridinJDForUpdate1 @Actioncase ='" + Actioncase + "' , @session= '" + session + "', @ITICode='" + ITICode + "', @Semester='" + semester + "', @TradeCode='" + Tradecode + "', @RollNo= '" + txtrollno.Text.Trim() + "'");
        }
        if (Ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = Ds;
            GridView1.DataBind();
            lblCMessage.Text = "<b>Total No. of Records -</b>" + Ds.Tables[0].Rows.Count;
            tradetype = "select JD from Tradecodemaster where TradeCode='" + Tradecode + "'";

            HiddenField1.Value = MySql.SingleCellResultInString(tradetype);

            Hiddenvalue = Convert.ToBoolean(HiddenField1.Value);
            btnsave.Visible = true;
            lblCMessage.Text = "";
        }

        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            btnsave.Visible = false;
            lblCMessage.Text = "No data found";
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
            Response.Redirect("Login.aspx");
        }
        catch (Exception ex)
        {
            errlog.LogError(ex);
        }

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        //// string Rollno = "";
        // string Rollno = GridView1.Rows[0].Cells[0].ToString();
        // int rl=Convert.ToInt32(Rollno);
        // int rowcount=GridView1.Rows.Count;

        // TextBox txtpractmarks = (TextBox)GridView1.FindControl("txtpractmarks");
        // TextBox txtedmarks = (TextBox)GridView1.FindControl("txtedmarks");




        // for (int i = 0; i < rowcount; i++)
        // {
        //    // foreach (GridView gvrow in GridView1.Rows[1].Cells)
        //     foreach ()
        //     {
        //         string q = "insert into tbl_MarksDetails values ('" + Rollno + "','" + txtpractmarks.Text.ToString() + "', '" + txtedmarks.Text.ToString() + "', getdate())";
        //         MySql.ExecuteNonQuery(q);
        //     }

        // }

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
                            //int TraineeId = Convert.ToInt32(row1.Cells[7]);
                            int Id = Convert.ToInt32((row1.Cells[3].FindControl("lblID") as Label).Text);
                            string RollNo = row1.Cells[1].Text;
                            string practmarks = (row1.Cells[2].FindControl("txtpractmarks") as TextBox).Text;

                            if (Hiddenvalue == false)
                            {
                                tradetype1 = "ED";
                            }
                            else
                            {
                                tradetype1 = "TT";
                            }

                            string ins = "exec SP_Update_MarksDetailsJD  @Marks='" + practmarks + "' , @Id='" + Id + "'";
                            MySql.ExecuteNonQuery(ins);
                        }
                    }
                }
                if (CheckedCount > 0)
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    btnsave.Visible = false;
                    lblCMessage.Text = "Records updated successfully";
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
        //----Check all values entered of checked row
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("checkCan") as CheckBox);
                if (chkRow.Checked)
                {
                    string RollNo = row.Cells[1].Text;
                   // string practmarks = (row.Cells[2].FindControl("txtpractmarks") as TextBox).Text;
                    //  string edmarks = (row.Cells[3].FindControl("txtedmarks") as TextBox).Text;
                      string x = (row.Cells[2].FindControl("txtpractmarks") as TextBox).Text;
                      if (x == "")
                      {
                          ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Enter marks.');", true);
                          return false;
                      }
                      else if(x=="A")
                      {
                          string practmarks=(row.Cells[2].FindControl("txtpractmarks") as TextBox).Text;
                      }
                      else
                      {
                          double practmarks = Convert.ToDouble((row.Cells[2].FindControl("txtpractmarks") as TextBox).Text);
                          //  string edmarks = (row.Cells[3].FindControl("txtedmarks") as TextBox).Text;
                          if (practmarks > 0)
                          {


                              if (ddlentrytype.SelectedValue == "ED" && practmarks > 75)
                              {
                                  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('75 is maximum for ED marks.');", true);
                                  return false;
                              }
                              if (ddlentrytype.SelectedValue == "TT" && practmarks > 100)
                              {
                                  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('100 is maximum for Steno practical marks.');", true);
                                  return false;
                              }
                          }

                      }
                    //if (ddlTradeName.SelectedValue != "258" || ddlTradeName.SelectedValue != "259")
                    //{
                    //    if (practmarks.Trim() == "")
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
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Session');", true);
            ddlSession.Focus();
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
        //if (ddlPaper.SelectedValue == "0")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Select Paper');", true);
        //    ddlPaper.Focus();
        //    return false;
        //}
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

    protected void txtrollno_TextChanged(object sender, EventArgs e)
    {
        Fillgrid();
    }

    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (Convert.ToInt32(ddlSession.SelectedValue) > 0 && Convert.ToInt32(ddldistrict.SelectedValue) > 0)
        {
            BindNameOfITI(ddlSession.SelectedValue, ddldistrict.SelectedItem.Text);
        }
    }
    protected void btnchangepass_Click(object sender, EventArgs e)
    {
        Session["CenterITICode"] = hiddenloginid.Value;
        Response.Redirect("ChangePassword.aspx");
    }
    protected void btnlogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }
    protected void ddlentrytype_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblCMessage.Text = "";
        string Remark = "";
        string jd = "";
        if (ddlentrytype.SelectedValue.ToString() == "ED")
        {
            Remark = "ENGG DRAWING";
            jd = "0";
        }
        else if (ddlentrytype.SelectedValue.ToString() == "TT")
        {
            Remark = "No";
            jd = "1";
        }
        else
        {

        }
        BindTradeName(Remark, jd);
    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (ddlentrytype.SelectedValue.ToString() == "ED")
            {
                e.Row.Cells[2].Text = "ED Marks(75)";
                //  e.Row.Cells[7].Text = "Present/Absent";
                // e.Row.Cells[7].Visible = true;

            }
            else if (ddlentrytype.SelectedValue.ToString() == "TT")
            {
                //practical marks
                e.Row.Cells[2].Text = "Steno Practical Marks(out of 100)";
                // e.Row.Cells[6].Text = "Present/Absent";



            }
        }


    }
}