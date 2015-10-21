namespace ExcellProcessing
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.IO;
    using System.Reflection;

    public class ExcelTasks
    {
        public void Start()
        {
            string pathToExcel = Directory.GetCurrentDirectory()
                .Split(new[] { "\\bin\\Debug" }, StringSplitOptions.RemoveEmptyEntries)[0] +
                    "\\data.xls";

            string strExcelConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
            "Data Source=" + pathToExcel + ";" +
            "Extended Properties='Excel 8.0;HDR=Yes'";
            
            OleDbConnection excelConnection = new OleDbConnection(strExcelConn);
            OleDbCommand cmdExcel = new OleDbCommand();
            cmdExcel.Connection = excelConnection;
            
            excelConnection.Open();
            DataTable excelSchema = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            excelConnection.Close();
            
            DataSet ds = new DataSet();
            /* Better use external library instead of this shit.*/
        }
    }
}
