using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FollowUp : System.Web.UI.Page
{
    static string connectionString;
    private string path;
    //This is to keep the notes variable IF an update had already been done on an alert ID.
    //This is necessary in order to keep past notes from previous follow ups. If that explanation
    //wasn't good enough just look at the notes column on the follow up data view. You should understand.
    string notesUpdate
    {
        get
        {
            object o = ViewState["notesUpdate"];
            return (string)o;
        }
        set
        {
            ViewState["notesUpdate"] = value;
        }
    }
    //Variables used throughout this page.
    private string alertID, averageGrade, followUpDate, dropDate, faculty, notes, dropped, phone, email, other, finalDate;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           try
            {
               //db connection string
                path = HttpContext.Current.Server.MapPath("~/Database/EALERT.accdb");
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + path;

                //db connection
                OleDbConnection conn = new OleDbConnection(connectionString);

                DataSet ds = new DataSet();
                string query = "SELECT AlertID FROM Alerts ORDER BY AlertID";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                conn.Open();
                adapter.Fill(ds);
                conn.Close();
                //fills the drop down list with the IDs.
                ddlAlertID.DataSource = ds;
                ddlAlertID.DataTextField = "AlertID";
                ddlAlertID.DataValueField = "AlertID";
                ddlAlertID.DataBind();
                ddlAlertID.Items.Insert(0, new ListItem());
                ddlAlertID.SelectedIndex = 0;


                DataSet ds2 = new DataSet();
                string query2 = "SELECT Name FROM Faculty_Staff ORDER BY Name";
                OleDbDataAdapter adapter2 = new OleDbDataAdapter(query2, conn);
                conn.Open();
                adapter2.Fill(ds2);
                conn.Close();
                //fills the drop down list with the names.
                ddlFollowUpFaculty.DataSource = ds2;
                ddlFollowUpFaculty.DataTextField = "Name";
                ddlFollowUpFaculty.DataValueField = "Name";
                ddlFollowUpFaculty.DataBind();
                ddlFollowUpFaculty.Items.Insert(0, new ListItem());
                ddlFollowUpFaculty.SelectedIndex = 0;
            }
            catch
            {
                Response.Redirect("Error.html");
            }
       }
    }
    //Sets variables for submitting.
    private void setVariables()
    {
        try
        {
            DateTime now = DateTime.Now;
            alertID = ddlAlertID.SelectedValue.ToString();
            dropDate = txtDropDate.Text.ToString();
            faculty = ddlFollowUpFaculty.SelectedValue.ToString();
            dropped = ddlDropped.SelectedValue.ToString();
            phone = ddlPhone.SelectedValue.ToString();
            other = ddlOther.SelectedValue.ToString();
            email = ddlEmail.SelectedValue.ToString();
            notes = now.ToString() + " " + txtNotes.Text.ToString();
            followUpDate = now.ToString();
            finalDate = now.ToString();

            //This is for adding the date to the note.
            notesUpdate += "\n" + now.ToString() + " " + txtNotes.Text.ToString();
            OleDbConnection conn = new OleDbConnection(connectionString);

            using (OleDbCommand cmd = new OleDbCommand("SELECT FROM Student WHERE StudentID like @ID", conn))
            {
                conn.Open();

                string query = "SELECT Current_Grade FROM Alerts WHERE AlertID=@ID ORDER BY AlertID;";

                OleDbCommand command = new OleDbCommand(query, conn);
                OleDbDataReader reader = null;

                //set a new parameter here, not sure why just had to.
                command.Parameters.Add(new OleDbParameter("@ID", alertID));

                //executes the read
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    averageGrade = (string)reader["Current_Grade"];
                }
                conn.Close();

            }
        }
        catch
        {
            Response.Redirect("Error.html");
        }

    }
    //inserts into follow up table.
    private void InsertIntoFollowUp(string alertID, string followUpDate, string averageGrade, string dropped, 
        string dropDate, string faculty, string phone, string email, string other, string notes)
    {
        try
        {
            OleDbConnection conn = new OleDbConnection(connectionString);
            OleDbCommand cmd = conn.CreateCommand();

            cmd.Connection = conn;
            conn.Open();

            //created the sql command
            cmd.CommandText =
                @"INSERT INTO FollowUpLog (AlertID, FollowUpDate, AverageToDate, Dropped, DropDate,
                ReportingFaculty, ContactByPhone, ContactByEmail, OtherContact, Notes)" +
                    " VALUES(@AlertID, @FollowUpDate, @AverageToDate,  @Dropped, @DropDate, @ReportingFaculty, @ContactByPhone, @ContactByEmail, @OtherContact, @Notes);";

            //Adds named parameters
            cmd.Parameters.Add(new OleDbParameter("@AlertID", alertID));
            cmd.Parameters.Add(new OleDbParameter("@FollowUpDate", followUpDate));
            cmd.Parameters.Add(new OleDbParameter("@AverageToDate", averageGrade));
            cmd.Parameters.Add(new OleDbParameter("@Dropped", dropped));
            cmd.Parameters.Add(new OleDbParameter("@DropDate", dropDate));
            cmd.Parameters.Add(new OleDbParameter("@ReportingFaculty", faculty));
            cmd.Parameters.Add(new OleDbParameter("@ContactByPhone", phone));
            cmd.Parameters.Add(new OleDbParameter("@ContactByEmail", email));
            cmd.Parameters.Add(new OleDbParameter("@OtherContact", other));
            cmd.Parameters.Add(new OleDbParameter("@Notes", notes));

            //executes the command then closes the connection.
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        catch
        {
            Response.Redirect("Error.html");
        }
    }
    //Accidental CLicks don't add code to either of these textbox events.
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //If the followup faculty is a greater index than 0 then the submit works.
        //Else error label.
        if (ddlFollowUpFaculty.SelectedIndex > 0)
        {
            setVariables();
            InsertIntoFollowUp(alertID, followUpDate, averageGrade, dropped,
            dropDate, faculty, phone, email, other, notes);
            reset();
        }
        else
        {
            lblFacultyError.Visible = true;
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        reset();
    }
    private void reset()
    {
        ddlAlertID.SelectedIndex = 0;
        ddlDropped.SelectedIndex = 0;
        txtDropDate.Text = "";
        ddlFollowUpFaculty.SelectedIndex = 0;
        ddlPhone.SelectedIndex = 0;
        ddlEmail.SelectedIndex = 0;
        ddlOther.SelectedIndex = 0;
        txtNotes.Text = "";
        ddlAlertID.Enabled=true;
        btnSubmit.Enabled = false;
        btnUpdate.Enabled=false;

        ddlDropped.Enabled = false;
        txtDropDate.Enabled = false;
        ddlFollowUpFaculty.Enabled = false;
        ddlPhone.Enabled = false;
        ddlEmail.Enabled = false;
        ddlOther.Enabled = false;
        txtNotes.Enabled = false;
        lblFacultyError.Visible = false;
        ddlAlertID.Enabled = true;
    }
    //Whoops.
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //If the followup faculty is a greater index than 0 then the update works.
        //Else error label.
        if (ddlFollowUpFaculty.SelectedIndex > 0)
        {
            setVariables();
            UpdateRecords(dropped, dropDate, finalDate, faculty, phone, email, other, notesUpdate, alertID);
            reset();
        }
        else
        {
            lblFacultyError.Visible = true;
        }
    }
    private void UpdateRecords(string dropped, string dropDate, string finalDate, string faculty, string phone, string email, string other, string notes, string alertID)
    {
        try
        {
            using (OleDbConnection db = new OleDbConnection(connectionString))
            {
                string query =
                    @"UPDATE FollowUpLog SET Dropped=@Dropped, DropDate=@DropDate, FinalReportDate=@FinalDate, ReportingFaculty=@ReportingFaculty, ContactByPhone=@ContactByPhone," +
                    " ContactByEmail=@ContactByEmail, OtherContact=@OtherContact, Notes=@Notes" +
                    " WHERE AlertID=@AlertID";

                OleDbCommand cmd = new OleDbCommand(query, db);
                cmd.Parameters.Add(new OleDbParameter("@Dropped", dropped));
                cmd.Parameters.Add(new OleDbParameter("@DropDate", dropDate));
                cmd.Parameters.Add(new OleDbParameter("@FinalDate", finalDate));
                cmd.Parameters.Add(new OleDbParameter("@ReportingFaculty", faculty));
                cmd.Parameters.Add(new OleDbParameter("@ContactByPhone", phone));
                cmd.Parameters.Add(new OleDbParameter("@ContactByEmail", email));
                cmd.Parameters.Add(new OleDbParameter("@OtherContact", other));
                cmd.Parameters.Add(new OleDbParameter("@Notes", notes));
                cmd.Parameters.Add(new OleDbParameter("@AlertID", alertID));

                db.Open();
                //executes the command then closes the connection.
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }
        catch
        {
            Response.Redirect("Error.html");
        }
    }
    //enables form
    private void enableForm()
    {
        ddlDropped.Enabled = true;
        txtDropDate.Enabled = true;
        ddlFollowUpFaculty.Enabled = true;
        ddlPhone.Enabled = true;
        ddlEmail.Enabled = true;
        ddlOther.Enabled = true;
        txtNotes.Enabled = true;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlAlertID.SelectedIndex > 0)
            {
                ID = ddlAlertID.SelectedValue.ToString();
                OleDbConnection conn = new OleDbConnection(connectionString);
                using (OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM FollowUpLog WHERE AlertID like @ID", conn))
                {
                    conn.Open();

                    cmd.Parameters.Add(new OleDbParameter("@ID", ID));
                    int userCount = (int)cmd.ExecuteScalar();

                    //if it returns with a 1 that means true, if true then do the code. Else set idExists to false and allows information to be enetered to the DB
                    //If this is not done and a duplicate ID is entered into the database there will be a runtime error. This handles that.
                    if (userCount >= 1)
                    {


                        //select query from student table using parameter
                        string query = "SELECT Dropped, DropDate, ReportingFaculty, ContactByPhone, ContactByEmail, OtherContact, Notes FROM FollowUpLog WHERE AlertID=@ID;";

                        OleDbCommand command = new OleDbCommand(query, conn);
                        OleDbDataReader reader = null;
                        ID = ddlAlertID.SelectedValue.ToString();

                        //set a new parameter here, not sure why just had to.
                        command.Parameters.Add(new OleDbParameter("@ID", ID));

                        //executes the read
                        reader = command.ExecuteReader();

                        //loops through the info setting them to the textboxes. I could potentially make this code smaller.
                        while (reader.Read())
                        {
                            string drop = (string)reader["Dropped"];
                            string dropDate = (string)reader["DropDate"];
                            string fac = (string)reader["ReportingFaculty"];
                            string phone = (string)reader["ContactByPhone"];
                            string email = (string)reader["ContactByEmail"];
                            string other = (string)reader["OtherContact"];
                            string notesUpdater = (string)reader["Notes"];
                            ddlDropped.SelectedValue = drop.ToString();
                            txtDropDate.Text = dropDate.ToString();
                            ddlFollowUpFaculty.SelectedValue = fac.ToString();
                            ddlPhone.SelectedValue = phone.ToString();
                            ddlEmail.SelectedValue = email.ToString();
                            ddlOther.SelectedValue = other.ToString();
                            notesUpdate = notesUpdater.ToString();
                        }
                        conn.Close();
                        ddlAlertID.Enabled = false;
                        btnSubmit.Enabled = false;
                        btnUpdate.Enabled = true;
                        ddlAlertID.Enabled = false;
                        enableForm();
                    }
                    else
                    {
                        ddlAlertID.Enabled = false;
                        enableForm();
                        btnSubmit.Enabled = true;
                        btnUpdate.Enabled = false;
                    }
                }
            }
        }
        catch
        {
             Response.Redirect("Error.html");
        }
    }
}