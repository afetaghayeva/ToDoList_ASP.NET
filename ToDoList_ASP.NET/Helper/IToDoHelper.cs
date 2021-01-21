using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList_ASP.NET.DataAccess.Entity;

namespace ToDoList_ASP.NET.Helper
{
    public interface IToDoHelper
    {
        void Set(string key, List<ToDo> toDos);
        List<ToDo> Get(string key);
        void Clear();
    }
}
