using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CodingTest
{
   public static class UserData
    {
        public static List<User> Users { get; private set; }

        static UserData()
        {
            var temp = new List<User>();

            AddUser(temp);

            Users = temp.OrderBy(i => i.Name).ToList();
        }

        private static void AddUser(List<User> users)
        {
            users.Add(new User()
            {
                Name = "John Atlanta",
                FieldOfExpertise = " Computer Science",
               Experience = 10,
                Password = "kjgkjgkhb"
            });
            //users.Add(new User()
            //{
            //    Name = "Donark Brooklyn",
            //    FieldOfExpertise = " Information Science",
            //    Experience = 20,
            //    Password = "oiuytrr"
            //});
            //users.Add(new User()
            //{
            //    Name = "Edie Charolette",
            //    FieldOfExpertise = " Environmental Science",
            //    Experience = 30,
            //    Password = "popiou"
            //});
            //users.Add(new User()
            //{
            //    Name = "John doe",
            //    FieldOfExpertise = " Electronics ",
            //    Experience = 9,
            //    Password = "khki"
            //});
            //users.Add(new User()
            //{
            //    Name = "John clay",
            //    FieldOfExpertise = " Science",
            //    Experience = 6,
            //    Password = "oooopkm"
            //});
        }
    }
}