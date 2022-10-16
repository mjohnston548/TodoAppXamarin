using System;
using TodoAppXamarin.ViewModels;
using Xamarin.Forms;

namespace TodoAppXamarin
{
    public partial class MainPage : ContentPage
    {
        public TodoListViewModel ViewModel { get; set; }
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = App.sharedTodoListViewModel;

        }

        
    }
}
