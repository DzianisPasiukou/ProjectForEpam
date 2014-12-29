using LogicLayer;
using LogicLayer.CatalogManager;
using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MvcApp.Controllers
{
    public class NoteInfoController : ApiController
    {
        IDataBaseManager<File> _dataFile;
        IDataBaseManager<Note_Characteristic> _dataNoteCharacter;
        IDataBaseManager<Characteristic> _dataCharacter;

        public NoteInfoController(IDataBaseManager<File> dataFile, IDataBaseManager<Note_Characteristic> dataNoteCharacter,
            IDataBaseManager<Characteristic> dataCharacter)
        {
            if (dataFile == null)
            {
                throw new ArgumentNullException("dataFile");
            }
            _dataFile = dataFile;
            if (dataNoteCharacter == null)
            {
                throw new ArgumentNullException("dataNoteCharacter");
            }
            _dataNoteCharacter = dataNoteCharacter;
            if (dataCharacter == null)
            {
                throw new ArgumentNullException("dataCharacter");
            }
            _dataCharacter = dataCharacter;
        }
        public NoteInfoHelper GetNoteInfo(int id)
        {
            IEnumerable<File> files = _dataFile.GetBy("Id_Note", id.ToString()).Where(f => f.Status == "Принято");
            IEnumerable<Note_Characteristic> characteristicsOfNote = _dataNoteCharacter.GetBy("Id_Note", id.ToString());
            List<Characteristic> characteristics = new List<Characteristic>();

            foreach (var ch in characteristicsOfNote)
            {
               characteristics.Add(_dataCharacter.GetBy("Id_Characteristic", ch.Id_Characteristic.ToString()).First()); 
            }
            NoteInfoHelper helper = new NoteInfoHelper()
            {
                Characteristics = characteristics,
                CharacteristicsOfNote = characteristicsOfNote,
                Files = files
            };
            return helper;
        }
    }
}