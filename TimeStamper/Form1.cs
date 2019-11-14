using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeStamper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void calc_button_Click(object sender, EventArgs e)
        {
            string start_time = StartTimeTextBox.Text;
            string end_time = EndTimeTextBox.Text;
            
            //strip into usable numbers
            string[] start_split = start_time.Split(':','.');
            string[] end_split = end_time.Split(':','.');


            int start_hour = int.Parse(start_split[0]);
            int start_min = int.Parse(start_split[1]);


            Debug.WriteLine("start");
            Debug.WriteLine(start_hour);
            Debug.WriteLine(start_min);
     

            int end_hour = int.Parse(end_split[0]);
            int end_min = int.Parse(end_split[1]);
     

            Debug.WriteLine("end");
            Debug.WriteLine(end_hour);
            Debug.WriteLine(end_min);
         

            //always assume that the end is after the start for now
            int hour = 0;
            int min = 0;

            //do this if it has passed midnight
            if (start_hour > end_hour)
            {
                hour = (24 - start_hour) + end_hour;
            }

            else
            {
                hour = end_hour - start_hour;
            }

            if(start_min <= end_min)
            {
                min = end_min - start_min;
            }

            else
            {
                hour = hour - 1;
                min = (end_min - start_min) + 60;
            }
            Debug.WriteLine("result");
            Debug.WriteLine(hour);
            ResultTextBox.Text = hour.ToString() + ":" + min.ToString("D2"); 
 

        }

        private void EndTimeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                calc_button.PerformClick();
                // these last two lines will stop the beep sound
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void EndTimeTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
