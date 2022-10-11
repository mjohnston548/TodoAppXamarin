
using MvvmHelpers.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TodoAppXamarin.Models;
using Xamarin.CommunityToolkit.ObjectModel;



namespace TodoAppXamarin.ViewModels
{
    public class TodoListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TodoItem> TodoListItems { get; set; }

        public ObservableCollection<TodoItemGroup> GroupedTodolists { get; set; }



        public ObservableCollection<TodoItem> CompletedTodoItems { get; set; }




        public TodoListViewModel()
        {

            GroupedTodolists = new ObservableCollection<TodoItemGroup>();
            TodoListItems = new ObservableRangeCollection<TodoItem>();

            GroupedTodolists.Add(new TodoItemGroup(DateTime.Today, new ObservableCollection<TodoItem>()
            {
                new TodoItem("Walk the duggo", dueByDateTime: new DateTime(2022, 12, 3), false ),
                new TodoItem("Do the washing",dueByDateTime: new DateTime(2022, 11, 3), false),

            }));

            GroupedTodolists.Add(new TodoItemGroup(new DateTime(2022, 10, 3), new ObservableCollection<TodoItem>()
            {
                new TodoItem("Brush off Cheeto dust",dueByDateTime: new DateTime(2022,10,3), false)
            }));

            //TodoListItems.Add(new TodoItem("Walk the duggo", dueByDateTime: new DateTime(2022, 12, 3), false));
            //TodoListItems.Add(new TodoItem("Do the washing",dueByDateTime: new DateTime(2022, 11, 3), false));
            //TodoListItems.Add(new TodoItem("Brush off Cheeto dust",dueByDateTime: new DateTime(2022,10,3), false));




            CompletedTodoItems = new ObservableCollection<TodoItem>();


        }
        public ICommand AddTodoCommand => new Command(AddTodoItem);
        public string NewTodoInputValue { get; set; }

        public bool NewTodoImportantValue { get; set; }

        private DateTime newTodoDueByDateTime = DateTime.Today;
        public DateTime NewTodoDueByDateTime
        {
            get { return newTodoDueByDateTime; }
            set
            {
                newTodoDueByDateTime = value;
                //OnPropertyChanged();  /should read about WHEN this is neccasary
            }
        }


        void AddTodoItem()
        {
            //Will need to check if date is the same as a date group in the groupedTodoLists already.
            bool foundMatchingGroupName = false;
            for (int i = 0; i < GroupedTodolists.Count; i++)
            {
                Console.WriteLine(GroupedTodolists[i].DueDateGroupName);

                if (DateTime.Equals(GroupedTodolists[i].DueDateGroupName, NewTodoDueByDateTime))
                {
                    GroupedTodolists[i].Add(new TodoItem(NewTodoInputValue, NewTodoDueByDateTime, isImportant: NewTodoImportantValue));
                    foundMatchingGroupName = true;
                    break;
                }
                Console.WriteLine(DateTime.Equals(GroupedTodolists[i].DueDateGroupName, NewTodoDueByDateTime));
            }


            if (foundMatchingGroupName == false)
            {
                GroupedTodolists.Add(new TodoItemGroup(NewTodoDueByDateTime, new ObservableCollection<TodoItem>
                {
                new TodoItem(NewTodoInputValue,NewTodoDueByDateTime,isImportant: NewTodoImportantValue)
                }));

            }




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

        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
