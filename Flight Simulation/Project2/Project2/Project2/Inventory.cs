using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Project2
{
    class Inventory
    {
        private int inventoryID;
        private string type;
        private int quantity;
        private int weight;

        public int InventoryID { get => inventoryID; set => inventoryID = value; }
        public string Type { get => type; set => type = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int Weight { get => weight; set => weight = value; }

        public Inventory()
        {

        }

        public Inventory(int inventoryID, string type, int quantity, int weight)
        {
            this.InventoryID = inventoryID;
            this.Type = type;
            this.Quantity = quantity;
            this.Weight = weight;
        }

        public List<Inventory> GetAllInventories()
        {
            List<Inventory> inventories = new List<Inventory>();
            DataHandler dh = new DataHandler();
            DataSet data = dh.ReadData("Inventory");

            foreach (DataRow item in data.Tables["Inventory"].Rows)
            {
                inventories.Add(new Inventory(int.Parse(item["InventoryID"].ToString()),
                    item["Type"].ToString(),
                    int.Parse(item["Quantity"].ToString()),
                    int.Parse(item["Weight(kg)"].ToString())));
            }

            return inventories;
        }
    }
}
