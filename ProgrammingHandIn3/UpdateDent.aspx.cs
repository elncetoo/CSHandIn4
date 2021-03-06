﻿using System;
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
        private List<Dentist> dentistslistdesr;

        List<Patient> patientslist = new List<Patient>();
        private List<Patient> patientslistdesr; //for the patients gridview
        private static string filename;
        int SelectedPatientIndex;
        //private string em;

        protected void Page_Load(object sender, EventArgs e)
        {
            //em = (string)Session["dent_log"];
            Dentist em = (Dentist)Session["dent_log"];

            filename = Server.MapPath("~/App_Data/dentistslistdata.ser");

            LabelUpdate.Text = em.Name;

            if (!Page.IsPostBack)
            {
                Deserialise();

                mygrid.DataSource = dentistslistdesr;
                mygrid.DataBind();


                
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
            //dentistslistdesr = new List<Dentist>(); //am creating an instance variable
            //using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None)) //opening afile stream to readfrom the file in the given path
            //{
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);
                BinaryFormatter bf = new BinaryFormatter();
                dentistslistdesr = (List<Dentist>)bf.Deserialize(fs);
                fs.Close();
            //}
        }
        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            Deserialise();
            string name = TextBoxName.Text;
            string email = TextBoxEmail.Text;
            string pass = TextBoxPass.Text;
            Int32.TryParse(TextBoxAge.Text, out int age);
            Int32.TryParse(TextBoxSocialNr.Text, out int socialnr);

            Dentist dent = (Dentist)Session["dent_log"];

            foreach (Dentist d in dentistslistdesr) //d is local variqble
            {
                if (dent.Email == d.Email)
                {
                    d.Name = name;
                    d.Email = email;
                    d.Password = pass;
                    d.Age = age;
                    d.SocialNr = socialnr;

                    LabelUpdate.Text = "Updated dentist: " + d.Name;

                    //Session["dent_log"] = email;
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

            //Session["dent_log"] = dent;

            //int selected = mygrid.SelectedIndex;
            //dentistslistdesr.RemoveAt(selected);
            //Deserialise();
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);
            BinaryFormatter bf = new BinaryFormatter();
            List<Dentist> dl = (List<Dentist>)bf.Deserialize(fs);
            fs.Close();

            LabelStatusD.Text = "Dentist deleted.";
            Dentist d = (Dentist)Session["dent_log"];
                        
            foreach (Dentist dent in dl)
            {
                if (d.Email == dent.Email && d.Password == dent.Password)
                {
                    dl.Remove(dent);
                    break;
                }
            }

            // write to file
            fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            bf = new BinaryFormatter();
            bf.Serialize(fs, dl);
            fs.Close();

            // clear session
            Session["dent_log"] = null;
            Session.Clear();

            // rediretto login page
             Response.Redirect("HomePage.aspx");
        }
    }

}