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
        static public List<TaskEntity> listTaskEntity = new List<TaskEntity>();
        static string _select = "All";

        public TaskController()
        {
            //this._taskRepository = new FakeTaskRepository();
            this._taskRepository = new SqlTaskRepository();
        }
        // GET: /Todo/
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Select = _select;
            ViewBag.listTaskEntity = listTaskEntity;
            return View();
        }

        [HttpPost]
        public ActionResult Get_Task( string select )
        {
            switch (select)
            {
                case "All":
                    listTaskEntity = _taskRepository.GetAll();
                break;

                case "Done":
                    listTaskEntity = _taskRepository.GetDone();
                break;

                case "Dont_Done":
                    listTaskEntity = _taskRepository.GetDontDone();
                break;

                default:
                    listTaskEntity = _taskRepository.GetAll();
                    break;
            }
            _select = select;
            return RedirectToAction("index");
        }



        [HttpPost]
        public ActionResult Index( string txt )
        {
            _select = "All";
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
            _select = "All";
            _taskRepository.Delete(taskId, taskTitle);
            ViewBag.ListTaskEntity = _taskRepository.GetAll();
            return RedirectToAction( "index" );
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            _select = "All";
            TaskEntity taskEntity = _taskRepository.SelectById(Id);
            TaskModel model = new TaskModel( taskEntity.Id, taskEntity.Title, taskEntity.IsDone, taskEntity.Priority );
            return View( model );
        }

        [HttpPost]
        public ActionResult Update( int id, string title, bool isDone, int priority )
        {
            _select = "All";
            _taskRepository.Update( id, title, isDone, priority );
            listTaskEntity = _taskRepository.GetAll();

            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Cancel()
        {
            _select = "All";
            return RedirectToAction( "index" );
        }

        [HttpPost]
        public ActionResult ChangeStatus(int taskId, bool isDone)
        {
            _select = "All";
            //throw new Exception();
            _taskRepository.ChangeStatus( taskId );
            return RedirectToAction("index");
        }


    }
}
