using System.IO;
using Newtonsoft.Json;

namespace Nice_Board.Configuration
{
    public class JsonReader<TJsonModel> : IModelReader<TJsonModel>
    {
        private readonly JsonSerializer m_JsonSerializer;

        public JsonReader()
        {
            m_JsonSerializer = new JsonSerializer();
        }

        public TJsonModel StreamToModel(Stream p_Stream)
        {
            using (TextReader textReader = new StreamReader(p_Stream))
            {
                using (JsonTextReader jsonTextReader = new JsonTextReader(textReader))
                {
                    return m_JsonSerializer.Deserialize<TJsonModel>(jsonTextReader);
                }
            }
        }
    }
}
