using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
//sing System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AlertDataView : System.Web.UI.Page
{
    static string connectionString;
    private string path;
    protected void Page_Load(object sender, EventArgs e)
    {
        //db connection
        if (!IsPostBack)
        {
            try
            {
                //This automatically finds the path for the database. Should not need touched.

                path = HttpContext.Current.Server.MapPath("~/Database/EALERT.accdb");
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + path;
                //I can't remember why I used this. I did a lot of this work late at night.
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                OleDbConnection conn = new OleDbConnection(connectionString);

                DataSet ds3 = new DataSet();
                string query3 = "SELECT * FROM Alerts ORDER BY AlertID;";
                OleDbDataAdapter adapter3 = new OleDbDataAdapter(query3, conn);
                conn.Open();
                adapter3.Fill(ds3);
                gridViewAlerts.DataSource = ds3;
                gridViewAlerts.DataBind();
                conn.Close();

                DataSet ds4 = new DataSet();
                string query4 = "SELECT Course FROM Alerts GROUP BY Course;";
                OleDbDataAdapter adapter4 = new OleDbDataAdapter(query4, conn);
                conn.Open();
                adapter4.Fill(ds4);
                conn.Close();
                //fills the drop down list with the courses.
                ddlCourse.DataSource = ds4;
                ddlCourse.DataTextField = "Course";
                ddlCourse.DataValueField = "Course";
                ddlCourse.DataBind();
                ddlCourse.Items.Insert(0, new ListItem());
                ddlCourse.SelectedIndex = 0;
            }
            catch
            {
                Response.Redirect("Error.html");
            }
        }
    }

    //Accidental do not add or do anything in this block.
    protected void gridViewAlerts_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    //searches based on the student ID or id's enetered.
    protected void btnAlertIDSEarch_Click(object sender, EventArgs e)
    {
        // this sets the id's of course.
        string alertID = txtAlertID.Text.ToString();
        string alertIDEnd = txtAlertIdEnd.Text.ToString();
        //I didn't run into an error, I added this just in case. If only 1 id is enetered into a textbox
        //this will set the other variable to that textbox as well. I added it just in case.
        if (alertIDEnd == "" && alertID.Length>1)
        {
            alertIDEnd = alertID;
        }
        if (alertID == "" && alertIDEnd.Length >1)
        {
            alertID = alertIDEnd;
        }

        OleDbConnection conn = new OleDbConnection(connectionString);
        //sql statement to select from a range.
        OleDbCommand cmd = new OleDbCommand("SELECT * FROM Alerts WHERE AlertID BETWEEN @AlertID AND @AlertIDEnd ORDER BY AlertID", conn);
        cmd.Parameters.AddWithValue("@AlertID", alertID);
        cmd.Parameters.AddWithValue("@AlertIDEnd", alertIDEnd);
        OleDbDataAdapter da1 = new OleDbDataAdapter(cmd);
        DataTable dt1 = new DataTable();
        da1.Fill(dt1);
        gridViewAlerts.DataSource = dt1;
        gridViewAlerts.DataBind();
        conn.Close();
        txtAlertID.Text = "";
        txtAlertIdEnd.Text = "";
    }
    //searches based on student ID
    protected void btnStudentIDSEarch_Click(object sender, EventArgs e)
    {
        string studentID = txtStudentID.Text.ToString();
        OleDbConnection conn = new OleDbConnection(connectionString);
        OleDbCommand cmd = new OleDbCommand("SELECT * FROM Alerts WHERE StudentID=@StudentID ORDER BY AlertID", conn);
        cmd.Parameters.AddWithValue("@StudentID", studentID);
        OleDbDataAdapter da2 = new OleDbDataAdapter(cmd);
        DataTable dt2 = new DataTable();
        da2.Fill(dt2);
        gridViewAlerts.DataSource = dt2;
        gridViewAlerts.DataBind();
        conn.Close();
        txtStudentID.Text = "";
    }
    //searches based on Course title.
    protected void btnCourseSearch_Click(object sender, EventArgs e)
    {
            string course = ddlCourse.SelectedValue.ToString();
            OleDbConnection conn = new OleDbConnection(connectionString);
            //order by is needed because if it isnt there it'll every class on the alerts table so you'll end up with
            //for exampled 200 CSC-253-680C course entries in the drop down list.
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Alerts WHERE Course=@course ORDER BY AlertID", conn);
            cmd.Parameters.AddWithValue("@course", course);
            OleDbDataAdapter da4 = new OleDbDataAdapter(cmd);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            gridViewAlerts.DataSource = dt4;
            gridViewAlerts.DataBind();
            conn.Close();
            ddlCourse.SelectedIndex = 0;
    }
    //resets the form and dataview back to default.
    private void Reset()
    {
        txtAlertID.Text = "";
        txtStudentID.Text = "";
        txtAlertIdEnd.Text = "";
        ddlCourse.SelectedIndex = 0;

        OleDbConnection conn = new OleDbConnection(connectionString);

        DataSet ds3 = new DataSet();
        string query3 = "SELECT * FROM Alerts ORDER BY AlertID;";
        OleDbDataAdapter adapter3 = new OleDbDataAdapter(query3, conn);
        conn.Open();
        adapter3.Fill(ds3);
        gridViewAlerts.DataSource = ds3;
        gridViewAlerts.DataBind();
        conn.Close();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Reset();
    }
}