using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using TodoAppXamarin.Models;
using TodoAppXamarin.ViewModels;
using Xamarin.CommunityToolkit.Markup;
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
