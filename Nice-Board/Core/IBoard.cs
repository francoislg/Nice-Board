namespace Nice_Board.Core
{
    public interface IBoard<in TDataModel> where TDataModel : IDataModel
    {
        void SetDataFetcher(IDataFetcher<TDataModel> p_DataFetcher);
    }
}
