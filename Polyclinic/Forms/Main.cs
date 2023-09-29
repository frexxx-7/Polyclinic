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
    public partial class Main : Form
    {
        private string id;
        public static string login;
        public Main(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DoctorsButton_Click(object sender, EventArgs e)
        {
            Doctors doc = new Doctors(id);
            doc.Show();
            this.Hide();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (!(id == "1"))
            {
                PatientsButton.Visible = false;
                FinanceButton.Visible = false;
            }
        }

        private void PatientsButton_Click(object sender, EventArgs e)
        {
            Patients pat = new Patients(id);
            pat.Show();
            this.Hide();
        }

        private void TreatmentsButton_Click(object sender, EventArgs e)
        {
            Treatments treat = new Treatments(id);
            treat.Show();
            this.Hide();
        }

        private void FinanceButton_Click(object sender, EventArgs e)
        {
            Finance fin = new Finance(id);
            fin.Show();
            this.Hide();
        }
    }
}
