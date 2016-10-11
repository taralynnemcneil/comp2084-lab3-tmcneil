using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace week_six
{
    public partial class tip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            /* ==================================================== 
             * get the amount from the text box
             * save in a variable of double (whichs holds decimals)
             * first we have to convert the value from a string to a double 
             ==================================================== */
            Double amount = Convert.ToDouble(txtAmount.Text);

            // get tip percent
            Double tipPercent = Convert.ToDouble(ddlPercent.SelectedValue);

            //calculate the tip and total
            Double tipAmount = amount * tipPercent;
            Double total = amount + tipAmount;

            lblTip.Text = tipAmount.ToString("c");
            lblTotal.Text = total.ToString("c");
        }
    }
}