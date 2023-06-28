using JudoArena.Model.DB;
using JudoArena.Model;
using System.Diagnostics;
using System.Reflection.Metadata;
using JudoArena.ViewModel;
using JudoArena.View;

namespace JudoArena.ViewModel
{

    class HomeVM : BindableBase
    {
        private readonly Navigation _navigation;
        
        ControlUser controlUser = new ControlUser();
        ControlCompetition _competition = new ControlCompetition();
        public string FullName { get; set; }
        public DelegateCommand GoSignIn => new(() =>
        {
            _navigation.Data = null;
            _navigation.CurrentView = new SignInVM();
        });
        public DelegateCommand GoProfile => new(() =>
        {
            _navigation.Data = null;
            _navigation.CurrentView = new SignInVM();
        });
        private List<Competition> _objectList { get; set; }
        public List<Competition> ObjectList {  get; set; }

        bool dostyp = false;
        public DelegateCommand<object> ChangePage => new DelegateCommand<object>(obj =>
        {
            _navigation.Competition = (Competition)obj;
            if (dostyp)
            {
                List<ParticipantCategory>  p = _competition.GetParticipantCategory(User.Id, dostyp);
                
                foreach(ParticipantCategory da in p)
                {
                    if (da.IdCategoryNavigation.IdCompetitionNavigation.Id == _navigation.Competition.Id)
                        dostyp = false; break;
                }
                if (dostyp) { MessageBox.Show("Нет доступа"); return; };
            }
            
            _navigation.CurrentView = new CompetitionsVM();
        });
        bool IsSorting = false;
        public DelegateCommand Sorting => new(() =>
        {
            ObjectList =  IsSorting ? ObjectList.OrderBy(p => p.Date).ToList() : ObjectList.OrderByDescending(p => p.Date).ToList();
            IsSorting = !IsSorting;
            RaisePropertiesChanged("ObjectList");
        });
        private string _selectedSort;
        public string SelectedSort
        {
            get { return _selectedSort; }
            set 
            {
                _selectedSort = value;
                DateTime currentDate = DateTime.Now.Date;
                DateOnly dateOnly = new DateOnly(currentDate.Year, currentDate.Month, currentDate.Day);
                switch (_selectedSort)
                {
                    case "Все":
                        ObjectList = _competition.GetCompetitionList();
                        break;
                    case "Завершенные":
                        
                        ObjectList = ObjectList.Where(item => item.Date < dateOnly).ToList() ;
                        break;
                    case "Запланированные":
                        ObjectList = ObjectList.Where(item => item.Date >= dateOnly).ToList();
                        break;
                }
                _objectList = ObjectList;
                if(_search != null)
                ObjectList = _search.Length > 0 ? _objectList.Where(item => item.Name.Contains(_search)).ToList() : _objectList;
                RaisePropertiesChanged("ObjectList");
            }
        }
        private string _search;
        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                ObjectList = _search.Length > 0 ? _objectList.Where(item => item.Name.Contains(_search)).ToList() : _objectList;
                RaisePropertiesChanged("ObjectList");
            }
        }
        public UserInterface User { get; set; }
        public Visibility Visibility { get; set; }
        public DelegateCommand AddCompetition => new(() =>
        {
            _navigation.NameWin = "Добавить соревнование";
            _navigation.Competition = null;
            _navigation.CurrentView = new AddСompetitionVM();
        });
        public HomeVM()
        {
            _navigation = MainWindowVM.Navigation;
            Visibility = Visibility.Hidden;


            switch (((int)((object[])_navigation.Data)[1]))
            {
                case 0:
                    FullName = ((Participant)((object[])_navigation.Data)[0]).Surname;
                    dostyp = true;
                    break;
                case 1:
                    FullName = ((Trainer)((object[])_navigation.Data)[0]).Surname;
                    break;

                case 2:
                    FullName = ((Judge)((object[])_navigation.Data)[0]).Surname;
                    Visibility = Visibility.Visible;
                    break;
            }
            User = ((UserInterface)((object[])_navigation.Data)[0]);
            _objectList = _competition.GetCompetitionList();
            ObjectList = _objectList;
        }
    }
}
