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
    public partial class Identify : Form
    {
        //window drag related
        Point lastPoint;

        //allows the application to generate random numbers
        static Random rand = new Random();

        //a list that allows for the population of the second column -- why is it not spelt collumn?
        static List<string> lstColB = new List<string>();
        static List<string> lstColBshuffled = new List<string>();

        //the extra dictionaries that make this application work correctly
        static Dictionary<string, string> dictUserAnswers = new Dictionary<string, string>();
        static Dictionary<string, string> dictAnswers = new Dictionary<string, string>();

        //the count used multiple times throughout the application
        static int intCount = 0;

        //the main dictionary holding the call numbers and their defintions
        static Dictionary<string, string> dictDeweyDecimal = new Dictionary<string, string>()
        {
            { "000", "Generalities" }, { "100", "Philosophy && psychology" },
            { "200", "Religion" }, { "300","Social sciences" },
            { "400", "Language"},{ "500", "Natural sciences && mathematics"},
            { "600", "Technology (Applied sciences)"}, {"700", "The arts"},
            { "800", "Literature && rhetoric"}, { "900", "Geography && history"}

        };

        public Identify()
        {
            InitializeComponent();
            addTransparency();

            if (Global.a1.blnAlternate == true)
            {
                //populates the first column
                foreach (Control control in tableColumnA.Controls)
                {
                    Label iconlabel = control as Label;
                    if (iconlabel != null)
                    {

                        int randomNumber = rand.Next(dictDeweyDecimal.Count);
                        iconlabel.Text = dictDeweyDecimal.ElementAt(randomNumber).Value.ToString();
                        lstColB.Add(dictDeweyDecimal.ElementAt(randomNumber).Key.ToString());

                        dictAnswers.Add(dictDeweyDecimal.ElementAt(randomNumber).Key.ToString(), dictDeweyDecimal.ElementAt(randomNumber).Value.ToString());

                        dictDeweyDecimal.Remove(dictDeweyDecimal.ElementAt(randomNumber).Key);


                    }
                }

                lstColB.AddRange(dictDeweyDecimal.Keys.Except(lstColB));


                for (int i = 0; i < 3; i++)
                {
                    lstColB.RemoveAt(lstColB.Count - 1);
                }

                foreach (string xString in lstColB)
                    lstColBshuffled.Insert(rand.Next(0, lstColBshuffled.Count + 1), xString);

                //populates the second column
                foreach (Control control in tableColumnB.Controls)
                {
                    Label iconlabel = control as Label;
                    if (iconlabel != null)
                    {

                        iconlabel.Text = lstColBshuffled[intCount];


                    }

                    intCount++;
                }
            }
            else
            {
                //populates the first column
                foreach (Control control in tableColumnA.Controls)
                {
                    Label iconlabel = control as Label;
                    if (iconlabel != null)
                    {

                        int randomNumber = rand.Next(dictDeweyDecimal.Count);
                        iconlabel.Text = dictDeweyDecimal.ElementAt(randomNumber).Key.ToString();
                        lstColB.Add(dictDeweyDecimal.ElementAt(randomNumber).Value.ToString());

                        dictAnswers.Add(dictDeweyDecimal.ElementAt(randomNumber).Key.ToString(), dictDeweyDecimal.ElementAt(randomNumber).Value.ToString());

                        dictDeweyDecimal.Remove(iconlabel.Text);


                    }
                }

                lstColB.AddRange(dictDeweyDecimal.Values.Except(lstColB));

                //removes the extra three rows of data that we don't use
                for (int i = 0; i < 3; i++)
                {
                    lstColB.RemoveAt(lstColB.Count - 1);
                }

                //sorting the list 
                lstColB.Sort();

                //populating the second colummn
                foreach (Control control in tableColumnB.Controls)
                {
                    Label iconlabel = control as Label;
                    if (iconlabel != null)
                    {

                        iconlabel.Text = lstColB[intCount];


                    }

                    intCount++;
                }
            }

            
            //clears the dictionary to ensure clean data for re-use of the task
            dictDeweyDecimal.Clear();

            //adds all the original data back so the application can reuse it for the next run
            dictDeweyDecimal.Add("000", "Generalities");
            dictDeweyDecimal.Add("100", "Philosophy && psychology");
            dictDeweyDecimal.Add("200", "Religion");
            dictDeweyDecimal.Add("300", "Social sciences");
            dictDeweyDecimal.Add("400", "Language");
            dictDeweyDecimal.Add("500", "Natural sciences && mathematics");
            dictDeweyDecimal.Add("600", "Technology (Applied sciences)");
            dictDeweyDecimal.Add("700", "The arts");
            dictDeweyDecimal.Add("800", "Literature && rhetoric");
            dictDeweyDecimal.Add("900", "Geography && history");

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //this is the logic that alternates the data presented when running the task.
            if (Global.a1.blnAlternate == true)
            {
                //checks if the user has entered a number from 1-7 -- if so adds the relevant data into the user answer dictionary
                if (answerboxA.Text.Equals("1"))
                {
                    dictUserAnswers.Add(columnB1.Text, columnA1.Text);

                }
                else if (answerboxA.Text.Equals("2"))
                {
                    dictUserAnswers.Add(columnB2.Text, columnA1.Text);
                }
                else if (answerboxA.Text.Equals("3"))
                {
                    dictUserAnswers.Add(columnB3.Text, columnA1.Text);
                }
                else if (answerboxA.Text.Equals("4"))
                {
                    dictUserAnswers.Add(columnB4.Text, columnA1.Text);
                }
                else if (answerboxA.Text.Equals("5"))
                {
                    dictUserAnswers.Add(columnB5.Text, columnA1.Text);
                }
                else if (answerboxA.Text.Equals("6"))
                {
                    dictUserAnswers.Add(columnB6.Text, columnA1.Text);
                }
                else if (answerboxA.Text.Equals("7"))
                {
                    dictUserAnswers.Add(columnB7.Text, columnA1.Text);
                }
                else
                {

                }

                //checks if the user has entered a number from 1-7 -- if so adds the relevant data into the user answer dictionary
                if (answerboxB.Text.Equals("1"))
                {
                    dictUserAnswers.Add(columnB1.Text, columnA2.Text);

                }
                else if (answerboxB.Text.Equals("2"))
                {
                    dictUserAnswers.Add(columnB2.Text, columnA2.Text);
                }
                else if (answerboxB.Text.Equals("3"))
                {
                    dictUserAnswers.Add(columnB3.Text, columnA2.Text);
                }
                else if (answerboxB.Text.Equals("4"))
                {
                    dictUserAnswers.Add(columnB4.Text, columnA2.Text);
                }
                else if (answerboxB.Text.Equals("5"))
                {
                    dictUserAnswers.Add(columnB5.Text, columnA2.Text);
                }
                else if (answerboxB.Text.Equals("6"))
                {
                    dictUserAnswers.Add(columnB6.Text, columnA2.Text);
                }
                else if (answerboxB.Text.Equals("7"))
                {
                    dictUserAnswers.Add(columnB7.Text, columnA2.Text);
                }
                else
                {

                }

                //checks if the user has entered a number from 1-7 -- if so adds the relevant data into the user answer dictionary
                if (answerboxC.Text.Equals("1"))
                {
                    dictUserAnswers.Add(columnB1.Text, columnA3.Text);

                }
                else if (answerboxC.Text.Equals("2"))
                {
                    dictUserAnswers.Add(columnB2.Text, columnA3.Text);
                }
                else if (answerboxC.Text.Equals("3"))
                {
                    dictUserAnswers.Add(columnB3.Text, columnA3.Text);
                }
                else if (answerboxC.Text.Equals("4"))
                {
                    dictUserAnswers.Add(columnB4.Text, columnA3.Text);
                }
                else if (answerboxC.Text.Equals("5"))
                {
                    dictUserAnswers.Add(columnB5.Text, columnA3.Text);
                }
                else if (answerboxC.Text.Equals("6"))
                {
                    dictUserAnswers.Add(columnB6.Text, columnA3.Text);
                }
                else if (answerboxC.Text.Equals("7"))
                {
                    dictUserAnswers.Add(columnB7.Text, columnA3.Text);
                }
                else
                {

                }

                //checks if the user has entered a number from 1-7 -- if so adds the relevant data into the user answer dictionary
                if (answerboxD.Text.Equals("1"))
                {
                    dictUserAnswers.Add(columnB1.Text, columnA4.Text);

                }
                else if (answerboxD.Text.Equals("2"))
                {
                    dictUserAnswers.Add(columnB2.Text, columnA4.Text);
                }
                else if (answerboxD.Text.Equals("3"))
                {
                    dictUserAnswers.Add(columnB3.Text, columnA4.Text);
                }
                else if (answerboxD.Text.Equals("4"))
                {
                    dictUserAnswers.Add(columnB4.Text, columnA4.Text);
                }
                else if (answerboxD.Text.Equals("5"))
                {
                    dictUserAnswers.Add(columnB5.Text, columnA4.Text);
                }
                else if (answerboxD.Text.Equals("6"))
                {
                    dictUserAnswers.Add(columnB6.Text, columnA4.Text);
                }
                else if (answerboxD.Text.Equals("7"))
                {
                    dictUserAnswers.Add(columnB7.Text, columnA4.Text);
                }
                else
                {

                }
                 
            }
            else
            {

                //checks if the user has entered a number from 1-7 -- if so adds the relevant data into the user answer dictionary
                if (answerboxA.Text.Equals("1"))
                {
                    dictUserAnswers.Add(columnA1.Text, columnB1.Text);

                }
                else if (answerboxA.Text.Equals("2"))
                {
                    dictUserAnswers.Add(columnA1.Text, columnB2.Text);
                }
                else if (answerboxA.Text.Equals("3"))
                {
                    dictUserAnswers.Add(columnA1.Text, columnB3.Text);
                }
                else if (answerboxA.Text.Equals("4"))
                {
                    dictUserAnswers.Add(columnA1.Text, columnB4.Text);
                }
                else if (answerboxA.Text.Equals("5"))
                {
                    dictUserAnswers.Add(columnA1.Text, columnB5.Text);
                }
                else if (answerboxA.Text.Equals("6"))
                {
                    dictUserAnswers.Add(columnA1.Text, columnB6.Text);
                }
                else if (answerboxA.Text.Equals("7"))
                {
                    dictUserAnswers.Add(columnA1.Text, columnB7.Text);
                }
                else
                {

                }

                //checks if the user has entered a number from 1-7 -- if so adds the relevant data into the user answer dictionary
                if (answerboxB.Text.Equals("1"))
                {
                    dictUserAnswers.Add(columnA2.Text, columnB1.Text);

                }
                else if (answerboxB.Text.Equals("2"))
                {
                    dictUserAnswers.Add(columnA2.Text, columnB2.Text);
                }
                else if (answerboxB.Text.Equals("3"))
                {
                    dictUserAnswers.Add(columnA2.Text, columnB3.Text);
                }
                else if (answerboxB.Text.Equals("4"))
                {
                    dictUserAnswers.Add(columnA2.Text, columnB4.Text);
                }
                else if (answerboxB.Text.Equals("5"))
                {
                    dictUserAnswers.Add(columnA2.Text, columnB5.Text);
                }
                else if (answerboxB.Text.Equals("6"))
                {
                    dictUserAnswers.Add(columnA2.Text, columnB6.Text);
                }
                else if (answerboxB.Text.Equals("7"))
                {
                    dictUserAnswers.Add(columnA2.Text, columnB7.Text);
                }
                else
                {

                }

                //checks if the user has entered a number from 1-7 -- if so adds the relevant data into the user answer dictionary
                if (answerboxC.Text.Equals("1"))
                {
                    dictUserAnswers.Add(columnA3.Text, columnB1.Text);

                }
                else if (answerboxC.Text.Equals("2"))
                {
                    dictUserAnswers.Add(columnA3.Text, columnB2.Text);
                }
                else if (answerboxC.Text.Equals("3"))
                {
                    dictUserAnswers.Add(columnA3.Text, columnB3.Text);
                }
                else if (answerboxC.Text.Equals("4"))
                {
                    dictUserAnswers.Add(columnA3.Text, columnB4.Text);
                }
                else if (answerboxC.Text.Equals("5"))
                {
                    dictUserAnswers.Add(columnA3.Text, columnB5.Text);
                }
                else if (answerboxC.Text.Equals("6"))
                {
                    dictUserAnswers.Add(columnA3.Text, columnB6.Text);
                }
                else if (answerboxC.Text.Equals("7"))
                {
                    dictUserAnswers.Add(columnA3.Text, columnB7.Text);
                }
                else
                {

                }

                //checks if the user has entered a number from 1-7 -- if so adds the relevant data into the user answer dictionary
                if (answerboxD.Text.Equals("1"))
                {
                    dictUserAnswers.Add(columnA4.Text, columnB1.Text);

                }
                else if (answerboxD.Text.Equals("2"))
                {
                    dictUserAnswers.Add(columnA4.Text, columnB2.Text);
                }
                else if (answerboxD.Text.Equals("3"))
                {
                    dictUserAnswers.Add(columnA4.Text, columnB3.Text);
                }
                else if (answerboxD.Text.Equals("4"))
                {
                    dictUserAnswers.Add(columnA4.Text, columnB4.Text);
                }
                else if (answerboxD.Text.Equals("5"))
                {
                    dictUserAnswers.Add(columnA4.Text, columnB5.Text);
                }
                else if (answerboxD.Text.Equals("6"))
                {
                    dictUserAnswers.Add(columnA4.Text, columnB6.Text);
                }
                else if (answerboxD.Text.Equals("7"))
                {
                    dictUserAnswers.Add(columnA4.Text, columnB7.Text);
                }
                else
                {

                }           
            }

            //reordering the lists to ensure they can be compared identically, furthermore a check to see if they are in fact identical.
            var orderAns = dictAnswers.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            var orderUserAns = dictUserAnswers.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            bool blnAreEqual = orderAns.Keys.Count == orderUserAns.Keys.Count && orderAns.Keys.All(k => orderUserAns.ContainsKey(k) && object.Equals(orderUserAns[k], orderAns[k]));


            if (blnAreEqual == true)
            {

                //if the answer is correct, all lists and dictionaries are cleared for re-use, an acheivement is granted and flags are triggered for application functionality

                if (!(Global.a1.blnNumbersCompleted.Equals(true)))
                {
                    this.Alert("Certified Librarian");
                }

                Global.a1.blnNumbersCompleted = true;
                Global.a1.blnArrivingFromSearch = false;
                Global.a1.blnArrivingFromId = true;

                dictUserAnswers.Clear();
                dictAnswers.Clear();
                lstColB.Clear();
                lstColBshuffled.Clear();
                orderAns.Clear();
                orderUserAns.Clear();

                intCount = 0;

                if (Global.a1.blnAlternate == true)
                {
                    Global.a1.blnAlternate = false;
                }
                else
                {
                    Global.a1.blnAlternate = true;
                }

                Success success = new Success();
                this.Hide();
                success.Show();
            }
            else
            {

                //display an error if the answer was not correct

                Global.a1.blnIncorrectNumbers = true;

                Error error = new Error();
                error.Show();

                dictUserAnswers.Clear();

                answerboxA.Clear();
                answerboxB.Clear();
                answerboxC.Clear();
                answerboxD.Clear();
            }
        }

        //the method responsible for triggering the achievement popup
        public void Alert(string msg)
        {
            Achievement frm = new Achievement();
            frm.showAlert(msg);
        }

        //clears the text box so the user can just type when clicking into it -- just a quality of life feature
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (answerboxA.Text.Equals("1 - 7"))
            {
                answerboxA.Clear();
            }
        }

        //clears the text box so the user can just type when clicking into it -- just a quality of life feature
        private void textBox2_Click(object sender, EventArgs e)
        {
            if (answerboxB.Text.Equals("1 - 7"))
            {
                answerboxB.Clear();
            }
        }

        //clears the text box so the user can just type when clicking into it -- just a quality of life feature
        private void textBox3_Click(object sender, EventArgs e)
        {
            if (answerboxC.Text.Equals("1 - 7"))
            {
                answerboxC.Clear();
            }
        }

        //clears the text box so the user can just type when clicking into it -- just a quality of life feature
        private void textBox4_Click(object sender, EventArgs e)
        {
            if (answerboxD.Text.Equals("1 - 7"))
            {
                answerboxD.Clear();
            }
        }

        //exits the application due to the lack of a title bar with a close button
        private void label17_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //changes the label colour to red to connotate a possible closure of the application -- just some tactile feedback
        private void label17_MouseHover(object sender, EventArgs e)
        {
            label17.ForeColor = Color.Red;
        }

        //changes the text colour back to the original when hovering away from the label
        private void label17_MouseLeave(object sender, EventArgs e)
        {
            label17.ForeColor = Color.White;
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

        //makes certain elements transparent so they look nice over the background
        private void addTransparency()
        {
            var pos = this.PointToScreen(label1.Location);
            pos = pictureBox1.PointToClient(pos);
            label1.Parent = pictureBox1;
            label1.Location = pos;
            label1.BackColor = Color.Transparent;

            var pos2 = this.PointToScreen(label18.Location);
            pos2 = pictureBox1.PointToClient(pos2);
            label18.Parent = pictureBox1;
            label18.Location = pos2;
            label18.BackColor = Color.Transparent;

            var pos3 = this.PointToScreen(tableColumnA.Location);
            pos3 = pictureBox1.PointToClient(pos3);
            tableColumnA.Parent = pictureBox1;
            tableColumnA.Location = pos3;
            tableColumnA.BackColor = Color.Transparent;

            var pos4 = this.PointToScreen(tableColumnB.Location);
            pos4 = pictureBox1.PointToClient(pos4);
            tableColumnB.Parent = pictureBox1;
            tableColumnB.Location = pos4;
            tableColumnB.BackColor = Color.Transparent;

            var pos5 = this.PointToScreen(label17.Location);
            pos5 = pictureBox1.PointToClient(pos5);
            label17.Parent = pictureBox1;
            label17.Location = pos5;
            label17.BackColor = Color.Transparent;

            var pos6 = this.PointToScreen(label6.Location);
            pos6 = pictureBox1.PointToClient(pos6);
            label6.Parent = pictureBox1;
            label6.Location = pos6;
            label6.BackColor = Color.Transparent;

            var pos7 = this.PointToScreen(label7.Location);
            pos7 = pictureBox1.PointToClient(pos7);
            label7.Parent = pictureBox1;
            label7.Location = pos7;
            label7.BackColor = Color.Transparent;

            var pos8 = this.PointToScreen(label8.Location);
            pos8 = pictureBox1.PointToClient(pos8);
            label8.Parent = pictureBox1;
            label8.Location = pos8;
            label8.BackColor = Color.Transparent;

            var pos9 = this.PointToScreen(label9.Location);
            pos9 = pictureBox1.PointToClient(pos9);
            label9.Parent = pictureBox1;
            label9.Location = pos9;
            label9.BackColor = Color.Transparent;

            var pos10 = this.PointToScreen(label10.Location);
            pos10 = pictureBox1.PointToClient(pos10);
            label10.Parent = pictureBox1;
            label10.Location = pos10;
            label10.BackColor = Color.Transparent;

            var pos11 = this.PointToScreen(label11.Location);
            pos11 = pictureBox1.PointToClient(pos11);
            label11.Parent = pictureBox1;
            label11.Location = pos11;
            label11.BackColor = Color.Transparent;

            var pos12 = this.PointToScreen(label12.Location);
            pos12 = pictureBox1.PointToClient(pos12);
            label12.Parent = pictureBox1;
            label12.Location = pos12;
            label12.BackColor = Color.Transparent;

            var pos13 = this.PointToScreen(label2.Location);
            pos13 = pictureBox1.PointToClient(pos13);
            label2.Parent = pictureBox1;
            label2.Location = pos13;
            label2.BackColor = Color.Transparent;

            var pos14 = this.PointToScreen(label3.Location);
            pos14 = pictureBox1.PointToClient(pos14);
            label3.Parent = pictureBox1;
            label3.Location = pos14;
            label3.BackColor = Color.Transparent;

            var pos15 = this.PointToScreen(label4.Location);
            pos15 = pictureBox1.PointToClient(pos15);
            label4.Parent = pictureBox1;
            label4.Location = pos15;
            label4.BackColor = Color.Transparent;

            var pos16 = this.PointToScreen(label5.Location);
            pos16 = pictureBox1.PointToClient(pos16);
            label5.Parent = pictureBox1;
            label5.Location = pos16;
            label5.BackColor = Color.Transparent;

            var pos17 = this.PointToScreen(label13.Location);
            pos17 = pictureBox1.PointToClient(pos17);
            label13.Parent = pictureBox1;
            label13.Location = pos17;
            label13.BackColor = Color.Transparent;

            var pos18 = this.PointToScreen(label14.Location);
            pos18 = pictureBox1.PointToClient(pos18);
            label14.Parent = pictureBox1;
            label14.Location = pos18;
            label14.BackColor = Color.Transparent;

            var pos19 = this.PointToScreen(label15.Location);
            pos19 = pictureBox1.PointToClient(pos19);
            label15.Parent = pictureBox1;
            label15.Location = pos19;
            label15.BackColor = Color.Transparent;

            var pos20 = this.PointToScreen(label16.Location);
            pos20 = pictureBox1.PointToClient(pos20);
            label16.Parent = pictureBox1;
            label16.Location = pos20;
            label16.BackColor = Color.Transparent;
        }

    }
}
