using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.DAL.Modules;

namespace CarService.DAL
{       
    public class ChangeStatus
    {
        public static void changeStatus()
        {
            Generator gen = new Generator();

            List<Project> projects = null;

            string message;

            if (!gen.GenerateProject(ref projects, out message))
            {
                Console.WriteLine("Project already exists");
                return;
            }
            else
            {
                Console.WriteLine("*************************");
                Console.WriteLine(message);
                Console.WriteLine("*************************");
            }
            foreach (Project item in projects)
            {
                item.PrintInfo();
            }

            Console.WriteLine("\n\n\nChoose the project: ");
            foreach (var item in projects)
            {
                Console.WriteLine(" - " + item.projectName);
            }

            Project temp = null;
            do
            {
                Console.Write("-> ");
                string name = Console.ReadLine();
                temp = projects.FirstOrDefault(o => o.projectName.ToLower() == name.ToLower());
                if (temp != null)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("**************************");
                    Console.WriteLine("\n CHOSEN PROJECT VEHICLES: \n");
                    Console.WriteLine("**************************");
                    temp.PrintInfo();
                    break;
                }
                else{
                    Console.WriteLine("Project not found!");
                    }
               
            }
            while (temp == null);

            Console.WriteLine("\n\n\nChoose search option: 1 - by state number, 2 - by model");

            int choice = 0;
            do
            {
                Console.Write("-> ");
                Int32.TryParse(Console.ReadLine(), out choice);
            }
            while (choice != 1 && choice != 2);

            int stateNumber = 0;
            string vehicleModel = "";
            Service service = new Service();

            Vehicle findVehicle = null;

            switch (choice)
            {
                case 1:
                    {
                        Console.Clear();
                        temp.PrintInfo();
                        Console.WriteLine("\n\n\nEnter the state number:");
                        Int32.TryParse(Console.ReadLine(), out stateNumber);
                        findVehicle = service.Search(temp, stateNumber);
                    }
                    break;
                case 2:
                    {
                        Console.Write("\n\n\nEnter the vehicle model:");
                        findVehicle = service.Search(temp, Console.ReadLine());
                    }
                    break;
            }
            if (findVehicle == null)
                Console.WriteLine("Vehicle not found");
            else
                Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("*****************************************");
            Console.WriteLine("\n CHOSEN VEHICLE: \n");
            Console.WriteLine("*****************************************");
            findVehicle.PrintInfo();

            //Console.WriteLine("Choose part to be installed: ")
            //    do
            //{
            //    Console.ReadLine().ToString();
            //}

            
            Console.WriteLine("\n\n\nChange car status: 1 - to Active, 2 - to Inactive");
            do
            {
                Int32.TryParse(Console.ReadLine(), out choice);
            } while (choice != 1 && choice != 2);
            if(choice == 1)
            {
                Console.Clear();
                projects.First(t => t == temp).Vehicles.First(o => o == findVehicle).vehicleStatus = VehicleStatus.Active;
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("*****************************************");
                Console.WriteLine("\n CHOSEN VEHICLE STATUS CHANGED TO ACTIVE: \n");
                Console.WriteLine("*****************************************");
                findVehicle.PrintInfo();
            }
            else if (choice == 2)
            {
                Console.Clear();
                projects.First(t => t == temp).Vehicles.First(o => o == findVehicle).vehicleStatus = VehicleStatus.Inactive;
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("********************************************");
                Console.WriteLine("\n CHOSEN VEHICLE STATUS CHANGED TO INACTIVE: \n");
                Console.WriteLine("********************************************");
                findVehicle.PrintInfo(); 
            }
        }
    }
}
