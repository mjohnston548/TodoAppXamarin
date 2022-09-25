using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void Button_Clicked(object sender, EventArgs e)
        {
            TodoListViewModel model = ViewModel;
            model.TodoListItems.Add(new TodoItem("Play warcraft"));
        }
    }
}
