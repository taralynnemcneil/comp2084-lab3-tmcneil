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
    public partial class department_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            { 
                // check the url for an ID
                if (!String.IsNullOrEmpty(Request.QueryString["DepartmentID"]))
                {
                    // get Id from the url
                    Int32 DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

                    // connect to the database
                    var conn = new ContosoEntities();

                    // find selected department
                    var objDep = (from d in conn.Departments
                                  where d.DepartmentID == DepartmentID
                                  select d).FirstOrDefault();

                    // populate the form
                    txtName.Text = objDep.Name;
                    txtBudget.Text = objDep.Budget.ToString();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // check if we are adding of editing
            Int32 DepartmentID = 0;

            if (!String.IsNullOrEmpty(Request.QueryString["DepartmentID"]))
            {
                DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);
            }
            
            // connect
            var conn = new ContosoEntities();

            // use the department class to create a new department object
            Department d = new Department();

            // fill the properties of the new department object
            d.Name = txtName.Text;
            d.Budget = Convert.ToDecimal(txtBudget.Text);

            // save the object to the database
            if (DepartmentID == 0)
            {
                conn.Departments.Add(d);
            } else {
                d.DepartmentID = DepartmentID;
                conn.Departments.Attach(d);
                conn.Entry(d).State = System.Data.Entity.EntityState.Modified;
            }
            
            conn.SaveChanges();

            // redirect to the departments page
            Response.Redirect("departments.aspx");

        }
    }
}