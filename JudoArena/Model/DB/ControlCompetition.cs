

namespace JudoArena.Model.DB
{
    class ControlCompetition
    {
        private readonly JudoContext _context = new JudoContext();

        public List<Competition> GetCompetitionList()
        {
            return _context.Competitions.Include(c => c.OrganizerNavigation).ToList();
        }
    }
}
