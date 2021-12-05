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

            var environments = serverInfoGroups.Select(t => t.Environment).Distinct().ToList();
            var streams = serverInfoGroups.Select(t => t.Stream).Distinct().ToList();

            foreach (var environment in environments)
            {
                var uiEnvironment = new UiEnvironment(environment);
                uiData.Add(uiEnvironment);

                foreach (var stream in streams)
                {
                    var uiStream = new UiStream(stream ?? "");
                    uiEnvironment.Streams.Add(uiStream);

                    var serverInfoGroupsHere = serverInfoGroups.Where(t => t.Environment == environment && t.Stream == stream).ToList();
                    var serverInfosHere = serverInfoGroupsHere.SelectMany(t => t.Children).ToList();

                    foreach (var serverInfo in serverInfosHere)
                    {
                        IBrush desiredColorBrush = null;
                        try
                        {
                            var desiredColor = serverInfo.Color ?? serverInfoGroupsHere.FirstOrDefault(t => t.Color != null)?.Color ?? "";
                            desiredColorBrush = colorConverter.ConvertFromString(desiredColor) as SolidColorBrush ?? Brushes.LightGreen;
                        }
                        catch
                        {

                        }
                        if (desiredColorBrush == null)
                        {
                            desiredColorBrush = Brushes.Red;
                        }


                        var uiServerInfo = new UiServerInfo(serverInfo.Name, serverInfo.Address, desiredColorBrush);
                        uiStream.Servers.Add(uiServerInfo);
                    }
                }
            }

            return uiData;
        }
    }
}
