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
    public partial class FindCallNumbers : Form
    {

        //window drag related
        Point lastPoint;

        static Random rand = new Random();
        static string strSecondLevel, strTopLevel;

        static string[] arrLines = System.IO.File.ReadAllLines("CallNumbers.txt");
        static List<string> lstTopLevel = new List<string>();
        static List<string> lstSecondLevel = new List<string>();
        static List<string> lstThirdLevel = new List<string>();
        static List<string> lstButtons = new List<string>();
        static string strLabelFirst, strButtonFirst;

        //the variables used to compare strings 
        static string strReadLine;
        static int intRand, intIndex = 0;

        public FindCallNumbers()
        {
            InitializeComponent();

            //adds transparancy to certain UI elements for the background image
            addTransparency();

            lstTopLevel.Clear();
            lstSecondLevel.Clear();
            lstThirdLevel.Clear();
            lstButtons.Clear();


            //a loop that loops through the the file and splits it accordingly
            foreach (string line in arrLines)
            {

                if (line.StartsWith("000") || line.StartsWith("100") || line.StartsWith("200") || line.StartsWith("300") || line.StartsWith("400") || line.StartsWith("500") || line.StartsWith("600") || line.StartsWith("700") || line.StartsWith("800") || line.StartsWith("900"))
                {
                    lstTopLevel.Add(line);
                }

                if (line.StartsWith("\t\t"))
                {
                    strReadLine = line;
                    strReadLine = strReadLine.Trim('\t');
                    lstThirdLevel.Add(strReadLine);
                }

                if (line.StartsWith("\t") && !(line.StartsWith("\t\t")))
                {
                    strReadLine = line;
                    strReadLine = strReadLine.Trim('\t');
                    lstSecondLevel.Add(strReadLine);
                }

            }

            //random number generator
            intRand = generateRandomNumber();
            strReadLine = lstThirdLevel[intRand];
            label2.Text = strReadLine.Substring(4);

            //taking only the first few characters of a string for comparison
            strSecondLevel = strReadLine.Substring(0, 2);
            strTopLevel = strReadLine.Substring(0, 1);

            //finding an index or something idk
            for (int i = 0; i < lstTopLevel.Count; i++)
            {
                if (lstTopLevel[i].StartsWith(strTopLevel))
                {
                    lstButtons.Add(lstTopLevel[i]);
                    intIndex = i;
                }
            }

            //this ensures that we do not have repeats or two of the same answers in the button selection -- hasn't failed yet
            for (int i = 0; i < 3; i++)
            {

                intRand = rand.Next(0, 9);

                if (lstButtons.Contains(lstTopLevel[intIndex]) && lstButtons.Contains(lstTopLevel[intRand]))
                {
                    while (lstButtons.Contains(lstTopLevel[intIndex]) && lstButtons.Contains(lstTopLevel[intRand]))
                    {
                        intRand = rand.Next(0, 9);
                    }
                }
                lstButtons.Add(lstTopLevel[intRand]);
            }

            //sorts the list as was asked for in the task
            lstButtons.Sort();


            //finally sets all the buttons text to the recorded data
            button1.Text = lstButtons[0];
            button2.Text = lstButtons[1];
            button3.Text = lstButtons[2];
            button4.Text = lstButtons[3];



        }
        
        //all the logic for the button click
        private void button1_Click(object sender, EventArgs e)
        {
            //disables all buttons upon clicking the button
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

            //changes the back colour
            button1.BackColor = Color.LightGray;
            button2.BackColor = Color.LightGray;
            button3.BackColor = Color.LightGray;
            button4.BackColor = Color.LightGray;

            //changes the font colour to a more disabled colour (???)
            button1.ForeColor = Color.Gray;
            button2.ForeColor = Color.Gray;
            button3.ForeColor = Color.Gray;
            button4.ForeColor = Color.Gray;
            button4.FlatAppearance.BorderColor = Color.LightGray;

            //transfers focus onto another label by darkening the existing label and making the next one brighter
            label1.ForeColor = Color.Gainsboro;
            label4.ForeColor = Color.White;

            
            //taking the first character again
            strLabelFirst = strReadLine.Substring(0, 1);
            strButtonFirst = button1.Text.Substring(0, 1);


            //checks if the two selections are matching
            if (strLabelFirst.Equals(strButtonFirst))
            {
                //populates and enables the combobox
                comboBox1.Items.Add("Please select an item");
                comboBox1.SelectedIndex = 0;
                comboBox1.Enabled = true;

                //if there is a matching selection or something
                for (int i = 0; i < lstSecondLevel.Count; i++)
                {
                    if (lstSecondLevel[i].StartsWith(strButtonFirst))
                    {
                        comboBox1.Items.Add(lstSecondLevel[i]);
                    }
                }
                
            }
            else
            {
                //failed attempt logic
                Global.a1.blnFailedSearch = true;
                Global.a1.blnArrivingFromId = false;
                Global.a1.blnArrivingFromSearch = true;

                Success success = new Success();
                this.Hide();
                success.Show();
            }

        }

        //identical logic as above, adjusted for the 2nd button
        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;


            button1.BackColor = Color.LightGray;
            button2.BackColor = Color.LightGray;
            button3.BackColor = Color.LightGray;
            button4.BackColor = Color.LightGray;

            button1.ForeColor = Color.Gray;
            button2.ForeColor = Color.Gray;
            button3.ForeColor = Color.Gray;
            button4.ForeColor = Color.Gray;
            button4.FlatAppearance.BorderColor = Color.LightGray;

            label1.ForeColor = Color.Gainsboro;
            label4.ForeColor = Color.White;



            strLabelFirst = strReadLine.Substring(0, 1);
            strButtonFirst = button2.Text.Substring(0, 1);

            if (strLabelFirst.Equals(strButtonFirst))
            {

                comboBox1.Items.Add("Please select an item");
                comboBox1.SelectedIndex = 0;
                comboBox1.Enabled = true;

                for (int i = 0; i < lstSecondLevel.Count; i++)
                {
                    if (lstSecondLevel[i].StartsWith(strButtonFirst))
                    {
                        comboBox1.Items.Add(lstSecondLevel[i]);
                    }
                }

            }
            else
            {
                Global.a1.blnFailedSearch = true;
                Global.a1.blnArrivingFromId = false;
                Global.a1.blnArrivingFromSearch = true;

                Success success = new Success();
                this.Hide();
                success.Show();
            }
        }

        //identical logic as above, adjusted for the 3rd button
        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;


            button1.BackColor = Color.LightGray;
            button2.BackColor = Color.LightGray;
            button3.BackColor = Color.LightGray;
            button4.BackColor = Color.LightGray;

            button1.ForeColor = Color.Gray;
            button2.ForeColor = Color.Gray;
            button3.ForeColor = Color.Gray;
            button4.ForeColor = Color.Gray;
            button4.FlatAppearance.BorderColor = Color.LightGray;

            label1.ForeColor = Color.Gainsboro;
            label4.ForeColor = Color.White;



            strLabelFirst = strReadLine.Substring(0, 1);
            strButtonFirst = button3.Text.Substring(0, 1);


            if (strLabelFirst.Equals(strButtonFirst))
            {

                comboBox1.Items.Add("Please select an item");
                comboBox1.SelectedIndex = 0;
                comboBox1.Enabled = true;

                for (int i = 0; i < lstSecondLevel.Count; i++)
                {
                    if (lstSecondLevel[i].StartsWith(strButtonFirst))
                    {
                        comboBox1.Items.Add(lstSecondLevel[i]);
                    }
                }

            }
            else
            {
                Global.a1.blnFailedSearch = true;
                Global.a1.blnArrivingFromId = false;
                Global.a1.blnArrivingFromSearch = true;

                Success success = new Success();
                this.Hide();
                success.Show();
            }
        }

        //identical logic as above, adjusted for the 4th button
        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;


            button1.BackColor = Color.LightGray;
            button2.BackColor = Color.LightGray;
            button3.BackColor = Color.LightGray;
            button4.BackColor = Color.LightGray;

            button1.ForeColor = Color.Gray;
            button2.ForeColor = Color.Gray;
            button3.ForeColor = Color.Gray;
            button4.ForeColor = Color.Gray;
            button4.FlatAppearance.BorderColor = Color.LightGray;

            label1.ForeColor = Color.Gainsboro;
            label4.ForeColor = Color.White;



            strLabelFirst = strReadLine.Substring(0, 1);
            strButtonFirst = button4.Text.Substring(0, 1);

            if (strLabelFirst.Equals(strButtonFirst))
            {

                comboBox1.Items.Add("Please select an item");
                comboBox1.SelectedIndex = 0;
                comboBox1.Enabled = true;

                for (int i = 0; i < lstSecondLevel.Count; i++)
                {
                    if (lstSecondLevel[i].StartsWith(strButtonFirst))
                    {
                        comboBox1.Items.Add(lstSecondLevel[i]);
                    }
                }

            }
            else
            {
                Global.a1.blnFailedSearch = true;
                Global.a1.blnArrivingFromId = false;
                Global.a1.blnArrivingFromSearch = true;

                Success success = new Success();
                this.Hide();
                success.Show();
            }
        }

        //the close button as the application lacks a traditional window with controls
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //checks what the user selected in the first combobox, this is to ensure they selected the correct answer
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;

            string strSelection = comboBox1.SelectedItem.ToString();

            string strFirstTwoOfSelection = strSelection.Substring(0, 2);

            for (int i = 0; i < lstThirdLevel.Count; i++)
            {
                if (lstThirdLevel[i].StartsWith(strFirstTwoOfSelection))
                {
                    comboBox2.Items.Add(lstThirdLevel[i]);
                }
            }

            int intIndex = comboBox2.FindString(strReadLine);

            if (intIndex.Equals(-1))
            {
                Global.a1.blnFailedSearch = true;
                Global.a1.blnArrivingFromId = false;
                Global.a1.blnArrivingFromSearch = true;

                Success success = new Success();
                this.Hide();
                success.Show();
            }
            else
            {
                comboBox2.Enabled = true;
                label4.ForeColor = Color.Gainsboro;
                label8.ForeColor = Color.White;
            }
        }

       //some aesthetic changes for the close label, changes the colour when hovering over it
        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Red;
        }

        //returns the original colour back to the label when leaving the hover
        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.White;
        }

        //checks if the value of the second combobox is correct and either awards or shames user
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString().Equals(strReadLine))
            {

                if (!(Global.a1.blnBeatenSearch.Equals(true)))
                {
                    this.Alert("Hide and Seek");
                }

                Global.a1.blnBeatenSearch = true;
                Global.a1.blnFailedSearch = false;
                Global.a1.blnArrivingFromId = false;
                Global.a1.blnArrivingFromSearch = true;

                Success success = new Success();
                this.Hide();
                success.Show();
            } else
            {
                Global.a1.blnFailedSearch = true;
                Global.a1.blnArrivingFromId = false;
                Global.a1.blnArrivingFromSearch = true;

                Success success = new Success();
                this.Hide();
                success.Show();
            }
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

        //allows the user to move the panel as the traditional title bar was removed
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        //generates a random number from 0 - 461
        public int generateRandomNumber(int min = 0, int max = 461)
        {
            return rand.Next(min, max);
        }

        //allowing certain labels to have transparency for the background image
        public void addTransparency()
        {
            var pos = this.PointToScreen(label6.Location);
            pos = pictureBox1.PointToClient(pos);
            label6.Parent = pictureBox1;
            label6.Location = pos;
            label6.BackColor = Color.Transparent;

            var pos2 = this.PointToScreen(label5.Location);
            pos2 = pictureBox1.PointToClient(pos2);
            label5.Parent = pictureBox1;
            label5.Location = pos2;
            label5.BackColor = Color.Transparent;

            var pos3 = this.PointToScreen(label7.Location);
            pos3 = pictureBox1.PointToClient(pos3);
            label7.Parent = pictureBox1;
            label7.Location = pos3;
            label7.BackColor = Color.Transparent;

            var pos4 = this.PointToScreen(label1.Location);
            pos4 = pictureBox1.PointToClient(pos4);
            label1.Parent = pictureBox1;
            label1.Location = pos4;
            label1.BackColor = Color.Transparent;

            var pos5 = this.PointToScreen(label2.Location);
            pos5 = pictureBox1.PointToClient(pos5);
            label2.Parent = pictureBox1;
            label2.Location = pos5;
            label2.BackColor = Color.Transparent;

            var pos6 = this.PointToScreen(label4.Location);
            pos6 = pictureBox1.PointToClient(pos6);
            label4.Parent = pictureBox1;
            label4.Location = pos6;
            label4.BackColor = Color.Transparent;

            var pos7 = this.PointToScreen(label8.Location);
            pos7 = pictureBox1.PointToClient(pos7);
            label8.Parent = pictureBox1;
            label8.Location = pos7;
            label8.BackColor = Color.Transparent;

            var pos8 = this.PointToScreen(label3.Location);
            pos8 = pictureBox1.PointToClient(pos8);
            label3.Parent = pictureBox1;
            label3.Location = pos8;
            label3.BackColor = Color.Transparent;
        }

        //the method responsible for triggering the achievement popup
        public void Alert(string msg)
        {
            Achievement frm = new Achievement();
            frm.showAlert(msg);
        }


    }
}
