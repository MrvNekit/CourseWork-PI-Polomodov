using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ParkingApp {
    public partial class HostForm : Form {
        private User currentUser;
        private List<ParkingSpot> spots = new List<ParkingSpot>();
        private List<Booking> bookings = new List<Booking>();
        private System.Windows.Forms.Timer timer;
        private Random rnd = new Random();

        public HostForm(User user) {
            InitializeComponent();
            currentUser = user;

            // Привязка обработчиков
            if (dgvSpots != null)
                dgvSpots.SelectionChanged += dgvSpots_SelectionChanged;

            if (btnToggleStatus != null)
                btnToggleStatus.Click += btnToggleStatus_Click;

            if (btnAddSpot != null)
                btnAddSpot.Click += btnAddSpot_Click;

            if (btnReport != null)
                btnReport.Click += btnReport_Click;

            if (btnSettings != null)
                btnSettings.Click += btnSettings_Click;

            if (btnRefresh != null)
                btnRefresh.Click += (s,e) => UpdateLiveData();

            InitializeData();
            SetupUI();
            StartTimer();
        }

        private void InitializeData() {
            spots = new List<ParkingSpot>
            {
                new ParkingSpot
                {
                    Id = 1,
                    SpotNumber = "A-01",
                    Zone = "A",
                    HourlyRate = 50,
                    IsOccupied = true,
                    CarNumber = "A123BC",
                    DailyIncome = 250
                },
                new ParkingSpot
                {
                    Id = 2,
                    SpotNumber = "A-02",
                    Zone = "A",
                    HourlyRate = 50,
                    IsOccupied = false,
                    DailyIncome = 0
                },
                new ParkingSpot
                {
                    Id = 3,
                    SpotNumber = "B-01",
                    Zone = "B",
                    HourlyRate = 70,
                    IsOccupied = true,
                    CarNumber = "B456DE",
                    DailyIncome = 350
                },
                new ParkingSpot
                {
                    Id = 4,
                    SpotNumber = "VIP-01",
                    Zone = "VIP",
                    HourlyRate = 150,
                    IsOccupied = true,
                    CarNumber = "VIP001",
                    DailyIncome = 800
                }
            };

            bookings = new List<Booking>
            {
                new Booking
                {
                    Id = 1,
                    ParkingSpotName = "A-01",
                    UserName = "Иван Петров",
                    UserCar = "A123BC",
                    StartTime = DateTime.Now.AddHours(-3),
                    EndTime = DateTime.Now.AddHours(1),
                    TotalPrice = 250,
                    Status = "Активно"
                },
                new Booking
                {
                    Id = 2,
                    ParkingSpotName = "B-01",
                    UserName = "Анна Смирнова",
                    UserCar = "B456DE",
                    StartTime = DateTime.Now.AddHours(-2),
                    EndTime = DateTime.Now.AddHours(2),
                    TotalPrice = 350,
                    Status = "Активно"
                }
            };
        }

        private void SetupUI() {
            this.Text = $"🏢 {currentUser.CompanyName} - Управление паркингом";
            if (lblWelcome != null) lblWelcome.Text = $"👤 Владелец: {currentUser.Name}";
            if (lblAddress != null) lblAddress.Text = $"📍 {currentUser.CompanyAddress}";

            UpdateDashboard();
            LoadParkingSpots();
            LoadBookings();
        }

        private void StartTimer() {
            timer = new System.Windows.Forms.Timer { Interval = 30000 };
            timer.Tick += (s,e) => UpdateLiveData();
            timer.Start();
        }

        private void UpdateDashboard() {
            if (spots == null) return;

            int total = spots.Count;
            int occupied = spots.Count(s => s.IsOccupied);
            decimal incomeToday = spots.Sum(s => s.DailyIncome);
            decimal incomeMonth = incomeToday * 30;

            if (lblTotalSpots != null) lblTotalSpots.Text = total.ToString();
            if (lblOccupiedSpots != null) lblOccupiedSpots.Text = occupied.ToString();
            if (lblFreeSpots != null) lblFreeSpots.Text = (total - occupied).ToString();
            if (lblTodayIncome != null) lblTodayIncome.Text = $"{incomeToday:C}";
            if (lblMonthIncome != null) lblMonthIncome.Text = $"{incomeMonth:C}";

            if (progressBar != null) {
                int occupancyPercent = total > 0 ? occupied * 100 / total : 0;
                progressBar.Value = occupancyPercent;
                progressBar.ForeColor = occupancyPercent > 80 ? Color.Red :
                                       occupancyPercent > 60 ? Color.Orange : Color.Green;
            }
        }

        private void LoadParkingSpots() {
            if (dgvSpots == null) return;

            dgvSpots.Rows.Clear();
            foreach (var spot in spots.OrderBy(s => s.SpotNumber)) {
                int idx = dgvSpots.Rows.Add(
                    spot.SpotNumber,
                    spot.Zone,
                    $"{spot.HourlyRate:C}/час",
                    spot.IsOccupied ? "🟥 Занято" : "🟩 Свободно",
                    spot.IsOccupied ? spot.CarNumber ?? "" : "-",
                    $"{spot.DailyIncome:C}"
                );

                dgvSpots.Rows[idx].DefaultCellStyle.BackColor = spot.IsOccupied ?
                    Color.FromArgb(255,240,240) : Color.FromArgb(240,255,240);
            }
        }
        private void LoadBookings() {
            if (dgvBookings == null) return;

            dgvBookings.Rows.Clear();
            foreach (var booking in bookings.OrderByDescending(b => b.StartTime)) {
                dgvBookings.Rows.Add(
                    booking.Id,
                    booking.ParkingSpotName,
                    booking.UserName,
                    booking.UserCar,
                    booking.StartTime.ToString("dd.MM HH:mm"),
                    booking.EndTime.ToString("dd.MM HH:mm"),
                    $"{booking.TotalPrice:C}",
                    booking.Status
                );
            }
        }

        private void UpdateLiveData() {
            if (spots == null) return;

            foreach (var spot in spots.Where(s => s.IsOccupied))
                spot.DailyIncome += spot.HourlyRate / 2;

            UpdateDashboard();
            LoadParkingSpots();

            if (lblLastUpdate != null)
                lblLastUpdate.Text = $"🔄 {DateTime.Now:HH:mm:ss}";
        }
        private void btnAddSpot_Click(object sender,EventArgs e) {
            string zone = "A";
            if (spots.Count % 3 == 1) zone = "B";
            if (spots.Count % 3 == 2) zone = "C";

            var spot = new ParkingSpot {
                Id = spots.Max(s => s.Id) + 1,
                SpotNumber = $"{zone}-{(spots.Count(s => s.Zone == zone) + 1):D2}",
                Zone = zone,
                HourlyRate = zone == "VIP" ? 150 : zone == "B" ? 70 : 50,
                IsOccupied = false,
                IsActive = true,
                DailyIncome = 0
            };

            spots.Add(spot);
            LoadParkingSpots();
            UpdateDashboard();

            MessageBox.Show($"Место {spot.SpotNumber} добавлено!","Успех",
                MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnToggleStatus_Click(object sender,EventArgs e) {
            if (dgvSpots == null || dgvSpots.SelectedRows.Count == 0) {
                MessageBox.Show("Выберите парковочное место","Внимание",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            try {
                string spotNumber = dgvSpots.SelectedRows[0].Cells[0].Value.ToString();
                var spot = spots.FirstOrDefault(s => s.SpotNumber == spotNumber);

                if (spot == null) return;

                spot.IsOccupied = !spot.IsOccupied;

                if (spot.IsOccupied) {
                    spot.CarNumber = $"{spot.Zone}{rnd.Next(100,999)}{(char)('A' + rnd.Next(0,26))}";

                    bookings.Add(new Booking {
                        Id = bookings.Max(b => b.Id) + 1,
                        ParkingSpotName = spot.SpotNumber,
                        UserName = "Клиент",
                        UserCar = spot.CarNumber,
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now.AddHours(3),
                        TotalPrice = spot.HourlyRate * 3,
                        Status = "Активно"
                    });
                }
                else {
                    spot.CarNumber = null;

                    var activeBooking = bookings.FirstOrDefault(b =>
                        b.ParkingSpotName == spotNumber && b.Status == "Активно");

                    if (activeBooking != null)
                        activeBooking.Status = "Завершено";
                }

                LoadParkingSpots();
                LoadBookings();
                UpdateDashboard();

                MessageBox.Show($"Статус места {spotNumber} изменен","Успех",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка: {ex.Message}","Ошибка",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnReport_Click(object sender,EventArgs e) {
            if (spots == null) return;

            string report = $"📊 ОТЧЕТ ПАРКИНГА\n" +
                          $"📅 {DateTime.Now:dd.MM.yyyy}\n\n" +
                          $"🏢 {currentUser.CompanyName}\n" +
                          $"📍 {currentUser.CompanyAddress}\n\n" +
                          $"Всего мест: {spots.Count}\n" +
                          $"Занято: {spots.Count(s => s.IsOccupied)}\n" +
                          $"Доход сегодня: {spots.Sum(s => s.DailyIncome):C}\n" +
                          $"Общий доход за месяц: {spots.Sum(s => s.DailyIncome) * 30:C}";

            MessageBox.Show(report,"📄 Финансовый отчет",
                MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnSettings_Click(object sender,EventArgs e) {
            try {
                decimal avgRate = spots.Count > 0 ? spots.Average(s => s.HourlyRate) : 50;

                using (var dlg = new RateDialog(avgRate)) {
                    if (dlg.ShowDialog() == DialogResult.OK) {
                        foreach (var spot in spots)
                            spot.HourlyRate = dlg.NewRate;

                        LoadParkingSpots();
                        UpdateDashboard();
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка: {ex.Message}","Ошибка",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void dgvSpots_SelectionChanged(object sender,EventArgs e) {
            if (btnToggleStatus != null && dgvSpots != null)
                btnToggleStatus.Enabled = dgvSpots.SelectedRows.Count > 0;
        }

        private void HostForm_FormClosing(object sender,FormClosingEventArgs e) {
            timer?.Stop();
        }
    }
    public class RateDialog : Form {
        public decimal NewRate { get; private set; }

        public RateDialog(decimal currentRate) {
            InitializeComponent(currentRate);
        }

        private void InitializeComponent(decimal currentRate) {
            this.Size = new Size(300,180);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Настройка тарифов";
            this.Font = new Font("Segoe UI",9);

            var lbl = new Label {
                Text = "Установить тариф:",
                Location = new Point(20,20),
                Size = new Size(250,25)
            };

            var numRate = new NumericUpDown {
                Location = new Point(20,50),
                Width = 100,
                Value = currentRate,
                Minimum = 10,
                Maximum = 500,
                DecimalPlaces = 0
            };

            var btnOk = new Button {
                Text = "Применить",
                Location = new Point(70,100),
                Size = new Size(75,30),
                DialogResult = DialogResult.OK
            };

            var btnCancel = new Button {
                Text = "Отмена",
                Location = new Point(155,100),
                Size = new Size(75,30),
                DialogResult = DialogResult.Cancel
            };

            btnOk.Click += (s,e) => { NewRate = numRate.Value; };

            this.Controls.AddRange(new Control[] { lbl,numRate,btnOk,btnCancel });
        }
private void HostForm_Load(object sender,EventArgs e) {

            }
       }
  }



