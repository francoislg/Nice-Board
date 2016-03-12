using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Nice_Board.Configuration;
using Nice_Board.Configuration.ConfigurationModels;
using Windows.ApplicationModel;
using Windows.Storage;
using Nice_Board.Core;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Nice_Board
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private GlobalConfigurationReader m_ConfigurationReader;
        private BoardConfigurationReader m_BoardConfigurationReader;

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

                IStorageFolder boardRootPath = await rootPath.GetFolderAsync(config.BoardsPath);

                m_BoardConfigurationReader = new BoardConfigurationReader(boardRootPath);
                /*
                IList<Task<IBoard<IDataModel>>> tasks = config.Boards
                                                               .Select(m_BoardConfigurationReader.LoadBoard)
                                                               .ToList();

                IList<IBoard<IDataModel>> boards = await Task.WhenAll(tasks);

                IBoard<IDataModel> firsBoard = boards.ElementAt(0);*/
            }
            catch(Exception e)
            {
                textBlock.Text += "  ERROR :" + e.ToString();
            }
        }
    }
}
