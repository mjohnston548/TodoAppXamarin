using Plugin.InputKit.Shared.Controls;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using TodoAppXamarin.Models;
using Xamarin.Forms;


namespace TodoAppXamarin.ViewModels
{
    public class TodoListViewModel
    {
        public ObservableCollection<TodoItem> TodoListItems { get; set; }

        public ObservableCollection<TodoItem> CompletedTodoItems { get; set; }




        public TodoListViewModel()
        {
            TodoListItems = new ObservableCollection<TodoItem>();
            TodoListItems.Add(new TodoItem("Walk the duggo", false));
            TodoListItems.Add(new TodoItem("Do the washing", false));
            TodoListItems.Add(new TodoItem("Brush off Cheeto dust", false));
            TodoListItems.Add(new TodoItem("Play basketball", false, true));


            CompletedTodoItems = new ObservableCollection<TodoItem>();


        }
        public ICommand AddTodoCommand => new Command(AddTodoItem);
        public string NewTodoInputValue { get; set; }

        public bool NewTodoImportantValue { get; set; }

        public DateTime? NewTodoDueByDateTime { get; set; }

        void AddTodoItem()
        {
            TodoListItems.Add(new TodoItem(NewTodoInputValue, NewTodoDueByDateTime, isImportant: NewTodoImportantValue));
            
        }

        public ICommand RemoveTodoCommand => new Command(RemoveTodoItem);

        void RemoveTodoItem(object o)
        {
            TodoItem todoItemBeingRemoved = o as TodoItem;
            TodoListItems.Remove(todoItemBeingRemoved);
        }

        public ICommand CompleteTodoCommand => new Command(CompleteTodoItem);

        void CompleteTodoItem(object o)
        {
            TodoItem completedTodoItem = (TodoItem)o;

            Console.WriteLine(completedTodoItem.TodoText);
            TodoListItems.Remove(completedTodoItem);

            CompletedTodoItems.Add(completedTodoItem as TodoItem);
            Console.WriteLine(CompletedTodoItems.Contains(completedTodoItem));
        }



    }
}
