using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ToDoList_ASP.NET.DataAccess.Entity;
using ToDoList_ASP.NET.Helper;
using ToDoList_ASP.NET.Models;

namespace ToDoList_ASP.NET.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoHelper _toDoHelper;

        public ToDoController(IToDoHelper toDoHelper)
        {
            _toDoHelper = toDoHelper;
        }

        public IActionResult Index(string key)
        {
           var toDos= _toDoHelper.Get("toDo");
           if (key!=null)
           {
               toDos = toDos.Where(t => t.Title.ToLower().Contains(key.ToLower())).ToList();
           }
           
           var model = new ToDoListViewModel()
           {
               ToDos = toDos
           };
           return View(model);
        }

        public IActionResult Add(ToDo toDo)
        {
            var toDos = _toDoHelper.Get("toDo");
            toDo.Id = toDos.Count + 1;
            if (String.IsNullOrEmpty(toDo.Title))
            {
                TempData.Add("message", "Please,write todo");
                TempData.Add("className","danger");
            }
            else if (toDos.Any(t=>t.Title==toDo.Title))
            {
                TempData.Add("message", "Please, write different todo");
                TempData.Add("className", "danger");
            }
            else
            {
                toDos.Add(toDo);
                _toDoHelper.Set("toDo", toDos);
                TempData.Add("message", toDo.Title + " added");
                TempData.Add("className", "success");
            }
            return RedirectToAction("Index", "ToDo");
        }

        public IActionResult Delete(int id)
        {
            var toDos = _toDoHelper.Get("toDo");
            var toDo=toDos.FirstOrDefault(t => t.Id == id);
            toDos.Remove(toDo);
            _toDoHelper.Set("toDo",toDos);
            if (toDo != null) TempData.Add("message", toDo.Title + " deleted");
            TempData.Add("className", "success");
            return RedirectToAction("Index", "ToDo");
        }

        public IActionResult Clear()
        {
            var toDos = _toDoHelper.Get("toDo");
            toDos.Clear();
            _toDoHelper.Set("toDo", toDos);
            return RedirectToAction("Index", "ToDo");
        }

    }
}
