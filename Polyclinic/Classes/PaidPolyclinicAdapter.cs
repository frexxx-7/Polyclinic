using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.Classes
{
    public class PaidPolyclinicAdapter : IPolyclinicFactory
    {
        private PaidPolyclinic _paidPolyclinic;

        public PaidPolyclinicAdapter(PaidPolyclinic paidPolyclinic)
        {
            _paidPolyclinic = paidPolyclinic;
        }

        public IDoctor CreateDoctor()
        {
            return new PaidDoctorAdapter(_paidPolyclinic.GetDoctor());
        }

        public IPatient CreatePatient()
        {
            return new PaidPatientAdapter(_paidPolyclinic.GetPatient());
        }
    }

    // Адаптер для работы с врачом платной поликлиники
    public class PaidDoctorAdapter : IDoctor
    {
        private PaidDoctor _paidDoctor;

        public PaidDoctorAdapter(PaidDoctor paidDoctor)
        {
            _paidDoctor = paidDoctor;
        }

        public void ExaminePatient(IPatient patient)
        {
            _paidDoctor.CheckUpPatient(((PaidPatientAdapter)patient).GetPaidPatient());
        }
    }

    // Адаптер для работы с пациентом платной поликлиники
    public class PaidPatientAdapter : IPatient
    {
        private PaidPatient _paidPatient;

        public PaidPatientAdapter(PaidPatient paidPatient)
        {
            _paidPatient = paidPatient;
        }

        public void Register()
        {
            _paidPatient.PayForRegistration();
        }

        public PaidPatient GetPaidPatient()
        {
            return _paidPatient;
        }
    }

    // Классы для работы с платной поликлиникой
    public class PaidPolyclinic
    {
        public PaidDoctor GetDoctor()
        {
            return new PaidDoctor();
        }

        public PaidPatient GetPatient()
        {
            return new PaidPatient();
        }
    }

    public class PaidDoctor
    {
        public void CheckUpPatient(PaidPatient patient)
        {
            Console.WriteLine("Paid doctor examines patient");
        }
    }

    public class PaidPatient
    {
        public void PayForRegistration()
        {
            Console.WriteLine("Paid patient pays for registration at the clinic");
        }
    }
}
