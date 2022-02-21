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
using System.Web.UI.WebControls;
public partial class Admin_StenoFeesCollectionReport : System.Web.UI.Page
{
    CommonPerception Mysql = new CommonPerception();
    DataTable dtgrid;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["Username"] == null)
        //    Response.Redirect("../Login/LoginNew.aspx");
        //else
        //    lblUName.Text = "Welcome " + Session["Username"].ToString();


        //CheckLoginTime();

        if (!IsPostBack)
        {
            BindGrid();
        }
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
    protected void BindGrid()
    {
        dtgrid = new DataTable();
        dtgrid = Mysql.GetDataTableWithQuery("exec GetAdminStenoCompositeReport ");
        if (dtgrid != null && dtgrid.Rows.Count > 0)
        {
            GridView1.DataSource = dtgrid;
            GridView1.DataBind();
            lblCMessage.Text = "";
            divReport.Visible = true;
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            lblCMessage.Text = "Sorry, No record found";
            divReport.Visible = false;
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void btnGenerateExcel_Click(object sender, EventArgs e)
    {
        dtgrid = new DataTable();
        dtgrid = Mysql.GetDataTableWithQuery("exec GetAdminStenoCompositeReport");
        if (dtgrid != null && dtgrid.Rows.Count > 0)
            CreateAdminCompositeReportExcel(dtgrid);
    }
    private void CreateAdminCompositeReportExcel(DataTable dt)
    {
        ExcelPackage excel = new ExcelPackage();
        var workSheet = excel.Workbook.Worksheets.Add("Steno Fees Collection Report");
        //var totalCols = dt.Columns.Count - 2;
        var totalCols = dt.Columns.Count;
        var totalRows = dt.Rows.Count;
        workSheet.Cells["A1:Q1"].Merge = true;
        workSheet.Cells["A1:Q1"].Style.Font.Bold = true;
        workSheet.Cells["A1:Q1"].Style.Font.Size = 18;
        workSheet.Cells[1, 1].Value = "Steno Fees Collection Report";
        workSheet.Cells["A1:Q1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
        workSheet.Cells["A1:Q1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        workSheet.Cells["A1:Q1"].Style.Font.UnderLine = true;

        workSheet.Cells["A2:Q2"].Merge = true;
        workSheet.Row(2).Height = 70;
        string imagepath = Server.MapPath("~/images/iti1.png");
        AddImage(workSheet, 1, 4, imagepath);
        System.Drawing.Color colFromHeximg = System.Drawing.ColorTranslator.FromHtml("#d8b377");
        workSheet.Cells["A2:Q2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
        workSheet.Cells["A2:Q2"].Style.Fill.BackgroundColor.SetColor(colFromHeximg);

        //workSheet.Cells["A3:I3"].Merge = true;
        //workSheet.Cells["A3:I3"].Style.Font.Bold = true;
        //workSheet.Cells["A3:I3"].Style.Font.Size = 13;
        //workSheet.Cells[3, 1].Value = "ITI Code : " + dt.Rows[0]["ITICode"] + "     ITI Name : " + dt.Rows[0]["ITIName"];
        //workSheet.Cells["A3:I3"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
        //workSheet.Cells["A3:I3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

       
       
        workSheet.Cells["A3:Q4"].Style.Font.Bold = true;
        //dt.Columns.Remove("ITICode");
        //dt.Columns.Remove("ITIName");
        for (var col = 1; col <= totalCols; col++)
        {
            workSheet.Cells[3, col].Value = dt.Columns[col - 1].ColumnName;
            workSheet.Cells[3, col].Style.Font.Bold = true;
        }
        System.Drawing.Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#CC632A");
        workSheet.Cells["A3:Q3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
        workSheet.Cells["A3:Q3"].Style.Fill.BackgroundColor.SetColor(colFromHex);
        for (var row = 1; row <= totalRows; row++)
        {
            for (var col = 0; col < totalCols; col++)
            {
                workSheet.Cells[row + 3, col + 1].Value = dt.Rows[row - 1][col];
            }
        }
        int lastcell = totalRows + 3;
        ExcelRange range = workSheet.Cells["A1:Q" + lastcell + ""];
        range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //range.Style.Border.Top.Color.SetColor(Color.Red);
        range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
        //range.Style.Border.Left.Color.SetColor(Color.Green);
        range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
        //range.Style.Border.Right.Color.SetColor(Color.Green);
        range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        //range.Style.Border.Bottom.Color.SetColor(DeepBlueHexCode); 
        using (var memoryStream = new MemoryStream())
        {
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;  filename=steno fees collection Report.xlsx");
            excel.SaveAs(memoryStream);
            memoryStream.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }
    }
    private void AddImage(ExcelWorksheet oSheet, int rowIndex, int colIndex, string imagePath)
    {
        Bitmap image = new Bitmap(imagePath);
        OfficeOpenXml.Drawing.ExcelPicture excelImage = null;
        if (image != null)
        {
            excelImage = oSheet.Drawings.AddPicture("Debopam Pal", image);
            excelImage.From.Column = colIndex;
            excelImage.From.Row = rowIndex;
            excelImage.SetSize(380, 90);
            // 2x2 px space for better alignment
            excelImage.From.ColumnOff = Pixel2MTU(2);
            excelImage.From.RowOff = Pixel2MTU(2);
        }
    }
    public int Pixel2MTU(int pixels)
    {
        int mtus = pixels * 9525;
        return mtus;
    }
    protected void btnGeneratePdf_Click(object sender, EventArgs e)
    {
        dtgrid = new DataTable();
        dtgrid = Mysql.GetDataTableWithQuery("exec GetAdminStenoCompositeReport");
        if (dtgrid != null && dtgrid.Rows.Count > 0)
            CreateAdminCompositeReportPdf(dtgrid);
    }
    private void CreateAdminCompositeReportPdf(DataTable dt)
    {
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<table width='100%' cellspacing='0' cellpadding='2' style='font-family: Arial;'>");
                sb.Append("<tr><td align='center' colspan = '5' style='font-size:18px; text-decoration:underline;'><b>Steno Fees Collection Report</b></td></tr>");
                sb.Append("<tr><td colspan = '5'></td></tr>");
                sb.Append("<tr><td align='center' bgcolor='#d8b377' colspan = '5'><img height='70px' width='250px' src='" + Server.MapPath("~/images/iti.png") + "' /></td></tr>");
                sb.Append("<tr><td colspan = '5'></td></tr>");
                //sb.Append("<tr><td align='center' colspan = '5'><b>ITI Code : </b>" + dt.Rows[0]["ITICode"] + " &nbsp;&nbsp;&nbsp;<b>ITI Name : </b>" + dt.Rows[0]["ITIName"] + "</td></tr>");
                           
               
                sb.Append("</table>");
                sb.Append("<br />");
                sb.Append("<table width='100%' cellpadding='2' border = '1' style='font-size:10px; font-family: Arial;'>");
                sb.Append("<tr>");
                //dt.Columns.Remove("ITICode");
                //dt.Columns.Remove("ITIName");
                string addStyle = string.Empty;
                foreach (DataColumn column in dt.Columns)
                {
                    if (column.ColumnName.ToLower() == "roll number")
                        addStyle = "width='15%' colspan = '2'";
                    else if (column.ColumnName.ToLower() == "name")
                        addStyle = "width='20%' colspan = '2'";
                    else if (column.ColumnName.ToLower() == "sem")
                        addStyle = "width='5%' colspan = '1'";
                    else if (column.ColumnName.ToLower() == "itiname")
                        addStyle = "width='20%' colspan = '2'";
                    else
                        addStyle = "width='10%' colspan = '1'";
                    sb.Append("<th bgcolor='#CC632A' style='color:black; font-weight:bold;' " + addStyle + ">");
                    sb.Append(column.ColumnName);
                    sb.Append("</th>");
                }
                sb.Append("</tr>");
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        if (column.ColumnName.ToLower() == "roll number")
                            addStyle = "width='15%' colspan = '2'";
                        else if (column.ColumnName.ToLower() == "name")
                            addStyle = "width='20%' colspan = '2'";
                        else if (column.ColumnName.ToLower() == "sem")
                            addStyle = "width='5%' colspan = '1'";
                        else if (column.ColumnName.ToLower() == "itiname")
                            addStyle = "width='20%' colspan = '2'";
                        else
                            addStyle = "width='10%' colspan = '1'";

                        sb.Append("<td " + addStyle + ">");
                        sb.Append(row[column]);
                        sb.Append("</td>");
                    }
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                StringReader sr = new StringReader(sb.ToString());
                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 10, 10, 10, 10);
                iTextSharp.text.html.simpleparser.HTMLWorker htmlparser = new iTextSharp.text.html.simpleparser.HTMLWorker(pdfDoc);
                iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=steno fees collection Report.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
        }
    }
}