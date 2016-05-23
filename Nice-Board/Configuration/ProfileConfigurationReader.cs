using System;
using System.IO;
using Windows.Storage;
using Nice_Board.Configuration.ConfigurationModels;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Nice_Board.Core;

namespace Nice_Board.Configuration
{
    internal class ProfileConfigurationReader
    {
        private readonly IModelReader<ProfileConfigurationModel> m_ModelReader;
        private readonly IStorageFolder m_RootFolder;

        public ProfileConfigurationReader(IStorageFolder p_RootFolder)
        {
            m_RootFolder = p_RootFolder;
            m_ModelReader = new JsonReader<ProfileConfigurationModel>();
        }

        public async Task<ProfileConfigurationModel> LoadProfile(string profileReferenceName)
        {
            string profileFileName = GetProfileConfigurationFileName(profileReferenceName);
            return await ReadModel(profileFileName);
        }

        private async Task<ProfileConfigurationModel> ReadModel(string boardFileName)
        {
            IStorageFile boardFile = await m_RootFolder.GetFileAsync(boardFileName);
            using (Stream stream = await boardFile.OpenStreamForReadAsync())
            {
                return m_ModelReader.StreamToModel(stream);
            }
        }

        private string GetProfileConfigurationFileName(string p_BoardName)
        {
            return p_BoardName + ".config.json";
        }
    }
}
