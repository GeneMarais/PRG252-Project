using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

/* PRG282 Project - 2019/07/24
 * Team members:
 *      Etienne Pieterse
 *      James Williams
 *      Gene Marais
*/

namespace Project2
{
    public class Aircraft
    {
        private int aircraftID;
        private string aircraftName;
        private string series;
        private int speed;
        private int weight;
        private int maxWeight;
        private int fuelCapacity;
        private int currentFuel;
        private double fuelConsumption;

        public int AircraftID { get => aircraftID; set => aircraftID = value; }
        public string AircraftName { get => aircraftName; set => aircraftName = value; }
        public string Series { get => series; set => series = value; }
        public int Speed { get => speed; set => speed = value; }
        public int Weight { get => weight; set => weight = value; }
        public int MaxWeight { get => maxWeight; set => maxWeight = value; }
        public int FuelCapacity { get => fuelCapacity; set => fuelCapacity = value; }
        public int CurrentFuel { get => currentFuel; set => currentFuel = value; }
        public double FuelConsumption { get => fuelConsumption; set => fuelConsumption = value; }

        public Aircraft()
        {

        }

        public Aircraft(int aircraftID, string aircraftName, string series, int speed, int weight, int maxWeight, int fuelCapacity, int currentFuel, double fuelConsumption)
        {
            this.aircraftID = aircraftID;
            this.aircraftName = aircraftName;
            this.series = series;
            this.speed = speed;
            this.weight = weight;
            this.maxWeight = maxWeight;
            this.fuelCapacity = fuelCapacity;
            this.currentFuel = currentFuel;
            this.fuelConsumption = fuelConsumption;
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
                    int.Parse(item["CurrentFuel"].ToString()),
                    double.Parse(item["FuelConsumption(km/l)"].ToString())));
            }

            return aircrafts;
        }
    }
}
