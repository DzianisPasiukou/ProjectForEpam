using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Entities
{
    public class Note
    {
        public int Id_Note { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id_Category { get; set; }
        public string AvatarPath { get; set; }
        public string Status { get; set; }
        public int Id_User { get; set; }
    }
}
