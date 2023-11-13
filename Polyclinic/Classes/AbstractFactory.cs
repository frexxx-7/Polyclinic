using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.Classes
{
    // Абстрактная фабрика
    public interface IPolyclinicFactory
    {
        IDoctor CreateDoctor();
        IPatient CreatePatient();
    }

    // Конкретная фабрика для частной поликлиники
    public class PrivatePolyclinicFactory : IPolyclinicFactory
    {
        public IDoctor CreateDoctor()
        {
            return new PrivateDoctor();
        }

        public IPatient CreatePatient()
        {
            return new PrivatePatient();
        }
    }

    // Конкретная фабрика для государственной поликлиники
    public class PublicPolyclinicFactory : IPolyclinicFactory
    {
        public IDoctor CreateDoctor()
        {
            return new PublicDoctor();
        }

        public IPatient CreatePatient()
        {
            return new PublicPatient();
        }
    }

    // Абстрактный класс врача
    public interface IDoctor
    {
        void ExaminePatient(IPatient patient);
    }

    // Конкретный класс врача для частной поликлиники
    public class PrivateDoctor : IDoctor
    {
        public void ExaminePatient(IPatient patient)
        {
            Console.WriteLine("Private doctor examines patient");
        }
    }

    // Конкретный класс врача для государственной поликлиники
    public class PublicDoctor : IDoctor
    {
        public void ExaminePatient(IPatient patient)
        {
            Console.WriteLine("Public doctor examines patient");
        }
    }

    // Абстрактный класс пациента
    public interface IPatient
    {
        void Register();
    }

    // Конкретный класс пациента для частной поликлиники
    public class PrivatePatient : IPatient
    {
        public void Register()
        {
            Console.WriteLine("Private patient registers at the clinic");
        }
    }

    // Конкретный класс пациента для государственной поликлиники
    public class PublicPatient : IPatient
    {
        public void Register()
        {
            Console.WriteLine("Public patient registers at the clinic");
        }
    }

    // Клиентский код
    class Client
    {
        private IPolyclinicFactory _factory;
        private IDoctor _doctor;
        private IPatient _patient;

        public Client(IPolyclinicFactory factory)
        {
            _factory = factory;
            _doctor = _factory.CreateDoctor();
            _patient = _factory.CreatePatient();
        }

        public void RunPolyclinic()
        {
            _patient.Register();
            _doctor.ExaminePatient(_patient);
        }
    }
}
