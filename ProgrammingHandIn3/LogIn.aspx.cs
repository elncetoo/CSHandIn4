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
    public partial class LogIn : System.Web.UI.Page
    {

        List<Dentist> dentistslist = new List<Dentist>();
        private static List<Dentist> dentistslistdesr;
        private string filename; // where we store users data

        public string email;
        public string password;

        protected void Page_Load(object sender, EventArgs e)
        {

            /*
            if (Application["DentistList"] == null)
            {
                Application["DentistList"] = new List<Dentist>();
            }

            dentistslist = (List<Dentist>)Application["DentistList"];

              */
        }



        private string FindUser(string email, string password)
        {
            foreach (Dentist dent in dentistslistdesr)
            {
                if (dent.Email == email && dent.Password == password)
                {

                    return email.ToString();
                }
                else

                    //return dent.Email.ToString();
                    return null;

            }
            return email.ToString();
        }


        public void Deserialise()
        {
            filename = Server.MapPath("~/App_Data/dentistslistdata.ser"); //decalring the path to the serializedfile
            dentistslistdesr = new List<Dentist>(); //am creating an instance variable
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None)) //opening afile stream to readfrom the file in the given path
            {
                BinaryFormatter bf = new BinaryFormatter();
                dentistslistdesr = (List < Dentist > ) bf.Deserialize(fs);
                fs.Close();
            }

            mygrid.DataSource = dentistslistdesr;
            mygrid.DataBind();

        }

        protected void ButtonLogIn_Click(object sender, EventArgs e)
        {
            string password = TextBoxPass.Text;
            string email = TextBoxUName.Text;

            if(dentistslistdesr.Count > 0)
            {
                FindUser(email, password);
                Session["dent_log"] = FindUser(email, password);
                //LabelMessageLogIn.Text = (string)Session["dent_log"];
                Response.Redirect("DentDash.aspx");
            }


            //LabelMessageLogIn.Text = FindUser(email, password);

            

        }

        protected void readfilebutton_Click(object sender, EventArgs e)
        {
            Deserialise();
        }
    }
}