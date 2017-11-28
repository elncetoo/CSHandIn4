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
    public partial class UpdatePat : System.Web.UI.Page
    {

        private List<Dentist> dentistslistdesr;
        private List<Patient> patientslistdesr;
        private static string filename;
        private static string filenamed;

        int SelectedPatientIndex;
        //private string emp;

        protected void Page_Load(object sender, EventArgs e)
        {
            Patient emp = (Patient)Session["pat_log"];

            filename = Server.MapPath("~/App_Data/patientslistdata.ser");

            filenamed = Server.MapPath("~/App_Data/dentistslistdata.ser"); //decalring the path to the serializedfile

            LabelPatDash.Text = emp.Name; 
            Deserialise();

            GridViewPatInfo.DataSource = patientslistdesr;
            GridViewPatInfo.DataBind();

            if (!Page.IsPostBack)
            {
                DeserialiseDent();

                List<string> dentistnamelist = new List<string>(); //making new list only with names
                foreach (Dentist d in dentistslistdesr)
                {
                    dentistnamelist.Add(d.Name);
                }

                GridViewDNames.DataSource = dentistnamelist;
                GridViewDNames.DataBind();

                // mygridallp.DataSource = patientslistdesr;
                // mygridallp.DataBind();
                //GridView1.Columns[0].Visible = false;
            }
        }

        public void DeserialiseDent()
        {
            filenamed = Server.MapPath("~/App_Data/dentistslistdata.ser"); //decalring the path to the serializedfile
            dentistslistdesr = new List<Dentist>(); //am creating an instance variable
            using (FileStream fs = new FileStream(filenamed, FileMode.Open, FileAccess.Read, FileShare.None)) //opening afile stream to readfrom the file in the given path
            {
                BinaryFormatter bf = new BinaryFormatter();
                dentistslistdesr = (List<Dentist>)bf.Deserialize(fs);
                fs.Close();
            }
        }

        public void Deserialise()
        {
            //filename = Server.MapPath("~/App_Data/dentistslistdata.ser"); //decalring the path to the serializedfile
            patientslistdesr = new List<Patient>(); //am creating an instance variable
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None)) //opening afile stream to readfrom the file in the given path
            {
                BinaryFormatter bf = new BinaryFormatter();
                patientslistdesr = (List<Patient>)bf.Deserialize(fs);
                fs.Close();

                //GridViewPatInfo.DataSource = patientslistdesr;
                //GridViewPatInfo.DataBind();
            }
        }

        protected void ButtonSaveToFile_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, patientslistdesr);
            fs.Close();

            GridViewPatInfo.DataSource = patientslistdesr;
            GridViewPatInfo.DataBind();

            LabelPatDash.Text = "Dentists list saved to file.";
        }

        protected void ButtonUpdateP_Click(object sender, EventArgs e)
        {
            string name = TextBoxNameP.Text;
            string email = TextBoxEmailP.Text;
            string pass = TextBoxPassP.Text;
            //string age = TextBoxAge.Text;

            Int32.TryParse(TextBoxAgeP.Text, out int age);
            Int32.TryParse(TextBoxSocialNrP.Text, out int socialnr);

            Patient pat = (Patient)Session["pat_log"];
            foreach (Patient p in patientslistdesr) //p is local variable
            {

                if (pat.Email == p.Email)
                {
                    p.Name = name;
                    p.Email = email;
                    p.Password = pass;
                    p.Age = age;
                    p.SocialNr = socialnr;

                    LabelPatDash.Text = "Updated patient: " + p.Name;

                }

            }
            /*  */

            GridViewPatInfo.DataSource = patientslistdesr;
            GridViewPatInfo.DataBind();
        }

        protected void ButtonDelP_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);
            BinaryFormatter bf = new BinaryFormatter();
            List<Patient> pl = (List<Patient>)bf.Deserialize(fs);
            fs.Close();

            LabelPatDash.Text = "Patient deleted.";
            Patient p = (Patient)Session["pat_log"];

            foreach (Patient pat in pl)
            {
                if (p.Email == pat.Email && p.Password == pat.Password)
                {
                    pl.Remove(pat);
                    break;
                }
            }

            // write to file
            fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            bf = new BinaryFormatter();
            bf.Serialize(fs, pl);
            fs.Close();

            // clear session
            Session["pat_log"] = null;
            Session.Clear();

            // rediretto login page
            Response.Redirect("HomePage.aspx");

            /*
            int selected = GridViewPatInfo.SelectedIndex;
            patientslistdesr.RemoveAt(selected);

            LabelPatDash.Text = "Patient deleted.";
            Patient p = (Patient)Session["pat_log"];
            int index = -1;

            foreach (Patient pat in patientslistdesr)
            {
                index++;

                if (p.Email == pat.Email && p.Password == pat.Password)
                {
                    Session["pat_log"] = pat;
                    //int selected = GridViewPatInfo.SelectedIndex;
                    patientslistdesr.RemoveAt(index);
                    // return email.ToString();
                }
                // else

                //return dent.Email.ToString();

            }

            //Patient sesspat = (Patient)Session["pat_log"];

            GridViewPatInfo.DataSource = patientslistdesr;
            GridViewPatInfo.DataBind();

            */
        }
    }
}