using JudoArena.Model.DB;
using JudoArena.Model;
using System.Diagnostics;
using System.Reflection.Metadata;

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
        
        public DelegateCommand<object> ChangePage => new DelegateCommand<object>(obj =>
        {
            MessageBox.Show(((Competition)obj).Name);
        });
        bool IsSorting = false;
        public DelegateCommand Sorting => new(() =>
        {
            ObjectList =  IsSorting ? ObjectList.OrderBy(p => p.Name).ToList() : ObjectList.OrderByDescending(p => p.Name).ToList();
            IsSorting = !IsSorting;
            RaisePropertiesChanged("ObjectList");
        });
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
        public HomeVM()
        {
            _navigation = MainWindowVM.Navigation;
            Visibility = Visibility.Hidden;


            switch (((int)((object[])_navigation.Data)[1]))
            {
                case 0:
                    FullName = ((Participant)((object[])_navigation.Data)[0]).Surname;
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
