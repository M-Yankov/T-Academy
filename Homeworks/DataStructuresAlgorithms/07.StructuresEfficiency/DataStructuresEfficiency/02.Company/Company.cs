namespace CompanyTask
{
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Company
    {
        public Company()
        {
            this.Articles = new OrderedMultiDictionary<decimal, Article>(true);
        }

        public OrderedMultiDictionary<decimal, Article> Articles { get; set; }

        public IEnumerable<Article> GetArticlesInRange(decimal minPrice, decimal maxPrice)
        {
            IList<Article> result = new List<Article>();
            if (this.Articles.Count == 0)
            {
                return result;
            }

            foreach (var item in this.Articles.FindAll(x => minPrice <= x.Key && x.Key <= maxPrice))
            {
                item.Value.ToList().ForEach(art => result.Add(art));
            }

            return result;
        }
    }
}
