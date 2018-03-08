using System;
namespace TodoMVC.Models
{
    public class TodoItem
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool Complete { get; set; }

        public TodoItem()
        {
        }
    }
}
