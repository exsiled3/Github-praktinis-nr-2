namespace Mole_Shooter
{
    partial class MoleShooter
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
            this.timerGameLoop = new System.Windows.Forms.Timer(this.components);
            this.timerBox = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerGameLoop
            // 
            this.timerGameLoop.Tick += new System.EventHandler(this.timerGameLoop_Tick);
            // 
            // timerBox
            // 
            this.timerBox.AutoSize = true;
            this.timerBox.BackColor = System.Drawing.Color.Transparent;
            this.timerBox.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerBox.Location = new System.Drawing.Point(224, 9);
            this.timerBox.Name = "timerBox";
            this.timerBox.Size = new System.Drawing.Size(103, 33);
            this.timerBox.TabIndex = 0;
            this.timerBox.Text = "Timer";
            this.timerBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MoleShooter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Mole_Shooter.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(584, 400);
            this.Controls.Add(this.timerBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MoleShooter";
            this.Text = "MoleShooter";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MoleShooter_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoleShooter_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerGameLoop;
        private System.Windows.Forms.Label timerBox;
        private System.Windows.Forms.Timer timer1;
    }
}

