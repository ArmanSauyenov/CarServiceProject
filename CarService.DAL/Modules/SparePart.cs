using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DAL.Modules
{
    public enum Parts { Engine = 1, Transmission = 2, Tire = 3, Brake = 4, Window = 5, Door = 6, Seat = 7, Trunk = 8, Rims = 9, EngineOil = 10, TransmissionOil = 11, BreaksOil = 12}
    public class SparePart
    {
        public Parts spareParts { get; set; }
        public int partsID { get; set; }
    }
}
