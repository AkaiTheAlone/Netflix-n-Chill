using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Netflix_n_Chill.Hypermedia.Filters
{
    public class HypermediaFilter : ResultFilterAttribute
    {
        private HypermediaFilterOptions _hypermediaFilterOptions { get; set; }
        public HypermediaFilter(HypermediaFilterOptions _hmo)
        {
            _hypermediaFilterOptions = _hmo;
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            TryEnrichResult(context);
        }

        private void TryEnrichResult(ResultExecutingContext context)
        {
            if (context.Result is OkObjectResult objectResult)
            {
                var enricher = _hypermediaFilterOptions.ContentResponseEnricherList.FirstOrDefault(x => x.CanEnrich(context));

                if (enricher != null) Task.FromResult(enricher.Enrich(context));
            }
        }
    }

}
