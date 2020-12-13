using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DITest
{
    public class ConfigReader : IConfigReader
    {
        private string _configFilePath;

        public ConfigReader(string configFileName)
        {
            _configFilePath = configFileName;
        }

        public string Reader()
        {
            return File.ReadAllText(_configFilePath);
        }
    }
}