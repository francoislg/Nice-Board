namespace Nice_Board.DataFetcher
{
    /// <summary>
    /// Implements methods to fetch data.
    /// </summary>
    public interface IDataFetcher<out TDataModel> where TDataModel : IDataModel 
    {

    }
}
