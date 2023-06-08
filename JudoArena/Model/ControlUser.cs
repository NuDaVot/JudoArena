

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
            return _context.Logins.SingleAsync(p => p.Loggin == login).Result;
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
        public async Task<Login> IsCheckedLogin(string login)
        {
            return _context.Logins.SingleOrDefaultAsync(p => p.Loggin == login).Result ;
        }
        public async Task<Trainer> AddTrainer(string Surname, string Name, string Patronymic, string License, string Login, string Password)
        {
            await _context.Logins.AddAsync(new Login
            {
                Loggin = Login,
                Password = Password,
                Role = 1
            });
            await _context.SaveChangesAsync();
            await _context.Trainers.AddAsync(new Trainer 
            {
                Surname = Surname,
                Name = Name,
                Patronymic = Patronymic,
                LicenseNumber = License,
                LoginTrainer = IsCheckedLogin(Login).Result.Id
            });
            await _context.SaveChangesAsync();
            return GetTrainer(GetUserByLogin(Login).Result.Id).Result;
        }
    }
}
