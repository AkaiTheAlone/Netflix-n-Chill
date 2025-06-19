using Netflix_n_Chill.Hypermedia.Abstract;

namespace Netflix_n_Chill.Hypermedia.Filters
{
    public class HypermediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
