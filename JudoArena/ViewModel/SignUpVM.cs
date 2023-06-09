using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using System;

namespace JudoArena.ViewModel
{
    class SignUpVM : BindableBase
    {
        private readonly Navigation _navigation;
        ControlUser controlUser = new ControlUser();
        public DelegateCommand GoSignIn => new(() =>
        {
            _navigation.CurrentView = new SignInVM();
        });


        private (bool, string) ValidateInitials(string PathName, int Length)
        {
            Regex regex = new Regex(@"\d");
            if (PathName.Length < Length)
                return (false, $"Слишком коротко - {PathName}");
            if (regex.IsMatch(PathName))
                return (false, $"Есть числа - {PathName}");
            return (true, "");
        }
        private bool IsNullTrainer()
        {
            if (string.IsNullOrWhiteSpace(TrainerSurname))
                return false;
            if (string.IsNullOrWhiteSpace(TrainerName))
                return false;
            if (string.IsNullOrWhiteSpace(TrainerPatronymic))
                return false;
            if (string.IsNullOrWhiteSpace(TrainerLicense))
                return false;
            if (string.IsNullOrWhiteSpace(TrainerLogin))
                return false;
            if (string.IsNullOrWhiteSpace(TrainerPassword))
                return false;
            if (string.IsNullOrWhiteSpace(TrainerRepeat))
                return false;
            return true;
        }
        private bool ValidateInitialsFullT()
        {
            var booSurname = ValidateInitials(TrainerSurname, 3);
            if (!booSurname.Item1) { TrainerError = booSurname.Item2; return booSurname.Item1; }

            var boolName = ValidateInitials(TrainerName, 2);
            if (!boolName.Item1) { TrainerError = boolName.Item2; return boolName.Item1; }

            var boolPatronymic = ValidateInitials(TrainerPatronymic, 3);
            if (!boolPatronymic.Item1) { TrainerError = boolPatronymic.Item2; return boolPatronymic.Item1; }

            return true;
        }
        private bool IsCheckedPassword(string Password, int Length)
        {
            if (Password.Length < Length) return false;
            if (!new Regex(@"\D").IsMatch(Password)) return false;
            if (!new Regex(@"\d").IsMatch(Password)) return false;
            return true;
        }
        public string TrainerSurname { get; set; }
        public string TrainerName { get; set; }
        public string TrainerPatronymic { get; set; }
        public string TrainerLicense { get; set; }
        public string TrainerLogin { get; set; }
        public string TrainerPassword { get; set; }
        public string TrainerRepeat { get; set; }
        private string _trainerError = "Что-то пусто";
        public string TrainerError
        {
            set { _trainerError = value; RaisePropertiesChanged("TrainerVisibilityError"); RaisePropertiesChanged("TrainerError"); }
            get { return _trainerError; }
        }
        public Visibility TrainerVisibilityError
        {
            get { return TrainerError != string.Empty ? Visibility.Visible : Visibility.Hidden; }
        }
        public DelegateCommand TrainerSignUp => new(() =>
        {
            TrainerError = "";
            if (!ValidateInitialsFullT())
                return;
            if (new Regex(@"\D").IsMatch(TrainerLicense))
            {
                TrainerError = $"Не число - {TrainerLicense}";
                return;
            }
            if (TrainerLicense.Length != 10)
            {
                TrainerError = $"Лицензия состоит из 10 цифр";
                return;
            }
            if (TrainerLogin.Length < 7)
            {
                TrainerError = $"Логин состоит из 7 символов";
                return;
            }
            if (controlUser.IsCheckedLogin(TrainerLogin) != null)
            {
                TrainerError = $"Логин уже есть";
                return;
            }
            if (!IsCheckedPassword(TrainerPassword, 10))
            {
                TrainerError = $"Пароль должен состоять из 10 символов,\nиз букв и цыфр";
                return;
            }
            if (!TrainerPassword.Equals(TrainerRepeat))
            {
                TrainerError = $"Пароли не совпадают";
                return;
            }
            TrainerError = "";
            try
            {
                _navigation.Data = null;
                UserInterface User = controlUser.AddTrainer(TrainerSurname, TrainerName, TrainerPatronymic, 
                                                        TrainerLicense, TrainerLogin, TrainerPassword);
                _navigation.Data = new object[] { User, 1 };
                _navigation.CurrentView = new HomeVM();
                TrainerError = "";
            }
            catch (Exception ex)
            {
                TrainerError = "Ошибка";
            }


        }
        , bool () =>
        {
            if (!IsNullTrainer())
            {
                TrainerError = "Что-то пусто";
                return false;
            }
            else
            {
                if (TrainerError == "Что-то пусто")
                    TrainerError = string.Empty;
                return true;
            }
        }
        );


