using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace Sift
{
    public partial class ReplaceBooks : Form
    {
        //relates to the dragging of the window
        Point lastPoint;

        //allows the application to generate random numbers
        static Random rand = new Random();

        //declaration of the lists -- one that the application will use as comparison and the other for the user to populate
        List<string> lstCodes = new List<string>();
        List<string> lstUserCodes = new List<string>();

        //all required variables for the application to function correctly
        static int intRand, intCount;
        static string strRand, strRand2;

        //variable that holds the total time a user takes to sort the call numbers
        double dblTicks;

        //allows the application to keep track on how long a task has been running
        Stopwatch sw = new Stopwatch();

        public ReplaceBooks()
        {
            InitializeComponent();

            //starts the stopwatch
            sw.Start();

            //ensures that the lists are always empty and do not hold old data
            lstCodes.Clear();
            lstUserCodes.Clear();

            //declares where count begins
            intCount = 0;

            addTransparency();

            //generates a call number exactly as shown in the question paper and assigns that value to a button
            //at the same time writes that value into one of the two lists
            intRand = generateRandomNumber();
            strRand = intRand.ToString("000");
            intRand = generateRandomNumber();
            strRand2 = intRand.ToString("00");
            button2.Text = strRand + "." + strRand2 + " " + generateRandomName().ToString();
            lstCodes.Add(button2.Text);

            //generates a call number exactly as shown in the question paper and assigns that value to a button
            //at the same time writes that value into one of the two lists
            intRand = generateRandomNumber();
            strRand = intRand.ToString("000");
            intRand = generateRandomNumber();
            strRand2 = intRand.ToString("00");
            button3.Text = strRand + "." + strRand2 + " " + generateRandomName().ToString();
            lstCodes.Add(button3.Text);

            //generates a call number exactly as shown in the question paper and assigns that value to a button
            //at the same time writes that value into one of the two lists
            intRand = generateRandomNumber();
            strRand = intRand.ToString("000");
            intRand = generateRandomNumber();
            strRand2 = intRand.ToString("00");
            button4.Text = strRand + "." + strRand2 + " " + generateRandomName().ToString();
            lstCodes.Add(button4.Text);

            //generates a call number exactly as shown in the question paper and assigns that value to a button
            //at the same time writes that value into one of the two lists
            intRand = generateRandomNumber();
            strRand = intRand.ToString("000");
            intRand = generateRandomNumber();
            strRand2 = intRand.ToString("00");
            button5.Text = strRand + "." + strRand2 + " " + generateRandomName().ToString();
            lstCodes.Add(button5.Text);

            //generates a call number exactly as shown in the question paper and assigns that value to a button
            //at the same time writes that value into one of the two lists
            intRand = generateRandomNumber();
            strRand = intRand.ToString("000");
            intRand = generateRandomNumber();
            strRand2 = intRand.ToString("00");
            button6.Text = strRand + "." + strRand2 + " " + generateRandomName().ToString();
            lstCodes.Add(button6.Text);

            //generates a call number exactly as shown in the question paper and assigns that value to a button
            //at the same time writes that value into one of the two lists
            intRand = generateRandomNumber();
            strRand = intRand.ToString("000");
            intRand = generateRandomNumber();
            strRand2 = intRand.ToString("00");
            button7.Text = strRand + "." + strRand2 + " " + generateRandomName().ToString();
            lstCodes.Add(button7.Text);

            //generates a call number exactly as shown in the question paper and assigns that value to a button
            //at the same time writes that value into one of the two lists
            intRand = generateRandomNumber();
            strRand = intRand.ToString("000");
            intRand = generateRandomNumber();
            strRand2 = intRand.ToString("00");
            button8.Text = strRand + "." + strRand2 + " " + generateRandomName().ToString();
            lstCodes.Add(button8.Text);

            //generates a call number exactly as shown in the question paper and assigns that value to a button
            //at the same time writes that value into one of the two lists
            intRand = generateRandomNumber();
            strRand = intRand.ToString("000");
            intRand = generateRandomNumber();
            strRand2 = intRand.ToString("00");
            button9.Text = strRand + "." + strRand2 + " " + generateRandomName().ToString();
            lstCodes.Add(button9.Text);

            //generates a call number exactly as shown in the question paper and assigns that value to a button
            //at the same time writes that value into one of the two lists
            intRand = generateRandomNumber();
            strRand = intRand.ToString("000");
            intRand = generateRandomNumber();
            strRand2 = intRand.ToString("00");
            button10.Text = strRand + "." + strRand2 + " " + generateRandomName().ToString();
            lstCodes.Add(button10.Text);

            //generates a call number exactly as shown in the question paper and assigns that value to a button
            //at the same time writes that value into one of the two lists
            intRand = generateRandomNumber();
            strRand = intRand.ToString("000");
            intRand = generateRandomNumber();
            strRand2 = intRand.ToString("00");
            button11.Text = strRand + "." + strRand2 + " " + generateRandomName().ToString();
            lstCodes.Add(button11.Text);

            //sorts the array in the correct ascending order -- this is what the user needs to achieve
            lstCodes.Sort();

            //shows the count that the application relies on to correctly add values into the array -- this doubles as the progress indication for the user
            label5.Text = intCount.ToString();
            progressBar1.Value = intCount * 10;



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

        private void button1_Click(object sender, EventArgs e)
        {
            Global.a1.blnArrivingFromId = false;

            //makes a comparison to see if the user array is identical to the generated, already sorted array
            if (lstCodes.SequenceEqual(lstUserCodes))
            {
                //if true stops the stopwatch and records the seconds
                sw.Stop();
                dblTicks = sw.Elapsed.TotalSeconds;

                //decision structure to determine which achievements to assign to the user
                if (dblTicks < 15)
                {
                    //checks if the user has previous completed the program as an achievement is always given for compeleting the task successfully
                    if (!Global.a1.blnCompleteted.Equals(true))
                    {

                        Global.a1.blnCompleteted = true;
                        this.Alert("Certified curator");

                        Global.a1.blnMaster = true;
                        this.Alert("Master");

                        Global.a1.blnPro = true;
                        this.Alert("Pro");

                        Global.a1.blnNovice = true;
                        this.Alert("Novice");

                        Success success = new Success();
                        this.Hide();
                        success.Show();

                    } else
                    {
                        Success success = new Success();
                        this.Hide();
                        success.Show();
                    }

                }
                //decision structure to determine which achievements to assign to the user
                else if (dblTicks < 30)
                {
                    //checks if the user has previous completed the program as an achievement is always given for compeleting the task successfully
                    if (!Global.a1.blnCompleteted.Equals(true))
                    {

                        Global.a1.blnCompleteted = true;
                        this.Alert("Certified curator");

                        Global.a1.blnPro = true;
                        this.Alert("Pro");

                        Global.a1.blnNovice = true;
                        this.Alert("Novice");

                        Success success = new Success();
                        this.Hide();
                        success.Show();

                    }
                    else
                    {
                        //checks if the user has previous completed the program as an achievement is always given for compeleting the task successfully
                        if (!Global.a1.blnPro.Equals(true))
                        {
                            Global.a1.blnPro = true;
                            this.Alert("Pro");

                            Global.a1.blnNovice = true;
                            this.Alert("Novice");

                            Success success = new Success();
                            this.Hide();
                            success.Show();
                        } else
                        {

                            Success success = new Success();
                            this.Hide();
                            success.Show();
                        }

                        
                    }
                }
                //decision structure to determine which achievements to assign to the user
                else if (dblTicks < 60)
                {
                    //checks if the user has previous completed the program as an achievement is always given for compeleting the task successfully
                    if (!Global.a1.blnCompleteted.Equals(true))
                    {

                        Global.a1.blnCompleteted = true;
                        this.Alert("Certified curator");

                        Global.a1.blnNovice = true;
                        this.Alert("Novice");

                        Success success = new Success();
                        this.Hide();
                        success.Show();

                    }
                    else
                    {

                        Success success = new Success();
                        this.Hide();
                        success.Show();
                    }
                } else
                {
                    //checks if the user has previous completed the program as an achievement is always given for compeleting the task successfully
                    if (!Global.a1.blnCompleteted.Equals(true))
                    {
                        Global.a1.blnCompleteted = true;
                        this.Alert("Certified curator");

                        Success success = new Success();
                        this.Hide();
                        success.Show();
                    } else
                    {
                        Success success = new Success();
                        this.Hide();
                        success.Show();
                    }

                    
                }



            }
            else
            {

                //if the user has not correctly re-arranged the call numbers, the application will inform them -- this also resets everything so that they can start over
                Error error = new Error();
                error.Show();
                lstUserCodes.Clear();
                intCount = 0;
                progressBar1.Value = intCount;
                label5.Text = intCount.ToString();
            }
        }

        //the button that writes to the list
        private void button2_Click(object sender, EventArgs e)
        {
            //checks if the user has already entered 10 numbers or not -- prevents the application from breaking
            if (intCount == 10)
            {

            }
            else
            {

                lstUserCodes.Insert(intCount, button2.Text);
                intCount++;
                label5.Text = intCount.ToString();
                progressBar1.Value = intCount * 10; ;
            }


        }

        //the button that writes to the list
        private void button3_Click(object sender, EventArgs e)
        {
            //checks if the user has already entered 10 numbers or not -- prevents the application from breaking
            if (intCount == 10)
            {

            }
            else
            {
                lstUserCodes.Insert(intCount, button3.Text);
                intCount++;
                label5.Text = intCount.ToString();
                progressBar1.Value = intCount * 10;
            }

        }

        //the button that writes to the list
        private void button4_Click(object sender, EventArgs e)
        {
            //checks if the user has already entered 10 numbers or not -- prevents the application from breaking
            if (intCount == 10)
            {

            }
            else
            {
                lstUserCodes.Insert(intCount, button4.Text);
                intCount++;
                label5.Text = intCount.ToString();
                progressBar1.Value = intCount * 10;
            }

        }

        //the button that writes to the list
        private void button5_Click(object sender, EventArgs e)
        {
            //checks if the user has already entered 10 numbers or not -- prevents the application from breaking
            if (intCount == 10)
            {

            }
            else
            {
                lstUserCodes.Insert(intCount, button5.Text);
                intCount++;
                label5.Text = intCount.ToString();
                progressBar1.Value = intCount * 10;
            }

        }

        //the button that writes to the list
        private void button6_Click(object sender, EventArgs e)
        {
            //checks if the user has already entered 10 numbers or not -- prevents the application from breaking
            if (intCount == 10)
            {

            }
            else
            {
                lstUserCodes.Insert(intCount, button6.Text);
                intCount++;
                label5.Text = intCount.ToString();
                progressBar1.Value = intCount * 10;
            }


        }

        //the button that writes to the list
        private void button7_Click(object sender, EventArgs e)
        {
            //checks if the user has already entered 10 numbers or not -- prevents the application from breaking
            if (intCount == 10)
            {

            }
            else
            {
                lstUserCodes.Insert(intCount, button7.Text);
                intCount++;
                label5.Text = intCount.ToString();
                progressBar1.Value = intCount * 10;
            }


        }

        //the button that writes to the list
        private void button8_Click(object sender, EventArgs e)
        {
            //checks if the user has already entered 10 numbers or not -- prevents the application from breaking
            if (intCount == 10)
            {

            }
            else
            {
                lstUserCodes.Insert(intCount, button8.Text);
                intCount++;
                label5.Text = intCount.ToString();
                progressBar1.Value = intCount * 10;
            }


        }

        //the button that writes to the list
        private void button9_Click(object sender, EventArgs e)
        {
            //checks if the user has already entered 10 numbers or not -- prevents the application from breaking
            if (intCount == 10)
            {

            }
            else
            {
                lstUserCodes.Insert(intCount, button9.Text);
                intCount++;
                label5.Text = intCount.ToString();
                progressBar1.Value = intCount * 10;
            }


        }

        //the button that writes to the list
        private void button10_Click(object sender, EventArgs e)
        {
            //checks if the user has already entered 10 numbers or not -- prevents the application from breaking
            if (intCount == 10)
            {

            }
            else
            {
                lstUserCodes.Insert(intCount, button10.Text);
                intCount++;
                label5.Text = intCount.ToString();
                progressBar1.Value = intCount * 10;
            }

        }

        //the button that writes to the list
        private void button11_Click(object sender, EventArgs e)
        {
            //checks if the user has already entered 10 numbers or not -- prevents the application from breaking
            if (intCount == 10)
            {

            }
            else
            {
                lstUserCodes.Insert(intCount, button11.Text);
                intCount++;
                label5.Text = intCount.ToString();
                progressBar1.Value = intCount * 10;
            }


        }

        //the button that writes to the list
        private void button12_Click(object sender, EventArgs e)
        {
            //checks if the user has already entered 10 numbers or not -- prevents the application from breaking
            if (intCount == 0)
            {

            }
            else
            {
                intCount--;
                lstUserCodes.RemoveAt(intCount);
                label5.Text = intCount.ToString();
                progressBar1.Value = intCount * 10;
            }

        }

        //generates the random number from 1 - 100
        public int generateRandomNumber(int min = 1, int max = 100)
        {
            return rand.Next(min, max);
        }

        //generates a random 3 letter word to emulate an author surname
        public static string generateRandomName(int length = 3)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var randomString = new string(Enumerable.Repeat(chars, length).Select(s => s[rand.Next(s.Length)]).ToArray());

            return randomString;
        }

        //makes certain elements transparent so they look nice over the background
        public void addTransparency()
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

            var pos4 = this.PointToScreen(label4.Location);
            pos4 = pictureBox1.PointToClient(pos4);
            label4.Parent = pictureBox1;
            label4.Location = pos4;
            label4.BackColor = Color.Transparent;

            var pos5 = this.PointToScreen(label5.Location);
            pos5 = pictureBox1.PointToClient(pos5);
            label5.Parent = pictureBox1;
            label5.Location = pos5;
            label5.BackColor = Color.Transparent;
        }

        //the method responsible for triggering the achievement popup
        public void Alert(string msg)
        {
            Achievement frm = new Achievement();
            frm.showAlert(msg);
        }


    }
}
