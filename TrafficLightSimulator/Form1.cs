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
    public partial class Form1 : Form
    {
        PictureBox[,] imageGrid = null;
        public Form1()
        {
            InitializeComponent();
            DrawGridArray(9,5);
        }

        public void DrawGridArray(int rows, int coloums)
        {
            imageGrid = new System.Windows.Forms.PictureBox[rows, coloums];
            // Row 
            for (int i = 0; i < rows; i++)
            {
                // Coloum
                for (int j = 0; j < coloums; j++)
                {
                    imageGrid[i, j] = new System.Windows.Forms.PictureBox();
                    imageGrid[i, j].Location = new Point(i * 101 + 370, j * 101 + 60);
                    imageGrid[i, j].Width = 101;
                    imageGrid[i, j].Height = 101;
                    imageGrid[i, j].Visible = true;
                    imageGrid[i, j].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    imageGrid[i, j].BringToFront();
                    this.Controls.Add(imageGrid[i, j]);
                    imageGrid[i, j].AllowDrop = true;
                    imageGrid[i, j].DragEnter += new System.Windows.Forms.DragEventHandler(image_DragEnter);
                    imageGrid[i, j].DragDrop += new System.Windows.Forms.DragEventHandler(image_DragDrop);
                }
            }
        }
        private void image_DragDrop(object sender , DragEventArgs e)
        {

        }
        private void image_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

    }
}
