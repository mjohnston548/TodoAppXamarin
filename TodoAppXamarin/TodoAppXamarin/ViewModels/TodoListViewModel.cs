using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using TodoAppXamarin.Models;
using Xamarin.Forms;

namespace TodoAppXamarin.ViewModels
{
    internal class TodoListViewModel
    {
		private ObservableCollection<TodoItem> todoListItems;

		
		public ObservableCollection<TodoItem> TodoListItems
		{
			get { return todoListItems; }
			set { todoListItems = value; }
		}

        public TodoListViewModel()
        {
			todoListItems = new ObservableCollection<TodoItem>();
			TodoListItems.Add(new TodoItem("Walk the duggo",true));
			TodoListItems.Add(new TodoItem("Do the washing",false));
			TodoListItems.Add(new TodoItem("Brush off Cheeto dust",false));
        }
		public ICommand AddTodoCommand => new Command(AddTodoItem);
		public string NewTodoInputValue { get; set; }
		void AddTodoItem() 
		{
			TodoListItems.Add(new TodoItem(NewTodoInputValue));
		}

		public ICommand RemoveTodoCommand => new Command(RemoveTodoItem);
        
        void RemoveTodoItem(object o)
        {
			TodoItem todoItemBeingRemoved = o as TodoItem;
			TodoListItems.Remove(todoItemBeingRemoved);
        }

    }
}
