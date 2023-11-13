using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.Classes
{
    // Интерфейс для всех состояний пациента
    public interface IPatientState
    {
        void HandlePatient(Patient patient);
    }

    // Конкретное состояние: пациент на приеме у врача
    public class InDoctorAppointmentState : IPatientState
    {
        public void HandlePatient(Patient patient)
        {
            // Логика обслуживания пациента на приеме у врача
        }
    }

    // Конкретное состояние: пациент ожидает приема у врача
    public class WaitingForDoctorState : IPatientState
    {
        public void HandlePatient(Patient patient)
        {
            // Логика ожидания приема у врача
        }
    }

    // Конкретное состояние: пациент получает медицинские услуги
    public class ReceivingMedicalServicesState : IPatientState
    {
        public void HandlePatient(Patient patient)
        {
            // Логика получения медицинских услуг
        }
    }

    // Класс пациента, который будет использовать состояния
    public class Patient
    {
        private IPatientState _state;

        public Patient()
        {
            _state = new WaitingForDoctorState(); // Начальное состояние - ожидание приема у врача
        }

        public void SetState(IPatientState state)
        {
            _state = state;
        }

        public void HandlePatient()
        {
            _state.HandlePatient(this);
        }
    }

}
