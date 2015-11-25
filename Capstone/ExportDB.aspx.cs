using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class ExportDB : System.Web.UI.Page
{

    //Alright I sorta winged this. If you're reading this Gary I think you said you had an already
    //good way to export to Excel. Mines just here for my project.
    static string path = HttpContext.Current.Server.MapPath("~/Database/EALERT.accdb");
    static string connectionString = connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
        "Data Source=" + path;

    OleDbConnection conn = new OleDbConnection(connectionString);
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                path = HttpContext.Current.Server.MapPath("~/Database/EALERT.accdb");
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + path;

            }
            catch
            {
                Response.Redirect("Error.html");
            }
        }
    } 
    private void ExportStudentsToData(DataTable dtdata)
    {
        string attach = "attachment;filename=Students.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attach);
        Response.ContentType = "application/ms-excel";
        if (dtdata != null)
        {
            foreach (DataColumn dc in dtdata.Columns)
            {
                Response.Write(dc.ColumnName + "\t");
            }
            Response.Write(System.Environment.NewLine);
            foreach (DataRow dr in dtdata.Rows)
            {
                for (int i = 0; i < dtdata.Columns.Count; i++)
                {
                    Response.Write(dr[i].ToString() + "\t");
                }
                Response.Write("\n");
            }
            Response.End();
        }
    }
    private void ExportTableData(DataTable dtdata)
    {
        string attach = "attachment;filename=Alert.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attach);
        Response.ContentType = "application/ms-excel";
        if(dtdata != null)
        {
            foreach (DataColumn dc in dtdata.Columns)
            {
                Response.Write(dc.ColumnName + "\t");
            }
            Response.Write(System.Environment.NewLine);
            foreach(DataRow dr in dtdata.Rows)
            {
                for (int i = 0;i<dtdata.Columns.Count;i++)
                {
                    Response.Write(dr[i].ToString() + "\t");
                }
                Response.Write("\n");
            }
            Response.End();
        }
    }
    protected void btnExportStudents_Click1(object sender, EventArgs e)
    {

        connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
        "Data Source=" + path;

        string query3 = "SELECT * FROM Student ORDER BY LastName;";
        OleDbDataAdapter oda = new OleDbDataAdapter(query3, conn);
        oda.Fill(dt);
        ExportStudentsToData(dt);
    }
    protected void btnExportAlerts_Click(object sender, EventArgs e)
    {
        connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
        "Data Source=" + path;

        string query3 = "SELECT * FROM Alerts ORDER BY AlertID;";
        OleDbDataAdapter oda = new OleDbDataAdapter(query3, conn);
        oda.Fill(dt);
        ExportTableData(dt);
    }
}