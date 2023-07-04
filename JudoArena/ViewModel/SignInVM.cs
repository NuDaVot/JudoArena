using System.Diagnostics;

namespace JudoArena.ViewModel
{
    class SignInVM : BindableBase
    {
        ControlUser controlUser = new ControlUser();

        private bool _boollLoading = false;
        public bool BoollLoading
        {
            get { return _boollLoading; }
            set { _boollLoading = value; RaisePropertiesChanged("VisibilityLoading"); RaisePropertiesChanged("BoollLoading"); }
        }
        public Visibility VisibilityLoading
        {
            get { return BoollLoading ? Visibility.Visible : Visibility.Hidden;  }
        }

        private string _error = "Что-то пусто";
        public string Error
        {
            set { _error = value; RaisePropertiesChanged("VisibilityErrot"); RaisePropertiesChanged("Error"); }
            get { return _error; }
        }
        public Visibility VisibilityErrot
        {
            get { return Error != string.Empty ? Visibility.Visible : Visibility.Hidden; }
        }
        

        public string Password { get; set; }
        public string Login { set; get; }

        private readonly Navigation _navigation;

        public DelegateCommand GoSignUp => new(() =>
        {
            _navigation.Data = new string[] { Login, Password };
            _navigation.CurrentView = new SignUpVM();
        });
        public DelegateCommand SignIn => new(() =>
        {
            BoollLoading = true;
            Error = string.Empty;
            try
            {
                var login = controlUser.GetUserByLogin(Login).Result;
                if (login.Password.Equals(Password))
                {
                    UserInterface User = null;
                    switch (login.Role)
                    {
                        case 0:
                            User = controlUser.GetParticipant(login.Id).Result;
                            _navigation.Data = new object[] { User, 0 };
                            break;
                        case 1:
                            User = controlUser.GetTrainer(login.Id).Result;
                            _navigation.Data = new object[] { User, 1 };
                            break;

                        case 2:
                            User = controlUser.GetJudges(login.Id).Result;
                            _navigation.Data = new object[] { User, 2 };
                            break;
                    }
                    _navigation.CurrentView = new HomeVM();
                }
                else { Error = "Не тот пароль"; }
            }
            catch (AggregateException ex)
            {
                Error = "Пользователь не найден";
            }
            BoollLoading = false;
        }, bool () =>
        {
            if(string.IsNullOrWhiteSpace(Login) | string.IsNullOrWhiteSpace(Password))
            {
                Error = "Что-то пусто";
                return false;
            }
            else
            {
                if(Error == "Что-то пусто")
                    Error = string.Empty;
                return true;
            }
        });

        public SignInVM()
        {
            _navigation = MainWindowVM.Navigation;
            //Password = "admin123";
            //Login = "admin";
        }
    }
}
