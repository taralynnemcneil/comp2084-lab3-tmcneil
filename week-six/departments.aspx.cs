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
    public partial class departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // get the departments and display in the gridview
            getDepartments();
        }

        protected void getDepartments()
        {
            // connect to database
            var conn = new ContosoEntities();

            // run the query using LINQ
            var Departments = from d in conn.Departments
                              select d;

            // display query result in grideview
            grdDepartments.DataSource = Departments.ToList();
            grdDepartments.DataBind();
            

        }

    }
}