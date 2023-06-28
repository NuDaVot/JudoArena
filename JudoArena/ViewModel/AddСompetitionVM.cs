using JudoArena.Model;
using JudoArena.Model.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media.Media3D;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JudoArena.ViewModel
{
    class AddСompetitionVM : BindableBase
    {
        private readonly Navigation _navigation;

        ControlCompetition _competition = new ControlCompetition();
        public string NameWin { get; set; }
        public DelegateCommand GoHome => new(() =>
        {
            _navigation.CurrentView = new HomeVM();
        });
        private bool IsChecedNull()
        {
            if(string.IsNullOrWhiteSpace(_nameСompetition) || string.IsNullOrWhiteSpace(_address) ) 
            {
                return false;
            }
            if(_nameСompetition == string.Empty)
            {
                return false;
            }
            if (_address == string.Empty)
            {
                return false;
            }
            if (!Date.HasValue)
            {
                return false;
            }
            if (ObjectWeight.Count < 1)
            {
                return false;
            }
            if (ObjectAge.Count < 1)
            {
                return false;
            }
            return true;
        }
        private string _nameСompetition;
        public string NameСompetition
        {
            set 
            { 
                _nameСompetition = value; 
                RaisePropertiesChanged("NameСompetition");
                Error = IsChecedNull() ? "" : "Что - то пусто";

            }
            get { return _nameСompetition; }
        }
        private string _address;
        public string Address
        {
            set
            {
                _address = value;
                RaisePropertiesChanged("Address");
                Error = IsChecedNull() ?  "" : "Что - то пусто";

            }
            get { return _address; }
        }
        public DateTime? Date { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public UserInterface User { get; set; }
        private string _error = "Что - то пусто";
        public string Error
        {
            set { _error = value; 
                RaisePropertiesChanged("VisibilityError"); RaisePropertiesChanged("Error"); }
            get { return _error; }
        }
        public Visibility VisibilityError
        {
            get { return Error != string.Empty ? Visibility.Visible : Visibility.Hidden; }
        }
        public DelegateCommand AddC => new(() =>
        {
            Competition competition = _competition.AddCompetition(NameСompetition, DateOnly.FromDateTime(Date.Value), Address, User.Id);

            _competition.AddCategory(competition.Id, ObjectWeight, ListAge);
            MessageBox.Show("Добавленно");
            _navigation.CurrentView = new HomeVM();
        }
        , bool () =>
        {
            return Error == string.Empty;
        }
        );


        public string WeightStartSTR { get; set; } = "";
        public string WeightEndSTR { get; set; } = "";
        List<Weight> list = new List<Weight>();
        public DelegateCommand AddWeight => new(() =>
        {
            Error = $"";
            list = ObjectWeight;
            decimal WeightStart1;
            if (!decimal.TryParse(WeightStartSTR.Replace(".", ","), out WeightStart1))
            {
                Error = $"Ошибка";
                return;
            }
            decimal WeightEnd1;
            if (!decimal.TryParse(WeightEndSTR.Replace(".", ","), out WeightEnd1))
            {
                Error = $"Ошибка";
                return;
            }
            if (WeightStart1 >= WeightEnd1)
            {
                Error = "Начало больше завершения";
                MessageBox.Show("Начало больше завершения");
                return;
            }
            Weight weight = _competition.WeightSearch(WeightStart1, WeightEnd1);
            if (!ObjectWeight.Contains(weight))
                if (weight != null)
                {
                    list.Add(weight);
                }
                else
                {
                    _competition.AddWeight(WeightStart1, WeightEnd1);
                    weight = _competition.WeightSearch(WeightStart1, WeightEnd1);
                    list.Add(weight);
                }
            else MessageBox.Show("Уже есть");
            ObjectWeight = new List<Weight>();
            ObjectWeight = list;
            RaisePropertiesChanged("ObjectWeight");
        }
        , bool () =>
        {
            return !WeightStartSTR.Equals("") && !WeightEndSTR.Equals("");
        });
        public DelegateCommand<object> DeleteWeight => new DelegateCommand<object>(obj =>
        {
            if (_navigation.Competition == null)
            {
                MessageBoxResult result = MessageBox.Show(
                    $"Вы уверены, что хотите удалить объект {WeightStartSTR}/{WeightEndSTR}?",
                    "Подтверждение удаления", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    Weight weight = (Weight)obj;
                    list = ObjectWeight;
                    list.Remove(weight);
                    ObjectWeight = new List<Weight>();
                    ObjectWeight = list;
                    RaisePropertiesChanged("ObjectWeight");
                }
            }
        });
        private List<Weight> _ojectWeight;
        public List<Weight> ObjectWeight
        {
            get { return _ojectWeight; }
            set
            {
                _ojectWeight = value;
                RaisePropertiesChanged("ObjectWeight");
                Error = IsChecedNull() ? "" : "Что - то пусто";
            }
        }

        List<Age> ListAge = new List<Age>();
        public DateTime DateBr { get; set; }
        public DateTime? DateBRStart { get; set; }
        public DateTime? DateBREnd { get; set; }
        public DelegateCommand AddAge => new(() =>
        {
            Error = $"";
            ListAge = ObjectAge;

            if (DateBRStart >= DateBREnd)
            {
                Error = "Начало больше завершения";
                MessageBox.Show("Начало больше завершения");
                return;
            }

            Age age = _competition.AgeSearch(new DateOnly(DateBRStart.Value.Year, DateBRStart.Value.Month, DateBRStart.Value.Day), 
                new DateOnly(DateBREnd.Value.Year, DateBREnd.Value.Month, DateBREnd.Value.Day));
            if (!ObjectAge.Contains(age))
                if (age != null)
                {
                    ListAge.Add(age);
                }
                else
                {
                    _competition.AddAge(new DateOnly(DateBRStart.Value.Year, DateBRStart.Value.Month, DateBRStart.Value.Day),
                new DateOnly(DateBREnd.Value.Year, DateBREnd.Value.Month, DateBREnd.Value.Day));
                    age = _competition.AgeSearch(new DateOnly(DateBRStart.Value.Year, DateBRStart.Value.Month, DateBRStart.Value.Day),
                new DateOnly(DateBREnd.Value.Year, DateBREnd.Value.Month, DateBREnd.Value.Day));
                    ListAge.Add(age);
                }
            else MessageBox.Show("Уже есть");
            ObjectAge = new List<Age>();
            ObjectAge = ListAge;
            RaisePropertiesChanged("ObjectAge");
        }
        , bool () =>
        {
            return DateBRStart != null && DateBREnd != null;
        }
        );
        public DelegateCommand<object> DeleteAge => new DelegateCommand<object>(obj =>
        {
            if (_navigation.Competition == null)
            {
                MessageBoxResult result = MessageBox.Show(
                    $"Вы уверены, что хотите удалить объект {DateBRStart.Value.Date}/{DateBREnd.Value.Date}?",
                    "Подтверждение удаления", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    Age age = (Age)obj;
                    ListAge = ObjectAge;
                    ListAge.Remove(age);
                    ObjectAge = new List<Age>();
                    ObjectAge = ListAge;
                    RaisePropertiesChanged("ObjectAge");
                }
            }
        });
        private List<Age> _ojectAge;
        public List<Age> ObjectAge
        {
            get { return _ojectAge; }
            set
            {
                _ojectAge = value;
                RaisePropertiesChanged("ObjectAge");
                Error = IsChecedNull() ? "" : "Что - то пусто";
            }
        }
        public string Organizer { get; set; }
        public Visibility VisibilityPage { get; set; }
        public Visibility VisibilityOrganizer { get; set; }
        public bool IsReadOnly { get ; set; }
        public bool IsEnabled { get; set; }
        public AddСompetitionVM()
        {
            _navigation = MainWindowVM.Navigation;
            IsReadOnly = !(_navigation.Competition == null);
            IsEnabled = !IsReadOnly;
            if (_navigation.Competition == null)
            {
                NameWin = _navigation.NameWin;

                User = ((UserInterface)((object[])_navigation.Data)[0]);

                DateStart = DateTime.Now;
                Date = null;
                DateEnd = DateTime.Today.AddYears(1);
                DateBr = DateTime.Today.AddYears(-150);
                _ojectWeight = new List<Weight>();
                _ojectAge = new List<Age>();
                DateBRStart = null;
                DateBREnd = null;
                VisibilityPage = Visibility.Visible;
                VisibilityOrganizer = Visibility.Hidden;
            }
            else
            {
                NameWin = _navigation.NameWin;
                Competition competition = _navigation.Competition;
                List<Category> categories = _competition.GetCategory(competition.Id);
                _ojectWeight = new List<Weight>();
                _ojectAge = new List<Age>();
                foreach (Category category in categories)
                {
                    Weight weight = category.IdWeightNavigation;
                    if (!_ojectWeight.Contains(weight))
                        _ojectWeight.Add(weight);
                    Age age = category.IdAgeNavigation;
                    if (!_ojectAge.Contains(age))
                        _ojectAge.Add(age);
                }
                Organizer = competition.OrganizerNavigation.Surname;
                NameWin = "";
                User = null;
                NameСompetition = competition.Name;
                Date = new DateTime(competition.Date.Value.Year, competition.Date.Value.Month, competition.Date.Value.Day);
                Address = competition.Address;
                VisibilityPage = Visibility.Hidden;

                VisibilityOrganizer = Visibility.Visible;
            }
           
        }
    }
}
