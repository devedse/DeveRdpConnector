using DeveRdpConnector.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DeveRdpConnector.Helpers
{
    public static class ServerInfoLoader
    {
        public static ServerInfoGroup GetOrCreateGroup(List<ServerInfoGroup> groups, string environment, string? stream, string? colorString)
        {
            var obtainedGroup = groups.FirstOrDefault(t => string.Equals(t.Environment, environment, StringComparison.OrdinalIgnoreCase) && string.Equals(t.Stream, stream, StringComparison.OrdinalIgnoreCase));
            if (obtainedGroup == null)
            {
                obtainedGroup = new ServerInfoGroup(environment, stream, colorString);
                groups.Add(obtainedGroup);
            }
            return obtainedGroup;
        }

        public static List<ServerInfoGroup> ObtainServerInfos(List<string> serverFileNames)
        {
            var serverInfoGroups = new List<ServerInfoGroup>();

            var noGroup = GetOrCreateGroup(serverInfoGroups, "No Group", null, null);

            foreach (var fileName in serverFileNames)
            {
                var currentGroup = noGroup;

                using (var reader = new StreamReader(fileName))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("#") && line.Length > 1)
                        {
                            var everythingAfterHashtag = line.Substring(1);
                            if (everythingAfterHashtag.Count(t => t == '|') == 2)
                            {
                                var splitted = everythingAfterHashtag.Split('|');
                                currentGroup = GetOrCreateGroup(serverInfoGroups, splitted[0], splitted[1], splitted[2]);
                            }
                            else if (everythingAfterHashtag.Count(t => t == '|') == 1)
                            {
                                var splitted = everythingAfterHashtag.Split('|');
                                currentGroup = GetOrCreateGroup(serverInfoGroups, splitted[0], null, splitted[1]);
                            }
                            else
                            {
                                currentGroup = GetOrCreateGroup(serverInfoGroups, everythingAfterHashtag, null, null);
                            }
                        }
                        else if (!(String.IsNullOrEmpty(line) || String.IsNullOrWhiteSpace(line) || line.StartsWith("#")))
                        {
                            var splitted = line.Split('|');
                            if (splitted.Length >= 2 || splitted.Length <= 3)
                            {
                                if (splitted.Length == 2)
                                {
                                    var serverInfo = new ServerInfo(splitted[0], splitted[1], null);
                                    currentGroup.Children.Add(serverInfo);
                                }
                                else if (splitted.Length == 3)
                                {
                                    var serverInfo = new ServerInfo(splitted[0], splitted[1], splitted[2]);
                                    currentGroup.Children.Add(serverInfo);
                                }
                            }
                        }
                    }
                }
            }

            //serverInfoGroups = serverInfoGroups.OrderBy(t => t.Environment).ThenBy(t => t.Stream).ToList();

            //foreach (var serverInfoGroup in serverInfoGroups)
            //{
            //    serverInfoGroup.SortChildren();
            //}

            //Remove empty groups
            return serverInfoGroups.Where(t => t.Children.Count > 0).ToList();
        }
    }
}