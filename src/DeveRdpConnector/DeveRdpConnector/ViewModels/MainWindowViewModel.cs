using DeveRdpConnector.Helpers;
using DeveRdpConnector.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DeveRdpConnector.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public IEnumerable<string> EmptyCollection => Enumerable.Repeat<string>("", 1);

        public ObservableCollection<ServerInfoGroup> Servers { get; set; } = new ObservableCollection<ServerInfoGroup>();
        public IEnumerable<string> Environments => EmptyCollection.Concat(Servers.Select(t => t.Environment).Distinct());
        public IEnumerable<string?> Streams => EmptyCollection.Concat(Servers.Select(t => t.Stream + "").Distinct());

        public MainWindowViewModel()
        {
            Servers.Clear();
            var serverInfos = ServerInfoLoader.ObtainServerInfos(new List<string>() { "ServerNames-1-TLS.txt" });
            foreach (var serverInfo in serverInfos)
            {
                Servers.Add(serverInfo);
            }

        }
    }
}
