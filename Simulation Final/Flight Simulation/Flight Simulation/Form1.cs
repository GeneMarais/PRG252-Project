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
    public partial class frmSimulation : Form
    {
        public frmSimulation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // draw gridline on main panel
            Graphics gr = pnlMain.CreateGraphics();
            Pen pen = new Pen(Brushes.Black, 1);

            int x = 0;
            int y = 0;
            int xWidth= pnlMain.Width / 9;      // divides the panel into 9
            int yHeight = pnlMain.Height / 9;

            // draw vertical lines on grid
            for (int i = 0; i < 9; i++)
            {
                gr.DrawLine(pen, x, y, x, pnlMain.Height);
                x += xWidth;
            }

            x = 0;

            // draw horisontal lines on grid
            for (int i = 0; i < 9; i++)
            {
                gr.DrawLine(pen, x, y, pnlMain.Width, y);
                y += yHeight;
            }
        }

        // GRID FOR ASTAR METHOD TO FIND SHORTEST ROUTE
        string a0 = "-", a1 = "-", a2 = "-", a3 = "-", a4 = "E", a5 = "-", a6 = "-", a7 = "-";  // specifies ending point
        string b0 = "-", b1 = "-", b2 = "-", b3 = "-", b4 = "-", b5 = "-", b6 = "-", b7 = "-";

        private void btnSpec_Click(object sender, EventArgs e)
        {
            Form2 specs = new Form2("");
            specs.Show();
            


        }

        string c0 = "-", c1 = "-", c2 = "-", c3 = "-", c4 = "-", c5 = "-", c6 = "-", c7 = "-";
        string d0 = "-", d1 = "-", d2 = "-", d3 = "-", d4 = "-", d5 = "-", d6 = "-", d7 = "-";
        string e0 = "-", e1 = "-", e2 = "-", e3 = "-", e4 = "-", e5 = "-", e6 = "-", e7 = "-";
        string f0 = "-", f1 = "-", f2 = "-", f3 = "-", f4 = "-", f5 = "-", f6 = "-", f7 = "-";
        string g0 = "-", g1 = "-", g2 = "-", g3 = "-", g4 = "-", g5 = "-", g6 = "-", g7 = "-";
        string h0 = "-", h1 = "-", h2 = "-", h3 = "-", h4 = "-", h5 = "-", h6 = "-", h7 = "-";  // specifies starting point
        string i0 = "-", i1 = "-", i2 = "-", i3 = "-", i4 = "-", i5 = "-", i6 = "-", i7 = "S";

        public class matrixNode
        {
            public int begin = 0, end = 0, sum = 0;
            public int x, y;
            public matrixNode parent;
        }

        public static matrixNode PathFinder(string[][] matrix, int beginX, int beginY, int endX, int endY)
        {
            // used to change nodes to red (closed) or green (open)
            Dictionary<string, matrixNode> greenNodes = new Dictionary<string, matrixNode>();
            Dictionary<string, matrixNode> redNodes = new Dictionary<string, matrixNode>();

            matrixNode startNode = new matrixNode { x = beginX, y = beginY };
            string key = startNode.x.ToString() + startNode.x.ToString();
            greenNodes.Add(key, startNode);

            // possible error
            #region
            //Func<KeyValuePair<string, matrixNode>> smallestGreen = () =>
            //{
            //    KeyValuePair<string, matrixNode> smallest = greenNodes.ElementAt(0);

            //    foreach (KeyValuePair<string, matrixNode> item in greenNodes)
            //    {
            //        if (item.Value.sum < smallest.Value.sum)
            //            smallest = item;
            //        else if (item.Value.sum == smallest.Value.sum
            //                && item.Value.end < smallest.Value.end)
            //            smallest = item;
            //    }


            //    return smallest;
            //};

            #endregion

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
                    string cousinKey = cousinX.ToString() + cousinY.ToString();
                    if (cousinX < 0 || cousinY < 0 || cousinX >= maxX || cousinY >= maxY
                        || matrix[cousinX][cousinY] == "X" // obstacles are marked with X
                        || redNodes.ContainsKey(cousinKey))
                        continue;

                    if (greenNodes.ContainsKey(cousinKey))
                    {
                        matrixNode currentCousin = greenNodes[cousinKey];
                        int from = Math.Abs(cousinX - beginX) + Math.Abs(cousinY - beginY);
                        if (from < currentCousin.begin)
                        {
                            currentCousin.begin = from;
                            currentCousin.sum = currentCousin.begin + currentCousin.end;
                            currentCousin.parent = current.Value;
                        }
                    }
                    else
                    {
                        matrixNode currentCousin = new matrixNode { x = cousinX, y = cousinY };
                        currentCousin.begin = Math.Abs(cousinX - beginX) + Math.Abs(cousinY - beginY);
                        currentCousin.end = Math.Abs(cousinX - endX) + Math.Abs(cousinY - endY);
                        currentCousin.sum = currentCousin.begin + currentCousin.end;
                        currentCousin.parent = current.Value;
                        greenNodes.Add(cousinKey, currentCousin);
                    }
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
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

                    Thread.Sleep(500);
                    MessageBox.Show("ENEMIES DEFEATED !!!", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string strikeTime = DateTime.Now.ToString("h:mm:ss tt");
                    Form2 form2 = new Form2(strikeTime);
                    this.Hide();
                    form2.Show();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // FLY TO ENEMY BASE
        public void BeginSimulation()
        {
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

            // looping through the Parent nodes until we get to the start node
            Stack<matrixNode> path = new Stack<matrixNode>();

            while (endNode.x != beginX || endNode.y != beginY)
            {
                path.Push(endNode);
                endNode = endNode.parent;
            }
            path.Push(endNode);

            int x, y;
            x = 7;
            y = 7;

            // lets the jet fly
            while (path.Count > 0)
            {
                matrixNode node = path.Pop();

                if (node.x < x)
                {
                    for (int i = 0; i < 33; i++)
                    {
                        lblPilot.Location = new Point(lblPilot.Location.X, lblPilot.Location.Y - 2);
                        Thread.Sleep(10);
                    }
                    x = node.x;
                }

                if (node.y < y)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        lblPilot.Location = new Point(lblPilot.Location.X - 2, lblPilot.Location.Y);
                        Thread.Sleep(10);
                    }
                    y = node.y;
                }
                //progressBarFuel.Increment(-CalculateFuelConsumption());     // accurately decrease bar to reflect fuel
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }



        private void button2_Click(object sender, EventArgs e)
        {
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
        }
    }
}
