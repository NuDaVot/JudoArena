using JudoArena.Model.DB;
using JudoArena.Model;

namespace JudoArena.ViewModel
{

    class HomeVM : BindableBase
    {
        private readonly Navigation _navigation;

        ControlUser controlUser = new ControlUser();
        public string da { get; set; }
        public HomeVM()
        {
            _navigation = MainWindowVM.Navigation;
            

            switch (((int)((object[])_navigation.Data)[1]))
            {
                case 0:
                    da = ((Participant)((object[])_navigation.Data)[0]).Name;
                    break;
                case 1:
                    da = ((Trainer)((object[])_navigation.Data)[0]).Name;
                    break;

                case 2:
                    da = ((Judge)((object[])_navigation.Data)[0]).Name;
                    break;
            }
        }
    }
}
