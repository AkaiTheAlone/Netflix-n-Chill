namespace Netflix_n_Chill.Hypermedia.Abstract
{
    public interface ISupportHypermedia
    {
        List<HypermediaLink> Links { get; set; }
    }
}
