﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.CatalogManager
{
   public interface ITree
    {
       List<TreeView> GetTree();
    }
}
