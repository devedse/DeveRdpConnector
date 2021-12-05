using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DeveRdpConnector.Models.UiModels
{
    public class UiEnvironment
    {
        public ObservableCollection<UiStream> Streams { get; } = new ObservableCollection<UiStream>();

        public string Name { get; set; }

        public UiEnvironment(string name)
        {
            Name = name;
        }
    }
}