        private bool IsNullParticipant()
        {
            if (string.IsNullOrWhiteSpace(ParticipantSurname))
                return false;
            if (string.IsNullOrWhiteSpace(ParticipantName))
                return false;
            if (string.IsNullOrWhiteSpace(ParticipantPatronymic))
                return false;
            if (string.IsNullOrWhiteSpace(ParticipantWeight))
                return false;
            if (!ParticipantDateBirth.HasValue)
                return false;
            if (string.IsNullOrWhiteSpace(ParticipantHealth))
                return false;
            if (string.IsNullOrWhiteSpace(ParticipantLogin))
                return false;
            if (string.IsNullOrWhiteSpace(ParticipantPassword))
                return false;
            if (string.IsNullOrWhiteSpace(ParticipantRepeat))
                return false;
            return true;
        }
        private bool ValidateInitialsFullP()
        {
            var booSurname = ValidateInitials(ParticipantSurname, 3);
            if (!booSurname.Item1) { ParticipantError = booSurname.Item2; return booSurname.Item1; }

            var boolName = ValidateInitials(ParticipantName, 2);
            if (!boolName.Item1) { ParticipantError = boolName.Item2; return boolName.Item1; }

            var boolPatronymic = ValidateInitials(ParticipantPatronymic, 3);
            if (!boolPatronymic.Item1) { ParticipantError = boolPatronymic.Item2; return boolPatronymic.Item1; }

            return true;
        }
        public string ParticipantSurname { get; set; }
        public string ParticipantName { get; set; }
        public string ParticipantPatronymic { get; set; }
        public string ParticipantWeight { get; set; }
        public DateTime? ParticipantDateBirth { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string ParticipantHealth { get; set; }
        public string ParticipantLogin { get; set; }
        public string ParticipantPassword { get; set; }
        public string ParticipantRepeat { get; set; }
        private string _participanError = "Что-то пусто";
        public string ParticipantError
        {
            set { _participanError = value; RaisePropertiesChanged("ParticipanVisibilityError"); RaisePropertiesChanged("ParticipantError"); }
            get { return _participanError; }
        }
        public Visibility ParticipanVisibilityError
        {
            get { return ParticipantError != string.Empty ? Visibility.Visible : Visibility.Hidden; }
        }
        public DelegateCommand ParticipantSignUp => new(() =>
        {
            ParticipantError = "";
            if (!ValidateInitialsFullP())
                return;
            if (!new Regex(@"^-?\d+(\.\d+)?(,\d+)?$").IsMatch(ParticipantWeight))
            {
                ParticipantError = $"Не число - {ParticipantWeight}";
                return;
            }
            decimal result;
            if (!decimal.TryParse(ParticipantWeight.Replace(".", ","), out result))
            {
                ParticipantError = $"Ошибка";
                return;
            }
            if (result < 5)
            {
                ParticipantError = $"Малый вес - {result}";
                return;
            }
            if (new Regex(@"\D").IsMatch(ParticipantHealth))
            {
                ParticipantError = $"Не число - {ParticipantHealth}";
                return;
            }
            if (ParticipantHealth.Length != 10)
            {
                ParticipantError = $"Страховка состоит из 10 цифр";
                return;
            }
            if (ParticipantLogin.Length < 7)
            {
                ParticipantError = $"Логин состоит из 7 символов";
                return;
            }
            if (controlUser.IsCheckedLogin(ParticipantLogin) != null)
            {
                ParticipantError = $"Логин уже есть";
                return;
            }
            if (!IsCheckedPassword(ParticipantPassword, 10))
            {
                ParticipantError = $"Пароль должен состоять из 10 символов, из букв и цифр";
                return;
            }
            if (!ParticipantPassword.Equals(ParticipantRepeat))
            {
                ParticipantError = $"Пароли не совпадают";
                return;
            }
            ParticipantError = "";
            try
            {
                _navigation.Data = null;
                DateOnly data = DateOnly.FromDateTime(ParticipantDateBirth.Value);
                UserInterface User = controlUser.AddParticipant(ParticipantSurname, ParticipantName, ParticipantPatronymic,
                                                           result, data, ParticipantHealth, ParticipantLogin, ParticipantPassword);

                _navigation.Data = new object[] { User, 0 };
                _navigation.CurrentView = new HomeVM();
                
            }
            catch (Exception ex)
            {
                ParticipantError = "Ошибка";
            }

        }
        , bool () =>
        {
            if (!IsNullParticipant())
            {
                ParticipantError = "Что-то пусто";
                return false;
            }
            else
            {
                if (ParticipantError == "Что-то пусто")
                    ParticipantError = string.Empty;
                return true;
            }
        }
        );

        public SignUpVM() 
        {
            _navigation = MainWindowVM.Navigation;
            TrainerLogin = ((string[])_navigation.Data)[0];
            TrainerPassword = ((string[])_navigation.Data)[1];
            ParticipantLogin = ((string[])_navigation.Data)[0];
            ParticipantPassword = ((string[])_navigation.Data)[1];
            DateStart  = new DateTime(1900, 1, 1);
            ParticipantDateBirth = null;
            DateEnd = DateTime.Today.AddYears(-3);
        }
    }
}
