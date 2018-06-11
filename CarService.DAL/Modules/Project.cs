using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DAL.Modules
{
    public class Project
    {
        public string projectName { get; set; }
        public List<Vehicle> Vehicles = new List<Vehicle>();

        public void PrintInfo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Project : {0}", projectName);

            foreach (Vehicle item in Vehicles)
            {
                Console.WriteLine("======================================");
                item.PrintInfo();
            }
        }
    }
}
