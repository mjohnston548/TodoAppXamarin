using System;
using System.Collections.Generic;
using System.Text;

namespace TodoAppXamarin.Models
{
    internal class TodoItem
    {
        

        public string TodoText { get; set; }
        public bool Complete { get; set; }

        public TodoItem(string todoText)
        {
            TodoText = todoText;
        }

        public TodoItem(string todoText, bool complete=false) 
        {
            TodoText= todoText;
            Complete = complete;
        }
    }
}
