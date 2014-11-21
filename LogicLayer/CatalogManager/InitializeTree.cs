using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Entities;

namespace LogicLayer.CatalogManager
{
   public class InitializeTree
    {
       private static InitializeTree _init;

       private static TreeView _tree = new TreeView();
       private static object _lockObj = new object();

       private InitializeTree(DBEntities entity)
        {
            _tree.NodeName = "Catalogs";
            _tree.ChildNode = new List<TreeView>();
                IEnumerator<Catalog> cats = entity.Catalog.GetEnumerator();

                for (int i = 0; cats.MoveNext(); i++)
                {
                    _tree.ChildNode.Add(new TreeView()
                    {
                        NodeName = cats.Current.Name,
                        ChildNode = new List<TreeView>()
                    });

                    IEnumerable<Theme> currentThemes = entity.Theme.Where(t => t.CatalogID == entity.Catalog.GetEnumerator().Current.Name);
                    IEnumerator<Theme> thms = currentThemes.GetEnumerator();

                    for (int j = 0; thms.MoveNext(); j++)
                    {
                        _tree.ChildNode[i].ChildNode.Add(new TreeView()
                        {
                            NodeName = currentThemes.ElementAt(j).Name,
                            ChildNode = new List<TreeView>()
                        });
                        IEnumerable<Record> currentRecords = entity.Record.Where(r => r.ThemeID == currentThemes.ElementAt(j).Name);
                        IEnumerator<Record> rc = currentRecords.GetEnumerator();

                        for (int k = 0; rc.MoveNext(); k++)
                        {
                            _tree.ChildNode[i].ChildNode[j].ChildNode.Add(new TreeView()
                            {
                                NodeName = currentRecords.ElementAt(k).Name,
                                ChildNode = new List<TreeView>()
                            });
                        }
                    }
                }
        }

     static public TreeView InstanceTree(DBEntities entity, bool update)
       {
         if (_init == null)
         {
             lock (_lockObj)
             {
                 if (_init == null)
                 {
                     _init = new InitializeTree(entity);
                 }
             }
         }
         if (update)
         {
             lock(_lockObj)
             {
                 _init = new InitializeTree(entity);
             }
         }

         return _tree;
       }
    }
}
