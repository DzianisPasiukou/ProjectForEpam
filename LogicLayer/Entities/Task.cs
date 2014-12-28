using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Entities
{
    public class Task
    {
        public int Id_Task { get; set; }
        public string Name { get; set; }
        public string Adapter { get; set; }
        public bool Enable { get; set; }
        public string DateChange { get; set; }
        public string WhoChange { get; set; }
    }
}
