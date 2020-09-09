using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
namespace CodingTest
{
    public class DBRepository
    {
        public void CreateDatabase()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath
                (System.Environment.SpecialFolder.Personal), "database.db3");
            var db = new SQLiteConnection(dbPath);
        }

        public void CreateTable()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath
               (System.Environment.SpecialFolder.Personal), "database.db3");
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<User>();
        }

        public void InsertUser(User user)
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath
               (System.Environment.SpecialFolder.Personal), "database.db3");
            var db = new SQLiteConnection(dbPath);
            User userData = new User();
            userData.Name = user.Name;
            userData.FieldOfExpertise = user.FieldOfExpertise;
            userData.Experience = user.Experience;
            userData.Password = user.Password;
            db.Insert(userData);
            
        }

        public bool CheckIfUserExist(User user)
        {
            var usersList = GetUserData();
            var item = usersList.FirstOrDefault(x => x.Name == user.Name);
            if (item != null)
            {
                if (item.Password == user.Password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;

        }


        public List<User> GetUserData()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath
               (System.Environment.SpecialFolder.Personal), "database.db3");
            var db = new SQLiteConnection(dbPath);
            List<User> userdatalist = new List<User>();
            var usertable = db.Table<User>();
            foreach (var item in usertable)
            {
                User userdata = new User();
                userdata.Name = item.Name;
                userdata.FieldOfExpertise = item.FieldOfExpertise;
                userdata.Experience = item.Experience;
                userdatalist.Add(userdata);
            }
            return userdatalist;
        }
    }
}