using Avalonia.Media;
using DeveRdpConnector.Models;
using DeveRdpConnector.Models.UiModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DeveRdpConnector.Helpers
{
    public static class ServerInfoUiTransmogifier
    {
        public static ObservableCollection<UiEnvironment> Transmogify(List<ServerInfoGroup> serverInfoGroups)
        {
            var colorConverter = new BrushConverter();

            var uiData = new ObservableCollection<UiEnvironment>();

            //This should be enabled environments / enabled streams
            var environments = serverInfoGroups.Select(t => t.Environment).Distinct().ToList();
            var streams = serverInfoGroups.Select(t => t.Stream).Distinct().ToList();

            for (int y = 0; y < environments.Count; y++)
            {
                var environment = environments[y];

                var uiEnvironment = new UiEnvironment(environment, y + 1);
                uiData.Add(uiEnvironment);

                for (int x = 0; x < streams.Count; x++)
                {
                    var stream = streams[x];

                    var uiStream = new UiEnvironmentStreamGroup(stream ?? "", y + 1, x + 1);
                    uiEnvironment.Streams.Add(uiStream);

                    var serverInfoGroupsHere = serverInfoGroups.Where(t => t.Environment == environment && t.Stream == stream).ToList();
                    var serverInfosHere = serverInfoGroupsHere.SelectMany(t => t.Children).ToList();

                    foreach (var serverInfo in serverInfosHere)
                    {
                        IBrush? desiredColorBrush = null;
                        try
                        {
                            var desiredColor = serverInfo.Color ?? serverInfoGroupsHere.FirstOrDefault(t => t.Color != null)?.Color ?? "";
                            desiredColorBrush = colorConverter.ConvertFromString(desiredColor) as IBrush ?? Brushes.LightGreen;
                        }
                        catch
                        {

                        }
                        if (desiredColorBrush == null)
                        {
                            desiredColorBrush = Brushes.Red;
                        }


                        var uiServerInfo = new UiServerInfo(serverInfo.Name.Replace("{newline}", Environment.NewLine, StringComparison.OrdinalIgnoreCase), serverInfo.Address, desiredColorBrush);
                        uiStream.Servers.Add(uiServerInfo);
                    }
                }
            }

            return uiData;
        }
    }
}
