using WebScraperApp.Models;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using System.Text.RegularExpressions;
using System.Net;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace WebScraperApp.Services
{
    public class WebScraperService
    {
        private Shop _shop;
        private HtmlWeb _htmlWeb;

        public WebScraperService()
        {
            _htmlWeb = new HtmlWeb();
        }

        public void AssignShop(Shop shop) => _shop = shop;

        public async IAsyncEnumerable<IEnumerable<Product>> GetProductsAsync()
        {
            List<Product> products = new List<Product>();

            IEnumerable<string> categoriesUrls = await PrepareCategoriesUrlsAsync();

            foreach (string categoryUrl in categoriesUrls)
            {
               yield return await GetCategoryProducts(categoryUrl);
            }
        }

        private async Task<IEnumerable<string>> PrepareCategoriesUrlsAsync()
        {
            List<string> categoriesUrls = new List<string>();

            HtmlDocument categoriesPageSource = await GetPageSourceAsync(_shop.CategoriesUrl);
            IList<HtmlNode> categoriesHtmlElements = categoriesPageSource.QuerySelectorAll(_shop.Selectors.Category.All);

            foreach (HtmlNode categoryNode in categoriesHtmlElements)
            {
                string categoryAttributeValue = categoryNode
                    .Attributes
                    .FirstOrDefault(a => a.Name.ToLower() == _shop.Selectors.Category.UrlDataAttributeName)?
                    .Value;
                string categoryUrl = categoryAttributeValue.Contains(_shop.BaseUrl) ?
                    $"{categoryAttributeValue}{_shop.Selectors.Category.QueryParams}" :
                    $"{_shop.BaseUrl}{categoryAttributeValue}{_shop.Selectors.Category.QueryParams}";
                categoriesUrls.Add(categoryUrl);
            }

            if (_shop.AdditionalCategoryUrls != null)
            {
                categoriesUrls.AddRange(_shop.AdditionalCategoryUrls);
            }
            return categoriesUrls;
        }

        private async Task<HtmlDocument> GetPageSourceAsync(string url)
        {
            return await _htmlWeb.LoadFromWebAsync(url);
        }

        private double ExtractPrice(string text)
        {
            string priceRegexPattern = "\\d{1,6}( |.\\d{1,3})*(\\d)?";
            double price = 0;
            Match match = Regex.Match(text, priceRegexPattern);

            if (match.Success)
            {
                string matchedValue = match.Value;
                double.TryParse(matchedValue, out price);
            }

            return price;
        }

        private async Task<IEnumerable<Product>> GetCategoryProducts(string categoryUrl)
        {
            List<Product> products = new List<Product>();
            HtmlDocument categoryPageSource = await GetPageSourceAsync(categoryUrl);
            IList<HtmlNode> productsHtmlElements = categoryPageSource.QuerySelectorAll(_shop.Selectors.Product.All);
            HtmlNode nextPageHtmlElement = categoryPageSource.QuerySelector(_shop.Selectors.Product.NextPage);
            string categoryName = WebUtility.HtmlDecode(categoryPageSource.QuerySelector(_shop.Selectors.Category.Name)?.InnerText);

            do
            {
                foreach (HtmlNode productHtmlElement in productsHtmlElements)
                {
                    Product product = GetProduct(productHtmlElement);
                    product.Category = categoryName;
                    products.Add(product);
                }

                if (nextPageHtmlElement != null)
                {
                    string nextPageUrl = nextPageHtmlElement
                        .Attributes
                        .FirstOrDefault(a => a.Name.ToLower() == "href")?
                        .Value;
                    categoryPageSource = nextPageUrl.Contains(_shop.BaseUrl) ?
                        await GetPageSourceAsync(nextPageUrl) :
                        await GetPageSourceAsync($"{_shop.BaseUrl}{nextPageUrl}");
                    productsHtmlElements = categoryPageSource.QuerySelectorAll(_shop.Selectors.Product.All);
                    nextPageHtmlElement = categoryPageSource.QuerySelector(_shop.Selectors.Product.NextPage);
                }
            }
            while (nextPageHtmlElement != null);

            return products;
        }

        private Product GetProduct(HtmlNode productHtmlElement) 
        {
            string productName = WebUtility.HtmlDecode(productHtmlElement.QuerySelector(_shop.Selectors.Product.Name).InnerText);
            string productAttributeValue = productHtmlElement
                .QuerySelector(_shop.Selectors.Product.Url)
                .Attributes.FirstOrDefault(a => a.Name.ToLower() == "href")?
                .Value;
            string productUrl = productAttributeValue.Contains(_shop.BaseUrl) ?
                $"{productAttributeValue}" :
                $"{_shop.BaseUrl}{productAttributeValue}";
            double productPrice = ExtractPrice(productHtmlElement.QuerySelector(_shop.Selectors.Product.Price).InnerText);

            return new Product()
            {
                Name = productName,
                Price = productPrice,
                Url = productUrl
            };
        }

    }
}
