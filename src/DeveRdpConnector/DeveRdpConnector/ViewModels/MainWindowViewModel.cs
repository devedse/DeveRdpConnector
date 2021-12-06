using DeveRdpConnector.Helpers;
using DeveRdpConnector.Models;
using DeveRdpConnector.Models.UiModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DeveRdpConnector.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Test => "Hello test";

        public IEnumerable<string> CollectionWithEmptyItem => Enumerable.Repeat("", 1);

        //public ObservableCollection<ServerInfoGroup> Servers { get; set; } = new ObservableCollection<ServerInfoGroup>();
        //public IEnumerable<string> Environments => CollectionWithEmptyItem.Concat(Servers.Select(t => t.Environment).Distinct());
        //public IEnumerable<string?> Streams => Servers.Select(t => t.Stream + "").Distinct();



        public ObservableCollection<UiEnvironment> Environments { get; set; } = new ObservableCollection<UiEnvironment>();

        public ObservableCollection<UiEnvironmentStreamGroup> UiEnvironmentStreamGroups { get; } = new ObservableCollection<UiEnvironmentStreamGroup>();

        public string RowDefinitionsString => string.Join(",", Enumerable.Repeat("Auto", Environments.Count + 1));
        public string ColumnDefinitionsString => string.Join(",", Enumerable.Repeat("Auto", (Environments.FirstOrDefault()?.Streams.Count ?? 1) + 1));

        public ObservableCollection<object> Items { get; } = new ObservableCollection<object>();

        public MainWindowViewModel()
        {
            //Servers.Clear();
            //var serverInfos = ServerInfoLoader.ObtainServerInfos(new List<string>() { "ServerNames-1-TLS.txt" });
            var serverInfos = ServerInfoLoader.ObtainServerInfos(new List<string>() { @"C:\XGitPrivate\DeveRdpConnector\src\DeveRdpConnector\DeveRdpConnector\ServerNames-1-TLS.txt" });
            Environments = ServerInfoUiTransmogifier.Transmogify(serverInfos);

            UiEnvironmentStreamGroups.Clear();
            foreach (var thing in Environments.SelectMany(t => t.Streams))
            {
                UiEnvironmentStreamGroups.Add(thing);
            }

            Items.Clear();
            foreach (var env in Environments)
            {
                Items.Add(env);
            }

        }
    }
}
