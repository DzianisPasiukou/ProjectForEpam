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
        public DBSet<Task> Tasks { get; set; }
        public DBSet<Adapter> Adapters { get; set; }

        public DBEntities()
            : base("ProjectDB")
        {
            Users = new DBSet<User>(Connection, "Login", false);
            Groups = new DBSet<Group>(Connection, "Id_Group", true);
            Categories = new DBSet<Category>(Connection, "Id_Category", true);
            Notes = new DBSet<Note>(Connection, "Id_Note", true);
            Characteristics = new DBSet<Characteristic>(Connection, "Id_Characteristic", true);
            Files = new DBSet<File>(Connection, "Id_File", true);
            Group_Categories = new DBSet<Group_Category>(Connection, "Id", true);
            Group_Permissions = new DBSet<Group_Permission>(Connection, "Id", true);
            LikeFiles = new DBSet<LikeFile>(Connection, "Id", true);
            LikeNotes = new DBSet<LikeNote>(Connection, "Id", true);
            Messages = new DBSet<Message>(Connection, "Id_Message", true);
            Note_Characteristics = new DBSet<Note_Characteristic>(Connection, "Id", true);
            Note_Tags = new DBSet<Note_Tag>(Connection, "Id", true);
            Permission = new DBSet<Permission>(Connection, "Id_Permission", true);
            Tags = new DBSet<Tag>(Connection, "Id_Tag", true);
            User_Permissions = new DBSet<User_Permission>(Connection, "Id", true);
            Contacts = new DBSet<Contact>(Connection, "Id", true);
            Tasks = new DBSet<Task>(Connection, "Name", false);
            Adapters = new DBSet<Adapter>(Connection, "Name", false);
        }
    }
}
