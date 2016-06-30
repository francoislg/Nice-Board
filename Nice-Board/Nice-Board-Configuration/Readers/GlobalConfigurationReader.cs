using System;
using System.IO;
using Windows.Storage;
using System.Threading.Tasks;
using Nice_Board.Core.Models;

namespace Nice_Board.Configuration.Readers
{
    public class GlobalConfigurationReader
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
