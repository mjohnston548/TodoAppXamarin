using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TodoAppXamarin.Models;
using TodoAppXamarin.Views;
using Xamarin.Forms;
using Command = Xamarin.Forms.Command;

namespace TodoAppXamarin.ViewModels
{
    public class TodoListViewModel : INotifyPropertyChanged
    {


        public ObservableCollection<TodoItemGroup> GroupedTodolists { get; set; }



        public ObservableCollection<TodoItem> CompletedTodoItems { get; set; }




        public TodoListViewModel()
        {

            GroupedTodolists = new ObservableCollection<TodoItemGroup>();


            GroupedTodolists.Add(new TodoItemGroup(DateTime.Today, new ObservableCollection<TodoItem>()
            {
                new TodoItem("Walk the duggo", isImportant: false),
                new TodoItem("Do the washing", isImportant: false),

            }));

            GroupedTodolists.Add(new TodoItemGroup(new DateTime(2022, 10, 3), new ObservableCollection<TodoItem>()
            {
                new TodoItem("Brush off Cheeto dust",dueByDateTime: new DateTime(2022,10,3), false)
            }));






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

            }
        }


        void AddTodoItem()
        {
            //Will need to check if date is the same as a date group in the groupedTodoLists already.
            bool foundMatchingGroupName = false;
            for (int i = 0; i < GroupedTodolists.Count; i++)
            {
                if (DateTime.Equals(GroupedTodolists[i].DueDateGroupName, NewTodoDueByDateTime))
                {
                    GroupedTodolists[i].Add(new TodoItem(NewTodoInputValue, NewTodoDueByDateTime, isImportant: NewTodoImportantValue));
                    foundMatchingGroupName = true;
                    break;
                }

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
            TodoItem todoItemBeingRemoved = (TodoItem)o;

            foreach (TodoItemGroup todoGroup in GroupedTodolists)
            {
                todoGroup.Remove(todoItemBeingRemoved);
                //if (todoGroup.Count==0)
                //{
                //    GroupedTodolists.Remove(todoGroup);  //throws exception
                //}
            }
            //Header is left behind after deleting all items in a group

        }

        public ICommand CompleteTodoCommand => new Command(CompleteTodoItem);

        void CompleteTodoItem(object o)
        {
            TodoItem completedTodoItem = (TodoItem)o;

            Console.WriteLine(completedTodoItem.TodoText);
            //TodoListItems.Remove(completedTodoItem);
            bool todoGroupEmpty=false;
            int emptyTodoGroupIndex=0;
            foreach (TodoItemGroup todoGroup in GroupedTodolists)
            {
                todoGroup.Remove(completedTodoItem);
                if (todoGroup.Count==0)
                {
                    todoGroupEmpty = true;
                    emptyTodoGroupIndex=GroupedTodolists.IndexOf(todoGroup);
                }
            }

            if (todoGroupEmpty==true)
            {
                GroupedTodolists.RemoveAt(emptyTodoGroupIndex);
            }

            CompletedTodoItems.Add(completedTodoItem);
            Console.WriteLine(CompletedTodoItems.Count);
        }

        public ICommand GoToTaskDetailsCommand => new Command(GoToTaskDetails);

        async void GoToTaskDetails(object sender)
        {
            
            TodoItem specificTodoItem = sender as TodoItem;
            var jsonSpecificTodoString=JsonConvert.SerializeObject(specificTodoItem);

            string route = $"{nameof(TodoDetailsPage)}?Content={jsonSpecificTodoString}";
            await Shell.Current.GoToAsync(route);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
