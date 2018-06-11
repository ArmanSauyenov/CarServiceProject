using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DAL.Modules
{
    public enum VehicleType { Excavator = 1, Tractor = 2, Loader = 3, CombineHarvester = 4, Tripper = 5 }
    public enum VehicleStatus { Active = 1, Inactive = 2 }
    public enum Parts { Engine = 1, Transmission = 2, Tire = 3, Brake = 4, Window = 5, Door = 6, Seat = 7, Trunk = 8, Rims = 9, EngineOil = 10, TransmissionOil = 11, BreaksOil = 12, Fixed = 13 }

    public class Vehicle
    {
        public VehicleType vehicleType { get; set; }
        public string model { get; set; }
        public DateTime issueYear { get; set; }
        public int stateNumber { get; set; }
        public VehicleStatus vehicleStatus { get; set; }
        public Parts spareParts { get; set; }
        public int partsID { get; set; }

        public void PrintInfo()
        {
            if (vehicleStatus == VehicleStatus.Active)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine($"-> Vehicle Discription: <- \n Vehicle type:\t {vehicleType}\n Vehicle model:\t {model} \n Issue year:\t {issueYear} \n State number:\t {stateNumber} \n Vehicle status: {vehicleStatus} \n Spare part:\t {spareParts} \n Parts ID:\t {partsID}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
