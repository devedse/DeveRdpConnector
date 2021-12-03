using System.Collections.Generic;

namespace DeveRdpConnector.Models
{
    public record ServerInfoGroup
    {
        public string Environment { get; }
        public string? Stream { get; }
        public string? Color { get; }
        public List<ServerInfo> Children { get; }
        public ServerInfoGroup(string environment, string? stream, string? color)
        {
            Environment = environment;
            Stream = stream;
            Color = color;
            Children = new List<ServerInfo>();
        }
    }
}
