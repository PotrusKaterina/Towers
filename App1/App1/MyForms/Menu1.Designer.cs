namespace App1.MyForms
{
    partial class Menu1
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
            this.Exit1 = new System.Windows.Forms.Button();
            this.Restart = new System.Windows.Forms.Button();
            this.Continue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Exit1
            // 
            this.Exit1.BackColor = System.Drawing.Color.Moccasin;
            this.Exit1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Exit1.Font = new System.Drawing.Font("Ravie", 18F, System.Drawing.FontStyle.Bold);
            this.Exit1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Exit1.Location = new System.Drawing.Point(1640, 835);
            this.Exit1.Name = "Exit1";
            this.Exit1.Size = new System.Drawing.Size(655, 173);
            this.Exit1.TabIndex = 14;
            this.Exit1.Text = "Exit";
            this.Exit1.UseVisualStyleBackColor = false;
            this.Exit1.Click += new System.EventHandler(this.Exit1_Click);
            // 
            // Restart
            // 
            this.Restart.BackColor = System.Drawing.Color.Moccasin;
            this.Restart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Restart.Font = new System.Drawing.Font("Ravie", 18F, System.Drawing.FontStyle.Bold);
            this.Restart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Restart.Location = new System.Drawing.Point(1640, 548);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(655, 173);
            this.Restart.TabIndex = 13;
            this.Restart.Text = "Restart";
            this.Restart.UseVisualStyleBackColor = false;
            this.Restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // Continue
            // 
            this.Continue.AutoSize = true;
            this.Continue.BackColor = System.Drawing.Color.Moccasin;
            this.Continue.CausesValidation = false;
            this.Continue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Continue.Font = new System.Drawing.Font("Ravie", 18F, System.Drawing.FontStyle.Bold);
            this.Continue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Continue.Location = new System.Drawing.Point(1640, 245);
            this.Continue.Name = "Continue";
            this.Continue.Size = new System.Drawing.Size(655, 173);
            this.Continue.TabIndex = 12;
            this.Continue.Text = "Continue";
            this.Continue.UseVisualStyleBackColor = false;
            this.Continue.Click += new System.EventHandler(this.Continue_Click);
            // 
            // Menu1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(2513, 1357);
            this.Controls.Add(this.Exit1);
            this.Controls.Add(this.Restart);
            this.Controls.Add(this.Continue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu1";
            this.Text = "Menu1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Exit1;
        private System.Windows.Forms.Button Restart;
        private System.Windows.Forms.Button Continue;
    }
}