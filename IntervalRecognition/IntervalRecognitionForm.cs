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
    public partial class IntervalRecognitionForm : Form
    {
        public IntervalRecognitionForm()
        {
            Musicality.Initialise();
            InitializeComponent();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            if (!Musicality.IsPlaying)
            {
                Musicality.PickRandomIntervalToRecognise(60);
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
                buttonGo.Enabled = true;
                notePlayTimer.Start();
            }
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
