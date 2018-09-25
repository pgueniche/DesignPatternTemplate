namespace MVP
{
    partial class FrmMvp
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
            this.cmdSet = new System.Windows.Forms.Button();
            this.CmdReverse = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdSet
            // 
            this.cmdSet.Location = new System.Drawing.Point(22, 49);
            this.cmdSet.Name = "cmdSet";
            this.cmdSet.Size = new System.Drawing.Size(75, 23);
            this.cmdSet.TabIndex = 0;
            this.cmdSet.Text = "Set";
            this.cmdSet.UseVisualStyleBackColor = true;
            this.cmdSet.Click += new System.EventHandler(this.cmdSet_Click);
            // 
            // CmdReverse
            // 
            this.CmdReverse.Location = new System.Drawing.Point(22, 100);
            this.CmdReverse.Name = "CmdReverse";
            this.CmdReverse.Size = new System.Drawing.Size(75, 23);
            this.CmdReverse.TabIndex = 1;
            this.CmdReverse.Text = "Reverse";
            this.CmdReverse.UseVisualStyleBackColor = true;
            this.CmdReverse.Click += new System.EventHandler(this.CmdReverse_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 161);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(227, 20);
            this.textBox1.TabIndex = 2;
            // 
            // FrmMvp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.CmdReverse);
            this.Controls.Add(this.cmdSet);
            this.Name = "FrmMvp";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSet;
        private System.Windows.Forms.Button CmdReverse;
        private System.Windows.Forms.TextBox textBox1;
    }
}

