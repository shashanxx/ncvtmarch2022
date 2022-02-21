using Common.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login_LoginNew : System.Web.UI.Page
{
    DataTable dt;
    CommonPerception Mysql = new CommonPerception();
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["LoginTime"] = null;
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (IsValidate())
            {
                dt = new DataTable();
                dt = Mysql.GetDataTableWithQuery("CheckUserNamePwd @UserName='" + txtUserName.Text + "',@Password='" + txtPassword.Text + "'");
                if (dt != null && dt.Rows.Count > 0)
                {
                    //if (Convert.ToInt32(dt.Rows[0]["IsLoggedIn"].ToString()) == 1 && (DateTime.Now.Subtract(Convert.ToDateTime(dt.Rows[0]["LoginTime"].ToString())).TotalMinutes <= 10))
                    //{
                    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('You have already LoggedIn into the other machine or browser.');", true);
                    //}
                    //else
                    //{
                    Session["Username"] = dt.Rows[0]["UserName"].ToString();
                    Session["UserType"] = dt.Rows[0]["UserType"].ToString();
                    Session["UserTypeId"] = dt.Rows[0]["UserTypeId"].ToString();
                    //string usertype = dt.Rows[0]["UserType"].ToString();
                    //if (usertype == "1")
                    //    Session["UserTypeName"] = "Student";
                    //else if (usertype == "2")
                    //    Session["UserTypeName"] = "ITI";
                    //else if (usertype == "3")
                    //    Session["UserTypeName"] = "Admin";
                    //else if (usertype == "4")
                    //    Session["UserTypeName"] = "Accounts";
                    if (Convert.ToInt32(dt.Rows[0]["IsActive"].ToString()) == 1)
                    {
                        Response.Redirect("../Maintenance.aspx", false);
                    }
                    else if (Convert.ToInt32(dt.Rows[0]["ChangePasswordAttempt"].ToString()) == 0 && (Convert.ToInt32(dt.Rows[0]["UserType"].ToString()) == 2 || Convert.ToInt32(dt.Rows[0]["UserType"].ToString()) == 6))
                        Response.Redirect("../ChangePassword.aspx", false);
                    else
                    {
                        Mysql.UpdateSingleLogin(Session["Username"].ToString(), Convert.ToInt32(Session["UserType"].ToString()), 1);
                        Session["LoginTime"] = Mysql.SingleCellResultInString("exec GetLastLoginTime @UserName='" + Session["Username"].ToString() + "',@UserType=" + Convert.ToInt32(Session["UserType"].ToString()) + "");
                        Response.Redirect("../Dashboard.aspx", false);
                    }
                    //}
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Invalid UserName or Password');", true);
                }
            }
        }
        catch (Exception ex1)
        {
            CommonUtilities.LogError(ex1);
        }
    }
    bool IsValidate()
    {
        if (string.IsNullOrEmpty(txtUserName.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter Username');", true);
            txtUserName.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtPassword.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter Password');", true);
            txtPassword.Focus();
            return false;
        }
        else
            return true;
    }
}