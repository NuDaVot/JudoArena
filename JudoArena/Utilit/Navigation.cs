namespace JudoArena.ViewModel
{
    public class Navigation : ViewModelBase
    {
        private object _currentView = new SignInVM();
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; RaisePropertiesChanged("CurrentView"); }
        }

        public object Data { get; set; }
        public string NameWin { get ; set; }
        public Competition Competition { get; set; }
        public object CurrentViewOld { get; set; } 
        public Category Category { get; set; }
        public List<Participant> Participants { get; set; }
    }
}
