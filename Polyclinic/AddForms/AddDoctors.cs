using MySql.Data.MySqlClient;
using Polyclinic.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polyclinic.AddForms
{
    public partial class AddDoctors : Form
    {
        private string idDoctor = null;
        public AddDoctors(string idDoctor)
        {
            InitializeComponent();
            this.idDoctor = idDoctor;
            if (idDoctor != null)
            {
                label1.Text = "Изменить доктора";
                AddButton.Text = "Изменить";
                loadInfoForDoctor();
            }
        }

        private void loadInfoForDoctor()
        {
            DB db = new DB();
            string queryInfo = $"SELECT * FROM doctors WHERE id = '{idDoctor}'";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                NameTextBox.Text = reader[1].ToString();
                SurnameTextBox.Text = reader[2].ToString();
                PatronymicTextBox.Text = reader[3].ToString();
                SpecialityTextBox.Text = reader[4].ToString();
                QualificationTextBox.Text = reader[5].ToString();
            }
            reader.Close();

            db.closeConnection();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            if (idDoctor == null)
            {
                MySqlCommand command = new MySqlCommand($"INSERT into doctors (name, surname, patronymic, speciality, qualification) values(@name, @surname, @patronymic, @speciality, @qualification)", db.getConnection());
                command.Parameters.AddWithValue("@name", NameTextBox.Text);
                command.Parameters.AddWithValue("@surname", SurnameTextBox.Text);
                command.Parameters.AddWithValue("@patronymic", PatronymicTextBox.Text);
                command.Parameters.AddWithValue("@speciality", SpecialityTextBox.Text);
                command.Parameters.AddWithValue("@qualification", QualificationTextBox.Text);
                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Врач добавлен");
                    this.Close();

                }
                catch
                {
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                db.closeConnection();
            }
            else
            {
                MySqlCommand command = new MySqlCommand($"update doctors set name = @name, surname = @surname, patronymic = @patronymic, speciality = @speciality, qualification = @qualification where id = {idDoctor}", db.getConnection());
                command.Parameters.AddWithValue("@name", NameTextBox.Text);
                command.Parameters.AddWithValue("@surname", SurnameTextBox.Text);
                command.Parameters.AddWithValue("@patronymic", PatronymicTextBox.Text);
                command.Parameters.AddWithValue("@speciality", SpecialityTextBox.Text);
                command.Parameters.AddWithValue("@qualification", QualificationTextBox.Text);

                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Врач изменен");
                    this.Close();

                }
                catch
                {
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                db.closeConnection();
            }
        }
    }
}
