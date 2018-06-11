using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.DAL;
using System.Collections;

namespace CarService.DAL.Menu
{
    public class User
    {
        public string login { get; set; }
        public string password { get; set; } 

        public void LogInAsUser()
        {
            string login = "";
            string password = "";
            Dictionary<string, string> LoginPassword = new Dictionary<string, string>();
            LoginPassword.Add("Alfar", "1234");
            LoginPassword.Add("Maxim", "2345");
            LoginPassword.Add("Ulan", "3456");
            //Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter login: ");
            //Console.ForegroundColor = ConsoleColor.White;
            login = Console.ReadLine();
            //Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter password: ");
            //Console.ForegroundColor = ConsoleColor.White;
            password = Console.ReadLine();
            if (LoginPassword.Where(o => o.Key == login && o.Value == password).Count() > 0)
            {
                Console.Clear();
                ShowInfo show = new ShowInfo();
                show.showInfo();
            }
            else
            {
                //Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("wrong login or password...");
            }
           // foreach (KeyValuePair<string, string> v in LoginPassword)
           // {
           //     Console.WriteLine($"-> Users: <- \n Login:\t {login}\n Password:\t {password}");
           // }
        }
    }
  }


