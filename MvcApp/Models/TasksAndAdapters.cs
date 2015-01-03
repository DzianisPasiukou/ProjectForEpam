using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.Models
{
    public class TasksAndAdapters
    {
        public IEnumerable<Task> Tasks { get; set; }

        public IEnumerable<Adapter> Adapters { get; set; }
    }
}