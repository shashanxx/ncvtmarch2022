using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Center_OTPPage : System.Web.UI.Page
{
    string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    string small_alphabets = "abcdefghijklmnopqrstuvwxyz";

    string numbers = "1234567890";

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["OTPValid"] = "No";
        if(!IsPostBack )
        { 
            GenerateOTP();
        }

    }
    protected void btnOTPSubmit_Click(object sender, EventArgs e)
    {
        if (txtOTP.Text.Trim() == "")
        {
            lblError.Text = "Enter OTP";
            return;
        }

        if (Session["OTP"]!=null)
        {
            if (txtOTP.Text.Trim() == Session["OTP"].ToString())
            {
                Session["OTP"] = null;
                Session["OTPValid"] = "Yes";
                if (Session["centerlogin"].ToString() == "centerlogin")
                {
                    Response.Redirect("ExamCenter.aspx");
                }
                else if (Session["centerlogin"].ToString() == "JD")
                {
                    Response.Redirect("Joindirector.aspx");
                }
            }
            else
            {
                Session["OTPValid"] = "No";

                lblError.Text = "Invalid OTP";
            }
        }
    }

    protected void GenerateOTP()
    {

       



        string characters = numbers;

        //if (rbType.SelectedItem.Value == "1")
        //{

        //    characters += alphabets + small_alphabets + numbers;

        //}

        int length = int.Parse("6");

        string otp = string.Empty;

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

        Session["OTP"] = otp;
        string Message = "OTP for MP ITI Entry: '" + otp + "'";
        //string gateway2use = "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=romanf@aptech.ac.in:05Nov03&senderID=ATTEST&receipientno=" + Session["MobileNo"].ToString() + "&msgtxt=" + Message + "&state=1";

        string gateway2use = "https://api.equence.in/pushsms?username=aptech_trans&password=-ZE56_nr&from=ATTEST&to=" + Session["MobileNo"].ToString() + "&text=" + Message + "";
        System.Net.WebRequest request = System.Net.WebRequest.Create(gateway2use);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Thread.Sleep(500); response.Close();

       // lblOTP.Text = otp;

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        GenerateOTP();
    }
}