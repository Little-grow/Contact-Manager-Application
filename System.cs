using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Contact_Manager_Application
{
    internal class System
    {
       static void Menu()
        { 
                Console.WriteLine("_________________________________________");
                Console.WriteLine("1. print all users");
                Console.WriteLine("2. Add users");
                Console.WriteLine("3. Search");
                Console.WriteLine("4. Edit Existing User");
                Console.WriteLine("5. Delete Existing User");
                Console.WriteLine("0. Quit");
                Console.WriteLine("_________________________________________\n");
        }
       static void Close()
        {
            Environment.Exit(1);
        }

       public static void Run()
        {
            Menu();
            while (true)
            {
                Console.WriteLine("Enter Your Choice: ");
                int choice = int.Parse(Console.ReadLine());
                Dictionary<int, Action> process = new Dictionary<int, Action>
                {
                    {0, Close},
                    {1, Contacts.Print},
                    {2, Contacts.AddNewUser},
                    {3, Contacts.FindAll},
                    {4, Contacts.EditUser},
                    {5, Contacts.DeleteUser}
                };
                process[choice]();
            }
        }
    }
}
