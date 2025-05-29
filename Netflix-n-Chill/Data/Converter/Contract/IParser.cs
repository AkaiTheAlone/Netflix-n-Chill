namespace Netflix_n_Chill.Data.Converter.Contract
{
    public interface IParser<Origin, Destination>
    {
        Destination Parse(Origin origin);
        List<Destination> Parse(List<Origin> origin);
    }
}
