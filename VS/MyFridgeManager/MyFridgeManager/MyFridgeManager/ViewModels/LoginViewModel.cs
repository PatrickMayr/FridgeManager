using MyFridgeManager.Models;
using MyFridgeManager.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Xamarin.Forms;

namespace MyFridgeManager.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            Console.WriteLine("dddd");
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            var url = "10.0.0.6/user/login";

            loginPostRequest();

            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        public void loginPostRequest()
        {
            var url = "10.0.0.6/user/login";
            Console.WriteLine("dddd");

            var request = WebRequest.Create(url);
            request.Method = "POST";

            var loginuser = new LoginUser(1, "pm@mail.com", "pw_pm");
            var json = JsonSerializer.Serialize(loginuser);
            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            using var reqStream = request.GetRequestStream();
            reqStream.Write(byteArray, 0, byteArray.Length);

            using var response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            using var respStream = response.GetResponseStream();

            using var reader = new StreamReader(respStream);
            string data = reader.ReadToEnd();
            Console.WriteLine(data);
        }
    }
}
