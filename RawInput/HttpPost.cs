using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Forms;

namespace RawInputApp
{
    public static class HttpPost
    {
        public static async void PostCard(string card)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://192.168.100.48:8080");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                var dictionary = new Dictionary<string, string>()
                {
                    {"code", "107"},
                    {"card_info", card}
                };

                HttpContent postContent = new FormUrlEncodedContent(dictionary);
                                          
                try
                {
                    HttpResponseMessage response = await httpClient.PostAsync("/card", postContent);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(responseBody);
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("error:" + ex);
                }
            }
            
        }
    }
}
