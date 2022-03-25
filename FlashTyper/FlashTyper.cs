using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using FlashTyperLibrary;

namespace flash
{
    public partial class FlashTyper : Form
    {
        Stopwatch stopWatch = new();
        List<string> words = new();

        int i = 0;
        int charsTyped = 0;

        public FlashTyper()
        {
            InitializeComponent();
        }
        
        private void ClearContents()
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox) ((TextBox)control).Text = null;
                if (control is Label) ((Label)control).Text = null;
            }

            lblTitle.Text = "Flash Typer - 1.0";
            timer1.Stop();
            stopWatch.Reset();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ClearContents();

            i = 0;
            words = null;
            charsTyped = 0;
            txtWords.Text = null;

            words = WordList.PossibleWords(Convert.ToInt32(cmbWordCount.SelectedItem));

            foreach (string word in words)
            {
                txtWords.Text += word + " ";
            }
        }

        private void FlashTyper_Load(object sender, EventArgs e)
        {
            cmbWordCount.SelectedIndex = 3;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = stopWatch.Elapsed;
            lblTime.Text = String.Format("Elapsed Time: {0:0:000}", ts.TotalMilliseconds);
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            timer1.Start();
            stopWatch.Start();

            if((Keys)e.KeyChar != Keys.Space || (Keys)e.KeyChar != Keys.Back)
            {
                charsTyped += 1;
            }

            try
            {
                if ((Keys)e.KeyChar == Keys.Space && txtInput.Text.Trim() == words[i] || txtInput.Text == words[i].ToUpper())
                {
                    txtWords.Text = txtWords.Text.Replace($"{words[i]} ", null);
                    txtInput.Text = "";

                    //Get the last word in the list, and end the test once it is detected
                    int wordToFind = Convert.ToInt32(cmbWordCount.SelectedItem) - 2;
                    if (!txtWords.Text.Contains(words[wordToFind]))
                    {
                        stopWatch.Stop();
                        lblWPM.Text = $"{(Math.Round((charsTyped / 5) / (stopWatch.Elapsed.TotalSeconds / 60))).ToString()} WPM";
                    }

                    i++;
                }
            } 
            catch(ArgumentOutOfRangeException)
            {

            }
        }
    }
}
