using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.IO;
using System.Security.Cryptography;

public static class CommonUtilities
{

    public static string ConnectionString()
    {
        return ConfigurationManager.AppSettings["ConnectionString"];
    }

    public static string ConnectionStringAttestNet()
    {
        return ConfigurationManager.AppSettings["ConnectionString"];
    }



    public enum Provider
    {
        SQL = 1, Access = 2
    }

    public static DataSet GetDataSet(string sqlText)
    {
        DataSet ds = null;
        SqlCommand dbcom;
        SqlConnection dbcon;
        SqlDataAdapter dadapter;

        dbcon = new SqlConnection(CommonUtilities.ConnectionString());
        dbcom = new SqlCommand(sqlText, dbcon);
        dadapter = new SqlDataAdapter(dbcom);

        ds = new DataSet();
        dadapter.Fill(ds, "results");
        dbcon.Close();
        return ds;
    }

    public static bool ExecuteNonQuery(string sqlText)
    {
        bool result = false;
        SqlCommand dbcom;
        SqlConnection dbcon;
        dbcon = new SqlConnection(CommonUtilities.ConnectionString());
        try
        {
            dbcom = new SqlCommand(sqlText, dbcon);
            dbcom.CommandType = CommandType.Text;
            dbcon.Open();
            dbcom.ExecuteNonQuery();
            result = true;
        }
        finally
        {
            dbcon.Close();
        }
        return result;
    }


    //return dataset by Passing  Query
    public static DataSet GetDataSetWithQueryAttest(string sqlText)
    {
        DataSet ds = null;
        SqlCommand dbcom;
        SqlConnection dbcon;
        SqlDataAdapter dadapter;

        dbcon = new SqlConnection(CommonUtilities.ConnectionStringAttestNet());

        dbcom = new SqlCommand(sqlText, dbcon);
        dbcom.CommandType = CommandType.Text;
        dadapter = new SqlDataAdapter(dbcom);

        ds = new DataSet();
        dadapter.Fill(ds, "results");
        dbcon.Close();
        return ds;
    }

    public static DataSet GetDataSetWithQuery(string sqlText)
    {
        DataSet ds = null;
        SqlCommand dbcom;
        SqlConnection dbcon;
        SqlDataAdapter dadapter;

        dbcon = new SqlConnection(CommonUtilities.ConnectionString());

        dbcom = new SqlCommand(sqlText, dbcon);
        dbcom.CommandType = CommandType.Text;
        dadapter = new SqlDataAdapter(dbcom);

        ds = new DataSet();
        dadapter.Fill(ds, "results");
        dbcon.Close();
        return ds;
    }
    //return dataset by Passing  TwoQuery 
    public static DataSet GetDataSetWithTwoQuery(string sqlText1, string sqlText2)
    {
        DataSet ds = null;
        DataSet ds1 = null;
        SqlCommand dbcom1;
        SqlCommand dbcom2;
        SqlConnection dbcon;
        SqlDataAdapter dadapter;

        // connection string
        dbcon = new SqlConnection(CommonUtilities.ConnectionString());

        //call the stored procedure
        dbcom1 = new SqlCommand(sqlText1, dbcon);
        dbcom1.CommandType = CommandType.Text;
        dadapter = new SqlDataAdapter(dbcom1);

        ds = new DataSet();
        dadapter.Fill(ds, "results");

        dbcom2 = new SqlCommand(sqlText2, dbcon);
        dbcom2.CommandType = CommandType.Text;
        dadapter = new SqlDataAdapter(dbcom2);

        ds1 = new DataSet();
        dadapter.Fill(ds1, "results");

        ds.Merge(ds1);
        dbcon.Close();
        return ds;
    }

    //return datareader
    public static SqlDataReader GetDataReader(string sqlText)
    {
        SqlCommand dbcom;
        SqlConnection dbcon;
        SqlDataReader dr;

        dbcon = new SqlConnection(CommonUtilities.ConnectionString());
        dbcom = new SqlCommand(sqlText, dbcon);
        dbcom.Connection.Open();
        dr = dbcom.ExecuteReader();
        return dr;
    }

