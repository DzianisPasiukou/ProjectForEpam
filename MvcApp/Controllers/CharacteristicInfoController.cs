using LogicLayer;
using LogicLayer.CatalogManager;
using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApp.Controllers
{
    public class CharacteristicInfoController : ApiController
    {
        IDataBaseManager<Note_Characteristic> _dataNoteCharacter;
        IDataBaseManager<Characteristic> _dataCharacter;
        public CharacteristicInfoController(IDataBaseManager<Note_Characteristic> dataNoteCharacter,
            IDataBaseManager<Characteristic> dataCharacter)
        {

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
        public CharacteristicHelper GetCharacteristic()
        {
            IEnumerable<Characteristic> characteristics = _dataCharacter.Get();
            IEnumerable<Note_Characteristic> characteristicsOfNote = _dataNoteCharacter.Get();

            CharacteristicHelper helper = new CharacteristicHelper()
            {
                Characteristics = characteristics,
                CharacteristicsOfNote = characteristicsOfNote
            };
            return helper;
        }
        public CharacteristicHelper GetCharacteristic(int id)
        {
            IEnumerable<Note_Characteristic> characteristicsOfNote = _dataNoteCharacter.GetBy("Id_Note", id.ToString());
            IEnumerable<Characteristic> characteristics = _dataCharacter.Get().Join(characteristicsOfNote, f => f.Id_Characteristic,
                f => f.Id_Characteristic, (f1, f2) => f1);

            CharacteristicHelper helper = new CharacteristicHelper()
            {
                Characteristics = characteristics,
                CharacteristicsOfNote = characteristicsOfNote
            };
            return helper;
        }
        public void PutCharacteristic(string name, string value, int IdNote)
        {
            Characteristic character;
            try
            {
                character = _dataCharacter.GetBy("Name", name.ToString()).First();
            }
            catch (InvalidOperationException)
            {
                _dataCharacter.Add(new Characteristic()
                {
                    Name = name
                });

                character = _dataCharacter.GetBy("Name", name.ToString()).First();
            }

            _dataNoteCharacter.Add(new Note_Characteristic()
                {
                    Id_Characteristic = character.Id_Characteristic,
                    Id_Note = IdNote,
                    Value = value
                });
        }

    }
}