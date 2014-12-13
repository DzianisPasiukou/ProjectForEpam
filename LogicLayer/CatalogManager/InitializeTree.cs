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

       private static List<TreeView> _tree = new List<TreeView>();
       private static object _lockObj = new object();

       private InitializeTree(DBEntities entity)
        {
            foreach (var cat in entity.Categories)
            {
                if (cat.Id_TopCategory == null)
                {
                    _tree.Add(new TreeView()
                        {
                            ID = cat.Id_Category,
                            NodeName = cat.Name,
                            NodeDescription = cat.Description,
                            ChildNode = new List<TreeView>()
                        });
                }
                else
                {
                    if (!InitChild(_tree, cat))
                    {
                        DoubleInit(cat, entity.Categories);
                    }
                }
            }
            foreach (var note in entity.Notes)
            {
                InitNote(_tree, note);
            }
        }
       private bool InitNote(List<TreeView> node, Note note)
       {
           bool isInit = false;

           for (int i = 0; i < node.Count; i++)
           {
               if (node[i].ID == note.Id_Category)
               {
                   node[i].IDNote = note.Id_Note;
                   break;
               }
               else
               {
                   isInit = InitNote(node[i].ChildNode, note);

                   if (isInit)
                   {
                       break;
                   }
               }
           }
               return isInit;
       }
       private bool InitChild(List<TreeView> childNode, Category cat)
       {
           bool isInit = false;

           for (int i = 0; i < childNode.Count; i++)
           {
               if (childNode[i].ID == cat.Id_TopCategory)
               {
                   childNode[i].ChildNode.Add(new TreeView()
                   {
                       ChildNode = new List<TreeView>(),
                       ID = cat.Id_Category,
                       NodeDescription = cat.Description,
                       NodeName = cat.Name
                   });

                   isInit = true;
                   break;
               }
               else
               {
                  isInit = InitChild(childNode[i].ChildNode, cat);

                   if (isInit)
                   {
                       break;
                   }
               }
           }
           return isInit;
       }
       private void DoubleInit(Category cat, IEnumerable<Category> categories)
       {
           bool error = false;
           Category newCat = null;

           try
           {
               newCat = categories.First(c => c.Id_Category == cat.Id_TopCategory);
           }
           catch
           {
               error = true;
           }

           if (!error)
           {
               if (!InitChild(_tree, newCat))
               {
                   DoubleInit(newCat, categories);
               }
           }
       }
     static public List<TreeView> InstanceTree(DBEntities entity, bool update)
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
