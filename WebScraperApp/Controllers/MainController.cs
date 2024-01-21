using Microsoft.Extensions.Configuration;
using System.Text;
using WebScraperApp.Models;
using WebScraperApp.Services;

namespace WebScraperApp.Controllers
{
    public class MainController
    {
        public event EventHandler DataUpdated;
        private List<Shop> _shops;
        private WebScraperService _webScraperService;
        private GenerateFileService _generateFileService;

        public MainController() 
        {
            _shops = Program.Configuration.GetSection("shops").Get<List<Shop>>();
            _webScraperService = new WebScraperService();
            _generateFileService = new GenerateFileService();
        }

        public void InitializeComboBox(ComboBox comboBox, BindingSource bindingSourceComboBox)
        {
            foreach (Shop shop in _shops) 
            {
                bindingSourceComboBox.Add(shop);
            }
        }

        public async Task HandleComboBoxSelectionAsync(int shopId, BindingSource bindingSourceDataGrid)
        {
            if (shopId <= 0)
            {
                return;
            }

            Shop shop = _shops.First(s => s.Id == shopId);
            _webScraperService.AssignShop(shop);

           await foreach (IEnumerable<Product> products in _webScraperService.GetProductsAsync())
            {
                foreach (Product product in products)
                {
                    bindingSourceDataGrid.Add(product);
                }
            }
        }

        public async Task HandleButtonCsvClickAsync(IEnumerable<Product> products)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.Title = "Zapisz plik z danymi";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                string content = PrepareFileContent(products);
                try
                {
                    await _generateFileService.GenerateCsvFileAsync(filePath, content);

                    MessageBox.Show("Pomyślnie zapisano plik", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas zapisu: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string PrepareFileContent(IEnumerable<Product> products)
        {
            StringBuilder csvContent = new StringBuilder();
            csvContent.AppendLine("Nazwa|Cena|Odnosnik|Kategoria");

            foreach (var product in products)
            {
                csvContent.AppendLine($"{product.Name}|{product.Price}|{product.Url}|{product.Category}");
            }

            return csvContent.ToString();
        }
    }
}
