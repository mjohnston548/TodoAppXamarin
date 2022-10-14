using System;
using System.Collections.ObjectModel;

namespace TodoAppXamarin.Models
{
    public class TodoItemGroup : ObservableCollection<TodoItem>
    {


        public DateTime? DueDateGroupName { get; set; } =new DateTime(1066,1,1);

        public TodoItemGroup(DateTime? dueDateGroupName, ObservableCollection<TodoItem> todoItems) : base(todoItems)
        {
            this.DueDateGroupName = dueDateGroupName;
        }

        
    }
}
