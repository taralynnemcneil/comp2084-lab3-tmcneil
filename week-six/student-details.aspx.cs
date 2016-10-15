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

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // connect
            var conn = new ContosoEntities();

            // use the student class to create a new student object
            Student s = new Student();

            // fill the properties of the new department object
            s.LastName = txtLastName.Text;
            s.FirstMidName = txtFirstName.Text;
            s.EnrollmentDate = Convert.ToDateTime(txtEnrollmentDate.Text);

            // save the new object to the database
            conn.Students.Add(s);
            conn.SaveChanges();

            // redirect to the departments page
            Response.Redirect("students.aspx");

        }
    }
}