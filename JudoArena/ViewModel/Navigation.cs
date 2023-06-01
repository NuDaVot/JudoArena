namespace JudoArena.ViewModel
{
    class Navigation : BindableBase
    {
        private static object _currentView;
        public static object CurrentView 
        { 
            get { return _currentView; } 
            set { _currentView = value; } 
        }
        public Navigation()
        {
            CurrentView = new SignInVM();
        }
    }
}
