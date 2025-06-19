using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using Netflix_n_Chill.Hypermedia.Abstract;
using System.Collections.Concurrent;

namespace Netflix_n_Chill.Hypermedia
{
    //rever sobre hateoas, n ficou exatamente claro oq eu faco e oq isso faz
    public abstract class ContentResponseEnricher<TData> : IResponseEnricher where TData : ISupportHypermedia
    {
        protected ContentResponseEnricher()
        {

        }
        protected abstract Task EnrichModel(TData content, IUrlHelper urlHelper);
        bool IResponseEnricher.CanEnrich(ResultExecutingContext response)
        {
            if (response.Result is OkObjectResult okObjResult)
            {
                return CanEnrich(okObjResult.Value.GetType());
            }

            return false;
        }
        public bool CanEnrich(Type ContentType)
        {
            return ContentType == typeof(TData) || ContentType == typeof(List<TData>);
        }

        public async Task Enrich(ResultExecutingContext response)
        {
            var urlHelper = new UrlHelperFactory().GetUrlHelper(response);
            if (response.Result is OkObjectResult okResult)
            {
                if (okResult.Value is TData model)
                {
                    await EnrichModel(model, urlHelper);
                }
                else if (okResult.Value is List<TData> collection)
                {
                    ConcurrentBag<TData> bag = new ConcurrentBag<TData>();
                    Parallel.ForEach(bag, (element) => { EnrichModel(element, urlHelper); });
                }
            }
            await Task.FromResult<Object>(null);
            ;
        }
    }
}
