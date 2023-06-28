using JudoArena.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudoArena.ViewModel
{ 
    class ParticipantsVM : BindableBase
    {
        private readonly Navigation _navigation;

        public Visibility Visibility { get; set; }

        private List<Category> _categoryList { get; set; }
        public List<Category> CategoryList { get; set; }

        ControlCompetition _competition = new ControlCompetition();
        private Category _category;
        private readonly JudoContext _context = new();
        public DelegateCommand<object> CategorySelection => new DelegateCommand<object>(obj =>
        {
            _category = (Category)obj;
            ParticipantCategoryList = _competition.GetParticipantCategory(_category.Id);
            //Random random = new Random();
            //for (int i = 0; i < ParticipantCategoryList.Count; i++)
            //{
            //    var p = _competition.ParticipantCategorySearch(ParticipantCategoryList[i].Id);
            //    p.IdParticipantNavigation.DateBirth = new DateOnly(random.Next(_category.IdAgeNavigation.AgeStart.Value.Year, _category.IdAgeNavigation.AgeEnd.Value.Year + 1),
            //        random.Next(1, 13), random.Next(1, 28));
            //    p.IdParticipantNavigation.Weight = (Decimal)(random.Next((int)_category.IdWeightNavigation.WeightStart, (int)_category.IdWeightNavigation.WeightEnd) + Math.Round(random.NextDouble(), 1) % 10);
            //    _competition.SaveContext();
            //}
        });
        private List<ParticipantCategory> _participantCategoryList { get; set; }
        public List<ParticipantCategory> ParticipantCategoryList
        {
            get { return _participantCategoryList; }
            set { _participantCategoryList = value; RaisePropertiesChanged("ParticipantCategoryList"); }
        }
        public ParticipantsVM()
        {
            _navigation = MainWindowVM.Navigation;
            Visibility = Visibility.Hidden;


            switch (((int)((object[])_navigation.Data)[1]))
            {
                case 0:
                    break;
                case 1:
                    Visibility = Visibility.Visible;
                    break;
                case 2:
                    
                    break;
            }
            _categoryList = _competition.GetCategory(_navigation.Competition.Id);
            CategoryList = _categoryList;
            _category = CategoryList[0];
            ParticipantCategoryList = _competition.GetParticipantCategory(_category.Id);
        }
        public DelegateCommand AddParticipantCategory => new(() =>
        {
            _navigation.Category = _category;
            List<Participant> participant = new();
            foreach(var item in ParticipantCategoryList) 
            {
                participant.Add(item.IdParticipantNavigation);
            }
            _navigation.Participants = (_competition.GetParticipant(_navigation.Category)).Except(participant).ToList(); ;
            _navigation.CurrentViewOld = _navigation.CurrentView;
            _navigation.CurrentView = new AddParticipantCategoryVM();
        });
        
    }
}
