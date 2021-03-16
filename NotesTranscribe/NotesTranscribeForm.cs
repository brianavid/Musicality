using System;
using System.Windows.Forms;

namespace Musicality
{
    public partial class NotesTranscribeForm : Form
    {
        public NotesTranscribeForm()
        {
            InitializeComponent();
            comboBoxMode.SelectedIndex = 0;
            comboBoxNote.SelectedIndex = 0;
            comboBoxSpeed.SelectedIndex = 1;
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            if (!Musicality.IsPlaying)
            {
                notePlayTimer.Interval = NoteTimeInterval();
                Musicality.PlaySequence(Convert.ToInt32(numericUpDownLength.Value), comboBoxNote.SelectedIndex, comboBoxMode.Text);
                instructions.Text = $"Write down this sequence (after an initial {comboBoxNote.SelectedItem})";
                textBoxAnswer.Text = "";
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
                notePlayTimer.Interval = NoteTimeInterval();
                Musicality.ReplayStartNotes();
                notePlayTimer.Start();
            }
        }

        private int NoteTimeInterval()
        {
            return comboBoxSpeed.Text == "Fast" ? 1000 : comboBoxSpeed.Text == "Medium" ? 1500 : 2000;
        }

        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            textBoxAnswer.Text = Musicality.SequenceText();
            buttonGo.Enabled = true;
        }

        private void notePlayTimer_Tick(object sender, EventArgs e)
        {
            Musicality.Tick();
            if (!Musicality.IsPlaying)
            {
                notePlayTimer.Stop();
            }
        }
    }
}
