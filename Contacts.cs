using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager_Application
{
    internal class Contacts
    {
        static List<User> users = new List<User>();

        public static void AddNewUser()
        {
            User user = new User();
            user.ReadInputs();
            users.Add(user);
        }

        public static void EditUser()
        {
            Console.WriteLine("Enter user first name");
            string firstName = Console.ReadLine() ?? "--";
            Console.WriteLine("Enter your last name");
            string lastName = Console.ReadLine() ?? "  ";

            if (UsersCount() == 0)
            {
                Console.WriteLine("No user exists");
                return;
            }

            for (int i = 0; i < users.Count; i++)
            {
                if (firstName == users[i].FirstName && lastName == users[i].LastName)
                {
                    // some logic;
                    users[i].ReadInputs();
                    break;
                }
            }

            Console.WriteLine("User not found");
        }

        public static void DeleteUser()
        {
            Console.WriteLine("Enter user first name");
            string firstName = Console.ReadLine() ?? "--";
            Console.WriteLine("Enter your last name");
            string lastName = Console.ReadLine() ?? "  ";

            if (UsersCount() == 0)
            {
                Console.WriteLine("No user exists");
                return;
            }

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].FirstName == firstName && users[i].LastName ==lastName)
                {
                    users.Remove(users[i]);
                    Console.WriteLine("Done!");
                }
            }

            Console.WriteLine("User Not found!");
        }

        public static void FindAll()
        {
            List<User> found = new List<User>();

            Console.WriteLine("Enter key");
            string key = Console.ReadLine()??"";

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].FindAny(key))
                    found.Add(users[i]);
            }

            if(found.Count == 0)
                Console.WriteLine("there's no such user");

            for (int i = 0; i < found.Count; i++)
                Console.WriteLine(found[i]);
            
        }

        public static void Print()
        {
            if(users.Count == 0)
                Console.WriteLine("No Uers");
            for (int i = 0; i < users.Count; i++)
            {

                Console.WriteLine(users[i]);
            }
        }

        public static int UsersCount()
        {
            return users.Count;
        }
    }
}
