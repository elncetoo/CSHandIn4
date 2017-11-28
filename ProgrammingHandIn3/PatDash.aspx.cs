using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProgrammingHandIn3
{
    public partial class PatDash : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* A person must be able to change own data only.
                Patients who have logged in must be able to see a list of only the names of all dentists.
            */

            if (Session["pat_log"] != null && !Page.IsPostBack)
            {
                LabelPatDash.Text = Session["pat_log"].ToString();
                // LabelPatDash.Text = (string)(Session["pat_log"]);
            }

        }


        protected void logoutbtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("HomePage.aspx");
        }
    }
}