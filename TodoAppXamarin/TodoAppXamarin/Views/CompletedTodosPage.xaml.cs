using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoAppXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompletedTodosPage : ContentPage
    {
        public CompletedTodosPage()
        {
            InitializeComponent();
            this.BindingContext = App.sharedTodoListViewModel;
            
        }
    }
}