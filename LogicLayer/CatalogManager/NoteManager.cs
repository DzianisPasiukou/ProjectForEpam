using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Entities;

namespace LogicLayer.CatalogManager.ThemeManager.RecordManager
{
   public class NoteManager : IDataBaseManager<Note>, INoteCompare
    {
        public IEnumerable<Note> Get()
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Notes;
            }
        }

        public bool Add(Note t)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Notes.Add(t);
            }
        }

        public bool Update(Note t)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Notes.Update(t);
                
            }
        }

        public bool Delete(Note t)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Notes.Delete(t);                 
            }
        }


        public IEnumerable<Note> GetBy(string nameParametr, string param)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Notes.GetBy(String.Format("{0} = {1}", nameParametr,param));
            }
        }
        public IEnumerable<Note> GetNote(string param1, string param2)
        {
            using (DBEntities entity = new DBEntities())
            {
                IEnumerable<Note> records = entity.Notes;
                List<Note> current = new List<Note>()
            {
                records.First(rc=>rc.Id_Note == int.Parse(param1)),
                records.First(rc=>rc.Id_Note == int.Parse(param2)),
            };

                return current;
            }
        }
    }
}
