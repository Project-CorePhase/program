using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficLightSimulator
{
    public partial class TrafficLightSimulator : Form
    {
        Simulator simulator;
        public TrafficLightSimulator()
        {
            InitializeComponent();
            simulator = new Simulator();
        }
        /* Drag & Drop Event*/
        private void pictureBoxGrid_DragDrop(object sender, DragEventArgs e)
        {
            // TODO Abdullah
            RoadObject roadObject = null; // Declaration
            Image draggedImage = (Image)e.Data.GetData(DataFormats.Bitmap); // Get Imaged Draged
            Point draggedPointer = new Point();
                roadObject = new Crossing(CrossingType.CrossingWithPedestrian,draggedPointer);
            

            if (draggedImage == pictureBox_CrossingA.Image)
            {
                Bitmap t = new Bitmap(draggedImage);
                roadObject = new Crossing(CrossingType.CrossingWithPedestrian, new Point()); // TODO : define the point
            }
        }
        private void pictureBoxGrid_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None; ;
            }
        }
        private void pictureBox_CrossingA_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox_CrossingA.DoDragDrop(pictureBox_CrossingA.Image, DragDropEffects.Copy);
            Console.WriteLine("Crossing A Mouse Down");
        }
        /* Form Load Event */

        /* Form Paint Event*/
        private void pictureBox_Grid_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            int SquareSize = 150;
            for (int i = 0; i < 4; i++)
            {
                gr.DrawLine(Pens.Black, 0, i * SquareSize, 6 * SquareSize, i * SquareSize);
            }
            for (int j = 0; j < 7; j++)
            {
                gr.DrawLine(Pens.LightGray, j * SquareSize, 0, j * SquareSize, 4 * SquareSize);
            }
        }
        /* Mouse Tracking*/
        private void TrafficLightSimulator_MouseMove(object sender, MouseEventArgs e)
        {
            label_MouseLocation.Text = e.Location.X + "," + e.Location.Y;
        }
        private void pictureBoxGrid_MouseMove(object sender, MouseEventArgs e)
        {
            label_MouseLocation.Text = e.Location.X + "," + e.Location.Y;
        }

        /*Menu Item */
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            simulator.SetTimerInterval(1000);
        }

   

    }
}
