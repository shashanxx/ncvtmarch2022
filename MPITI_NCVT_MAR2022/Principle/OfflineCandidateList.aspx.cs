using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Common.Class;

public partial class Home_CandidateList : System.Web.UI.Page
{
    CommonPerception Mysql = new CommonPerception();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
            Response.Redirect("../Login/LoginNew.aspx");
        else
        {
            lblUName.Text = "Welcome " + Convert.ToString(Session["Username"]);
            fillCandidateList();
        }
    }

    private void fillCandidateList()
    {
        DataSet ds = new DataSet();
        ds = Mysql.GetDataSetWithQuery("select a.*,b.TradeName,(case when ISNUMERIC(a.PaymentRefNo)=1 then '-' when c.PaymentStatus Is null then 'Enter correct Order No' when c.PaymentStatus='N' then 'Payment failure' when c.PaymentStatus='Y' then 'Payment successful' else '' end) as 'OfflinePaymentStatus',(case when c.PaymentStatus='Y' then CONVERT(varchar(20),Total_Amount) else '-' end) as 'OfflineTranAmount' from tb_StudentOfflineDet a left join TradeMaster b on a.Trade=b.Tradeid left join tbOrder_Details c on a.PaymentRefNo=c.Order_no where ITICode='" + Convert.ToString(Session["Username"]) + "' order by id desc");
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl1.Visible = true;
            grd_candidate.DataSource = ds;
            grd_candidate.DataBind();
        }

        DataSet ds2 = new DataSet();
        ds2 = Mysql.GetDataSetWithQuery("select Order_no,total_amount,trans_msg,created_date,case when paymentstatus='Y' then 'Success' else 'Fail' end paymentstatus from tbOrder_Details where RegistrationId='" + Convert.ToString(Session["Username"]) + "' order by order_id desc");
        if (ds2.Tables[0].Rows.Count > 0)
        {
            lbl2.Visible = true;
            grd_payment.DataSource = ds2;
            grd_payment.DataBind();
        }
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Session["ID"] = null;
        Response.Redirect("OfflineEntryForm.aspx");
    }

    protected void grd_candidate_RowEditing(object sender, GridViewEditEventArgs e)
    {

        try
        {
            GridViewRow row = grd_candidate.Rows[e.NewEditIndex];
            string ID = Convert.ToString(grd_candidate.DataKeys[e.NewEditIndex].Values[0]);
            Session["ID"] = ID;
            Response.Redirect("OfflineEntryForm.aspx");
        }

        catch (Exception)
        {

            throw;

        }

    }

    protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        
    } 
}