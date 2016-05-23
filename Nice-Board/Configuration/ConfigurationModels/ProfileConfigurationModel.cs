using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nice_Board.Configuration.ConfigurationModels
{
    public struct ProfileConfigurationModel
    {
        public string Name { get; set; }
        public GoogleConfigurationModel? Google { get; set; }
    }
}
