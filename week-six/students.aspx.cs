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
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // get the students and display in the gridview
            getStudents();
        }

        protected void getStudents()
        {
            // connect to database
            var conn = new ContosoEntities();

            // run the query using LINQ
            var Students = from s in conn.Students
                           select s;

            // display query result in grideview
            grdStudents.DataSource = Students.ToList();
            grdStudents.DataBind();
        }

        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // create a function to delete student from gridview
            // determine the row the user clicked
            Int32 gridIndex = e.RowIndex;

            // find student ID in selected row
            Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[gridIndex].Value);

            // connect to database
            var conn = new ContosoEntities();

            // delete the selected student

            Student s = new Student();
            s.StudentID = StudentID;
            conn.Students.Attach(s);
            conn.Students.Remove(s);
            conn.SaveChanges();

            // refresh the gridview
            getStudents();
        }
    }
}