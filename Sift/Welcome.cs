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
    public partial class Welcome : Form
    {

        Point lastPoint;

        public Welcome()
        {
            InitializeComponent();

            addTransparency();

        }

        //exits the application when clicking exit
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //allows the user to move the window as the traditional titlebar has been removed
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        //triggers the book re-ordering task
        private void button1_Click(object sender, EventArgs e)
        {
            ReplaceBooks replace = new ReplaceBooks();

            this.Hide();
            replace.Show();
        }

        //triggers the call number identification task
        private void button2_Click(object sender, EventArgs e)
        {
            Identify identify = new Identify();

            this.Hide();
            identify.Show();
        }

        //allows the user to view their achievements
        private void button4_Click(object sender, EventArgs e)
        {
            Acomplishments acc = new Acomplishments();
            acc.Show();
            this.Hide();
        }

        //makes certain elements transparent so they look nice over the background
        private void addTransparency()
        {
            var pos = this.PointToScreen(label1.Location);
            pos = pictureBox1.PointToClient(pos);
            label1.Parent = pictureBox1;
            label1.Location = pos;
            label1.BackColor = Color.Transparent;

            var pos2 = this.PointToScreen(label2.Location);
            pos2 = pictureBox1.PointToClient(pos2);
            label2.Parent = pictureBox1;
            label2.Location = pos2;
            label2.BackColor = Color.Transparent;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FindCallNumbers findCallNumbers = new FindCallNumbers();
            findCallNumbers.Show();
            this.Hide();
        }
    }
}
