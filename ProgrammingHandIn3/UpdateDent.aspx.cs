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
    public partial class UpdateDent : System.Web.UI.Page
    {
        //private static List<Dentist> dentistslist;
        private List<Dentist> dentistslistdesr;

        List<Patient> patientslist = new List<Patient>();
        private static List<Patient> patientslistdesr; //for the patients gridview
        private static string filename;
        int SelectedPatientIndex;

        private string em;


        protected void Page_Load(object sender, EventArgs e)
        {
            em = (string)Session["dent_log"];

            filename = Server.MapPath("~/App_Data/dentistslistdata.ser");

            LabelUpdate.Text = em;

            if (!Page.IsPostBack)
            {
                Deserialise();

                mygrid.DataSource = dentistslistdesr;
                mygrid.DataBind();



                List<string> dentistnamelist = new List<string>(); //making new list only with names
                foreach (Dentist d in dentistslistdesr)
                {
                    dentistnamelist.Add(d.Name);
                }

                GridView1.DataSource = dentistnamelist;
                GridView1.DataBind();

                // mygridallp.DataSource = patientslistdesr;
                // mygridallp.DataBind();
                //GridView1.Columns[0].Visible = false;
            }
        }


        //for patients
        public void DeserialisePat()
        {
            filename = Server.MapPath("~/App_Data/patientslistdata.ser"); //decalring the path to the serializedfile
            patientslistdesr = new List<Patient>(); //am creating an instance variable
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None)) //opening afile stream to readfrom the file in the given path
            {
                BinaryFormatter bf = new BinaryFormatter();
                patientslistdesr = (List<Patient>)bf.Deserialize(fs);
                fs.Close();
            }

            mygridallp.DataSource = patientslistdesr;
            mygridallp.DataBind();

        }

        public void Deserialise()
        {
            //filename = Server.MapPath("~/App_Data/dentistslistdata.ser"); //decalring the path to the serializedfile
            dentistslistdesr = new List<Dentist>(); //am creating an instance variable
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None)) //opening afile stream to readfrom the file in the given path
            {
                BinaryFormatter bf = new BinaryFormatter();
                dentistslistdesr = (List<Dentist>)bf.Deserialize(fs);
                fs.Close();
            }
        }
        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            string name = TextBoxName.Text;
            string email = TextBoxEmail.Text;
            string pass = TextBoxPass.Text;
            //string age = TextBoxAge.Text;

            Int32.TryParse(TextBoxAge.Text, out int age);
            Int32.TryParse(TextBoxSocialNr.Text, out int socialnr);

            foreach (Dentist d in dentistslistdesr) //d is local variqble
            {
                if (d.Email == em)
                {
                    d.Name = name;
                    d.Email = email;
                    d.Password = pass;
                    d.Age = age;
                    d.SocialNr = socialnr;

                    LabelUpdate.Text = "Updated dentist: " + d.Email;


                    Session["dent_log"] = email;
                }

            }


            mygrid.DataSource = dentistslistdesr;
            mygrid.DataBind();
        }

        protected void ButtonSaveDentist_Click(object sender, EventArgs e)
        {
            //dentistslistdesr = (List<Dentist>)Application["DentistList"];

            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, dentistslistdesr);
            fs.Close();

            mygrid.DataSource = dentistslistdesr;
            mygrid.DataBind();

            LabelUpdate.Text = "Dentists list saved to file.";
        }

        protected void ButtonReadPatientFile_Click(object sender, EventArgs e)
        {
            DeserialisePat();
            MessagePatientForm.Text = "Now reading patients from file.";
        }

        protected void ButtonDelD_Click(object sender, EventArgs e)
        {
            int selected = mygrid.SelectedIndex;
            dentistslistdesr.RemoveAt(selected);

            LabelStatusD.Text = "Patient deleted.";
            Dentist d = (Dentist)Session["dent_log"];
            int index = -1;

            foreach (Dentist dent in dentistslistdesr)
            {
                index++;

                if (d.Email == dent.Email && d.Password == dent.Password)
                {
                    Session["dent_log"] = dent;
                    //int selected = GridViewPatInfo.SelectedIndex;
                    dentistslistdesr.RemoveAt(index);
                    // return email.ToString();
                }
                // else

                //return dent.Email.ToString();

            }
        }
    }

}