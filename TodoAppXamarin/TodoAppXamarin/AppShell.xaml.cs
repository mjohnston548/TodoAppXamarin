using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppXamarin.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoAppXamarin
{
    
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TodoDetailsPage), typeof(TodoDetailsPage));
        }
    }
}