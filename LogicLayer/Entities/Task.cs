using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Entities
{
    public class Task
    {
        public string Name { get; set; }
        public string Adapter { get; set; }
        public bool IsEnable { get; set; }
        public string DateWeekStart { get; set; }
        public string TimeStart { get; set; }
        public string DateChange { get; set; }
        public string WhoChange { get; set; }
    }
}
