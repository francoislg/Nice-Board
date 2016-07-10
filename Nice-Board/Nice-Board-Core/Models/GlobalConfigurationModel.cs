using System.Collections.Generic;

namespace Nice_Board.Core.Models
{
    public struct GlobalConfigurationModel
    {
        public string ProfilesPath { get; set; }
        public IList<string> ProfileNames { get; set; }
    }
}
