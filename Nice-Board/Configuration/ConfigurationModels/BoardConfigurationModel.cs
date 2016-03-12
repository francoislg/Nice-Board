using System.Collections.Generic;

namespace Nice_Board.Configuration.ConfigurationModels
{
    internal class BoardConfigurationModel
    {
        public string Name = "";
        public List<string> Assemblies;
        public string DataModel;
        public string DataFetcher;
        public string Board;
    }
}
