using System;
using System.Windows.Forms;

namespace Musicality
{
    public partial class IntervalSingForm : Form
    {
        public IntervalSingForm()
        {
            Musicality.Initialise();
            InitializeComponent();
            comboBoxNote.SelectedItem = "C";
            comboBoxOctave.SelectedItem = "3";
            comboBoxVariant.SelectedIndex = 0;
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            if (!Musicality.IsPlaying)
            {
                int lowNote = comboBoxNote.SelectedIndex + comboBoxOctave.SelectedIndex * 12 + 36;
                switch (comboBoxVariant.SelectedIndex)
                {
                    case 0:
                        Musicality.PickRandomIntervalToSing(lowNote + 6);
                        break;
                    case 1:
                        Musicality.PickRandomChordIntervalToSing(lowNote + 6);
                        break;
                    case 2:
                        Musicality.PickRandomNoteToSingfromA(lowNote + 6);
                        break;
                }
                instructions.Text = Musicality.Instructions;
                textBoxNotes.Text = "";
                buttonAgain.Enabled = true;
                buttonAnswer.Enabled = true;
                buttonGo.Enabled = false;
                notePlayTimer.Start();
            }
        }

        private void buttonAgain_Click(object sender, EventArgs e)
        {
            if (!Musicality.IsPlaying)
            {
                Musicality.ReplayStartNotes();
                notePlayTimer.Start();
            }
        }

        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            if (!Musicality.IsPlaying)
            {
                textBoxNotes.Text = Musicality.GetIntervalSingNotesText();
                Musicality.PlayIntervalSingTarget();
                buttonGo.Enabled = true;
                notePlayTimer.Start();
            }
        }

        private void buttonHearRange_Click(object sender, EventArgs e)
        {
            if (!Musicality.IsPlaying)
            {
                int lowNote = comboBoxNote.SelectedIndex + comboBoxOctave.SelectedIndex * 12 + 36;
                Musicality.PlayNotes(lowNote, lowNote + 4, lowNote + 7, lowNote + 12);
                notePlayTimer.Start();
            }
        }

        private void secondTimer_Tick(object sender, EventArgs e)
        {
            Musicality.Tick();
            if (!Musicality.IsPlaying)
            {
                notePlayTimer.Stop();
            }
        }
    }
}
