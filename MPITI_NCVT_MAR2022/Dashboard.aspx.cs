using Common.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Principle_Dashboard : System.Web.UI.Page
{
    DataTable dt;
    CommonPerception Mysql = new CommonPerception();
    StringBuilder str = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
            Response.Redirect("Login/LoginNew.aspx");
        else
        {
            dt = Mysql.GetDataTableWithQuery("select distinct ITICode+'-'+ITIName itiname from tbl_Student where ITICode='" + Session["Username"].ToString() + "'");
            if (dt != null && dt.Rows.Count > 0)
                lblUName.Text = "Welcome " + Convert.ToString(dt.Rows[0]["itiname"]);
            else
                lblUName.Text = "Welcome " + Session["Username"].ToString();
        }
        //if (!IsPostBack)
        //{
            CheckLoginTime();
        //}

        dt = new DataTable();
        dt = Mysql.GetDataTableWithQuery("GetUserDashboard @UserType='" + Session["UserType"].ToString() + "'");
        if (dt != null && dt.Rows.Count > 0)
        {
            BindDashboard(dt);
        }
    }
    private void CheckLoginTime()
    {
        try
        {
            string UsrName = Mysql.SingleCellResultInString("exec CheckLoginTime @UserName='" + Session["Username"].ToString() + "',@UserType=" + Convert.ToInt32(Session["UserType"].ToString()) + ",@LoginDate='" + Session["LoginTime"].ToString() + "'");
            //CommonUtilities.LogFileWrite("exec CheckLoginTime @UserName='" + Session["Username"].ToString() + "',@UserType=" + Convert.ToInt32(Session["UserType"].ToString()) + ",@LoginDate='" + Session["LoginTime"].ToString() + "'");
            if (string.IsNullOrEmpty(UsrName))
            {
                //CommonUtilities.LogFileWrite("Empty Records redirect to logout:" + UsrName);
                Session.Abandon();
                Session.Clear();
                Response.Redirect("Login/LogOut.aspx");
            }
        }
        catch (Exception ex1)
        {
            CommonUtilities.LogError(ex1);
        }
    }
    private void BindDashboard(DataTable dtdash)
    {
        string UserId = Convert.ToString(Session["UserID"]);
        if (dtdash != null && dtdash.Rows.Count > 0)
        {
            for (int i = 0; i < dtdash.Rows.Count; i++)
            {
                if (Session["UserType"].ToString() == "2" && (dtdash.Rows[i]["URL"].ToString() == "Principle/PracticalMarksEntryForm.aspx" || dtdash.Rows[i]["URL"].ToString() == "Principle/DirectPracticalMarksEntry.aspx"))
                {
                    int ItiCount = 0;
                    DataTable dt = new DataTable();
                    dt = Mysql.GetDataTableWithQuery("select COUNT(*) from [tbl_SuperITIMapping] where SuperITIID='" + UserId + "'");
                    if (Convert.ToInt16(dt.Rows[0][0]) > 0)
                        str.Append("<div class='icon_box'><div class='div_img_style'><img src='" + dtdash.Rows[i]["ImageURL"].ToString() + "' class='imgstyle' /></div><div class='data'><h1><a id='HyperLink" + i + "' href=" + dtdash.Rows[i]["URL"].ToString() + ">" + dtdash.Rows[i]["NAME"].ToString() + "</a></h1><p>" + dtdash.Rows[i]["NameDesc"].ToString() + "</p></div></div>");
                }
                else if (Session["UserType"].ToString() == "2" && (dtdash.Rows[i]["URL"].ToString() == "Principle/DownloadMarkEntryReport.aspx"))
                {
                    DataTable dt = new DataTable();
                    dt = Mysql.GetDataTableWithQuery("select COUNT(*) from [tbl_misportalNodalMapping] where NODALITICODEASPERNCVTMISPORTAL='" + Session["Username"].ToString() + "'");
                    if (Convert.ToInt16(dt.Rows[0][0]) > 0)
                        str.Append("<div class='icon_box'><div class='div_img_style'><img src='" + dtdash.Rows[i]["ImageURL"].ToString() + "' class='imgstyle' /></div><div class='data'><h1><a id='HyperLink" + i + "' href=" + dtdash.Rows[i]["URL"].ToString() + ">" + dtdash.Rows[i]["NAME"].ToString() + "</a></h1><p>" + dtdash.Rows[i]["NameDesc"].ToString() + "</p></div></div>");
                }
                else
                {
                    str.Append("<div class='icon_box'><div class='div_img_style'><img src='" + dtdash.Rows[i]["ImageURL"].ToString() + "' class='imgstyle' /></div><div class='data'><h1><a id='HyperLink" + i + "' href=" + dtdash.Rows[i]["URL"].ToString() + ">" + dtdash.Rows[i]["NAME"].ToString() + "</a></h1><p>" + dtdash.Rows[i]["NameDesc"].ToString() + "</p></div></div>");
                }               

            }
            userdashboard.InnerHtml = str.ToString();
        }
    }
    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Mysql.UpdateSingleLogin(Session["Username"].ToString(), Convert.ToInt32(Session["UserType"].ToString()), 0);
        Session.Abandon();
        Session.Clear();
        Response.Redirect("Login/LogOut.aspx");
    }
}