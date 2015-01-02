using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.Models
{
    public class UsersAndGroups
    {
        public IEnumerable<User> users { get; set; }

        public IEnumerable<Group> groups { get; set; }
    }
}