using DeveRdpConnector.Helpers;
using DeveRdpConnector.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DeveRdpConnector.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Test => "Hello test";

        public IEnumerable<string> CollectionWithEmptyItem => Enumerable.Repeat("", 1);

        public ObservableCollection<ServerInfoGroup> Servers { get; set; } = new ObservableCollection<ServerInfoGroup>();
        public IEnumerable<string> Environments => CollectionWithEmptyItem.Concat(Servers.Select(t => t.Environment).Distinct());
        public IEnumerable<string?> Streams => Servers.Select(t => t.Stream + "").Distinct();

        public MainWindowViewModel()
        {
            Servers.Clear();
            //var serverInfos = ServerInfoLoader.ObtainServerInfos(new List<string>() { "ServerNames-1-TLS.txt" });
            var serverInfos = ServerInfoLoader.ObtainServerInfos(new List<string>() { @"C:\XGitPrivate\DeveRdpConnector\src\DeveRdpConnector\DeveRdpConnector\ServerNames-1-TLS.txt" });
            foreach (var serverInfo in serverInfos)
            {
                Servers.Add(serverInfo);
            }

        }
    }
}
