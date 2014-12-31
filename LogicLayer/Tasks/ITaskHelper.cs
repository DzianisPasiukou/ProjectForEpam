using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicLayer.Tasks
{
    public interface ITaskHelper
    {
        IEnumerable<Task> GetTasks();
        bool updateTaskEnable(string task, bool isEnable, string whoChange);
    }
}