    //return int from DataReader but with ExecuteScalar

    public static int SingleCellResult(string strquery)
    {
        SqlCommand dbcom;
        SqlConnection dbcon;
        int lcchkRec = 0;
        dbcon = new SqlConnection(CommonUtilities.ConnectionString());
        try
        {
            dbcon.Open();
            dbcom = new SqlCommand(strquery, dbcon);
            lcchkRec = (int)dbcom.ExecuteScalar();
            dbcon.Close();
        }
        finally
        {
            if (dbcon.State == ConnectionState.Open)
            {
                dbcon.Close();
            }
        }
        return lcchkRec;
    }

    public static int SingleCellResultAttestNet(string strquery)
    {
        SqlCommand dbcom;
        SqlConnection dbcon;
        int lcchkRec = 0;
        dbcon = new SqlConnection(CommonUtilities.ConnectionStringAttestNet());
        try
        {
            dbcon.Open();
            dbcom = new SqlCommand(strquery, dbcon);
            lcchkRec = (int)dbcom.ExecuteScalar();
            dbcon.Close();
        }
        finally
        {
            if (dbcon.State == ConnectionState.Open)
            {
                dbcon.Close();
            }
        }
        return lcchkRec;
    }


    //return String from DataReader but with ExecuteScalar
    public static string SingleCellResultInStringCentrDB(string strquery)
    {
        SqlCommand dbcom;
        SqlConnection dbcon;
        string lcchkRec = "";
        dbcon = new SqlConnection(CommonUtilities.ConnectionStringAttestNet());
        try
        {
            dbcon.Open();
            dbcom = new SqlCommand(strquery, dbcon);
            lcchkRec = dbcom.ExecuteScalar().ToString();
            dbcon.Close();
        }
        finally
        {
            if (dbcon.State == ConnectionState.Open)
            {
                dbcon.Close();
            }
        }
        return lcchkRec;
    }

    public static string SingleCellResultInString(string strquery)
    {
        SqlCommand dbcom;
        SqlConnection dbcon;
        string lcchkRec = "";
        dbcon = new SqlConnection(CommonUtilities.ConnectionString());
        try
        {
            dbcon.Open();
            dbcom = new SqlCommand(strquery, dbcon);
            lcchkRec = dbcom.ExecuteScalar().ToString();
            dbcon.Close();
        }
        finally
        {
            if (dbcon.State == ConnectionState.Open)
            {
                dbcon.Close();
            }
        }
        return lcchkRec;
    }


    public static string SingleCellResultInStringAttestNet(string strquery)
    {
        SqlCommand dbcom;
        SqlConnection dbcon;
        string lcchkRec = "";
        dbcon = new SqlConnection(CommonUtilities.ConnectionStringAttestNet());
        try
        {
            dbcon.Open();
            dbcom = new SqlCommand(strquery, dbcon);
            lcchkRec = dbcom.ExecuteScalar().ToString();
            dbcon.Close();
        }
        catch (Exception err)
        {
            throw err;
        }

        finally
        {
            if (dbcon.State == ConnectionState.Open)
            {
                dbcon.Close();
            }
        }
        return lcchkRec;
    }


    //return int from DataReader but with ExecuteScalar and with Decimal As Return Type

    public static decimal SingleCellResult_decimal(string strquery)
    {
        SqlCommand dbcom;
        SqlConnection dbcon;
        decimal lcchkRec = 0;
        dbcon = new SqlConnection(CommonUtilities.ConnectionString());
        try
        {
            dbcon.Open();
            dbcom = new SqlCommand(strquery, dbcon);
            lcchkRec = (decimal)dbcom.ExecuteScalar();
            dbcon.Close();
        }
        catch (Exception err)
        {
            throw err;
        }

        finally
        {
            if (dbcon.State == ConnectionState.Open)
            {
                dbcon.Close();
            }
        }
        return lcchkRec;
    }

