using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Entities
{
    public class Record
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string ThemeID { get; set; }
    }
}
