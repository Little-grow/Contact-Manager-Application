using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager_Application
{
    internal struct Address
    {
        public string? Place { get; set; }
        public string? Type { private get; set; }
        public string? Description { private get; set; }


        public override string ToString() // to get the Adrress
        {
            string address = "";
            address += $"{Place}\t";

            if(Type!= null)
                address += $"{Type}\t";
            if(Description!=null)
                address += $"{Description}\t";

            return address;
        }

        internal bool IsMatched(Address address)
        {
            if (Place != null && address.Place.CompareTo(Place) == 0)
                return true;
            return false;
        }
    }
}
