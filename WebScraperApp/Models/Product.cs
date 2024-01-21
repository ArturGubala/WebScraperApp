using System.ComponentModel;

namespace WebScraperApp.Models
{
    public class Product
    {
        [DisplayName("Produkt")]
        public string Name { get; set; }
        [DisplayName("Cena")]
        public double Price { get; set; }
        [DisplayName("Odnośnik")]
        public string Url { get; set; }
        [DisplayName("Kategoria")]
        public string Category { get; set; }
    }
}
