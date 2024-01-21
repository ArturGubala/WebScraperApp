namespace WebScraperApp.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BaseUrl { get; set; }
        public string CategoriesUrl { get; set; }
        public string[] AdditionalCategoryUrls { get; set; }
        public Selectors Selectors { get; set; }
    }

    public class Selectors
    {
        public CategorySelectors Category { get; set; }
        public ProductSelectors Product { get; set; }
    }

    public class CategorySelectors
    {
        public string All { get; set; }
        public string Name { get; set; }
        public string QueryParams { get; set; }
        public string UrlDataAttributeName { get; set;}
    }

    public class ProductSelectors
    {
        public string All { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Price { get; set; }
        public string NextPage { get; set; }
    }
}
