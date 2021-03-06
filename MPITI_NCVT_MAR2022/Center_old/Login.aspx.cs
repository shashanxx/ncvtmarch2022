using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Class;
using System.Data;
using System.Data.SqlClient;

public partial class Center_Login : ClsErrorLog
{
    CommonPerception MySql = new CommonPerception();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet Ds = new DataSet();

            if (txtLoginID.Text.ToString() != "")
            {
                if (txtPassword.Text != "")
                {
                    Ds = MySql.GetDataSetWithQuery("Exec sp_CheckLogin '" + txtLoginID.Text.ToString() + "','" + txtPassword.Text.ToString() + "'");
                    if (Ds.Tables[0].Rows.Count > 0)
                    {
                        //-------Center Login
                        if (Convert.ToString(Ds.Tables[0].Rows[0]["Role"]) == "Center")
                        {
                            if (Convert.ToString(txtLoginID.Text) == Convert.ToString(Ds.Tables[0].Rows[0]["LoginID"]) && Convert.ToString(txtPassword.Text) == Convert.ToString(Ds.Tables[0].Rows[0]["Password"]))
                            {
                                Session["centerlogin"] = "centerlogin";
                                Session["CenterITICode"] = Convert.ToString(Ds.Tables[0].Rows[0]["LoginID"]);
                                Session["MobileNo"] = Convert.ToString(Ds.Tables[0].Rows[0]["MobileNo"]);

                                Response.Redirect("OTPPage.aspx");
                                //Response.Redirect("ExamCenter.aspx");
                            }
                            else
                            {
                                lblError.Text = "Invalid Login Details";
                            }
                        }

                        //-------JD Login
                        if (Convert.ToString(Ds.Tables[0].Rows[0]["Role"]) == "JD")
                        {
                            if (Convert.ToString(txtLoginID.Text) == Convert.ToString(Ds.Tables[0].Rows[0]["LoginID"]) && Convert.ToString(txtPassword.Text) == Convert.ToString(Ds.Tables[0].Rows[0]["Password"]))
                            {
                                Session["centerlogin"] = "JD";
                                Session["Zone"] = Ds.Tables[0].Rows[0]["Zone"];
                                Session["LoginId"]=Convert.ToString(Ds.Tables[0].Rows[0]["LoginID"]);
                                Session["MobileNo"] = Convert.ToString(Ds.Tables[0].Rows[0]["MobileNo"]);
                                Response.Redirect("OTPPage.aspx");
                                //Response.Redirect("Joindirector.aspx");
                            }
                            else
                            {
                                lblError.Text = "Invalid Login Details";
                            }
                        }
                        if (Convert.ToString(Ds.Tables[0].Rows[0]["Role"]) == "Admin")
                        {
                            Session["Login"] = "Admin";
                            Response.Redirect("../Admin/CenterAdminReport.aspx");
                        }
                        //if (Convert.ToString(Ds.Tables[0].Rows[0]["Role"]) == "JDAdmin")
                        //{
                        //    Session["Login"] = "JDAdmin";
                        //    Response.Redirect("../Admin/JoinDirectorAdminReports.aspx");
                        //}
                    }
                    else
                    {
                        lblError.Text = "Invalid Login Details";
                    }                    
                }
                else
                {
                    lblError.Text = "Please enter Password";
                }
            }
            else
            {
                lblError.Text = "Please enter Login ID";
            }

        }
        catch (Exception ex)
        {
            LogError(ex);
        }
    }
}