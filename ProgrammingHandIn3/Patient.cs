using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.IO;

namespace ProgrammingHandIn3
{
    [Serializable]
    public class Patient : Person
    {
        protected int socialnr;

        public Patient(string name, int age, string password, string email, int socialnr) : base(name, age, password, email)
        {
            this.SocialNr = socialnr;
        }

        public int SocialNr
        {
            get { return socialnr; }
            set { socialnr = value; }
        }


        //Method
        public override string ToString()
        {
            return "Name: " + Name + " Age: " + Age + " Email: " + Email + " Password: " + Password + " Social Security Nr: " + SocialNr;
        }

    }
}