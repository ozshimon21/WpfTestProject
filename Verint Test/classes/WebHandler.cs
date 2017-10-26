using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Verint_Test.classes
{
    public sealed class WebHandler
    {
        private static WebHandler _instance;
        private static object singletonLockObject;

        public static WebHandler Instance
        {
            get
            {
                if (_instance != null)
                {
                    lock (singletonLockObject)
                    {
                        if (_instance != null)
                        {
                            _instance = new WebHandler();
                        }
                    }
                }
                return _instance;
            }
        }

        public static async Task<string> DownloadWebSite(string urlAddress)
        {
           // await Task.Delay(TimeSpan.FromSeconds(3)).ConfigureAwait(false);
//            var client = new HttpClient();
//            using (var response = await client.GetAsync(urlAddress).ConfigureAwait(false))
//            {
//                var data = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
//                return data.ToString();
//            }

            var client = new WebClient();
            return await client.DownloadStringTaskAsync("http://www.gooogle.com");
        }

        public static async Task<String> test(string name)
        {
            return await new Task<string>(() => "");
        }
      
    }
}
