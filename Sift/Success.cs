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
    public partial class Success : Form
    {

        Point lastPoint;

        public Success()
        {
            InitializeComponent();

            addTransparency();

            if (Global.a1.blnArrivingFromId == true)
            {
                label3.Text = "Well done! You successfully matched the call numbers with their corresponding definition. " +
                    "If you wish to go again please select the 'go again' button or else you may return to the main menu.";

                button2.BackColor = Color.SandyBrown;
                button2.Text = "Go again";

            }
            else if (Global.a1.blnArrivingFromSearch == true)
            {

                if (Global.a1.blnFailedSearch == true)
                {
                    label2.Text = "Oh no!";
                    label3.Text = "It looks like you have selected the incorrect option, if you wish to try again please hit the " +
                        "'go again' button or else you may return to the main menu.";

                    button2.BackColor = Color.SandyBrown;
                    button2.Text = "Go again";
                } else
                {
                    label3.Text = "Well done! You successfully matched the call number with its top level definition. " +
                    "If you wish to go again please select the 'go again' button or else you may return to the main menu.";

                    button2.BackColor = Color.SandyBrown;
                    button2.Text = "Go again";
                }

                

            }
        }

        //the close button for the application as the original was removed as a design choice
        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //allows the user to move the panel as the traditional title bar was removed
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

        //changes the colour of the x when being hovered over
        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
        }

        //allows the x to go back to its original colour when no longer hovering over it
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        //allows the user to exit the application if they are done using it
        private void button2_Click(object sender, EventArgs e)
        {

            if (Global.a1.blnArrivingFromId == true)
            {
                Identify identify = new Identify();
                this.Hide();
                identify.Show();
            }
            else if (Global.a1.blnArrivingFromSearch == true)
            {
                FindCallNumbers findcallnumbers = new FindCallNumbers();
                this.Hide();
                findcallnumbers.Show();
            }
            else
            {
                Application.Exit();
            }

            
           
        }

        //returns the user back to the welcome screen
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            Welcome welcome = new Welcome();

            welcome.Show();
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

            var pos3 = this.PointToScreen(label3.Location);
            pos3 = pictureBox1.PointToClient(pos3);
            label3.Parent = pictureBox1;
            label3.Location = pos3;
            label3.BackColor = Color.Transparent;
        }
    }
}
