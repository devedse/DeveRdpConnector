using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DeveRdpConnector.Models.UiModels
{
    public class UiEnvironment
    {
        public ObservableCollection<UiEnvironmentStreamGroup> Streams { get; } = new ObservableCollection<UiEnvironmentStreamGroup>();

        public string Name { get;}
        public int Row { get; }

        public UiEnvironment(string name, int row)
        {
            Name = name;
            Row = row;
        }
    }
}
