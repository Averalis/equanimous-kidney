/*Created by Joshua Hall over the course of a month.
 * Finish date 5/1/2015
 * Created using C#, HTML, and I did write some of the CSS.
 * Capstone Project for Judy Hawley's capstone class.
*/
using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//needed for database stuff to work
using System.Data.OleDb;
using System.Globalization;
using System.Data;
//needed for regex to work
using System.Text.RegularExpressions;
//needed for mail to work
using System.Net.Mail;
public partial class Alerts : System.Web.UI.Page
{
    //pattern for the regex to check the Student ID to ensure it is a positive number from 0-9999999.
    static string pattern = @"^[0-9]\d{0,6}$";
    static string path;
    static string connectionString;
    //This makes the regex that'll use the string pattern.
    Regex check = new Regex(pattern);
    //This makes sure that the boolean isn't reset if a page_load occurs.
    bool idExists
    {
        get
        {
            object o = ViewState["idExists"];
            if(o == null) return false;
            return (bool)o;
        }
        set
        {
            ViewState["idExists"] = value;
        }
    }
    //col sets the color to red, wht to white. These are used to show errors.
    System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#D11919");
    System.Drawing.Color wht = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
    //Variables used throughout this page.
    private string alertDate, alertType, reportingFaculty, numAbsences, maxAbs, numTardies,
        academicProgress, withdrawalRisk, currentGrade, comments, firstName, lastName, MI, studentID, email, absRemaining, course, semester;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                path = HttpContext.Current.Server.MapPath("~/Database/EALERT.accdb");
                //This automatically finds the path for the database.
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + path;

                //db connection
                OleDbConnection conn = new OleDbConnection(connectionString);

                DataSet ds2 = new DataSet();
                string query2 = "SELECT Name FROM Faculty_Staff ORDER BY Name;";
                OleDbDataAdapter adapter2 = new OleDbDataAdapter(query2, conn);
                conn.Open();
                adapter2.Fill(ds2);
                conn.Close();
                //fills the drop down list with the names.
                cmbReportingFaculty.DataSource = ds2;
                cmbReportingFaculty.DataTextField = "Name";
                cmbReportingFaculty.DataValueField = "Name";
                cmbReportingFaculty.DataBind();
                cmbReportingFaculty.Items.Insert(0, new ListItem());
                cmbReportingFaculty.SelectedIndex = 0;

