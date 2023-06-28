
namespace JudoArena.ViewModel
{
    class CompetitionsVM : BindableBase
    {
        private object _currentFrame;
        public object CurrentFrame
        {
            get { return _currentFrame; }
            set { _currentFrame = value; RaisePropertiesChanged("CurrentFrame"); }
        }
        public DelegateCommand Abuot => new(() =>
        {
            CurrentFrame = new AddСompetitionVM();
        }, () =>
        {
            return !(CurrentFrame is AddСompetitionVM);
        });
        public DelegateCommand Participants => new(() =>
        {
            CurrentFrame = new ParticipantsVM();
        });
        public Visibility Visibility { get; set; }
        public DelegateCommand Document => new(() =>
        {
            DocumentWord doc = new DocumentWord();
            doc.GenerateWord(_navigation.Competition);
        });
        private readonly Navigation _navigation;
        private Competition _competition;
        public string NameCompetition { get; set; }
        public UserInterface User { get; set; }
        public CompetitionsVM()
        {
            Visibility = Visibility.Hidden;
            _navigation = MainWindowVM.Navigation;
            _competition = _navigation.Competition;
            NameCompetition = _competition.Name;
            User = ((UserInterface)((object[])_navigation.Data)[0]);
            _navigation.NameWin = "О соревновании";
            _currentFrame = new AddСompetitionVM();
            switch (((int)((object[])_navigation.Data)[1]))
            {
                case 0:
                    break;
                case 1:
                    break;

                case 2:
                    Visibility = Visibility.Visible;
                    break;
            }
        }
        
        public DelegateCommand GoHome => new(() =>
        {
            _navigation.CurrentView = new HomeVM();
        });
    }
}
