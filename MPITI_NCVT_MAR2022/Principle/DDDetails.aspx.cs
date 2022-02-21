using Common.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Auth;


public partial class Principle_DDDetails : System.Web.UI.Page
{
    CommonPerception Mysql = new CommonPerception();
    string lstrFullPath1 = string.Empty;
    string filepath1 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
            Response.Redirect("../Login/LoginNew.aspx");
        else
        {
            DataTable dt = new DataTable();
            dt = Mysql.GetDataTableWithQuery("select distinct ITICode+'-'+ITIName itiname from tbl_Student where ITICode='" + Session["Username"].ToString() + "'");
            if (dt != null && dt.Rows.Count > 0)
                lblUName.Text = "Welcome " + Convert.ToString(dt.Rows[0]["itiname"]);
            else
                lblUName.Text = "Welcome " + Session["Username"].ToString();
        }
        if (Session["PID"] == null)
            Response.Redirect("../Dashboard.aspx");

        if (!IsPostBack)
        {
            lblPID.Text = "PID: " + Session["PID"].ToString();
        }

        //if (!IsPostBack)
        //{
            CheckLoginTime();
        //}
        CheckPIDExists(Convert.ToInt32(Session["PID"].ToString()));

        txtAmount.Text = Session["Amount"].ToString();
    }
    private void CheckLoginTime()
    {
        string UsrName = Mysql.SingleCellResultInString("exec CheckLoginTime @UserName='" + Session["Username"].ToString() + "',@UserType=" + Convert.ToInt32(Session["UserType"].ToString()) + ",@LoginDate='" + Session["LoginTime"].ToString() + "'");
        if (string.IsNullOrEmpty(UsrName))
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("../Login/LogOut.aspx");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (isvalidate())
        {
            bool affectrows = false;
            int PID = Convert.ToInt32(Session["PID"].ToString());
            if (PID > 0)
            {
                string[] DDDate = txtDDDate.Text.Split('/');
                string NewDDDate = DDDate[2] + "-" + DDDate[1] + "-" + DDDate[0];

                string filePath = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["DDsavepath"]);
                string ImageShowpath = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["ImageShowPath"]);
                string PhotoPath = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["DD"]);

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                var storageAccount_connectionString = "DefaultEndpointsProtocol=https;AccountName=masterfilestorage;AccountKey=PsyX5QH4+kIMavjKA69X6+qGpzM1l0UfcydwuMZw1zGpcp5szm4oTndRVAvU+fIRhyxSO42mXsKHW0rOIifzOg==;EndpointSuffix=core.windows.net";
                CloudStorageAccount mycloudStorageAccountPhoto = CloudStorageAccount.Parse(storageAccount_connectionString);
                CloudBlobClient blobClientPhoto = mycloudStorageAccountPhoto.CreateCloudBlobClient();
                CloudBlobContainer containerPhoto = blobClientPhoto.GetContainerReference("mpiti");
                filepath1 = "";
               
                if (fu_DD.HasFile)
                {
                    filepath1 = ImageShowpath + Session["Username"].ToString() + "_" + Session["PID"].ToString() + ".jpg";
                    fu_DD.SaveAs(filePath + '/' + Session["Username"].ToString() + "_" + Session["PID"].ToString() + ".jpg");
                    string fileMimeType = fu_DD.FileContent.GetType().ToString();
                    CloudBlockBlob cloudBlockBlobPhoto = containerPhoto.GetBlockBlobReference(PhotoPath + Session["Username"].ToString() + "_" + Session["PID"].ToString() + ".jpg");
                    cloudBlockBlobPhoto.Properties.ContentType = fileMimeType;

                    //upload file to storage account
                    cloudBlockBlobPhoto.UploadFromFile(filePath + '/' + Session["Username"].ToString() + "_" + Session["PID"].ToString() + ".jpg");
                    //delete file from system file
                    System.IO.File.Delete(filePath + '/' + Session["Username"].ToString() + "_" + Session["PID"].ToString() + ".jpg");

                }

                affectrows = Mysql.ExecuteNonQuery("exec InsertDDDetails @DDNumber='" + txtDDnumber.Text + "',@BankName='" + txtBankName.Text + "',@IssuingBranch='" + txtIssuingBranch.Text + "',@DDDate='" + NewDDDate + "',@TotalAmount=" + Convert.ToDouble(txtAmount.Text).ToString("##.00") + ",@PaymentStatus='Yes',@PaymentMode='Payment through DD',@PID=" + PID + ",@DDPath='" + filepath1 + "'");
                if (affectrows)
                    Response.Redirect("DDPrint.aspx");
                else
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Some issue in update dd details. Please submit all information again.');", true);

            }
        }
    }
    bool isvalidate()
    {
        string NameChange = "";
        string Imagepath = string.Empty;
        string[] ImageName;
        string ImageExtension = string.Empty;
        string Itype = "";

        NameChange = fu_DD.PostedFile.FileName.ToString();
        Imagepath = NameChange;
        ImageName = Imagepath.Split('.');
        ImageExtension = ImageName[1];
        Itype = ImageCase(ImageExtension).ToString();

        if (string.IsNullOrEmpty(txtDDnumber.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Enter DD Number');", true);
            txtDDnumber.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtBankName.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Enter Bank Name');", true);
            txtBankName.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtIssuingBranch.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Enter Issuing Branch');", true);
            txtIssuingBranch.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtDDDate.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Enter DD Date');", true);
            txtDDDate.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtAmount.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please Enter Amount');", true);
            txtAmount.Focus();
            return false;
        }
        else if (fu_DD.FileName == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please upload DD');", true);
            return false;
        }
        else if (fu_DD.PostedFile.ContentLength > 200000)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Oops ! Error occured while uploading, DD size should be 200KB');", true);
            return false;
        }
        else if (!(Itype == "1" || Itype == "2"))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Oops ! Error occured while uploading, DD should be in .jpeg/jpg format only');", true);
            return false;
        }
        else
            return true;
    }

    #region ImageFormatchecker
    protected int ImageCase(string Format)
    {
        int ImageType = 0;
        if (Format == "jpg") { ImageType = 1; }
        else if (Format == "JPG") { ImageType = 1; }
        else if (Format == "Jpg") { ImageType = 1; }
        else if (Format == "JPg") { ImageType = 1; }
        else if (Format == "jPG") { ImageType = 1; }
        else if (Format == "jpg") { ImageType = 1; }

        else if (Format == "jpeg") { ImageType = 2; }
        else if (Format == "JPEG") { ImageType = 2; }
        else if (Format == "Jpeg") { ImageType = 2; }
        else if (Format == "JPeg") { ImageType = 2; }
        else if (Format == "jPeG") { ImageType = 2; }
        return ImageType;

    }
    #endregion

    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Mysql.UpdateSingleLogin(Session["Username"].ToString(), Convert.ToInt32(Session["UserType"].ToString()), 0);
        Session.Abandon();
        Session.Clear();
        Response.Redirect("../Login/LogOut.aspx");
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Dashboard.aspx");
    }
    private void CheckPIDExists(int CurrentPID)
    {
        string CPID = Mysql.SingleCellResultInString("exec CheckPIDExists @PID=" + CurrentPID + "");
        if (string.IsNullOrEmpty(CPID))
        {
            Response.Redirect("PrVerificationNew.aspx");
        }
    }
}