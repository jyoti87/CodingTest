using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CodingTest.Resources.layout;

namespace CodingTest
{
    [Activity(Label = "UserRegisterActivity")]
    public class UserRegisterActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.RegisterUserLayout);
           Button saveBtn = FindViewById<Button>(Resource.Id.SaveButton);
            saveBtn.Click += OnSaveButtonClickEvent;
            Button cancelBtn = FindViewById<Button>(Resource.Id.CancelButton);
            cancelBtn.Click += OnCancelButtonClickEvent;
        }

        private void OnCancelButtonClickEvent(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ShowListActivity));
            StartActivity(intent);
        }

        private void OnSaveButtonClickEvent(object sender, EventArgs e)
        {
            User inputUser = new User();
            DBRepository repository = new DBRepository();
            var userName = FindViewById<EditText>(Resource.Id.userName);
            var password = FindViewById<EditText>(Resource.Id.password1);
            var expertise = FindViewById<EditText>(Resource.Id.expertise);
            var experience = FindViewById<EditText>(Resource.Id.experience);
            Regex regexUserName = new Regex(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{5,12})$");
            Regex regexpassword = new Regex(@"^([a-zA-Z0-9@*#]{5,12})$");
            Match matchUserName = regexUserName.Match(userName.Text);
            Match matchPassword = regexpassword.Match(password.Text);
            Match matchexpertise = regexUserName.Match(expertise.Text);
            if (matchUserName.Success && matchPassword.Success && matchexpertise.Success && experience.Text!=string.Empty)
            {
                inputUser.Name = userName.Text;
                inputUser.FieldOfExpertise = expertise.Text;
                inputUser.Password = password.Text;
                inputUser.Experience =int.Parse(experience.Text);
                repository.InsertUser(inputUser);
                var intent = new Intent(this, typeof(ShowListActivity));
                StartActivity(intent);
            }
            else
            {
                var textmessage = FindViewById<TextView>(Resource.Id.listViewMessage);
                textmessage.Text = "Input string must be of length greater than 5 and less than 12.. And the input strings must be alphanumerics.";
            }
            
        }

        public override void OnBackPressed()
        {
            //base.OnBackPressed();

        }
    }
}