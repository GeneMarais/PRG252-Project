using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading;

/* PRG282 Project - 2019/07/24
 * Team members:
 *      Etienne Pieterse
 *      James Williams
 *      Gene Marais
*/

namespace Project2
{
    public partial class frmSimulation : Form
    {
        List<Aircraft> aircrafts = new List<Aircraft>();
        List<int> myInventory = new List<int>();
        Aircraft myJet = null;


        public frmSimulation()
        {
            InitializeComponent();
        }

        // constructor used after choosing jet from hangar
        public frmSimulation(Aircraft selectedJet)
        {
            InitializeComponent();
            try
            {
                if (selectedJet != null)
                {
                    myJet = selectedJet;
                    progressBarFuel.Value = (int)Math.Round((double)myJet.CurrentFuel / (double)myJet.FuelCapacity * 100);
                    lblFuel.Text = progressBarFuel.Value + " %";
                }
                else
                {
                    throw new NoJetException("Please select a jet from the hangar");    // CUSTOM EXCEPTION
                }
            }
            catch (NoJetException noJet)
            {
                MessageBox.Show(noJet.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public int CurrentFuelPercentage(Aircraft chosen)
        {
            int fuelPercentage = (chosen.CurrentFuel / chosen.FuelCapacity * 100);    // calculate how full progressbar should be
            return fuelPercentage;
        }

        // GRID FOR ASTAR METHOD TO CALCULATE SHORTEST ROUTE
        string a0 = "E", a1 = "-", a2 = "-", a3 = "-", a4 = "-", a5 = "-", a6 = "-", a7 = "-";  // specifies ending point
        string b0 = "-", b1 = "-", b2 = "-", b3 = "-", b4 = "-", b5 = "-", b6 = "-", b7 = "-";
        string c0 = "-", c1 = "-", c2 = "-", c3 = "-", c4 = "-", c5 = "-", c6 = "-", c7 = "-";
        string d0 = "-", d1 = "-", d2 = "-", d3 = "-", d4 = "-", d5 = "-", d6 = "-", d7 = "-";
        string e0 = "-", e1 = "-", e2 = "-", e3 = "-", e4 = "-", e5 = "-", e6 = "-", e7 = "-";
        string f0 = "-", f1 = "-", f2 = "-", f3 = "-", f4 = "-", f5 = "-", f6 = "-", f7 = "-";
        string g0 = "-", g1 = "-", g2 = "-", g3 = "-", g4 = "-", g5 = "-", g6 = "-", g7 = "-";
        string h0 = "-", h1 = "-", h2 = "-", h3 = "-", h4 = "-", h5 = "-", h6 = "-", h7 = "S";  // specifies starting point
        string i0 = "-", i1 = "-", i2 = "-", i3 = "-", i4 = "-", i5 = "-", i6 = "-", i7 = "-";

        public class matrixNode
        {
            public int begin = 0, end = 0, sum = 0;
            public int x, y;
            public matrixNode parent;
        }

        public static matrixNode PathFinder(string[][] matrix, int beginX, int beginY, int endX, int endY)  // using A* method
        {
            // used to change nodes to red (closed) or green (open)
            Dictionary<string, matrixNode> greenNodes = new Dictionary<string, matrixNode>();
            Dictionary<string, matrixNode> redNodes = new Dictionary<string, matrixNode>();

            matrixNode startNode = new matrixNode { x = beginX, y = beginY };
            string key = startNode.x.ToString() + startNode.x.ToString();
            greenNodes.Add(key, startNode);

            KeyValuePair<string, matrixNode> SmallestGreen()    // get shortest route
            {
                KeyValuePair<string, matrixNode> smallest = greenNodes.ElementAt(0);

                foreach (KeyValuePair<string, matrixNode> item in greenNodes)
                {
                    if (item.Value.sum < smallest.Value.sum)
                        smallest = item;
                    else if (item.Value.sum == smallest.Value.sum
                            && item.Value.end < smallest.Value.end)
                        smallest = item;
                }
                return smallest;
            };
            SmallestGreen();

            // add these values to current nodes x and y to get surrounding neighbours
            List<KeyValuePair<int, int>> fourCousins = new List<KeyValuePair<int, int>>()
                                            { new KeyValuePair<int, int>(-1,0),
                                              new KeyValuePair<int, int>(0,1),
                                              new KeyValuePair<int, int>(1, 0),
                                              new KeyValuePair<int, int>(0,-1) };

            int maxX = matrix.GetLength(0);
            if (maxX == 0)
                return null;
            int maxY = matrix[0].Length;

            while (true)
            {
                if (greenNodes.Count == 0)
                    return null;

                KeyValuePair<string, matrixNode> current = SmallestGreen();
                if (current.Value.x == endX && current.Value.y == endY)
                    return current.Value;

                greenNodes.Remove(current.Key);
                redNodes.Add(current.Key, current.Value);

                foreach (KeyValuePair<int, int> plusXY in fourCousins)
                {
                    int cousinX = current.Value.x + plusXY.Key;
                    int cousinY = current.Value.y + plusXY.Value;
                    string neighbourKey = cousinX.ToString() + cousinY.ToString();
                    if (cousinX < 0 || cousinY < 0 || cousinX >= maxX || cousinY >= maxY
                        || matrix[cousinX][cousinY] == "X"      //obstacles marked with an X (not open)
                        || redNodes.ContainsKey(neighbourKey))
                        continue;

                    if (greenNodes.ContainsKey(neighbourKey))
                    {
                        matrixNode currentNeighbour = greenNodes[neighbourKey];
                        int from = Math.Abs(cousinX - beginX) + Math.Abs(cousinY - beginY);
                        if (from < currentNeighbour.begin)
                        {
                            currentNeighbour.begin = from;
                            currentNeighbour.sum = currentNeighbour.begin + currentNeighbour.end;
                            currentNeighbour.parent = current.Value;
                        }
                    }
                    else
                    {
                        matrixNode curNbr = new matrixNode { x = cousinX, y = cousinY };
                        curNbr.begin = Math.Abs(cousinX - beginX) + Math.Abs(cousinY - beginY);
                        curNbr.end = Math.Abs(cousinX - endX) + Math.Abs(cousinY - endY);
                        curNbr.sum = curNbr.begin + curNbr.end;
                        curNbr.parent = current.Value;
                        greenNodes.Add(neighbourKey, curNbr);
                    }
                }
            }
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {
            pnlMain.SendToBack();
            Stack<matrixNode> path = new Stack<matrixNode>();
            lblFuel.Visible = true;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            pbBoat.Visible = true;
            pbCannon.Visible = true;
            btnStart.Enabled = true;

            Graphics gr = pnlMain.CreateGraphics();
            Pen mypen = new Pen(Brushes.Gray, 1);

            float x = 0f;
            float y = 0f;
            float xspace = pnlMain.Width / 9;
            float yspace = pnlMain.Height / 9;

            for (int i = 0; i < 9; i++)
            {
                gr.DrawLine(mypen, x, y, x, pnlMain.Height);
                x += xspace;
            }

            x = 0f;

            for (int i = 0; i < 9; i++)
            {
                gr.DrawLine(mypen, x, y, pnlMain.Width, y);
                y += yspace;
            }

            // changing all buttons to be visible
            #region ButtonsVisible
            btn1.Visible = true;
            btn2.Visible = true;
            btn3.Visible = true;
            btn4.Visible = true;
            btn5.Visible = true;
            btn6.Visible = true;
            btn7.Visible = true;
            btn8.Visible = true;
            btn9.Visible = true;
            btn10.Visible = true;
            btn11.Visible = true;
            btn12.Visible = true;
            btn13.Visible = true;
            btn14.Visible = true;
            btn15.Visible = true;
            btn16.Visible = true;
            btn17.Visible = true;
            btn18.Visible = true;
            btn19.Visible = true;
            btn20.Visible = true;
            btn21.Visible = true;
            btn22.Visible = true;
            btn23.Visible = true;
            btn24.Visible = true;
            btn25.Visible = true;
            btn26.Visible = true;
            btn27.Visible = true;
            btn28.Visible = true;
            btn29.Visible = true;
            btn30.Visible = true;
            btn31.Visible = true;
            btn32.Visible = true;
            btn33.Visible = true;
            btn34.Visible = true;
            btn35.Visible = true;
            btn36.Visible = true;
            btn37.Visible = true;
            btn38.Visible = true;
            btn39.Visible = true;
            btn40.Visible = true;
            btn41.Visible = true;
            btn42.Visible = true;
            btn43.Visible = true;
            btn44.Visible = true;
            btn45.Visible = true;
            btn46.Visible = true;
            btn47.Visible = true;
            btn48.Visible = true;
            btn49.Visible = true;
            btn50.Visible = true;
            btn51.Visible = true;
            btn52.Visible = true;
            btn53.Visible = true;
            btn54.Visible = true;
            btn55.Visible = true;
            btn56.Visible = true;
            btn57.Visible = true;
            btn58.Visible = true;
            btn59.Visible = true;
            #endregion  
        }

        // make button x when clicked
        #region GridButtons

        private void btn1_Click(object sender, EventArgs e)
        {
            a3 = "X";
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            a4 = "X";
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            a5 = "X";
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            a6 = "X";
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            a7 = "X";
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            b0 = "X";
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            b1 = "X";
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            b2 = "X";
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            b3 = "X";
        }
        private void btn10_Click(object sender, EventArgs e)
        {
            b4 = "X";
        }
        private void btn11_Click(object sender, EventArgs e)
        {
            b5 = "X";
        }
        private void btn12_Click(object sender, EventArgs e)
        {
            b6 = "X";
        }
        private void btn13_Click(object sender, EventArgs e)
        {
            b7 = "X";
        }
        private void btn14_Click(object sender, EventArgs e)
        {
            c0 = "X";
        }
        private void btn15_Click(object sender, EventArgs e)
        {
            c1 = "X";
        }

        private void btn16_Click(object sender, EventArgs e)
        {
            c2 = "X";
        }
        private void btn17_Click(object sender, EventArgs e)
        {
            c3 = "X";
        }
        private void btn18_Click(object sender, EventArgs e)
        {
            c4 = "X";
        }

        private void btn19_Click(object sender, EventArgs e)
        {
            c5 = "X";
        }
        private void btn20_Click(object sender, EventArgs e)
        {
            c6 = "X";
        }
        private void btn21_Click(object sender, EventArgs e)
        {
            c7 = "X";
        }
        private void btn22_Click(object sender, EventArgs e)
        {
            d0 = "X";
        }

        private void btn23_Click(object sender, EventArgs e)
        {
            d1 = "X";
        }
        private void btn24_Click(object sender, EventArgs e)
        {
            d2 = "X";
        }
        private void btn25_Click(object sender, EventArgs e)
        {
            d3 = "X";
        }
        private void btn26_Click(object sender, EventArgs e)
        {
            d4 = "X";
        }
        private void btn27_Click(object sender, EventArgs e)
        {
            d5 = "X";
        }
        private void btn28_Click(object sender, EventArgs e)
        {
            d6 = "X";
        }
        private void btn29_Click(object sender, EventArgs e)
        {
            d7 = "X";
        }
        private void btn30_Click(object sender, EventArgs e)
        {
            e0 = "X";
        }
        private void btn31_Click(object sender, EventArgs e)
        {
            e1 = "X";
        }
        private void btn32_Click(object sender, EventArgs e)
        {
            e2 = "X";
        }
        private void btn33_Click(object sender, EventArgs e)
        {
            e3 = "X";
        }
        private void btn34_Click(object sender, EventArgs e)
        {
            e4 = "X";
        }
        private void btn35_Click(object sender, EventArgs e)
        {
            e5 = "X";
        }
        private void btn36_Click(object sender, EventArgs e)
        {
            e6 = "X";
        }
        private void btn37_Click(object sender, EventArgs e)
        {
            e7 = "X";
        }
        private void btn38_Click(object sender, EventArgs e)
        {
            f0 = "X";
        }
        private void btn39_Click(object sender, EventArgs e)
        {
            f1 = "X";
        }
        private void btn40_Click(object sender, EventArgs e)
        {
            f2 = "X";
        }
        private void btn41_Click(object sender, EventArgs e)
        {
            f3 = "X";
        }
        private void btn42_Click(object sender, EventArgs e)
        {
            f4 = "X";
        }
        private void btn43_Click(object sender, EventArgs e)
        {
            f5 = "X";
        }
        private void btn44_Click(object sender, EventArgs e)
        {
            f6 = "X";
        }
        private void btn45_Click(object sender, EventArgs e)
        {
            f7 = "X";
        }
        private void btn46_Click(object sender, EventArgs e)
        {
            g0 = "X";
        }
        private void btn47_Click(object sender, EventArgs e)
        {
            g1 = "X";
        }
        private void btn48_Click(object sender, EventArgs e)
        {
            g2 = "X";
        }
        private void btn49_Click(object sender, EventArgs e)
        {
            g3 = "X";
        }
        private void btn50_Click(object sender, EventArgs e)
        {
            g4 = "X";
        }
        private void btn51_Click(object sender, EventArgs e)
        {
            g5 = "X";
        }
        private void btn52_Click(object sender, EventArgs e)
        {
            g6 = "X";
        }
        private void btn53_Click(object sender, EventArgs e)
        {
            g7 = "X";
        }
        private void btn54_Click(object sender, EventArgs e)
        {
            h0 = "X";
        }
        private void btn55_Click(object sender, EventArgs e)
        {
            h1 = "X";
        }
        private void btn56_Click(object sender, EventArgs e)
        {
            h2 = "X";
        }
        private void btn57_Click(object sender, EventArgs e)
        {
            h3 = "X";
        }
        private void btn58_Click(object sender, EventArgs e)
        {
            h4 = "X";
        }
        private void btn59_Click(object sender, EventArgs e)
        {
            h5 = "X";
        }
        private void btn60_Click(object sender, EventArgs e)
        {
            h6 = "X";
        }

        #endregion

        #region AddObjectsHover

        private void pbBoat_MouseHover(object sender, EventArgs e)
        {
            pbBoat.BackColor = Color.MediumTurquoise;
        }

        private void pbBoat_MouseLeave(object sender, EventArgs e)
        {
            pbBoat.BackColor = Color.Transparent;
        }

        private void pbCannon_MouseHover(object sender, EventArgs e)
        {
            pbCannon.BackColor = Color.MediumTurquoise;
        }

        private void pbCannon_MouseLeave(object sender, EventArgs e)
        {
            pbCannon.BackColor = Color.Transparent;
        }
        #endregion

        private void btnReFuel_Click(object sender, EventArgs e)
        {
            myJet.CurrentFuel = myJet.FuelCapacity;             // fills up the entire tank
            progressBarFuel.Value = CurrentFuelPercentage(myJet);   // make bar 100%
            lblFuel.Text = CurrentFuelPercentage(myJet) + " %";
        }

        // FLY TO ENEMY BASE
        public void BeginSimulation()
        {
            lblFuel.Visible = false;
            pnlMain.Visible = false;
            pnlMain.SendToBack();
            pbPilot.BringToFront();

            string[][] matrix = new string[9][];        // jagged array
            matrix[0] = new string[8] { a0, a1, a2, a3, a4, a5, a6, a7 };
            matrix[1] = new string[8] { b0, b1, b2, b3, b4, b5, b6, b7 };
            matrix[2] = new string[8] { c0, c1, c2, c3, c4, c5, c6, c7 };
            matrix[3] = new string[8] { d0, d1, d2, d3, d4, d5, d6, d7 };
            matrix[4] = new string[8] { e0, e1, e2, e3, e4, e5, e6, e7 };
            matrix[5] = new string[8] { f0, f1, f2, f3, f4, f5, f6, f7 };
            matrix[6] = new string[8] { g0, g1, g2, g3, g4, g5, g6, g7 };
            matrix[7] = new string[8] { h0, h1, h2, h3, h4, h5, h6, h7 };
            matrix[8] = new string[8] { i0, i1, i2, i3, i4, i5, i6, i7 };

            int beginX = 7, beginY = 7, endX = 0, endY = 0;
            matrixNode endNode = PathFinder(matrix, beginX, beginY, endX, endY);

            // we have to loop through the "parent" nodes until we find a start node
            Stack<matrixNode> path = new Stack<matrixNode>();

            while (endNode.x != beginX || endNode.y != beginY)
            {
                path.Push(endNode);
                endNode = endNode.parent;
            }
            path.Push(endNode);

            int x = 7;
            int y = 7;

            // lets the jet fly
            while (path.Count > 0)
            {
                progressBarFuel.Increment(-3);     // accurately decrease bar to reflect fuel
                matrixNode node = path.Pop();

                if (node.x < x)
                {
                    // change vertical location of jet
                    for (int i = 0; i < 38; i++)
                    {
                        pbPilot.Location = new Point(pbPilot.Location.X, pbPilot.Location.Y - 2);
                        Thread.Sleep(20);
                    }
                    x = node.x;
                }

                if (node.y < y)
                {
                    // change vertical location of jet
                    for (int i = 0; i < 57; i++)
                    {
                        pbPilot.Location = new Point(pbPilot.Location.X - 2, pbPilot.Location.Y);
                        Thread.Sleep(20);
                    }
                    y = node.y;
                }
            }
        }

        // FLY TO HOME BASE
        public void FlyBack()
        {
            pnlMain.Visible = false;
            pnlMain.SendToBack();
            pbJetBack.BringToFront();

            // switch the start and end point 
            a7 = "S";
            h0 = "E";

            string[][] matrix = new string[8][];
            matrix[0] = new string[7] { h7, h6, h5, h4, h3, h2, h1 };
            matrix[1] = new string[7] { g7, g6, g5, g4, g3, g2, g1 };
            matrix[2] = new string[7] { f7, f6, f5, f4, f3, f2, f1 };
            matrix[3] = new string[7] { e7, e6, e5, e4, e3, e2, e1 };
            matrix[4] = new string[7] { d7, d6, d5, d4, d3, d2, d1 };
            matrix[5] = new string[7] { c7, c6, c5, c4, c3, c2, c1 };
            matrix[6] = new string[7] { b7, b6, b5, b4, b3, b2, b1 };
            matrix[7] = new string[7] { a7, a6, a5, a4, a3, a2, a1 };
  
            int beginX = 7, beginY = 7, endX = 0, endY = 0;
            matrixNode endNode = PathFinder(matrix, beginX, beginY, endX, endY);

            // we have to loop through the "parent" nodes until we find a start node
            Stack<matrixNode> path = new Stack<matrixNode>();

            while (endNode.x != beginX || endNode.y != beginY)
            {
                path.Push(endNode);
                endNode = endNode.parent;
            }
            path.Push(endNode);

            int x = 7;
            int y = 7;

            while (path.Count > 0)
            {
                matrixNode node = path.Pop();

                if (node.x < x)
                {
                    // vertical
                    for (int i = 0; i < 38; i++)
                    {
                        pbJetBack.Location = new Point(pbJetBack.Location.X, pbJetBack.Location.Y + 2);
                        Thread.Sleep(20);
                    }
                    x = node.x;
                }

                if (node.y < y)
                {
                    // horisontal
                    for (int i = 0; i < 57; i++)
                    {
                        pbJetBack.Location = new Point(pbJetBack.Location.X + 2, pbJetBack.Location.Y);
                        Thread.Sleep(20);
                    }
                    y = node.y;
                }
                progressBarFuel.Increment(-(int)(Math.Round(myJet.FuelConsumption)));
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (progressBarFuel.Value < 100)    // have to refuel if not 100% before starting 
                {
                    throw new FuelException("You have to refuel before starting!");
                }
                else
                {
                    // can't place objects in an entire row - no route will be available
                    if (b0 == "X" && b1 == "X" && b2 == "X" && b3 == "X" && b4 == "X" && b5 == "X" && b6 == "X" && b7 == "X")
                    { 
                        b0 = "-";
                        b1 = "-";
                        b2 = "-";
                        b3 = "-";
                        b4 = "-";
                        b5 = "-";
                        b6 = "-";
                        b7 = "-";
                        throw new NoRouteException("There are no possible routes");
                    }
                    else if (c0 == "X" && c1 == "X" && c2 == "X" && c3 == "X" && c4 == "X" && c5 == "X" && c6 == "X" && c7 == "X")
                    {
                        c0 = "-";
                        c1 = "-";
                        c2 = "-";
                        c3 = "-";
                        c4 = "-";
                        c5 = "-";
                        c6 = "-";
                        c7 = "-";
                        throw new NoRouteException("There are no possible routes");
                    }
                    else if (d0 == "X" && d1 == "X" && d2 == "X" && d3 == "X" && d4 == "X" && d5 == "X" && d6 == "X" && d7 == "X")
                    {
                        d0 = "-";
                        d1 = "-";
                        d2 = "-";
                        d3 = "-";
                        d4 = "-";
                        d5 = "-";
                        d6 = "-";
                        d7 = "-";
                        throw new NoRouteException("There are no possible routes");
                    }
                    else if (e0 == "X" && e1 == "X" && e2 == "X" && e3 == "X" && e4 == "X" && e5 == "X" && e6 == "X" && e7 == "X")
                    {
                        e0 = "-";
                        e1 = "-";
                        e2 = "-";
                        e3 = "-";
                        e4 = "-";
                        e5 = "-";
                        e6 = "-";
                        e7 = "-";
                        throw new NoRouteException("There are no possible routes");
                    }
                    else if (f0 == "X" && f1 == "X" && f2 == "X" && f3 == "X" && f4 == "X" && f5 == "X" && f6 == "X" && f7 == "X")
                    {
                        f0 = "-";
                        f1 = "-";
                        f2 = "-";
                        f3 = "-";
                        f4 = "-";
                        f5 = "-";
                        f6 = "-";
                        f7 = "-";
                        throw new NoRouteException("There are no possible routes");
                    }
                    else if (g0 == "X" && g1 == "X" && g2 == "X" && g3 == "X" && g4 == "X" && g5 == "X" && g6 == "X" && g7 == "X")
                    {
                        g0 = "-";
                        g1 = "-";
                        g2 = "-";
                        g3 = "-";
                        g4 = "-";
                        g5 = "-";
                        g6 = "-";
                        g7 = "-";
                        throw new NoRouteException("There are no possible routes");
                    }
                    else
                    {
                        BeginSimulation();
                        
                        pbPilot.Visible = false; // make first picture invisible

                        Thread.Sleep(500);
                        MessageBox.Show("The enemies have been DESTROYED!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string strikeTime = DateTime.Now.ToString("h:mm:ss tt");

                        FlyBack();

                        pnlHomeBase.Visible = true;

                        myJet.CurrentFuel = myJet.FuelCapacity * progressBarFuel.Value / 100;
                        lblFuel.Text = progressBarFuel.Value + " %";
                        lblFuel.Visible = true;
                        MessageBox.Show("You have returned from your mission", "Great", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // open report form after simulation
                        Thread.Sleep(200);
                        frmReport openReport = new frmReport(strikeTime);
                        openReport.Show();
                    }
                }
            }
            catch (FuelException fuel)
            {
                MessageBox.Show(fuel.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (NoRouteException noRoute)
            {
                MessageBox.Show(noRoute.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception all)
            {
                MessageBox.Show(all.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // method used to add a picture box when image is clicked
        PictureBox AddPictureBox(int x, int y, string imageURL)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Location = new Point(x, y);
            pictureBox.Image = Image.FromFile(imageURL);
            pictureBox.Size = new Size(84, 64);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.BackColor = Color.Transparent;

            ControlExtension.Draggable(pictureBox, true);   // make picturebox draggable

            return pictureBox;
        }

        int x1 = 400, x2 = 400;
        int y1 = 30, y2 = 100, y3 = 170, y4 = 240;

        private void pbBoat_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = AddPictureBox(x1, y1, "../Pics/Ship.png");
            x1 += 80;

            Controls.Add(pictureBox);
            pictureBox.BringToFront();
        }
        private void pbCannon_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = AddPictureBox(x2, y2, "../Pics/Cannon.png");
            x2 += 80;

            Controls.Add(pictureBox);
            pictureBox.BringToFront();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }



    }
}
