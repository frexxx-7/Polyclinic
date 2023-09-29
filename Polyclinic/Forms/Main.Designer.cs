namespace Polyclinic.Forms
{
    partial class Main
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
            this.DoctorsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TreatmentsButton = new System.Windows.Forms.Button();
            this.PatientsButton = new System.Windows.Forms.Button();
            this.FinanceButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DoctorsButton
            // 
            this.DoctorsButton.Location = new System.Drawing.Point(170, 102);
            this.DoctorsButton.Name = "DoctorsButton";
            this.DoctorsButton.Size = new System.Drawing.Size(147, 36);
            this.DoctorsButton.TabIndex = 0;
            this.DoctorsButton.Text = "Врачи";
            this.DoctorsButton.UseVisualStyleBackColor = true;
            this.DoctorsButton.Click += new System.EventHandler(this.DoctorsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(181, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Главная";
            // 
            // TreatmentsButton
            // 
            this.TreatmentsButton.Location = new System.Drawing.Point(170, 168);
            this.TreatmentsButton.Name = "TreatmentsButton";
            this.TreatmentsButton.Size = new System.Drawing.Size(147, 36);
            this.TreatmentsButton.TabIndex = 2;
            this.TreatmentsButton.Text = "Обращения";
            this.TreatmentsButton.UseVisualStyleBackColor = true;
            this.TreatmentsButton.Click += new System.EventHandler(this.TreatmentsButton_Click);
            // 
            // PatientsButton
            // 
            this.PatientsButton.Location = new System.Drawing.Point(170, 235);
            this.PatientsButton.Name = "PatientsButton";
            this.PatientsButton.Size = new System.Drawing.Size(147, 36);
            this.PatientsButton.TabIndex = 3;
            this.PatientsButton.Text = "Пациенты";
            this.PatientsButton.UseVisualStyleBackColor = true;
            this.PatientsButton.Click += new System.EventHandler(this.PatientsButton_Click);
            // 
            // FinanceButton
            // 
            this.FinanceButton.Location = new System.Drawing.Point(170, 303);
            this.FinanceButton.Name = "FinanceButton";
            this.FinanceButton.Size = new System.Drawing.Size(147, 36);
            this.FinanceButton.TabIndex = 4;
            this.FinanceButton.Text = "Финансы";
            this.FinanceButton.UseVisualStyleBackColor = true;
            this.FinanceButton.Click += new System.EventHandler(this.FinanceButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(170, 478);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(147, 36);
            this.ExitButton.TabIndex = 5;
            this.ExitButton.Text = "Выход";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 526);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.FinanceButton);
            this.Controls.Add(this.PatientsButton);
            this.Controls.Add(this.TreatmentsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DoctorsButton);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DoctorsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TreatmentsButton;
        private System.Windows.Forms.Button PatientsButton;
        private System.Windows.Forms.Button FinanceButton;
        private System.Windows.Forms.Button ExitButton;
    }
}