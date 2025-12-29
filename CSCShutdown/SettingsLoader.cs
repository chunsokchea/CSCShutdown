using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSCShutdown
{
    public class SettingsLoader
    {
        public static Dictionary<string, string> LoadSettings(string filePath)
        {
            var settings = new Dictionary<string, string>();

            if (File.Exists(filePath))
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        settings[parts[0].Trim()] = parts[1].Trim();
                    }
                }
            }

            return settings;
        }
    }
}