    //return dataset by Passing  Query
    public static DataSet GetDataSetWithQueryAttestNet(string sqlText)
    {
        DataSet ds = null;
        SqlCommand dbcom;
        SqlConnection dbcon;
        SqlDataAdapter dadapter;

        // connection string
        dbcon = new SqlConnection(CommonUtilities.ConnectionStringAttestNet());

        //call the stored procedure
        dbcom = new SqlCommand(sqlText, dbcon);
        dbcom.CommandType = CommandType.Text;
        dadapter = new SqlDataAdapter(dbcom);

        ds = new DataSet();
        dadapter.Fill(ds, "results");
        dbcon.Close();
        return ds;
    }


    public static DataSet GetDataSetWithQueryAttestATC(string sqlText)
    {
        DataSet ds = null;
        SqlCommand dbcom;
        SqlConnection dbcon;
        SqlDataAdapter dadapter;

        // connection string
        dbcon = new SqlConnection(CommonUtilities.ConnectionString());

        //call the stored procedure
        dbcom = new SqlCommand(sqlText, dbcon);
        dbcom.CommandType = CommandType.Text;
        dadapter = new SqlDataAdapter(dbcom);

        ds = new DataSet();
        dadapter.Fill(ds, "results");
        dbcon.Close();
        return ds;
    }

    public static bool TransactionEntry(int Order_Id, int Exam_Id)
    {
        SqlCommand dbcom;
        SqlConnection dbcon;
        SqlParameter dbparam;

        int norecords = 0;
        // connection string
        dbcon = new SqlConnection(CommonUtilities.ConnectionString());

        //call the stored procedure
        dbcom = new SqlCommand("SP_ValidateUser", dbcon);
        dbcom.CommandType = CommandType.StoredProcedure;

        //define the parameters

        //login
        dbcom.Parameters.Add(new SqlParameter("@orderid", SqlDbType.Int));
        dbcom.Parameters["@orderid"].Value = Order_Id;

        //password
        dbcom.Parameters.Add(new SqlParameter("@examid", SqlDbType.Int));
        dbcom.Parameters["@examid"].Value = Exam_Id;

        //Establish an output parameter to return a value from the stored proc
        dbparam = dbcom.Parameters.Add(new SqlParameter("@validuser", SqlDbType.Int));

        //Our parameter is for output as mentioned
        dbparam.Direction = ParameterDirection.Output;

        try
        {

            dbcon.Open();
            dbcom.ExecuteNonQuery();

            norecords = (int)dbcom.Parameters["@validuser"].Value;


            dbcon.Close();
        }
        catch
        {

        }

        finally
        {
            if (dbcon.State == ConnectionState.Open)
            {
                dbcon.Close();
            }
        }

        if (norecords == 1)
        {
            //user name & password found
            return true;
        }

        //user name & password not found
        return false;

    }



    public static bool ValidIPRequest(string filepath, string clientIP)
    {
        XmlDocument xmldoc;
        string path = "Paths.xml";
        //path=Request.PhysicalApplicationPath+path;
        path = filepath + path;
        //Response.Write(path);
        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        xmldoc = new XmlDocument();
        xmldoc.Load(fs);
        //DisplayCatalog();	

        XmlNodeList xmlnode = xmldoc.GetElementsByTagName("IP");
        //Response.Write("Here is the list of catalogs\n\n");

        for (int i = 0; i < xmlnode.Count; i++)
        {

            if (xmlnode[i].FirstChild.InnerText == clientIP)
                return true;
        }
        return false;

    }

