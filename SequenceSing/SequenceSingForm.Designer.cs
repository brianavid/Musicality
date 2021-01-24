
namespace Musicality
{
    partial class SequenceSingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.instructions = new System.Windows.Forms.TextBox();
            this.buttonAgain = new System.Windows.Forms.Button();
            this.buttonAnswer = new System.Windows.Forms.Button();
            this.buttonGo = new System.Windows.Forms.Button();
            this.notePlayTimer = new System.Windows.Forms.Timer(this.components);
            this.checkBoxFullOctave = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNotes.Location = new System.Drawing.Point(116, 70);
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.ReadOnly = true;
            this.textBoxNotes.Size = new System.Drawing.Size(47, 13);
            this.textBoxNotes.TabIndex = 20;
            this.textBoxNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // instructions
            // 
            this.instructions.Location = new System.Drawing.Point(12, 41);
            this.instructions.Name = "instructions";
            this.instructions.ReadOnly = true;
            this.instructions.Size = new System.Drawing.Size(256, 20);
            this.instructions.TabIndex = 19;
            // 
            // buttonAgain
            // 
            this.buttonAgain.Enabled = false;
            this.buttonAgain.Location = new System.Drawing.Point(11, 67);
            this.buttonAgain.Name = "buttonAgain";
            this.buttonAgain.Size = new System.Drawing.Size(75, 23);
            this.buttonAgain.TabIndex = 18;
            this.buttonAgain.Text = "Again";
            this.buttonAgain.UseVisualStyleBackColor = true;
            this.buttonAgain.Click += new System.EventHandler(this.buttonAgain_Click);
            // 
            // buttonAnswer
            // 
            this.buttonAnswer.Enabled = false;
            this.buttonAnswer.Location = new System.Drawing.Point(193, 65);
            this.buttonAnswer.Name = "buttonAnswer";
            this.buttonAnswer.Size = new System.Drawing.Size(75, 23);
            this.buttonAnswer.TabIndex = 17;
            this.buttonAnswer.Text = "Answer";
            this.buttonAnswer.UseVisualStyleBackColor = true;
            this.buttonAnswer.Click += new System.EventHandler(this.buttonAnswer_Click);
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(12, 12);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(75, 23);
            this.buttonGo.TabIndex = 16;
            this.buttonGo.Text = "New";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // secondTimer
            // 
            this.notePlayTimer.Interval = 1000;
            this.notePlayTimer.Tick += new System.EventHandler(this.secondTimer_Tick);
            // 
            // checkBoxFullOctave
            // 
            this.checkBoxFullOctave.AutoSize = true;
            this.checkBoxFullOctave.Location = new System.Drawing.Point(188, 12);
            this.checkBoxFullOctave.Name = "checkBoxFullOctave";
            this.checkBoxFullOctave.Size = new System.Drawing.Size(80, 17);
            this.checkBoxFullOctave.TabIndex = 21;
            this.checkBoxFullOctave.Text = "Full Octave";
            this.checkBoxFullOctave.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 120);
            this.Controls.Add(this.checkBoxFullOctave);
            this.Controls.Add(this.textBoxNotes);
            this.Controls.Add(this.instructions);
            this.Controls.Add(this.buttonAgain);
            this.Controls.Add(this.buttonAnswer);
            this.Controls.Add(this.buttonGo);
            this.Name = "Form1";
            this.Text = "Sequence Sing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.TextBox instructions;
        private System.Windows.Forms.Button buttonAgain;
        private System.Windows.Forms.Button buttonAnswer;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.Timer notePlayTimer;
        private System.Windows.Forms.CheckBox checkBoxFullOctave;
    }
}

