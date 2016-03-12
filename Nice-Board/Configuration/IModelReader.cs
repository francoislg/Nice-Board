using System.IO;

namespace Nice_Board.Configuration
{
    public interface IModelReader<TModel>
    {
        TModel StreamToModel(Stream p_Stream);
    }
}
