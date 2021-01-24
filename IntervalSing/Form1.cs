using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Musicality
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Musicality.Initialise();
            InitializeComponent();
            comboBoxNote.SelectedItem = "A";
            comboBoxOctave.SelectedItem = "3";
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            if (!Musicality.IsPlaying)
            {
                int middleNote = comboBoxNote.SelectedIndex + comboBoxOctave.SelectedIndex * 12 + 36;
                Musicality.PickRandomIntervalToSing(middleNote);
                instructions.Text = Musicality.Instructions;
                textBoxNotes.Text = "";
                buttonAgain.Enabled = true;
                buttonAnswer.Enabled = true;
                buttonGo.Enabled = false;
                secondTimer.Start();
            }
        }

        private void buttonAgain_Click(object sender, EventArgs e)
        {
            if (!Musicality.IsPlaying)
            {
                Musicality.ReplayStartNotes();
                secondTimer.Start();
            }
        }

        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            if (!Musicality.IsPlaying)
            {
                textBoxNotes.Text = Musicality.GetIntervalSingNotesText();
                Musicality.PlayIntervalSingTarget();
                buttonGo.Enabled = true;
                secondTimer.Start();
            }
        }

        private void buttonHearRange_Click(object sender, EventArgs e)
        {
            if (!Musicality.IsPlaying)
            {
                int middleNote = comboBoxNote.SelectedIndex + comboBoxOctave.SelectedIndex * 12 + 36;
                Musicality.PlayNotes(middleNote - 6, middleNote - 2, middleNote + 1, middleNote + 6);
                secondTimer.Start();
            }
        }

        private void secondTimer_Tick(object sender, EventArgs e)
        {
            Musicality.Tick();
            if (!Musicality.IsPlaying)
            {
                secondTimer.Stop();
            }
        }
    }
}
