using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace BeautyApp.Controllers
{
    public class ServiceCategoryes
    {/// <summary>
    /// Вывод категорий
    /// </summary>
        public List<ServiceCategoryes> GetServiceCategoryes()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{Manager.RootUrl}ServiceCategoryes";
                Console.WriteLine(url);
                HttpResponseMessage response = client.GetAsync(url).Result;
                var content = response.Content.ReadAsStringAsync();
                var answer = JsonConvert.DeserializeObject<List<ServiceCategoryes>>(content.Result);
                return answer;
            }
        }
    }
}
