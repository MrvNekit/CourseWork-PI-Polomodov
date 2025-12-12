namespace ParkingApp {
    partial class BookingForm {
        private System.ComponentModel.IContainer components = null;
        private Panel panelHeader;
        private Label lblHeader;
        private Label lblParkingName;
        private Label lblAddress;
        private Label lblPricePerHour;
        private Label lblAvailableSpots;
        private Label lblStartTime;
        private DateTimePicker dtpStartTime;
        private Label lblEndTime;
        private DateTimePicker dtpEndTime;
        private Label lblDuration;
        private Label lblDurationValue;
        private Label lblTotalPriceTitle;
        private Label lblTotalPriceValue;
        private Button btnConfirm;
        private Button btnCancel;
        private Panel panelSeparator;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            panelHeader = new Panel();
            lblHeader = new Label();
            lblParkingName = new Label();
            lblAddress = new Label();
            lblPricePerHour = new Label();
            lblAvailableSpots = new Label();
            lblStartTime = new Label();
            dtpStartTime = new DateTimePicker();
            lblEndTime = new Label();
            dtpEndTime = new DateTimePicker();
            lblDuration = new Label();
            lblDurationValue = new Label();
            lblTotalPriceTitle = new Label();
            lblTotalPriceValue = new Label();
            btnConfirm = new Button();
            btnCancel = new Button();
            panelSeparator = new Panel();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(52,152,219);
            panelHeader.Controls.Add(lblHeader);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0,0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(438,56);
            panelHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI",14F,FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(18,14);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(247,25);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Бронирование парковки";
            // 
            // lblParkingName
            // 
            lblParkingName.AutoSize = true;
            lblParkingName.Font = new Font("Segoe UI",12F,FontStyle.Bold);
            lblParkingName.Location = new Point(18,75);
            lblParkingName.Name = "lblParkingName";
            lblParkingName.Size = new Size(194,21);
            lblParkingName.TabIndex = 1;
            lblParkingName.Text = "Центральная парковка";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI",10F);
            lblAddress.ForeColor = Color.Gray;
            lblAddress.Location = new Point(18,108);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(127,19);
            lblAddress.TabIndex = 2;
            lblAddress.Text = "ул. Центральная, 1";
            // 
            // lblPricePerHour
            // 
            lblPricePerHour.AutoSize = true;
            lblPricePerHour.Font = new Font("Segoe UI",10F,FontStyle.Bold);
            lblPricePerHour.ForeColor = Color.Green;
            lblPricePerHour.Location = new Point(18,136);
            lblPricePerHour.Name = "lblPricePerHour";
            lblPricePerHour.Size = new Size(96,19);
            lblPricePerHour.TabIndex = 3;
            lblPricePerHour.Text = "100 руб./час";
            // 
            // lblAvailableSpots
            // 
            lblAvailableSpots.AutoSize = true;
            lblAvailableSpots.Font = new Font("Segoe UI",10F);
            lblAvailableSpots.Location = new Point(18,164);
            lblAvailableSpots.Name = "lblAvailableSpots";
            lblAvailableSpots.Size = new Size(126,19);
            lblAvailableSpots.TabIndex = 4;
            lblAvailableSpots.Text = "Доступно мест: 15";
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Font = new Font("Segoe UI",10F,FontStyle.Bold);
            lblStartTime.Location = new Point(18,216);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(137,19);
            lblStartTime.TabIndex = 6;
            lblStartTime.Text = "Начало парковки:";
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpStartTime.Font = new Font("Segoe UI",10F);
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(18,244);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(176,25);
            dtpStartTime.TabIndex = 7;
            dtpStartTime.ValueChanged += dtpStartTime_ValueChanged;
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.Font = new Font("Segoe UI",10F,FontStyle.Bold);
            lblEndTime.Location = new Point(219,216);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(129,19);
            lblEndTime.TabIndex = 8;
            lblEndTime.Text = "Конец парковки:";
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpEndTime.Font = new Font("Segoe UI",10F);
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(219,244);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(176,25);
            dtpEndTime.TabIndex = 9;
            dtpEndTime.ValueChanged += dtpEndTime_ValueChanged;
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Font = new Font("Segoe UI",10F,FontStyle.Bold);
            lblDuration.Location = new Point(18,291);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(110,19);
            lblDuration.TabIndex = 10;
            lblDuration.Text = "Длительность:";
            // 
            // lblDurationValue
            // 
            lblDurationValue.AutoSize = true;
            lblDurationValue.Font = new Font("Segoe UI",10F);
            lblDurationValue.Location = new Point(131,291);
            lblDurationValue.Name = "lblDurationValue";
            lblDurationValue.Size = new Size(45,19);
            lblDurationValue.TabIndex = 11;
            lblDurationValue.Text = "1 час.";
            // 
            // lblTotalPriceTitle
            // 
            lblTotalPriceTitle.AutoSize = true;
            lblTotalPriceTitle.Font = new Font("Segoe UI",12F,FontStyle.Bold);
            lblTotalPriceTitle.Location = new Point(18,328);
            lblTotalPriceTitle.Name = "lblTotalPriceTitle";
            lblTotalPriceTitle.Size = new Size(83,21);
            lblTotalPriceTitle.TabIndex = 12;
            lblTotalPriceTitle.Text = "К оплате:";
            // 
            // lblTotalPriceValue
            // 
            lblTotalPriceValue.AutoSize = true;
            lblTotalPriceValue.Font = new Font("Segoe UI",16F,FontStyle.Bold);
            lblTotalPriceValue.ForeColor = Color.Green;
            lblTotalPriceValue.Location = new Point(131,323);
            lblTotalPriceValue.Name = "lblTotalPriceValue";
            lblTotalPriceValue.Size = new Size(103,30);
            lblTotalPriceValue.TabIndex = 13;
            lblTotalPriceValue.Text = "100 руб.";
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new Font("Segoe UI",10F,FontStyle.Bold);
            btnConfirm.Location = new Point(175,384);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(140,42);
            btnConfirm.TabIndex = 14;
            btnConfirm.Text = "Забронировать";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI",10F);
            btnCancel.Location = new Point(324,384);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(96,42);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // panelSeparator
            // 
            panelSeparator.BackColor = Color.LightGray;
            panelSeparator.Location = new Point(18,197);
            panelSeparator.Name = "panelSeparator";
            panelSeparator.Size = new Size(402,1);
            panelSeparator.TabIndex = 5;
            // 
            // BookingForm
            // 
            AutoScaleDimensions = new SizeF(7F,15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438,450);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(lblTotalPriceValue);
            Controls.Add(lblTotalPriceTitle);
            Controls.Add(lblDurationValue);
            Controls.Add(lblDuration);
            Controls.Add(dtpEndTime);
            Controls.Add(lblEndTime);
            Controls.Add(dtpStartTime);
            Controls.Add(lblStartTime);
            Controls.Add(panelSeparator);
            Controls.Add(lblAvailableSpots);
            Controls.Add(lblPricePerHour);
            Controls.Add(lblAddress);
            Controls.Add(lblParkingName);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BookingForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Бронирование парковки";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}