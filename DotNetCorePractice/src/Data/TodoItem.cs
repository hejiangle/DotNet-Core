using System;

namespace DotNetCorePractice.Data
{
    public class TodoItem
    {
        public TodoItem()
        {

        }
        
        public TodoItem(int id, string content, bool isDone, DateTime timeSpan)
        {
            this.Id = id;
            this.Content = content;
            this.IsDone = false;
            this.TimeSpan = new DateTime();
        }

        public int Id { get; }

        public string Content { get; set;}

        public bool IsDone { get; set; }

        public DateTime TimeSpan { get; set; }
    }
}