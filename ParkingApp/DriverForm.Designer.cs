namespace ParkingApp {
    partial class DriverForm {
        private System.ComponentModel.IContainer components = null;
        private Panel panelSidebar;
        private Label lblTitle;
        private Label lblUserName;
        private Label lblCarInfo;
        private Button btnSearchParkings;
        private Button btnMyBookings;
        private Button btnProfile;
        private Button btnLogout;
        private Panel panelMain;
        private Label lblMainTitle;
        private Label lblStatus;
        private Panel panelParkings;
        private Panel panelBookings;
        private Panel panelProfile;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label labelBalance;
        private System.Windows.Forms.Button buttonAddBalance;
        
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            panelSidebar = new Panel();
            btnLogout = new Button();
            btnProfile = new Button();
            btnMyBookings = new Button();
            btnSearchParkings = new Button();
            lblCarInfo = new Label();
            lblUserName = new Label();
            lblTitle = new Label();
            panelMain = new Panel();
            balancePanel = new Panel();
            labelBalance = new Label();
            buttonAddBalance = new Button();
            panelProfile = new Panel();
            panelBookings = new Panel();
            panelParkings = new Panel();
            lblStatus = new Label();
            lblMainTitle = new Label();
            panelHeader = new Panel();
            labelWelcome = new Label();
            panelSidebar.SuspendLayout();
            panelMain.SuspendLayout();
            balancePanel.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(25,25,25);
            panelSidebar.Controls.Add(btnLogout);
            panelSidebar.Controls.Add(btnProfile);
            panelSidebar.Controls.Add(btnMyBookings);
            panelSidebar.Controls.Add(btnSearchParkings);
            panelSidebar.Controls.Add(lblCarInfo);
            panelSidebar.Controls.Add(lblUserName);
            panelSidebar.Controls.Add(lblTitle);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0,0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(300,720);
            panelSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI",10F,FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(0,650);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(25,0,0,0);
            btnLogout.Size = new Size(300,50);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "🚪 Выйти";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnProfile
            // 
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.Font = new Font("Segoe UI",10F);
            btnProfile.ForeColor = Color.White;
            btnProfile.Location = new Point(0,260);
            btnProfile.Name = "btnProfile";
            btnProfile.Padding = new Padding(25,0,0,0);
            btnProfile.Size = new Size(300,50);
            btnProfile.TabIndex = 5;
            btnProfile.Text = "  👤 Профиль";
            btnProfile.TextAlign = ContentAlignment.MiddleLeft;
            btnProfile.UseVisualStyleBackColor = true;
            // 
            // btnMyBookings
            // 
            btnMyBookings.FlatStyle = FlatStyle.Flat;
            btnMyBookings.Font = new Font("Segoe UI",10F);
            btnMyBookings.ForeColor = Color.White;
            btnMyBookings.Location = new Point(0,210);
            btnMyBookings.Name = "btnMyBookings";
            btnMyBookings.Padding = new Padding(25,0,0,0);
            btnMyBookings.Size = new Size(300,50);
            btnMyBookings.TabIndex = 4;
            btnMyBookings.Text = "  📋 Мои бронирования";
            btnMyBookings.TextAlign = ContentAlignment.MiddleLeft;
            btnMyBookings.UseVisualStyleBackColor = true;
            // 
            // btnSearchParkings
            // 
            btnSearchParkings.FlatStyle = FlatStyle.Flat;
            btnSearchParkings.Font = new Font("Segoe UI",10F);
            btnSearchParkings.ForeColor = Color.White;
            btnSearchParkings.Location = new Point(0,160);
            btnSearchParkings.Name = "btnSearchParkings";
            btnSearchParkings.Padding = new Padding(25,0,0,0);
            btnSearchParkings.Size = new Size(300,50);
            btnSearchParkings.TabIndex = 3;
            btnSearchParkings.Text = "  🔍 Поиск парковок";
            btnSearchParkings.TextAlign = ContentAlignment.MiddleLeft;
            btnSearchParkings.UseVisualStyleBackColor = true;
            // 
            // lblCarInfo
            // 
            lblCarInfo.AutoSize = true;
            lblCarInfo.Font = new Font("Segoe UI",10F);
            lblCarInfo.ForeColor = Color.Silver;
            lblCarInfo.Location = new Point(20,105);
            lblCarInfo.Name = "lblCarInfo";
            lblCarInfo.Size = new Size(119,19);
            lblCarInfo.TabIndex = 2;
            lblCarInfo.Text = "128BC777 Toyota";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI",12F,FontStyle.Bold);
            lblUserName.ForeColor = Color.White;
            lblUserName.Location = new Point(20,70);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(112,21);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "Иван Петров";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI",14F,FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20,20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(199,25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Паркинг - Водитель";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(balancePanel);
            panelMain.Controls.Add(panelProfile);
            panelMain.Controls.Add(panelBookings);
            panelMain.Controls.Add(panelParkings);
            panelMain.Controls.Add(lblStatus);
            panelMain.Controls.Add(lblMainTitle);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(300,0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(900,720);
            panelMain.TabIndex = 1;
            // 
            // balancePanel
            // 
            balancePanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            balancePanel.Controls.Add(labelBalance);
            balancePanel.Controls.Add(buttonAddBalance);
            balancePanel.Location = new Point(332,20);
            balancePanel.Name = "balancePanel";
            balancePanel.Size = new Size(235,39);
            balancePanel.TabIndex = 0;
            // 
            // labelBalance
            // 
            labelBalance.AutoSize = true;
            labelBalance.Font = new Font("Segoe UI",12F,FontStyle.Bold);
            labelBalance.ForeColor = Color.DarkGreen;
            labelBalance.Location = new Point(9,9);
            labelBalance.Name = "labelBalance";
            labelBalance.Size = new Size(97,21);
            labelBalance.TabIndex = 1;
            labelBalance.Text = "Баланс: 0 ₽";
            // 
            // buttonAddBalance
            // 
            buttonAddBalance.BackColor = Color.Gold;
            buttonAddBalance.FlatStyle = FlatStyle.Flat;
            buttonAddBalance.Font = new Font("Segoe UI",10F,FontStyle.Bold);
            buttonAddBalance.Location = new Point(130,4);
            buttonAddBalance.Name = "buttonAddBalance";
            buttonAddBalance.Size = new Size(105,33);
            buttonAddBalance.TabIndex = 2;
            buttonAddBalance.Text = "Пополнить";
            buttonAddBalance.UseVisualStyleBackColor = false;
            buttonAddBalance.Click += buttonAddBalance_Click;
            // 
            // panelProfile
            // 
            panelProfile.AutoScroll = true;
            panelProfile.Location = new Point(26,94);
            panelProfile.Name = "panelProfile";
            panelProfile.Size = new Size(735,562);
            panelProfile.TabIndex = 4;
            panelProfile.Visible = false;
            // 
            // panelBookings
            // 
            panelBookings.AutoScroll = true;
            panelBookings.Location = new Point(26,94);
            panelBookings.Name = "panelBookings";
            panelBookings.Size = new Size(735,562);
            panelBookings.TabIndex = 3;
            panelBookings.Visible = false;
            // 
            // panelParkings
            // 
            panelParkings.AutoScroll = true;
            panelParkings.Location = new Point(26,94);
            panelParkings.Name = "panelParkings";
            panelParkings.Size = new Size(735,562);
            panelParkings.TabIndex = 2;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI",9F);
            lblStatus.ForeColor = Color.Gray;
            lblStatus.Location = new Point(26,56);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(168,15);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Поиск доступных парковок...";
            // 
            // lblMainTitle
            // 
            lblMainTitle.AutoSize = true;
            lblMainTitle.Font = new Font("Segoe UI",16F,FontStyle.Bold);
            lblMainTitle.ForeColor = Color.FromArgb(52,152,219);
            lblMainTitle.Location = new Point(26,19);
            lblMainTitle.Name = "lblMainTitle";
            lblMainTitle.Size = new Size(188,30);
            lblMainTitle.TabIndex = 0;
            lblMainTitle.Text = "Поиск парковок";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.SteelBlue;
            panelHeader.Controls.Add(labelWelcome);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0,0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(800,80);
            panelHeader.TabIndex = 0;
            // 
            // labelWelcome
            // 
            labelWelcome.AutoSize = true;
            labelWelcome.Font = new Font("Segoe UI",14F,FontStyle.Bold);
            labelWelcome.ForeColor = Color.White;
            labelWelcome.Location = new Point(20,20);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(200,25);
            labelWelcome.TabIndex = 0;
            labelWelcome.Text = "Добро пожаловать!";
            // 
            // DriverForm
            // 
            AutoScaleDimensions = new SizeF(7F,15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200,720);
            Controls.Add(panelMain);
            Controls.Add(panelSidebar);
            Name = "DriverForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Панель водителя - Паркинг";
            panelSidebar.ResumeLayout(false);
            panelSidebar.PerformLayout();
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            balancePanel.ResumeLayout(false);
            balancePanel.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }
        private Panel balancePanel;
    }
}