using System;
using System.Web.UI.WebControls;
using Common.Class;
using System.Data;
using System.Net;
using System.Threading;


public partial class Center_ForgotPassword : System.Web.UI.Page
{
    CommonPerception MySql = new CommonPerception();
    string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
    string numbers = "1234567890";
    string otp = string.Empty;
    string mobileNo = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblpasslbl.Visible = false;
            //bindPassRecoveryQue();
        }

    }
    protected void btnlogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Login/LoginNew.aspx");
    }


    protected void btnshowpass_Click(object sender, EventArgs e)
    {
        if(string.IsNullOrEmpty(txtpwd.Text.ToString()) || string.IsNullOrEmpty(txtotp.Text.ToString()) || string.IsNullOrEmpty(txtloginid.Text.ToString())){
            lblpass.Text = "Please fill all details";
            return;
        }
        if (Session["Otp"].ToString() == null)
        {
            lblpass.Text = "Please generate otp";
            return;
        }
        if (txtotp.Text.ToString() == Session["Otp"].ToString())
        {
            bool updatedata;
            updatedata = MySql.ExecuteNonQuery("update tbl_user set password='" + txtpwd.Text.ToString()+ "'  where userName='" + txtloginid.Text.ToString() + "'");
            if (updatedata)
            {
                lblpass.Text = "Password successufully changed";
                return;
            }
            else
            {
                lblpass.Text = "failed to changed Password";
                return;
            }
        }        
    }
    protected void bindPassRecoveryQue()
    {
        ddlpassque.Items.Clear();
        DataSet Ds = new DataSet();
        Ds = MySql.GetDataSetWithQuery("Exec getPassRecoveryQue");
        if (Ds.Tables[0].Rows.Count > 0)
        {
            ddlpassque.DataSource = Ds;
            ddlpassque.DataTextField = "PasswordQue";
            ddlpassque.DataValueField = "Id";
            ddlpassque.DataBind();
            ddlpassque.Items.Insert(0, new ListItem("Select Question", "0"));
        }
    }

    protected void GenerateOTPnew(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtloginid.Text.ToString()))
        {
            lblpass.Text = "Please enter the Username";
            return;
        }
        string characters = numbers;
        int length = int.Parse("6");


        for (int i = 0; i < length; i++)
        {
            string character = string.Empty;

            do
            {
                int index = new Random().Next(0, characters.Length);
                character = characters.ToCharArray()[index].ToString();
            } while (otp.IndexOf(character) != -1);
            otp += character;
        }
        Session["Otp"] = otp;
        string Message = "OTP for MP ITI NCVT Entry: '" + otp + "'";
        DataTable dt = new DataTable();
        dt = MySql.GetDataTableWithQuery("select * from  tbl_User_Profile where Name='" + txtloginid.Text.ToString() + "'");
        mobileNo = Convert.ToString(dt.Rows[0]["MobileNo"]);
        string gateway2use = "https://api.equence.in/pushsms?username=aptech_trans&password=-ZE56_nr&from=ATTEST&to=" + mobileNo + "&text=" + Message + "";
        System.Net.WebRequest request = System.Net.WebRequest.Create(gateway2use);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Thread.Sleep(500); response.Close();
    }
}