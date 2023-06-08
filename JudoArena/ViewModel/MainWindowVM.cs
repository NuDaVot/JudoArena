using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudoArena.ViewModel
{
    class MainWindowVM : ViewModelBase
    {
        public static readonly Navigation Navigation = new Navigation();

        public object CurrentView => Navigation.CurrentView;
        
        public MainWindowVM() 
        {
            Navigation.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
        }
    }
}
