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

        protected void grdDepartments_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // function delete department from gridview
            // determine the row the user clicked
            Int32 gridIndex = e.RowIndex;

            // find department id in selected row
            Int32 DepartmentID = Convert.ToInt32(grdDepartments.DataKeys[gridIndex].Value);

            // connect to database
            var conn = new ContosoEntities();

            // delete the selected department
            /* var objDep = (from d in conn.Departments
                            where d.DepartmentID == DepartmentID
                            select d).First(); */

            Department d = new Department();
            d.DepartmentID = DepartmentID;
            conn.Departments.Attach(d);
            conn.Departments.Remove(d);
            conn.SaveChanges();

            // refresh the gridview
            getDepartments();

        }
    }
}