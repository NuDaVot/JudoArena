

using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Media3D;

namespace JudoArena.Model.DB
{
    class ControlCompetition
    {
        private readonly JudoContext _context = new();

        public List<Competition> GetCompetitionList()
        {
            return _context.Competitions.Include(c => c.OrganizerNavigation).ToList();
        }
        
        public Competition AddCompetition(string name, DateOnly date, string address, int organizer)
        {
            Competition competition = new Competition
            {
                Id = _context.Competitions.Max(c => c.Id) + 1,
                Name = name,
                Date = date,
                Address = address,
                Organizer = organizer
            };
            _context.Competitions.Add(competition);
            _context.SaveChanges();
            return competition;
        }
        public Weight WeightSearch(decimal start, decimal end) 
        {
            return _context.Weights.SingleOrDefault(p => p.WeightStart == start && p.WeightEnd == end);
        }
        public void AddWeight(decimal start, decimal end)
        {
            Weight weight = new Weight
            {
                Id = _context.Weights.Max(c => c.Id) + 1,
                WeightStart = start,
                WeightEnd = end
            };
            _context.Weights.Add(weight);
            _context.SaveChanges();
        }
        public Age AgeSearch(DateOnly? start, DateOnly? end)
        {
            return _context.Ages.SingleOrDefault(p => p.AgeStart == start && p.AgeEnd == end);
        }
        public void AddAge(DateOnly? start, DateOnly? end)
        {
            Age age = new Age
            {
                Id = _context.Ages.Max(c => c.Id) + 1,
                AgeStart = start,
                AgeEnd = end
            };
            _context.Ages.Add(age);
            _context.SaveChanges();
        }
        public void AddCategory(int IdCompetition, List<Weight> weights, List<Age> ages)
        {
            foreach (Weight weight in weights)
            {
                foreach(Age age in ages)
                {
                    _context.Categories.Add(new Category 
                    { 
                        Id = _context.Categories.Max(c => c.Id) + 1,
                        IdCompetition = IdCompetition,
                        IdWeight = weight.Id,
                        IdAge = age.Id
                    }
                    );
                    _context.SaveChanges();
                }
            }
            
        }
        public List<Category> GetCategory(int IdCompetition)
        {
            return _context.Categories.Where(p => p.IdCompetition == IdCompetition).Include(c => c.IdAgeNavigation).Include(c => c.IdWeightNavigation).ToList();
        }
        public List<ParticipantCategory> GetParticipantCategory(int IdCategory)
        {
            return _context.ParticipantCategories.Where(p => p.IdCategory == IdCategory).Include(c => c.IdParticipantNavigation).Include(c => c.IdTrainerNavigation).ToList();
        }
        public ParticipantCategory ParticipantCategorySearch(int Id)
        {
            return _context.ParticipantCategories.SingleOrDefault(p => p.Id == Id );
        }
        public void SaveContext()
        {
            _context.SaveChanges();
        }
        public List<Participant> GetParticipant(Category Category)
        {
            return _context.Participants.Where(p => (p.Weight >= Category.IdWeightNavigation.WeightStart && p.Weight < Category.IdWeightNavigation.WeightEnd) &&
            (p.DateBirth.Value.Year >= Category.IdAgeNavigation.AgeStart.Value.Year  && p.DateBirth.Value.Year <= Category.IdAgeNavigation.AgeEnd.Value.Year)).ToList();
        }
        public void AddParticipantCategorie(int IdTrainer, int IdCategory, ObservableCollection<Participant> Participants)
        {
            foreach (var participant in Participants)
            {
                DateTime currentDate = DateTime.Now.Date;
                _context.ParticipantCategories.Add(new ParticipantCategory
                {
                    Id = _context.ParticipantCategories.Max(c => c.Id) + 1,
                    IdParticipant = participant.Id,
                    IdCategory = IdCategory,
                    IdTrainer = IdTrainer,
                    Date = new DateOnly(currentDate.Year, currentDate.Month, currentDate.Day)
                });
                _context.SaveChanges();
            }
        }
        public List<ParticipantCategory> GetParticipantCategory(int IdParticipant, bool flag)
        {
            return _context.ParticipantCategories.Where(p => p.IdParticipant == IdParticipant).Include(c => c.IdCategoryNavigation.IdCompetitionNavigation).ToList();
        }
    }
}
