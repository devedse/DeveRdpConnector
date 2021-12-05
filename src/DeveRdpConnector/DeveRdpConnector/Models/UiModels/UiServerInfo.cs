using Avalonia.Media;

namespace DeveRdpConnector.Models.UiModels
{
    public class UiServerInfo
    {
        public string Name { get; }
        public string Address { get; }
        public IBrush Color { get; }

        public UiServerInfo(string name, string address, IBrush color)
        {
            Name = name;
            Address = address;
            Color = color;
        }
    }
}
