﻿namespace Polyclinic.Forms
{
    partial class Patients
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
            this.DoctorsDataGridView = new System.Windows.Forms.DataGridView();
            this.AddButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.idDocrors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patronymic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateBirthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DoctorsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DoctorsDataGridView
            // 
            this.DoctorsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DoctorsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DoctorsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDocrors,
            this.NameDoctor,
            this.Surname,
            this.Patronymic,
            this.DateBirthday});
            this.DoctorsDataGridView.Location = new System.Drawing.Point(12, 81);
            this.DoctorsDataGridView.Name = "DoctorsDataGridView";
            this.DoctorsDataGridView.RowHeadersWidth = 51;
            this.DoctorsDataGridView.RowTemplate.Height = 24;
            this.DoctorsDataGridView.Size = new System.Drawing.Size(990, 380);
            this.DoctorsDataGridView.TabIndex = 0;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(12, 490);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(114, 36);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(145, 490);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(114, 36);
            this.EditButton.TabIndex = 2;
            this.EditButton.Text = "Изменить";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(12, 12);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(114, 36);
            this.BackButton.TabIndex = 3;
            this.BackButton.Text = "Назад";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(279, 490);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(114, 36);
            this.DeleteButton.TabIndex = 4;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(888, 490);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(114, 36);
            this.SearchButton.TabIndex = 5;
            this.SearchButton.Text = "Поиск";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(625, 497);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(243, 22);
            this.SearchTextBox.TabIndex = 6;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(888, 12);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(114, 36);
            this.UpdateButton.TabIndex = 7;
            this.UpdateButton.Text = "Обновить";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // idDocrors
            // 
            this.idDocrors.HeaderText = "id";
            this.idDocrors.MinimumWidth = 6;
            this.idDocrors.Name = "idDocrors";
            this.idDocrors.Visible = false;
            this.idDocrors.Width = 125;
            // 
            // NameDoctor
            // 
            this.NameDoctor.HeaderText = "Имя";
            this.NameDoctor.MinimumWidth = 6;
            this.NameDoctor.Name = "NameDoctor";
            this.NameDoctor.Width = 125;
            // 
            // Surname
            // 
            this.Surname.HeaderText = "Фамилия";
            this.Surname.MinimumWidth = 6;
            this.Surname.Name = "Surname";
            this.Surname.Width = 125;
            // 
            // Patronymic
            // 
            this.Patronymic.HeaderText = "Отчество";
            this.Patronymic.MinimumWidth = 6;
            this.Patronymic.Name = "Patronymic";
            this.Patronymic.Width = 125;
            // 
            // DateBirthday
            // 
            this.DateBirthday.HeaderText = "Дата рождения";
            this.DateBirthday.MinimumWidth = 6;
            this.DateBirthday.Name = "DateBirthday";
            this.DateBirthday.Width = 125;
            // 
            // Patients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 552);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.DoctorsDataGridView);
            this.Name = "Patients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пациенты";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Doctors_FormClosed);
            this.Load += new System.EventHandler(this.Doctors_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DoctorsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DoctorsDataGridView;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocrors;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patronymic;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateBirthday;
    }
}