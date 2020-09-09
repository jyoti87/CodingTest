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
using SQLite;

namespace CodingTest
{
    public class User
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FieldOfExpertise { get; set; }
        public string Password { get; set; }
        public int Experience { get; set; }

        public override string ToString()
        {
            return Name +  " " + FieldOfExpertise + " " + Experience;
             
        }
    }

    public class ListHolder : Java.Lang.Object
    {
        public TextView Name { get; set; }
        public TextView FieldOfExpertise { get; set; }

        public TextView Experience { get; set; }
    }
}