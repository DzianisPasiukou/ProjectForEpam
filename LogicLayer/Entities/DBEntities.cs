using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLayer;
using LogicLayer.Entities;

namespace LogicLayer.Entities
{
    public class DBEntities : DbContext
    {
        public DBSet<User> Users { get; set; }
        public DBSet<Group> Groups { get; set; }
        public DBSet<Category> Categories { get; set; }
        public DBSet<Note> Notes { get; set; }
        public DBSet<Characteristic> Characteristics { get; set; }
        public DBSet<File> Files { get; set; }
        public DBSet<Group_Category> Group_Categories { get; set; }
        public DBSet<Group_Permission> Group_Permissions { get; set; }
        public DBSet<LikeFile> LikeFiles { get; set; }
        public DBSet<LikeNote> LikeNotes { get; set; }
        public DBSet<Message> Messages { get; set; }
        public DBSet<Note_Characteristic> Note_Characteristics { get; set; }
        public DBSet<Note_Tag> Note_Tags { get; set; }
        public DBSet<Permission> Permission { get; set; }
        public DBSet<Tag> Tags { get; set; }
        public DBSet<User_Permission> User_Permissions { get; set; }
        public DBSet<Contact> Contacts { get; set; }

        public DBEntities()
            : base()
        {
            Users = new DBSet<User>(connection, "Login");
            Groups = new DBSet<Group>(connection, "Id_Group");
            Categories = new DBSet<Category>(connection, "Id_Category");
            Notes = new DBSet<Note>(connection, "Id_Note");
            Characteristics = new DBSet<Characteristic>(connection, "Id_Characteristic");
            Files = new DBSet<File>(connection, "Id_File");
            Group_Categories = new DBSet<Group_Category>(connection, "Id");
            Group_Permissions = new DBSet<Group_Permission>(connection, "Id");
            LikeFiles = new DBSet<LikeFile>(connection, "Id");
            LikeNotes = new DBSet<LikeNote>(connection, "Id");
            Messages = new DBSet<Message>(connection, "Id_Message");
            Note_Characteristics = new DBSet<Note_Characteristic>(connection, "Id");
            Note_Tags = new DBSet<Note_Tag>(connection, "Id");
            Permission = new DBSet<Permission>(connection, "Id_Permission");
            Tags = new DBSet<Tag>(connection, "Id_Tag");
            User_Permissions = new DBSet<User_Permission>(connection, "Id");
            Contacts = new DBSet<Contact>(connection, "Login");
        }
    }
}
