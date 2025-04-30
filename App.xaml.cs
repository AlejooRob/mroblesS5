namespace mroblesS5
{
    public partial class App : Application
    {
        public static Repositories.PersonaRepository personaRepo { get; set; }
        public App(Repositories.PersonaRepository personaRepository)
        {
            personaRepo = personaRepository;
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views.vHome());
        }
    }
}