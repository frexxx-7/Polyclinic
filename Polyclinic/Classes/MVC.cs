using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.Classes
{
    public class Patients
    {
        public string Name { get; set; }
        public string Diagnosis { get; set; }
        // Другие свойства пациента
    }

    // Представление
    public class PatientView
    {
        public void ShowPatientInfo(Patients patient)
        {
            // Отображение информации о пациенте
        }
    }

    // Контроллер
    public class PatientController
    {
        private Patients model;
        private PatientView view;

        public PatientController(Patients model, PatientView view)
        {
            this.model = model;
            this.view = view;
        }

        public void UpdatePatientInfo(string name, string diagnosis)
        {
            model.Name = name;
            model.Diagnosis = diagnosis;
            view.ShowPatientInfo(model);
        }
    }
}
