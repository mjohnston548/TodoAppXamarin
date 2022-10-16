using TodoAppXamarin.ViewModels;
using Xamarin.Forms;

namespace TodoAppXamarin
{
    public partial class App : Application
    {
        public static TodoListViewModel sharedTodoListViewModel { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            sharedTodoListViewModel = new TodoListViewModel();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
