using Common.Class;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using QRCoder;
using System.Globalization;

public partial class Principle_Marksheet : System.Web.UI.Page
{
    CommonPerception Mysql = new CommonPerception();
    DataTable dtgrid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["rollno"] != null)
            {
                InsertAdmitCardDownloadStatus(Convert.ToString(Request.QueryString["rollno"]));
                BindStudentDetails(Convert.ToString(Request.QueryString["rollno"]));
            }
        }
    }

    private void InsertAdmitCardDownloadStatus(string rollno)
    {
        Mysql.ExecuteNonQuery("InsertWPMDownloadStatus @Rollnumber='" + rollno + "'");
    }

    private void BindStudentDetails(string rollno)
    {
        dtgrid = new DataTable();
        dtgrid = Mysql.GetDataTableWithQuery("exec GetStudentDetailsForWPM @RollNo='" + rollno + "'");
        if (dtgrid != null && dtgrid.Rows.Count > 0)
        {
            string trade = Convert.ToString(dtgrid.Rows[0]["trade"]);

            string marksheetNo = "MP/STENO/" + Convert.ToString(dtgrid.Rows[0]["AdmissionYear"]) + "/0121/" + Convert.ToString(dtgrid.Rows[0]["ITICode"]).Substring(6, 4) + "/" + Convert.ToString(dtgrid.Rows[0]["TradeCode"])+"/N" + Convert.ToString(dtgrid.Rows[0]["marksheetSeries"]);
            string code = marksheetNo + "," + Convert.ToString(dtgrid.Rows[0]["RollNumber"]) + "," + Convert.ToString(dtgrid.Rows[0]["Name"]) + "," + Convert.ToString(dtgrid.Rows[0]["Trade"]) + "," + Convert.ToString(dtgrid.Rows[0]["AdmissionYear"]) + ",PASS";
            bindQRCode(code);

            lblmarksheetNoSteno.Text = marksheetNo;
            lblNameSteno.Text = Convert.ToString(dtgrid.Rows[0]["Name"]);
            lblFatherNameSteno.Text = Convert.ToString(dtgrid.Rows[0]["FatherName"]);
            lblRollNoSteno.Text = Convert.ToString(dtgrid.Rows[0]["RollNumber"]);
            lblItiNameSteno.Text = Convert.ToString(dtgrid.Rows[0]["ITIName"]);
            lblDistrictSteno.Text = Convert.ToString(dtgrid.Rows[0]["ExistsDistrict"]);
            lblDateSteno.Text = DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("hh:mm tt");
        }
    }

    private void bindQRCode(string code)
    {
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
        imgBarCode.Height = 150;
        imgBarCode.Width = 150;
        using (Bitmap bitMap = qrCode.GetGraphic(20))
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] byteImage = ms.ToArray();
                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
            }
            plBarCodeSteno.Controls.Add(imgBarCode);
        }
    }

}