                DataSet ds3 = new DataSet();
                string query3 = "SELECT Course FROM Course ORDER BY Course;";
                OleDbDataAdapter adapter3 = new OleDbDataAdapter(query3, conn);
                conn.Open();
                adapter3.Fill(ds3);
                conn.Close();
                //fills the drop down list with the courses.
                cmbCourse.DataSource = ds3;
                cmbCourse.DataTextField = "Course";
                cmbCourse.DataValueField = "Course";
                cmbCourse.DataBind();
                cmbCourse.Items.Insert(0, new ListItem());
                cmbCourse.SelectedIndex = 0;
            }
            if(IsPostBack)
            {
                //i left this line of code in. I no longer used the event handler for
                //alert type drop down list. If you are remaking this program just
                //don't use that event handler. If this is taken out, things go bad.
                cmbAlertType_SelectedIndexChanged(sender, e);
            }
        }
        catch
        {
            //used a lot throughout my program. Redirects to error.html
            Response.Redirect("Error.html");
        }
    }
    //Used to insert the data into alerts.
    private void InsertToAlerts(string alertDate, string studentID, string course, string semester, string alertType, string reportingFaculty, string numAbsences, string maxAbs, string absRemaining, string numTardies,
        string academicProgress, string withdrawalRisk, string currentGrade, string comments)
    {
        try
        {
            //sets the variable "conn" to the file path.
            OleDbConnection conn = new OleDbConnection(connectionString);
            OleDbCommand cmd = conn.CreateCommand();

            cmd.Connection = conn;
            conn.Open();

            //created the sql command
            cmd.CommandText =
                        @"INSERT INTO Alerts (AlertDate, StudentID, [Course], Semester, Alert_Type, Reporting_Faculty, NumAbsences, MaxAllowedAbs, AbsRemaining, NumTardies, AcademicProgress, Withdrawal_Risk, Current_Grade, Comments)" +
                        " VALUES(@alertDate, @studentID, @course, @semester, @alertType, @reportingFaculty, @numAbsences, @maxAbs,@absRemaining, @numTardies, @academicProgress, @withdrawalRisk, @currentGrade, @comments);";

            //Adds named parameters THESE MUST BE IN THE EXACT ORDER OF THE SQL STATEMENT.
            cmd.Parameters.Add(new OleDbParameter("@alertDate", alertDate));
            cmd.Parameters.Add(new OleDbParameter("@studentID", studentID));
            cmd.Parameters.Add(new OleDbParameter("@course", course));
            cmd.Parameters.Add(new OleDbParameter("@semester", semester));
            cmd.Parameters.Add(new OleDbParameter("@alertType", alertType));
           // cmd.Parameters.Add(new OleDbParameter("@courseType", courseType));
            cmd.Parameters.Add(new OleDbParameter("@reportingFaculty", reportingFaculty));
            cmd.Parameters.Add(new OleDbParameter("@numAbsences", numAbsences));
            cmd.Parameters.Add(new OleDbParameter("@maxAbs", maxAbs));
            cmd.Parameters.Add(new OleDbParameter("@absRemaining", absRemaining));
            cmd.Parameters.Add(new OleDbParameter("@numTardies", numTardies));
            cmd.Parameters.Add(new OleDbParameter("@academicProgress", academicProgress));
            cmd.Parameters.Add(new OleDbParameter("@withdrawalRisk", withdrawalRisk));
            cmd.Parameters.Add(new OleDbParameter("@currentGrade", currentGrade));
            cmd.Parameters.Add(new OleDbParameter("@comments", comments));

            //executes the command then closes the connection.
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        catch
        {
            Response.Redirect("Error.html");
        }
    }
    //inserts the data into students.
    private void InsertToStudents(string studentID, string firstName, string MI, string lastName, string email)
    { 
        try
        {
            if (idExists == false)
            {
                path = Server.MapPath("~").ToString();
                OleDbConnection conn = new OleDbConnection(connectionString);
                OleDbCommand cmd = conn.CreateCommand();

                cmd.Connection = conn;
                conn.Open();
                

                //created the sql command
                cmd.CommandText =
                    @"INSERT INTO Student (StudentID, FirstName, MI, LastName, Email)" +
                    " VALUES(@studentID, @firstName, @MI, @lastName, @email);";

                //Adds named parameters THESE MUST BE IN THE EXACT ORDER OF THE SQL STATEMENT.
                cmd.Parameters.Add(new OleDbParameter("@studentID", studentID));
                cmd.Parameters.Add(new OleDbParameter("@firstName", firstName));
                cmd.Parameters.Add(new OleDbParameter("@MI", MI));
                cmd.Parameters.Add(new OleDbParameter("@lastName", lastName));
                cmd.Parameters.Add(new OleDbParameter("@email", email));

                //executes the command then closes the connection.
                cmd.ExecuteNonQuery();
                conn.Close();
            }

        }
        catch
        {
            Response.Redirect("Error.html");
        }
    }
    private void SetAllVariables()
    {
        int localAbs = 0;
        //Sets variables to text box Text.
        firstName = txtFirstName.Text.ToString();
        lastName = txtLastName.Text.ToString();
        MI = txtMiddleInit.Text.ToString();
        studentID = txtStudentID.Text.ToString();
        email = txtEmail.Text.ToString();
        currentGrade = txtCurrentGrade.Text.ToString();
        comments = txtComments.Text.ToString();
        course = cmbCourse.SelectedValue.ToString();

        //automatically sets alert date to the current date.
        DateTime now = DateTime.Now;
        alertDate = now.ToString();

        //Sets Variables to Drop Down List selected value.
        numAbsences = ddlAbsences.SelectedValue.ToString();
        reportingFaculty = cmbReportingFaculty.SelectedValue.ToString();
        withdrawalRisk = cmbWithdrawalRisk.SelectedValue.ToString();
        academicProgress = cmbAcademicProgress.SelectedValue.ToString();
        maxAbs = ddlMaxAbsences.SelectedValue.ToString();
        numTardies = ddlNumTardies.SelectedValue.ToString();


        DateTime moment = DateTime.Now;
        
        int determineMonth = moment.Month;
        int determineYear = moment.Year;

        //README: I left this in in case you have more time than I did. This inserts course type. Course type
        //is Transfer, Non-Transfer, Health Sciences, and Developmental.
        //db connection
        /*OleDbConnection conn = new OleDbConnection(connectionString);
        string query = "SELECT CourseType FROM Course WHERE Course=@Course";

        OleDbCommand command = new OleDbCommand(query, conn);
        OleDbDataReader reader = null;
        ID = txtStudentID.Text.ToString();

        command.Parameters.Add(new OleDbParameter("@Course", course));
        conn.Open();
        //execute
        reader = command.ExecuteReader();
        //loops through the reader
        while (reader.Read())
        {
            string courseRead = (string)reader["CourseType"];
            if (courseRead == null)
            {
                courseType = "Soon";
            }
            courseType = courseRead.ToString();
        }
        conn.Close();  */       
      
        //determines month to set semster. Mark asked for it to be able to determine if it's spring or summer/summer or fall.
        //Because summer classes start in May and summer classes end in August.
        switch(determineMonth)
        {
            case 1:
            case 2:
            case 3:
            case 4:
                semester = "SP" + determineYear.ToString();
                break;
            case 5:
            case 6:
            case 7:
                semester = "SU" + determineYear.ToString();
                break;
            case 8:
            case 9:
            case 10:
            case 11:
            case 12:
                semester = "FA" + determineYear.ToString();
                break;
            default:
                break;
        }
        //checks if the drop down list absences index is greater than 0, 0 is N/A. If it is then it does the math on the MaxAbs and NumAbs drop down
        //lists, and then converts the integer to a string. Else if it is not greater than 0, the abs remaining are N/A.
        if (ddlAbsences.SelectedIndex > 0 && ddlMaxAbsences.SelectedIndex >0)
        {
            localAbs = Convert.ToInt32(ddlMaxAbsences.SelectedValue.ToString()) - Convert.ToInt32(ddlAbsences.SelectedValue.ToString());
            absRemaining = localAbs.ToString();
        }
        else
        {
            absRemaining = "N/A";
        }
        //This is to set alert type to a specific letter. Teachers don't know alert types by letters.
        //They are spelled out in the drop down lists, this switch case just converts to the letters.
        switch (cmbAlertType.SelectedIndex)
        {
            case 0:
                alertType = "";
                break;
            case 1:
                alertType = "A";
                break;
            case 2:
                alertType = "T";
                break;
            case 3:
                alertType = "G";
                break;
            case 4:
                alertType = "AT";
                break;
            case 5:
                alertType = "AG";
                break;
            case 6:
                alertType = "ATG";
                break;
            case 7:
                alertType = "TG";
                break;
            default:
                break;
        }
    }
    //used to reset everything back to how it is starting up.
    private void ResetAll()
    {
        txtComments.Text = "";
        txtCurrentGrade.Text = "";
        txtEmail.Text = "";
        txtStudentID.Text = "";
        txtFirstName.Text = "";
        txtMiddleInit.Text = "";
        txtLastName.Text = "";
        ddlAbsences.SelectedIndex = 0;
        ddlMaxAbsences.SelectedIndex = 0;
        ddlNumTardies.SelectedIndex = 0;
        cmbAcademicProgress.SelectedIndex = 0;
        cmbAlertType.SelectedIndex = 0;
        cmbReportingFaculty.SelectedIndex =0;
        cmbWithdrawalRisk.SelectedIndex = 0;
        cmbCourse.SelectedIndex = 0;

        //method to disable all
        setDisabled();
        btnSubmit.Enabled = false;
        btnUpdate.Enabled = false;
        lblIDError.Visible = false;
        lblError.Visible = false;
        txtStudentID.Enabled = true;
        txtStudentID.Focus();
        ResetColor();
    }
    //this is btn submit.
    protected void Button1_Click(object sender, EventArgs e)
    {
        SubmitForm();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ResetAll();
        ResetColor();
    }
    //resets the error colors.
    private void ResetColor()
    {
        //resets all back colors to white
        //These work kind of. I listed the ones below it that I think weren't working
        foreach (Control c in Page.Controls)
        {
            foreach (Control childc in c.Controls)
            {
                DropDownList ddl = childc as DropDownList;
                TextBox txt = childc as TextBox;
                if (childc is DropDownList)
                {
                    ddl.BackColor = wht;
                }
                if (childc is TextBox)
                {
                    txt.BorderColor = wht;
                }
            }
        }
        cmbAcademicProgress.BackColor = wht;
        cmbWithdrawalRisk.BackColor = wht;
        ddlNumTardies.BackColor = wht;
        ddlMaxAbsences.BackColor = wht;
        ddlAbsences.BackColor = wht;
        txtCurrentGrade.BackColor = wht;
    }
    //sets form to disabled.
    private void setDisabled()
    {
        cmbCourse.Enabled = false;
        cmbAlertType.Enabled = false;
        txtComments.Enabled = false;
        txtCurrentGrade.Enabled = false;
        txtEmail.Enabled = false;
        txtFirstName.Enabled = false;
        txtMiddleInit.Enabled = false;
        txtLastName.Enabled = false;
        ddlAbsences.Enabled = false;
        ddlMaxAbsences.Enabled = false;
        ddlNumTardies.Enabled = false;
        cmbAcademicProgress.Enabled = false;
        cmbReportingFaculty.Enabled = false;
        cmbWithdrawalRisk.Enabled = false;
        lblIDError.Visible = false;
    }
    //sets form to enabled.
    private void setEnabled()
    {
        txtComments.Enabled = true;
        txtEmail.Enabled = true;
        txtFirstName.Enabled = true;
        txtMiddleInit.Enabled = true;
        txtLastName.Enabled = true;
        cmbCourse.Enabled = true;
        cmbAlertType.Enabled = true;
        cmbReportingFaculty.Enabled = true;
        ddlAbsences.Enabled = true;
        ddlMaxAbsences.Enabled = true;
        ddlNumTardies.Enabled = true;
        cmbAcademicProgress.Enabled = true;
        cmbWithdrawalRisk.Enabled = true;
        txtCurrentGrade.Enabled = true;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            //these reset the textboxes. I feel like there was a problem if I didn't do this. Don't take these out.
            txtFirstName.Text = "";
            txtMiddleInit.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtStudentID.Enabled = false;
            //this means that only after they have searched for a student ID can they
            //use the rest of the web form.
            setEnabled();

            //sets the error label to not show
            lblIDError.Visible = false;

            string ID = "";
            //Only works if the Student ID length is 7 characters long. Adding an else to show a label stating the error.
            if (txtStudentID.Text.Length == 7 && check.IsMatch(txtStudentID.Text.ToString()))
            {
                btnSubmit.Enabled = true;
                lblIDError.Visible = false;
                ID = txtStudentID.Text.ToString();

                OleDbConnection conn = new OleDbConnection(connectionString);

                using (OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM Student WHERE StudentID like @ID", conn))
                {
                    conn.Open();

                    cmd.Parameters.Add(new OleDbParameter("@ID", ID));
                    int userCount = (int)cmd.ExecuteScalar();

                    //if it returns with a 1 that means true, if true then do the code. Else set idExists to false and allows information to be enetered to the DB
                    //If this is not done and a duplicate ID is entered into the database there will be a runtime error. This handles that.
                    if (userCount >= 1)
                    {
                        //sets the boolean to true so that the student info can not be entered twice.
                        idExists = true;

                        //select query from student table using parameter
                        string query = "SELECT FirstName, MI, LastName, Email FROM Student WHERE StudentID=@ID;";

                        OleDbCommand command = new OleDbCommand(query, conn);
                        OleDbDataReader reader = null;
                        ID = txtStudentID.Text.ToString();

                        command.Parameters.Add(new OleDbParameter("@ID", ID));

                        //executes the read
                        reader = command.ExecuteReader();

                        //loops through the info setting them to the textboxes.
                        while (reader.Read())
                        {
                            string fname = (string)reader["FirstName"];
                            string mname = (string)reader["MI"];
                            string lname = (string)reader["LastName"];
                            string emailRead = (string)reader["Email"];
                            txtFirstName.Text = fname.ToString();
                            txtMiddleInit.Text = mname.ToString();
                            txtLastName.Text = lname.ToString();
                            txtEmail.Text = emailRead.ToString();
                        }
                        conn.Close();
                        btnUpdate.Enabled = true;
                    }
                    else
                    {
                        //connection was opened and left open to run the next section.
                        //you need this conn.close();
                        conn.Close();
                        idExists = false;
                        btnUpdate.Enabled = false;
                    }
                }
            }
            else
            {
                ResetAll();
                lblIDError.Visible = true;
            }
        }
        catch
        {
            Response.Redirect("Error.html");
        }
        }
    //Read the first comment.
    protected void cmbAlertType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Even though this is no longer used. Deleting it causes headaches to remove it.
        //I use setEnabled on every case because if i don't it disables half my form.
       /* switch (cmbAlertType.SelectedIndex)
        {
            case 0:
                DisableAll();
                setEnabled();
                break;
            case 1:
                AbsenceTextboxes();
                setEnabled();
                DisableGrade();
                DisableTardie();
                break;
            case 2:
                TardeisTextbox();
                setEnabled();
                DisableGrade();
                DisableAbsence();
                break;
            case 3:
                GradeTextboxes();
                setEnabled();
                DisableAbsence();
                DisableTardie();
                break;
            case 4:
                AbsenceTextboxes();
                setEnabled();
                TardeisTextbox();
                DisableGrade();
                break;
            case 5:
                AbsenceTextboxes();
                setEnabled();
                GradeTextboxes();
                DisableTardie();
                break;
            case 6:
                AbsenceTextboxes();
                setEnabled();
                TardeisTextbox();
                GradeTextboxes();
                break;
            case 7:
                TardeisTextbox();
                setEnabled();
                GradeTextboxes();
                DisableAbsence();
                break;
            default:
                break;
        }*/
    }
    
    private void SubmitForm()
    {
        //bool test is used to check every part of the form for valid data. If something is invalid it is set to false.
        bool test = true;
        //sets variables to be used.
        SetAllVariables();
        //I honestly can't remember why this is here. 
        setEnabled();
        //resets color here because if theres an error, color is set.
        ResetColor();
        if (check.IsMatch(txtStudentID.Text.ToString()) && txtStudentID.Text.Length == 7)
        {

            if (!(Validation.IsntBlank(firstName)))
            {
                txtFirstName.BorderColor = col;
                test = false;
            }
            if (!(Validation.IsntBlank(lastName)))
            {
                txtLastName.BorderColor = col;
                test = false;
            }
            if (!(Validation.IsntBlank(email)))
            {
                txtEmail.BorderColor = col;
                test = false;
            }
            if(cmbReportingFaculty.SelectedIndex==0)
            {
                cmbReportingFaculty.BackColor = col;
                test = false;
            }
            if(cmbCourse.SelectedIndex==0)
            {
                cmbCourse.BackColor = col;
                test = false;
            }
            //checking for null is needed to make sure all fields aren't set to red. It will happen.
            if (alertType == "")
            {
                txtCurrentGrade.BackColor = wht;
                ddlNumTardies.BackColor = wht;
                ddlAbsences.BackColor = wht;
                ddlMaxAbsences.BackColor = wht;
                cmbAcademicProgress.BackColor = wht;
                cmbWithdrawalRisk.BackColor = wht;
                cmbAlertType.BackColor = col;
                test = false;
            }
            if (alertType == "A")
            {
                if (ddlAbsences.SelectedIndex == 0)
                {
                    ddlAbsences.BackColor = col;
                    test = false;
                }
                //I did these pretty late, most say <1 you can set them to == 0 if you want.
                if (ddlMaxAbsences.SelectedIndex < 1)
                {
                    ddlMaxAbsences.BackColor = col;
                    test = false;
                }
            }
            if (alertType == "T")
            {
                if (ddlNumTardies.SelectedIndex < 1)
                {
                    ddlNumTardies.BackColor = col;
                    test = false;
                }
            }
            if (alertType == "G")
            {
                if (txtCurrentGrade.Text.Length < 1)
                {
                    txtCurrentGrade.BackColor = col;
                    test = false;
                }
            }
            if (alertType == "AT")
            {
                if (ddlNumTardies.SelectedIndex < 1)
                {
                    ddlNumTardies.BackColor = col;
                    test = false;
                }
                if (ddlAbsences.SelectedIndex < 1)
                {
                    ddlAbsences.BackColor = col;
                    test = false;
                }
                if (ddlMaxAbsences.SelectedIndex < 1)
                {
                    ddlMaxAbsences.BackColor = col;
                    test = false;
                }
            }
            if (alertType == "AG")
            {
                if (txtCurrentGrade.Text.Length < 1)
                {
                    txtCurrentGrade.BackColor = col;
                    test = false;
                }

                if (ddlAbsences.SelectedIndex < 1)
                {
                    ddlAbsences.BackColor = col;
                    test = false;
                }
                if (ddlMaxAbsences.SelectedIndex < 1)
                {
                    ddlMaxAbsences.BackColor = col;
                    test = false;
                }
            }
            if (alertType == "ATG")
            {
                if (txtCurrentGrade.Text.Length < 1)
                {
                    txtCurrentGrade.BackColor = col;
                    test = false;
                }
                if (ddlNumTardies.SelectedIndex < 1)
                {
                    ddlNumTardies.BackColor = col;
                    test = false;
                }
                if (ddlAbsences.SelectedIndex < 1)
                {
                    ddlAbsences.BackColor = col;
                    test = false;
                }
                if (ddlMaxAbsences.SelectedIndex < 1)
                {
                    ddlMaxAbsences.BackColor = col;
                    test = false;
                }
            }
            if (alertType == "TG")
            {
                if (txtCurrentGrade.Text.Length < 1)
                {
                    txtCurrentGrade.BackColor = col;
                    test = false;
                }

                if (ddlNumTardies.SelectedIndex < 1)
                {
                    ddlNumTardies.BackColor = col;
                    test = false;
                }
            }
            if (cmbAcademicProgress.SelectedIndex < 1)
            {
                cmbAcademicProgress.BackColor = col;
                test = false;
            }
            if (cmbWithdrawalRisk.SelectedIndex < 1)
            {
                cmbWithdrawalRisk.BackColor = col;
                test = false;
            }
            //this is the regex in use. refer to the top for the regex pattern and name.
            if (!(check.IsMatch(txtStudentID.Text.ToString()) && txtStudentID.Text.Length == 7))
            {
                lblIDError.Visible = true;
                test = false;
            }
            //this is where the boolean test is used as you can tell...
            if (test == true)
            {
                //Inserts student information into Students.
                InsertToStudents(studentID, firstName, MI, lastName, email);
                //Inserts Alert information into Alerts.
                InsertToAlerts(alertDate, studentID, course, semester, alertType, reportingFaculty, numAbsences, maxAbs,
                   absRemaining, numTardies, academicProgress, withdrawalRisk, currentGrade, comments);
                Emailing();
                ResetAll();
            }
            if (test == false)
            {
                lblError.Visible = true;
            }
        }
    }
    //This is as it says for emailing.
    private void Emailing()
    {
        try
        {
            //Student Services Mail
            MailMessage mail2 = new MailMessage();
            SmtpClient SmtpServer2 = new SmtpClient("smtp.gmail.com");
            //set this email to for example donotreply@cccti.edu, this is not a real email
            //CHANGE THE EMAIL FOR THIS CODE TO WORK. CHANGED SO THAT REAL EMAIL WASN'T ON THE WEB.
            mail2.From = new MailAddress("sample@gmail.com");
            //Change this to all student services staff I think. You'll know. I don't.
            //CHANGE THE EMAIL FOR THIS CODE TO WORK. CHANGED SO THAT REAL EMAIL WASN'T ON THE WEB.
            mail2.To.Add("sample@gmail.com");
            //make the following two items whatever you want to make them.
            mail2.Subject = "Early Alert STUDENT SERVICES Test";
            mail2.Body = "This is a test email. " + txtStudentID.Text.ToString() + " has had an alert entered under their ID. " +
                "He/She was entered into the system for the following reason " + cmbAlertType.SelectedValue.ToString() +
                ". The Reporting faculty member was " + cmbReportingFaculty.SelectedValue.ToString() + ".";

            //Uh... I googled this. I think it's the port google mail uses.
            SmtpServer2.Port = 587;
            //this is the login ("username@gmail.com", "password");
            //CHANGE THE EMAIL FOR THIS CODE TO WORK. CHANGED SO THAT REAL EMAIL WASN'T ON THE WEB. The password was a random password from Keypass.
            SmtpServer2.Credentials = new System.Net.NetworkCredential("sample@gmail.com", "de35eaf29a892cd67fea5f023edb270cb4821c3260ebf99589457830003dc5ac");
            //googled it. sorry.
            SmtpServer2.EnableSsl = true;
            //sends the email.
            SmtpServer2.Send(mail2);
        }
        catch
        {
            Response.Redirect("Error.html");
        }
    }
    //This allows teachers to update student information.
    private void UpdateStudent (string firstName, string MI, string lastName, string email,string studentID)
    {
        try
        {
                SetAllVariables();
                ResetColor();
                using (OleDbConnection db = new OleDbConnection(connectionString))
                {
                    string query =
                        @"UPDATE Student SET FirstName=@firstName, MI=@MI, LastName=@lastName, Email=@email" +
                        " WHERE StudentID=@studentID";

                    OleDbCommand cmd = new OleDbCommand(query, db);
                    cmd.Parameters.Add(new OleDbParameter("@firstName", firstName));
                    cmd.Parameters.Add(new OleDbParameter("@MI", MI));
                    cmd.Parameters.Add(new OleDbParameter("@lastName", lastName));
                    cmd.Parameters.Add(new OleDbParameter("@email", email));
                    cmd.Parameters.Add(new OleDbParameter("@studentID", studentID));

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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
            SetAllVariables();
            UpdateStudent(firstName, MI, lastName, email,studentID);
            setEnabled();
    }
}