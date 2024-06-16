using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Media.TextFormatting;
using Newtonsoft.Json;
using SecondLibPractice;

namespace WpfApp1.ViewModel.ApiHelper;

public static class ApiHelper
    {
        private static string _url = "http://93.185.159.39:5000/api";
        public static T? Get<T>(string model, int id = 0) 
        {
            HttpClient client = new HttpClient();
            string request = id == 0 ? $"{model}" : $"{model}/{id}";
            HttpResponseMessage response = client.GetAsync($"{_url}/{model}/{(id != 0 ? id : string.Empty)}").Result;
            if (response.StatusCode != HttpStatusCode.OK) return default;
            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
        }   
    
        public static bool Put<T>(string json, string model, int id)
        {
            HttpClient client = new HttpClient();
            HttpContent body = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync($"{_url}/{model}/{id}", body).Result;
            if (response.StatusCode != HttpStatusCode.NoContent) return false;
            return true;
        }

        public static bool Post<T>(string json, string model)
        {
            HttpClient client = new HttpClient();
            HttpContent body = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync($"{_url}/{model}", body).Result;
            if (response.StatusCode != HttpStatusCode.Created) return false;
            return true;
        }

        public static bool Delete<T>(string model, int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync($"{_url}/{model}/{id}").Result;
            if (response.StatusCode != HttpStatusCode.NoContent) return false;
            return true;
        }

    }