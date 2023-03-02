using BeautyApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BeautyApp.Controllers
{
    /// <summary>
    /// Авторизация
    /// </summary>
    /// <param name="login">Логин</param>
    /// <param name="password">Пароль</param>
    public class UsersController
    {
        public static Users GetUser(string login, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = Manager.RootUrl + "Users/" + login + "/" + password;
                HttpResponseMessage response = client.GetAsync($"{url}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync();
                    var answer = JsonConvert.DeserializeObject<Users>(content.Result);
                    return answer;
                }
                else { return null; }
            }
        }
    }
}
