using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Opengl;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Transitions;
using Android.Views;
using Android.Widget;
using CodingTest.Resources.layout;

namespace CodingTest
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ListView usersList;
        List<User> data;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            data = initializeData();

            if (data != null)
            {
                var intent = new Intent(this, typeof(LoginActivity));
                StartActivity(intent);
                // SetContentView(Resource.Layout.activity_main);
                Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
                SetSupportActionBar(toolbar);
                //usersList = FindViewById<ListView>(Resource.Id.listView);

                //    usersList.Adapter = new MyListViewAdapter(data);
            }
            else
            {
                var intent = new Intent(this, typeof(UserRegisterActivity));
                StartActivity(intent);
                // var textmessage = FindViewById<TextView>(Resource.Id.listViewMessage);
                //textmessage.Text = "No items in the list to display.Please click on Add ";
            }
          //  FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
          //  fab.Click += FabOnClick;
        }

        private List<User> initializeData()
        {
            DBRepository db = new DBRepository();

            try
            {
                var localDBUsers = db.GetUserData();
                return localDBUsers;
            }
            catch (Exception ex)
            {
                db.CreateTable();
                return null;
            }

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            var intent = new Intent(this, typeof(UserRegisterActivity));
            StartActivity(intent);
            //View view = (View) sender;
            //Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
            //    .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnBackPressed()
        {
            //base.OnBackPressed();
        }
    }
}
