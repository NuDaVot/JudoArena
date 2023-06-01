namespace JudoArena.ViewModel
{
    class SignInVM : BindableBase
    {

        public DelegateCommand GoSignUp { get; set; }

        public SignInVM()
        {
            GoSignUp = new( () =>
            {
                MessageBox.Show("dadadada");
                Navigation.CurrentView = new SignUpVM();
                //Navigation.RaisePropertiesChanged("CurrentView");
            });
        }
    }
}
