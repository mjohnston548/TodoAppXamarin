namespace TodoAppXamarin.Models
{
    public class TodoItem
    {


        public string TodoText { get; set; }
        public bool Complete { get; set; }



        public TodoItem(string todoText, bool complete)
        {
            this.TodoText = todoText;
            this.Complete = complete;
        }
    }
}
