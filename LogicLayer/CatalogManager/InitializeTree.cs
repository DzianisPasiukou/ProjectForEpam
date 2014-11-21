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

       private static TreeView _tree;
       private static object _lockObj = new object();

       private InitializeTree(DBEntities entity)
        {
                _tree.roleName = "Catalogs";

                for (int i = 0; entity.Catalog.GetEnumerator().MoveNext(); i++)
                {
                    _tree.children.Add(new TreeView()
                    {
                        roleName = entity.Catalog.GetEnumerator().Current.Name,
                        children = new List<TreeView>()
                    });

                    IEnumerable<Theme> currentThemes = entity.Theme.Where(t => t.NameCatalog == entity.Catalog.GetEnumerator().Current.Name);

                    for (int j = 0;currentThemes.GetEnumerator().MoveNext(); j++)
                    {
                        _tree.children[i].children.Add(new TreeView()
                        {
                            roleName = currentThemes.ElementAt(j).Name,
                            children = new List<TreeView>()
                        });
                        IEnumerable<Record> currentRecords = entity.Record.Where(r => r.NameTheme == currentThemes.ElementAt(j).Name);
                        for (int k = 0; currentRecords.GetEnumerator().MoveNext(); k++)
                        {
                            _tree.children[i].children[j].children.Add(new TreeView()
                            {
                                roleName = currentRecords.ElementAt(k).Name
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
