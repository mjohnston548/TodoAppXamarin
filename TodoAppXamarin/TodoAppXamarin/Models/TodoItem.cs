using System;

namespace TodoAppXamarin.Models
{
    public class TodoItem 
    {
        public TodoItem(string todoText, bool complete=false, bool isImportant=false) :base()
        {
            TodoText = todoText;
            Complete = complete;
            IsImportant = isImportant;
        }


        public string TodoText { get; set; }
        public bool Complete { get; set; }

        public bool IsImportant { get; set; }

        public DateTime? DueByDateTime { get; set; }


        public bool IsDeleted { get; set; } = false;

        public TodoItem(string todoText, bool complete)
        {
            this.TodoText = todoText;
            this.Complete = complete;
        }

        

        public TodoItem(string todoText, DateTime? dueByDateTime, bool complete = false, bool isImportant = false) : this(todoText, complete, isImportant)
        {
            this.DueByDateTime = dueByDateTime;
        }
        
        public TodoItem()
        {
        }
    }
}
