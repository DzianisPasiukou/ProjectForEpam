using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Entities
{
    public class Role
    {
        public string RoleName { get; set; }

        public string PermissionTrafficOneFile { get; set; }

        public string PermissionTrafficAllFiles { get; set; }

        public string PermissionCategory { get; set; }

        public string PermissionContent { get; set; }

        public bool IsLoad { get; set; }

    }
}
