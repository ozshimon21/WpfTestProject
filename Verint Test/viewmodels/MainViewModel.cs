using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Verint_Test.Annotations;
using Verint_Test.classes;
using Verint_Test.commands;
using Verint_Test.Interfaces;

namespace Verint_Test.viewmodels
{
    public class MainViewModel : INotifyPropertyChanged
    { 
        public string UrlAddress { get; set; }
        public string UrlContent { get; set; }

        public IAsyncCommand DownloadUrlContentCommand { get; set; }

       public WebHandler WebHandler => WebHandler.Instance;

        public MainViewModel()
        {
            UrlAddress = "http://www.google.com/";

            DownloadUrlContentCommand = AsyncCommand.Create(() => WebHandler.DownloadWebSite(UrlAddress));

             
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
