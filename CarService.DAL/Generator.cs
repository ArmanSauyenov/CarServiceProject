using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.DAL.Modules;
using System.Xml;
using System.IO;
using CarService.DAL;

namespace CarService.DAL
{
    public class Generator
    {
        private Random rand = new Random();

        public bool GenerateProject(ref List<Project> Projects, out string message)
        {
            try
            {
                if (Projects == null)
                    Projects = new List<Project>();

                Projects.Add(new Project() { projectName = "AlmatyConst" });
                Projects[0].Vehicles = GenerateVehicles(out message);

                Projects.Add(new Project() { projectName = "CityConst" });
                Projects[1].Vehicles = GenerateVehicles(out message);

                Projects.Add(new Project() { projectName = "FirstConst" });
                Projects[2].Vehicles = GenerateVehicles(out message);

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                message = "Project complete!";

                return true;
            }
            catch(Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }
        public List<Vehicle> GenerateVehicles(out string message)
        {
            List<Vehicle> Vehicles = new List<Vehicle>();
            for (int i = 0; i < 5; i++)
            {
                Vehicle vehicle = new Vehicle();
                vehicle.vehicleType = (VehicleType)rand.Next(1, 6);
                vehicle.model = "Model №" + rand.Next(1, 10);
                vehicle.issueYear = DateTime.Now.AddMonths((rand.Next(10, 100) * -1));
                vehicle.stateNumber = rand.Next(100, 999);
                vehicle.vehicleStatus = (VehicleStatus)rand.Next(1, 3);
                vehicle.spareParts = (Parts)rand.Next(1, 13);
                vehicle.partsID = rand.Next();
                Vehicles.Add(vehicle);
                addVehicleToXml(vehicle);
            }
            message = "Vehicle complete";
            return Vehicles;
        }

        public string path = @"Vehicles.xml";

        public void addVehicleToXml(Vehicle vehicles)
        {
            XmlDocument doc = getDocument();
            //XmlComment xcom;
            XmlElement elem = doc.CreateElement("Vehicle");

            XmlElement Type = doc.CreateElement("Type");
            Type.InnerText = vehicles.vehicleType.ToString();
            //xcom = doc.CreateComment("Type of the vehicle");
            //Type.AppendChild(xcom);

            XmlElement Model = doc.CreateElement("Model");
            Model.InnerText = vehicles.model;
            //xcom = doc.CreateComment("Model of the vehicle");
            //Model.AppendChild(xcom);

            //XmlElement IssueYear = doc.CreateElement("Issue Year");
            //IssueYear.InnerText = vehicles.issueYear.ToString();
            //xcom = doc.CreateComment("Issue year of the vehicle");
            //IssueYear.AppendChild(xcom);
            //
            //XmlElement StateNumber = doc.CreateElement("State Number");
            //StateNumber.InnerText = vehicles.stateNumber.ToString();
            //xcom = doc.CreateComment("State number of the vehicle");
            //StateNumber.AppendChild(xcom);
            //
            //XmlElement VehicleStatus = doc.CreateElement("Status");
            //VehicleStatus.InnerText = vehicles.vehicleStatus.ToString();
            //xcom = doc.CreateComment("Status of the vehicle");
            //VehicleStatus.AppendChild(xcom);
            //
            //XmlElement SpareParts = doc.CreateElement("Spare parts");
            //SpareParts.InnerText = vehicles.spareParts.ToString();
            //xcom = doc.CreateComment("Spare parts of the vehicle");
            //SpareParts.AppendChild(xcom);
            //
            //XmlElement PartsID = doc.CreateElement("Parts ID");
            //PartsID.InnerText = vehicles.partsID.ToString();
            //xcom = doc.CreateComment("Parts ID of the vehicle");
            //PartsID.AppendChild(xcom);

            doc.DocumentElement.AppendChild(elem);
            elem.AppendChild(Type);
            Type.AppendChild(Model);
            //elem.AppendChild(IssueYear);
            //elem.AppendChild(StateNumber);
            //elem.AppendChild(VehicleStatus);
            //elem.AppendChild(SpareParts);
            //elem.AppendChild(PartsID);
            doc.Save(path);
        }

        public XmlDocument getDocument()
        {
            XmlDocument xd = new XmlDocument();
        
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                xd.Load(path);
            }
            else
            {
                XmlElement xl = xd.CreateElement("Vehicles");
                xd.AppendChild(xl);
                xd.Save(path);
            }
            return xd;
        }
    }
}
