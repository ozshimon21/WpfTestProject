using System;
using System.Collections.Generic;
using System.Linq;
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
            var result = await Task.Factory.StartNew(async () =>
            {
                System.Net.Http.HttpClient c = new System.Net.Http.HttpClient();
                var urlResult = await c.GetAsync(urlAddress);
                return urlResult.Content.ToString();
            });
            return result.Result;
        }

      
    }
}
