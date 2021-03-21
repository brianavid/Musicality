
namespace Musicality
{
    partial class IntervalSingForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonHearRange = new System.Windows.Forms.Button();
            this.comboBoxOctave = new System.Windows.Forms.ComboBox();
            this.comboBoxNote = new System.Windows.Forms.ComboBox();
            this.instructions = new System.Windows.Forms.TextBox();
            this.buttonAgain = new System.Windows.Forms.Button();
            this.buttonAnswer = new System.Windows.Forms.Button();
            this.buttonGo = new System.Windows.Forms.Button();
            this.notePlayTimer = new System.Windows.Forms.Timer(this.components);
            this.comboBoxVariant = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNotes.Location = new System.Drawing.Point(95, 76);
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.ReadOnly = true;
            this.textBoxNotes.Size = new System.Drawing.Size(159, 17);
            this.textBoxNotes.TabIndex = 15;
            this.textBoxNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonHearRange);
            this.groupBox1.Controls.Add(this.comboBoxOctave);
            this.groupBox1.Controls.Add(this.comboBoxNote);
            this.groupBox1.Location = new System.Drawing.Point(14, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 62);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Octave range starting from";
            // 
            // buttonHearRange
            // 
            this.buttonHearRange.Location = new System.Drawing.Point(241, 26);
            this.buttonHearRange.Name = "buttonHearRange";
            this.buttonHearRange.Size = new System.Drawing.Size(75, 23);
            this.buttonHearRange.TabIndex = 10;
            this.buttonHearRange.Text = "Hear";
            this.buttonHearRange.UseVisualStyleBackColor = true;
            this.buttonHearRange.Click += new System.EventHandler(this.buttonHearRange_Click);
            // 
            // comboBoxOctave
            // 
            this.comboBoxOctave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOctave.FormattingEnabled = true;
            this.comboBoxOctave.Items.AddRange(new object[] {
            "2",
            "3",
            "4"});
            this.comboBoxOctave.Location = new System.Drawing.Point(95, 28);
            this.comboBoxOctave.Name = "comboBoxOctave";
            this.comboBoxOctave.Size = new System.Drawing.Size(35, 21);
            this.comboBoxOctave.TabIndex = 9;
            // 
            // comboBoxNote
            // 
            this.comboBoxNote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNote.FormattingEnabled = true;
            this.comboBoxNote.Items.AddRange(new object[] {
            "C",
            "C#",
            "D",
            "D#",
            "E",
            "F",
            "F#",
            "G",
            "G#",
            "A",
            "A#",
            "B"});
            this.comboBoxNote.Location = new System.Drawing.Point(44, 28);
            this.comboBoxNote.Name = "comboBoxNote";
            this.comboBoxNote.Size = new System.Drawing.Size(45, 21);
            this.comboBoxNote.TabIndex = 8;
            // 
            // instructions
            // 
            this.instructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructions.Location = new System.Drawing.Point(12, 43);
            this.instructions.Name = "instructions";
            this.instructions.ReadOnly = true;
            this.instructions.Size = new System.Drawing.Size(324, 22);
            this.instructions.TabIndex = 13;
            // 
            // buttonAgain
            // 
            this.buttonAgain.Enabled = false;
            this.buttonAgain.Location = new System.Drawing.Point(14, 71);
            this.buttonAgain.Name = "buttonAgain";
            this.buttonAgain.Size = new System.Drawing.Size(75, 23);
            this.buttonAgain.TabIndex = 12;
            this.buttonAgain.Text = "Again";
            this.buttonAgain.UseVisualStyleBackColor = true;
            this.buttonAgain.Click += new System.EventHandler(this.buttonAgain_Click);
            // 
            // buttonAnswer
            // 
            this.buttonAnswer.Enabled = false;
            this.buttonAnswer.Location = new System.Drawing.Point(260, 71);
            this.buttonAnswer.Name = "buttonAnswer";
            this.buttonAnswer.Size = new System.Drawing.Size(75, 23);
            this.buttonAnswer.TabIndex = 11;
            this.buttonAnswer.Text = "Answer";
            this.buttonAnswer.UseVisualStyleBackColor = true;
            this.buttonAnswer.Click += new System.EventHandler(this.buttonAnswer_Click);
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(12, 12);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(75, 23);
            this.buttonGo.TabIndex = 10;
            this.buttonGo.Text = "New";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // notePlayTimer
            // 
            this.notePlayTimer.Interval = 1000;
            this.notePlayTimer.Tick += new System.EventHandler(this.secondTimer_Tick);
            // 
            // comboBoxVariant
            // 
            this.comboBoxVariant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVariant.FormattingEnabled = true;
            this.comboBoxVariant.Items.AddRange(new object[] {
            "Close interval from note",
            "Any interval from note",
            "Top note of chord",
            "Bottom note of chord",
            "Fourth or fifth above top of chord",
            "Major or minor third above top of chord",
            "Major or minor sixth above top of chord",
            "Fourth or fifth below bottom of chord",
            "Major or minor third below bottom of chord",
            "Major or minor sixth below bottom of chord",
            "Any interval above or below chord",
            "Any note from A"});
            this.comboBoxVariant.Location = new System.Drawing.Point(109, 13);
            this.comboBoxVariant.Name = "comboBoxVariant";
            this.comboBoxVariant.Size = new System.Drawing.Size(221, 21);
            this.comboBoxVariant.TabIndex = 16;
            // 
            // IntervalSingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 180);
            this.Controls.Add(this.comboBoxVariant);
            this.Controls.Add(this.textBoxNotes);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.instructions);
            this.Controls.Add(this.buttonAgain);
            this.Controls.Add(this.buttonAnswer);
            this.Controls.Add(this.buttonGo);
            this.Name = "IntervalSingForm";
            this.Text = "Interval Sing";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonHearRange;
        private System.Windows.Forms.ComboBox comboBoxOctave;
        private System.Windows.Forms.ComboBox comboBoxNote;
        private System.Windows.Forms.TextBox instructions;
        private System.Windows.Forms.Button buttonAgain;
        private System.Windows.Forms.Button buttonAnswer;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.Timer notePlayTimer;
        private System.Windows.Forms.ComboBox comboBoxVariant;
    }
}

