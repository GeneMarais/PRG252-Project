using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Flight_Simulation
{
    public partial class Form2 : Form
    {
        BindingSource bsInventory = new BindingSource();
        BindingSource bsAircraft = new BindingSource();
        public Form2(string strikeTime)
        {
            InitializeComponent();
            lblTime.Text = strikeTime;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblTarget.Text = "531, 22";

            if (lblTarget.Text == "531, 22")
            {
                lblHit.Text = "Enemy Base";
            }

            string[] obstacles = new string[] { "Enemy Aircraft", "Barracks", "Water Tower", "Artillery Weapons", "Ground Troops", "Power Station" };
            Random random = new Random();
            int amountObstacles = random.Next(3, obstacles.Length);
            List<string> rtbObstacles = new List<string>();

            for (int i = 0; i < amountObstacles; i++)
            {
                rtbObstacles.Add(obstacles[random.Next(obstacles.Length)]);
            }
            rtbIdentified.Lines = rtbObstacles.ToArray();

            Inventory inv = new Inventory();
            bsInventory.DataSource = inv.GetAllInventories();
            dataGridView7.DataSource = bsInventory;

            Aircraft air = new Aircraft();
            bsAircraft.DataSource = air.GetAllAircrafts();
            dataGridView1.DataSource = bsAircraft;

        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSimulation simulation = new frmSimulation();
            simulation.Show();
            this.Hide();
        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}