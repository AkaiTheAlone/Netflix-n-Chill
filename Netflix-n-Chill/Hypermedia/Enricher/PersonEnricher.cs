using Microsoft.AspNetCore.Mvc;
using Netflix_n_Chill.Data.ValueObject;
using Netflix_n_Chill.Hypermedia.Constants;
using System.Text;

namespace Netflix_n_Chill.Hypermedia.Enricher
{
    public class PersonEnricher : ContentResponseEnricher<PersonVO>
    {
        private readonly object _lock = new object();
        protected override Task EnrichModel(PersonVO content, IUrlHelper urlHelper)
        {
            string link = GetLink(content.Id, urlHelper, "api/persons");

            content.Links.Add(new HypermediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet,
            });

            return Task.CompletedTask;
        }

        private string GetLink(long id, IUrlHelper urlHelper, string path)
        {
            lock (_lock)
            {
                return new StringBuilder(urlHelper.Link("DefaultApi", new
                {
                    controler = path,
                    id = id,
                })).Replace("%2f", "/").ToString();
            }
            ;
        }
    }
}
