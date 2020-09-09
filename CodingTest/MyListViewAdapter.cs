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
    public class MyListViewAdapter : BaseAdapter<User>
    {
        List<User> users;

        public MyListViewAdapter(List<User> userslist)
        {
            this.users = userslist;
        }
        public override User this[int position]
        {
            get
            {
                return users[position];
            }
        }

        public override int Count
        {
            get
            {
                return users.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ListRow, parent, false);

                var name = view.FindViewById<TextView>(Resource.Id.nameTextView);
                var expertise = view.FindViewById<TextView>(Resource.Id.departmentTextView);
                var experience = view.FindViewById<TextView>(Resource.Id.experienceTextView);
                view.Tag = new ListHolder() { Name = name, FieldOfExpertise = expertise, Experience = experience };
            }
            var viewholder = (ListHolder)view.Tag;
            viewholder.Name.Text = users[position].Name;
            viewholder.FieldOfExpertise.Text = users[position].FieldOfExpertise;
            viewholder.Experience.Text = users[position].Experience.ToString();

            return view;

        }
    }
}