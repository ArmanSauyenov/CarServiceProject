using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.DAL.Modules;

namespace CarService.DAL
{
    public class Service
    {
        public Vehicle Search(Project project, int StateNumber_)
        {
            foreach (Vehicle item in project.Vehicles)
            {
                if (item.stateNumber == StateNumber_) return item;
            }
            return null;
        }
        public Vehicle Search(Project project, string Model_)
        {
            foreach (Vehicle item in project.Vehicles)
            {
                if (item.model == Model_) return item; 
            }
            return null;
        }
    }
}
