using FakeRepository;
using SqlRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Todo.Entity;
using Todo.WebUI.Models;

namespace Todo.WebUI.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        public TaskController()
        {
            //this._taskRepository = new FakeTaskRepository();
            this._taskRepository = new SqlTaskRepository();
        }
        // GET: /Todo/
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.listTaskEntity = _taskRepository.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Index( string txt )
        {
            ViewBag.Prevenction = " ";

            if (String.IsNullOrWhiteSpace(txt))
            {
                ViewBag.prevenction = "Is null";
            }
            else if (txt.Length > 50)
            {
                ViewBag.prevenction = "Bik task ( task > 50 signs )";
            }
            else
            {
                _taskRepository.Add(txt);
            }

            ViewBag.ListTaskEntity = _taskRepository.GetAll();

            return View();
        }

        [HttpPost]
        public ActionResult DeleteTask(int taskId, string taskTitle)
        {
            _taskRepository.Delete(taskId, taskTitle);
            ViewBag.ListTaskEntity = _taskRepository.GetAll();
            return RedirectToAction( "index" );
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            TaskEntity taskEntity = _taskRepository.SelectById(Id);
            TaskModel model = new TaskModel( taskEntity.Id, taskEntity.Title, taskEntity.IsDone );
            return View( model );
        }

        [HttpPost]
        public ActionResult Update( int id, string title, bool isDone )
        {
            _taskRepository.Update( id, title, isDone );
            ViewBag.ListTaskEntity = _taskRepository.GetAll();

            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Cancel()
        {
            return RedirectToAction( "index" );
        }

    }
}
