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
    public partial class Patients : System.Web.UI.Page
    {
        List<Patient> patientslist = new List<Patient>();
        int SelectedPatientIndex; //so we can select the field for update later
        private string filename; // where we store users data

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            {
                Application["SelectedPatient"] = null;
                MessagePatientForm.Text = (string)Application["SelectedPatient"];
            }

            filename = Server.MapPath("~/App_Data/patientslistdata.ser");

            if (Application["PatientList"] == null) 
            {
                Application["PatientList"] = new List<Patient>(); //makes a new list of patients that is empty
            }

            patientslist = (List<Patient>)Application["PatientList"];

            UpdatePatientsGridView();

        }

        private void UpdatePatient() 
        {
            foreach (Patient pat in (List<Patient>)Application["PatientList"])
            {
                //creating a variable for each new dentist inthe application
                patientslist.Add(pat);
            }

            for (int i = 0; i < patientslist.Count(); i++)
            {
                if (i == Convert.ToInt32(Application["SelectedPatient"]))
                {
                    Patient pat = patientslist[i];
                    TextBoxPatientName.Text = pat.Name;
                    TextBoxPatientAge.Text = pat.Age.ToString();
                    TextBoxPatientPassword.Text = pat.Password;
                    TextBoxPatientEmail.Text = pat.Email;
                    TextBoxPatientSocialNr.Text = pat.SocialNr.ToString();
                }
            }
        }

        public void UpdatePatientsGridView()
        {
            PatientsGridView.DataSource = patientslist; 
            PatientsGridView.DataBind();
        }

        protected void ButtonAddPatientList_Click(object sender, EventArgs e)
        {
            Patient pat = new Patient(TextBoxPatientName.Text, Int32.Parse(TextBoxPatientAge.Text), TextBoxPatientPassword.Text, TextBoxPatientEmail.Text, Int32.Parse(TextBoxPatientSocialNr.Text));

            Application.Lock();
            patientslist = (List<Patient>)Application["PatientList"];
            patientslist.Add(pat);
            Application["PatientList"] = patientslist;
            Application.UnLock();

            TextBoxPatientName.Text = "";
            TextBoxPatientAge.Text = "";
            TextBoxPatientPassword.Text = "";
            TextBoxPatientEmail.Text = "";
            TextBoxPatientSocialNr.Text = "";

            UpdatePatientsGridView();
            MessagePatientForm.Text = "Patient added to Patients list";
        }

        protected void ButtonReadPatientFile_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);
            BinaryFormatter bf = new BinaryFormatter();
            patientslist = (List<Patient>)bf.Deserialize(fs);
            fs.Close();

            Application.Lock();
            Application["PatientList"] = patientslist;
            Application.UnLock();

            UpdatePatientsGridView();
            MessagePatientForm.Text = "Now reading patients from file.";
        }

        protected void ButtonSavePatientFile_Click(object sender, EventArgs e)
        {
            patientslist = (List<Patient>)Application["PatientList"];

            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, patientslist);
            fs.Close();

            UpdatePatientsGridView();
            MessagePatientForm.Text = "Patient list saved to file.";
        }

        protected void ButtonDeleteSelectedPatient_Click(object sender, EventArgs e)
        {
            int selected = PatientsGridView.SelectedIndex;
            patientslist.RemoveAt(selected);

            UpdatePatientsGridView();
            MessagePatientForm.Text = "Patient deleted.";
        }

        protected void PatientsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxPatientName.Text = PatientsGridView.SelectedRow.Cells[2].Text; 
            TextBoxPatientAge.Text = PatientsGridView.SelectedRow.Cells[3].Text;
            TextBoxPatientPassword.Text = PatientsGridView.SelectedRow.Cells[4].Text;
            TextBoxPatientEmail.Text = PatientsGridView.SelectedRow.Cells[5].Text;
            TextBoxPatientSocialNr.Text = PatientsGridView.SelectedRow.Cells[1].Text;

            ButtonUpdateSelectedPatient.Enabled = true;

            GridViewRow row = PatientsGridView.SelectedRow;

            SelectedPatientIndex = PatientsGridView.SelectedIndex;
            Application["SelectedPatient"] = SelectedPatientIndex;
            MessagePatientForm.Text = "Selected patient: " + PatientsGridView.SelectedRow.Cells[2].Text;

            UpdatePatientsGridView();
            MessageNewFormPat.Text = "";
        }

        protected void ButtonUpdateSelectedPatient_Click(object sender, EventArgs e)
        {
            string name = TextBoxPatientName.Text;
            Int32.TryParse(TextBoxPatientAge.Text, out int age);
            string password = TextBoxPatientPassword.Text;
            string email = TextBoxPatientEmail.Text;
            Int32.TryParse(TextBoxPatientSocialNr.Text, out int socialnr);

            for (int i = 0; i < patientslist.Count(); i++)
            {
                if (i == Convert.ToInt32(Application["SelectedPatient"]))
                {
                    Patient pat = patientslist[i];
                    pat.Name = name;
                    pat.Age = age;
                    pat.Password = password;
                    pat.Email = email;
                    pat.SocialNr = socialnr;

                    Application.Lock();
                    patientslist = (List<Patient>)Application["PatientList"];
                    Application["PatientList"] = patientslist;
                    Application.UnLock();

                    UpdatePatientsGridView();
                    MessagePatientForm.Text = "Patient updated to Patients list";
                }
            }
        }
                
    }
}