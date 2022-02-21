using Common.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ActiveNDeactivatedMenus : System.Web.UI.Page
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
        DataSet ds = Mysql.GetDataSet("Select ID, Name, Case When IsActive = 0 then 'True' else 'False' END IsActive, CanAlterByOperation from [tbl_user_dashboard] where CanAlterByOperation = 1");
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                gvData.DataSource = ds.Tables[0];
                gvData.DataBind();
            }
        }
    }

    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Mysql.UpdateSingleLogin(Session["Username"].ToString(), Convert.ToInt32(Session["UserType"].ToString()), 0);
        Session.Abandon();
        Session.Clear();
        Response.Redirect("../Login/Logout.aspx");
    }
    protected void gvData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvData.EditIndex = e.NewEditIndex;
        this.BindGridView();
    }
    protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvData.EditIndex = -1;
        this.BindGridView();
    }
    protected void gvData_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int Action = 1;
        GridViewRow row = gvData.Rows[e.RowIndex];
        int Id = Convert.ToInt32(gvData.DataKeys[e.RowIndex].Values[0]);
        bool ChckStatusEdit = (row.FindControl("ChckStatusEdit") as CheckBox).Checked;
        if (ChckStatusEdit)
        {
            Action = 0;
        }

        bool bSaved = Convert.ToBoolean(Mysql.SingleCellResult("sp_ActiveNDeActivatedMenus '" + Id + "', '" + Action + "'"));
        if (bSaved)
        {
            gvData.EditIndex = -1;
            this.BindGridView();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Saved...');", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Unable to Save. Try Again...');", true);
        }

    }
    protected void gvData_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}