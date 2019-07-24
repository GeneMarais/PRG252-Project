using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/* PRG282 Project - 2019/07/24
 * Team members:
 *      Etienne Pieterse
 *      James Williams
 *      Gene Marais
*/

namespace Project2
{
    public partial class frmReport : Form
    {
        public frmReport(string strikeTime)
        {
            InitializeComponent();
            lblTime.Text = strikeTime;
        }

        BindingSource bsInventory = new BindingSource();
        BindingSource bsAircraft = new BindingSource();

        private void btnReturn_Click(object sender, EventArgs e)
        {
            frmSimulation simulation = new frmSimulation();
            simulation.Show();
            this.Hide();
        }

        private void frmReport_Load(object sender, EventArgs e)
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
            dgvDetails.DataSource = bsInventory;

            Aircraft air = new Aircraft();
            bsAircraft.DataSource = air.GetAllAircrafts();
            dgvAircrafts.DataSource = bsAircraft;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
