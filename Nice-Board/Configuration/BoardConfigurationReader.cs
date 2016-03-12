using System;
using System.IO;
using Windows.Storage;
using Nice_Board.Configuration.ConfigurationModels;
using System.Threading.Tasks;
using Nice_Board.Assembly;
using System.Linq;
using System.Collections.Generic;
using Nice_Board.Core;

namespace Nice_Board.Configuration
{
    internal class BoardConfigurationReader
    {
        private readonly IModelReader<BoardConfigurationModel> m_ModelReader;
        private readonly IStorageFolder m_RootFolder;
        private readonly ClassFactory m_ClassFactory;

        public BoardConfigurationReader(IStorageFolder p_RootFolder)
        {
            m_RootFolder = p_RootFolder;
            m_ModelReader = new JsonReader<BoardConfigurationModel>();
            m_ClassFactory = new ClassFactory();
        }

        public async Task<IBoard<IDataModel>> LoadBoard(string boardReferenceName)
        {
            string boardFileName = GetBoardFileName(boardReferenceName);
            BoardConfigurationModel boardModel = await ReadModel(boardFileName);

            Type dataFetcherType = m_ClassFactory.FindType(boardModel.DataFetcher);

            IDataFetcher<IDataModel> dataFetcher = (IDataFetcher<IDataModel>)m_ClassFactory.CreateClass(dataFetcherType);
            IBoard<IDataModel> board = (IBoard<IDataModel>)m_ClassFactory.CreateClass(dataFetcherType);

            board.SetDataFetcher(dataFetcher);

            return board;
        }

        private async Task<BoardConfigurationModel> ReadModel(string boardFileName)
        {
            IStorageFile boardFile = await m_RootFolder.GetFileAsync(boardFileName);
            using (Stream stream = await boardFile.OpenStreamForReadAsync())
            {
                return m_ModelReader.StreamToModel(stream);
            }
        }

        private string GetBoardFileName(string p_BoardName)
        {
            return p_BoardName + ".config.json";
        }
    }
}
