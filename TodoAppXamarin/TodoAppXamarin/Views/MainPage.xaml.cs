using System;
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

        private void testButton_Clicked(object sender, EventArgs e)
        {
            ListView listView = new ListView();

        }
    }
}
