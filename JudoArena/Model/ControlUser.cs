using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace JudoArena.Model
{
    class ControlUser
    {
        private readonly JudoContext _context = new JudoContext();
        public async Task<Login> GetUserByLogin(string login)
        {
            return _context.Logins.SingleAsync(p => p.Login1 == login).Result;
        }
        public async Task<Judge> GetJudges(int IDLogin)
        {
            return _context.Judges.SingleAsync(p => p.LoginJudges == IDLogin).Result;
        }
        public async Task<Participant> GetParticipant(int IDLogin)
        {
            return _context.Participants.SingleAsync(p => p.LoginParticipant == IDLogin).Result;
        }
        public async Task<Trainer> GetTrainer(int IDLogin)
        {
            return _context.Trainers.SingleAsync(p => p.LoginTrainer == IDLogin).Result;
        }
        public Login IsCheckedLogin(string login)
        {
            return _context.Logins.SingleOrDefault(p => p.Login1 == login) ;
        }
        public Trainer AddTrainer(string Surname, string Name, string Patronymic, string License, string Login, string Password)
        {
            _context.Logins.Add(new Login
            {
                Login1 = Login,
                Password = Password,
                Role = 1
            });
             _context.SaveChanges();
            Trainer trainer = new Trainer
            {
                Surname = Surname,
                Name = Name,
                Patronymic = Patronymic,
                LicenseNumber = License,
                LoginTrainer = IsCheckedLogin(Login).Id
            };
            _context.Trainers.Add(trainer);
            _context.SaveChanges();
            return trainer;
        }
        public Participant AddParticipant(string Surname, string Name, string Patronymic, decimal Weight, DateOnly DateBirth, string HealthInsuranceNumber, string login, string Password)
        {
            _context.Logins.Add(new Login
            {
                Login1 = login,
                Password = Password,
                Role = 0
            });
            _context.SaveChanges();
            Participant participant = new Participant
            {
                Surname = Surname,
                Name = Name,
                Patronymic = Patronymic,
                Weight = Weight,
                DateBirth = DateBirth,
                HealthInsuranceNumber = HealthInsuranceNumber,
                LoginParticipant = IsCheckedLogin(login).Id
            };
            _context.Participants.Add(participant);
            _context.SaveChanges();
            return participant;
        }
    }
}
