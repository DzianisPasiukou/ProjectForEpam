using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
    public class Role
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string PermissionTrafficOneFile { get; set; }

        public string PermissionTrafficAllFiles { get; set; }

        public string PermissionCategory { get; set; }

        public string PermissionContent { get; set; }

        public bool IsLoad { get; set; }

    }
}
