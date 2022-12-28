using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Contact_Manager_Application
{
    internal struct Email
    {
        private string email;



        public void SetEmail(string _email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(_email);
            if (match.Success)
                this.email = _email;
        }


        public override string ToString()
        {
            return email + " ";
        }

        public bool IsMatched(Email mail)
        {
            if (email != null && email.CompareTo(mail.ToString()) == 0)
                return true;

            return false;
        }
    }
}
