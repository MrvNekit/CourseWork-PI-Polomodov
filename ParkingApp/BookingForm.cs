using System;
using System.Drawing;
using System.Windows.Forms;

namespace ParkingApp {
    public partial class BookingForm : Form {
        private ParkingSpot spot;
        private User user;

        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public decimal TotalPrice { get; private set; }

        // Цвета
        private Color primaryColor = Color.FromArgb(52,152,219);
        private Color accentColor = Color.FromArgb(46,204,113);
        private Color dangerColor = Color.FromArgb(231,76,60);

        public BookingForm(ParkingSpot parkingSpot,User currentUser) {
            InitializeComponent();
            spot = parkingSpot;
            user = currentUser;
            InitializeForm();
            ApplyStyles();

            // Инициализация времени при создании формы, а не в обработчике Load
            InitializeDateTimeControls();
        }

        private void InitializeForm() {
            this.Text = $"Бронирование парковки";
            lblParkingName.Text = spot.Name;
            lblAddress.Text = $"📍 {spot.Address}";
            lblPricePerHour.Text = $"💵 {spot.PricePerHour} руб./час";
            lblAvailableSpots.Text = $"🅿️ Доступно мест: {spot.AvailableSpots}";

            dtpStartTime.Value = DateTime.Now;
            dtpEndTime.Value = DateTime.Now.AddHours(1);

            CalculatePrice();
        }

        private void InitializeDateTimeControls() {
            // Устанавливаем минимальное и максимальное время
            dtpStartTime.MinDate = DateTime.Now;
            dtpStartTime.MaxDate = DateTime.Now.AddDays(30);

            dtpEndTime.MinDate = DateTime.Now;
            dtpEndTime.MaxDate = DateTime.Now.AddDays(30).AddHours(1);
        }

        private void ApplyStyles() {
            // Стиль для формы
            this.BackColor = Color.White;

            // Стиль для панели заголовка
            panelHeader.BackColor = primaryColor;
            lblHeader.ForeColor = Color.White;
            lblHeader.Font = new Font("Segoe UI",14,FontStyle.Bold);

            // Стиль для информационных полей
            lblParkingName.Font = new Font("Segoe UI",12,FontStyle.Bold);
            lblParkingName.ForeColor = Color.FromArgb(50,50,50);

            lblAddress.Font = new Font("Segoe UI",10);
            lblAddress.ForeColor = Color.Gray;

            lblPricePerHour.Font = new Font("Segoe UI",10,FontStyle.Bold);
            lblPricePerHour.ForeColor = Color.Green;

            lblAvailableSpots.Font = new Font("Segoe UI",10);
            lblAvailableSpots.ForeColor = spot.AvailableSpots > 5 ? Color.Green : dangerColor;

            // Стиль для меток
            lblStartTime.Font = new Font("Segoe UI",10,FontStyle.Bold);
            lblEndTime.Font = new Font("Segoe UI",10,FontStyle.Bold);
            lblDuration.Font = new Font("Segoe UI",10,FontStyle.Bold);
            lblTotalPriceTitle.Font = new Font("Segoe UI",10,FontStyle.Bold);

            // Стиль для DateTimePicker
            dtpStartTime.Font = new Font("Segoe UI",10);
            dtpEndTime.Font = new Font("Segoe UI",10);

            // Стиль для кнопок
            btnConfirm.BackColor = accentColor;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Font = new Font("Segoe UI",10,FontStyle.Bold);

            btnCancel.BackColor = Color.LightGray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.ForeColor = Color.Black;
            btnCancel.Font = new Font("Segoe UI",10);
        }

        private void CalculatePrice() {
            TimeSpan duration = dtpEndTime.Value - dtpStartTime.Value;
            if (duration.TotalHours < 0) {
                MessageBox.Show("Время окончания должно быть позже времени начала","Ошибка",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);
                dtpEndTime.Value = dtpStartTime.Value.AddHours(1);
                return;
            }

            decimal hours = (decimal)Math.Ceiling(duration.TotalHours);
            if (hours < 1) hours = 1; // Минимум 1 час

            TotalPrice = hours * spot.PricePerHour;
            lblDurationValue.Text = $"{hours} час.";
            lblTotalPriceValue.Text = $"{TotalPrice} руб.";
        }

        private void dtpStartTime_ValueChanged(object sender,EventArgs e) {
            if (dtpEndTime.Value < dtpStartTime.Value)
                dtpEndTime.Value = dtpStartTime.Value.AddHours(1);
            CalculatePrice();
        }

        private void dtpEndTime_ValueChanged(object sender,EventArgs e) {
            CalculatePrice();
        }

        private void btnConfirm_Click(object sender,EventArgs e) {
            if (dtpEndTime.Value <= dtpStartTime.Value) {
                MessageBox.Show("Время окончания должно быть позже времени начала","Ошибка",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            TimeSpan duration = dtpEndTime.Value - dtpStartTime.Value;
            if (duration.TotalHours > 24) {
                if (MessageBox.Show($"Вы собираетесь забронировать парковку на {duration.TotalHours:0.0} часов. Продолжить?",
                    "Подтверждение",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) {
                    return;
                }
            }

            StartTime = dtpStartTime.Value;
            EndTime = dtpEndTime.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender,EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // УДАЛЕНО: обработчик BookingForm_Load - перенесен в конструктор
    


    }
}
