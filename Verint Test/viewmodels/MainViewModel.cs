using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verint_Test.classes;

namespace Verint_Test.viewmodels
{
    public class MainViewModel 
    { 
        public ICommand 

        WebHandler _webHandler
        {
            get
            {
                return WebHandler.Instance;
            }
        }
        String WebContent { get; set; }




    }
}
