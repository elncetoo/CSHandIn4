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
    public partial class LogInP : System.Web.UI.Page
    {
        List<Patient> patientslist = new List<Patient>();
        private List<Patient> patientslistdesr;
        private string filename; // where we store users data

        public string email;
        public string password;

        protected void Page_Load(object sender, EventArgs e)
        {
            Deserialise();
        }
        
        private string FindUser(string email, string password)
        {
            foreach (Patient pat in patientslistdesr)
            {
                if (pat.Email == email && pat.Password == password)
                {
                    Session["pat_log"] = pat;
                    // return email.ToString();
                }
                //else
                //return dent.Email.ToString();
            }
            return null;
        }

        public void Deserialise()
        {
            filename = Server.MapPath("~/App_Data/patientslistdata.ser"); //decalring the path to the serializedfile
            patientslistdesr = new List<Patient>(); //am creating an instance variable
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None)) //opening afile stream to readfrom the file in the given path
            {
                BinaryFormatter bf = new BinaryFormatter();
                patientslistdesr = (List<Patient>)bf.Deserialize(fs);
                fs.Close();
            }

            mygridpat.DataSource = patientslistdesr;
            mygridpat.DataBind();

        }

        protected void ButtonLogInP_Click(object sender, EventArgs e)
        {
            string password = TextBoxPassword.Text;
            string email = TextBoxEmail.Text;


            if (patientslistdesr.Count > 0)
            {
                FindUser(email, password);
                //Session["pat_log"] = FindUser(email, password);
                //LabelLogInD.Text = (string)Session["pat_log"];
                Response.Redirect("PatDash.aspx");
            }

        }

        protected void readfilebutton_Click(object sender, EventArgs e)
        {
            Deserialise();
        }
    }
}