using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FollowUpData : System.Web.UI.Page
{
    static string connectionString;
    private string path;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            
            path = HttpContext.Current.Server.MapPath("~/Database/EALERT.accdb");
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source=" + path;

            //db connection
            OleDbConnection conn = new OleDbConnection(connectionString);

            DataSet ds3 = new DataSet();
            string query3 = "SELECT * FROM FollowUpLog ORDER BY AlertID;";
            OleDbDataAdapter adapter3 = new OleDbDataAdapter(query3, conn);
            conn.Open();
            adapter3.Fill(ds3);
            gridViewFollowUp.DataSource = ds3;
            gridViewFollowUp.DataBind();
            conn.Close();
        }
        catch
        {
            Response.Redirect("Error.html");
        }
    }
    
}
