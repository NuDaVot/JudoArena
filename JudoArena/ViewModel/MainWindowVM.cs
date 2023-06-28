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
        public DelegateCommand GoAboute => new(() =>
        {
            // Открытие нового окна
            var newWindow = new AboutJudoArenaWin();
            newWindow.Closing += (sender, e) =>
            {
                // Разморозка текущего окна при закрытии нового окна
                var currentWindow = Application.Current.MainWindow;
                currentWindow.IsEnabled = true;
            };
            newWindow.Show();

            // Заморозка текущего окна
            var currentWindow = Application.Current.MainWindow;
            currentWindow.IsEnabled = false;
        });
        public object CurrentView => Navigation.CurrentView;
        
        public MainWindowVM() 
        {
            Navigation.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
        }
    }
}
