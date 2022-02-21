using Common.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddUser : System.Web.UI.Page
{
    CommonPerception Mysql = new CommonPerception();
    protected void Page_Load(object sender, EventArgs e)
    {
        string UserName = Convert.ToString(Session["Username"]);
        if (UserName != "Operation")
        {
            Response.Redirect("../Login/LoginNew.aspx");
        }

        if (!IsPostBack)
        {
            BindGridView();
        }
    }

    private void BindGridView()
    {
        DataSet ds = Mysql.GetDataSet("Select UT.UserID, UT.UserName, Password, MobileNo, UT.UserType,  ITIName,  Division,  District from tbl_User UT Inner join tbl_User_Profile UP on UT.UserName = UP.Name  where UT.usertype in (2,6) order by UT.UserName");
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                gvData.DataSource = ds.Tables[0];
                gvData.DataBind();
            }
        }
    }

    [WebMethod]
    public static int CheckUserName(string UserName)
    {
        SqlCommand dbcom;
        SqlConnection dbcon;
        int Count = 1;
        dbcon = new SqlConnection(CommonPerception.ConnectionString());
        try
        {
            dbcon.Open();
            dbcom = new SqlCommand("Select Count(*) from tbl_user  where Username = '" + UserName + "'", dbcon);
            Count = (int)dbcom.ExecuteScalar();
            dbcon.Close();
        }
        catch (Exception err)
        {
            Count = 1;
        }

        finally
        {
            if (dbcon.State == ConnectionState.Open)
            {
                dbcon.Close();
            }
        }
        return Count;
    }


    protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvData.EditIndex = e.NewEditIndex;
        this.BindGridView();
    }
    protected void gvData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvData.EditIndex = -1;
        this.BindGridView();
    }
    protected void gvData_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = gvData.Rows[e.RowIndex];
        int UserID = Convert.ToInt32(gvData.DataKeys[e.RowIndex].Values[0]);
        string Name = (row.FindControl("txtName") as TextBox).Text;
        string MobileNo = (row.FindControl("txtMobileNo") as TextBox).Text;
        string Password = (row.FindControl("txtPassword") as TextBox).Text;
        string Division = (row.FindControl("txtDivision") as TextBox).Text;
        string District = (row.FindControl("txtDistrict") as TextBox).Text;
        string ITIName = (row.FindControl("txtITIName") as TextBox).Text;
        string UserType = (row.FindControl("ddlUserType") as DropDownList).SelectedValue;

        if (ITIName == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter ITIName.');", true);
            return;
        }
        if (Password == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter Password.');", true);
            return;
        }
        if (MobileNo == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter Mobile No.');", true);
            return;
        }

        if (Division == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter Division.');", true);
            return;
        }
        if (District == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter District.');", true);
            return;
        }
        if (MobileNo.Length != 10)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter valid Mobile No.');", true);
            return;
        }

        int Saved = Convert.ToInt32(Mysql.ExecuteNonQuery("sp_UpdateUser '" + Name + "', '" + Password + "', '" + MobileNo + "', '" + UserType + "', '" + Division + "', '" + District + "','" + ITIName + "'"));
        if (Saved == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Unable to Save.');", true);
            return;
        }
        else
        {
            txtMobileNo.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtDivision.Text = "";
            txtDistrict.Text = "";
            txtItiName.Text = "";
            gvData.EditIndex = -1;
            this.BindGridView();
        }

    }
    protected void gvData_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Mysql.UpdateSingleLogin(Session["Username"].ToString(), Convert.ToInt32(Session["UserType"].ToString()), 0);
        Session.Abandon();
        Session.Clear();
        Response.Redirect("../Login/Logout.aspx");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string UserName = txtUserName.Text.Trim();
        string MobileNo = txtMobileNo.Text.Trim();
        string Password = txtPassword.Text.Trim();
        string UserType = ddlUserType.SelectedValue;
        string Division = txtDivision.Text.Trim();
        string District = txtDistrict.Text.Trim();
        string ItiName = txtItiName.Text.Trim();

        if (ItiName == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter ItiName.');", true);
            return;
        }

        if (UserName == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter UserName.');", true);
            return;
        }
        if (Password == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter Password.');", true);
            return;
        }
        if (Division == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter Division.');", true);
            return;
        }
        if (District == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter District.');", true);
            return;
        }
        if (MobileNo == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please enter Mobile No.');", true);
            return;
        }

        int Exists = Mysql.SingleCellResult("Select Count(*) from tbl_user  where Username = '" + UserName + "'");
        if (Exists > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('User Name already exists.');", true);
            return;
        }

        int Saved = Convert.ToInt32(Mysql.ExecuteNonQuery("sp_SaveUser '" + UserName + "', '" + Password + "', '" + MobileNo + "', '" + UserType + "', '" + Division + "', '" + District + "','" + ItiName + "'"));
        if (Saved == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Unable to Save.');", true);
            return;
        }
        else
        {
            txtMobileNo.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtDivision.Text = "";
            txtDistrict.Text = "";
            txtItiName.Text = "";
            BindGridView();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Saved.');", true);
            return;
        }
    }
}