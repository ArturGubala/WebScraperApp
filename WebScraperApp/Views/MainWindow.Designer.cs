namespace WebScraperApp;

partial class MainWindow
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
        tableLayoutPanel1 = new TableLayoutPanel();
        shops = new ComboBox();
        shopBindingSource = new BindingSource(components);
        button_csv = new Button();
        products = new DataGridView();
        dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
        productBindingSource = new BindingSource(components);
        dataLoadingProgressBar = new ProgressBar();
        tableLayoutPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)shopBindingSource).BeginInit();
        ((System.ComponentModel.ISupportInitialize)products).BeginInit();
        ((System.ComponentModel.ISupportInitialize)productBindingSource).BeginInit();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 2;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        tableLayoutPanel1.Controls.Add(shops, 0, 0);
        tableLayoutPanel1.Controls.Add(button_csv, 1, 0);
        tableLayoutPanel1.Dock = DockStyle.Top;
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 1;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.Size = new Size(1184, 30);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // shops
        // 
        shops.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        shops.DataSource = shopBindingSource;
        shops.DisplayMember = "Name";
        shops.DropDownStyle = ComboBoxStyle.DropDownList;
        shops.FormattingEnabled = true;
        shops.Location = new Point(3, 3);
        shops.Name = "shops";
        shops.Size = new Size(941, 23);
        shops.TabIndex = 0;
        shops.ValueMember = "Id";
        shops.SelectedIndexChanged += shops_SelectedIndexChanged;
        // 
        // button_csv
        // 
        button_csv.Dock = DockStyle.Fill;
        button_csv.Location = new Point(950, 3);
        button_csv.Name = "button_csv";
        button_csv.Size = new Size(231, 24);
        button_csv.TabIndex = 1;
        button_csv.Text = "Generuj CSV";
        button_csv.UseVisualStyleBackColor = true;
        button_csv.Click += button_csv_Click;
        // 
        // products
        // 
        products.AllowUserToAddRows = false;
        products.AllowUserToDeleteRows = false;
        products.AllowUserToOrderColumns = true;
        products.AutoGenerateColumns = false;
        products.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        products.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
        products.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        products.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8 });
        products.DataSource = productBindingSource;
        products.Dock = DockStyle.Fill;
        products.Location = new Point(0, 30);
        products.Name = "products";
        products.ReadOnly = true;
        products.ShowEditingIcon = false;
        products.Size = new Size(1184, 731);
        products.TabIndex = 1;
        // 
        // dataGridViewTextBoxColumn5
        // 
        dataGridViewTextBoxColumn5.DataPropertyName = "Name";
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle1;
        dataGridViewTextBoxColumn5.HeaderText = "Produkt";
        dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
        dataGridViewTextBoxColumn5.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn6
        // 
        dataGridViewTextBoxColumn6.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dataGridViewTextBoxColumn6.DataPropertyName = "Price";
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
        dataGridViewCellStyle2.Format = "N2";
        dataGridViewCellStyle2.NullValue = null;
        dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle2;
        dataGridViewTextBoxColumn6.HeaderText = "Cena";
        dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
        dataGridViewTextBoxColumn6.ReadOnly = true;
        dataGridViewTextBoxColumn6.Width = 59;
        // 
        // dataGridViewTextBoxColumn7
        // 
        dataGridViewTextBoxColumn7.DataPropertyName = "Url";
        dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle3;
        dataGridViewTextBoxColumn7.HeaderText = "Odnośnik";
        dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
        dataGridViewTextBoxColumn7.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn8
        // 
        dataGridViewTextBoxColumn8.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dataGridViewTextBoxColumn8.DataPropertyName = "Category";
        dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle4;
        dataGridViewTextBoxColumn8.HeaderText = "Kategoria";
        dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
        dataGridViewTextBoxColumn8.ReadOnly = true;
        dataGridViewTextBoxColumn8.Width = 82;
        // 
        // productBindingSource
        // 
        productBindingSource.DataSource = typeof(Models.Product);
        // 
        // dataLoadingProgressBar
        // 
        dataLoadingProgressBar.Dock = DockStyle.Bottom;
        dataLoadingProgressBar.Location = new Point(0, 746);
        dataLoadingProgressBar.MarqueeAnimationSpeed = 10;
        dataLoadingProgressBar.Name = "dataLoadingProgressBar";
        dataLoadingProgressBar.Size = new Size(1184, 15);
        dataLoadingProgressBar.TabIndex = 2;
        dataLoadingProgressBar.Visible = false;
        // 
        // MainWindow
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.ActiveBorder;
        ClientSize = new Size(1184, 761);
        Controls.Add(dataLoadingProgressBar);
        Controls.Add(products);
        Controls.Add(tableLayoutPanel1);
        Name = "MainWindow";
        Text = "WebScraper";
        Load += MainWindow_Load;
        tableLayoutPanel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)shopBindingSource).EndInit();
        ((System.ComponentModel.ISupportInitialize)products).EndInit();
        ((System.ComponentModel.ISupportInitialize)productBindingSource).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private ComboBox shops;
    private Button button_csv;
    private DataGridView products;
    private ProgressBar dataLoadingProgressBar;
    private BindingSource shopBindingSource;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn urlDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    private BindingSource productBindingSource;
}