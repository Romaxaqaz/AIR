namespace HttpLab
{
    partial class CommonForm
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
            this.BtnGreyWarden = new System.Windows.Forms.Button();
            this.BtnAnton = new System.Windows.Forms.Button();
            this.BtnRomaxa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnGreyWarden
            // 
            this.BtnGreyWarden.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BtnGreyWarden.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnGreyWarden.Location = new System.Drawing.Point(12, 12);
            this.BtnGreyWarden.Name = "BtnGreyWarden";
            this.BtnGreyWarden.Size = new System.Drawing.Size(150, 50);
            this.BtnGreyWarden.TabIndex = 0;
            this.BtnGreyWarden.Text = "Grey Warden";
            this.BtnGreyWarden.UseVisualStyleBackColor = false;
            this.BtnGreyWarden.Click += new System.EventHandler(this.BtnGreyWarden_Click);
            // 
            // BtnAnton
            // 
            this.BtnAnton.BackColor = System.Drawing.SystemColors.Control;
            this.BtnAnton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnAnton.Location = new System.Drawing.Point(12, 80);
            this.BtnAnton.Name = "BtnAnton";
            this.BtnAnton.Size = new System.Drawing.Size(150, 50);
            this.BtnAnton.TabIndex = 1;
            this.BtnAnton.Text = "Anton";
            this.BtnAnton.UseVisualStyleBackColor = false;
            this.BtnAnton.Click += new System.EventHandler(this.BtnAnton_Click);
            // 
            // BtnRomaxa
            // 
            this.BtnRomaxa.BackColor = System.Drawing.SystemColors.Control;
            this.BtnRomaxa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnRomaxa.Location = new System.Drawing.Point(12, 149);
            this.BtnRomaxa.Name = "BtnRomaxa";
            this.BtnRomaxa.Size = new System.Drawing.Size(150, 50);
            this.BtnRomaxa.TabIndex = 2;
            this.BtnRomaxa.Text = "Romaxa";
            this.BtnRomaxa.UseVisualStyleBackColor = false;
            this.BtnRomaxa.Click += new System.EventHandler(this.BtnRomaxa_Click);
            // 
            // CommonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(174, 211);
            this.Controls.Add(this.BtnRomaxa);
            this.Controls.Add(this.BtnAnton);
            this.Controls.Add(this.BtnGreyWarden);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CommonForm";
            this.Text = "Common Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnGreyWarden;
        private System.Windows.Forms.Button BtnAnton;
        private System.Windows.Forms.Button BtnRomaxa;
    }
}

