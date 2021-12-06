using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DeveRdpConnector.Models.UiModels
{
    public class UiEnvironmentStreamGroup
    {
        public ObservableCollection<UiServerInfo> Servers { get; } = new ObservableCollection<UiServerInfo>();
        public string Name { get; }

        public int Row { get; }
        public int Column { get; }

        public UiEnvironmentStreamGroup(string name, int row, int column)
        {
            Name = name;
            Row = row;
            Column = column;
        }
    }
}