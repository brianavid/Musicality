
namespace Musicality
{
    partial class NotesTranscribeForm
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
            this.buttonGo = new System.Windows.Forms.Button();
            this.buttonAnswer = new System.Windows.Forms.Button();
            this.buttonAgain = new System.Windows.Forms.Button();
            this.instructions = new System.Windows.Forms.TextBox();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.textBoxAnswer = new System.Windows.Forms.TextBox();
            this.notePlayTimer = new System.Windows.Forms.Timer(this.components);
            this.numericUpDownLength = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxNote = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Speed = new System.Windows.Forms.Label();
            this.comboBoxSpeed = new System.Windows.Forms.ComboBox();
            this.comboBoxMode = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(12, 12);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(75, 23);
            this.buttonGo.TabIndex = 22;
            this.buttonGo.Text = "New";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // buttonAnswer
            // 
            this.buttonAnswer.Enabled = false;
            this.buttonAnswer.Location = new System.Drawing.Point(244, 106);
            this.buttonAnswer.Name = "buttonAnswer";
            this.buttonAnswer.Size = new System.Drawing.Size(75, 23);
            this.buttonAnswer.TabIndex = 23;
            this.buttonAnswer.Text = "Answer";
            this.buttonAnswer.UseVisualStyleBackColor = true;
            this.buttonAnswer.Click += new System.EventHandler(this.buttonAnswer_Click);
            // 
            // buttonAgain
            // 
            this.buttonAgain.Enabled = false;
            this.buttonAgain.Location = new System.Drawing.Point(11, 103);
            this.buttonAgain.Name = "buttonAgain";
            this.buttonAgain.Size = new System.Drawing.Size(75, 23);
            this.buttonAgain.TabIndex = 24;
            this.buttonAgain.Text = "Again";
            this.buttonAgain.UseVisualStyleBackColor = true;
            this.buttonAgain.Click += new System.EventHandler(this.buttonAgain_Click);
            // 
            // instructions
            // 
            this.instructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructions.Location = new System.Drawing.Point(12, 71);
            this.instructions.Name = "instructions";
            this.instructions.ReadOnly = true;
            this.instructions.Size = new System.Drawing.Size(307, 22);
            this.instructions.TabIndex = 25;
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNotes.Location = new System.Drawing.Point(116, 106);
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.ReadOnly = true;
            this.textBoxNotes.Size = new System.Drawing.Size(47, 13);
            this.textBoxNotes.TabIndex = 26;
            this.textBoxNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxAnswer
            // 
            this.textBoxAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAnswer.Location = new System.Drawing.Point(11, 139);
            this.textBoxAnswer.Name = "textBoxAnswer";
            this.textBoxAnswer.ReadOnly = true;
            this.textBoxAnswer.Size = new System.Drawing.Size(308, 22);
            this.textBoxAnswer.TabIndex = 29;
            // 
            // notePlayTimer
            // 
            this.notePlayTimer.Interval = 1000;
            this.notePlayTimer.Tick += new System.EventHandler(this.notePlayTimer_Tick);
            // 
            // numericUpDownLength
            // 
            this.numericUpDownLength.Location = new System.Drawing.Point(142, 13);
            this.numericUpDownLength.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownLength.Name = "numericUpDownLength";
            this.numericUpDownLength.Size = new System.Drawing.Size(36, 20);
            this.numericUpDownLength.TabIndex = 31;
            this.numericUpDownLength.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Length";
            // 
            // comboBoxNote
            // 
            this.comboBoxNote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNote.FormattingEnabled = true;
            this.comboBoxNote.Items.AddRange(new object[] {
            "C",
            "D♭",
            "D",
            "E♭",
            "E",
            "F",
            "F#",
            "G",
            "A♭",
            "A",
            "B♭",
            "B"});
            this.comboBoxNote.Location = new System.Drawing.Point(142, 39);
            this.comboBoxNote.Name = "comboBoxNote";
            this.comboBoxNote.Size = new System.Drawing.Size(45, 21);
            this.comboBoxNote.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Key";
            // 
            // Speed
            // 
            this.Speed.AutoSize = true;
            this.Speed.Location = new System.Drawing.Point(208, 17);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(38, 13);
            this.Speed.TabIndex = 35;
            this.Speed.Text = "Speed";
            // 
            // comboBoxSpeed
            // 
            this.comboBoxSpeed.FormattingEnabled = true;
            this.comboBoxSpeed.Items.AddRange(new object[] {
            "Fast",
            "Medium",
            "Slow"});
            this.comboBoxSpeed.Location = new System.Drawing.Point(250, 12);
            this.comboBoxSpeed.Name = "comboBoxSpeed";
            this.comboBoxSpeed.Size = new System.Drawing.Size(69, 21);
            this.comboBoxSpeed.TabIndex = 36;
            // 
            // comboBoxMode
            // 
            this.comboBoxMode.Enabled = false;
            this.comboBoxMode.FormattingEnabled = true;
            this.comboBoxMode.Items.AddRange(new object[] {
            "Major",
            "Natural Minor",
            "Melodic Minor",
            "Harmonic Minor"});
            this.comboBoxMode.Location = new System.Drawing.Point(193, 40);
            this.comboBoxMode.Name = "comboBoxMode";
            this.comboBoxMode.Size = new System.Drawing.Size(127, 21);
            this.comboBoxMode.TabIndex = 37;
            // 
            // NotesTranscribeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 172);
            this.Controls.Add(this.comboBoxMode);
            this.Controls.Add(this.comboBoxSpeed);
            this.Controls.Add(this.Speed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxNote);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownLength);
            this.Controls.Add(this.textBoxAnswer);
            this.Controls.Add(this.textBoxNotes);
            this.Controls.Add(this.instructions);
            this.Controls.Add(this.buttonAgain);
            this.Controls.Add(this.buttonAnswer);
            this.Controls.Add(this.buttonGo);
            this.Name = "NotesTranscribeForm";
            this.Text = "Notes Transcribe";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.Button buttonAnswer;
        private System.Windows.Forms.Button buttonAgain;
        private System.Windows.Forms.TextBox instructions;
        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.TextBox textBoxAnswer;
        private System.Windows.Forms.Timer notePlayTimer;
        private System.Windows.Forms.NumericUpDown numericUpDownLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxNote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Speed;
        private System.Windows.Forms.ComboBox comboBoxSpeed;
        private System.Windows.Forms.ComboBox comboBoxMode;
    }
}

