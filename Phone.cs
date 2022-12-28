using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager_Application
{
    internal struct Phone
    {
        public string? PhoneNumber { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }

        public override string ToString()
        {
            string phone = $"{PhoneNumber}\t";
            return phone;
        }

        internal bool IsMatched(Phone phone)
        {
            if (PhoneNumber != null && PhoneNumber.CompareTo(phone.PhoneNumber) == 0)
                return true;
            return false;
        }
    }
}
