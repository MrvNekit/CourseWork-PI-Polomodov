using System;
using System.Windows.Forms;

namespace ParkingApp {
    public partial class Form1 : Form {
        private string selectedRole = "";

        public Form1() {
            InitializeComponent();

            // Подключаем обработчики событий
            this.driverBtn.Click += DriverBtn_Click;
            this.hostBtn.Click += HostBtn_Click;
            this.loginBtn.Click += LoginBtn_Click;
        }

        private void DriverBtn_Click(object sender,EventArgs e) {
            SelectRole("driver");
        }

        private void HostBtn_Click(object sender,EventArgs e) {
            SelectRole("host");
        }

        private void SelectRole(string role) {
            selectedRole = role;
            loginPanel.Visible = true;
            loginTextBox.Text = "";
            passwordTextBox.Text = "";
            loginTextBox.Focus();
        }

        private void LoginBtn_Click(object sender,EventArgs e) {
            Login(loginTextBox.Text,passwordTextBox.Text);
        }

        private void Login(string login,string password) {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password)) {
                MessageBox.Show("Введите логин и пароль","Ошибка",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if ((selectedRole == "driver" && login == "driver" && password == "123") ||
                   (selectedRole == "host" && login == "host" && password == "123")) {
                if (selectedRole == "driver") {
                    User testUser = new User {
                        FullName = "Иван Петров",
                        CarModel = "Toyota",
                        CarNumber = "A888C777"
                    };
                    DriverForm driverForm = new DriverForm();
                    driverForm.Show();
                }
                else // host
                {
                    User currentUser = new User {
                        Id = 1,
                        Name = "Администратор Паркинга",
                        FullName = "Сергей Сидоров",
                        Email = "admin@parking.com",
                        Phone = "+7 (999) 123-45-67",
                        Role = "host",
                        CompanyName = "Паркинг Центральный",
                        CompanyAddress = "ул. Центральная, д. 1",
                        RegistrationDate = DateTime.Now.AddYears(-1),
                        IsActive = true
                    };

                    HostForm hostForm = new HostForm(currentUser);
                    hostForm.Show();
                }

                this.Hide(); // Это относится ко всему блоку if (успешный вход)
            }
            else // Неверный логин/пароль
            {
                MessageBox.Show("Неверный логин или пароль","Ошибка входа",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }



        private void Form1_Load(object sender,EventArgs e) {

        }

        private void Form1_Load_1(object sender,EventArgs e) {

        }
    }
}
