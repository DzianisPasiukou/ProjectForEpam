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
        public User Get(string login)
        {
            return _dataUserInfo.GetBy("Login", login.ToString()).First();
        }
        public object GetLikeEnable(int id, string noteOrFile)
        {
            string login = User.Identity.Name.ToString();
            
            if (noteOrFile == "note")
            {
                if (_dataNoteInfo.GetBy("Login", login).Where(a => a.Id_Note == id).Count() > 0)
                {
                    return _dataNoteInfo.GetBy("Login", login).Where(a => a.Id_Note == id).First();
                }
            }
            else if (noteOrFile == "file")
            {
                if (_dataFileInfo.GetBy("Login", login).Where(a => a.Id_File == id).Count() > 0)
                {
                    return _dataFileInfo.GetBy("Login", login).Where(a => a.Id_File == id).First();
                }
            }
            else
            {
                throw new ArgumentException("wrong description if likes");
            }
            return Ok();
  
        }
        public void Put(string noteOrFile,int id)
        {
            string login = User.Identity.Name.ToString();
            
            if (noteOrFile == "note")
            {
                _dataNoteInfo.Add(new LikeNote()
                    {
                        Id_Note = id,
                        Login = login
                    });
            }
            else if (noteOrFile == "file")
            {
                _dataFileInfo.Add(new LikeFile()
                {
                    Id_File = id,
                    Login = login
                });
            }
            else
            {
                throw new ArgumentException("wrong description if likes");
            }
        }
    }
}