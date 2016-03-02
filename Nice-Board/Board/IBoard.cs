using Nice_Board.DataFetcher;

namespace Nice_Board.Board
{
    public interface IBoard<in TDataModel> where TDataModel : IDataModel
    {

    }
}
