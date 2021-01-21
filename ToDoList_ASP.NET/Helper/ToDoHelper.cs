using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ToDoList_ASP.NET.DataAccess.Entity;
using ToDoList_ASP.NET.Extension;

namespace ToDoList_ASP.NET.Helper
{
    public class ToDoHelper:IToDoHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ToDoHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Set(string key, List<ToDo> toDo)
        {
            _httpContextAccessor.HttpContext.Session.SetObject(key,toDo);
        }

        public List<ToDo> Get(string key)
        {
            var check = _httpContextAccessor.HttpContext.Session.GetObject<List<ToDo>>(key);
            if (check==null)
            {
                Set(key, new List<ToDo>());
                check= _httpContextAccessor.HttpContext.Session.GetObject<List<ToDo>>(key);
            }

            return check;
        }

        public void Clear()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }
    }
}
