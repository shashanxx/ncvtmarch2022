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
            fillPaymentList();
        }
    }

    private void fillPaymentList()
    {
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
        Response.Redirect("../PayCash/PayOffline.aspx?Username=" + Convert.ToString(Session["Username"]) + "");
    }

    

   
}