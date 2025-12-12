using System.Windows.Forms;

namespace ParkingApp {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            titleLabel = new Label();
            subtitleLabel = new Label();
            driverBtn = new Button();
            hostBtn = new Button();
            loginPanel = new Panel();
            loginBtn = new Button();
            passwordTextBox = new TextBox();
            loginTextBox = new TextBox();
            loginTitle = new Label();
            loginPanel.SuspendLayout();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI",32F,FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(44,62,80);
            titleLabel.Location = new Point(307,38);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(231,59);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "ПАРКИНГ";
            // 
            // subtitleLabel
            // 
            subtitleLabel.AutoSize = true;
            subtitleLabel.Font = new Font("Segoe UI",14F);
            subtitleLabel.ForeColor = Color.FromArgb(127,140,141);
            subtitleLabel.Location = new Point(323,97);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(193,25);
            subtitleLabel.TabIndex = 1;
            subtitleLabel.Text = "Выберите вашу роль";
            // 
            // driverBtn
            // 
            driverBtn.BackColor = Color.FromArgb(52,152,219);
            driverBtn.FlatAppearance.BorderSize = 0;
            driverBtn.FlatStyle = FlatStyle.Flat;
            driverBtn.Font = new Font("Segoe UI",16F,FontStyle.Bold);
            driverBtn.ForeColor = Color.White;
            driverBtn.Location = new Point(306,150);
            driverBtn.Margin = new Padding(3,2,3,2);
            driverBtn.Name = "driverBtn";
            driverBtn.Size = new Size(262,60);
            driverBtn.TabIndex = 2;
            driverBtn.Text = "🚗 ВОДИТЕЛЬ";
            driverBtn.UseVisualStyleBackColor = false;
            // 
            // hostBtn
            // 
            hostBtn.BackColor = Color.FromArgb(46,204,113);
            hostBtn.FlatAppearance.BorderSize = 0;
            hostBtn.FlatStyle = FlatStyle.Flat;
            hostBtn.Font = new Font("Segoe UI",16F,FontStyle.Bold);
            hostBtn.ForeColor = Color.White;
            hostBtn.Location = new Point(306,225);
            hostBtn.Margin = new Padding(3,2,3,2);
            hostBtn.Name = "hostBtn";
            hostBtn.Size = new Size(262,60);
            hostBtn.TabIndex = 3;
            hostBtn.Text = "🏢 ВЛАДЕЛЕЦ";
            hostBtn.UseVisualStyleBackColor = false;
            // 
            // loginPanel
            // 
            loginPanel.BackColor = Color.White;
            loginPanel.BorderStyle = BorderStyle.FixedSingle;
            loginPanel.Controls.Add(loginBtn);
            loginPanel.Controls.Add(passwordTextBox);
            loginPanel.Controls.Add(loginTextBox);
            loginPanel.Controls.Add(loginTitle);
            loginPanel.Location = new Point(262,300);
            loginPanel.Margin = new Padding(3,2,3,2);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(350,188);
            loginPanel.TabIndex = 4;
            loginPanel.Visible = false;
            // 
            // loginBtn
            // 
            loginBtn.BackColor = Color.FromArgb(41,128,185);
            loginBtn.FlatAppearance.BorderSize = 0;
            loginBtn.FlatStyle = FlatStyle.Flat;
            loginBtn.Font = new Font("Segoe UI",12F,FontStyle.Bold);
            loginBtn.ForeColor = Color.White;
            loginBtn.Location = new Point(44,128);
            loginBtn.Margin = new Padding(3,2,3,2);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(262,30);
            loginBtn.TabIndex = 5;
            loginBtn.Text = "ВОЙТИ";
            loginBtn.UseVisualStyleBackColor = false;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Font = new Font("Segoe UI",12F);
            passwordTextBox.Location = new Point(44,90);
            passwordTextBox.Margin = new Padding(3,2,3,2);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.PlaceholderText = "Пароль";
            passwordTextBox.Size = new Size(263,29);
            passwordTextBox.TabIndex = 4;
            // 
            // loginTextBox
            // 
            loginTextBox.Font = new Font("Segoe UI",12F);
            loginTextBox.Location = new Point(44,52);
            loginTextBox.Margin = new Padding(3,2,3,2);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.PlaceholderText = "Логин";
            loginTextBox.Size = new Size(263,29);
            loginTextBox.TabIndex = 3;
            // 
            // loginTitle
            // 
            loginTitle.AutoSize = true;
            loginTitle.Font = new Font("Segoe UI",18F,FontStyle.Bold);
            loginTitle.ForeColor = Color.FromArgb(44,62,80);
            loginTitle.Location = new Point(71,18);
            loginTitle.Name = "loginTitle";
            loginTitle.Size = new Size(195,32);
            loginTitle.TabIndex = 0;
            loginTitle.Text = "Вход в систему";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F,15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240,244,247);
            ClientSize = new Size(875,525);
            Controls.Add(loginPanel);
            Controls.Add(hostBtn);
            Controls.Add(driverBtn);
            Controls.Add(subtitleLabel);
            Controls.Add(titleLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3,2,3,2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Паркинг - Система управления парковками";
            Load += Form1_Load_1;
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label titleLabel;
        private Label subtitleLabel;
        private Button driverBtn;
        private Button hostBtn;
        private Panel loginPanel;
        private Button loginBtn;
        private TextBox passwordTextBox;
        private TextBox loginTextBox;
        private Label loginTitle;
    }
}