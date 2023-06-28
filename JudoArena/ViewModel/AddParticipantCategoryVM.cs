using JudoArena.Model.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudoArena.ViewModel
{
    class AddParticipantCategoryVM : BindableBase
    {
        ControlCompetition _competition = new ControlCompetition();

        bool IsSorting = false;
        private ObservableCollection<Participant> _objectList { get; set; }
        public ObservableCollection<Participant> ObjectList { get; set; }
        public DelegateCommand Sorting => new(() =>
        {
            ObjectList = IsSorting ? new ObservableCollection<Participant>(ObjectList.OrderBy(p => p.Surname).ToList()) : new ObservableCollection<Participant>(ObjectList.OrderByDescending(p => p.Surname).ToList());
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
                ObjectList = _search.Length > 0 ? new ObservableCollection<Participant>(
                    _objectList.Where(item => item.Name.Contains(_search) || item.Surname.Contains(_search) || item.Patronymic.Contains(_search)).ToList()) : _objectList;
                RaisePropertiesChanged("ObjectList");
            }
        }

        private ObservableCollection<Participant> _addList { get; set; }
        public ObservableCollection<Participant> AddList
        {
            get { return _addList; }
            set { _addList = value; RaisePropertiesChanged("AddList"); }
        }
        ObservableCollection<Participant> list = new ObservableCollection<Participant>();
        public DelegateCommand<object> Add => new DelegateCommand<object>(obj =>
        {
            Participant participant = (Participant)obj;
            AddList.Add(participant);
            RaisePropertiesChanged("AddList");
            list = ObjectList;
            ObjectList = new ObservableCollection<Participant>();
            list.Remove(participant);
            ObjectList = list;
            RaisePropertiesChanged("ObjectList");
        });
        public DelegateCommand<object> Delete => new DelegateCommand<object>(obj =>
        {
            Participant participant = (Participant)obj;
            ObjectList.Add(participant);
            RaisePropertiesChanged("AddList");
            AddList.Remove(participant);
            RaisePropertiesChanged("ObjectList");
        });
        public DelegateCommand Geft => new(() =>
        {
            if(AddList.Count > 0)
            {
                _competition.AddParticipantCategorie(User.Id, _navigation.Category.Id, AddList);
                MessageBox.Show("Заяка отправлена");
                _navigation.CurrentView = _navigation.CurrentViewOld;
            }
            else
            {
                MessageBox.Show("Пусто");
            }
        });


        private readonly Navigation _navigation;
        public UserInterface User { get; set; }
        public DelegateCommand GoHome => new(() =>
        {
            _navigation.CurrentView = _navigation.CurrentViewOld;
        });
        public AddParticipantCategoryVM() 
        {
            _navigation = MainWindowVM.Navigation;
            User = ((UserInterface)((object[])_navigation.Data)[0]);
            _objectList = new ObservableCollection<Participant>(_navigation.Participants);
            _addList = new ObservableCollection<Participant>();
            ObjectList = _objectList;
        }
    }
}
