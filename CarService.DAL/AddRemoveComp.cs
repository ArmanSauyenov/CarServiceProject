using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.DAL.Modules;

namespace CarService.DAL
{
    public class AddRemoveComp
    {
        public static void addRemoveComp()
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
                else
                {
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

            Console.WriteLine("\n\n\nChange car parts: 1 - to change part, 2 - to remove part");
            do
            {
                Int32.TryParse(Console.ReadLine(), out choice);
            }
            while (choice != 1 && choice != 2);
            if (choice == 1)
            {
                Console.Clear();
                Console.WriteLine("\n\n\nChoose component:  Engine = 1, Transmission = 2, Tire = 3, Brake = 4, Window = 5, Door = 6, Seat = 7, Trunk = 8, Rims = 9, EngineOil = 10, TransmissionOil = 11, BreaksOil = 12");
                Int32.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        {
                            for (int i = 0; i <3; i++)
                            {
                                Console.Clear();
                                projects.First(t => t == temp).Vehicles.First(t => t == findVehicle).spareParts = Parts.Engine;
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine("***********************************************************");
                                Console.WriteLine("\n CHOSEN VEHICLE COMPONENT TO BE FIXED CHANGED TO ENGINE: \n");
                                Console.WriteLine("***********************************************************");
                                findVehicle.PrintInfo();
                                Console.WriteLine();
                            }
                        }
                        break;
                    case 2:
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                Console.Clear();
                                projects.First(t => t == temp).Vehicles.First(t => t == findVehicle).spareParts = Parts.Transmission;
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine("*****************************************************************");
                                Console.WriteLine("\n CHOSEN VEHICLE COMPONENT TO BE FIXED CHANGED TO TRANSMISSION: \n");
                                Console.WriteLine("*****************************************************************");
                                findVehicle.PrintInfo();
                                Console.WriteLine();
                            }
                        }
                        break;
                    case 3:
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                Console.Clear();
                                projects.First(t => t == temp).Vehicles.First(t => t == findVehicle).spareParts = Parts.Tire;
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine("*********************************************************");
                                Console.WriteLine("\n CHOSEN VEHICLE COMPONENT TO BE FIXED CHANGED TO TIRE: \n");
                                Console.WriteLine("*********************************************************");
                                findVehicle.PrintInfo();
                                Console.WriteLine();
                            }
                        }
                        break;
                    case 4:
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                Console.Clear();
                                projects.First(t => t == temp).Vehicles.First(t => t == findVehicle).spareParts = Parts.Brake;
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine("**********************************************************");
                                Console.WriteLine("\n CHOSEN VEHICLE COMPONENT TO BE FIXED CHANGED TO BRAKE: \n");
                                Console.WriteLine("**********************************************************");
                                findVehicle.PrintInfo();
                                Console.WriteLine();
                            }
                        }
                        break;
                    case 5:
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                Console.Clear();
                                projects.First(t => t == temp).Vehicles.First(t => t == findVehicle).spareParts = Parts.Window;
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine("***********************************************************");
                                Console.WriteLine("\n CHOSEN VEHICLE COMPONENT TO BE FIXED CHANGED TO WINDOW: \n");
                                Console.WriteLine("***********************************************************");
                                findVehicle.PrintInfo();
                                Console.WriteLine();
                            }
                        }
                        break;
                    case 6:
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                Console.Clear();
                                projects.First(t => t == temp).Vehicles.First(t => t == findVehicle).spareParts = Parts.Door;
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine("*********************************************************");
                                Console.WriteLine("\n CHOSEN VEHICLE COMPONENT TO BE FIXED CHANGED TO DOOR: \n");
                                Console.WriteLine("*********************************************************");
                                findVehicle.PrintInfo();
                                Console.WriteLine();
                            }
                        }
                        break;
                    case 7:
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                Console.Clear();
                                projects.First(t => t == temp).Vehicles.First(t => t == findVehicle).spareParts = Parts.Seat;
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine("*********************************************************");
                                Console.WriteLine("\n CHOSEN VEHICLE COMPONENT TO BE FIXED CHANGED TO SEAT: \n");
                                Console.WriteLine("*********************************************************");
                                findVehicle.PrintInfo();
                                Console.WriteLine();
                            }
                        }
                        break;
                    case 8:
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                Console.Clear();
                                projects.First(t => t == temp).Vehicles.First(t => t == findVehicle).spareParts = Parts.Trunk;
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine("**********************************************************");
                                Console.WriteLine("\n CHOSEN VEHICLE COMPONENT TO BE FIXED CHANGED TO TRUNK: \n");
                                Console.WriteLine("**********************************************************");
                                findVehicle.PrintInfo();
                                Console.WriteLine();
                            }
                        }
                        break;
                    case 9:
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                Console.Clear();
                                projects.First(t => t == temp).Vehicles.First(t => t == findVehicle).spareParts = Parts.Rims;
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine("*********************************************************");
                                Console.WriteLine("\n CHOSEN VEHICLE COMPONENT TO BE FIXED CHANGED TO RIMS: \n");
                                Console.WriteLine("*********************************************************");
                                findVehicle.PrintInfo();
                                Console.WriteLine();
                            }
                        }
                        break;
                    case 10:
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                Console.Clear();
                                projects.First(t => t == temp).Vehicles.First(t => t == findVehicle).spareParts = Parts.EngineOil;
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine("***************************************************************");
                                Console.WriteLine("\n CHOSEN VEHICLE COMPONENT TO BE FIXED CHANGED TO ENGINE OIL: \n");
                                Console.WriteLine("***************************************************************");
                                findVehicle.PrintInfo();
                                Console.WriteLine();
                            }
                        }
                        break;
                    case 11:
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                Console.Clear();
                                projects.First(t => t == temp).Vehicles.First(t => t == findVehicle).spareParts = Parts.TransmissionOil;
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine("*********************************************************************");
                                Console.WriteLine("\n CHOSEN VEHICLE COMPONENT TO BE FIXED CHANGED TO TRANSMISSION OIL: \n");
                                Console.WriteLine("*********************************************************************");
                                findVehicle.PrintInfo();
                                Console.WriteLine();
                            }
                        }
                        break;
                    case 12:
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                Console.Clear();
                                projects.First(t => t == temp).Vehicles.First(t => t == findVehicle).spareParts = Parts.BreaksOil;
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine("***************************************************************");
                                Console.WriteLine("\n CHOSEN VEHICLE COMPONENT TO BE FIXED CHANGED TO BREAKS OIL: \n");
                                Console.WriteLine("***************************************************************");
                                findVehicle.PrintInfo();
                                Console.WriteLine();
                            }
                        }
                        break;
                }
            }
            else if (choice == 2)
            {
                Console.Clear();
                projects.First(t => t == temp).Vehicles.First(t => t == findVehicle).spareParts = Parts.Fixed;
                projects.First(t => t == temp).Vehicles.First(o => o == findVehicle).vehicleStatus = VehicleStatus.Active;
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("********************************************");
                Console.WriteLine("\n CHOSEN VEHICLE IS FIXED AND READY FOR EXPLUATATION: \n");
                Console.WriteLine("********************************************");
                findVehicle.PrintInfo();
                Console.WriteLine();
            }
        }
    }
}
