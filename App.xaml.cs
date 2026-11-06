using fushcasinaS5A.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace fushcasinaS5A
{
    public partial class App : Application
        
    {

        public static PersonRepository _personRepo { get; private set; }

        public App(PersonRepository repo)
        {
            InitializeComponent();
            _personRepo = repo;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views.vPersona());
        }
    }
}