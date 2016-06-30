using System;
using System.IO;
using Windows.Storage;
using System.Threading.Tasks;
using Nice_Board.Core.Models;

namespace Nice_Board.Configuration.Readers
{
    public class ProfileConfigurationReader
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
