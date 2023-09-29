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
    public partial class AddTreatments : Form
    {
        private string idTreatment = null;
        public AddTreatments(string idPatients)
        {
            InitializeComponent();
            this.idTreatment = idPatients;
            loadInfoDoctors();
            loadInfoPatients();

            if (idPatients != null)
            {
                label1.Text = "Изменить пациента";
                AddButton.Text = "Изменить";
                loadInfoForTreatment();
            }
        }

        private void loadInfoForTreatment()
        {
            DB db = new DB();
            string queryInfo = $"SELECT * FROM treatments WHERE id = '{idTreatment}'";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                PriceTextBox.Text = reader["price"].ToString();
                DiagnosisTextBox.Text = reader["diagnosis"].ToString();
                DateTreatmentsDateTimePicker.Value = DateTime.Parse(reader["dateTreatment"].ToString());

                for (int i = 0; i < DoctorsComboBox.Items.Count; i++)
                {
                    if (reader["idDoctors"].ToString() != "")
                    {
                        if (Convert.ToInt32((DoctorsComboBox.Items[i] as ComboboxItem).Value) == Convert.ToInt32(reader["idDoctors"]))
                        {
                            DoctorsComboBox.SelectedIndex = i;
                        }
                    }
                }
                for (int i = 0; i < PatientsComboBox.Items.Count; i++)
                {
                    if (reader["idPatients"].ToString() != "")
                    {
                        if (Convert.ToInt32((PatientsComboBox.Items[i] as ComboboxItem).Value) == Convert.ToInt32(reader["idPatients"]))
                        {
                            PatientsComboBox.SelectedIndex = i;
                        }
                    }
                }
            }
            reader.Close();

            db.closeConnection();
        }

        private void loadInfoDoctors()
        {
            DB db = new DB();
            string queryInfo = $"SELECT id, name, surname, patronymic FROM doctors";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = $" {reader[1]} {reader[3]} {reader[2]}";
                item.Value = reader[0];
                DoctorsComboBox.Items.Add(item);
            }
            reader.Close();

            db.closeConnection();
        }

        private void loadInfoPatients()
        {
            DB db = new DB();
            string queryInfo = $"SELECT id, name, surname, patronymic FROM patients";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = $" {reader[1]} {reader[3]} {reader[2]}";
                item.Value = reader[0];
                PatientsComboBox.Items.Add(item);
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
            if (idTreatment == null)
            {
                MySqlCommand command = new MySqlCommand($"INSERT into treatments (idPatients, idDoctors, dateTreatment, diagnosis, price) values(@idPatients, @idDoctors, @dateTreatment, @diagnosis, @price)", db.getConnection());
                command.Parameters.AddWithValue("@idPatients", (PatientsComboBox.SelectedItem as ComboboxItem).Value);
                command.Parameters.AddWithValue("@idDoctors", (DoctorsComboBox.SelectedItem as ComboboxItem).Value);
                command.Parameters.AddWithValue("@dateTreatment", DateTreatmentsDateTimePicker.Value.ToString("dd.MM.yyyy"));
                command.Parameters.AddWithValue("@diagnosis", DiagnosisTextBox.Text);
                command.Parameters.AddWithValue("@price", PriceTextBox.Text);
                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Обращение добавлено");
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
                MySqlCommand command = new MySqlCommand($"update treatments set idPatients = @idPatients, idDoctors = @idDoctors, dateTreatment= @dateTreatment, diagnosis = @diagnosis, price = @price where id = {idTreatment}", db.getConnection());
                command.Parameters.AddWithValue("@idPatients", (PatientsComboBox.SelectedItem as ComboboxItem).Value);
                command.Parameters.AddWithValue("@idDoctors", (DoctorsComboBox.SelectedItem as ComboboxItem).Value);
                command.Parameters.AddWithValue("@dateTreatment", DateTreatmentsDateTimePicker.Value.ToString("dd.MM.yyyy"));
                command.Parameters.AddWithValue("@diagnosis", DiagnosisTextBox.Text);
                command.Parameters.AddWithValue("@price", PriceTextBox.Text);

                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Обращение изменено");
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
