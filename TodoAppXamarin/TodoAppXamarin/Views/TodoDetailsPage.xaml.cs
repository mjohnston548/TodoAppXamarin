using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppXamarin.Models;
using TodoAppXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoAppXamarin.Views
{
    
    public partial class TodoDetailsPage : ContentPage
    {
        

        
        public TodoDetailsPage()
        {
            InitializeComponent();
            BindingContext = new TodoDetailsViewModel();
        }

        
    }
}