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
    public partial class Finance : Form
    {
        private string id = null;
        private double expenses = 0;
        private double income = 0;
        private double profit = 0;
        public Finance(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddExpenses ae = new AddExpenses(null);
            ae.Show();
        }
        private void loadInfoExpenses()
        {
            DB db = new DB();

            ExpensesDataGridView.Rows.Clear();

            string query = $"select expenses.*, concat(doctors.name, ' ', doctors.patronymic, ' ', doctors.surname) as doctorFio from expenses join doctors on doctors.id = expenses.idDoctor";

            db.openConnection();
            using (MySqlCommand mySqlCommand = new MySqlCommand(query, db.getConnection()))
            {
                MySqlDataReader reader = mySqlCommand.ExecuteReader();

                List<string[]> dataDB = new List<string[]>();
                while (reader.Read())
                {
                    dataDB.Add(new string[reader.FieldCount]);
                    expenses += Convert.ToInt32(reader["price"]);
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        dataDB[dataDB.Count - 1][i] = reader[i].ToString();
                    }
                }
                reader.Close();
                foreach (string[] s in dataDB)
                    ExpensesDataGridView.Rows.Add(s);
            }
            db.closeConnection();

            ExpensesLabel.Text = expenses.ToString();
        }
        private void sumIncome()
        {
            DB db = new DB();

            string query = $"select price from treatments";

            db.openConnection();
            using (MySqlCommand mySqlCommand = new MySqlCommand(query, db.getConnection()))
            {
                MySqlDataReader reader = mySqlCommand.ExecuteReader();

                List<string[]> dataDB = new List<string[]>();
                while (reader.Read())
                {
                    income += Convert.ToInt32(reader[0]);
                }
                reader.Close();
            }
            db.closeConnection();

            incomeLabel.Text = income.ToString();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            AddExpenses ae = new AddExpenses(ExpensesDataGridView[0, ExpensesDataGridView.SelectedCells[0].RowIndex].Value.ToString());
            ae.Show();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand($"delete from expenses where id = {ExpensesDataGridView[0, ExpensesDataGridView.SelectedCells[0].RowIndex].Value}", db.getConnection());
            db.openConnection();

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Расход удален");

            }
            catch
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db.closeConnection();
            loadInfoExpenses();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            ExpensesDataGridView.Rows.Clear();

            string searchString = $"select expenses.*, concat(doctors.name, ' ', doctors.patronymic, ' ', doctors.surname) as doctorFio from expenses " +
                $"join doctors on doctors.id = expenses.idDoctor " +
                $"where concat (price, description, concat(doctors.name, ' ', doctors.patronymic, ' ', doctors.surname)) like '%" + SearchTextBox.Text + "%'";

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
                    ExpensesDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void Finance_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            loadInfoExpenses();
        }

        private void Finance_Load(object sender, EventArgs e)
        {
            loadInfoExpenses();

            sumIncome();
            profit = income - expenses;
            ProfitLabel.Text = profit.ToString();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Main main = new Main(id);
            main.Show();
            this.Hide();
        }
    }
}
