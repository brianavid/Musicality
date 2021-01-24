using System;
using System.Windows.Forms;

namespace Musicality
{
    public partial class SequenceSingForm : Form
    {
        public SequenceSingForm()
        {
            Musicality.Initialise();
            InitializeComponent();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            if (!Musicality.IsPlaying)
            {
                Musicality.BuildSequenceToSing(checkBoxFullOctave.Checked);
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
                Musicality.PlaySequenceSingTarget();
                buttonGo.Enabled = true;
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
