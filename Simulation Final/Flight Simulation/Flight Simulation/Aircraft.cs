using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Flight_Simulation
{
    class Aircraft
    {
        private int aircraftID;
        private string aircraftName;
        private string series;
        private int speed;
        private int weight;
        private int maxWeight;
        private int fuelCapacity;
        private double fuelConsumption;

        public int AircraftID { get => aircraftID; set => aircraftID = value; }
        public string AircraftName { get => aircraftName; set => aircraftName = value; }
        public string Series { get => series; set => series = value; }
        public int Speed { get => speed; set => speed = value; }
        public int Weight { get => weight; set => weight = value; }
        public int MaxWeight { get => maxWeight; set => maxWeight = value; }
        public int FuelCapacity { get => fuelCapacity; set => fuelCapacity = value; }
        public double FuelConsumption { get => fuelConsumption; set => fuelConsumption = value; }

        public Aircraft()
        {

        }

        public Aircraft(int aircraftID, string aircraftName, string series, int speed, int weight, int maxWeight, int fuelCapacity, double fuelConsumption)
        {
            this.AircraftID = aircraftID;
            this.AircraftName = aircraftName;
            this.Series = series;
            this.Speed = speed;
            this.MaxWeight = maxWeight;
            this.Weight = weight;
            this.FuelCapacity = fuelCapacity;
            this.FuelConsumption = fuelConsumption;
        }

        public List<Aircraft> GetAllAircrafts()
        {
            List<Aircraft> aircrafts = new List<Aircraft>();
            DataHandler dh = new DataHandler();
            DataSet data = dh.ReadData("Aircraft");

            foreach (DataRow item in data.Tables["Aircraft"].Rows)
            {
                aircrafts.Add(new Aircraft(int.Parse(item["AircraftID"].ToString()),
                    item["AircraftName"].ToString(),
                    item["Series"].ToString(),
                    int.Parse(item["Speed(km/h)"].ToString()),
                    int.Parse(item["Weight(kg)"].ToString()),
                    int.Parse(item["MaxTakeoffWeight(kg)"].ToString()),
                    int.Parse(item["FuelCapacity(l)"].ToString()),
                    double.Parse(item["FuelConsumption(km/l)"].ToString())));
            }

            return aircrafts;
        }
    }
}