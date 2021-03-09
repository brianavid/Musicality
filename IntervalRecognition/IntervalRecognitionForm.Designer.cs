
namespace Musicality
{
    partial class IntervalRecognitionForm
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
            this.buttonAgain = new System.Windows.Forms.Button();
            this.buttonAnswer = new System.Windows.Forms.Button();
            this.buttonGo = new System.Windows.Forms.Button();
            this.notePlayTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNotes.Location = new System.Drawing.Point(95, 77);
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.ReadOnly = true;
            this.textBoxNotes.Size = new System.Drawing.Size(159, 17);
            this.textBoxNotes.TabIndex = 22;
            this.textBoxNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonAgain
            // 
            this.buttonAgain.Enabled = false;
            this.buttonAgain.Location = new System.Drawing.Point(14, 71);
            this.buttonAgain.Name = "buttonAgain";
            this.buttonAgain.Size = new System.Drawing.Size(75, 23);
            this.buttonAgain.TabIndex = 19;
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
            this.buttonAnswer.TabIndex = 18;
            this.buttonAnswer.Text = "Answer";
            this.buttonAnswer.UseVisualStyleBackColor = true;
            this.buttonAnswer.Click += new System.EventHandler(this.buttonAnswer_Click);
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(12, 12);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(75, 23);
            this.buttonGo.TabIndex = 17;
            this.buttonGo.Text = "New";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // notePlayTimer
            // 
            this.notePlayTimer.Interval = 1000;
            this.notePlayTimer.Tick += new System.EventHandler(this.notePlayTimer_Tick);
            // 
            // IntervalRecognitionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 108);
            this.Controls.Add(this.textBoxNotes);
            this.Controls.Add(this.buttonAgain);
            this.Controls.Add(this.buttonAnswer);
            this.Controls.Add(this.buttonGo);
            this.Name = "IntervalRecognitionForm";
            this.Text = "Interval Recognition";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.Button buttonAgain;
        private System.Windows.Forms.Button buttonAnswer;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.Timer notePlayTimer;
    }
}

