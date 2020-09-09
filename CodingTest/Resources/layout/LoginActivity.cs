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

namespace CodingTest.Resources.layout
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Login);
            Button loginBtn = FindViewById<Button>(Resource.Id.LoginButton);
            loginBtn.Click += OnLoginButtonClickEvent;
            Button RegisterBtn = FindViewById<Button>(Resource.Id.RegisterButton);
            RegisterBtn.Click += OnRegisterButtonClickEvent;
        }

        private void OnRegisterButtonClickEvent(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(UserRegisterActivity));
            StartActivity(intent);
        }

        private void OnLoginButtonClickEvent(object sender, EventArgs e)
        {
            var userName = FindViewById<EditText>(Resource.Id.userName1);
            var password = FindViewById<EditText>(Resource.Id.password2);
            Regex regexUserName = new Regex(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{5,12})$");
            Regex regexpassword = new Regex(@"^([a-zA-Z0-9@*#]{5,12})$");
            Match matchUserName = regexUserName.Match(userName.Text);
            Match matchPassword = regexpassword.Match(password.Text);
            if (matchUserName.Success && matchPassword.Success)
            {
                User user = new User();
                DBRepository db = new DBRepository();
                user.Name = userName.Text;
                user.Password = password.Text;
                bool exists = db.CheckIfUserExist(user);
                if (exists)
                {
                    var intent = new Intent(this, typeof(ShowListActivity));
                    StartActivity(intent);
                }
                else
                {
                    var textmessage = FindViewById<TextView>(Resource.Id.listViewMessage);
                   textmessage.Text = "User Name or Password is incorrect. Login with correct user name and password.";
                }
            }
            else
            {
                var textmessage = FindViewById<TextView>(Resource.Id.listViewMessage);
                textmessage.Text = "User Name or Password is incorrect. Login with correct user name and password.";
            }

        }

        public override void OnBackPressed()
        {
            //base.OnBackPressed();
        }
    }
}