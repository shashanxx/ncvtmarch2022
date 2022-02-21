using Common.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Principle_AdmitCardEd : System.Web.UI.Page
{
    CommonPerception Mysql = new CommonPerception();
    DataTable dtgrid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
            Response.Redirect("../Login/LoginNew.aspx");

        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                InsertAdmitCardDownloadStatus(Convert.ToInt32(Request.QueryString["id"].ToString()));
                BindStudentDetails(Convert.ToInt32(Request.QueryString["id"].ToString()));
            }
        }
    }
    private void BindStudentDetails(int id)
    {
        dtgrid = new DataTable();
        dtgrid = Mysql.GetDataTableWithQuery("exec GetStudentDetailsForAdmitCardEd @id=" + id + "");
        if (dtgrid != null && dtgrid.Rows.Count > 0)
        {
            lblName.Text = dtgrid.Rows[0]["Name"].ToString();
            lblFatherName.Text = dtgrid.Rows[0]["FatherName"].ToString();
            lblITICode.Text = dtgrid.Rows[0]["ITICode"].ToString();
            lblIITName.Text = dtgrid.Rows[0]["ITIName"].ToString();
            lblGender.Text = dtgrid.Rows[0]["gender"].ToString();
            lblSemester.Text = dtgrid.Rows[0]["Semester"].ToString();
            lblTrade.Text = dtgrid.Rows[0]["Trade"].ToString();
            lblRollNumber.Text = dtgrid.Rows[0]["RollNumber"].ToString();
            lblDOB.Text = dtgrid.Rows[0]["DOB"].ToString();

            if (Convert.ToInt32(dtgrid.Rows[0]["admissionyear"]) > 2017)
            {
                lblAnnualOrSemester.Text = "Annual";
            }
            else
            {
                lblAnnualOrSemester.Text = "Semester";
            }

            if (dtgrid.Rows.Count >= 2)
            {
                if (Convert.ToInt32(dtgrid.Rows[0]["admissionyear"]) > 2017)
                {
                    if (dtgrid.Rows[1]["remarks"].ToString() == "1")
                        lblCentre.Text = dtgrid.Rows[1]["CentreName"].ToString();
                    else if (dtgrid.Rows[0]["remarks"].ToString() == "1")
                        lblCentre.Text = dtgrid.Rows[0]["CentreName"].ToString();
                    else if(dtgrid.Rows[0]["remarks"].ToString() == "0" && dtgrid.Rows[1]["remarks"].ToString() == "0")
                    {
                        if (dtgrid.Rows[0]["ITICode"].ToString() == "PR23000912" || dtgrid.Rows[0]["ITICode"].ToString() == "PU23001015" || dtgrid.Rows[0]["ITICode"].ToString() == "PU23001110")
                        {
                            if (dtgrid.Rows[1]["TradeMapping"].ToString() == "ELECTRICIAN")
                            {
                                lblCentre.Text = dtgrid.Rows[1]["CentreName"].ToString();
                            }
                            else if (dtgrid.Rows[0]["TradeMapping"].ToString() == "ELECTRICIAN")
                            {
                                lblCentre.Text = dtgrid.Rows[0]["CentreName"].ToString();
                            }
                            else
                            {
                                lblCentre.Text = dtgrid.Rows[0]["CentreName"].ToString();
                            }
                        }
                        else
                        {
                            lblCentre.Text = dtgrid.Rows[0]["CentreName"].ToString();
                        }
                    }
                }
                else
                {
                    if (dtgrid.Rows[1]["remarks"].ToString() == "0")
                        lblCentre.Text = dtgrid.Rows[1]["CentreName"].ToString();
                    else if (dtgrid.Rows[0]["remarks"].ToString() == "0")
                        lblCentre.Text = dtgrid.Rows[0]["CentreName"].ToString();
                    else if (dtgrid.Rows[0]["remarks"].ToString() == "0" && dtgrid.Rows[1]["remarks"].ToString() == "0")
                    {
                        if (dtgrid.Rows[0]["ITICode"].ToString() == "PR23000912")
                        {
                            if (dtgrid.Rows[1]["TradeMapping"].ToString() == "ELECTRICIAN")
                            {
                                lblCentre.Text = dtgrid.Rows[1]["CentreName"].ToString();
                            }
                            else if (dtgrid.Rows[0]["TradeMapping"].ToString() == "ELECTRICIAN")
                            {
                                lblCentre.Text = dtgrid.Rows[0]["CentreName"].ToString();
                            }
                            else
                            {
                                lblCentre.Text = dtgrid.Rows[0]["CentreName"].ToString();
                            }
                        }
                        else
                        {
                            lblCentre.Text = dtgrid.Rows[0]["CentreName"].ToString();
                        }
                    }
                }
            }
            else
            {
                lblCentre.Text = dtgrid.Rows[0]["CentreName"].ToString();
            }
            //lblPaper1Date.Text = dtgrid.Rows[0]["PracticalExamDate"].ToString();
            lblExamtime.Text = dtgrid.Rows[0]["examtime"].ToString();
            //lblPaper1Name.Text = dtgrid.Rows[0]["Paper1Name"].ToString();
            //lblPaper2Date.Text = dtgrid.Rows[0]["Paper2Date"].ToString();
            //lblPaper2Name.Text = dtgrid.Rows[0]["Paper2Name"].ToString();
            //lblPaper1Time.Text = dtgrid.Rows[0]["Paper1Time"].ToString();
            //lblPaper2Time.Text = dtgrid.Rows[0]["Paper2Time"].ToString();
            //lblDate1.Text = dtgrid.Rows[0]["Paper1Date"].ToString();
            //lblDate2.Text = dtgrid.Rows[0]["Paper2Date"].ToString();
        }
        else
        {

        }
    }

    private void InsertAdmitCardDownloadStatus(int ID)
    {
        Mysql.ExecuteNonQuery("InsertAdmitCardDownloadStatus @ID=" + ID + "");
    }
}