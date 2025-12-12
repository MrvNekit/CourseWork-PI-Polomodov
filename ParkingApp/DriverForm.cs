using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ParkingApp {
    public partial class DriverForm : Form {
        private List<ParkingSpot> parkingSpots = new List<ParkingSpot>();
        private List<Booking> bookings = new List<Booking>();
        private System.Windows.Forms.Timer notificationTimer;
        private System.Windows.Forms.Timer statusTimer;
        private Random random = new Random();
        private User currentUser;
        private Color primaryColor = Color.FromArgb(52,152,219);
        private Color secondaryColor = Color.FromArgb(236,240,241);
        private Color accentColor = Color.FromArgb(46,204,113);
        private Color dangerColor = Color.FromArgb(231,76,60);

        public DriverForm(User user) {
            InitializeComponent();
            currentUser = user;
            InitializeParkingData();
            InitializeBookingData();
            SetupEventHandlers();
            StartTimers();
            UpdateUserInfo();
            ApplyStyles();
            ShowParkingPanel(); 
            UpdateBalanceDisplay();
        }
        private void UpdateBalanceDisplay() {
            labelBalance.Text = $"Баланс: {currentUser.Balance} ₽";
        }

        private void buttonAddBalance_Click(object sender,EventArgs e) {
           
            TopUpForm topUpForm = new TopUpForm(currentUser);

            if (topUpForm.ShowDialog() == DialogResult.OK) {
                decimal amount = topUpForm.Amount; 
                currentUser.Balance += amount;
                UpdateBalanceDisplay();
                MessageBox.Show($"Баланс пополнен на {amount} ₽. Текущий баланс: {currentUser.Balance} ₽");
            }
        }

        private void buttonPay_Click(object sender,EventArgs e) {
            
            decimal amount = 200;
            if (currentUser.Balance >= amount) {
                currentUser.Balance -= amount;
                UpdateBalanceDisplay();
                MessageBox.Show($"Оплачено {amount} ₽. Остаток: {currentUser.Balance} ₽");
            }
            else {
                MessageBox.Show("Недостаточно средств на балансе!");
            }
        }
        public DriverForm() : this(CreateTestUser()) {
        }
        private static User CreateTestUser() {
            return new User {
                FullName = "Иван Петров",
                Email = "ivan@example.com",
                Phone = "+7 (123) 456-78-90",
                CarModel = "Toyota Camry",
                CarNumber = "А123ВС777",
                RegistrationDate = DateTime.Now.AddMonths(-3)
            };
        }
        private void InitializeParkingData() {
            parkingSpots = new List<ParkingSpot>
            {
                new ParkingSpot {
                    Id = 1,
                    Name = "Центральная парковка",
                    Address = "ул. Центральная, 1",
                    PricePerHour = 100,
                    TotalSpots = 50,
                    AvailableSpots = 15,
                    Description = "Крытая охраняемая парковка в центре города. Камеры наблюдения, охрана 24/7.",
                    Distance = 0.5,
                    Rating = 4.5
                },
                new ParkingSpot {
                    Id = 2,
                    Name = "Торговый центр 'Метро'",
                    Address = "пр. Ленина, 10",
                    PricePerHour = 80,
                    TotalSpots = 120,
                    AvailableSpots = 45,
                    Description = "Парковка у торгового центра. Первые 2 часа бесплатно при покупке.",
                    Distance = 1.2,
                    Rating = 4.2
                },
                new ParkingSpot {
                    Id = 3,
                    Name = "Аэропорт",
                    Address = "ш. Аэропортовское, 25",
                    PricePerHour = 150,
                    TotalSpots = 300,
                    AvailableSpots = 120,
                    Description = "Долгосрочная парковка у аэропорта. Крытые и открытые места.",
                    Distance = 8.5,
                    Rating = 4.7
                },
                new ParkingSpot {
                    Id = 4,
                    Name = "Бизнес-центр 'Плаза'",
                    Address = "ул. Деловая, 15",
                    PricePerHour = 120,
                    TotalSpots = 80,
                    AvailableSpots = 12,
                    Description = "Подземная парковка бизнес-центра. Зарядка для электромобилей.",
                    Distance = 2.3,
                    Rating = 4.8
                }
            };
        }

        private void InitializeBookingData() {
            bookings = new List<Booking>
            {
                new Booking {
                    Id = 1,
                    ParkingSpotName = "Центральная парковка",
                    StartTime = DateTime.Now.AddHours(-2),
                    EndTime = DateTime.Now.AddHours(2),
                    TotalPrice = 400,
                    Status = "Активно"
                },
                new Booking {
                    Id = 2,
                    ParkingSpotName = "Торговый центр 'Метро'",
                    StartTime = DateTime.Now.AddDays(-1),
                    EndTime = DateTime.Now.AddDays(-1).AddHours(3),
                    TotalPrice = 240,
                    Status = "Завершено"
                }
            };
        }

        private void SetupEventHandlers() {
            btnSearchParkings.Click += (s,e) => ShowParkingPanel();
            btnMyBookings.Click += (s,e) => ShowBookingsPanel();
            btnProfile.Click += (s,e) => ShowProfilePanel();
            btnLogout.Click += (s,e) => Logout();
        }

        private void StartTimers() {
            
            statusTimer = new System.Windows.Forms.Timer();
            statusTimer.Interval = 5000; 
            statusTimer.Tick += (s,e) => UpdateStatus();
            statusTimer.Start();

            notificationTimer = new System.Windows.Forms.Timer();
            notificationTimer.Interval = 30000; 
            notificationTimer.Tick += (s,e) => CheckNotifications();
            notificationTimer.Start();
        }

        private void UpdateUserInfo() {
            if (currentUser != null) {
                lblUserName.Text = currentUser.FullName ?? "Не указано";
                lblCarInfo.Text = $"{currentUser.CarModel ?? "Не указана"} ({currentUser.CarNumber ?? "Не указан"})";
            }
            else {
                lblUserName.Text = "Гость";
                lblCarInfo.Text = "Авто не указано";
            }
        }

        private void UpdateStatus() {
            
            foreach (var spot in parkingSpots) {
                spot.AvailableSpots = random.Next(5,spot.TotalSpots);
            }

            if (panelParkings.Visible)
                LoadParkingSpots();

            lblStatus.Text = $"Обновлено: {DateTime.Now:HH:mm:ss}";
        }

        private void CheckNotifications() {
           
            var activeBooking = bookings.FirstOrDefault(b => b.Status == "Активно");
            if (activeBooking != null && activeBooking.EndTime.Subtract(DateTime.Now).TotalMinutes < 30) {
                ShowNotification($"Ваше бронирование на {activeBooking.ParkingSpotName} истекает через " +
                               $"{(int)activeBooking.EndTime.Subtract(DateTime.Now).TotalMinutes} минут");
            }
        }

        private void ShowNotification(string message) {
            var notificationForm = new Form {
                Size = new Size(400,100),
                StartPosition = FormStartPosition.Manual,
                Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - 420,
                                   Screen.PrimaryScreen.WorkingArea.Bottom - 120),
                FormBorderStyle = FormBorderStyle.None,
                BackColor = primaryColor,
                ShowInTaskbar = false
            };

            var label = new Label {
                Text = message,
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI",10)
            };

            notificationForm.Controls.Add(label);
            notificationForm.Show();

            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 5000;
            timer.Tick += (s,e) => { notificationForm.Close(); timer.Stop(); };
            timer.Start();
        }

        private void ApplyStyles() {
            
            this.BackColor = Color.White;

            panelSidebar.BackColor = Color.FromArgb(25,25,25);

            var navButtons = new[] { btnSearchParkings,btnMyBookings,btnProfile };
            foreach (var btn in navButtons) {
                btn.BackColor = Color.Transparent;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI",10,FontStyle.Regular);
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Padding = new Padding(20,0,0,0);
                btn.Height = 50;

                btn.MouseEnter += (s,e) => {
                    btn.BackColor = Color.FromArgb(52,152,219);
                };
                btn.MouseLeave += (s,e) => {
                    if (btn != GetActiveNavButton())
                        btn.BackColor = Color.Transparent;
                };
            }

            btnLogout.BackColor = dangerColor;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.ForeColor = Color.White;
            btnLogout.Font = new Font("Segoe UI",10,FontStyle.Bold);

            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Segoe UI",14,FontStyle.Bold);

            lblUserName.Font = new Font("Segoe UI",12,FontStyle.Bold);
            lblCarInfo.Font = new Font("Segoe UI",10);

            lblStatus.Font = new Font("Segoe UI",9);
            lblStatus.ForeColor = Color.Gray;
        }

        private Button GetActiveNavButton() {
            if (panelParkings.Visible) return btnSearchParkings;
            if (panelBookings.Visible) return btnMyBookings;
            if (panelProfile.Visible) return btnProfile;
            return btnSearchParkings;
        }

        private void ShowParkingPanel() {
           
            panelParkings.Visible = true;
            panelBookings.Visible = false;
            panelProfile.Visible = false;

           
            UpdateNavButtonsStyle(btnSearchParkings);

           
            LoadParkingSpots();

            lblMainTitle.Text = "Поиск парковок";
            lblStatus.Text = "Поиск доступных парковок...";
        }

        private void LoadParkingSpots() {
            panelParkings.Controls.Clear();

            if (!parkingSpots.Any()) {
                var lblNoParkings = new Label {
                    Text = "Парковки не найдены",
                    Font = new Font("Segoe UI",12),
                    ForeColor = Color.Gray,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };
                panelParkings.Controls.Add(lblNoParkings);
                return;
            }

            int y = 10;
            foreach (var spot in parkingSpots) {
                var parkingPanel = CreateParkingPanel(spot);
                parkingPanel.Location = new Point(10,y);
                panelParkings.Controls.Add(parkingPanel);
                y += parkingPanel.Height + 10;
            }
        }

        private Panel CreateParkingPanel(ParkingSpot spot) {
            var panel = new Panel {
                Size = new Size(panelParkings.Width - 40,170), 
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Tag = spot.Id,
                Padding = new Padding(10)
            };

            var lblName = new Label {
                Text = spot.Name,
                Location = new Point(15,15),
                Font = new Font("Segoe UI",12,FontStyle.Bold),
                ForeColor = primaryColor,
                AutoSize = true
            };

           
            var lblAddress = new Label {
                Text = $"📍 {spot.Address}",
                Location = new Point(15,45),
                Font = new Font("Segoe UI",9),
                ForeColor = Color.Gray,
                AutoSize = true
            };

           
            var lblDistance = new Label {
                Text = $"📏 {spot.Distance} км от вас",
                Location = new Point(15,65),
                Font = new Font("Segoe UI",9),
                ForeColor = Color.Gray,
                AutoSize = true
            };

            
            var lblSpots = new Label {
                Text = $"🅿️ Свободно мест: {spot.AvailableSpots}/{spot.TotalSpots}",
                Location = new Point(panel.Width - 250,15), 
                Font = new Font("Segoe UI",10),
                ForeColor = spot.AvailableSpots > 5 ? accentColor : dangerColor,
                AutoSize = true
            };

            var lblRating = new Label {
                Text = $"⭐ {spot.Rating}/5",
                Location = new Point(panel.Width - 250,40), 
                Font = new Font("Segoe UI",10),
                ForeColor = Color.Orange,
                AutoSize = true
            };

            var lblPrice = new Label {
                Text = $"💵 {spot.PricePerHour} руб./час",
                Location = new Point(panel.Width - 250,65), 
                Font = new Font("Segoe UI",10,FontStyle.Bold),
                ForeColor = Color.Green,
                AutoSize = true
            };

           
            var lblDescription = new Label {
                Text = spot.Description,
                Location = new Point(15,90),
                Size = new Size(panel.Width - 270,50), 
                Font = new Font("Segoe UI",9),
                ForeColor = Color.DimGray
            };

            var btnBook = new Button {
                Text = spot.AvailableSpots > 0 ? "✅ Забронировать" : "❌ Нет мест",
                Location = new Point(panel.Width - 160,110), 
                Size = new Size(140,40), 
                BackColor = spot.AvailableSpots > 0 ? accentColor : Color.LightGray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI",10,FontStyle.Bold),
                Tag = spot.Id,
                Enabled = spot.AvailableSpots > 0,
                Name = $"btnBook_{spot.Id}"
            };

            btnBook.FlatAppearance.BorderSize = 0;
            btnBook.Click += BookParkingSpot;

            panel.Controls.AddRange(new Control[] { lblName, lblAddress, lblDistance, lblSpots,
        lblRating, lblPrice, lblDescription, btnBook });

            return panel;
        }

        private void BookParkingSpot(object sender,EventArgs e) {
            var button = sender as Button;
            if (button != null && button.Tag != null) {
                int spotId = (int)button.Tag;
                var spot = parkingSpots.FirstOrDefault(s => s.Id == spotId);

                if (spot != null && spot.AvailableSpots > 0) {
                    var bookingForm = new BookingForm(spot,currentUser);
                    if (bookingForm.ShowDialog() == DialogResult.OK) {
                        
                        var booking = new Booking {
                            Id = bookings.Count + 1,
                            ParkingSpotName = spot.Name,
                            StartTime = bookingForm.StartTime,
                            EndTime = bookingForm.EndTime,
                            TotalPrice = bookingForm.TotalPrice,
                            Status = "Активно"
                        };

                        bookings.Add(booking);
                        spot.AvailableSpots--;

                        ShowNotification($"Бронирование на {spot.Name} успешно создано!");
                        ShowBookingsPanel();
                    }
                }
            }
        }

        private void ShowBookingsPanel() {
            panelParkings.Visible = false;
            panelBookings.Visible = true;
            panelProfile.Visible = false;

            UpdateNavButtonsStyle(btnMyBookings);

            LoadBookings();

            lblMainTitle.Text = "Мои бронирования";
            lblStatus.Text = "Обновление статистики...";
        }

        private void LoadBookings() {
            panelBookings.Controls.Clear();

            if (!bookings.Any()) {
                var lblNoBookings = new Label {
                    Text = "У вас пока нет бронирований",
                    Font = new Font("Segoe UI",12),
                    ForeColor = Color.Gray,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };
                panelBookings.Controls.Add(lblNoBookings);
                return;
            }

            int y = 10;
            foreach (var booking in bookings.OrderByDescending(b => b.StartTime)) {
                var bookingPanel = CreateBookingPanel(booking);
                bookingPanel.Location = new Point(10,y);
                panelBookings.Controls.Add(bookingPanel);
                y += bookingPanel.Height + 10;
            }
        }

        private Panel CreateBookingPanel(Booking booking) {
            var panel = new Panel {
                Size = new Size(panelBookings.Width - 20,140),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10)
            };

          
            var statusColor = booking.Status == "Активно" ? accentColor :
                             booking.Status == "Завершено" ? Color.Gray : dangerColor;

            var lblStatus = new Label {
                Text = booking.Status,
                Location = new Point(panel.Width - 140,15), 
                Size = new Size(120,25), 
                BackColor = statusColor,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI",9,FontStyle.Bold)
            };

          
            var lblParkingName = new Label {
                Text = booking.ParkingSpotName,
                Location = new Point(15,15),
                Font = new Font("Segoe UI",12,FontStyle.Bold),
                ForeColor = primaryColor,
                AutoSize = true
            };

            var lblTime = new Label {
                Text = $"🕐 {booking.StartTime:dd.MM.yyyy HH:mm} - {booking.EndTime:HH:mm}",
                Location = new Point(15,45),
                Font = new Font("Segoe UI",10),
                ForeColor = Color.DimGray,
                AutoSize = true
            };

           
            var duration = booking.EndTime - booking.StartTime;
            var lblDuration = new Label {
                Text = $"⏱️ {duration.TotalHours:0.0} часов",
                Location = new Point(15,70),
                Font = new Font("Segoe UI",10),
                ForeColor = Color.DimGray,
                AutoSize = true
            };

            var lblPrice = new Label {
                Text = $"💵 {booking.TotalPrice} руб.",
                Location = new Point(15,95),
                Font = new Font("Segoe UI",11,FontStyle.Bold),
                ForeColor = Color.Green,
                AutoSize = true
            };

           
            if (booking.Status == "Активно") {
                var btnCancel = new Button {
                    Text = "❌ Отменить",
                    Location = new Point(panel.Width - 140,95), 
                    Size = new Size(120,30), 
                    BackColor = dangerColor,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI",9,FontStyle.Bold),
                    Tag = booking.Id
                };

                btnCancel.FlatAppearance.BorderSize = 0;
                btnCancel.Click += CancelBooking;
                panel.Controls.Add(btnCancel);
            }

            panel.Controls.AddRange(new Control[] { lblStatus, lblParkingName, lblTime,
        lblDuration, lblPrice });

            return panel;
        }

        private void CancelBooking(object sender,EventArgs e) {
            var button = sender as Button;
            if (button != null && button.Tag != null) {
                int bookingId = (int)button.Tag;
                var booking = bookings.FirstOrDefault(b => b.Id == bookingId);

                if (booking != null && MessageBox.Show($"Отменить бронирование на {booking.ParkingSpotName}?",
                    "Подтверждение",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) {
                    booking.Status = "Отменено";
                    ShowNotification("Бронирование отменено");
                    LoadBookings();
                }
            }
        }

        private void ShowProfilePanel() {
            panelParkings.Visible = false;
            panelBookings.Visible = false;
            panelProfile.Visible = true;

            UpdateNavButtonsStyle(btnProfile);

            LoadProfileInfo();

            lblMainTitle.Text = "Профиль";
            lblStatus.Text = "";
        }

        private void LoadProfileInfo() {
            panelProfile.Controls.Clear();

            if (currentUser == null) return;

            var profilePanel = new Panel {
                Size = new Size(500,450), 
                Location = new Point((panelProfile.Width - 500) / 2,50),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(20)
            };

            
            var avatarPanel = new Panel {
                Size = new Size(100,100),
                Location = new Point((profilePanel.Width - 100) / 2,30),
                BackColor = primaryColor
            };

            var lblInitials = new Label {
                Text = GetInitials(currentUser.FullName),
                Font = new Font("Segoe UI",24,FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            avatarPanel.Controls.Add(lblInitials);

            int y = 150;
            AddProfileField(profilePanel,"👤 ФИО:",currentUser.FullName ?? "Не указано",ref y);
            AddProfileField(profilePanel,"📧 Email:",currentUser.Email ?? "Не указан",ref y);
            AddProfileField(profilePanel,"📱 Телефон:",currentUser.Phone ?? "Не указан",ref y);
            AddProfileField(profilePanel,"🚗 Модель авто:",currentUser.CarModel ?? "Не указана",ref y);
            AddProfileField(profilePanel,"🔢 Номер авто:",currentUser.CarNumber ?? "Не указан",ref y);

      
            y += 10; 
            AddProfileField(profilePanel,"📅 Дата регистрации:",
                (currentUser.RegistrationDate != DateTime.MinValue ?
                    currentUser.RegistrationDate.ToString("dd.MM.yyyy") :
                    "Не указана"),
                ref y);

            profilePanel.Controls.Add(avatarPanel);
            panelProfile.Controls.Add(profilePanel);
        }

        private void AddProfileField(Panel parent,string label,string value,ref int y) {
            var lblTitle = new Label {
                Text = label,
                Location = new Point(40,y), 
                Font = new Font("Segoe UI",10,FontStyle.Bold), 
                ForeColor = Color.Gray,
                AutoSize = true
            };

            var lblValue = new Label {
                Text = value,
                Location = new Point(200,y), 
                Font = new Font("Segoe UI",10), 
                ForeColor = Color.Black,
                AutoSize = true
            };

            parent.Controls.Add(lblTitle);
            parent.Controls.Add(lblValue);
            y += 40; 
        }
        private string GetInitials(string fullName) {
            var parts = fullName.Split(' ');
            if (parts.Length >= 2)
                return $"{parts[0][0]}{parts[1][0]}".ToUpper();
            return fullName.Length >= 2 ? fullName.Substring(0,2).ToUpper() : "US";
        }

        private void UpdateNavButtonsStyle(Button activeButton) {
            var buttons = new[] { btnSearchParkings,btnMyBookings,btnProfile };

            foreach (var btn in buttons) {
                btn.BackColor = btn == activeButton ? primaryColor : Color.Transparent;
                btn.Font = new Font("Segoe UI",10,btn == activeButton ? FontStyle.Bold : FontStyle.Regular);
            }
        }

        private void Logout() {
            if (MessageBox.Show("Вы уверены, что хотите выйти?","Выход",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) {
                statusTimer?.Stop();
                notificationTimer?.Stop();

                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            statusTimer?.Stop();
            notificationTimer?.Stop();
        }


        private void DriverForm_Load(object sender,EventArgs e) {

        }

        private void btnProfile_Click(object sender,EventArgs e) {

        }
    }
}
