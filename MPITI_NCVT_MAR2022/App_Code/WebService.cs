using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Threading;
using System.Net;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Common.Class;
/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "https://mpitincvtjul2021.cbtexam.in/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    public WebService()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void GetITIData(string ITICode)
    {
        CommonPerception Mysql = new CommonPerception();
        DataSet ds = new DataSet();
        ds = Mysql.GetDataSet("select  * from tbl_student as s left join tbl_ITIPaymentDetails as p on(s.PID=p.PID) where s.ITICode='" + ITICode + "'");

        //ExistsZone=ZoneName
        var StudentList = new List<Person>();
        if (ds.Tables[0].Rows.Count > 0)
        {
            for(int i=0; i< ds.Tables[0].Rows.Count; i++)
            {
                string payStaus = "Pending";
                if(ds.Tables[0].Rows[i]["PaymentStatus"].ToString()== "Yes")
                {
                    payStaus = "Done";
                }
                StudentList.Add(new Person()
                {
                    ITICode =           ds.Tables[0].Rows[i]["ITICode"].ToString(),
                    ITIName =           ds.Tables[0].Rows[i]["ITIName"].ToString(),
                    ExistsZone =        ds.Tables[0].Rows[i]["ExistsZone"].ToString(),
                    ExistDistrict =     ds.Tables[0].Rows[i]["ExistsDistrict"].ToString(),
                    Rollnumber =        ds.Tables[0].Rows[i]["RollNumber"].ToString(),
                    Name =              ds.Tables[0].Rows[i]["Name"].ToString(),
                    DOB =               ds.Tables[0].Rows[i]["DOB"].ToString(),
                    AdmissionYear =     ds.Tables[0].Rows[i]["AdmissionYear"].ToString(),
                    ExamType =          ds.Tables[0].Rows[i]["Examtype"].ToString(),
                    ApprovalStatus =    ds.Tables[0].Rows[i]["ApprovalStatus"].ToString(),
                    PaymentStatus =     payStaus
                });
            }
        }


        var serializer = new JavaScriptSerializer();
        var serializedResult = serializer.Serialize(StudentList);
        Context.Response.Write(serializedResult);
    }
}
public class Person
{    
    public string ITICode { get; set; }
    public string ITIName { get; set; }
    public string ExistDistrict { get; set; }
    public string Rollnumber { get; set; }
    public string Name { get; set; }
    public string DOB { get; set; }
    public string AdmissionYear { get; set; }
    public string ExamType { get; set; }
    public string ApprovalStatus { get; set; }
    public string PaymentStatus { get; set; }
    public string ExistsZone { get; set; }

}
