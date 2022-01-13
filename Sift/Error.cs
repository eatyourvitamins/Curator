using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sift
{
    public partial class Error : Form
    {

        Point lastPoint;

        public Error()
        {
            InitializeComponent();

            if (Global.a1.blnIncorrectNumbers == true)
            {
                label3.Text = "It appears that the columns were not correctly matched, please try again.";
            } 

        }

        //dismisses the window
        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //dismisses the window instead of exiting the whole application
        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //allows the user to move the panel as the traditional title bar was removed
        private void Error_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Error_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}
