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
                _tree.NameNode = "Catalogs";

                for (int i = 0; entity.Catalog.GetEnumerator().MoveNext(); i++)
                {
                    _tree.Tree.Add(new TreeView()
                    {
                        NameNode = entity.Catalog.GetEnumerator().Current.Name,
                        Tree = new List<TreeView>()
                    });

                    IEnumerable<Theme> currentThemes = entity.Theme.Where(t => t.NameCatalog == entity.Catalog.GetEnumerator().Current.Name);

                    for (int j = 0;currentThemes.GetEnumerator().MoveNext(); j++)
                    {
                        _tree.Tree[i].Tree.Add(new TreeView()
                        {
                            NameNode = currentThemes.ElementAt(j).Name,
                            Tree = new List<TreeView>()
                        });
                        IEnumerable<Record> currentRecords = entity.Record.Where(r => r.NameTheme == currentThemes.ElementAt(j).Name);
                        for (int k = 0; currentRecords.GetEnumerator().MoveNext(); k++)
                        {
                            _tree.Tree[i].Tree[j].Tree.Add(new TreeView()
                            {
                                NameNode = currentRecords.ElementAt(k).Name
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
