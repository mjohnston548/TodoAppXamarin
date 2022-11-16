using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using TodoAppXamarin.Models;
using Xamarin.Forms;

namespace TodoAppXamarin.ViewModels
{
    [QueryProperty(nameof(Content),nameof(Content))]
    public class TodoDetailsViewModel : INotifyPropertyChanged
    {
        public TodoDetailsViewModel()
        {
        }

        private string content;

        public string Content
        {
            get { return content; }
            set 
            { 
                content = Uri.UnescapeDataString(value ?? string.Empty);
                OnPropertyChanged();
                PerformOperation(content);
            }
        }

        private void PerformOperation(string getcont)
        {
            var content=JsonConvert.DeserializeObject<TodoItem>(getcont);
            TodoText = content.TodoText;
        }


        private string todoText;

        public string TodoText
        {
            get { return todoText; }
            set 
            { 
                todoText = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
