using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammingHandIn3
{
    [Serializable]
    public abstract class Person
    {
        //making instance fields
        protected string name;
        protected int age;
        protected string password;
        protected string email;
        //protected int social;

        //constructor
        public Person(string name, int age, string password, string email) //, int social
        {
            this.Name = name;
            this.Age = age;
            this.Password = password;
            this.Email = email;
            //this.SocialNr = social;
        }

        // Property
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public virtual void ChangeEmail(string newEmail)
        {
            Email = newEmail;
        }

        public override string ToString()
        {
            return "Patient name: " + this.Name + ", age: " + this.Age + ", Password: " + this.Password + ", email: " + this.Email + ", Social Security Number: "; //+this.SocialNr
        }

    }
}