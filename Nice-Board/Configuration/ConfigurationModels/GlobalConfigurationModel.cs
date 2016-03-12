using System.Collections.Generic;

namespace Nice_Board.Configuration.ConfigurationModels
{
    internal class GlobalConfigurationModel
    {
        public string BoardsPath = "Boards";
        public List<string> Boards = new List<string>();
    }
}
