using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /**********************************************************************
         * Team 4- Travis Johnson, George Gachoki, Jason Thomas, Tonya Martinez
         * May 19, 2020
         * CIS 123
         * Week 8 Murach Coding Assignments, 
         * Extra Exercise 8-1 Display Test Scores Array 
         * *******************************************************************/


        int total = 0;
        int count = 0;
        int[] scoresArray = new int[20];    //class variable that hold up to 20 scores              

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidData())
                {
                    int score = Convert.ToInt32(txtScore.Text);
                    //add scores thats entered to the array using count variable
                    scoresArray[count] = score; 
                    total += score;
                    count += 1;
                    int average = total / count;
                    txtScoreTotal.Text = total.ToString();
                    txtScoreCount.Text = count.ToString();
                    txtAverage.Text = average.ToString();
                    txtScore.Focus();
                }
            }
            catch (Exception ex)
            {
                //message box
                MessageBox.Show(ex.Message + "\n\n" +
               ex.GetType().ToString() + "\n" +
               ex.StackTrace, "Exception"); 
            }
            
        }

        public bool IsValidData()
        {
            return
            // Validate the Score text box
                IsPresent(txtScore, "Score") &&
                IsInt32(txtScore, "Score") &&
                IsWithinRange(txtScore, "Score", 01, 100);
        }

        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        public bool IsInt32(TextBox textBox, string name)
        {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be a valid integer.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }

        public bool IsWithinRange(TextBox textBox, string name,
            decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(name + " must be between " + min +
                    " and " + max + ".", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            //sort scores in array
            Array.Sort(scoresArray);
            string scoresString = "";
            foreach (int i in scoresArray)
                if (i != 0)
                {
                    scoresString += i.ToString() + "\n";
                }
            //message box showing sorted scores
            MessageBox.Show(scoresString, "Sorted Scores");
            //move focus to Score textbox
            txtScore.Focus();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            //clear scores list
            total = 0;
            count = 0;
            txtScore.Text = "";
            txtScoreTotal.Text = "";
            txtScoreCount.Text = "";
            txtAverage.Text = "";
            //move focus to Score textbox
            txtScore.Focus();
            //create new array and assign it to array variable
            scoresArray = new int[20]; 
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //exits the application

    }
}