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
    public partial class frmJets : Form
    {
        public frmJets()
        {
            InitializeComponent();
        }

        Aircraft a = new Aircraft();
        List<Aircraft> aircrafts = new List<Aircraft>();

        private void Hangar_Load(object sender, EventArgs e)
        {
            aircrafts = a.GetAllAircrafts();

            int i = 1;
            // populate listboxes
            foreach (Aircraft item in aircrafts)
            {
                if (i == 1)
                {
                    lsbJet1.Items.Add(string.Format("Jet ID: \t    " + item.AircraftID));
                    lsbJet1.Items.Add(string.Format("Name: \t    " + item.AircraftName));
                    lsbJet1.Items.Add(string.Format("Top speed:   {0:#,#0} km/h", item.Speed));
                    lsbJet1.Items.Add(string.Format("Weight: \t    {0:#,#0} kg", item.Weight));
                    lsbJet1.Items.Add(string.Format("Fuel: \t    {0:#,#0}/{1:#,#0} litre", item.CurrentFuel, item.FuelCapacity));
                    lsbJet1.Items.Add(string.Format("Usage:\t    {0} litres/hour", item.FuelConsumption));
                    lsbJet1.Items.Add(string.Format("Inventory:    " + item.MaxWeight));
                    i++;
                }
                else if (i == 2)
                {
                    lsbJet2.Items.Add(string.Format("Jet ID: \t    " + item.AircraftID));
                    lsbJet2.Items.Add(string.Format("Name: \t    " + item.AircraftName));
                    lsbJet2.Items.Add(string.Format("Top speed:   {0:#,#0} km/h", item.Speed));
                    lsbJet2.Items.Add(string.Format("Weight: \t    {0:#,#0} kg", item.Weight));
                    lsbJet2.Items.Add(string.Format("Fuel: \t    {0:#,#0}/{1:#,#0} litre", item.CurrentFuel, item.FuelCapacity));
                    lsbJet2.Items.Add(string.Format("Usage:\t    {0} litres/hour", item.FuelConsumption));
                    lsbJet2.Items.Add(string.Format("Inventory:    " + item.MaxWeight));
                    i++;
                }
                else
                {
                    lsbJet3.Items.Add(string.Format("Jet ID: \t    " + item.AircraftID));
                    lsbJet3.Items.Add(string.Format("Name: \t    " + item.AircraftName));
                    lsbJet3.Items.Add(string.Format("Top speed:   {0:#,#0} km/h", item.Speed));
                    lsbJet3.Items.Add(string.Format("Weight: \t    {0:#,#0} kg", item.Weight));
                    lsbJet3.Items.Add(string.Format("Fuel: \t    {0:#,#0}/{1:#,#0} litre", item.CurrentFuel, item.FuelCapacity));
                    lsbJet3.Items.Add(string.Format("Usage:\t    {0} litres/hour", item.FuelConsumption));
                    lsbJet3.Items.Add(string.Format("Inventory:    " + item.MaxWeight));
                }
            }
        }

        Aircraft currentAircraft = null;


        #region PictureButtons
        private void pbJet1_Click(object sender, EventArgs e)
        {
            currentAircraft = aircrafts[0];
        }
        private void pbJet1_MouseHover(object sender, EventArgs e)
        {
            pbJet1.BackColor = Color.MediumAquamarine;
        }
        private void pbJet1_MouseLeave(object sender, EventArgs e)
        {
            pbJet1.BackColor = Color.Transparent;
        }

        private void pbJet2_Click(object sender, EventArgs e)
        {
            currentAircraft = aircrafts[1];
        }
        private void pbJet2_MouseHover(object sender, EventArgs e)
        {
            pbJet2.BackColor = Color.MediumAquamarine;
        }
        private void pbJet2_MouseLeave(object sender, EventArgs e)
        {
            pbJet2.BackColor = Color.Transparent;
        }

        private void pbJet3_Click(object sender, EventArgs e)
        {
            currentAircraft = aircrafts[2];
        }
        private void pbJet3_MouseHover(object sender, EventArgs e)
        {
            pbJet3.BackColor = Color.MediumAquamarine;
        }

        private void pbJet3_MouseLeave(object sender, EventArgs e)
        {
            pbJet3.BackColor = Color.Transparent;
        }
        #endregion

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSimulation open = new frmSimulation(currentAircraft);
            open.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void Hangar_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }


    }
}
