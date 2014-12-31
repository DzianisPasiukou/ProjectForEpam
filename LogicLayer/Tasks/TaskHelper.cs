using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogicLayer.Entities;

namespace LogicLayer.Tasks
{
    public class TaskHelper : ITaskHelper
    {
        public IEnumerable<Entities.Task> GetTasks()
        {
            using (DBEntities db = new DBEntities())
            {
                return db.Tasks.ToList();
            }
        }

        public bool updateTaskEnable(string task, bool isEnable, string whoChange)
        {
            using (DBEntities db = new DBEntities())
            {
                Task getTask = db.Tasks.First(model => model.Name.Equals(task));
                getTask.IsEnable = isEnable;
                getTask.DateChange = DateTime.Now.ToString();
                getTask.WhoChange = whoChange;
                bool flag = db.Tasks.Update(getTask);
                return flag;
            }
        }
    }
}
