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
    public partial class DentDash : System.Web.UI.Page
    {

        /* A person must be able to change own data only.
           Dentists who have logged in must be able to see a list of all persons.
        */



        protected void Page_Load(object sender, EventArgs e)
        {
            //LabelDentDash.Text = Session["dent_log"];
            if (Session["dent_log"] != null && !Page.IsPostBack)
            {
                LabelDentDash.Text = (string)Session["dent_log"];
                //UpdateGridview();
            }
        }

        protected void logoutbtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("HomePage.aspx");
        }
    }
}