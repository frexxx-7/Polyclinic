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
    public partial class AddPatients : Form
    {
        private string idPatients = null;
        public AddPatients(string idPatients)
        {
            InitializeComponent();
            this.idPatients = idPatients;
            if (idPatients != null)
            {
                label1.Text = "Изменить пациента";
                AddButton.Text = "Изменить";
                loadInfoForPatients();
            }
        }

        private void loadInfoForPatients()
        {
            DB db = new DB();
            string queryInfo = $"SELECT * FROM patients WHERE id = '{idPatients}'";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                NameTextBox.Text = reader[1].ToString();
                SurnameTextBox.Text = reader[2].ToString();
                PatronymicTextBox.Text = reader[3].ToString();
                DateBirthdayDateTimePicker.Value = DateTime.Parse(reader[4].ToString());
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
            if (idPatients == null)
            {
                MySqlCommand command = new MySqlCommand($"INSERT into patients (name, surname, patronymic, dateBirthday) values(@name, @surname, @patronymic, @dateBirthday)", db.getConnection());
                command.Parameters.AddWithValue("@name", NameTextBox.Text);
                command.Parameters.AddWithValue("@surname", SurnameTextBox.Text);
                command.Parameters.AddWithValue("@patronymic", PatronymicTextBox.Text);
                command.Parameters.AddWithValue("@dateBirthday", DateBirthdayDateTimePicker.Value.ToString("dd.MM.yyyy"));
                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Пациент добавлен");
                    this.Close();

                }
                catch(Exception epx)
                {
                    MessageBox.Show("Ошибка" + epx.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                db.closeConnection();
            }
            else
            {
                MySqlCommand command = new MySqlCommand($"update patients set name = @name, surname = @surname, patronymic = @patronymic, dateBirthday = @dateBirthday where id = {idPatients}", db.getConnection());
                command.Parameters.AddWithValue("@name", NameTextBox.Text);
                command.Parameters.AddWithValue("@surname", SurnameTextBox.Text);
                command.Parameters.AddWithValue("@patronymic", PatronymicTextBox.Text);
                command.Parameters.AddWithValue("@dateBirthday", DateBirthdayDateTimePicker.Value.ToString("dd.MM.yyyy"));

                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Пациент изменен");
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
