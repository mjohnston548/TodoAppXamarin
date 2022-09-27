using System.Collections.ObjectModel;
using TodoAppXamarin.Models;
using TodoAppXamarin.ViewModels;
using Xamarin.Forms;

namespace TodoAppXamarin
{
    public partial class MainPage : ContentPage
    {
        TodoListViewModel ViewModel { get; set; }
        public MainPage()
        {
            InitializeComponent();
            this.ViewModel = new TodoListViewModel();
            
        }


    }
}
