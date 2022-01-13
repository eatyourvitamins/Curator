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
    public partial class Acomplishments : Form
    {
        public Acomplishments()
        {
            InitializeComponent();
            addTransparency();

            //checks if the user has earned the master achievement -- if so, all achievements below are unlock as well as they are mutually inclusive
            if (Global.a1.blnMaster.Equals(true))
            {
                label6.Visible = true;
                label13.Visible = true;
                label14.Visible = true;
                pictureBox5.Visible = true;

                label5.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                pictureBox4.Visible = true;

                label4.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                pictureBox3.Visible = true;

                label3.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                pictureBox2.Visible = true;

                label20.Visible = true;

            }
            //checks if the user has earned the pro achievement -- if so, all achievements below are unlock as well as they are mutually inclusive
            else if (Global.a1.blnPro.Equals(true))
            {
                label5.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                pictureBox4.Visible = true;

                label4.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                pictureBox3.Visible = true;

                label3.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                pictureBox2.Visible = true;

                label20.Visible = true;

            }
            //checks if the user has earned the novice achievement -- if so, all achievements below are unlock as well as they are mutually inclusive
            else if (Global.a1.blnNovice.Equals(true))
            {
                label4.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                pictureBox3.Visible = true;

                label3.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                pictureBox2.Visible = true;

                label20.Visible = true;
            }
            //checks if the user has completed the program but not quick enough for another achievement -- assigns only a single achievement
            else if (Global.a1.blnCompleteted.Equals(true))
            {
                label3.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                pictureBox2.Visible = true;

                label20.Visible = true;

            } else
            {
                //if no other condition is met, the empty achievements panel message is shown to encourage the user to go out and get an achievement
                label15.Visible = true;

            }

            if (Global.a1.blnNumbersCompleted.Equals(true))
            {
                label16.Visible = true;
                label17.Visible = true;
                label18.Visible = true;
                pictureBox6.Visible = true;

                label15.Visible = false;
                label19.Visible = true;
            }

            if (Global.a1.blnBeatenSearch.Equals(true))
            {
                label21.Visible = true;
                label22.Visible = true;
                label23.Visible = true;
                pictureBox7.Visible = true;

                label15.Visible = false;
                label19.Visible = true;
            }

        }

        //the close button for the application as the original was removed as a design choice
        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //this button returns you to the main menu
        private void button1_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
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

            var pos3 = this.PointToScreen(label15.Location);
            pos3 = pictureBox1.PointToClient(pos3);
            label15.Parent = pictureBox1;
            label15.Location = pos3;
            label15.BackColor = Color.Transparent;
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
    }
}
