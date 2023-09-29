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
    public partial class AddExpenses : Form
    {
        private string idExpenses = null;
        public AddExpenses(string idDoctor)
        {
            InitializeComponent();
            this.idExpenses = idDoctor;
            loadInfoDoctors();

            if (idDoctor != null)
            {
                label1.Text = "Изменить расход";
                AddButton.Text = "Изменить";
                loadInfoForExpenses();
            }
        }

        private void loadInfoForExpenses()
        {
            DB db = new DB();
            string queryInfo = $"SELECT * FROM expenses WHERE id = '{idExpenses}'";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                PriceTextBox.Text = reader[1].ToString();
                DescriptionTextBox.Text = reader[2].ToString();

                for (int i = 0; i < DoctorComboBox.Items.Count; i++)
                {
                    if (reader["idDoctor"].ToString() != "")
                    {
                        if (Convert.ToInt32((DoctorComboBox.Items[i] as ComboboxItem).Value) == Convert.ToInt32(reader["idDoctor"]))
                        {
                            DoctorComboBox.SelectedIndex = i;
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
                DoctorComboBox.Items.Add(item);
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
            if (idExpenses == null)
            {
                MySqlCommand command = new MySqlCommand($"INSERT into expenses (price, description, idDoctor) values(@price, @description, @idDoctor)", db.getConnection());
                command.Parameters.AddWithValue("@price", PriceTextBox.Text);
                command.Parameters.AddWithValue("@description", DescriptionTextBox.Text);
                command.Parameters.AddWithValue("@idDoctor", (DoctorComboBox.SelectedItem as ComboboxItem).Value);
                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Расход добавлен");
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
                MySqlCommand command = new MySqlCommand($"update expenses set price=@price, description=@description, idDoctor=@idDoctor where id = {idExpenses}", db.getConnection());
                command.Parameters.AddWithValue("@price", PriceTextBox.Text);
                command.Parameters.AddWithValue("@description", DescriptionTextBox.Text);
                command.Parameters.AddWithValue("@idDoctor", (DoctorComboBox.SelectedItem as ComboboxItem).Value);

                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Расход изменен");
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
