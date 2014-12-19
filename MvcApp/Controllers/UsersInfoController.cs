using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogicLayer;
using LogicLayer.Entities;

namespace MvcApp.Controllers
{
    public class UsersInfoController : ApiController
    {

        IDataBaseManager<User> _dataUserInfo;
        IDataBaseManager<LikeFile> _dataFileInfo;
        IDataBaseManager<LikeNote> _dataNoteInfo;

        public UsersInfoController(IDataBaseManager<User> dataUserInfo, IDataBaseManager<LikeFile> dataFileInfo,
           IDataBaseManager<LikeNote> dataNoteInfo )
        {
            if (dataUserInfo == null)
            {
                throw new ArgumentNullException("UsersInfo");
            }
            _dataUserInfo = dataUserInfo;
            if (dataFileInfo == null)
            {
                throw new ArgumentNullException("LikeFileInfo");
            }
            _dataFileInfo = dataFileInfo;
            if (dataNoteInfo == null)
            {
                throw new ArgumentNullException("LikeNoteInfo");
            }
            _dataNoteInfo = dataNoteInfo;
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        
        // GET api/<controller>/5
        public User Get(int id)
        {
            return _dataUserInfo.GetBy("Id_User", id.ToString()).First();
        }
        public bool GetLikeEnable(int id, string noteOrFile)
        {
            string login = User.Identity.Name.ToString();
            bool find = false;

            LogicLayer.Entities.User currentUser = _dataUserInfo.GetBy("Login", login).First();
            if (noteOrFile == "note")
            {

                if (_dataNoteInfo.GetBy("Id_User", currentUser.Id_User.ToString()).Where(a => a.Id_Note == id).Count() > 0)
                {
                    find = true;
                }
            }
            else if (noteOrFile == "file")
            {
                if (_dataFileInfo.GetBy("Id_User", currentUser.Id_User.ToString()).Where(a => a.Id_File == id).Count() > 0)
                {
                    find = true;
                }
            }
            else
            {
                throw new ArgumentException("wrong description if likes");
            }
            return find;
  
        }
        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(string noteOrFile,int id)
        {
            string login = User.Identity.Name.ToString();
            int idUser = _dataUserInfo.GetBy("Login", login).First().Id_User;
            
            if (noteOrFile == "note")
            {
                _dataNoteInfo.Add(new LikeNote()
                    {
                        Id_Note = id,
                        Id_User = idUser
                    });
            }
            else if (noteOrFile == "file")
            {
                _dataFileInfo.Add(new LikeFile()
                {
                    Id_File = id,
                    Id_User = idUser
                });
            }
            else
            {
                throw new ArgumentException("wrong description if likes");
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}