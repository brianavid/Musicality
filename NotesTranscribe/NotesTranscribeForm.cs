using System;
using System.Windows.Forms;

namespace Musicality
{
    public partial class NotesTranscribeForm : Form
    {
        public NotesTranscribeForm()
        {
            InitializeComponent();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            if (!Musicality.IsPlaying)
            {
                notePlayTimer.Interval = radioButtonFast.Checked ? 1000 : radioButtonMedium.Checked ? 1500 : 2000;
                Musicality.PlaySequence();
                instructions.Text = "Write down this sequence (after an initial C)";
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
                notePlayTimer.Interval = radioButtonFast.Checked ? 1000 : radioButtonMedium.Checked ? 1500 : 2000;
                Musicality.ReplayStartNotes();
                notePlayTimer.Start();
            }
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
