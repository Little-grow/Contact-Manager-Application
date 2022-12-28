
using System.Collections.Generic;
using System.Data;

namespace Contact_Manager_Application
{
    internal class User
    {
        long Id = 100;
        DateTime addedDate;
        List<Phone> phones = new List<Phone>();
        List<Email> emails = new List<Email>();
        List<Address> addresses = new List<Address>();

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? City { get; set; }

        public User()
        {
            Id = GetHashCode();
            addedDate = DateTime.Now;
        }

        public void ReadInputs()
        {
            Console.WriteLine("Enter user information");

            Console.WriteLine("Enter first Name");
            FirstName = Console.ReadLine()??"----";
            Console.WriteLine("Enter last Name");
            LastName = Console.ReadLine() ?? "---";

            Console.WriteLine("Enter Gender \'m\' or \'f\' ");
            Gender = Console.ReadLine() ?? "m";

            Console.WriteLine("Enter city");
            City = Console.ReadLine()??"Cairo";

           
            Console.WriteLine("Enter the number of phone numbers you wanna add");
            int n = 1;
            bool ok  = int.TryParse(Console.ReadLine(),out n);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter phone number");
                Phone phone = new Phone();
                phone.PhoneNumber = Console.ReadLine();
                AddPhoneNumber(phone);
            }

            Console.WriteLine("Enter the number of emails");
            n = 1;
            ok = int.TryParse(Console.ReadLine(), out n);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter your mail");
                Email email = new Email();
                string mail = Console.ReadLine()??"---";
                email.SetEmail(mail);
                AddEmail(email);
            }

            Console.WriteLine("Enter the number of addresses");
            n = 1;
            ok = int.TryParse(Console.ReadLine(), out n);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter address");
                Address address = new Address();
                address.Place = Console.ReadLine()??"---";
                AddAddress(address);
            }
        }

        
        public override string ToString()
        {
            string user = "";
            user += $"User Name: {FirstName??"--"} {LastName??"  "}\n";

            string UserPhones = string.Concat(phones); // to group all the phones 
            user +="User Phones " +UserPhones +"\n";

            string UserAddresses = string.Concat(addresses);
            user += "User addresses "+UserAddresses+'\n';

            string UserEmails = string.Concat(emails);
            user += "User Emails " + UserEmails + '\n';

            user += "User city " + City??"---";
            
            return user;
        }

        /*
         * the add, edit, delete method may be better if be generic 
         * it need some thinking to implement 
         */
        private void AddPhoneNumber(Phone phone)
        {
            phones.Add(phone);
        }
        public void EditPhoneNumber(Phone phone)
        {
            for (int i = 0; i < phones.Count; i++)
            {
                if (phone.IsMatched(phones[i]))
                {
                    Console.WriteLine("Enter the new phone number");
                    string? phoneNumebr = Console.ReadLine();
                    phone.PhoneNumber = phoneNumebr;
                    Console.WriteLine("Done!");
                    break;
                }
            }
            Console.WriteLine("Not found!");
        }
        public void DeletePhoneNumber(Phone phone)
        {
            for (int i = 0; i < phones.Count; i++)
            {
                if (phone.IsMatched(phones[i]))
                {
                    phones.Remove(phone);
                    Console.WriteLine("Done!");
                    break;
                }
            }
            Console.WriteLine("Not found!");
        }

        private void AddEmail(Email email)
        {
            emails.Add(email);
        }
        public void EditEmail(Email email)
        {
            for (int i = 0; i < emails.Count; i++)
            {
                if (email.IsMatched(emails[i]))
                {
                    Console.WriteLine("Enter the new mail");
                    string? mail = Console.ReadLine();
                    email.SetEmail(mail);
                    Console.WriteLine("Done!");
                    break;
                }
            }
            Console.WriteLine("Not found!");
        }
        public void DeleteEmail(Email email)
        {
            for (int i = 0; i < emails.Count; i++)
            {
                if (email.IsMatched(emails[i]))
                {
                    emails.Remove(email);
                    Console.WriteLine("Done!");
                }
            }
            Console.WriteLine("Not found!");
        }

        private void AddAddress(Address address)
        {
            addresses.Add(address);
        }
        public void EditAddress(Address address)
        {
            for (int i = 0; i < addresses.Count; i++)
            {
                if (address.IsMatched(addresses[i]))
                {
                    Console.WriteLine("Enter the new address place");
                    string adrs = Console.ReadLine();
                    address.Place = adrs;
                    Console.WriteLine("Done!");
                }
            }
            Console.WriteLine("Not found!");
        }
        public void DeleteAddress(Address address)
        {
            for (int i = 0; i < addresses.Count; i++)
            {
                if (address.IsMatched(addresses[i]))
                {
                    addresses.Remove(addresses[i]);
                    Console.WriteLine("Done!");
                    break;
                }
            }
            Console.WriteLine("Not found!");
        }

        public bool FindAny(string key) // stupid method
        {
            if (FirstName == key || LastName == key)
                return true;

            if (phones.Count > 0)
            {
                for (int i = 0; i < phones.Count; i++)
                {
                    Phone phone = new Phone();
                    phone.PhoneNumber = key;
                    if (phones[i].IsMatched(phone))
                        return true;
                }
            }

            if(emails.Count > 0)
            {
                for (int i = 0; i < emails.Count; i++)
                {
                    Email email = new Email();
                    email.SetEmail(key);
                    if (emails[i].IsMatched(email))
                        return true;
                }
            }
                
            if (addresses.Count > 0)
            {
                for (int i = 0; i < addresses.Count; i++)
                {
                    Address address = new Address();
                    address.Place = key;
                    if (addresses[i].IsMatched(address))
                        return true;
                }
            }

            if (City == key)
                return true;

            if (Gender == key)
                return true;

            return false;
        }
    }
}