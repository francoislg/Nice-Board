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
using Nice_Board.Core.Card;
using Nice_Board.GoogleCalendar.Card;
using System.Collections.ObjectModel;
using Nice_Board_CoreUI;
using Nice_Board_RTC;
using Nice_Board.GoogleCalendar.Provider;

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

        private ObservableCollection<UserControl> CardControls;
        private ObservableCollection<ICardProvider> CardProviders;

        public MainPage()
        {
            this.InitializeComponent();

            CardControls = new ObservableCollection<UserControl>();
            CardProviders = new ObservableCollection<ICardProvider>();
            CardProviders.CollectionChanged += CardProviders_CollectionChanged;
            MyPanel.ItemsSource = CardControls;

            //Test();
            InitBoards();
        }

        private void CardProviders_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Task.WaitAll(CardProviders.Select(provider => provider.Synchronize()).ToArray());
            // This is probably the worst way possible besides bogosorting just before. Change it some day.
            CardControls.Clear();
            IEnumerable<UserControl> controls = CardProviders.SelectMany(provider => provider.Cards).Select(provider => provider.Control);
            foreach(UserControl control in controls)
            {
                CardControls.Add(control);
            }
        }

        private async Task Test()
        {
            
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
                GoogleCalendarClient gAgendaClient = new GoogleCalendarClient(client);

                textBlock.Text = "User code: " + (await client.GetUserCode());

                while (!(await client.HasAuthorization()))
                {
                    Task.Delay(5000).Wait();
                }

                CardProviders.Add(new GoogleCalendarCardProvider(gAgendaClient));
            }
            catch(Exception e)
            {
                textBlock.Text += "  ERROR :" + e.ToString();
            }
        }
    }
}
