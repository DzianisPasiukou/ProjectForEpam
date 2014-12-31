using LogicLayer.Entities;
using LogicLayer.Tasks;
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

        public IEnumerable<Task> Get()
        {
            List<Task> tasks = _taskHelper.GetTasks().ToList();
            return tasks;
        }

        
        public void Put(string task, bool isEnable, string whoChange)
        {
            _taskHelper.updateTaskEnable(task, isEnable, whoChange);
        }
    }
}
