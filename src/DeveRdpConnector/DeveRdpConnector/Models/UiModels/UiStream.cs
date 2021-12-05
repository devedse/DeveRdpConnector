using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DeveRdpConnector.Models.UiModels
{
    public class UiStream
    {
        public ObservableCollection<UiServerInfo> Servers { get; } = new ObservableCollection<UiServerInfo>();
        public string Name { get; }

        public UiStream(string name)
        {
            Name = name;
        }
    }
}