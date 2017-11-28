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
    public partial class Dentists : System.Web.UI.Page
    {
        List<Dentist> dentistslist = new List<Dentist>();
        int SelectedDentistIndex; //so we can select the field for update it later
        private string filename; // where we store users data

        protected void Page_Load(object sender, EventArgs e)
        {   
            if (!Page.IsPostBack) 
            {
                Application["SelectedDentist"] = null;
                MessageNewFormDent.Text = (string)Application["SelectedDentist"];
            }

            filename = Server.MapPath("~/App_Data/dentistslistdata.ser");

            if (Application["DentistList"] == null) 
            {
                Application["DentistList"] = new List<Dentist>();
            }

            dentistslist = (List<Dentist>)Application["DentistList"];

            UpdateDentistGridView();
        }

        public void UpdateDentistGridView()
        {
            DentistsGridView.DataSource = dentistslist; 
            DentistsGridView.DataBind();
        }

        private void UpdateDentist() 
        {

            foreach (Dentist dent in (List<Dentist>)Application["DentistList"])
            {
                //creating a variable for each new dentist in the application
                dentistslist.Add(dent);
            }

            for (int i = 0; i < dentistslist.Count(); i++)
            {
                if (i == Convert.ToInt32(Application["SelectedDentist"]))
                {
                    Dentist dent = dentistslist[i];
                    TextBoxCRDName.Text = dent.Name;
                    TextBoxCRDAge.Text = dent.Age.ToString();
                    TextBoxCRDPass.Text = dent.Password;
                    TextBoxCRDEmail.Text = dent.Email;
                    TextBoxCRDSocialNr.Text = dent.SocialNr.ToString();
                }
            }
            
        }
       
        protected void DentistsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxCRDName.Text = DentistsGridView.SelectedRow.Cells[2].Text;
            TextBoxCRDAge.Text = DentistsGridView.SelectedRow.Cells[3].Text;
            TextBoxCRDPass.Text = DentistsGridView.SelectedRow.Cells[4].Text;
            TextBoxCRDEmail.Text = DentistsGridView.SelectedRow.Cells[5].Text;
            TextBoxCRDSocialNr.Text = DentistsGridView.SelectedRow.Cells[1].Text;

            GridViewRow row = DentistsGridView.SelectedRow;

            SelectedDentistIndex = DentistsGridView.SelectedIndex;
            Application["SelectedDentist"] = SelectedDentistIndex;
            MessageDentistForm.Text = "Selected dentist: " + DentistsGridView.SelectedRow.Cells[2].Text;

            ButtonUpdateSelectedDentist.Enabled = true;

            UpdateDentistGridView();
            MessageNewFormDent.Text = "";

        }

        protected void ButtonCRNewDentist_Click(object sender, EventArgs e)
        {
            Dentist dent = new Dentist(TextBoxCRDName.Text, Int32.Parse(TextBoxCRDAge.Text), TextBoxCRDPass.Text, TextBoxCRDEmail.Text, Int32.Parse(TextBoxCRDSocialNr.Text));

            Application.Lock();
            dentistslist = (List<Dentist>)Application["DentistList"];
            dentistslist.Add(dent);
            Application["DentistList"] = dentistslist;
            Application.UnLock();

            TextBoxCRDName.Text = "";
            TextBoxCRDAge.Text = "";
            TextBoxCRDPass.Text = "";
            TextBoxCRDEmail.Text = "";
            TextBoxCRDSocialNr.Text = "";
            UpdateDentistGridView();

            MessageDentistForm.Text = "Dentist added to dentists list";
        }

        protected void ButtonDeleteSelectedDentist_Click(object sender, EventArgs e)
        {
            int selected = DentistsGridView.SelectedIndex;
            dentistslist.RemoveAt(selected);

            UpdateDentistGridView();
            MessageDentistForm.Text = "Dentist deleted from dentists list.";
        }

        protected void ButtonReadDentistFile_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);
            BinaryFormatter bf = new BinaryFormatter();
            dentistslist = (List<Dentist>)bf.Deserialize(fs);
            fs.Close();

            Application.Lock();
            Application["DentistList"] = dentistslist;
            Application.UnLock();

            UpdateDentistGridView();
            MessageDentistForm.Text = "Now reading dentists from a file.";
        }

        protected void ButtonSaveDentistFile_Click1(object sender, EventArgs e)
        {
            dentistslist = (List<Dentist>)Application["DentistList"];

            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, dentistslist);
            fs.Close();

            UpdateDentistGridView();
            MessageDentistForm.Text = "Dentists list saved to file.";
        }

        protected void ButtonUpdateSelectedDentist_Click(object sender, EventArgs e)
        {
            string name = TextBoxCRDName.Text;
            Int32.TryParse(TextBoxCRDAge.Text, out int age);
            string password = TextBoxCRDPass.Text;
            string email = TextBoxCRDEmail.Text;
            Int32.TryParse(TextBoxCRDSocialNr.Text, out int socialnr);

            for (int i = 0; i < dentistslist.Count(); i++)
            {
                if (i == Convert.ToInt32(Application["SelectedDentist"]))
                {
                    Dentist dent = dentistslist[i];

                    dent.Name = name;
                    dent.Age = age;
                    dent.Password = password;
                    dent.Email = email;
                    dent.SocialNr = socialnr;

                    Application.Lock();
                    dentistslist = (List<Dentist>)Application["DentistList"];
                    Application["DentistList"] = dentistslist;
                    Application.UnLock();

                    UpdateDentistGridView();
                    MessageNewFormDent.Text = "Dentist updated to dentists list";

                }
            }

        }

      
    }
}
 