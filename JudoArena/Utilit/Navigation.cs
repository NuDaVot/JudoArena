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
    }
}
