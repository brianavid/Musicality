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
                        Musicality.PickRandomIntervalToSing(lowNote + 6, true);
                        break;
                    case 1:
                        Musicality.PickRandomIntervalToSing(lowNote + 6, false);
                        break;
                    case 2:
                        Musicality.PickRandomChordIntervalToSing(lowNote + 6, Musicality.ChordIntervalChooser.TopNote);
                        break;
                    case 3:
                        Musicality.PickRandomChordIntervalToSing(lowNote + 6, Musicality.ChordIntervalChooser.BottomNote);
                        break;
                    case 4:
                        Musicality.PickRandomChordIntervalToSing(lowNote + 6, Musicality.ChordIntervalChooser.PerfectAbove);
                        break;
                    case 5:
                        Musicality.PickRandomChordIntervalToSing(lowNote + 6, Musicality.ChordIntervalChooser.ThirdsAbove);
                        break;
                    case 6:
                        Musicality.PickRandomChordIntervalToSing(lowNote + 6, Musicality.ChordIntervalChooser.SixthsAbove);
                        break;
                    case 7:
                        Musicality.PickRandomChordIntervalToSing(lowNote + 6, Musicality.ChordIntervalChooser.PerfectBelow);
                        break;
                    case 8:
                        Musicality.PickRandomChordIntervalToSing(lowNote + 6, Musicality.ChordIntervalChooser.ThirdsBelow);
                        break;
                    case 9:
                        Musicality.PickRandomChordIntervalToSing(lowNote + 6, Musicality.ChordIntervalChooser.SixthsBelow);
                        break;
                    case 10:
                        Musicality.PickRandomChordIntervalToSing(lowNote + 6, Musicality.ChordIntervalChooser.Mixed);
                        break;
                    case 11:
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
