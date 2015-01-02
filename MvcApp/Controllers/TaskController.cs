using LogicLayer.Entities;
using LogicLayer.Tasks;
using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApp.Controllers
{
    public class TaskController : ApiController
    {
        private ITaskHelper _taskHelper;

        public TaskController(ITaskHelper taskHelper)
        {
            if (taskHelper == null)
            {
                throw new ArgumentNullException();
            }

            _taskHelper = taskHelper;
        }

        public TasksAndAdapters Get()
        {
            TasksAndAdapters tasksAndAdapters = new TasksAndAdapters();
            tasksAndAdapters.Tasks = _taskHelper.GetTasks().ToList();
            tasksAndAdapters.Adapters = _taskHelper.GetAdapters().ToList();
            return tasksAndAdapters;
        }
  
        public void Put(string task, bool isEnable, string whoChange)
        {
            _taskHelper.updateTaskEnable(task, isEnable, whoChange);
        }
    }
}
