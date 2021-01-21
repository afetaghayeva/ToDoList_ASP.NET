using System.Collections.Generic;
using ToDoList_ASP.NET.DataAccess.Entity;

namespace ToDoList_ASP.NET.Models
{
    public class ToDoListViewModel
    {
        public List<ToDo> ToDos { get; set; }
        public ToDo ToDo { get; set; }
        public string Key { get; set; }
    }
}
