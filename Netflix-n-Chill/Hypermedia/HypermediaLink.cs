namespace Netflix_n_Chill.Hypermedia
{
    public class HypermediaLink
    {
        public string Rel { get; set; }
        public string Type { get; set; }
        public string Action { get; set; }
        //public string Href overengineering?
        //{
        //    get
        //    {
        //        object _lock = new object();
        //        lock (_lock)
        //        {
        //            StringBuilder sb = new StringBuilder(_href);
        //            return sb.Replace("%2F", "/").ToString();
        //        }
        //    }
        //    set { _href = value; }
        //}
        public string Href
        {
            get => _href.Replace("%2F", "/");
            set => _href = value;
        }


        private string _href { get; set; }


    }
}
