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
        public double Weight { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double Height { get; set; }
        public double Power { get; set; }
        public int UserID { get; set; }
        public string Description { get; set; }
        public int ThemeID { get; set; }
        public int ComparerID { get; set; }
       
    }
}
