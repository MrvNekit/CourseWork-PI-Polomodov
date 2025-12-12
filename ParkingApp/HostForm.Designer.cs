namespace ParkingApp {
    partial class HostForm {
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Panel panelStats;
        private Panel panelButtons;
        private TabControl tabControl;
        private TabPage tabSpots;
        private TabPage tabBookings;
        private DataGridView dgvSpots;
        private DataGridView dgvBookings;
        private ProgressBar progressBar;

        private Label lblTitle;
        private Label lblWelcome;
        private Label lblAddress;

        private Label lblTotalLabel;
        private Label lblOccupiedLabel;
        private Label lblFreeLabel;
        private Label lblTodayIncomeLabel;
        private Label lblMonthIncomeLabel;

        private Label lblTotalSpots;
        private Label lblOccupiedSpots;
        private Label lblFreeSpots;
        private Label lblTodayIncome;
        private Label lblMonthIncome;

        private Button btnAddSpot;
        private Button btnToggleStatus;
        private Button btnReport;
        private Button btnSettings;
        private Button btnRefresh;

        private Label lblLastUpdate;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();

            // ===== ОСНОВНЫЕ НАСТРОЙКИ =====
            this.Size = new Size(1000,650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI",9F);
            this.BackColor = Color.FromArgb(245,248,250);

            // ===== ПАНЕЛЬ ЗАГОЛОВКА =====
            this.panelHeader = new Panel();
            this.lblAddress = new Label();
            this.lblWelcome = new Label();
            this.lblTitle = new Label();

            panelHeader.BackColor = Color.FromArgb(52,152,219);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 90;
            panelHeader.Padding = new Padding(20);

            lblTitle.Text = "🏢 УПРАВЛЕНИЕ ПАРКИНГОМ";
            lblTitle.Font = new Font("Segoe UI",16F,FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20,15);
            lblTitle.AutoSize = true;

            lblWelcome.Text = "👤 Владелец: ";
            lblWelcome.Font = new Font("Segoe UI",11F,FontStyle.Bold);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(20,50);
            lblWelcome.AutoSize = true;

            lblAddress.Text = "📍 Адрес: ";
            lblAddress.Font = new Font("Segoe UI",10F);
            lblAddress.ForeColor = Color.FromArgb(230,230,230);
            lblAddress.Location = new Point(300,52);
            lblAddress.AutoSize = true;

            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblWelcome);
            panelHeader.Controls.Add(lblAddress);

            // ===== ПАНЕЛЬ СТАТИСТИКИ =====
            this.panelStats = new Panel();
            this.progressBar = new ProgressBar();
            this.lblMonthIncome = new Label();
            this.lblTodayIncome = new Label();
            this.lblFreeSpots = new Label();
            this.lblOccupiedSpots = new Label();
            this.lblTotalSpots = new Label();
            this.lblMonthIncomeLabel = new Label();
            this.lblTodayIncomeLabel = new Label();
            this.lblFreeLabel = new Label();
            this.lblOccupiedLabel = new Label();
            this.lblTotalLabel = new Label();

            panelStats.BackColor = Color.White;
            panelStats.Dock = DockStyle.Top;
            panelStats.Height = 120;
            panelStats.Padding = new Padding(20);

            // Настройка меток статистики
            SetupStatLabels();

            // Прогресс-бар
            progressBar.Location = new Point(600,40);
            progressBar.Size = new Size(250,25);
            progressBar.Style = ProgressBarStyle.Continuous;

            // ===== ПАНЕЛЬ КНОПОК =====
            this.panelButtons = new Panel();
            this.btnRefresh = new Button();
            this.btnSettings = new Button();
            this.btnReport = new Button();
            this.btnToggleStatus = new Button();
            this.btnAddSpot = new Button();

            panelButtons.BackColor = Color.FromArgb(236,240,241);
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Height = 60;
            panelButtons.Padding = new Padding(10);

            // Настройка кнопок
            SetupButtons();

            // ===== ВКЛАДКИ =====
            this.tabControl = new TabControl();
            this.tabSpots = new TabPage();
            this.tabBookings = new TabPage();
            this.dgvSpots = new DataGridView();
            this.dgvBookings = new DataGridView();

            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Segoe UI",9F,FontStyle.Bold);
            tabControl.ItemSize = new Size(120,30);

            // Вкладка парковочных мест
            tabSpots.Text = "🚗 Парковочные места";
            tabSpots.BackColor = Color.White;

            // Вкладка бронирований
            tabBookings.Text = "📅 Бронирования";
            tabBookings.BackColor = Color.White;

            // Таблица парковочных мест
            dgvSpots.Dock = DockStyle.Fill;
            dgvSpots.BackgroundColor = Color.White;
            dgvSpots.BorderStyle = BorderStyle.None;
            dgvSpots.RowHeadersVisible = false;
            dgvSpots.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSpots.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSpots.ReadOnly = true;

            // Столбцы для мест
            string[] spotColumns = { "Место","Зона","Тариф","Статус","Автомобиль","Доход" };
            foreach (string col in spotColumns)
                dgvSpots.Columns.Add(col,col);

            // Таблица бронирований
            dgvBookings.Dock = DockStyle.Fill;
            dgvBookings.BackgroundColor = Color.White;
            dgvBookings.BorderStyle = BorderStyle.None;
            dgvBookings.RowHeadersVisible = false;
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBookings.ReadOnly = true;

            // Столбцы для бронирований
            string[] bookingColumns = { "ID","Место","Клиент","Авто","Начало","Окончание","Сумма","Статус" };
            foreach (string col in bookingColumns)
                dgvBookings.Columns.Add(col,col);

            // ===== СТАТУС БАР =====
            this.lblLastUpdate = new Label();

            lblLastUpdate.Dock = DockStyle.Bottom;
            lblLastUpdate.Height = 25;
            lblLastUpdate.TextAlign = ContentAlignment.MiddleRight;
            lblLastUpdate.Padding = new Padding(0,0,20,0);
            lblLastUpdate.Font = new Font("Segoe UI",8F);
            lblLastUpdate.ForeColor = Color.Gray;
            lblLastUpdate.Text = "🔄 Обновлено: --:--:--";

            // ===== СОБИРАЕМ ФОРМУ =====

            // Добавляем таблицы на вкладки
            tabSpots.Controls.Add(dgvSpots);
            tabBookings.Controls.Add(dgvBookings);

            // Добавляем вкладки
            tabControl.Controls.Add(tabSpots);
            tabControl.Controls.Add(tabBookings);

            // Собираем форму
            this.Controls.Add(tabControl);
            this.Controls.Add(panelButtons);
            this.Controls.Add(panelStats);
            this.Controls.Add(panelHeader);
            this.Controls.Add(lblLastUpdate);
        }

        private void SetupStatLabels() {
            int x = 20, y = 20;
            int labelWidth = 120, valueWidth = 100;

            CreateStatLabel(ref lblTotalLabel,"Всего мест:",x,y,labelWidth);
            CreateStatLabel(ref lblTotalSpots,"0",x + labelWidth,y,valueWidth,true);

            CreateStatLabel(ref lblOccupiedLabel,"Занято:",x + 250,y,labelWidth);
            CreateStatLabel(ref lblOccupiedSpots,"0",x + 250 + labelWidth,y,valueWidth,true);

            CreateStatLabel(ref lblFreeLabel,"Свободно:",x + 480,y,labelWidth);
            CreateStatLabel(ref lblFreeSpots,"0",x + 480 + labelWidth,y,valueWidth,true);

            y += 35;
            CreateStatLabel(ref lblTodayIncomeLabel,"Доход за день:",x,y,labelWidth);
            CreateStatLabel(ref lblTodayIncome,"0 ₽",x + labelWidth,y,valueWidth + 50,true);

            CreateStatLabel(ref lblMonthIncomeLabel,"Доход за месяц:",x + 250,y,labelWidth);
            CreateStatLabel(ref lblMonthIncome,"0 ₽",x + 250 + labelWidth,y,valueWidth + 50,true);
        }

        private void CreateStatLabel(ref Label label,string text,int x,int y,int width,bool isValue = false) {
            label = new Label();
            label.Text = text;
            label.Location = new Point(x,y);
            label.Font = isValue ? new Font("Segoe UI",10F,FontStyle.Bold) :
                                   new Font("Segoe UI",9F);
            label.ForeColor = isValue ? Color.FromArgb(52,152,219) :
                                        Color.FromArgb(52,73,94);
            label.Size = new Size(width,25);
            label.TextAlign = isValue ? ContentAlignment.MiddleRight :
                                         ContentAlignment.MiddleLeft;
            panelStats.Controls.Add(label);
        }

        private void SetupButtons() {
            int x = 10;
            int buttonWidth = 140;
            int buttonHeight = 38;

            btnAddSpot = CreateButton("➕ Добавить место",x,10,buttonWidth,buttonHeight);
            btnToggleStatus = CreateButton("🔄 Изменить статус",x + 150,10,buttonWidth,buttonHeight);
            btnReport = CreateButton("📊 Отчет",x + 300,10,buttonWidth,buttonHeight);
            btnSettings = CreateButton("⚙️ Настройки",x + 450,10,buttonWidth,buttonHeight);
            btnRefresh = CreateButton("🔄 Обновить",x + 600,10,buttonWidth,buttonHeight);

            // Изначально выключаем кнопку изменения статуса
            btnToggleStatus.Enabled = false;

            panelButtons.Controls.Add(btnAddSpot);
            panelButtons.Controls.Add(btnToggleStatus);
            panelButtons.Controls.Add(btnReport);
            panelButtons.Controls.Add(btnSettings);
            panelButtons.Controls.Add(btnRefresh);
        }

        private Button CreateButton(string text,int x,int y,int width,int height) {
            var btn = new Button();
            btn.Text = text;
            btn.Location = new Point(x,y);
            btn.Size = new Size(width,height);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(52,152,219);
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI",9F,FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            return btn;
        }
    }
}