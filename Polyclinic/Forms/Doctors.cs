using MySql.Data.MySqlClient;
using Polyclinic.AddForms;
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

namespace Polyclinic.Forms
{
    public partial class Doctors : Form
    {
        private string id;
        public Doctors(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void Doctors_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Main main = new Main(id);
            main.Show();
            this.Hide();
        }

        private void loadInfoDoctors()
        {
            DB db = new DB();

            DoctorsDataGridView.Rows.Clear();

            string query = $"select * from doctors";

            db.openConnection();
            using (MySqlCommand mySqlCommand = new MySqlCommand(query, db.getConnection()))
            {
                MySqlDataReader reader = mySqlCommand.ExecuteReader();

                List<string[]> dataDB = new List<string[]>();
                while (reader.Read())
                {
                    dataDB.Add(new string[reader.FieldCount]);

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        dataDB[dataDB.Count - 1][i] = reader[i].ToString();
                    }
                }
                reader.Close();
                foreach (string[] s in dataDB)
                    DoctorsDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void Doctors_Load(object sender, EventArgs e)
        {
            loadInfoDoctors();

            if (!(Main.login == "Admin" || Main.login == "admin"))
            {
                AddButton.Visible = false;
                EditButton.Visible = false;
                DeleteButton.Visible = false;
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            loadInfoDoctors();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddDoctors ad = new AddDoctors(null);
            ad.Show();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            AddDoctors ad = new AddDoctors(DoctorsDataGridView[0, DoctorsDataGridView.SelectedCells[0].RowIndex].Value.ToString());
            ad.Show();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand($"delete from doctors where id = {DoctorsDataGridView[0, DoctorsDataGridView.SelectedCells[0].RowIndex].Value}", db.getConnection());
            db.openConnection();

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Врач удален");

            }
            catch
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db.closeConnection();
            loadInfoDoctors();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            DoctorsDataGridView.Rows.Clear();

            string searchString = $"select * from doctors where concat (name, surname, patronymic, speciality, qualification) like '%" + SearchTextBox.Text + "%'";
            
            db.openConnection();
            using (MySqlCommand mySqlCommand = new MySqlCommand(searchString, db.getConnection()))
            {
                MySqlDataReader reader = mySqlCommand.ExecuteReader();

                List<string[]> dataDB = new List<string[]>();
                while (reader.Read())
                {
                    dataDB.Add(new string[reader.FieldCount]);

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        dataDB[dataDB.Count - 1][i] = reader[i].ToString();
                    }
                }
                reader.Close();
                foreach (string[] s in dataDB)
                    DoctorsDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }
    }
}
