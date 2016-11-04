using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// add references to access the database
using System.Web.ModelBinding;

namespace week_six
{
    public partial class student_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack== false)
            {
                // check the url for an ID
                if (!String.IsNullOrEmpty(Request.QueryString["StudentID"]))
                {
                    // get the ID from the url
                    Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                    // connect to the database
                    var conn = new ContosoEntities();

                    // find the selected student
                    var objStudent = (from s in conn.Students
                                      where s.StudentID == StudentID
                                      select s).FirstOrDefault();

                    // populate the form
                    txtLastName.Text = objStudent.LastName;
                    txtFirstName.Text = objStudent.FirstMidName;
                    txtEnrollmentDate.Text = objStudent.EnrollmentDate.ToString();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // check if we are adding a student or editing one
            Int32 StudentID = 0;

            if (!String.IsNullOrEmpty(Request.QueryString["StudentID"]))
            {
                StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);
            }

            // connect
            var conn = new ContosoEntities();

            // use the student class to create a new student object
            Student s = new Student();

            // fill the properties of the new department object
            s.LastName = txtLastName.Text;
            s.FirstMidName = txtFirstName.Text;
            s.EnrollmentDate = Convert.ToDateTime(txtEnrollmentDate.Text);

            // save the new object to the database
            if (StudentID == 0)
            {
                conn.Students.Add(s);
            }
            else
            {
                s.StudentID = StudentID;
                conn.Students.Attach(s);
                conn.Entry(s).State = System.Data.Entity.EntityState.Modified;
            }

            conn.SaveChanges();

            // redirect to the departments page
            Response.Redirect("students.aspx");

        }
    }
}