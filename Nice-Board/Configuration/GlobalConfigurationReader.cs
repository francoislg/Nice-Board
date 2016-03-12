using System;
using System.IO;
using Nice_Board.Configuration.ConfigurationModels;
using Windows.Storage;
using Windows.ApplicationModel;
using Windows.Foundation;
using System.Threading.Tasks;

namespace Nice_Board.Configuration
{
    internal class GlobalConfigurationReader
    {
        private readonly IStorageFolder m_RootFolder;
        private const string CONFIGURATION_FILENAME = "config.json";

        private readonly IModelReader<GlobalConfigurationModel> m_ModelReader;

        public GlobalConfigurationReader(IStorageFolder p_RootFolder)
        {
            m_RootFolder = p_RootFolder;
            m_ModelReader = new JsonReader<GlobalConfigurationModel>();
        }

        public async Task<GlobalConfigurationModel> GetConfiguration()
        {
            IStorageFile storageFile = await m_RootFolder.GetFileAsync(CONFIGURATION_FILENAME);
            using (Stream stream = await storageFile.OpenStreamForReadAsync())
            {
                return m_ModelReader.StreamToModel(stream);
            }
        }

    }
}
