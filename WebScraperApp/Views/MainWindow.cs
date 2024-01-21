using WebScraperApp.Controllers;
using WebScraperApp.Models;

namespace WebScraperApp;

public partial class MainWindow : Form
{
    private MainController _mainController;

    public MainWindow(MainController mainController)
    {
        InitializeComponent();
        _mainController = mainController;
    }

    private void MainWindow_Load(object sender, EventArgs e)
    {
        _mainController.InitializeComboBox(shops, shopBindingSource);
    }

    private async void shops_SelectedIndexChanged(object sender, EventArgs e)
    {
        int.TryParse(shops.SelectedValue?.ToString(), out int id);
        ShowLoading();
        productBindingSource.Clear();
        await _mainController.HandleComboBoxSelectionAsync(id, productBindingSource);
        HideLoading();
    }

    private void ShowLoading()
    {
        dataLoadingProgressBar.Visible = true;
        dataLoadingProgressBar.Style = ProgressBarStyle.Marquee;
    }

    private void HideLoading()
    {
        dataLoadingProgressBar.Visible = false;
        dataLoadingProgressBar.Style = ProgressBarStyle.Blocks;
    }

    private async void button_csv_Click(object sender, EventArgs e)
    {
        await _mainController.HandleButtonCsvClickAsync((IEnumerable<Product>)productBindingSource.List);
    }
}