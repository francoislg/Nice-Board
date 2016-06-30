using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel;
using Windows.Storage;
using System.Threading.Tasks;
using System.Text;
using Nice_Board.Configuration.Readers;
using Nice_Board.Core.Models;
using Nice_Board.GoogleClient;
using Nice_Board.GoogleCalendar.Client;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Nice_Board
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private GlobalConfigurationReader m_ConfigurationReader;
        private ProfileConfigurationReader m_ProfileConfigurationReader;

        public MainPage()
        {
            this.InitializeComponent();

            InitBoards();
        }

        private async Task InitBoards()
        {
            IStorageFolder rootPath = Package.Current.InstalledLocation;

            textBlock.Text = rootPath.Path;
            try
            {
                m_ConfigurationReader = new GlobalConfigurationReader(rootPath);

                GlobalConfigurationModel config = await m_ConfigurationReader.GetConfiguration();

                IStorageFolder boardRootPath = await rootPath.GetFolderAsync(config.ProfilesPath);

                m_ProfileConfigurationReader = new ProfileConfigurationReader(boardRootPath);
                
                IList<Task<ProfileConfigurationModel>> tasks = config.ProfileNames
                                                               .Select(m_ProfileConfigurationReader.LoadProfile)
                                                               .ToList();

                IList<ProfileConfigurationModel> profiles = await Task.WhenAll(tasks);

                textBlock.Text = profiles.Aggregate(new StringBuilder(), (sb, profile) => sb.Append(profile.Name)).ToString();

                textBlock.Text += "  --   " + Windows.Networking.Connectivity.NetworkInformation.GetHostNames().Aggregate(new StringBuilder(), (sb, hostname) => sb.Append(hostname.RawName)).ToString();

                GoogleRestClient client = new GoogleRestClient(profiles.First().Google.Value);
                GoogleAgendaClient gAgendaClient = new GoogleAgendaClient(client);

                textBlock.Text = "User code: " + (await client.GetUserCode());

                while (!(await client.HasAuthorization()))
                {
                    Task.Delay(5000).Wait();
                }

                gAgendaClient.Synchronize();
            }
            catch(Exception e)
            {
                textBlock.Text += "  ERROR :" + e.ToString();
            }
        }
    }
}
