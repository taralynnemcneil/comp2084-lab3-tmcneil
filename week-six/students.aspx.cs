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
            // connect to database
            var conn = new ContosoEntities();

            // run the query using LINQ
            var Students = from s in conn.Students
                           select s;

            // display query result in grideview
            grdStudents.DataSource = Students.ToList();
            grdStudents.DataBind();
        }
    }
}