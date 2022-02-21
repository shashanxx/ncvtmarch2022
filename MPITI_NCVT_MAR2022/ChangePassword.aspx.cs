using Common.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword : System.Web.UI.Page
{
    CommonPerception Mysql = new CommonPerception();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
            Response.Redirect("Login/LoginNew.aspx");
        else
        {
            lblUName.Text = "Welcome " + Session["Username"].ToString();
            lblUserName.Text = Session["Username"].ToString();
        }
        if (this.IsPostBack)
        {
            if (lblCMessage.Text == "")
            {
                txtOldPassword.Attributes["value"] = txtOldPassword.Text;
                txtNewPassword.Attributes["value"] = txtNewPassword.Text;
                txtCNewPassword.Attributes["value"] = txtCNewPassword.Text;
            }
        }
    }
    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Response.Redirect("Login/LogOut.aspx");
    }
    //protected void btnExit_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("Dashboard.aspx");
    //}
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if(isvalidate())
        {
            string OldPassword = Mysql.SingleCellResultInString("CheckOldPassword @UserName='" + lblUserName.Text + "',@OldPassword='" + txtOldPassword.Text + "',@UserType=" + Session["UserType"].ToString() + "");
            if(!string.IsNullOrEmpty(OldPassword))
            {
                Regex regnewpass = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@#!%*?&])[A-Za-z\d$@#!%*?&]{8,13}");
                Match matchnewpass = regnewpass.Match(txtNewPassword.Text);
                if (!matchnewpass.Success)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('PASSWORD MUST BE 8 TO 13 CHARACTERS LONG, MUST HAVE AT LEAST 1 UPPERCASE ALPHABET, 1 LOWERCASE ALPHABET AND 1 NUMBER');", true);
                    txtNewPassword.Focus();
                }
                else
                {
                    bool affectrows = false;
                    affectrows = Mysql.ExecuteNonQuery("UpdatePassword @UserName='" + lblUserName.Text + "',@NewPassword='" + txtNewPassword.Text + "',@UserType=" + Session["UserType"].ToString() + "");
                    if(affectrows)
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('PASSWORD CHANGE SUCCESSFULLY'); window.location='" + Request.ApplicationPath + "Dashboard.aspx';", true);
                        lblCMessage.Text = "PASSWORD CHANGE SUCCESSFULLY";
                        txtOldPassword.Text = "";
                        txtNewPassword.Text = "";
                        txtCNewPassword.Text = "";
                        txtOldPassword.Attributes["value"] = "";
                        txtNewPassword.Attributes["value"] = "";
                        txtCNewPassword.Attributes["value"] = "";
                    }
                    else
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('SOME ISSUE ON UPDATE PASSWORD. PLEASE TRY AGAIN.');", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('PLEASE ENTER CORRECT OLD PASSWORD');", true);
                txtOldPassword.Focus();
            }
        }
    }
    bool isvalidate()
    {
        if (string.IsNullOrEmpty(txtOldPassword.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('PLEASE ENTER OLD PASSWORD');", true);
            txtOldPassword.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtNewPassword.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('PLEASE ENTER NEW PASSWORD');", true);
            txtNewPassword.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtCNewPassword.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('PLEASE ENTER CONFIRM PASSWORD');", true);
            txtCNewPassword.Focus();
            return false;
        }
        else if (txtNewPassword.Text != txtCNewPassword.Text)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('NEW PASSWORD AND CONFIRM PASSWORD DO NOT MATCH');", true);
            txtCNewPassword.Focus();
            return false;
        }
        else if (txtNewPassword.Text == txtOldPassword.Text)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('OLD PASSWORD AND NEW PASSWORD CAN NOT BE SAME');", true);
            txtNewPassword.Focus();
            return false;
        }
        else
            return true;
    }
    private void CheckPassword()
    {


    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login/LoginNew.aspx");
    }
}