    public static string Encrypt<T>(string key, string value)
          where T : SymmetricAlgorithm, new()
    {
        DeriveBytes rgb = new Rfc2898DeriveBytes(key, new byte[8]);

        SymmetricAlgorithm algorithm = new T();

        byte[] rgbKey = rgb.GetBytes(algorithm.KeySize >> 3);
        byte[] rgbIV = rgb.GetBytes(algorithm.BlockSize >> 3);

        ICryptoTransform transform = algorithm.CreateEncryptor(rgbKey, rgbIV);

        using (MemoryStream buffer = new MemoryStream())
        {
            using (CryptoStream stream = new CryptoStream(buffer, transform, CryptoStreamMode.Write))
            {
                using (StreamWriter writer = new StreamWriter(stream, Encoding.Unicode))
                {
                    writer.Write(value);
                }
            }

            return Convert.ToBase64String(buffer.ToArray());
        }
    }


    public static string Decrypt<T>(string key, string text)
       where T : SymmetricAlgorithm, new()
    {
        DeriveBytes rgb = new Rfc2898DeriveBytes(key, new byte[8]);

        SymmetricAlgorithm algorithm = new T();

        byte[] rgbKey = rgb.GetBytes(algorithm.KeySize >> 3);
        byte[] rgbIV = rgb.GetBytes(algorithm.BlockSize >> 3);

        ICryptoTransform transform = algorithm.CreateDecryptor(rgbKey, rgbIV);

        using (MemoryStream buffer = new MemoryStream(Convert.FromBase64String(text)))
        {
            using (CryptoStream stream = new CryptoStream(buffer, transform, CryptoStreamMode.Read))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.Unicode))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }


    public static string CreateKey(int keyLength)
    {
        String _allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
        Byte[] randomBytes = new Byte[keyLength];

        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        rng.GetBytes(randomBytes);


        char[] chars = new char[keyLength];
        int allowedCharCount = _allowedChars.Length;

        for (int i = 0; i < keyLength; i++)
        {
            chars[i] = _allowedChars[(int)randomBytes[i] % allowedCharCount];
        }

        return new string(chars);
    }


    public static string CalculateMD5Checksum(string filename)
    {
        using (var md5 = MD5.Create())
        {
            using (var stream = File.OpenRead(filename))
            {
                return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
            }
        }
    }

    public static void LogError(Exception ex)
    {
        string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
        message += Environment.NewLine;
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;
        message += string.Format("Message: {0}", ex.Message);
        message += Environment.NewLine;
        message += string.Format("StackTrace: {0}", ex.StackTrace);
        message += Environment.NewLine;
        message += string.Format("Source: {0}", ex.Source);
        message += Environment.NewLine;
        message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
        message += Environment.NewLine;
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;

        string logFilePath = @"\\192.168.105.2\e\WebPortal_Data\MPITISCVT\MPITINCVT_Jan2020\\DD\\";

        logFilePath = logFilePath + "ProgramLog" + "-" + DateTime.Today.ToString("yyyyMMdd") + "." + "txt";

        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        {
            writer.WriteLine(message);
            writer.Close();
        }
    }

    public static void LogFileWrite(string message)
    {
        FileStream fileStream = null;
        StreamWriter streamWriter = null;
        try
        {
            string logFilePath = @"\\192.168.105.2\e\WebPortal_Data\MPITISCVT\MPITINCVT_Jan2020\\DD\\";

            logFilePath = logFilePath + "ProgramLog" + "-" + DateTime.Today.ToString("yyyyMMdd") + "." + "txt";

            if (logFilePath.Equals("")) return;
            #region Create the Log file directory if it does not exists
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo = new FileInfo(logFilePath);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            #endregion Create the Log file directory if it does not exists

            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }
            streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine(message);
        }
        finally
        {
            if (streamWriter != null) streamWriter.Close();
            if (fileStream != null) fileStream.Close();
        }

    }

    //public static void WriteErrorLog(string Message)
    //{
    //    StreamWriter sw = null;
    //    try
    //    {
    //        sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
    //        sw.WriteLine(DateTime.Now.ToString() + ": " + Message);
    //        sw.Flush();
    //        sw.Close();
    //    }
    //    catch
    //    {
    //    }
    //}

}